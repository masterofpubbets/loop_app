Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class frmInstruments
    Private ins As New Instruments
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False
    Private _IsFullView As Boolean = False
    Private docImage As Image = Image.FromFile(Application.StartupPath & "\res\doc12.png")

    Public Sub New(Optional ByVal isFullView As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _IsFullView = isFullView
    End Sub

    Private Sub CheckAuth()
        rpProduction.Visible = False
        rpQC.Visible = False
        rpPlanning.Visible = False
        rpProductionControl.Visible = False
        rpEngineering.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            rpPlanning.Visible = True
            rpQC.Visible = True
            rpProductionControl.Visible = True
            rpEngineering.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "construction", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            rpQC.Visible = True
        End If
        If InStr(Users.userType, "planning", CompareMethod.Text) > 0 Then
            rpPlanning.Visible = True
        End If
        If InStr(Users.userType, "Production", CompareMethod.Text) > 0 Then
            rpProductionControl.Visible = True
        End If
        If InStr(Users.userType, "engineer", CompareMethod.Text) > 0 Then
            rpEngineering.Visible = True
        End If
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
            formatConditionRuleExpression.Expression = "[Status] = 'DELETED'"
            gridFormatRule.Rule = formatConditionRuleExpression
            gv.FormatRules.Add(gridFormatRule)
            StandardRulesAdded = True
        End If
    End Sub
    Private Sub Filter()
        Try
            If _filter <> "" Then
                gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub getData()
        saveColumnsWidth()
        If _IsFullView Then
            grd.DataSource = ins.GetItems(Construction.ItemsTypes.INSTRUMENTSFULL)
        Else
            grd.DataSource = ins.GetItems(Construction.ItemsTypes.INSTRUMENTS)
        End If
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Calibration Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Installation Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Hookup Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        gv.Columns("Id").Visible = False
        If _IsFullView Then gv.Columns("Resource").Visible = False

        gv.OptionsSelection.MultiSelect = True

        'conditional format=
        ConditionalFormat()

        'Filter
        Filter()

        gv.BestFitColumns(True)

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        getData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Instruments Filter"
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

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
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

    Private Sub frmInstruments_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
        Try
            If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
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

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        Try
            If opnFle.FileName <> "" Then
                grdView.ApplyViewLayout(gv, opnFle.FileName)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, opnFle.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Me.MdiParent = Nothing
    End Sub
    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as QC Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSetQCReleased
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.ClearInstalledQCReleased(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetInstalledQCReleased(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, frm.selectedRFI)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as QC Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSetQCReleased
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.ClearCalibrationQCReleased(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetCalibrationQCReleased(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, frm.selectedRFI)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        Dim fs As New FileSystem
        For Each row_handle As Integer In gv.GetSelectedRows
            If Not IsDBNull(gv.GetDataRow(row_handle).Item("RFINumberInstallation")) Then
                fs.OpenFile(gv.GetDataRow(row_handle).Item("RFINumberInstallation") & ".pdf", RFIPath)
            End If
        Next
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim fs As New FileSystem
        For Each row_handle As Integer In gv.GetSelectedRows
            If Not IsDBNull(gv.GetDataRow(row_handle).Item("RFINumberCalibration")) Then
                fs.OpenFile(gv.GetDataRow(row_handle).Item("RFINumberCalibration") & ".pdf", RFIPath)
            End If
        Next
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as QC Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSetQCReleased
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.ClearHookupQCReleased(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetHookupQCReleased(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, frm.selectedRFI)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Dim fs As New FileSystem
        For Each row_handle As Integer In gv.GetSelectedRows
            If Not IsDBNull(gv.GetDataRow(row_handle).Item("RFINumberHookup")) Then
                fs.OpenFile(gv.GetDataRow(row_handle).Item("RFINumberHookup") & ".pdf", RFIPath)
            End If
        Next
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Installed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then

            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetInstalled(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Calibrated?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then

            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetCalibrated(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Hookup?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then

            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetHookup(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Change Team for All {0}{1} Selected Instruments?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmEditText With {.Text = "Change Team"}
        frm.lblTitle.Text = "Please type the New value"
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateTeam(Activities.Discipline.Ins, gv.GetDataRow(row_handle).Item("Tag"), frm.newValye)
            Next
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If MsgBox("Do you want to change Installation Activity ID for selected Instruments?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        If MsgBox("Do you want to change Calibration Activity ID for selected Instruments?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Calib, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        If MsgBox("Do you want to change Hookup Activity ID for selected Instruments?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Hook, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        If MsgBox("Do you want to Clear Installation Activity ID for selected Instrument?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), "")
        Next
        getData()
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        If MsgBox("Do you want to Clear Calibration Activity ID for selected Instrument?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Calib, gv.GetDataRow(row_handle).Item("Tag"), "")
        Next
        getData()
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        If MsgBox("Do you want to Clear Hookup Activity ID for selected Instrument?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Hook, gv.GetDataRow(row_handle).Item("Tag"), "")
        Next
        getData()
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        If MsgBox("Do you want to change Installation Activity ID for selected Instrument?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Ins, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                act.UpdateArea(Activities.Discipline.Ins, gv.GetDataRow(row_handle).Item("Tag"), frm.Area)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Calibrated?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.ClearCalibrated(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetCalibrated(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, 1)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Installed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.ClearInstalled(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetInstalled(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, 1)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Hookup?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.ClearHookup(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    ins.SetHookup(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, 1)
                Next
            End If
            msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem32_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Include All {0}{1} In Penumatic Scope?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.SetHookupName(gv.GetDataRow(row_handle).Item("Tag"), "Penumatic")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem33_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Include All {0}{1} In Process Scope?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.SetHookupName(gv.GetDataRow(row_handle).Item("Tag"), "Process")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem34_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem34.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Remove All {0}{1} From Hookup Scope?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.SetHookupName(gv.GetDataRow(row_handle).Item("Tag"), "NULL")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Include All {0}{1} in Calibration Scope?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.SetCalibrationScope(gv.GetDataRow(row_handle).Item("Tag"))
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem31_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Remove All {0}{1} From Calibration Scope?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.RemoveCalibrationScope(gv.GetDataRow(row_handle).Item("Tag"))
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem35_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want Set All {0}{1} As Device?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.RemoveInstallationScope(gv.GetDataRow(row_handle).Item("Tag"), "Instrument")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem36_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem36.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want Set All {0}{1} As Accessory?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.RemoveInstallationScope(gv.GetDataRow(row_handle).Item("Tag"), "Accessory")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem37_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem37.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want Set All {0}{1} As Fire and Gas?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.RemoveInstallationScope(gv.GetDataRow(row_handle).Item("Tag"), "F&G")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want Set All {0}{1} As Signal?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            ins.RemoveInstallationScope(gv.GetDataRow(row_handle).Item("Tag"), "Signal")
        Next
        msgR = MsgBox(String.Format("Instruments Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem39_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        Dim frm As New frmSelectResource
        Dim res As New ResourcesMan
        frm.ShowDialog(Me)
        If frm.IsSelected Then
            For Each row_handle As Integer In gv.GetSelectedRows
                For inx As Integer = 1 To frm.ResId.Count
                    Dim unused = res.Assign(frm.ResId.Item(inx), gv.GetDataRow(row_handle).Item("Id"), ResourcesMan.GROUPID.Instrument)
                Next
            Next
            Dim msgR As MsgBoxResult = MsgBox("Resource Has Been Assigned.", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub BarButtonItem40_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Clear All Resources For All {0}{1} Selected Instruments?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim res As ResourcesManItem, itemId As Integer = 0, groupId As ResourcesManItem.GROUPID = ResourcesMan.GROUPID.ElecatricalCable
        For Each row_handle As Integer In gv.GetSelectedRows
            itemId = gv.GetDataRow(row_handle).Item("Id")
            groupId = ResourcesMan.GROUPID.Instrument
            res = New ResourcesManItem(itemId, groupId)
            res.ClearResources()
        Next
        MsgBox("Resource Has Been Cleared.", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub BarButtonItem41_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        If gv.RowCount = 0 Then Exit Sub
        If gv.GetSelectedRows.Length = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        Dim itemId As Integer = gv.GetDataRow(row_handle).Item("Id")
        Dim groupId As ResourcesMan.GROUPID = ResourcesMan.GROUPID.Instrument
        Dim frm As New frmItemResource(itemId, groupId)
        frm.lblItem.Text = "Tag: " & gv.GetDataRow(row_handle).Item("Tag") & vbTab & "Discipline: Instruments"
        frm.Show()
    End Sub

    Private Sub gv_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv.CustomDrawCell
        If _IsFullView Then
            If e.Column.FieldName = "Tag" Then
                If ((e.RowHandle >= 0) AndAlso (gv.GetDataRow(e.RowHandle).Item("Resource") = "Yes")) Then
                    Dim p As New Point(e.Bounds.Width + e.Bounds.X - 12, e.Bounds.Y + 3)
                    e.DefaultDraw()
                    e.Cache.DrawImage(docImage, p)
                End If
            End If
        End If
    End Sub

End Class