Public Class frmSet
    Private Sub frmSet_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDB.Text = ILDDBFolder
        lblFolder.Text = SharedFolder
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If lblDB.Text = "" Then
            MsgBox("Please Select ILD DB Folder", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If lblFolder.Text = "" Then
            MsgBox("Please Select ILD Shared Folder", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim msgr As MsgBoxResult = MsgBox("Do You Want To Save Changes", MsgBoxStyle.YesNo, Me.Text)
        If msgr = MsgBoxResult.No Then Exit Sub
        ILDDBFolder = lblDB.Text
        SharedFolder = lblFolder.Text
        SaveSetting("TR", "EIKA", "ILDDBFolder", ILDDBFolder)
        SaveSetting("TR", "EIKA", "SharedFolder", SharedFolder)
        Me.Close()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        fld.SelectedPath = ""
        fld.ShowDialog()
        If fld.SelectedPath = "" Then Exit Sub
        lblDB.Text = fld.SelectedPath
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        fld.SelectedPath = ""
        fld.ShowDialog()
        If fld.SelectedPath = "" Then Exit Sub
        lblFolder.Text = fld.SelectedPath
    End Sub
End Class