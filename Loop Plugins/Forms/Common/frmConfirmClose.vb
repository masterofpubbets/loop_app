Public Class frmConfirmClose
    Public Result As eResultType = eResultType.Cancel

    Public Enum eResultType
        Cancel = 1
        Dicard = 2
        Save = 3
    End Enum
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Result = eResultType.Dicard
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Result = eResultType.Save
        Me.Close()
    End Sub
End Class