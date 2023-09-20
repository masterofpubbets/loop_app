Imports DevExpress.Internal.WinApi.Windows.UI.Notifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Public Class frmItemResource
    Private res As ResourcesManItem
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False
    Public IsSelected As Boolean = False
    Private _itemId As Integer = 0
    Private _groupId As Integer = 0

    Public Sub New(ByVal itemId As Integer, ByVal groupId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _itemId = itemId
        _groupId = groupId
        res = New ResourcesManItem(itemId, groupId)
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub
    Private Sub CheckAuth()
        btnAssign.Visible = False
        btnDelete.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            btnAssign.Visible = True
            btnDelete.Visible = True
            Exit Sub
        End If

        If InStr(Users.userType, "engineer", CompareMethod.Text) > 0 Then
            btnAssign.Visible = True
            btnDelete.Visible = True
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

    Private Sub frmItemResource_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        For Each row_handle As Integer In gv.GetSelectedRows
            res.ShowResource(gv.GetDataRow(row_handle).Item("ResId"))
        Next
    End Sub

    Private Sub btnAssign_Click(sender As Object, e As EventArgs) Handles btnAssign.Click
        Dim frm As New frmSelectResource
        Dim res As New ResourcesMan
        frm.ShowDialog(Me)
        If frm.IsSelected Then
            For inx As Integer = 1 To frm.ResId.Count
                Dim unused = res.Assign(frm.ResId.Item(inx), _itemId, _groupId)
            Next
            getData()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Unassign All {0}{1} Selected Resources?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        For Each row_handle As Integer In gv.GetSelectedRows
            res.DeleteResource(gv.GetDataRow(row_handle).Item("Id"))
        Next
        getData()
    End Sub
End Class