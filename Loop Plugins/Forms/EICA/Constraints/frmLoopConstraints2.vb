Public Class frmLoopConstraints2

    Private Sub GetLoop()
        GRD.DataSource = DB.ReturnDataTable("SELECT tbl_id as ID,Area,[LoopName],[L_Type] as [Type],[L_Description] as [Description],[Subsystem],[Subcontractor],[Active] FROM [tblInsLoop] order by Area,[LoopName]")
    End Sub
    Private Sub GetData_Loop(ByVal LoopID As Integer)
        grdCons.DataSource = DB.ReturnDataTable(String.Format("{0} where loop_id={1}", My.Resources.LoopsCons, LoopID))
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetLoop()
    End Sub

    Private Sub frmLoopConstraints2_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetLoop()
    End Sub

    Private Sub GridView2_Click(sender As Object, e As EventArgs) Handles GridView2.Click
        For Each row_handle As Integer In GridView2.GetSelectedRows
            GetData_Loop(GridView2.GetDataRow(row_handle).Item("ID"))
        Next
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If GridView2.RowCount = 0 Then Exit Sub
        Dim col As New Collection
        For Each row_handle As Integer In GridView2.GetSelectedRows
            col.Add(GridView2.GetDataRow(row_handle).Item("LoopName"))
        Next
        Dim frm As New frmAddConsEntry() With {.LoopIDs = col}
        frm.ShowDialog(Me)
        frm = Nothing
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If gvLoopCons.RowCount = 0 Then Exit Sub
        Dim msgR As MsgBoxResult = MsgBox("Do You Want to Close Selected Constraint?", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        For Each row_handle As Integer In gvLoopCons.GetSelectedRows
            DB.ExcuteNoneResult("exec sp_CloseLoopConstraint null," & gvLoopCons.GetDataRow(row_handle).Item("ID"))
        Next
        Dim row_handle2 As Integer = GridView2.GetSelectedRows(0)
        GetData_Loop(GridView2.GetDataRow(row_handle2).Item("ID"))
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If GridView2.RowCount = 0 Then Exit Sub
        Dim msgR As MsgBoxResult = MsgBox("Do You Want to Close All Constraints for All Selected Loops?", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        For Each row_handle As Integer In GridView2.GetSelectedRows
            DB.ExcuteNoneResult(String.Format("exec sp_CloseLoopConstraint {0},null", GridView2.GetDataRow(row_handle).Item("ID")))
        Next
        MsgBox("Loops Constrains Have Been CLosed", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            DB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT '' AS LoopName,'' as [Constraint],'' as Department,'' as ActionBy,'' as ForecastDate,'' as Remarks", SheetName)
            MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
            Process.Start(sveFle.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            opnFle.FileName = ""
            opnFle.ShowDialog()
            If opnFle.FileName = "" Then
                Exit Sub
            End If
            Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
            dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[LoopName] is not null and [Constraint] is not null and Department is not null and [ActionBy] is not null and [ForecastDate] is not null")
            If dt.Rows.Count = 0 Then
                MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            Dim frm As New frmLoadCons
            frm.GridControl2.DataSource = dt
            frm.Text = opnFle.FileName
            frm.ShowDialog(Me)
            frm = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            DB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT '' AS LoopName", SheetName)
            MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
            Process.Start(sveFle.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Try
            opnFle.FileName = ""
            opnFle.ShowDialog()
            If opnFle.FileName = "" Then
                Exit Sub
            End If
            Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
            dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[LoopName] is not null")
            If dt.Rows.Count = 0 Then
                MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            Dim frm As New frmLoadCons() With {.LoadType = frmLoadCons.en_LoadType.ClearConstraint}
            frm.GridControl2.DataSource = dt
            frm.Text = opnFle.FileName
            frm.ShowDialog(Me)
            frm = Nothing
        Catch ex As Exception

        End Try
    End Sub
End Class