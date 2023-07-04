Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Public Class frmEICALoopManagement
    Private DT As New DataTable
    Private Builder As SqlClient.SqlCommandBuilder
    Private cmd As New SqlClient.SqlCommand("SELECT [TBL_ID] AS ID,[LoopName] AS [Loop Name],[L_Type] AS [Type],[Sub_Type] AS [Sub Type],[L_Description] AS [Description],[Subsystem],[Area],[Planning_START_Date],[Planning_FINISH_Date],[Active],[PID],[ACTIVITYID] AS [Activity ID],[LoopPriority] AS [Priority],[Subcontractor],[Vendor] FROM tblInsLoop", DB.DBConnection)
    Private DA As New SqlClient.SqlDataAdapter(cmd)
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private viewType As Boolean = False
    Private StandardRulesAdded As Boolean = False

    Private Sub formatColumnsWidth()
        Try
            If IsNothing(colWidth) Then
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = 100
                Next
            Else
                gv.FocusedRowHandle = focusedRowHandler
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = colWidth.Item(inx)
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub saveColumnsWidth()
        Try
            If gv.RowCount <> 0 Then
                focusedRowHandler = gv.FocusedRowHandle

                If IsNothing(colWidth) Then
                    colWidth = New Collection
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                Else
                    colWidth.Clear()
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ConditionalFormat()
        If Not StandardRulesAdded Then
            Dim gridFormatRule As New GridFormatRule()
            Dim formatConditionRuleExpression As New FormatConditionRuleExpression()
            gridFormatRule.ApplyToRow = True
            formatConditionRuleExpression.PredefinedName = "Red Fill, Red Text"
            formatConditionRuleExpression.Expression = "[Active] = 0"
            gridFormatRule.Rule = formatConditionRuleExpression
            gv.FormatRules.Add(gridFormatRule)
            StandardRulesAdded = True
        End If
    End Sub
    Private Sub Filter()
        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
    End Sub
    Private Sub getData()
        saveColumnsWidth()
        GetRawData()
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        'gv.Columns("Pulled Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        'gv.Columns("TotalPercentage").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        'gv.Columns("Pulled Lm").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        'gv.Columns("Con From Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        'gv.Columns("Con To Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        'gv.Columns("Test Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        'gv.Columns("QC Released Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        'gv.Columns("Pulling Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        'gv.Columns("Gland From Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        'gv.Columns("Gland To Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        'gv.Columns("Conn From Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        'gv.Columns("Conn To Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)


        gv.OptionsSelection.MultiSelect = True

        'conditional format
        ConditionalFormat()

        'Filter
        Filter()

        gv.BestFitColumns(True)

    End Sub

    Private Sub GetRawData()
        DT = New DataTable
        DA.Fill(DT)
        Builder = New SqlClient.SqlCommandBuilder(DA)
        DA.InsertCommand = Builder.GetInsertCommand
        DA.UpdateCommand = Builder.GetUpdateCommand
        GRD.DataSource = DT
    End Sub


    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick, BarButtonItem10.ItemClick
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName = "" Then Exit Sub
        AccDB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT '' AS [LoopName],'' AS [L_Type],'' AS [Sub_Type],'' AS [L_Description],'' AS [Subsystem],'' AS [Area],'' AS [Planning_START_Date],'' AS [Planning_FINISH_Date],'' AS [Active],'' AS [PID],'' AS [ACTIVITYID],'' AS [LoopPriority],'' AS [Subcontractor],'' AS [Vendor]", SheetName)
        MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
        Process.Start(sveFle.FileName)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub frmAddEICALoop_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[LoopName] is not null")
        If dt.Rows.Count = 0 Then
            MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmNewLoopProgress
        frm.grd.DataSource = dt
        frm.Text = opnFle.FileName
        frm.ShowDialog(Me)
        If frm.IsAdded Then GetData()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        Try
            Dim rws As Integer = 0
            DT = GRD.DataSource
            rws = DA.Update(DT)
            MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
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

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            Dim msg As MsgBoxResult = MsgBox("Are You Sure You Want To Delete Selected Loop", MsgBoxStyle.YesNo, Me.Text)
            If msg = MsgBoxResult.No Then Exit Sub
            gv.DeleteSelectedRows()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName = "" Then Exit Sub
        AccDB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT '' as [LoopName],'' as [Folder_Preparation],'' as [TR_Loop_Folder_QC_Release],'' as [HCS_Folder_Ready],'' as [Submitted_to_Precom],'' as [L_Done],'' as [Submitted_For_Certificate],'' as [L_FinalApproval]", SheetName)
        MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
        Process.Start(sveFle.FileName)
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[LoopName] is not null")
        If dt.Rows.Count = 0 Then
            MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmEditLoopBProgress
        frm.GridControl2.DataSource = dt
        frm.Text = opnFle.FileName
        frm.ShowDialog(Me)
        getData()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Loops Filter"
        For inx As Integer = 0 To gv.Columns.Count - 1
            frm.cmbSearchIn.Items.Add(gv.Columns.Item(inx).FieldName)
        Next
        frm.ShowDialog(Me)
        If Not frm.isCancel Then
            Dim _filter As String = ""
            For inx As Integer = 1 To frm.searchValues.Count
                If inx <> 1 Then
                    _filter &= String.Format("OR [{0}] LIKE '{1}'", frm.searchField, frm.searchValues.Item(inx))
                Else
                    _filter = String.Format("[{0}] LIKE '{1}'", frm.searchField, frm.searchValues.Item(inx))
                End If
            Next
            gv.Columns(frm.searchField).FilterInfo = New ColumnFilterInfo(_filter)
        End If
    End Sub

    Private Sub ckEditInPlace_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ckEditInPlace.CheckedChanged
        If ckEditInPlace.Checked Then
            cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Else
            cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        End If
        gv.OptionsBehavior.Editable = ckEditInPlace.Checked
    End Sub

    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        For Each row_handle As Integer In gv.GetSelectedRows
            Dim frm As New frmQRCodeViewer
            frm.lbl.Text = "Loop: " & gv.GetDataRow(row_handle).Item("Loop Name")
            frm.pic.Image = DB.GetImage("SELECT qrCode FROM tblInsLoop WHERE LoopName ='" & gv.GetDataRow(row_handle).Item("Loop Name") & "'")
            frm.Show()
        Next
    End Sub
End Class