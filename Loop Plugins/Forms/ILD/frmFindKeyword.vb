Public Class frmFindKeyword
    Private ILD As New ExtractILD

    Private Sub h_FileCnt(ByVal cnt As Integer)
        RepositoryItemProgressBar1.Maximum = cnt
        pBar.EditValue = 0
        pBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub
    Private Sub h_FileIndex(ByVal inx As Integer)
        pBar.EditValue = inx
    End Sub
    Private Sub h_Finished()
        pBar.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInRuntime
        MsgBox("Searching Has Been Finished", MsgBoxStyle.Information, Me.Text)
    End Sub
    Private Sub frmFindKeyword_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler ILD.FileCount, AddressOf h_FileCnt
        AddHandler ILD.FileIndex, AddressOf h_FileIndex
        AddHandler ILD.SearchingFinished, AddressOf h_Finished
        GetILDs()
    End Sub

    Private Sub GetILDs()
        GRD.DataSource = AccDB.ReturnDataTable("select distinct Loop_name,FileName from tblILD where filename is not null")
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GetILDs()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If txtSearch.EditValue = "" Then
            MsgBox("Keyword Cannot Be Empty", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim fs As New EAMS.FilesSystem.FileSearch
        grdRslt.DataSource = ILD.ReturnILDContainsWord(txtSearch.EditValue)
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If txtSearch.EditValue = "" Then
            MsgBox("Keyword Cannot Be Empty", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim fs As New EAMS.FilesSystem.FileSearch
        grdRslt.DataSource = ILD.ReturnILD_NO_ContainsWord(txtSearch.EditValue)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            grdRslt.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            Dim selectedRowHandles As Int32() = GridView1.GetSelectedRows
            If IO.File.Exists(String.Format("{0}\loops\{1}.pdf", Application.StartupPath, GridView1.GetDataRow(selectedRowHandles(0)).Item("File Name"))) Then
                Dim frm As New frmPdf() With {.PDFPath = String.Format("{0}\{1}.pdf", SharedFolder, GridView1.GetDataRow(selectedRowHandles(0)).Item("File Name"))}
                frm.Text &= " " & GridView1.GetDataRow(selectedRowHandles(0)).Item("File Name")
                frm.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class