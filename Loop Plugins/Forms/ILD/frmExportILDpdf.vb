Public Class frmExportILDpdf

    Private Sub frmExportILDpdf_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub GetData(Optional ByVal cri As String = "")
        If cri = "" Then
            GRD.DataSource = AccDB.ReturnDataTable("select distinct Loop_Name,Filename from tblild where filename is not null order by Loop_Name")
        Else
            GRD.DataSource = AccDB.ReturnDataTable(String.Format("select distinct Loop_Name,Filename from tblild where filename is not null and {0} order by Loop_Name", cri))
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GetData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData(txtFilter.Text)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            fld.SelectedPath = ""
            fld.ShowDialog()
            If fld.SelectedPath = "" Then Exit Sub
            Dim OldFile As String = ""
            Dim NewFile As String = ""
            Dim Pcnt As Integer = 1
            Dim lName As String = ""
            RepositoryItemProgressBar1.Maximum = GridView2.RowCount
            pBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            For inx As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetDataRow(inx).Item("Loop_Name") <> lName Then Pcnt = 1
                OldFile = String.Format("{0}\{1}.pdf", SharedFolder, GridView2.GetDataRow(inx).Item("Filename"))
                NewFile = String.Format("{0}\{1}.pdf", fld.SelectedPath, GridView2.GetDataRow(inx).Item("Loop_Name"))
                If FileIO.FileSystem.FileExists(NewFile) Then
                    Rename(NewFile, Replace(NewFile, ".pdf", String.Format("-{0}.pdf", Pcnt)))
                End If
                FileIO.FileSystem.CopyFile(OldFile, NewFile, False)
                lName = GridView2.GetDataRow(inx).Item("Loop_Name")
                Pcnt += 1
                Application.DoEvents()
                pBar.EditValue = inx + 1
            Next
            Process.Start(fld.SelectedPath)
            pBar.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Dim msgr As MsgBoxResult = MsgBox("Do You Want To Cancel The Operation", MsgBoxStyle.YesNo, Me.Text)
            If msgr = MsgBoxResult.Yes Then
                Exit Try
            End If
        End Try
    End Sub
End Class