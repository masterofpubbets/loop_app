﻿Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Public Class frmInstruments
    Private ins As New Instruments
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False

    Private Sub CheckAuth()
        rpProduction.Visible = False
        rpQC.Visible = False
        rpPlanning.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            rpPlanning.Visible = True
            rpQC.Visible = True
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
        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
    End Sub
    Private Sub getData()
        saveColumnsWidth()
        grd.DataSource = ins.GetItems(Construction.ItemsTypes.INSTRUMENTS)
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Calibration Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Installation Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Hookup Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)


        gv.OptionsSelection.MultiSelect = True

        'conditional format
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
        If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
            grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
        End If
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
End Class