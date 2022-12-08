Public Class frmUploadHCSData
    Private p As New HCS
    Private ex As String

    Private Sub OnProcessStatus(ByVal s As String)
        lblProcessStatus.Text &= s & vbCrLf
    End Sub
    Private Sub OnNoErr()
        ex = ""
        lblErr.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        lblNoErr.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Application.DoEvents()
    End Sub
    Private Sub OnErr(ByVal er As String)
        lblErr.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        lblNoErr.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        ex &= er & vbCrLf
        Application.DoEvents()
    End Sub

    Private Sub GetRestoreTables()
        Dim t As String = ""
        If ckEle.Checked Then
            t = "Elements"
        End If
        If ckGroup.Checked Then
            t &= vbCrLf & "Groups"
        End If
        If ckItems.Checked Then
            t &= vbCrLf & "Items"
        End If
        If ckPunch.Checked Then
            t &= vbCrLf & "Punchs"
        End If
        If ckSubsystem.Checked Then
            t &= vbCrLf & "Subsystems"
        End If
        If ckSystem.Checked Then
            t &= vbCrLf & "Systems"
        End If
        If ckTask.Checked Then
            t &= vbCrLf & "Tasks"
        End If
        lblTables.Text = t
    End Sub
    Private Sub ckEle_CheckedChanged(sender As Object, e As EventArgs) Handles ckEle.CheckedChanged, ckGroup.CheckedChanged, ckItems.CheckedChanged, ckPunch.CheckedChanged, ckSubsystem.CheckedChanged, ckSystem.CheckedChanged, ckTask.CheckedChanged
        GetRestoreTables()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblEle.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblGroup.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblItems.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblPunch.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblSystem.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblSubsystem.Text = opnFle.FileName
        End If
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()

        If opnFle.FileName <> "" Then
            lblTask.Text = opnFle.FileName
        End If
    End Sub

    Private Sub frmRestoreHCS_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler p.Err, AddressOf OnErr
        AddHandler DB.err, AddressOf OnErr
        AddHandler p.HCSRestoreStatus, AddressOf OnProcessStatus
        BarEditItem1.EditValue = 5000
        BarEditItem1.Caption = "Batch Size: " & BarEditItem1.EditValue
    End Sub

    Private Sub BarEditItem1_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem1.EditValueChanged
        BarEditItem1.Caption = "Batch Size: " & BarEditItem1.EditValue
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim msgR As MsgBoxResult = MsgBox("Are You Sure You Want to Upload HCS Data", MsgBoxStyle.YesNo, Me.Text)
        OnNoErr()
        lblProcessStatus.Text = ""
        Application.DoEvents()
        If msgR = MsgBoxResult.No Then Exit Sub
        If ckEle.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For Elements" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectElements, lblEle.Text, txtEleSheet.Text, BarEditItem1.EditValue)
        End If
        If ckGroup.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For Groups" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectGroups, lblGroup.Text, txtGroupSheet.Text, BarEditItem1.EditValue)
        End If
        If ckItems.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For Items" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectItems, lblItems.Text, txtItemsSheet.Text, BarEditItem1.EditValue)
        End If
        If ckPunch.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For Punchs" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectPunchs, lblPunch.Text, txtPunchSheet.Text, BarEditItem1.EditValue)
        End If
        If ckSubsystem.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For Subsystem" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectSubsystems, lblSubsystem.Text, txtSubsystemSheet.Text, BarEditItem1.EditValue)
        End If
        If ckSystem.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For System" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectSystems, lblSystem.Text, txtSystemSheet.Text, BarEditItem1.EditValue)
        End If
        If ckTask.Checked Then
            If lblEle.Text = "" Then
                MsgBox("Please Select Loaded Excel File For Tasks" & vbCrLf & "The Update Process Will Terminate", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            p.RestoreTable(HCS.e_DataType.ProjectTasks, lblTask.Text, txtTaskSheet.Text, BarEditItem1.EditValue)
        End If
        MsgBox("Operation Has Been FInished", MsgBoxStyle.OkOnly, Me.Text)
    End Sub

    Private Sub lblErr_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles lblErr.ItemClick
        'Dim frm As New frmErrLog
        'frm.txt.Text = ex
        'frm.Show()
    End Sub
End Class