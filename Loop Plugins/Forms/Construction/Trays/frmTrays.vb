Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class frmTrays
    Private tray As New Trays
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False
    Private docImage As Image = Image.FromFile(Application.StartupPath & "\res\doc12.png")

    Private Sub CheckAuth()
        rpProduction.Visible = False
        rpEngineering.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            rpEngineering.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "construction", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
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
        grd.DataSource = tray.GetItems(Construction.ItemsTypes.TRAYS)
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Last Update").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Percentage").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Id").Visible = False
        gv.Columns("Resource").Visible = False

        gv.OptionsSelection.MultiSelect = True

        'conditional format
        ConditionalFormat()

        'Filter
        Filter()

        gv.BestFitColumns(True)

    End Sub

    Private Sub frmTrays_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
        Try
            If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        getData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Trays Filter"
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
            sveFle.Filter = "Excel File|*.xlsx"
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
        If gv.RowCount = 0 Then Exit Sub
        If gv.GetSelectedRows.Length = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        Dim itemId As Integer = gv.GetDataRow(row_handle).Item("Id")
        Dim groupId As ResourcesMan.GROUPID = If(gv.GetDataRow(row_handle).Item("Discipline") = "Electrical", ResourcesMan.GROUPID.ElectricalTray, ResourcesMan.GROUPID.InstrumentTray)
        Dim frm As New frmItemResource(itemId, groupId)
        frm.lblItem.Text = "Tag: " & gv.GetDataRow(row_handle).Item("Tag") & vbTab & "Discipline: " & gv.GetDataRow(row_handle).Item("Discipline")
        frm.Show()
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim frm As New frmSelectResource
        Dim res As New ResourcesMan
        frm.ShowDialog(Me)
        If frm.IsSelected Then
            For Each row_handle As Integer In gv.GetSelectedRows
                For inx As Integer = 1 To frm.ResId.Count
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        Dim unused = res.Assign(frm.ResId.Item(inx), gv.GetDataRow(row_handle).Item("Id"), ResourcesMan.GROUPID.ElectricalTray)
                    Else
                        Dim unused = res.Assign(frm.ResId.Item(inx), gv.GetDataRow(row_handle).Item("Id"), ResourcesMan.GROUPID.InstrumentTray)
                    End If
                Next
            Next
            Dim msgR As MsgBoxResult = MsgBox("Resource Has Been Assigned.", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Clear All Resources For All {0}{1} Selected Trays?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim res As ResourcesManItem, itemId As Integer = 0, groupId As ResourcesManItem.GROUPID = ResourcesMan.GROUPID.ElecatricalCable
        For Each row_handle As Integer In gv.GetSelectedRows
            itemId = gv.GetDataRow(row_handle).Item("Id")
            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                groupId = ResourcesMan.GROUPID.ElectricalTray
            Else
                groupId = ResourcesMan.GROUPID.InstrumentTray
            End If
            res = New ResourcesManItem(itemId, groupId)
            res.ClearResources()
        Next
        MsgBox("Resource Has Been Cleared.", MsgBoxStyle.Information, Me.Text)
    End Sub
    Private Sub gv_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv.CustomDrawCell
        If e.Column.FieldName = "Tag" Then
            If ((e.RowHandle >= 0) AndAlso (gv.GetDataRow(e.RowHandle).Item("Resource") = "Yes")) Then
                Dim p As New Point(e.Bounds.Width + e.Bounds.X - 12, e.Bounds.Y + 3)
                e.DefaultDraw()
                e.Cache.DrawImage(docImage, p)
            End If
        End If
    End Sub
End Class