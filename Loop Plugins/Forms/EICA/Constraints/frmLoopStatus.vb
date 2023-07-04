Public Class frmLoopStatus
    Private DT As New DataTable
    Private Builder As SqlClient.SqlCommandBuilder
    Private cmd As New SqlClient.SqlCommand("SELECT TBL_ID,Area,[LoopName],L_Remarks,STATUS,Constraints,Active FROM [tblInsLoop] WHERE STATUS is not null", DB.DBConnection)
    Private DA As New SqlClient.SqlDataAdapter(cmd)
    Private ild As New ExtractILD

    Private Sub h_Index(ByVal inx As Integer)
        pBar.EditValue = inx
    End Sub
    Private Sub h_LoopCnt(ByVal inx As Integer)
        RepositoryItemProgressBar1.Maximum = inx
        pBar.EditValue = 0
    End Sub
    Private Sub h_Finished()
        MsgBox("Update Loop Status Has Been Finished", MsgBoxStyle.Information, Me.Text)
        GetData()
    End Sub
    Private Sub GetData()
        DT = New DataTable
        DA.Fill(DT)
        Builder = New SqlClient.SqlCommandBuilder(DA)
        DA.InsertCommand = Builder.GetInsertCommand
        DA.UpdateCommand = Builder.GetUpdateCommand
        GRD.DataSource = DT
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            Dim rws As Integer = 0
            DT = GRD.DataSource
            rws = DA.Update(DT)
            MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            GRD.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim msgr As New MsgBoxResult
        msgr = MsgBox("Are You Sure You Want To Remove Missing ILD Status?", vbYesNo, Me.Text)
        If msgr = MsgBoxResult.No Then Exit Sub
        ild.RemoveMissingILDStatus()
    End Sub

    Private Sub frmLoopStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler ild.ItemIndex, AddressOf h_Index
        AddHandler ild.FileCount, AddressOf h_LoopCnt
        AddHandler ild.UpdateLoopFinished, AddressOf h_Finished
        GetData()
    End Sub
End Class