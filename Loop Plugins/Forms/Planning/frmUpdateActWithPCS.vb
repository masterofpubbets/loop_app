Public Class frmUpdateActWithPCS
    Public isUpdated As Boolean = False
    Private act As New Activities



    Private Sub frmUpdateActWithPCS_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If Trim(txtPCS.Text) = "" Then
            MsgBox("You Have To type PCS DB Name", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Try
            DB.Fill(cmbBase, String.Format("SELECT distinct [BaseLine] FROM [{0}]..[ActivityBudget]", txtPCS.Text))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If cmbBase.SelectedIndex = -1 Then
            MsgBox("You Have To Select Baseline", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If MsgBox("Do You Want To Update PCS Scope in EICA", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim Eng As New Engineering
        Try
            act.UpdateP6Scope(txtPCS.Text, cmbBase.SelectedItem)
            MsgBox("PCS Scope and Percentage Done Have Been Updated in EICA", vbOKOnly, Me.Text)
            isUpdated = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub
End Class