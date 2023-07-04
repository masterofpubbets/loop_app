Public Class frmHCSEICALoopStatus

    Private Sub GetData()
        GRD.DataSource = DB.ReturnDataTable(My.Resources.LoopHCSEICA)
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub frmHCSEICALoopStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
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

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim l As New LoopProcess
        l.UpdateDeactivatedLoopInHCS()
        GetData()
        MsgBox("Loops Have Been Deactivated as Per HCS", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim l As New LoopProcess
        l.UpdateLoopInfoFromHCS()
        GetData()
        MsgBox("Loops Have Been Updated From HCS", MsgBoxStyle.Information, Me.Text)
    End Sub
End Class