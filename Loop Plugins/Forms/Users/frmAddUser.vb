Public Class frmAddUser
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
        If DB.ExcutResult("SELECT id from LOOPS.tblUsers WHERE userName = '" & Trim(txtUserName.Text) & "'") <> "" Then
            MsgBox("User already exists!", MsgBoxStyle.Exclamation, Me.Text)
            txtUserName.Focus()
            Return False
        End If
        If Trim(txtPass.Text) = "" Then
            MsgBox("Missing Password!", MsgBoxStyle.Exclamation, Me.Text)
            txtPass.Focus()
            Return False
        End If
        If Trim(txtName.Text) = "" Then
            MsgBox("Missing Full Name!", MsgBoxStyle.Exclamation, Me.Text)
            txtName.Focus()
            Return False
        End If
        If DB.ExcutResult("SELECT id from LOOPS.tblUsers WHERE fullName = '" & Trim(txtName.Text) & "'") <> "" Then
            MsgBox("User already exists!", MsgBoxStyle.Exclamation, Me.Text)
            txtName.Focus()
            Return False
        End If
        If Trim(txtEmail.Text) = "" Then
            MsgBox("Missing Email!", MsgBoxStyle.Exclamation, Me.Text)
            txtEmail.Focus()
            Return False
        End If
        If DB.ExcutResult("SELECT id from LOOPS.tblUsers WHERE email = '" & Trim(txtEmail.Text) & "'") <> "" Then
            MsgBox("Mail already exists!", MsgBoxStyle.Exclamation, Me.Text)
            txtEmail.Focus()
            Return False
        End If
        If ckcmbUserType.EditValue = "" Then
            MsgBox("Missing User Type!", MsgBoxStyle.Exclamation, Me.Text)
            ckcmbUserType.Focus()
            Return False
        End If
        If Not (ckFolderPrepared.Checked Or ckQCFolderReady.Checked Or ckQCApproved.Checked Or ckSubmittedToPrecomm.Checked Or ckLoopDone.Checked Or ckFolderBlockage.Checked) Then
            MsgBox("You Have to assign group to the user!", MsgBoxStyle.Exclamation, Me.Text)
            ckFolderPrepared.Focus()
            Return False
        End If
        If Trim(txtTRUserName.Text) = "" Then
            MsgBox("Missing TR User Name!", MsgBoxStyle.Exclamation, Me.Text)
            txtTRUserName.Focus()
            Return False
        End If
        txtName.Text = Trim(txtName.Text)
        txtUserName.Text = Trim(txtUserName.Text)
        txtEmail.Text = Trim(txtEmail.Text)
        txtTRUserName.Text = Trim(txtTRUserName.Text)
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
            If ckQCApproved.Checked Then userGroup &= "FolderApproved,"
            If ckSubmittedToPrecomm.Checked Then userGroup &= "SubmittedToPrecomm,"
            If ckLoopDone.Checked Then userGroup &= "LoopDone,"
            If ckFolderBlockage.Checked Then userGroup &= "FolderBlockage,"
            isAdded = user.AddUser(txtUserName.Text, txtName.Text, txtPass.Text, ckcmbUserType.EditValue, txtEmail.Text, txtDepartment.Text, txtJob.Text, userGroup, txtTRUserName.Text, userImage)
            If isAdded Then
                MsgBox("New user has been created.", MsgBoxStyle.Information, Me.Text)
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