Public Class frmAddConsEntry
    Public selectedUserId As Integer = -1
    Public selectedUserName As String = ""
    Public selectedUserMail As String = ""
    Public catName As String = ""
    Public description As String = ""
    Public isSelected As Boolean = False

    Private Sub GetConsCategories()
        cmbConsCat.Items.Clear()
        DB.Fill(cmbConsCat, "SELECT DISTINCT catName FROM LOOPS.tblConsCategory ORDER BY catName")
        If cmbConsCat.Items.Count > 0 Then cmbConsCat.SelectedIndex = 0
    End Sub
    Private Function IsValidate() As Boolean
        If cmbConsCat.SelectedIndex = -1 Then
            MsgBox("Please Select Category", MsgBoxStyle.Exclamation, "Loop Constriant")
            cmbConsCat.Focus()
            Return False
        End If
        If lblActionBy.Text = "---" Then
            MsgBox("Please Select Action By", MsgBoxStyle.Exclamation, "Loop Constriant")
            SimpleButton3.Focus()
            Return False
        End If
        If Trim(txtDescription.Text) = "" Then
            MsgBox("Description cannot be empty", MsgBoxStyle.Exclamation, "Loop Constriant")
            txtDescription.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValidate() Then
            catName = cmbConsCat.SelectedItem.ToString
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

    Private Sub frmAddConsEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetConsCategories()
    End Sub
End Class