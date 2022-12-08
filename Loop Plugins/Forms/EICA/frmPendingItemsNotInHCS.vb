Public Class frmPendingItemsNotInHCS

    Private Sub GetData()
        GRD.DataSource = DB.ReturnDataTable(My.Resources.PendingItemsNotInHCS, 9999999)
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub frmPendingItemsNotInHCS_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
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
End Class