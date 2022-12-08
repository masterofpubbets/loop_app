Public Class frmEICALogin

    Public Sub checkpassword()
        EICADBConnect()
        SaveSetting("TR", "EIKA", "DBLoc", txtConn.Text)
        SaveSetting("TR", "EIKA", "DBName", txtDB.Text)
        SaveSetting("TR", "EIKA", "U", txtUser.Text)
        SaveSetting("TR", "EIKA", "P", txtPass.Text)
    End Sub

    Private Sub frmEICALogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadSettings()
        txtConn.Text = DB.DataBaseLocation
        txtDB.Text = DB.DataBaseName
    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        DBPath = txtConn.Text
        DBName = txtDB.Text
        UserName = txtUser.Text
        Password = txtPass.Text
        checkpassword()
        Me.Close()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class