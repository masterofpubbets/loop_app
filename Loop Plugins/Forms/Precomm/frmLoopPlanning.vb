Imports DevExpress.XtraTreeList
Imports DevExpress.XtraGantt
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Columns

Public Class frmLoopPlanning
    Private LoopGant As New LoopPlanning
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private viewType As Boolean = False
    Private StandardRulesAdded As Boolean = False
    Private fs As New FileSystem
    Private hasChanged As Boolean = False
    Private isDataLoaded As Boolean = False
    Private taskID As Integer = -1
    Private parentID As Integer = -1
    Private pe As New PublicErrors
    Private LoopLists As New LoopFolders
    Private area As String = ""
    Private actualStartDate As Date
    Private actualFinishDate As Date
    Private lMap As New LoopMap


    Private Sub AddToSaveList(ByVal lf As LoopFolder)
        hasChanged = True
        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        LoopLists.Add(lf)
    End Sub
    Private Function SaveChanges(ByVal dataDate As Date) As Boolean
        Dim dt As New DataTable
        If LoopLists.UpdateDBFromPlanning(Enumerations.UpdateType.UPDATEPROGRESS, dataDate, dt) Then
            MsgBox("Changes have been applied.", MsgBoxStyle.Information, Me.Text)
            Dim frmResult As New frmDataResult("", frmDataResult.en_ResultType.LoopPlanning, dt)
            frmResult.ShowDialog(Me)
        End If
        Return True
    End Function
    Private Sub ClearChanges()
        hasChanged = False
        LoopLists.ClearData()
        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
    End Sub
    Private Sub HandleDataLoaded()
        isDataLoaded = True
    End Sub
    Private Sub CheckAuth()


        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then

            Exit Sub
        End If

        If InStr(Users.userType, "precomm", CompareMethod.Text) > 0 Then

        End If
    End Sub
    Private Sub GetData()
        Application.DoEvents()
        isDataLoaded = False
        taskID = -1
        parentID = -1
        area = ""
        gntControl.DataSource = Nothing
        LoopGant.IniateGant(gntControl)
        gntControl.OptionsCustomization.AllowModifyTasks = DevExpress.Utils.DefaultBoolean.True
        gntControl.OptionsCustomization.AllowModifyProgress = DevExpress.Utils.DefaultBoolean.True
        gntControl.OptionsCustomization.AllowModifyDependencies = DevExpress.Utils.DefaultBoolean.True

        gntControl.Columns("Name").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("Loops").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("Area").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("ItemType").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("SatDone").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("LoopDone").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("SatLateFinishedDate").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("Duration").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
        gntControl.Columns("Sats").OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False
    End Sub
    Private Sub GetSelectedTasksInfo()
        Try
            Dim subsystem As New List(Of String)
            For Each task As LoopTask In LoopGant.GetSelectedTasks(gntControl)
                taskID = task.Id
                parentID = task.ParentId
                lblName.Text = task.Name
                lblType.Text = task.ItemType
                lblDescription.Text = task.Description
                lblVendor.Text = task.Vendors
                lblActualStart.Text = Format(task.StartDate, "dddd, dd-MMMM-yyyy")
                actualStartDate = task.StartDate
                lblActualFinish.Text = Format(task.FinishDate, "dddd, dd-MMMM-yyyy")
                actualFinishDate = task.FinishDate
                lblDuration.Text = DateDiff(DateInterval.Day, task.StartDate, task.FinishDate)
                lblProgress.Text = CInt(Math.Round(task.Progress, 0))
                Select Case task.ItemType
                    Case "Subsystem"
                        subsystem.Add(task.Name)
                End Select
            Next
            grdPred.DataSource = LoopGant.GetPredecessors(gntControl, taskID)
            grdSucc.DataSource = LoopGant.GetSuccessors(gntControl, taskID)
            grd.DataSource = LoopMap.LoopMap(subsystem)
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub GetSelectedTasksInfoMini()
        Try
            For Each task As LoopTask In LoopGant.GetSelectedTasks(gntControl)
                taskID = task.Id
                parentID = task.ParentId
                lblName.Text = task.Name
                lblType.Text = task.ItemType
                lblDescription.Text = task.Description
                lblVendor.Text = task.Vendors
                lblActualStart.Text = Format(task.StartDate, "dddd, dd-MMMM-yyyy")
                actualStartDate = task.StartDate
                lblActualFinish.Text = Format(task.FinishDate, "dddd, dd-MMMM-yyyy")
                actualFinishDate = task.FinishDate
                lblDuration.Text = DateDiff(DateInterval.Day, task.StartDate, task.FinishDate)
                lblProgress.Text = CInt(Math.Round(task.Progress, 0))
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmLoopPlanning_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler LoopPlanning.DataLoaded, AddressOf HandleDataLoaded
        CheckAuth()
        GetData()
        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        btnShowChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        Try
            If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                grdView.ApplyViewLayout(gntControl, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
            ElseIf IO.File.Exists(Application.StartupPath & "\layouts\loop_precomm_planning.xml") Then
                grdView.ApplyViewLayout(gntControl, Application.StartupPath & "\layouts\loop_precomm_planning.xml")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        gntControl.OptionsSplitter.PanelVisibility = DevExpress.XtraGantt.GanttPanelVisibility.Chart
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        gntControl.OptionsSplitter.PanelVisibility = DevExpress.XtraGantt.GanttPanelVisibility.Tree
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        gntControl.OptionsSplitter.PanelVisibility = DevExpress.XtraGantt.GanttPanelVisibility.Both
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        gntControl.OptionsMainTimeRuler.Unit = GanttTimescaleUnit.Month
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        gntControl.OptionsMainTimeRuler.Unit = GanttTimescaleUnit.Day
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        gntControl.OptionsMainTimeRuler.Unit = GanttTimescaleUnit.Quarter
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        gntControl.OptionsMainTimeRuler.Unit = GanttTimescaleUnit.Year
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Loops Planning Filter"
        For inx As Integer = 0 To gntControl.Columns.Count - 1
            frm.cmbSearchIn.Items.Add(gntControl.Columns.Item(inx).FieldName)
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

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        gntControl.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        sveFle.Filter = "Views File|*.xml"
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName <> "" Then
            If grdView.SaveViewLayout(gntControl, sveFle.FileName) Then
                MsgBox("View Has Been Saved", MsgBoxStyle.Information, Me.Text)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, sveFle.FileName)
            End If
        End If
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        Try
            If opnFle.FileName <> "" Then
                'grdView.setViewFromFile(gv, opnFle.FileName)
                grdView.ApplyViewLayout(gntControl, opnFle.FileName)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, opnFle.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim selectedTasks As IList(Of LoopTask) = LoopGant.GetSelectedTasks(gntControl)

        If selectedTasks.Count > 10 Then
            If MsgBox("You have selected more than 10 ILDs to open." & vbCrLf & "Are you sure you want to load (" & selectedTasks.Count & ") ILDs?", vbYesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        For inx As Integer = 0 To selectedTasks.Count - 1
            If selectedTasks.Item(inx).ItemType = "Loop" Then
                Try
                    Dim pdfs As List(Of String)
                    Dim pdfsFName As New List(Of String)
                    pdfs = fs.FindFile(selectedTasks.Item(inx).Name & "*", SharedFolder, pdfsFName)
                    If IsNothing(pdfs) Then
                        MsgBox("No PDF associated to this Loop!", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                    If pdfs.Count = 0 Then
                        MsgBox("No PDF associated to this Loop!", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                    If IO.File.Exists(pdfs.Item(0)) Then
                        Dim frm As New frmPdf() With {.PDFPath = pdfs.Item(0), .Text = selectedTasks.Item(inx).Name}
                        frm.Show()
                    End If
                Catch ex As Exception

                End Try
            End If
        Next

    End Sub


    Private Sub gntControl_TaskProgressModified(sender As Object, e As TaskProgressModifiedEventArgs) Handles gntControl.TaskProgressModified
        Select Case e.ProcessedTask.Node.Item("ItemType")
            Case "Loop"
                AddToSaveList(New LoopFolder(e.ProcessedTask.Node.Item("Name"), e.ProcessedTask.Node.Item("StartDate"), e.ProcessedTask.Node.Item("FinishDate"), e.CurrentProgress, e.ProcessedTask.Node.Item("Vendors"), e.ProcessedTask.Node.Item("Description")))
        End Select
    End Sub

    Private Sub gntControl_TaskDependencyModified(sender As Object, e As TaskDependencyModificationEventArgs) Handles gntControl.TaskDependencyModified
        hasChanged = True
        MsgBox(e.PredecessorTask.Node.Item("Name")) 'First Node
        MsgBox(e.SuccessorTask.Node.Item("Name"))
        MsgBox(e.Type.ToString)
    End Sub

    Private Sub gntControl_TaskFinishDateModified(sender As Object, e As TaskFinishModifiedEventArgs) Handles gntControl.TaskFinishDateModified
        hasChanged = True
        MsgBox(e.ProcessedTask.Node.Item("Name"))
        MsgBox(e.OriginalTaskFinish)
    End Sub

    Private Sub gntControl_TaskMoved(sender As Object, e As TaskMovedEventArgs) Handles gntControl.TaskMoved
        hasChanged = True
        MsgBox(e.ProcessedTask.Node.Item("Name"))
        MsgBox(e.ProcessedTask.ScheduledStartDate)
        MsgBox(e.ProcessedTask.ScheduledFinishDate)
    End Sub

    Private Sub frmLoopPlanning_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
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
                    Dim frmd As New frmConfirmDataChanged
                    frmd.grdPred.DataSource = LoopLists.GetLoopsFoldersForPlanning
                    frmd.Text = "Loop Folders Data Changes"
                    frmd.ShowDialog(Me)
                    Select Case frmd.ActionType
                        Case MsgBoxResult.Cancel
                            e.Cancel = True
                        Case MsgBoxResult.Ignore
                            e.Cancel = False
                            frmMain.MdiChildClosed(Me.Text)
                        Case MsgBoxResult.Ok
                            e.Cancel = Not SaveChanges(frmd.SelectedDate)
                            If Not e.Cancel Then
                                frmMain.MdiChildClosed(Me.Text)
                            End If
                    End Select
                Case Else
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub gntControl_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles gntControl.RowCellClick
        'MsgBox(e.CellValue)
    End Sub


    Private Sub gntControl_SelectionChanged(sender As Object, e As EventArgs) Handles gntControl.SelectionChanged
        If isDataLoaded Then
            GetSelectedTasksInfo()
        End If
    End Sub

    Private Sub btnShowChanges_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowChanges.ItemClick, btnSave.ItemClick
        Dim frmd As New frmConfirmDataChanged
        frmd.grdPred.DataSource = LoopLists.GetLoopsFoldersForPlanning
        frmd.Text = "Loop Folders Data Changes"
        frmd.ShowDialog(Me)
        Select Case frmd.ActionType
            Case MsgBoxResult.Ignore
                ClearChanges()
            Case MsgBoxResult.Ok
                SaveChanges(frmd.SelectedDate)
        End Select
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        gntControl.DataSource.item(11).Name = "koko"
        LoopGant.Refresh(gntControl)
    End Sub

    Private Sub gntControl_EditFormHidden(sender As Object, e As EditFormHiddenEventArgs) Handles gntControl.EditFormHidden
        If e.Result = EditFormResult.Update Then
            GetSelectedTasksInfoMini()
            AddToSaveList(New LoopFolder(lblName.Text, actualStartDate, actualFinishDate, Val(lblProgress.Text), lblVendor.Text, lblDescription.Text))
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Try
            My.Computer.Clipboard.Clear()
            Dim lst As New List(Of String)
            lst = LoopGant.GetSelectedTasks(gntControl, "Subsystem")
            Dim a(lst.Count) As String
            lst.CopyTo(a, 0)
            Dim tabbedText = String.Join(ControlChars.CrLf, a)
            If tabbedText <> "" Then My.Computer.Clipboard.SetText(tabbedText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Try
            My.Computer.Clipboard.Clear()
            Dim lst As New List(Of String)
            lst = LoopGant.GetSelectedTasks(gntControl, "Loop")
            Dim a(lst.Count) As String
            lst.CopyTo(a, 0)
            Dim tabbedText = String.Join(ControlChars.CrLf, a)
            If tabbedText <> "" Then My.Computer.Clipboard.SetText(tabbedText)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Subsystem Pending ITems"
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

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            grd.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub
End Class