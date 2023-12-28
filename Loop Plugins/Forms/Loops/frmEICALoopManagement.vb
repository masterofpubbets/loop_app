Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen
Public Class frmEICALoopManagement
    Private DT As New DataTable
    Private Builder As SqlClient.SqlCommandBuilder
    Private cmd As New SqlClient.SqlCommand("SELECT [TBL_ID] AS ID,[LoopName] AS [Loop Name],[L_Type] AS [Type],[Sub_Type] AS [Sub Type],[L_Description] AS [Description],
                                            [Subsystem],[Area],[Planning_START_Date] AS [Plan Start Date],[Planning_FINISH_Date] AS [Plan Finish Date],
                                            CASE WHEN [Active] = 1 THEN 'Active' ELSE 'Deleted' END AS [Status],[PID],[ACTIVITYID] AS [Activity ID],
                                            [LoopPriority] AS [Priority],[Subcontractor],[Vendor],
                                            [Folder_Preparation] AS [Folder Printed], L_Constr_Release AS [Cons Complete], TR_Loop_Folder_QC_Release AS [QC Released],
                                            HCS_Folder_Ready AS [Folder Ready QC], Submitted_to_Precom AS [Submitted To Precomm], L_Done AS [Done], L_FinalApproval AS [Final Approval]
                                            FROM tblInsLoop",
                                            DB.DBConnection)
    Private DA As New SqlClient.SqlDataAdapter(cmd)
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private viewType As Boolean = False
    Private StandardRulesAdded As Boolean = False
    Private fs As New FileSystem
    Private lf As New LoopFolders
    Private hasChanged As Boolean = False
    Private opnedHandle As IOverlaySplashScreenHandle
    Private LoopLists As New LoopFolders




    Private Sub SaveChanges()
        Dim frmd As New frmConfirmDataChanged(False)
        frmd.grdPred.DataSource = LoopLists.GetLoopsFoldersForPlanning
        frmd.Text = "Loop Folders Data Changes"
        frmd.ShowDialog(Me)
        Select Case frmd.ActionType
            Case MsgBoxResult.Ignore
                ClearChanges()
            Case MsgBoxResult.Ok
                Try
                    Dim rws As Integer = 0
                    DT = GRD.DataSource
                    rws = DA.Update(DT)
                    MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.Information, Me.Text)
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Private Sub ClearChanges()
        hasChanged = False
        LoopLists.ClearData()
        cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
    End Sub
    Private Sub AddToSaveList(ByVal lf As LoopFolder)
        hasChanged = True
        cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        LoopLists.Add(lf)
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
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

        gv.Columns("Folder Printed").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Final Approval").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("QC Released").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Folder Ready QC").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Submitted To Precomm").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Done").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        gv.OptionsSelection.MultiSelect = True
        gv.Columns("ID").Visible = False

        gv.Columns("Activity ID").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gv.Columns("Area").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gv.Columns("Status").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False

        gv.OptionsBehavior.Editable = True

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


    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        ShowProgressPanel()
        getData()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub frmAddEICALoop_Load(sender As Object, e As EventArgs) Handles Me.Load
        getData()
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

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim frm As New frmUpdateLoopFolders
        frm.MdiParent = frmMain
        frm.Show()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Loops Filter"
        For inx As Integer = 0 To gv.Columns.Count - 1
            frm.cmbSearchIn.Items.Add(gv.Columns.Item(inx).FieldName)
        Next
        frm.ShowDialog(Me)
        If Not frm.isCancel Then
            Dim bc As String = ""
            If Not frm.Exact Then bc = "%"
            Dim _filter As String = ""
            For inx As Integer = 1 To frm.searchValues.Count
                If inx <> 1 Then
                    _filter &= String.Format("OR [{0}] LIKE '{2}{1}{2}'", frm.searchField, frm.searchValues.Item(inx), bc)
                Else
                    _filter = String.Format("[{0}] LIKE '{2}{1}{2}'", frm.searchField, frm.searchValues.Item(inx), bc)
                End If
            Next
            gv.Columns(frm.searchField).FilterInfo = New ColumnFilterInfo(_filter)
        End If
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
    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        sveFle.Filter = "Views File|*.xml"
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName <> "" Then
            If grdView.SaveViewLayout(gv, sveFle.FileName) Then
                MsgBox("View Has Been Saved", MsgBoxStyle.Information, Me.Text)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, sveFle.FileName)
            End If
        End If
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        Try
            If opnFle.FileName <> "" Then
                'grdView.setViewFromFile(gv, opnFle.FileName)
                grdView.ApplyViewLayout(gv, opnFle.FileName)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, opnFle.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        For Each row_handle As Integer In gv.GetSelectedRows
            Try
                Dim pdfs As List(Of String)
                Dim pdfsFName As New List(Of String)
                pdfs = fs.FindFile(gv.GetDataRow(row_handle).Item("Loop Name") & "*", SharedFolder, pdfsFName)
                If IsNothing(pdfs) Then
                    MsgBox("No PDF associated to this Loop!", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                If pdfs.Count = 0 Then
                    MsgBox("No PDF associated to this Loop!", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
                End If
                If IO.File.Exists(pdfs.Item(0)) Then
                    Dim frm As New frmPdf() With {.PDFPath = pdfs.Item(0), .Text = gv.GetDataRow(row_handle).Item("Loop Name")}
                    frm.Show()
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        grdView.CopySelectedItems(gv, "Loop Name")
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        GRD.ShowPrintPreview()
    End Sub
    Private Sub gv_EditFormHidden(sender As Object, e As EditFormHiddenEventArgs) Handles gv.EditFormHidden
        If e.Result = EditFormResult.Update Then
            AddToSaveList(New LoopFolder(
                          gv.GetDataRow(e.RowHandle).Item("Loop Name"),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Plan Start Date")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Plan Start Date")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Plan Finish Date")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Plan Finish Date")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Done")), 0, 100),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Vendor")), "", gv.GetDataRow(e.RowHandle).Item("Vendor")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Description")), "", gv.GetDataRow(e.RowHandle).Item("Description")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Folder Printed")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Folder Printed")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Cons Complete")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Cons Complete")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("QC Released")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("QC Released")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Folder Ready QC")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Folder Ready QC")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Submitted To Precomm")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Submitted To Precomm")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Done")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Done")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Final Approval")), "1/1/0001", gv.GetDataRow(e.RowHandle).Item("Final Approval")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Area")), "", gv.GetDataRow(e.RowHandle).Item("Area")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Type")), "", gv.GetDataRow(e.RowHandle).Item("Type")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Sub Type")), "", gv.GetDataRow(e.RowHandle).Item("Sub Type")),
                          IIf(IsDBNull(gv.GetDataRow(e.RowHandle).Item("Activity ID")), "", gv.GetDataRow(e.RowHandle).Item("Activity ID"))
                          ))
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        SaveChanges()
    End Sub

    Private Sub btnShowChanges_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowChanges.ItemClick
        SaveChanges()
    End Sub

    Private Sub frmEICALoopManagement_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If hasChanged Then
            Dim frm As New frmConfirmClose
            frm.ShowDialog(Me)
            Select Case frm.Result
                Case frmConfirmClose.eResultType.Cancel
                    e.Cancel = True
                Case frmConfirmClose.eResultType.Dicard
                    e.Cancel = False
                    frmMain.MdiChildClosed(Me.Text)
                Case frmConfirmClose.eResultType.Save
                    SaveChanges()
                Case Else
                    e.Cancel = True
            End Select
        End If
    End Sub
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        GRD.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If MsgBox("Do you want to generate automatically priorities for the loop based on Start Dates?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        If lf.CreateLoopPriority Then
            getData()
        End If
    End Sub
End Class