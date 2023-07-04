Public Class frmLoopTaskDispatch
    Private Sub frmLoopTaskDispatch_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub GetData()
        Dim dt As New DataTable
        dt = DB.ReturnDataTable("select distinct area from tblInsLoop order by area")
        RepositoryItemComboBox1.Items.Clear()
        For inx As Integer = 0 To dt.Rows.Count - 1
            RepositoryItemComboBox1.Items.Add(dt.Rows(inx).Item("area"))
        Next
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            fld.SelectedPath = ""
            fld.ShowDialog()
            If fld.SelectedPath = "" Then Exit Sub
            GRD.ExportToXlsx(String.Format("{0}\Loops Items Dispatch {2} {1}.xlsx", fld.SelectedPath, Format(Now, "yyyyMMdd"), cmbUnit.EditValue))
            Process.Start(fld.SelectedPath)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If cmbUnit.EditValue = "" Then
            MsgBox("Please Select Unit", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        GRD.DataSource = DB.ReturnDataTable(String.Format("exec SpLoopTaskWF '{0}'", cmbUnit.EditValue), 99999999)
        grdRem.DataSource = DB.ReturnDataTable(My.Resources.LoopRemainigDays)
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Try
            fld.SelectedPath = ""
            fld.ShowDialog()
            If fld.SelectedPath = "" Then Exit Sub
            grdRem.ExportToXlsx(String.Format("{0}\Loops Pendings Days {1}.xlsx", fld.SelectedPath, Format(Now, "yyyyMMdd")))
            Process.Start(fld.SelectedPath)
        Catch ex As Exception

        End Try
    End Sub
End Class