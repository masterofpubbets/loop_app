Public Class frmEditText
    Public isUpdated As Boolean = False
    Public newValye As String = ""

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmEditText_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        newValye = txtValue.Text
        isUpdated = True
        Me.Close()
    End Sub
End Class