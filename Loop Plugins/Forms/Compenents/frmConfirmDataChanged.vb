Imports System.ComponentModel

Public Class frmConfirmDataChanged
    Public ActionType As MsgBoxResult = MsgBoxResult.Retry
    Public SelectedDate As Date
    Private isDateRequired As Boolean = True

    Public Sub New(Optional dateRequired As Boolean = True)

        ' This call is required by the designer.
        InitializeComponent()

        Me.isDateRequired = dateRequired

    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ActionType = MsgBoxResult.Ignore
        Me.Close()
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If isDateRequired Then
            MsgBox("Please Select Update Date.", MsgBoxStyle.Information, Me.Text)
            Dim frm As New frmSelectDateConstraint
            frm.SimpleButton3.Visible = False
            frm.ShowDialog(Me)
            If frm.isSelected Then
                SelectedDate = frm.selectedDate
                ActionType = MsgBoxResult.Ok
                Me.Close()
            End If
        Else
            ActionType = MsgBoxResult.Ok
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ActionType = MsgBoxResult.Cancel
        Me.Close()
    End Sub
End Class