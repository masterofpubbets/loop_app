Imports System.ComponentModel

Public Class frmDefaultCons
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If lst.SelectedIndex = -1 Then
            MsgBox("No Constraint Selected", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Clipboard.Clear()
        Clipboard.SetText(lst.SelectedItem.ToString)
        MsgBox(String.Format("{0}{1}Has Been Copied", lst.SelectedItem, vbCrLf), MsgBoxStyle.OkOnly, Me.Text)
    End Sub

    Private Sub frmDefaultCons_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class