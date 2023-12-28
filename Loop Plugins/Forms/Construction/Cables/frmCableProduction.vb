Imports System.ComponentModel
Imports DevExpress.Data
Imports DevExpress.Internal.WinApi.Windows.UI.Notifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Public Class frmCableProduction
    Private cable As New Cables
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False

    Private Sub CheckAuth()
        rpProduction.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "production", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
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
            'formatConditionRuleExpression.PredefinedName = "Gray Fill"
            formatConditionRuleExpression.Expression = "[Percentage] = 100"
            formatConditionRuleExpression.Appearance.BackColor = Color.LightGray
            formatConditionRuleExpression.Appearance.ForeColor = Color.Black
            gridFormatRule.Rule = formatConditionRuleExpression
            gv.FormatRules.Add(gridFormatRule)
            StandardRulesAdded = True
        End If
    End Sub
    Private Sub gridSummary()
        Dim si(5) As GridColumnSummaryItem

        gv.Columns("Tag").Summary.Clear()
        si(0) = New GridColumnSummaryItem() With {.SummaryType = SummaryItemType.Count, .FieldName = "Tag", .DisplayFormat = "Count: {0:n0}"}
        gv.Columns("Tag").Summary.Add(si(0))

        gv.Columns("Percentage").Summary.Clear()
        si(1) = New GridColumnSummaryItem() With {.SummaryType = SummaryItemType.Sum, .FieldName = "Percentage", .DisplayFormat = "Sum: {0:n0}"}
        gv.Columns("Percentage").Summary.Add(si(1))
        si(5) = New GridColumnSummaryItem() With {.SummaryType = SummaryItemType.Average, .FieldName = "Percentage", .DisplayFormat = "Avg: {0:n0}"}
        gv.Columns("Percentage").Summary.Add(si(5))

        gv.Columns("Actual Length").Summary.Clear()
        si(2) = New GridColumnSummaryItem() With {.SummaryType = SummaryItemType.Sum, .FieldName = "Actual Length", .DisplayFormat = "Sum: {0:n0}"}
        gv.Columns("Actual Length").Summary.Add(si(2))

        gv.Columns("Pulled Date").Summary.Clear()
        si(3) = New GridColumnSummaryItem() With {.SummaryType = SummaryItemType.Min, .FieldName = "Pulled Date", .DisplayFormat = "Min: {0:dddd, dd-MMM-yyyy}"}
        gv.Columns("Pulled Date").Summary.Add(si(3))
        si(4) = New GridColumnSummaryItem() With {.SummaryType = SummaryItemType.Max, .FieldName = "Pulled Date", .DisplayFormat = "Max: {0:dddd, dd-MMM-yyyy}"}
        gv.Columns("Pulled Date").Summary.Add(si(4))
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
        grd.DataSource = cable.GetItems(Construction.ItemsTypes.CABLESPRODUCTION)
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Pulled Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Percentage").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        gv.Columns("Mark 1 To").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        gv.Columns("Mark 1 From").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)

        gv.Columns("Actual Length").AppearanceCell.BackColor = Color.LightGray
        gv.Columns("Id").Visible = False


        gv.OptionsSelection.MultiSelect = True

        'conditional format
        'ConditionalFormat()

        'Filter
        Filter()

        'Summaries
        gridSummary()
        gv.BestFitColumns(True)

    End Sub

    Private Sub frmCableProduction_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
        Try
            If FileIO.FileSystem.FileExists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Delete All {0}{1} Selected Production?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        For Each row_handle As Integer In gv.GetSelectedRows
            cable.DeleteProduction(gv.GetDataRow(row_handle).Item("Id"), gv.GetDataRow(row_handle).Item("Discipline"))
        Next
        msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        getData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Cables Production Filter"
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
            grd.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
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

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If MsgBox(String.Format("Do You Want To Edit Selected Production Item?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        If row_handle < 0 Then Exit Sub
        Dim frm As New frmEditCableProduction
        frm.lblOtherPercentage.Text = cable.OtherCablePercentage(gv.GetDataRow(row_handle).Item("Id"), gv.GetDataRow(row_handle).Item("Discipline"), gv.GetDataRow(row_handle).Item("Tag"))
        frm.lblTag.Text = gv.GetDataRow(row_handle).Item("Tag") & " (" & gv.GetDataRow(row_handle).Item("Discipline") & ")"
        frm.txtPercentage.Text = gv.GetDataRow(row_handle).Item("Percentage")
        frm.OldPercentage = Val(gv.GetDataRow(row_handle).Item("Percentage"))
        frm.lblDate.Text = gv.GetDataRow(row_handle).Item("Pulled Date")
        frm.dteEdit.EditValue = gv.GetDataRow(row_handle).Item("Pulled Date")
        frm.txtMark1From.EditValue = gv.GetDataRow(row_handle).Item("Mark 1 From")
        frm.txtMark1To.EditValue = gv.GetDataRow(row_handle).Item("Mark 1 To")
        frm.Discipline = gv.GetDataRow(row_handle).Item("Discipline")
        frm.Id = gv.GetDataRow(row_handle).Item("Id")
        frm.OldMark1From = gv.GetDataRow(row_handle).Item("Mark 1 From")
        frm.OldMark1To = gv.GetDataRow(row_handle).Item("Mark 1 To")
        frm.txtActualDrum.Text = If(Not IsDBNull(gv.GetDataRow(row_handle).Item("Actual Drum")), gv.GetDataRow(row_handle).Item("Actual Drum"), "")
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            getData()
        End If
    End Sub

    Private Sub frmCableProduction_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class