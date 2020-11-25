Public Class frmExcute

    Private Sub h_Err(ByVal msg As String)
        lblErr.Text &= msg & vbCrLf
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Trim(txt.Text) = "" Then
            MsgBox("No Command To Execute", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If InStr(txt.Text, ";", CompareMethod.Text) = 0 Then
            txt.Text &= ";"
        End If
        Dim t() As String = Split(txt.Text, ";",, CompareMethod.Text)
        For inx As Integer = 0 To t.Length - 1
            If t(inx) <> "" Then

            End If
            AccDB.ExcuteNoneResult(t(inx))
            lblStatus.Caption = "Executed " & inx + 1 & " / " & t.Length
            Application.DoEvents()
        Next
        MsgBox("Executing Has Been Finished", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub frmExcute_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler AccDB.err, AddressOf h_Err
    End Sub
End Class