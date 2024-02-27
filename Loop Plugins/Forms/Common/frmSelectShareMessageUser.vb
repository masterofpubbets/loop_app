Imports System.ComponentModel

Public Class frmSelectShareMessageUser
    Public selectedUserId As Integer = -1
    Public selectedUserName As String = ""
    Public selectedUserMail As String = ""
    Public description As String = ""
    Public isSelected As Boolean = False

    Private Function IsValidate() As Boolean
        If lblActionBy.Text = "---" Then
            MsgBox("Please Select user to Share With", MsgBoxStyle.Exclamation, Me.Text)
            SimpleButton3.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValidate() Then
            description = txtDescription.Text
            isSelected = True
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim frm As New frmSelectUser
        frm.ShowDialog(Me)
        If frm.selectedUserName <> "" Then
            lblActionBy.Text = frm.selectedUserName
            selectedUserId = frm.selectedUserId
            selectedUserName = frm.selectedUserName
            selectedUserMail = frm.selectedUsermail
        End If
    End Sub

End Class