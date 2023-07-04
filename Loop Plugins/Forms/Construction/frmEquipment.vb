Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Public Class frmEquipment
    Private eq As New Equipment
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False

    Private Sub CheckAuth()
        rpProduction.Visible = False
        rpPlanning.Visible = False
        rpQC.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            rpQC.Visible = True
            rpPlanning.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "construction", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
        End If
        If InStr(Users.userType, "planning", CompareMethod.Text) > 0 Then
            rpPlanning.Visible = True
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            rpQC.Visible = True
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
        grd.DataSource = eq.GetItems(Construction.ItemsTypes.EQUIPMENT)
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Installed Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)


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
        frm.Text = "Equipment Filter"
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

    Private Sub frmEquipment_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
        If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
            grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
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
                grdView.ApplyViewLayout(gv, opnFle.FileName)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, opnFle.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If MsgBox("Do you want to change Pulling Activity ID for selected Equipment?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Equipment, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Installed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    eq.ClearInstalled(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    eq.SetInstalled(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                Next
            End If
            msgR = MsgBox(String.Format("Equipment Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If MsgBox("Do you want to change Pulling Activity ID for selected Equipment?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Equipment, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                act.UpdateArea(Activities.Discipline.Equipment, gv.GetDataRow(row_handle).Item("Tag"), frm.Area)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as QC Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSetQCReleased
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    eq.ClearQCReleased(gv.GetDataRow(row_handle).Item("Tag"))
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    eq.SetQCReleased(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, frm.selectedRFI)
                Next
            End If
            msgR = MsgBox(String.Format("Equipment Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim fs As New FileSystem
        For Each row_handle As Integer In gv.GetSelectedRows
            If Not IsDBNull(gv.GetDataRow(row_handle).Item("RFINumber")) Then
                fs.OpenFile(gv.GetDataRow(row_handle).Item("RFINumber") & ".pdf", RFIPath)
            End If
        Next
    End Sub
End Class