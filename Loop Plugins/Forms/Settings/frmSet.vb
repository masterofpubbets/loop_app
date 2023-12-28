Imports System.ComponentModel

Public Class frmSet
    Private pe As New PublicErrors
    Private Sub frmSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDB.Text = ILDDBFile
        lblFolder.Text = SharedFolder
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If lblDB.Text = "" Then
            MsgBox("Please Select ILD DB File", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If lblFolder.Text = "" Then
            MsgBox("Please Select ILD Shared Folder", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim msgr As MsgBoxResult = MsgBox("Do You Want To Save Changes", MsgBoxStyle.YesNo, Me.Text)
        If msgr = MsgBoxResult.No Then Exit Sub
        ILDDBFile = lblDB.Text
        SharedFolder = lblFolder.Text
        SaveSetting("TR", "EIKA", "ILDDBFile", ILDDBFile)
        SaveSetting("TR", "EIKA", "SharedFolder", SharedFolder)
        Me.Close()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        opnFile.FileName = ""
        opnFile.ShowDialog()
        If opnFile.FileName = "" Then Exit Sub
        lblDB.Text = opnFile.FileName
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        fld.SelectedPath = ""
        fld.ShowDialog()
        If fld.SelectedPath = "" Then Exit Sub
        lblFolder.Text = fld.SelectedPath
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Try
            fld.SelectedPath = ""
            fld.ShowDialog()
            If fld.SelectedPath = "" Then Exit Sub
            IO.File.Copy(Application.StartupPath & "\BlankDB\ILDDB.ilddb", fld.SelectedPath & "\ILDDB.ilddb", True)
            lblDB.Text = fld.SelectedPath & "\ILDDB.ilddb"
            lblNewDB.Text = fld.SelectedPath & "\ILDDB.ilddb"
        Catch ex As Exception
            lblDB.Text = ""
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub

    Private Sub frmSet_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class