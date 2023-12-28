Public Class frmFilter
    Public isCancel As Boolean = True
    Public searchField As String = ""
    Public searchValues As New Collection
    Public Exact As Boolean = True

    Private Sub frmPunchFilter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.Refresh()
        Me.Refresh()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        isCancel = True
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Trim(txt.Text) = "" Then
            MsgBox("Please Type or Paste Search Value(s)!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If cmbSearchIn.SelectedIndex = -1 Then
            MsgBox("Please Select Where To Search In!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim selected As String = ""
        searchValues = New Collection
        For Each strLine As String In txt.Text.Split(vbNewLine)
            selected = Replace(strLine, vbLf, "")
            If Trim(selected) <> "" Then
                searchValues.Add(selected)
            End If
        Next
        searchField = cmbSearchIn.SelectedItem.ToString
        isCancel = False
        If tgExact.IsOn Then
            Exact = False
        End If
        Me.Close()
    End Sub

    Private Sub frmFilter_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class