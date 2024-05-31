Imports DevExpress.XtraSplashScreen
Public Class frmEICALogin
    Private user As New Users
    Private pe As New PublicErrors
    Private opnedHandle As IOverlaySplashScreenHandle


    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub ParseDetailsFile(ByVal content As String)
        Dim temp() As String = Split(content, vbCrLf,, CompareMethod.Binary)
        For inx As Integer = 0 To temp.Length - 1
            If InStr(temp(inx), "server:", CompareMethod.Text) > 0 Then
                txtConn.Text = Trim(Replace(temp(inx), "server:", "",,, CompareMethod.Text))
            ElseIf InStr(temp(inx), "database:", CompareMethod.Text) > 0 Then
                txtDB.Text = Trim(Replace(temp(inx), "database:", "",,, CompareMethod.Text))
            ElseIf InStr(temp(inx), "user:", CompareMethod.Text) > 0 Then
                txtUser.Text = Trim(Replace(temp(inx), "user:", "",,, CompareMethod.Text))
            ElseIf InStr(temp(inx), "pass:", CompareMethod.Text) > 0 Then
                txtPass.Text = Trim(Replace(temp(inx), "pass:", "",,, CompareMethod.Text))
            End If
        Next
    End Sub
    Public Function checkpassword() As Boolean
        Try
            DBConnect()
            SaveSetting("TR", "EIKA", "DBLoc", txtConn.Text)
            SaveSetting("TR", "EIKA", "DBName", txtDB.Text)
            SaveSetting("TR", "EIKA", "U", txtUser.Text)
            Dim loginType = user.loggin(txtUser.Text, txtPass.Text)
            Select Case loginType
                Case -1
                    Users.userFullName = ""
                    Users.userName = ""
                    Users.userType = ""
                    Return True
                Case 0
                    Return False
                Case 1
                    Return True
            End Select

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Private Sub frmEICALogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler AccDB.Connnected, AddressOf frmMain.OnConnected
        AddHandler AccDB.Disconnected, AddressOf frmMain.OnDisConnected
        AddHandler DB.Connnected, AddressOf frmMain.OnEICAConnected
        AddHandler DB.Disconnected, AddressOf frmMain.OnEICADisConnected
        AddHandler Users.userChanged, AddressOf frmMain.HandleUserChanged
        LoadSettings()
        txtConn.Text = DBPath
        txtDB.Text = DBName
        txtUser.Text = UserName
        If Val(GetSetting("TR", "EIKA", "LOGINTRUST", "0")) = 1 Then
            ckTrust.Checked = True
            If txtUser.Text = GetSetting("TR", "EIKA", "LOGINUSR", "") Then
                txtPass.Text = GetSetting("TR", "EIKA", "LOGINKEY", "")
            End If
        Else
            ckTrust.Checked = False
        End If
    End Sub

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = Chr(13) Then
            SimpleButton1_Click(sender, e)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            ShowProgressPanel()
            Application.DoEvents()
            SharedFolder = GetSetting("TR", "EIKA", "SharedFolder", "")
            ILDDBFile = GetSetting("TR", "EIKA", "ILDDBFile", "")
            If ((ILDDBFile = "") Or (SharedFolder = "")) Then
                Dim msgr As MsgBoxResult = MsgBox("Please Select ILD Folder and DB File Settings First", MsgBoxStyle.OkCancel, Me.Text)
                If msgr = MsgBoxResult.Cancel Then
                    Me.Close()
                    End
                End If
                Dim frm As New frmSet
                frm.ShowDialog(Me)
            End If
            DBPath = txtConn.Text
            DBName = txtDB.Text
            UserName = txtUser.Text
            Password = txtPass.Text
            If checkpassword() Then
                CloseProgressPanel(opnedHandle)
                frmMain.Show()
                If ckTrust.Checked Then
                    SaveSetting("TR", "EIKA", "LOGINTRUST", "1")
                    SaveSetting("TR", "EIKA", "LOGINKEY", txtPass.Text)
                    SaveSetting("TR", "EIKA", "LOGINUSR", txtUser.Text)
                Else
                    SaveSetting("TR", "EIKA", "LOGINTRUST", "0")
                End If
                Me.Hide()
            Else
                MsgBox("Wrong user name or password!", MsgBoxStyle.Exclamation, Me.Text)
                CloseProgressPanel(opnedHandle)
            End If
        Catch ex As Exception
            MsgBox("Wrong user name or password!", MsgBoxStyle.Exclamation, Me.Text)
            CloseProgressPanel(opnedHandle)
        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        opnFile.FileName = ""
        opnFile.ShowDialog()
        If opnFile.FileName <> "" Then
            Dim fs As New FileSystem
            Dim d As String = fs.ReadTextFile(opnFile.FileName)
            If d <> "" Then
                ParseDetailsFile(d)
                txtPass.Focus()
            End If
        End If
    End Sub

End Class