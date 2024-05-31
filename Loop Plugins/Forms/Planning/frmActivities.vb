Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns


Public Class frmActivities
    Private Acts As New Activities
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False


    Private Sub ShowRadialMenu()
        ' Display Radial Menu
        If rMenu Is Nothing Then
            Return
        End If
        Dim pt As Point = Me.Location
        pt.Offset(Me.Width \ 2, Me.Height \ 2)
        rMenu.ShowPopup(pt)
    End Sub
    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles grd.KeyDown
        Select Case e.KeyCode
            Case Keys.Space
                ShowRadialMenu()
        End Select
    End Sub
    Private Sub CheckAuth()

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
    Private Sub GetData()
        saveColumnsWidth()
        grd.DataSource = Acts.GetItems(Construction.ItemsTypes.ACTIVITIES)
        formatColumnsWidth()

        gv.OptionsSelection.MultiSelect = True

        gv.Columns("PCS Budget").AppearanceCell.BackColor = Color.FromArgb(182, 173, 144)
        gv.Columns("EICA Budget").AppearanceCell.BackColor = Color.FromArgb(194, 197, 170)
        gv.Columns("Done").AppearanceCell.BackColor = Color.FromArgb(164, 172, 134)
        gv.Columns("Id").Visible = False

        gv.BestFitColumns()

        'Filter
        Filter()

        gv.BestFitColumns(True)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub frmActivities_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
        Try
            If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Activities Filter"
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

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
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
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim frm As New frmUpdateActWithPCS
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            GetData()
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        sveFle.Filter = "Views File|*.xml"
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName <> "" Then
            If grdView.SaveViewLayout(gv, sveFle.FileName) Then
                MsgBox("View Has Been Saved", MsgBoxStyle.Information, Me.Text)
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
        Dim frm As New frmAddActivity
        frm.ShowDialog(Me)
        If frm.isAdded Then
            GetData()
        End If
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If gv.GetSelectedRows.Count = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        If row_handle < 0 Then Exit Sub
        Dim ActId As String = gv.GetDataRow(row_handle).Item("ActID")
        Dim ActName As String = gv.GetDataRow(row_handle).Item("ActName")
        Dim PCS_Area As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("PCS Area")), "", gv.GetDataRow(row_handle).Item("PCS Area"))
        Dim SubCon As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("SubCon")), "", gv.GetDataRow(row_handle).Item("SubCon"))
        Dim PCS_Budget As Double = If(IsDBNull(gv.GetDataRow(row_handle).Item("PCS Budget")), 0, gv.GetDataRow(row_handle).Item("PCS Budget"))
        Dim Family As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("Family")), "", gv.GetDataRow(row_handle).Item("Family"))
        Dim EICA_Area As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("EICA Area")), "", gv.GetDataRow(row_handle).Item("EICA Area"))
        Dim EICA_Budget As Double = If(IsDBNull(gv.GetDataRow(row_handle).Item("EICA Budget")), 0, gv.GetDataRow(row_handle).Item("EICA Budget"))
        Dim Package As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("Package")), "", gv.GetDataRow(row_handle).Item("Package"))
        Dim KeyQnty As Byte = If(IsDBNull(gv.GetDataRow(row_handle).Item("KeyQnty")), 0, gv.GetDataRow(row_handle).Item("KeyQnty"))
        Dim wps As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("wps")), "", gv.GetDataRow(row_handle).Item("wps"))
        Dim ResourceId As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("ResourceId")), "", gv.GetDataRow(row_handle).Item("ResourceId"))
        Dim ResourceName As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("ResourceName")), "", gv.GetDataRow(row_handle).Item("ResourceName"))
        Dim Location As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("Location")), "", gv.GetDataRow(row_handle).Item("Location"))
        Dim StartDate As Date = If(IsDBNull(gv.GetDataRow(row_handle).Item("StartDate")), Now, gv.GetDataRow(row_handle).Item("StartDate"))
        Dim EndDate As Date = If(IsDBNull(gv.GetDataRow(row_handle).Item("EndDate")), Now, gv.GetDataRow(row_handle).Item("EndDate"))
        Dim UOM As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("UOM")), "", gv.GetDataRow(row_handle).Item("UOM"))
        Dim Team As String = If(IsDBNull(gv.GetDataRow(row_handle).Item("Team")), "", gv.GetDataRow(row_handle).Item("Team"))

        Dim frm As New frmAddActivity
        frm.txtEICABudget.Text = EICA_Budget
        frm.txtFamily.Text = Family
        frm.txtLocation.Text = Location
        frm.txtPackage.Text = Package
        frm.txtEICABudget.Text = EICA_Budget
        frm.txtPCSArea.Text = PCS_Area
        frm.txtPCSBudget.Text = PCS_Budget
        frm.txtResourceId.Text = ResourceId
        frm.txtResourceName.Text = ResourceName
        frm.txtSubcon.Text = SubCon
        frm.txtTeam.Text = Team
        frm.txtUOM.Text = UOM
        frm.txtWPS.Text = wps
        frm.dteEndDate.Value = EndDate
        frm.dteStartDate.Value = StartDate
        frm.txtActName.Text = ActName
        frm.txtActId.Text = ActId
        frm.EICAArea = EICA_Area

        frm.chkKeyQnty.Checked = gv.GetDataRow(row_handle).Item("KeyQnty")
        frm.ShowDialog(Me)
        If frm.isAdded Then
            GetData()
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        grdView.CopySelectedItems(gv, "ActID")
    End Sub

    Private Sub frmActivities_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    'Private Sub gv_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv.CustomDrawCell
    '    If e.Column.FieldName = "Status" Then
    '        If Not IsDBNull(e.CellValue) Then
    '            If e.CellValue = "DELETED" Then
    '                e.Cache.FillEllipse(Convert.ToSingle(e.Bounds.X + e.Bounds.Height / 2), e.Bounds.Y + 3, e.Bounds.Height - 5, e.Bounds.Height - 5, Color.Red)
    '                'e.Cache.FillRectangle(Color.Salmon, e.Bounds)
    '                e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)
    '                e.Handled = True
    '            End If
    '        End If
    '    End If
    'End Sub


End Class