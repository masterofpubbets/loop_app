Public Class frmEICALogin
    Private user As New Users

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
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
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
            frmMain.Show()
            Me.Hide()
        Else
            MsgBox("Wrong user name or password!", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.KeyPress
        If e.KeyChar = Chr(13) Then
            OK_Click(sender, e)
        End If
    End Sub
End Class