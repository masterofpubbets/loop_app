Public Class frmAddActivity
    Public isAdded As Boolean = False
    Private Act As New Activities
    Public EICAArea As String = ""

    Private Function IsValida() As Boolean
        txtActId.Text = Trim(txtActId.Text)
        txtActName.Text = Trim(txtActName.Text)
        txtPCSArea.Text = Trim(txtPCSArea.Text)
        txtSubcon.Text = Trim(txtSubcon.Text)
        txtFamily.Text = Trim(txtFamily.Text)
        txtLocation.Text = Trim(txtLocation.Text)
        txtResourceId.Text = Trim(txtResourceId.Text)
        txtResourceName.Text = Trim(txtResourceName.Text)
        txtActId.Text = Trim(txtActId.Text)
        txtActId.Text = Trim(txtActId.Text)
        txtActId.Text = Trim(txtActId.Text)

        If txtActName.Text = "" Then
            MsgBox("Missing Activity Name!", MsgBoxStyle.Exclamation, Me.Text)
            txtActName.Focus()
            Return False
        End If
        If txtActId.Text = "" Then
            MsgBox("Missing Activity Id!", MsgBoxStyle.Exclamation, Me.Text)
            txtActId.Focus()
            Return False
        End If
        If txtFamily.Text = "" Then
            MsgBox("Missing Family!", MsgBoxStyle.Exclamation, Me.Text)
            txtFamily.Focus()
            Return False
        End If
        If Act.IsActivityExists(txtActId.Text) Then
            MsgBox("This Activity Id Exists!", MsgBoxStyle.Exclamation, Me.Text)
            txtActId.Focus()
            Return False
        End If
        If Act.IsActivityExists(txtActId.Text, txtActName.Text) Then
            MsgBox("This Activity Name Exists!", MsgBoxStyle.Exclamation, Me.Text)
            txtActName.Focus()
            Return False
        End If
        If cmbEICAArea.SelectedIndex = -1 Then
            MsgBox("Please Select EICA Area!", MsgBoxStyle.Exclamation, Me.Text)
            cmbEICAArea.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub frmAddActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DB.Fill(cmbEICAArea, "SELECT [Area] FROM [Area] ORDER BY [Area]")
        If cmbEICAArea.Items.Count > 0 Then cmbEICAArea.SelectedItem = EICAArea
    End Sub

    Private Sub frmAddActivity_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
        Me.Refresh()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValida() Then
            Dim keyQnty As Byte = 0
            If chkKeyQnty.Checked Then keyQnty = 1
            If Act.AddActivity(txtActId.Text, txtActName.Text, txtPCSArea.Text, txtSubcon.Text, Val(txtPCSBudget.Text), txtFamily.Text, cmbEICAArea.SelectedItem, Val(txtEICABudget.Text), txtPackage.Text, 0, keyQnty, txtWPS.Text, txtResourceId.Text, txtResourceName.Text, txtLocation.Text, txtTeam.Text, dteStartDate.Value, dteEndDate.Value, txtUOM.Text) Then
                isAdded = True
                If MsgBox("Activity Has Been Added." & vbCrLf & "Do You Want to Add Another One?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Me.Close()
                txtActId.Text = ""
                txtActName.Text = ""
                txtActId.Focus()
            End If
        End If
    End Sub
End Class