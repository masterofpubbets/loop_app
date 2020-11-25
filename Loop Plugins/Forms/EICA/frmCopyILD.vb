Public Class frmCopyILD
    Private ild As New ExtractILD

    Private Sub OnErr(ByVal err As String)
        MsgBox(err, MsgBoxStyle.Exclamation, Me.Text)
        mBar.Visible = False
    End Sub
    Private Sub frmCopyILD_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler ild.CopyToEICAFinished, AddressOf HCopyFinished
        AddHandler ild.Err, AddressOf OnErr
    End Sub

    Private Sub HCopyFinished()
        MsgBox("Copy ILDs To EICA Has Been Finished", MsgBoxStyle.Information, Me.Text)
        mBar.Visible = False
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Delete All ILDs in EICA", vbYesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        DB.ExcuteNoneResult("delete from tblILD", 600)
        MsgBox("All ILDs Have Been Delete From EICA", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Copy All ILDs To EICA", vbYesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        mBar.Visible = True
        Application.DoEvents()
        ild.CopyILDToEICA()
    End Sub
End Class