Public Class frmSelectDate
    Public Property IsSelect As Boolean = False
    Public Property IsClear As Boolean = False
    Public Property SelectedDate As Date


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmSelectDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDate.Text = Now
        dte.EditValue = Now
    End Sub

    Private Sub dte_EditValueChanged(sender As Object, e As EventArgs) Handles dte.EditValueChanged
        lblDate.Text = Format(CDate(dte.EditValue), "dddd dd-MMMM-yyyy")
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SelectedDate = CDate(dte.EditValue)
        IsSelect = True
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SelectedDate = CDate(dte.EditValue)
        IsSelect = True
        IsClear = True
        Me.Close()
    End Sub
End Class