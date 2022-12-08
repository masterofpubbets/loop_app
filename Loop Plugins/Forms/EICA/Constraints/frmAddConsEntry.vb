Public Class frmAddConsEntry
    Public LoopIDs As New Collection

    Private Sub GetDep()
        DB.Fill(cmbDep, "select dep_name From tbldepartments order By dep_id")
        cmbDep.SelectedIndex = 0
        cmbCons.SelectedIndex = 0
    End Sub
    Private Function Validate() As Boolean
        If cmbCons.SelectedIndex = -1 Then
            MsgBox("Please Select Constraint", MsgBoxStyle.Exclamation, "Loop Constriant")
            cmbCons.Focus()
            Return False
        End If
        If cmbDep.SelectedIndex = -1 Then
            MsgBox("PLease Selec Department", MsgBoxStyle.Exclamation, "Loop Constriant")
            cmbDep.Focus()
            Return False
        End If
        If Trim(txtActionBy.Text) = "" Then
            MsgBox("Action By Cannot Be Empty", MsgBoxStyle.Exclamation, "Loop Constriant")
            txtActionBy.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmAddConsEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDep()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Validate() Then
            For inx As Integer = 1 To LoopIDs.Count
                If txtRemarks.Text = "" Then
                    DB.ExcuteNoneResult(String.Format("exec sp_AddLoopConstraint '{0}','{1}','{2}','{3}','{4}',null", LoopIDs.Item(inx), cmbCons.SelectedItem.ToString, cmbDep.SelectedItem.ToString, txtActionBy.Text, Format(dteForecast.Value, "MM/dd/yyyy")))
                Else
                    DB.ExcuteNoneResult(String.Format("exec sp_AddLoopConstraint '{0}','{1}','{2}','{3}','{4}','{5}'", LoopIDs.Item(inx), cmbCons.SelectedItem.ToString, cmbDep.SelectedItem.ToString, txtActionBy.Text, Format(dteForecast.Value, "MM/dd/yyyy"), txtRemarks.Text))
                End If
            Next
            Me.Close()
        End If
    End Sub
End Class