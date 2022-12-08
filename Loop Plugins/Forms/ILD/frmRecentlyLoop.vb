Public Class frmRecentlyLoop

    Private Sub GetData()
        GRD.DataSource = AccDB.ReturnDataTable("Select Distinct LoopName from tblNewLoopAdded")
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub frmRecentlyLoop_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            GRD.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            If DB.DBStatus = ConnectionState.Closed Then
                MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
                Exit Sub
            End If
            Dim dt As New DataTable
            dt = AccDB.ReturnDataTable("Select Distinct LoopName from tblNewLoopAdded")
            For inx As Integer = 0 To dt.Rows.Count - 1
                If DB.ExcutResult(String.Format("select loopname from tblinsloop where [status] ='On Hold Missing ILD' and loopname='{0}'", dt.Rows(inx).Item("loopname"))) <> "" Then
                    DB.ExcutResult(String.Format("update tblinsloop set [status]=null where loopname='{0}'", dt.Rows(inx).Item("loopname")))
                End If
            Next
            MsgBox("Loops Status Have Been Updated", MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try

    End Sub
End Class