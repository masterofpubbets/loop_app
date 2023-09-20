Imports DevExpress.Internal.WinApi.Windows.UI.Notifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class frmCables
    Private cable As New Cables
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private viewType As Boolean = False
    Private StandardRulesAdded As Boolean = False
    Private docImage As Image = Image.FromFile(Application.StartupPath & "\res\doc12.png")

    Public Sub New(Optional ByVal ShowFullDetails As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        viewType = ShowFullDetails
        If ShowFullDetails Then
            Me.Text &= " (Full View)"
        Else
            Me.Text &= " (Simple View)"
        End If
    End Sub
    Private Sub CheckAuth()
        rpProduction.Visible = False
        rpQC.Visible = False
        rpPlanning.Visible = False
        rpEngineering.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            rpQC.Visible = True
            rpPlanning.Visible = True
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
        If viewType Then
            grd.DataSource = cable.GetItems(Construction.ItemsTypes.CABLESFULL)
        Else
            grd.DataSource = cable.GetItems(Construction.ItemsTypes.CABLES)
        End If
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Pulled Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("TotalPercentage").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Pulled Lm").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Con From Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Con To Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Test Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("QC Released Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        gv.Columns("Pulling Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        gv.Columns("Gland From Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        gv.Columns("Gland To Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        gv.Columns("Conn From Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)
        gv.Columns("Conn To Workfront").AppearanceCell.BackColor = Color.FromArgb(142, 202, 230)

        gv.Columns("Id").Visible = False
        If viewType Then gv.Columns("Resource").Visible = False

        gv.OptionsSelection.MultiSelect = True

        'conditional format
        ConditionalFormat()

        'Filter
        Filter()

        gv.BestFitColumns(True)

    End Sub

    Private Sub frmCables_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        frm.Text = "Cables Filter"
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

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
    End Sub
    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as QC Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSetQCReleased
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        cable.ClearQCReleased(gv.GetDataRow(row_handle).Item("Tag"))
                    Else
                        cable.ClearICQCReleased(gv.GetDataRow(row_handle).Item("Tag"))
                    End If
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        cable.SetQCReleased(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, 0, gv.GetDataRow(row_handle).Item("Length"), frm.selectedRFI)
                    Else
                        cable.SetICQCReleased(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate, 0, gv.GetDataRow(row_handle).Item("Length"), frm.selectedRFI)
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
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

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
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
    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        If MsgBox("Do you want to change Pulling Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            'change act id here
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                    act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                Else
                    act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                End If
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        If MsgBox("Do you want to change Pulling Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            'change act id here
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                    act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                    act.UpdateArea(Activities.Discipline.EleCable, gv.GetDataRow(row_handle).Item("Tag"), frm.Area)
                Else
                    act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                    act.UpdateArea(Activities.Discipline.InsCable, gv.GetDataRow(row_handle).Item("Tag"), frm.Area)
                End If
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        If MsgBox("Do you want to clear Pulling Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        'change act id here
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), "")
            Else
                act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), "")
            End If
        Next
        getData()
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        If MsgBox("Do you want to change Conn From Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            'change act id here
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                    act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                Else
                    act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                End If
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        If MsgBox("Do you want to clear Conn From Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        'change act id here
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"), "")
            Else
                act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"), "")
            End If
        Next
        getData()
    End Sub

    Private Sub BarButtonItem31_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        If MsgBox("Do you want to change Conn To Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            'change act id here
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                    act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                Else
                    act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                End If
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem32_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        If MsgBox("Do you want to clear Conn To Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        'change act id here
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"), "")
            Else
                act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"), "")
            End If
        Next
        getData()
    End Sub

    Private Sub BarButtonItem33_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        If MsgBox("Do you want to change Test Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            'change act id here
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                    act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Test, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                Else
                    act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Test, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                End If
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem34_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem34.ItemClick
        If MsgBox("Do you want to clear Test Activity ID for selected cables?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        'change act id here
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                act.UpdateActIds(Activities.Discipline.EleCable, Activities.Keys.Test, gv.GetDataRow(row_handle).Item("Tag"), "")
            Else
                act.UpdateActIds(Activities.Discipline.InsCable, Activities.Keys.Test, gv.GetDataRow(row_handle).Item("Tag"), "")
            End If
        Next
        getData()
    End Sub

    Private Sub BarButtonItem35_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To update All {0}{1} Selected for Pulling Workfront?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim act As New Activities
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"))
                    Else
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"))
                    End If
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    Else
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.Pulling, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Workfront Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem36_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem36.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To update All {0}{1} Selected for Gland From Workfront?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim act As New Activities
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandFrom, gv.GetDataRow(row_handle).Item("Tag"))
                    Else
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandFrom, gv.GetDataRow(row_handle).Item("Tag"))
                    End If
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandFrom, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    Else
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandFrom, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Workfront Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem37_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem37.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To update All {0}{1} Selected for Gland To Workfront?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim act As New Activities
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandTo, gv.GetDataRow(row_handle).Item("Tag"))
                    Else
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandTo, gv.GetDataRow(row_handle).Item("Tag"))
                    End If
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandTo, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    Else
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.GlandTo, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Workfront Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To update All {0}{1} Selected for Connect From Workfront?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim act As New Activities
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"))
                    Else
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"))
                    End If
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    Else
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn1, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Workfront Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem39_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To update All {0}{1} Selected for Connect To Workfront?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim act As New Activities
            If frm.isCleared Then
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"))
                    Else
                        act.ClearWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"))
                    End If
                Next
            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    Else
                        act.SetWorkfront(Activities.Discipline.EleCable, Activities.Keys.Conn2, gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Workfront Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Change Discipline for All {0}{1} Selected Cables?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim pullinActId As String = ""
        Dim conFromActId As String = ""
        Dim conToActId As String = ""
        Dim testActId As String = ""

        Dim frm As New frmEditText
        frm.lblTitle.Text = "New Cable Type"
        frm.Text = "Change Cable Discipline"
        frm.ShowDialog(Me)

        For Each row_handle As Integer In gv.GetSelectedRows
            pullinActId = If(IsDBNull(gv.GetDataRow(row_handle).Item("Pulling ActId")), "", gv.GetDataRow(row_handle).Item("Pulling ActId"))
            conFromActId = If(IsDBNull(gv.GetDataRow(row_handle).Item("Con From ActId")), "", gv.GetDataRow(row_handle).Item("Con From ActId"))
            conToActId = If(IsDBNull(gv.GetDataRow(row_handle).Item("Con To ActId")), "", gv.GetDataRow(row_handle).Item("Con To ActId"))
            testActId = If(IsDBNull(gv.GetDataRow(row_handle).Item("Test ActId")), "", gv.GetDataRow(row_handle).Item("Con To ActId"))

            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                cable.MoveECIC(gv.GetDataRow(row_handle).Item("Tag"), pullinActId, conFromActId, conToActId, testActId, frm.newValye)
            Else
                cable.MoveICEC(gv.GetDataRow(row_handle).Item("Tag"), pullinActId, conFromActId, conToActId, testActId, frm.newValye)
            End If
        Next
        msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Change Routing for All {0}{1} Selected Cables?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmEditText With {.Text = "Change Cable Routing"}
        frm.lblTitle.Text = "Please type the Routing value"
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            For Each row_handle As Integer In gv.GetSelectedRows
                cable.ChangeRouting(gv.GetDataRow(row_handle).Item("Tag"), gv.GetDataRow(row_handle).Item("Discipline"), frm.newValye)
            Next
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Change Type for All {0}{1} Selected Cables?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmEditText With {.Text = "Change Cable Type"}
        frm.lblTitle.Text = "Please type the New value"
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            For Each row_handle As Integer In gv.GetSelectedRows
                cable.ChangeType(gv.GetDataRow(row_handle).Item("Tag"), gv.GetDataRow(row_handle).Item("Discipline"), frm.newValye)
            Next
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Pulled?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            If frm.isCleared Then

            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        cable.SetPulled(gv.GetDataRow(row_handle).Item("Tag"), 100, frm.selectedDate, 0, gv.GetDataRow(row_handle).Item("Length"))
                    Else
                        cable.SetICPulled(gv.GetDataRow(row_handle).Item("Tag"), 100, frm.selectedDate, 0, gv.GetDataRow(row_handle).Item("Length"))
                    End If
                Next
            End If
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem40_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Connected From?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        Dim result As String = ""
        If frm.isSelected Then
            If frm.isCleared Then

            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        If Not IsDBNull(gv.GetDataRow(row_handle).Item("Pulled Date")) Then
                            cable.SetConFrom(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                        Else
                            result &= "Cable: " & gv.GetDataRow(row_handle).Item("Tag") & " Cannot set as connected because it is not pulled." & vbCrLf
                        End If
                    Else
                        If Not IsDBNull(gv.GetDataRow(row_handle).Item("Pulled Date")) Then
                            cable.SetICConFrom(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                        Else
                            result &= "Cable: " & gv.GetDataRow(row_handle).Item("Tag") & " Cannot set as connected because it is not pulled." & vbCrLf
                        End If
                    End If
                Next
            End If
            If result <> "" Then
                Dim frmResult As New frmResults
                frmResult.txt.Text = result
                frmResult.Show()
            End If
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem41_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Connected To?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        Dim result As String = ""
        If frm.isSelected Then
            If frm.isCleared Then

            Else
                For Each row_handle As Integer In gv.GetSelectedRows
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        If Not IsDBNull(gv.GetDataRow(row_handle).Item("Pulled Date")) Then
                            cable.SetConTo(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                        Else
                            result &= "Cable: " & gv.GetDataRow(row_handle).Item("Tag") & " Cannot set as connected because it is not pulled." & vbCrLf
                        End If
                    Else
                        If Not IsDBNull(gv.GetDataRow(row_handle).Item("Pulled Date")) Then
                            cable.SetICConTo(gv.GetDataRow(row_handle).Item("Tag"), frm.selectedDate)
                        Else
                            result &= "Cable: " & gv.GetDataRow(row_handle).Item("Tag") & " Cannot set as connected because it is not pulled." & vbCrLf
                        End If
                    End If
                Next
            End If
            If result <> "" Then
                Dim frmResult As New frmResults
                frmResult.txt.Text = result
                frmResult.Show()
            End If
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim fs As New FileSystem
        For Each row_handle As Integer In gv.GetSelectedRows
            If Not IsDBNull(gv.GetDataRow(row_handle).Item("RFINumber")) Then
                fs.OpenFile(gv.GetDataRow(row_handle).Item("RFINumber") & ".pdf", RFIPath)
            End If
        Next
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Change Team for All {0}{1} Selected Cables?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmEditText With {.Text = "Change Team"}
        frm.lblTitle.Text = "Please type the New value"
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                    act.UpdateTeam(Activities.Discipline.EleCable, gv.GetDataRow(row_handle).Item("Tag"), frm.newValye)
                Else
                    act.UpdateTeam(Activities.Discipline.InsCable, gv.GetDataRow(row_handle).Item("Tag"), frm.newValye)
                End If
            Next
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Dim inx As Integer = 0
        Dim filter As String = ""
        For Each row_handle As Integer In gv.GetSelectedRows
            If inx = 0 Then
                filter = "[Tag] LIKE '" & gv.GetDataRow(row_handle).Item("Tag") & "'"
            Else
                filter &= " OR [Tag] LIKE '" & gv.GetDataRow(row_handle).Item("Tag") & "'"
            End If
            inx += 1
        Next
        Dim frm As New frmCableProduction With {
            .MdiParent = Me.MdiParent,
            ._filterColumn = "Tag",
        ._filter = filter
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem43_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem43.ItemClick
        Dim frm As New frmSelectResource
        Dim res As New ResourcesMan
        frm.ShowDialog(Me)
        If frm.IsSelected Then
            For Each row_handle As Integer In gv.GetSelectedRows
                For inx As Integer = 1 To frm.ResId.Count
                    If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                        Dim unused = res.Assign(frm.ResId.Item(inx), gv.GetDataRow(row_handle).Item("Id"), ResourcesMan.GROUPID.ElecatricalCable)
                    Else
                        Dim unused = res.Assign(frm.ResId.Item(inx), gv.GetDataRow(row_handle).Item("Id"), ResourcesMan.GROUPID.InstrumentCable)
                    End If
                Next
            Next
            Dim msgR As MsgBoxResult = MsgBox("Resource Has Been Assigned.", MsgBoxStyle.Information, Me.Text)
            msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        If gv.RowCount = 0 Then Exit Sub
        If gv.GetSelectedRows.Length = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        Dim itemId As Integer = gv.GetDataRow(row_handle).Item("Id")
        Dim groupId As ResourcesMan.GROUPID = If(gv.GetDataRow(row_handle).Item("Discipline") = "Electrical", ResourcesMan.GROUPID.ElecatricalCable, ResourcesMan.GROUPID.InstrumentCable)
        Dim frm As New frmItemResource(itemId, groupId)
        frm.lblItem.Text = "Tag: " & gv.GetDataRow(row_handle).Item("Tag") & vbTab & "Discipline: " & gv.GetDataRow(row_handle).Item("Discipline")
        frm.Show()
    End Sub

    Private Sub BarButtonItem44_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem44.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Clear All Resources For All {0}{1} Selected Cables?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim res As ResourcesManItem, itemId As Integer = 0, groupId As ResourcesManItem.GROUPID = ResourcesMan.GROUPID.ElecatricalCable
        For Each row_handle As Integer In gv.GetSelectedRows
            itemId = gv.GetDataRow(row_handle).Item("Id")
            If gv.GetDataRow(row_handle).Item("Discipline") = "Electrical" Then
                groupId = ResourcesMan.GROUPID.ElecatricalCable
            Else
                groupId = ResourcesMan.GROUPID.InstrumentCable
            End If
            res = New ResourcesManItem(itemId, groupId)
            res.ClearResources()
        Next
        MsgBox("Resource Has Been Cleared.", MsgBoxStyle.Information, Me.Text)
        msgR = MsgBox(String.Format("Cables Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        getData()
    End Sub

    Private Sub gv_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv.CustomDrawCell
        If viewType Then
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