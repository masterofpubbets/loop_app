Public Class frmUpdateLoopDone

    Private Sub RemoveLoop(ByVal inx As Integer)
        lstLoop.Items.RemoveAt(inx)
        If lstLoop.SelectedIndices.Count > 0 Then
            RemoveLoop(lstLoop.SelectedIndices.Item(0))
        End If
    End Sub
    Private Sub GetData()
        Dim DT As New DataTable
        DT = DB.ReturnDataTable(My.Resources.LoopBasicInfo)
        grd.DataSource = DT
    End Sub

    Private Sub UpdateLoops()
        For Each row_handle As Integer In gvLoop.GetSelectedRows
            If IsDBNull(gvLoop.GetDataRow(row_handle).Item("Precomm Done Date")) Then
                lstLoop.Items.Add(gvLoop.GetDataRow(row_handle).Item("LoopName").ToString)
            End If
        Next
    End Sub
    Private Sub frmUpdateLoopDone_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        UpdateLoops()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Clear The List", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        lstLoop.Items.Clear()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Remove Selected Loop", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        If lstLoop.SelectedIndices.Count > 0 Then
            RemoveLoop(lstLoop.SelectedIndices.Item(0))
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Set Selected Loop as Precomm Done", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        MsgBox("Please Wait While Updating Loop System for Those Selected Loops", MsgBoxStyle.Information, Me.Text)
        For inx As Integer = 0 To lstLoop.Items.Count - 1
            DB.ExcuteNoneResult(String.Format("exec sp_SetLoopDone '{0}'", lstLoop.Items.Item(inx)))
        Next
        Dim ild As New ExtractILD
        ild.UpdateLoopConsFinishedWithoutMasterJobard()
        GetData()
        MsgBox("Loops Progress Updated and Validated in EICA", MsgBoxStyle.Information, Me.Text)
    End Sub
End Class