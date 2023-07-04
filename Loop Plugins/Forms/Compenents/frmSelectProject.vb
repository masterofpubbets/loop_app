Public Class frmSelectProject

    Private Sub GetData()
        grd.DataSource = DB.ReturnDataTable("SELECT * FROM tblProject")
        lblCurrentProject.Text = "Current Project: " & GetSetting("TR", "LoopApp", "ProjectUUID", "")
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmSelectProject_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If gv.GetSelectedRows.Count > 0 Then
            Dim row_handle As Integer = gv.GetSelectedRows(0)
            Users.ProUUID = gv.GetDataRow(row_handle).Item("UUID")
            SaveSetting("TR", "LoopApp", "ProjectUUID", Users.ProUUID)
            MsgBox("Project " & gv.GetDataRow(row_handle).Item("Pro_Title") & " has been selected.", MsgBoxStyle.Information, Me.Text)
            Me.Close()
        End If
    End Sub
End Class