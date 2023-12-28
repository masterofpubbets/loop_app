Imports System.ComponentModel

Public Class frmAddLoopProgress
    Private Eng As New Engineering
    Public isAdded As Boolean = False

    Private Sub Errhandling(ByVal e As String)
        MsgBox(e, MsgBoxStyle.Critical, Me.Text)
    End Sub
    Private Sub progressview(ByVal inx As Integer)
        pBar.EditValue = inx
    End Sub
    Private Sub frmAddLoopProgress_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Eng.Err, AddressOf Errhandling
        AddHandler Eng.ProgressDataCount, AddressOf progressview
        AddHandler DB.ExportProgress, AddressOf progressview
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Try
            Dim msgR As MsgBoxResult = MsgBox("Do You Want To Add Loaded Loops to EICA", MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
            dt = ex.GetSheetData(Me.Text, SheetName, "[LoopName] is not null")
            pBar.Properties.Maximum = GridView3.RowCount
            pBar.EditValue = 0
            pBar.Visible = True
            If ckOverride.Checked Then
                Eng.UploadEngineeringData(dt, Engineering.e_DataType.LOOPS, Engineering.e_OverrideUpload.OverrideData)
            Else
                Eng.UploadEngineeringData(dt, Engineering.e_DataType.LOOPS, Engineering.e_OverrideUpload.NoOverrideData)
            End If
            MsgBox("Loops have been uploaded to EICA", MsgBoxStyle.Exclamation, Me.Text)
            pBar.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Dim msgr As MsgBoxResult = MsgBox("Do You Want To Cancel The Operation", MsgBoxStyle.YesNo, Me.Text)
            If msgr = MsgBoxResult.Yes Then
                Exit Try
            End If
        End Try

    End Sub

    Private Sub frmAddLoopProgress_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class