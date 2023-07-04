Public Class frmNewLoopProgress
    Private Eng As New Engineering
    Public IsAdded As Boolean = False

    Private Sub Errhandling(ByVal e As String)
        MsgBox(e, MsgBoxStyle.Critical, Me.Text)
    End Sub
    Private Sub progressview(ByVal inx As Integer)
        pBar.Value = inx
    End Sub

    Private Sub frmNewLoopProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Eng.Err, AddressOf Errhandling
        AddHandler Eng.ProgressDataCount, AddressOf progressview
        AddHandler DB.ExportProgress, AddressOf progressview
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            Dim msgR As MsgBoxResult = MsgBox("Do You Want To Add Loaded Loops to EICA?" & vbCrLf & "For This Project (" & Users.ProUUID & ")", MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
            dt = ex.GetSheetData(Me.Text, SheetName, "[LoopName] is not null")
            pBar.Maximum = gv.RowCount
            pBar.Value = 0
            pBar.Visible = True

            Dim proUIDColumn As New DataColumn
            proUIDColumn.DataType = System.Type.GetType("System.String")
            proUIDColumn.ColumnName = "ProUUID"
            proUIDColumn.DefaultValue = Users.ProUUID
            dt.Columns.Add(proUIDColumn)

            If ckOverride.Checked Then
                Eng.UploadEngineeringData(dt, Engineering.e_DataType.LOOPS, Engineering.e_OverrideUpload.OverrideData)
            Else
                Eng.UploadEngineeringData(dt, Engineering.e_DataType.LOOPS, Engineering.e_OverrideUpload.NoOverrideData)
            End If
            MsgBox("Loops have been uploaded to EICA", MsgBoxStyle.Information, Me.Text)
            pBar.Visible = False
            IsAdded = True
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Dim msgr As MsgBoxResult = MsgBox("Do You Want To Cancel The Operation", MsgBoxStyle.YesNo, Me.Text)
            If msgr = MsgBoxResult.Yes Then
                Exit Try
            End If
        End Try
    End Sub
End Class