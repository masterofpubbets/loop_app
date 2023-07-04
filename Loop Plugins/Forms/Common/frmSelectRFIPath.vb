Public Class frmSelectRFIPath
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        opnFIle.SelectedPath = ""
        opnFIle.ShowDialog()
        If opnFIle.SelectedPath <> "" Then
            lblPath.Text = opnFIle.SelectedPath
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub
    Private Sub frmSelectRFIPath_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If lblPath.Text = "" Then
            MsgBox("Please select folder first!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        RFIPath = lblPath.Text
        SaveSetting("TR", "EIKA", "RFIPath", RFIPath)
        Me.Close()
    End Sub

    Private Sub frmSelectRFIPath_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblPath.Text = RFIPath
    End Sub
End Class