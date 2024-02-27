Imports System.Drawing.Imaging
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.ToastNotifications
Imports DevExpress.XtraSplashScreen

Public Class frmMain
    Private opnedHandle As IOverlaySplashScreenHandle
    Private appset As New AppSettings
    Private coDate As New CutoffDate
    Private OpenedForms As New List(Of FormsHandle)
    Private WithEvents notify As EICANotifications

    Delegate Sub GNotifications(loopBlockagesCount As Integer, solorunBlockagesCount As Integer, pushedNotification As DataTable, pushedMappedNotification As DataTable)


    Private Sub GetNotifications(loopBlockagesCount As Integer, solorunBlockagesCount As Integer, pushedNotification As DataTable, pushedMappedNotification As DataTable)
        notify.Cancel()

        'Loop BLockages
        If loopBlockagesCount = 0 Then
            lblLoopBlockages.Visibility = BarItemVisibility.OnlyInCustomizing
        Else
            lblLoopBlockages.Visibility = BarItemVisibility.Always
        End If
        lblLoopBlockages.Caption = "My Loop Blockages: " & loopBlockagesCount

        'Solo Run BLockages
        If solorunBlockagesCount = 0 Then
            lblSolorunBlockages.Visibility = BarItemVisibility.OnlyInCustomizing
        Else
            lblSolorunBlockages.Visibility = BarItemVisibility.Always
        End If
        lblSolorunBlockages.Caption = "My Solo Run Blockages: " & solorunBlockagesCount

        'Pushed Notification
        If pushedNotification.Rows.Count > 0 Then
            Dim frm As New frmNotifications
            frm.grd.DataSource = pushedNotification
            frm.gv.BestFitColumns(True)
            frm.Show()
        End If

        'Pushed Mapped Notification
        If pushedMappedNotification.Rows.Count > 0 Then
            For Inx As Integer = 0 To pushedMappedNotification.Rows.Count - 1
                Dim frm As New frmNotificationsMaping With {
                                .Text = "Notifications: Shared Actions"
                                }
                frm.lblFrom.Text = pushedMappedNotification.Rows(Inx).Item("From") & " Shared with you:"
                frm.lblDes.Text = pushedMappedNotification.Rows(Inx).Item("Message")
                frm.lblHeader.Text = pushedMappedNotification.Rows(Inx).Item("Header")
                frm.MapFilter = pushedMappedNotification.Rows(Inx).Item("MappingCategory")
                frm.MapName = pushedMappedNotification.Rows(Inx).Item("Header")
                frm.Show()
            Next

        End If


        notificationsTimer.Start()
    End Sub

    Private Sub globatNotis(loopBlockagesCount As Integer, solorunBlockagesCount As Integer, pushedNotification As DataTable, pushedMappedNotification As DataTable) Handles notify.GlobalNotifications
        notificationsTimer.Stop()

        If RibbonControl1.InvokeRequired Then
            Dim d As New GNotifications(AddressOf GetNotifications)
            RibbonControl1.Invoke(d, New Object() {loopBlockagesCount, solorunBlockagesCount, pushedNotification, pushedMappedNotification})
        End If
    End Sub
    Private Sub GetUserSkin()
        Try
            Dim skinName As String = GetSetting("TR", "EIKA", "skinName" & DB.DataBaseName & DB.DataBaseLocation & Users.userName, "The Bezier")
            Dim colorPalette As String = GetSetting("TR", "EIKA", "colorPalette" & DB.DataBaseName & DB.DataBaseLocation & Users.userName, "Default")
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName, colorPalette)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveUserSkin(ByVal skinName As String, ByVal colorPalette As String)
        Try
            SaveSetting("TR", "EIKA", "skinName" & DB.DataBaseName & DB.DataBaseLocation & Users.userName, skinName)
            SaveSetting("TR", "EIKA", "colorPalette" & DB.DataBaseName & DB.DataBaseLocation & Users.userName, colorPalette)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MdiChildClosed(formText As String)
        Dim frmCount As Integer = 0
        For Each frm As Form In Me.MdiChildren
            If frm.Text = formText Then
                frmCount += 1
            End If
        Next
        If frmCount = 1 Then
            For Each b As DevExpress.XtraEditors.SimpleButton In stackPanel.Controls
                If b.Text = formText Then
                    stackPanel.Controls.Remove(b)
                End If
            Next
        End If
    End Sub
    Private Sub HandleSideButton(sender As Object, e As EventArgs)
        Dim fptr As String = OpenedForms.Find(Function(f) f.Id = sender.text).Id
        For Each frm As Form In Me.MdiChildren
            If frm.Text = fptr Then
                frm.WindowState = FormWindowState.Maximized
                frm.Activate()
            End If
        Next
    End Sub
    Public Sub AddToQuickAccess(ByRef frm As DevExpress.XtraBars.Ribbon.RibbonForm)
        Try
            Dim btnExists As Boolean = False
            For Each b As DevExpress.XtraEditors.SimpleButton In stackPanel.Controls
                If b.Text = frm.Text Then
                    btnExists = True
                End If
            Next
            If Not btnExists Then
                Dim btn As New DevExpress.XtraEditors.SimpleButton
                btn.Height = 55
                btn.Text = frm.Text
                btn.Width = stackPanel.Width
                OpenedForms.Add(New FormsHandle(frm.Handle, frm.Text))
                AddHandler btn.Click, AddressOf HandleSideButton
                btn.ImageOptions.Image = frm.IconOptions.Image
                stackPanel.Controls.Add(btn)

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub PrepareSettingsPanel()
        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            gpAdmin.Visible = True
        Else
            gpAdmin.Visible = False
        End If
        If Users.userType = String.Empty Then
            gpAdmin.Visible = True
        End If
        tgLoopIntegrity.IsOn = appset.LoopIntegrity
        tgSolorunIntegrity.IsOn = appset.SolorunIntegrity
        lblCutoffDate.Text = Format(coDate.CurrentCutoffDate(), "dddd, dd-MMMM-yyyy")
        lblDBVersion.Text = appset.DBVersion
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub DisableAllRibbons()
        lblDBName.Caption = "DB: None"
        lblServer.Caption = "Server: None"
        rpHandover.Visible = False
        rpEng.Visible = False
        rpQC.Visible = False
        rpPrecom.Visible = False
        rpPlanning.Visible = False
        rpPC.Visible = False
        rpHandover.Visible = False
        rpSupportTeam.Visible = False
        barBtnHandoverData.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        gpAdmin.Visible = False
    End Sub
    Private Sub HandleDataReadError(ByVal er As String)
        Try
            Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
            Dim note As New ToastNotification("DataConnectionError", img, "Data Error", er, String.Empty, ToastNotificationTemplate.ImageAndText02)
            ToastNotificationsManager.Notifications.Add(note)
            ToastNotificationsManager.ShowNotification("DataConnectionError")
            ToastNotificationsManager.Notifications.Remove(note)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HandleDataConnectionError(ByVal er As String)
        Try
            Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
            Dim note As New ToastNotification("DataConnectionError", img, "Data Error", er, String.Empty, ToastNotificationTemplate.ImageAndText02)
            ToastNotificationsManager.Notifications.Add(note)
            ToastNotificationsManager.ShowNotification("DataConnectionError")
            ToastNotificationsManager.Notifications.Remove(note)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HandleILDConnectionError(ByVal er As String)
        Try
            Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
            Dim note As New ToastNotification("DataConnectionError", img, "Data Error", er, String.Empty, ToastNotificationTemplate.ImageAndText02)
            ToastNotificationsManager.Notifications.Add(note)
            ToastNotificationsManager.ShowNotification("DataConnectionError")
            ToastNotificationsManager.Notifications.Remove(note)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HandleDataExecuteError(ByVal er As String)
        Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
        Dim note As New ToastNotification("DataExecuteError", img, "Data Error", er, String.Empty, ToastNotificationTemplate.ImageAndText02)
        ToastNotificationsManager.Notifications.Add(note)
        ToastNotificationsManager.ShowNotification("DataExecuteError")
        ToastNotificationsManager.Notifications.Remove(note)
    End Sub
    Private Sub HandleReadFileError(ByVal er As String)
        Try
            Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
            Dim note As New ToastNotification("DataExecuteError", img, "Data Error", er, String.Empty, ToastNotificationTemplate.ImageAndText02)
            ToastNotificationsManager.Notifications.Add(note)
            ToastNotificationsManager.ShowNotification("DataExecuteError")
            ToastNotificationsManager.Notifications.Remove(note)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckAuth()
        DisableAllRibbons()
        lblUserName.Caption = Users.userFullName


        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
            rpEng.Visible = True
            rpConstruction.Visible = True
            rpQC.Visible = True
            rpPrecom.Visible = True
            rpPlanning.Visible = True
            rpPC.Visible = True
            rpSupportTeam.Visible = True
            gpAdmin.Visible = True
        End If
        If InStr(Users.userType, "handover", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            rpQC.Visible = True
        End If
        If InStr(Users.userType, "precomm", CompareMethod.Text) > 0 Then
            rpPrecom.Visible = True
        End If
        If InStr(Users.userType, "planning", CompareMethod.Text) > 0 Then
            rpPlanning.Visible = True
        End If
        If InStr(Users.userType, "production", CompareMethod.Text) > 0 Then
            rpPC.Visible = True
        End If
        If InStr(Users.userType, "support team", CompareMethod.Text) > 0 Then
            rpSupportTeam.Visible = True
        End If
        If InStr(Users.userType, "folder admin", CompareMethod.Text) > 0 Then
            barBtnHandoverData.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
    End Sub

    Public Sub HandleUserChanged()
        CheckAuth()
    End Sub
    Public Sub OnConnected()

    End Sub
    Public Sub OnDisConnected()
        'lblEICACon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        DisableAllRibbons()
    End Sub
    Public Sub OnEICAConnected()
        'lblEICACon.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        lblDBName.Caption = "DB: " & DBName
        lblServer.Caption = "Server: " & DBPath
    End Sub
    Public Sub OnEICADisConnected()
        'lblEICACon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        lblDBName.Caption = "DB: None"
        lblServer.Caption = "Server: None"
        DisableAllRibbons()
    End Sub
    Private Sub checkProjectUUID()
        Users.ProUUID = GetSetting("TR", "LoopApp", "ProjectUUID", String.Empty)
        If Users.ProUUID = String.Empty Then
            Dim frm As New frmSelectProject
            frm.ShowDialog(Me)
        End If
        If DB.ExcutResult("select uuid from tblProject where uuid ='" & GetSetting("TR", "LoopApp", "ProjectUUID", String.Empty) & "'") = String.Empty Then
            Dim frm As New frmSelectProject
            frm.ShowDialog(Me)
        End If
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetUserSkin()
        AddHandler PublicErrors.DataReadError, AddressOf HandleDataReadError
        AddHandler PublicErrors.ILDDBConnectionError, AddressOf HandleILDConnectionError
        AddHandler PublicErrors.DataConnectionError, AddressOf HandleDataConnectionError
        AddHandler PublicErrors.DataExecuteError, AddressOf HandleDataExecuteError
        AddHandler PublicErrors.ReadFileError, AddressOf HandleReadFileError
        AddHandler PublicErrors.UnknownError, AddressOf HandleDataConnectionError
        frmEICALogin.Hide()
        checkProjectUUID()
        BackstageViewControl1.SelectedTabIndex = 0
        OnEICAConnected()

        'notify = New EICANotifications
        'notify.Start()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmILDManage() With {.MdiParent = Me}
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmPdf() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub
    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        ShowProgressPanel()
        Dim frm As New frmEICALoopMap() With {.MdiParent = Me}
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim frm As New frmAddLoop() With {.MdiParent = Me}
        AddToQuickAccess(frm)
        frm.Show()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        BackstageViewControl1.Close()
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmReports(Reports.ReportTypes.EICAITRCLOSED)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub
    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Dim frm As New frmLoopConstraints2() With {.MdiParent = Me}
        AddToQuickAccess(frm)
        frm.Show()
    End Sub
    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        frmCopyILD.MdiParent = Me
        frmCopyILD.Show()
    End Sub

    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Application.Exit()
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
    End Sub
    Private Sub BarButtonItem40_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmItemProduction() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem41_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmValidateSubPro() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub

    Private Sub BarButtonItem45_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub
    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick, BarButtonItem3.ItemClick, BarButtonItem39.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmLoopFolders
        frm.MdiParent = Me
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem45_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmLoopFolders With {
            .MdiParent = Me
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem47_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmLoopFolders With {
           .MdiParent = Me
       }
        frm.Show()
    End Sub

    Private Sub BarButtonItem23_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmLighting
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem26_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmTrays
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub
    Private Sub BarButtonItem48_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem48.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmEquipment
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem50_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem50.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmActivities
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub
    Private Sub BarButtonItem52_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem52.ItemClick
        AddToQuickAccess(frmExtractILD2)
        frmExtractILD2.MdiParent = Me
        frmExtractILD2.Show()
    End Sub

    Private Sub BarButtonItem53_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem53.ItemClick
        AddToQuickAccess(frmExtractILD3)
        frmExtractILD3.MdiParent = Me
        frmExtractILD3.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmEICALoopManagement
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim frm As New frmSelectRFIPath
        frm.Show()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmCables
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmCables(True)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem54_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem54.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmCableProduction
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem46_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem46.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmResources
        frm.MdiParent = Me
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem51_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem51.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmInstruments
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem55_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem55.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmInstruments(True)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem49_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem49.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmPDSModelItemsSummary
        frm.MdiParent = Me
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        BackstageViewControl1.Close()
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmReports(Reports.ReportTypes.EICADAILYTRACKINGELEResources)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        BackstageViewControl1.Close()
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmReports(Reports.ReportTypes.EICADAILYTRACKINGINSResources)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem56_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem56.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmLoopPlanning
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmLoopsCurve
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BackstageViewControl1_Shown(sender As Object, e As EventArgs) Handles BackstageViewControl1.Shown
        PrepareSettingsPanel()
    End Sub

    Private Sub tgLoopIntegrity_IsOnChanged(sender As Object, e As EventArgs) Handles tgLoopIntegrity.IsOnChanged
        appset.LoopIntegrity = tgLoopIntegrity.IsOn
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        BackstageViewControl1.Close()
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmUsers With {
            .MdiParent = Me
        }
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        BackstageViewControl1.Close()
        Dim frm As New frmSysLogs() With {.MdiParent = Me}
        AddToQuickAccess(frm)
        frm.Show()
    End Sub

    Private Sub stackPanel_SizeChanged(sender As Object, e As EventArgs) Handles stackPanel.SizeChanged
        For Each btn As DevExpress.XtraEditors.SimpleButton In stackPanel.Controls
            btn.Width = stackPanel.Width
        Next
    End Sub

    Private Sub barBtnHandoverData_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnHandoverData.ItemClick
        Dim frm As New frmUpdateEICAWithHCS
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub BarButtonItem25_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        dpQuickAccess.Show()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        BackstageViewControl1.Close()
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmReports(Reports.ReportTypes.LOOPSUMMARY)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        BackstageViewControl1.Close()
        Dim frm As New frmSet() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        BackstageViewControl1.Close()
        Dim frm As New frmSelectProject
        frm.Show()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        BackstageViewControl1.Close()
        Dim frm As New frmResetPass
        frm.ShowDialog(Me)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmLoopLogs
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub
    Private Sub tgSolorunIntegrity_IsOnChanged(sender As Object, e As EventArgs) Handles tgSolorunIntegrity.IsOnChanged
        appset.SolorunIntegrity = tgSolorunIntegrity.IsOn
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmSolorunManagement
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmSolorunFolders
        frm.MdiParent = Me
        AddToQuickAccess(frm)
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim frm As New frmSoloRunConstraints() With {.MdiParent = Me}
        AddToQuickAccess(frm)
        frm.Show()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        BackstageViewControl1.Close()
        ShowProgressPanel()
        Application.DoEvents()
        Dim frm As New frmReports(Reports.ReportTypes.LOOPBLOCKAGERESPONSIBLE)
        AddToQuickAccess(frm)
        frm.MdiParent = Me
        frm.Show()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim skinColor As String = ""
        If SkinPaletteRibbonGalleryBarItem.Gallery.GetCheckedItemsCount = 0 Then
            skinColor = "Default"
        Else
            skinColor = SkinPaletteRibbonGalleryBarItem.Gallery.GetCheckedItem.Caption
        End If
        SaveUserSkin(
                    SkinDropDownButtonItem.DropDownGallery.Gallery.GetCheckedItem.Caption,
                    skinColor
                    )
    End Sub

    Private Sub notificationsTimer_Tick(sender As Object, e As EventArgs) Handles notificationsTimer.Tick
        notify.Start()
    End Sub

    Private Sub lblLoopBlockages_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lblLoopBlockages.ItemClick
        Dim filter As String = "[Issued To] LIKE '" & Users.userFullName & "'"
        Dim frm As New frmLoopConstraints2 With {
            ._filterColumn = "Issued To",
        ._filter = filter
        }
        frm.Show()
    End Sub

    Private Sub lblSolorunBlockages_ItemClick(sender As Object, e As ItemClickEventArgs) Handles lblSolorunBlockages.ItemClick
        Dim filter As String = "[Issued To] LIKE '" & Users.userFullName & "'"
        Dim frm As New frmSoloRunConstraints With {
            ._filterColumn = "Issued To",
        ._filter = filter
        }
        frm.Show()
    End Sub

End Class
