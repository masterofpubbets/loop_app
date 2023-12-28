Public Class frmEditUser
    Public isAdded As Boolean = False
    Private user As New Users
    Private pe As New PublicErrors
    Private userImage As String = ""

    Private Function IsValidated() As Boolean
        If Trim(txtUserName.Text) = "" Then
            MsgBox("Missing User Name!", MsgBoxStyle.Exclamation, Me.Text)
            txtUserName.Focus()
            Return False
        End If
        If DB.ExcutResult("SELECT id from LOOPS.tblUsers WHERE userName = '" & Trim(txtUserName.Text) & "'") = "" Then
            MsgBox("User not exists!", MsgBoxStyle.Exclamation, Me.Text)
            txtUserName.Focus()
            Return False
        End If
        If Trim(txtName.Text) = "" Then
            MsgBox("Missing Full Name!", MsgBoxStyle.Exclamation, Me.Text)
            txtName.Focus()
            Return False
        End If
        If Trim(txtEmail.Text) = "" Then
            MsgBox("Missing Email!", MsgBoxStyle.Exclamation, Me.Text)
            txtEmail.Focus()
            Return False
        End If
        If ckcmbUserType.EditValue = "" Then
            MsgBox("Missing User Type!", MsgBoxStyle.Exclamation, Me.Text)
            ckcmbUserType.Focus()
            Return False
        End If
        txtName.Text = Trim(txtName.Text)
        txtUserName.Text = Trim(txtUserName.Text)
        txtEmail.Text = Trim(txtEmail.Text)
        Return True
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValidated() Then
            Dim userGroup As String = ""
            If ckFolderPrepared.Checked Then userGroup &= "FolderPrepared,"
            If ckQCFolderReady.Checked Then userGroup &= "FolderReady,"
            If ckQCReleased.Checked Then userGroup &= "QCReleased,"
            If ckSubmittedToPrecomm.Checked Then userGroup &= "SubmittedToPrecomm,"
            If ckLoopDone.Checked Then userGroup &= "LoopDone,"
            If ckLoopApproved.Checked Then userGroup &= "FolderApproved,"
            If ckFolderBlockage.Checked Then userGroup &= "FolderBlockage,"
            isAdded = user.EditUser(txtUserName.Text, txtName.Text, ckcmbUserType.EditValue, txtEmail.Text, txtDepartment.Text, txtJob.Text, userGroup, txtTRUserName.Text, pic)
            If isAdded Then
                MsgBox("User has been updated.", MsgBoxStyle.Information, Me.Text)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            opnFile.FileName = ""
            opnFile.ShowDialog()
            If opnFile.FileName = "" Then Exit Sub
            pic.Image = Image.FromFile(opnFile.FileName)
            userImage = opnFile.FileName
        Catch ex As Exception
            userImage = ""
            pe.RaiseReadFileError(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        pic.Image = Nothing
        userImage = ""
    End Sub
End Class