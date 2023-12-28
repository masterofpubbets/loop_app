Public Class frmEditCableProduction
    Public OldPercentage As Double
    Public OldMark1From As Integer, OldMark1To As Integer
    Public Id As Integer = 0
    Public cable As New Cables
    Public isUpdated As Boolean
    Public Discipline As String = ""

    Private Sub frmEditCableProduction_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub txtPercentage_EditValueChanged(sender As Object, e As EventArgs) Handles txtPercentage.EditValueChanged
        lblTotal.Text = Val(txtPercentage.EditValue) + Val(lblOtherPercentage.Text)
    End Sub

    Private Sub dteEdit_EditValueChanged(sender As Object, e As EventArgs) Handles dteEdit.EditValueChanged
        lblDate.Text = dteEdit.EditValue
    End Sub

    Private Sub txtPercentage_Validated(sender As Object, e As EventArgs) Handles txtPercentage.Validated
        If Val(txtPercentage.EditValue) + Val(lblOtherPercentage.Text) > 100 Then
            MsgBox("Total Percentage Cannot Be Greater Than 100%", MsgBoxStyle.Exclamation, Me.Text)
            txtPercentage.EditValue = OldPercentage
        End If
        If Val(txtPercentage.EditValue) < 0 Then
            txtPercentage.EditValue = OldPercentage
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If cable.UpdateCableProduction(Id, Discipline, Val(txtPercentage.EditValue), txtMark1From.EditValue, txtMark1To.EditValue, CDate(lblDate.Text), txtActualDrum.Text) Then
            isUpdated = True
            Me.Close()
        End If
    End Sub

    Private Sub txtMark1From_Validated(sender As Object, e As EventArgs) Handles txtMark1From.Validated
        If Val(txtMark1From.EditValue) < 0 Then
            txtMark1From.EditValue = OldMark1From
        End If
    End Sub

    Private Sub txtMark1To_Validated(sender As Object, e As EventArgs) Handles txtMark1To.Validated
        If Val(txtMark1To.EditValue) < 0 Then
            txtMark1To.EditValue = OldMark1To
        End If
    End Sub

    Private Sub frmEditCableProduction_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class