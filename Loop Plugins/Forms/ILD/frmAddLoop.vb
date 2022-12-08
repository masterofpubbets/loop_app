Public Class frmAddLoop
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick, BarButtonItem3.ItemClick
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName = "" Then Exit Sub
        AccDB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT null as [Loop_Name],null as [Item],null as [Segment]", SheetName)
        MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
        Process.Start(sveFle.FileName)
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[Loop_Name] is not null")
        RepositoryItemProgressBar1.Maximum = dt.Rows.Count
        GRD.DataSource = dt
        For inx As Integer = 0 To dt.Rows.Count - 1
            AccDB.ExcuteNoneResult(String.Format("insert into tblILD (Loop_Name,Item,Segment) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Loop_Name"), dt.Rows(inx).Item("Item"), dt.Rows(inx).Item("Segment")))
            pBar.EditValue = inx + 1
            pBar.Caption = inx + 1 & " / " & dt.Rows.Count
            Application.DoEvents()
        Next
        MsgBox("Importing Has Been Finished", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        Const TbName As String = "tblILD"
        Dim sql As String = ""
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName)
        RepositoryItemProgressBar2.Maximum = dt.Rows.Count
        'Main -----------------------------------------------------------------------------------------------------
        For inx = 0 To dt.Rows.Count - 1
            For iny = 1 To dt.Columns.Count - 1
                If IsDBNull(dt.Rows(inx).Item(iny)) Then
                    sql = "update " & TbName & " set [" & dt.Columns(iny).ColumnName & "] = " & "null" & " " &
                           "where [" & dt.Columns(0).ColumnName & "] = '" & dt.Rows(inx).Item(0).ToString & "'"
                Else
                    If dt.Columns(iny).DataType.Name = vbDouble.ToString Or dt.Columns(iny).DataType.Name = vbDecimal.ToString Then
                        sql = "update " & TbName & " set [" & dt.Columns(iny).ColumnName & "] = " & Val(dt.Rows(inx).Item(iny).ToString) & " " &
                           "where [" & dt.Columns(0).ColumnName & "] = '" & dt.Rows(inx).Item(0).ToString & "'"
                    ElseIf dt.Columns(iny).DataType.Name = vbDate.ToString Then
                        sql = "update " & TbName & " set [" & dt.Columns(iny).ColumnName & "] = '" & Format(CDate(dt.Rows(inx).Item(iny)), "MM/dd/yyyy") & "' " &
                            "where [" & dt.Columns(0).ColumnName & "] = '" & dt.Rows(inx).Item(0).ToString & "'"
                    ElseIf dt.Columns(iny).DataType.Name = "DateTime" Then
                        sql = "update " & TbName & " set [" & dt.Columns(iny).ColumnName & "] = '" & Format(CDate(dt.Rows(inx).Item(iny)), "MM/dd/yyyy") & "' " &
                            "where [" & dt.Columns(0).ColumnName & "] = '" & dt.Rows(inx).Item(0).ToString & "'"
                    Else
                        sql = "update " & TbName & " set [" & dt.Columns(iny).ColumnName & "] = '" & dt.Rows(inx).Item(iny).ToString & "' " &
                            "where [" & dt.Columns(0).ColumnName & "] = '" & dt.Rows(inx).Item(0).ToString & "'"
                    End If
                End If
                AccDB.ExcuteNoneResult(sql)
                Application.DoEvents()
                pBar2.EditValue = inx + 1
                pBar2.Caption = inx + 1 & " / " & dt.Rows.Count
            Next
        Next
        MsgBox("Updating Has Been Finished", MsgBoxStyle.Information, Me.Text)
        '---------------------------------------------------------------------------
    End Sub


End Class