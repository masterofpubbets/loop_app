Imports DevExpress.XtraBars.ToastNotifications


Public Class frmMain


    Private Sub HandleDataReadError()
        ToastNotificationsManager.ShowNotification(ToastNotificationsManager.Notifications(0).ID)
    End Sub
    Private Sub HandleDataConnectionError(ByVal er As String)
        Try
            Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
            Dim note As New ToastNotification("DataConnectionError", img, "Data Error", er, "", ToastNotificationTemplate.ImageAndText02)
            ToastNotificationsManager.Notifications.Add(note)
            ToastNotificationsManager.ShowNotification("DataConnectionError")
            ToastNotificationsManager.Notifications.Remove(note)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HandleILDConnectionError()
        ToastNotificationsManager.ShowNotification(ToastNotificationsManager.Notifications(2).ID)
    End Sub
    Private Sub HandleDataExecuteError(ByVal er As String)
        Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
        Dim note As New ToastNotification("DataExecuteError", img, "Data Error", er, "", ToastNotificationTemplate.ImageAndText02)
        ToastNotificationsManager.Notifications.Add(note)
        ToastNotificationsManager.ShowNotification("DataExecuteError")
        ToastNotificationsManager.Notifications.Remove(note)
    End Sub
    Private Sub HandleReadFileError(ByVal er As String)
        Try
            Dim img As Image = Image.FromFile(Application.StartupPath & "\res\Error.png")
            Dim note As New ToastNotification("DataExecuteError", img, "Data Error", er, "", ToastNotificationTemplate.ImageAndText02)
            ToastNotificationsManager.Notifications.Add(note)
            ToastNotificationsManager.ShowNotification("DataExecuteError")
            ToastNotificationsManager.Notifications.Remove(note)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckAuth()
        rpHandover.Visible = False
        rpAdmin.Visible = False
        rpEng.Visible = False
        rpQC.Visible = False
        rpPrecom.Visible = False
        rpPlanning.Visible = False
        rpPC.Visible = False
        lblUserName.Caption = Users.userFullName

        If Users.userType = "" Then
            rpAdmin.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpAdmin.Visible = True
            rpHandover.Visible = True
            rpEng.Visible = True
            rpConstruction.Visible = True
            rpQC.Visible = True
            rpPrecom.Visible = True
            rpPlanning.Visible = True
            rpPC.Visible = True
            barBtnHandoverData.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            barbtnHandoverIndex.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Exit Sub
        End If
        If InStr(Users.userType, "handover", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
            barBtnHandoverData.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            barbtnHandoverIndex.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            rpQC.Visible = True
            barbtnHandoverIndex.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
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

    End Sub

    Public Sub HandleUserChanged()
        CheckAuth()
    End Sub
    Public Sub OnConnected()

    End Sub
    Public Sub OnDisConnected()
        'lblEICACon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        lblDBName.Caption = "DB: None"
        lblServer.Caption = "Server: None"
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
    End Sub
    Private Sub checkProjectUUID()
        Users.ProUUID = GetSetting("TR", "LoopApp", "ProjectUUID", "")
        If Users.ProUUID = "" Then
            Dim frm As New frmSelectProject
            frm.ShowDialog(Me)
        End If
        If DB.ExcutResult("select uuid from tblProject where uuid ='" & GetSetting("TR", "LoopApp", "ProjectUUID", "") & "'") = "" Then
            Dim frm As New frmSelectProject
            frm.ShowDialog(Me)
        End If
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler PublicErrors.DataReadError, AddressOf HandleDataReadError
        AddHandler PublicErrors.ILDDBConnectionError, AddressOf HandleILDConnectionError
        AddHandler PublicErrors.DataConnectionError, AddressOf HandleDataConnectionError
        AddHandler PublicErrors.DataExecuteError, AddressOf HandleDataExecuteError
        AddHandler PublicErrors.ReadFileError, AddressOf HandleReadFileError
        AddHandler PublicErrors.UnknownError, AddressOf HandleDataConnectionError
        frmEICALogin.Hide()
        checkProjectUUID()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmILDManage() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmPdf() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmNativeLoopMap() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim ild As New ExtractILD
        ild.UpdateLoopConsFinished()
        MsgBox("Loops Progress Validated in EICA", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim frm As New frmEICALoopMap() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmLoopCard() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim frm As New frmAddLoop() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmPenItems() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmLoopStepStatus()
        frm.Show()
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        MsgBox("PLease Be Sure You Update Production For the Loop In EICA", vbInformation, Me.Text)
        Dim frm As New frmPrecommWF() With {.MdiParent = Me}
        frm.Show()
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

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmRFINoIndex() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barbtnHandoverIndex.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim ild As New ExtractILD
        ild.UpdateLoopHCSIndexSigned()
        MsgBox("Loops Progress Validated in EICA", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmFolderStatus() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmHCSEICALoopStatus() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Dim frm As New frmLoopConstraints2() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmLoopTaskDispatch() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmPendingItemsNotInHCS() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim frm As New frmSet() With {.MdiParent = Me}
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

    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmEICALoopManagement
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
    End Sub

    Private Sub BarButtonItem39_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmUpdateFolderSteps() With {.MdiParent = Me}
        frm.Show()
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

    Private Sub BarButtonItem44_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem44.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmSysLogs() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem43_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem43.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmUpdateLoopDone() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem46_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnHandoverData.ItemClick
        Dim frm As New frmUploadHCSData() With {.MdiParent = Me}
        frm.Show()
    End Sub
    Private Sub BarButtonItem25_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        Dim frm As New frmUsers With {
            .MdiParent = Me
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        Dim frm As New frmHCSSetSteps With {
            .MdiParent = Me
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem42_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        Dim frm As New frmSelectProject
        frm.Show()
    End Sub

    Private Sub BarButtonItem45_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmHCSSetSteps With {
            .MdiParent = Me
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem47_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim frm As New frmHCSSetSteps With {
           .MdiParent = Me
       }
        frm.Show()
    End Sub

    Private Sub BarButtonItem23_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Dim frm As New frmLighting
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem26_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        Dim frm As New frmTrays
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub BarButtonItem48_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem48.ItemClick
        Dim frm As New frmEquipment
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem40_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
        Dim frm As New frmResetPass
        frm.ShowDialog(Me)
    End Sub

    Private Sub BarButtonItem45_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem45.ItemClick
        Dim frm As New frmReports(Reports.ReportTypes.EICADAILYTRACKINGELEResources)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem47_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem47.ItemClick
        Dim frm As New frmReports(Reports.ReportTypes.EICADAILYTRACKINGINSResources)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem50_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem50.ItemClick
        Dim frm As New frmActivities
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub BarButtonItem52_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem52.ItemClick
        frmExtractILD2.MdiParent = Me
        frmExtractILD2.Show()
    End Sub

    Private Sub BarButtonItem53_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem53.ItemClick
        frmExtractILD3.MdiParent = Me
        frmExtractILD3.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim frm As New frmEICALoopManagement
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim frm As New frmSelectRFIPath
        frm.Show()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim frm As New frmCables
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim frm As New frmCables(True)
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem54_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem54.ItemClick
        Dim frm As New frmCableProduction
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem46_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem46.ItemClick
        Dim frm As New frmResources
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem51_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem51.ItemClick
        Dim frm As New frmInstruments
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem55_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem55.ItemClick
        Dim frm As New frmInstruments(True)
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
