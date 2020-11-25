Public Class frmMain

    Private Sub OnConnected()
        lblCOn.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        lblDis.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
    Private Sub OnDisConnected()
        lblCOn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        lblDis.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub
    Private Sub OnEICAConnected()
        lblEICACon.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub
    Private Sub OnEICADisConnected()
        lblEICACon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler AccDB.Connnected, AddressOf OnConnected
        AddHandler AccDB.Disconnected, AddressOf OnDisConnected
        AddHandler DB.Connnected, AddressOf OnEICAConnected
        AddHandler DB.Disconnected, AddressOf OnEICADisConnected
        ILDDBFolder = GetSetting("TR", "EIKA", "ILDDBFolder", "")
        SharedFolder = GetSetting("TR", "EIKA", "SharedFolder", "")
        If ((ILDDBFolder = "") Or (SharedFolder = "")) Then
            Dim msgr As MsgBoxResult = MsgBox("Please Select Folder Settings First", MsgBoxStyle.OkCancel, Me.Text)
            If msgr = MsgBoxResult.Cancel Then
                Me.Close()
                End
            End If
            Dim frm As New frmSet
            frm.ShowDialog(Me)
        End If
        DBConnect()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        frmExtractILD2.MdiParent = Me
        frmExtractILD2.Show()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmILDManage() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) 
        Dim frm As New frmPdf() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
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
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
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

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmInsLoop() With {.MdiParent = Me}
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

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim ild As New ExtractILD
        ild.UpdateLoopHCSIndexSigned()
        MsgBox("Loops Progress Validated in EICA", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
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
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
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

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
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
        Dim frm As New frmAddEICALoop
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) 
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
    End Sub

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        ILDDBFolder = GetSetting("TR", "EIKA", "ILDDBFolder", "")
        SharedFolder = GetSetting("TR", "EIKA", "SharedFolder", "")
        If ((ILDDBFolder = "") Or (SharedFolder = "")) Then
            Dim msgr As MsgBoxResult = MsgBox("Please Select Folder Settings First", MsgBoxStyle.OkCancel, Me.Text)
            If msgr = MsgBoxResult.Cancel Then
                Me.Close()
                End
            End If
            Dim frm As New frmSet
            frm.ShowDialog(Me)
        End If
        DBConnect()
    End Sub

    Private Sub BarButtonItem39_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmUpdateFolderSteps() With {.MdiParent = Me}
        frm.Show()
    End Sub

    Private Sub BarButtonItem40_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
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

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        Dim frm As New frmEICALogin
        frm.Show()
    End Sub

    Private Sub BarButtonItem45_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem45.ItemClick
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
End Class
