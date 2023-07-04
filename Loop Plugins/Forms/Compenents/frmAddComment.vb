Public Class frmAddComment
    Public Comment As String = ""
    Private Sub frmAddComment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Trim(txtComment.Text) = "" Then
            MsgBox("Comment Cannot Be Empty!", MsgBoxStyle.Exclamation, Me.Text)
            txtComment.Focus()
            Exit Sub
        End If
        Comment = Replace(txtComment.Text, "'", "''",,, CompareMethod.Text)
        Me.Close()
    End Sub
End Class