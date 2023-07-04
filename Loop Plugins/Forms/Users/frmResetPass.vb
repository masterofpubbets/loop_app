Public Class frmResetPass
    Private user As New Users

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If MsgBox("Do You Want To Reset Your Password?", vbYesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        If Trim(txtPass.Text) = "" Then
            MsgBox("Password Cannot Be Empty!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If txtCon.Text <> txtPass.Text Then
            MsgBox("Password Not Matching!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If user.ResetPassword(txtPass.Text) Then
            MsgBox("Password Has Been Reset.", MsgBoxStyle.Information)
            Me.Close()
        End If
    End Sub
End Class