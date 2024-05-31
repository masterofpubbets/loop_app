Public Class frmSQMSSyncSettings
    Private sqms As New SQMSTransaction

    Private Sub GetData()
        txtMotorSoloRunScope.Text = sqms.MotorSoloRunScope
        txtLoopFolderTaskFilter.Text = sqms.LoopFolderRequiredTasks
        txtSoloRunTaskFilter.Text = sqms.SoloRunRequiredTasks
        txtLoopTestScope.Text = sqms.LoopTestScope
        txtMotorSoloRunApproved.Text = sqms.MotorSoloRunApproved
        txtFinalClean.Text = sqms.FinalClean
        txtLoopTestApproved.Text = sqms.LoopTestApproved
        txtBoxUpScope.Text = sqms.BoxupScope
        txtBoxupTaskFilter.Text = sqms.BoxupRequiredTask
        txtBoxupApproved.Text = sqms.BoxupApproved
    End Sub
    Private Function IsValide() As Boolean
        If Trim(txtMotorSoloRunScope.Text) = "" Then
            MsgBox("Motor Solo Run Scope cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtMotorSoloRunScope.Focus()
            Return False
        End If
        If Trim(txtMotorSoloRunApproved.Text) = "" Then
            MsgBox("Motor Solo Run Approved cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtMotorSoloRunApproved.Focus()
            Return False
        End If
        If Trim(txtLoopTestScope.Text) = "" Then
            MsgBox("Loop Test Scope cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtLoopTestScope.Focus()
            Return False
        End If
        If Trim(txtLoopTestApproved.Text) = "" Then
            MsgBox("Loop Test Approved cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtLoopTestApproved.Focus()
            Return False
        End If
        If Trim(txtBoxUpScope.Text) = "" Then
            MsgBox("Box Up Scope cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtBoxUpScope.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub frmHCSConnectionSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmHCSConnectionSettings_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If MsgBox("Do you want to update SQMS Connection settings?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        If IsValide() Then
            sqms.MotorSoloRunScope = txtMotorSoloRunScope.Text
            sqms.LoopFolderRequiredTasks = txtLoopFolderTaskFilter.Text
            sqms.LoopTestScope = txtLoopTestScope.Text
            sqms.MotorSoloRunApproved = txtMotorSoloRunApproved.Text
            sqms.FinalClean = txtFinalClean.Text
            sqms.LoopTestApproved = txtLoopTestApproved.Text
            sqms.SoloRunRequiredTasks = txtSoloRunTaskFilter.Text
            sqms.BoxupScope = txtBoxUpScope.Text
            sqms.BoxupRequiredTask = txtBoxupTaskFilter.Text
            sqms.BoxupApproved = txtBoxupApproved.Text
            MsgBox("Settings Saved.", MsgBoxStyle.Information, Me.Text)
            Me.Close()
        End If
    End Sub
End Class