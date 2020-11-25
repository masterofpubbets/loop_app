Public Class frmSelectDate

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmSelectDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDate.Text = Now
        dte.EditValue = Now
    End Sub

    Private Sub dte_EditValueChanged(sender As Object, e As EventArgs) Handles dte.EditValueChanged
        lblDate.Text = dte.EditValue
    End Sub
End Class