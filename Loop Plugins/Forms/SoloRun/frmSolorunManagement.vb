Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class frmSolorunManagement
    Private DT As New DataTable
    Private Builder As SqlClient.SqlCommandBuilder
    Private cmd As New SqlClient.SqlCommand("SELECT Id,[FolderName] AS [Folder Name],[L_Type] AS [Type],[Sub_Type] AS [Sub Type],[L_Description] AS [Description],
                                            [Subsystem],[Area],[Planning_START_Date] AS [Plan Start Date],[Planning_FINISH_Date] AS [Plan Finish Date],
                                            CASE WHEN [Active] = 1 THEN 'Active' ELSE 'Deleted' END AS [Status],[PID],[ACTIVITYID] AS [Activity ID],
                                            [FolderPriority] AS [Priority],[Subcontractor],[Vendor], ControllerLocation AS [Controller Location],PDSModel,L_Remarks AS Remarks,
                                            [Folder_Preparation] AS [Folder Printed], L_Constr_Release AS [Cons Complete], TR_Loop_Folder_QC_Release AS [QC Released],
                                            HCS_Folder_Ready AS [Folder Ready QC], Submitted_to_Precom AS [Submitted To Precomm], L_Done AS [Done], L_FinalApproval AS [Final Approval]
                                            FROM tblSolorun",
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
    Private lf As New Soloruns
    Private hasChanged As Boolean = False
    Private opnedHandle As IOverlaySplashScreenHandle
    Private SolorunLists As New Soloruns


    Private Sub ShowRadialMenu()
        ' Display Radial Menu
        If rMenu Is Nothing Then
            Return
        End If
        Dim pt As Point = Me.Location
        pt.Offset(Me.Width \ 2, Me.Height \ 2)
        rMenu.ShowPopup(pt)
    End Sub
    Private Sub SaveChanges()
        Dim frmd As New frmConfirmDataChanged(False)
        frmd.grdPred.DataSource = SolorunLists.GetFoldersForPlanning
        frmd.Text = "Solo Run Folders Data Changes"
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
                    ClearChanges()
                    lf.CheckIntgerity()
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Private Sub ClearChanges()
        hasChanged = False
        SolorunLists.ClearData()
        cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
    End Sub
    Private Sub AddToSaveList(ByVal lf As Solorun)
        hasChanged = True
        cmdSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        SolorunLists.Add(lf)
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
        gv.Columns("Id").Visible = False

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

    Private Sub frmSolorunManagement_Load(sender As Object, e As EventArgs) Handles Me.Load
        getData()
    End Sub

    Private Sub frmSolorunManagement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        Else
            frmMain.MdiChildClosed(Me.Text)
        End If
    End Sub
    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles GRD.KeyDown
        Select Case e.KeyCode
            Case Keys.Space
                ShowRadialMenu()
        End Select
    End Sub
    Private Sub gv_EditFormHidden(sender As Object, e As EditFormHiddenEventArgs) Handles gv.EditFormHidden
        If e.Result = EditFormResult.Update Then
            AddToSaveList(New Solorun(
                          gv.GetDataRow(e.RowHandle).Item("Folder Name"),
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

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Application.DoEvents()
        ShowProgressPanel()
        getData()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Application.DoEvents()
        Dim frm As New frmFilter
        frm.Text = "Solo Run Filter"
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

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        Application.DoEvents()
        grdView.CopySelectedItems(gv, "Folder Name")
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        GRD.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
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

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
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

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Application.DoEvents()
        Dim frm As New frmUpdateSoloRunFolders(Nothing, True)
        frmMain.AddToQuickAccess(frm)
        frm.MdiParent = frmMain
        frm.Show()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Application.DoEvents()
        Dim folders As New List(Of Solorun)
        For Each row_handle As Integer In gv.GetSelectedRows
            folders.Add(New Solorun(
                                        gv.GetDataRow(row_handle).Item("Folder Name"),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Plan Start Date")), "1/1/0001", gv.GetDataRow(row_handle).Item("Plan Start Date")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Plan Finish Date")), "1/1/0001", gv.GetDataRow(row_handle).Item("Plan Finish Date")),
                                        0,
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Vendor")), "", gv.GetDataRow(row_handle).Item("Vendor")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Folder Printed")), "1/1/0001", gv.GetDataRow(row_handle).Item("Folder Printed")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Cons Complete")), "1/1/0001", gv.GetDataRow(row_handle).Item("Cons Complete")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("QC Released")), "1/1/0001", gv.GetDataRow(row_handle).Item("QC Released")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Folder Ready QC")), "1/1/0001", gv.GetDataRow(row_handle).Item("Folder Ready QC")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Submitted To Precomm")), "1/1/0001", gv.GetDataRow(row_handle).Item("Submitted To Precomm")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Done")), "1/1/0001", gv.GetDataRow(row_handle).Item("Done")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Final Approval")), "1/1/0001", gv.GetDataRow(row_handle).Item("Final Approval")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Type")), "", gv.GetDataRow(row_handle).Item("Type")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Sub Type")), "", gv.GetDataRow(row_handle).Item("Sub Type")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Activity ID")), "", gv.GetDataRow(row_handle).Item("Activity ID")),
                                        CDate("1/1/0001"),
                                        CDate("1/1/0001"),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Subsystem")), "", gv.GetDataRow(row_handle).Item("Subsystem")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Priority")), -1, gv.GetDataRow(row_handle).Item("Priority")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("PDSModel")), "", gv.GetDataRow(row_handle).Item("PDSModel")),
                                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Controller Location")), "", gv.GetDataRow(row_handle).Item("Controller Location"))
                                    ))
        Next

        Dim frm As New frmUpdateSoloRunFolders(folders)
        frmMain.AddToQuickAccess(frm)
        frm.MdiParent = frmMain
        frm.Show()
    End Sub

    Private Sub BarButtonItem13_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Application.DoEvents()
        Try
            Dim msg As MsgBoxResult = MsgBox("Are You Sure You Want To Delete Selected Folders", MsgBoxStyle.YesNo, Me.Text)
            If msg = MsgBoxResult.No Then Exit Sub
            ShowProgressPanel()
            Dim dt As New DataTable
            dt.Columns.Add("Tag", System.Type.GetType("System.String"))
            For Each row_handle As Integer In gv.GetSelectedRows
                dt.Rows.Add(gv.GetDataRow(row_handle).Item("Folder Name"))
            Next
            If dt.Rows.Count = 0 Then
                MsgBox("Nothing to update!", MsgBoxStyle.Exclamation, Me.Text)
                CloseProgressPanel(opnedHandle)
                Exit Sub
            End If
            Dim opKey As String = lf.UploadTempData(Enumerations.UpdateType.UPDATEDATA, dt)
            If opKey <> "" Then
                Dim dtResult As New DataTable
                If lf.Delete(opKey, dtResult) Then
                    lf.DeleteTempData(opKey)
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        CloseProgressPanel(opnedHandle)
                        Exit Sub
                    End If
                    getData()
                End If

            Else
                MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
            End If

        Catch ex As Exception

        End Try
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Application.DoEvents()
        Try
            Dim msg As MsgBoxResult = MsgBox("Are You Sure You Want To Deactivate Selected Folders", MsgBoxStyle.YesNo, Me.Text)
            If msg = MsgBoxResult.No Then Exit Sub
            ShowProgressPanel()
            Dim dt As New DataTable
            dt.Columns.Add("Tag", System.Type.GetType("System.String"))
            For Each row_handle As Integer In gv.GetSelectedRows
                dt.Rows.Add(gv.GetDataRow(row_handle).Item("Folder Name"))
            Next
            If dt.Rows.Count = 0 Then
                MsgBox("Nothing to update!", MsgBoxStyle.Exclamation, Me.Text)
                CloseProgressPanel(opnedHandle)
                Exit Sub
            End If
            Dim opKey As String = lf.UploadTempData(Enumerations.UpdateType.UPDATEDATA, dt)
            If opKey <> "" Then
                Dim dtResult As New DataTable
                If lf.ChangeStatus(opKey, dtResult, 0) Then
                    lf.DeleteTempData(opKey)
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                        CloseProgressPanel(opnedHandle)
                        Exit Sub
                    End If
                    getData()
                End If

            Else
                MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
            End If

        Catch ex As Exception

        End Try
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub cmdSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        SaveChanges()
    End Sub

    Private Sub frmSolorunManagement_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
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
                    frmMain.MdiChildClosed(Me.Text)
                    e.Cancel = False
                Case Else
                    e.Cancel = True
            End Select
        Else
            frmMain.MdiChildClosed(Me.Text)
        End If
    End Sub
End Class