Public Class frmILDManage
    Private DT As New DataTable
    Private Builder As OleDb.OleDbCommandBuilder
    Dim cmd As New OleDb.OleDbCommand("select * from tblILD", AccDB.Connection)
    Dim DA As New OleDb.OleDbDataAdapter(cmd)

    Private Sub GetData()
        DT = New DataTable
        DA.Fill(DT)
        Builder = New OleDb.OleDbCommandBuilder(DA)
        DA.InsertCommand = Builder.GetInsertCommand
        DA.UpdateCommand = Builder.GetUpdateCommand
        GRD.DataSource = DT
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

    Private Sub frmILDManage_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Try
            Dim rws As Integer = 0
            DT = GRD.DataSource
            rws = DA.Update(DT)
            MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.OkOnly, Me.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim msg As MsgBoxResult = MsgBox("Are You Sure You Want To Delete All Loops", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub
        AccDB.ExcuteNoneResult("delete from tblILD")
        GetData()
        Dim di As New IO.DirectoryInfo(SharedFolder)
        Dim fiArr As IO.FileInfo() = di.GetFiles()
        For Each fri In fiArr
            fri.Delete()
        Next
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim cmd2 As String = "", FileName As String = ""
        Dim InkScapePath As String = String.Format("{0}{1}\Libs\App\Inkscape\inkscape.exe{2}", Chr(34), Application.StartupPath, Chr(34))
        If GridView2.GetSelectedRows.Count = 0 Then Exit Sub
        Dim selectedRowHandles As Int32() = GridView2.GetSelectedRows
        FileName = String.Format("{0}\Loops\{1}.pdf", Application.StartupPath, AccDB.ExcutResult("select filename from tblild where tblid =" & GridView2.GetDataRow(selectedRowHandles(0)).Item("tblid")))
        cmd2 = String.Format(" -f {0}{1}{0} ", Chr(34), FileName, "=", Chr(34))
        Shell(InkScapePath & cmd2, AppWinStyle.MaximizedFocus, True)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            Dim msg As MsgBoxResult = MsgBox("Are You Sure You Want To Delete Selected Row", MsgBoxStyle.YesNo, Me.Text)
            If msg = MsgBoxResult.No Then Exit Sub
            GridView2.DeleteSelectedRows()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Try
            Dim selectedRowHandles As Int32() = GridView2.GetSelectedRows
            If IO.File.Exists(String.Format("{0}\{1}.pdf", SharedFolder, GridView2.GetDataRow(selectedRowHandles(0)).Item("FileName"))) Then
                Dim frm As New frmPdf() With {.PDFPath = String.Format("{0}\{1}.pdf", SharedFolder, GridView2.GetDataRow(selectedRowHandles(0)).Item("FileName"))}
                frm.Text &= " " & GridView2.GetDataRow(selectedRowHandles(0)).Item("FileName")
                frm.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
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

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim frm As New frmFindKeyword() With {.MdiParent = frmMain}
        frm.Show()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim frm As New frmExportILDpdf() With {.MdiParent = frmMain}
        frm.Show()
    End Sub
End Class