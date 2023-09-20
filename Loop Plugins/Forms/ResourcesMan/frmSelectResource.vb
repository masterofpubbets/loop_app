Imports DevExpress.Internal.WinApi.Windows.UI.Notifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Public Class frmSelectResource
    Private res As New ResourcesMan
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False
    Public IsSelected As Boolean = False
    Public ResId As New Collection

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
    Private Sub getData()
        saveColumnsWidth()
        grd.DataSource = res.GetResources()
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Resources Name").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        gv.OptionsSelection.MultiSelect = True

        'conditional format
        'ConditionalFormat()

        'Filter
        Filter()

        gv.BestFitColumns(True)

    End Sub

    Private Sub frmSelectResource_Load(sender As Object, e As EventArgs) Handles Me.Load
        getData()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim frm As New frmAddResource
        frm.ShowDialog(Me)
        If frm.IsAdded Then
            getData()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        For Each row_handle As Integer In gv.GetSelectedRows
            res.ShowResource(gv.GetDataRow(row_handle).Item("Id"))
        Next
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If gv.RowCount > 0 Then
            If gv.GetSelectedRows.Length > 0 Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    ResId.Add(gv.GetDataRow(row_handle).Item("Id"))
                Next
                IsSelected = True
                Me.Close()
            End If
        End If
    End Sub
End Class