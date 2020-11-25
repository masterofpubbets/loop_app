Public Class frmEditLoopBProgress
    Private Eng As New Engineering

    Private Sub Errhandling(ByVal e As String)
        MsgBox(e, MsgBoxStyle.Critical, Me.Text)
    End Sub

    Private Sub frmEditLoopBProgress_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Eng.Err, AddressOf Errhandling
        AddHandler Eng.ProgressDataCount, AddressOf progressview
        AddHandler DB.ExportProgress, AddressOf progressview
    End Sub

    Private Sub progressview(ByVal inx As Integer)
        pBar.EditValue = inx
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            Dim msgR As MsgBoxResult = MsgBox("Do You Want To Update Loops With Loaded Data", MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
            dt = ex.GetSheetData(Me.Text, SheetName, "[LoopName] is not null")
            pBar.Properties.Maximum = GridView3.RowCount
            pBar.EditValue = 0
            pBar.Visible = True
            Eng.UpdateEngineeringData(dt, Engineering.e_DataType.LOOPS)
            MsgBox("Loops have been Updated", MsgBoxStyle.Exclamation, Me.Text)
            pBar.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Dim msgr As MsgBoxResult = MsgBox("Do You Want To Cancel The Operation", MsgBoxStyle.YesNo, Me.Text)
            If msgr = MsgBoxResult.Yes Then
                Exit Try
            End If
        End Try

    End Sub
End Class