Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraSplashScreen

Public Class frmLighting
    Private light As New Lighting
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private StandardRulesAdded As Boolean = False
    Private docImage As Image = Image.FromFile(Application.StartupPath & "\res\doc12.png")
    Private Scope As Integer = 0
    Private done As Integer = 0
    Private opnedHandle As IOverlaySplashScreenHandle


    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub

    Private Sub CheckAuth()
        rpProduction.Visible = False
        rpPlanning.Visible = False
        rpProductionControl.Visible = False
        rpEngineering.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
            rpPlanning.Visible = True
            rpProductionControl.Visible = True
            rpEngineering.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "construction", CompareMethod.Text) > 0 Then
            rpProduction.Visible = True
        End If
        If InStr(Users.userType, "planning", CompareMethod.Text) > 0 Then
            rpPlanning.Visible = True
        End If
        If InStr(Users.userType, "production", CompareMethod.Text) > 0 Then
            rpProductionControl.Visible = True
        End If
        If InStr(Users.userType, "engineering", CompareMethod.Text) > 0 Then
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
        grd.DataSource = light.GetItems(Construction.ItemsTypes.LIGHTING)
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Installed Date").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Id").Visible = False
        gv.Columns("Resource").Visible = False
        gv.Columns("IfInstalled").Visible = False

        gv.OptionsSelection.MultiSelect = True

        'conditional format
        ConditionalFormat()

        'Filter
        Filter()

        gv.BestFitColumns(True)

    End Sub

    Private Sub frmLighting_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
        Try
            If System.IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        ShowProgressPanel()
        getData()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Lighting Filter"
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

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Installed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            For Each row_handle As Integer In gv.GetSelectedRows
                light.UpdateInstalled(gv.GetDataRow(row_handle).Item("Id"), frm.selectedDate)
            Next
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
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

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
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

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If MsgBox("Do you want to change Pulling Activity ID for selected Fixture?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Fixture, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If MsgBox("Do you want to change Pulling Activity ID for selected Fixture?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateActIds(Activities.Discipline.Fixture, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), frm.ActId)
                act.UpdateArea(Activities.Discipline.Fixture, gv.GetDataRow(row_handle).Item("Tag"), frm.Area)
            Next
            getData()
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        If MsgBox("Do you want to Clear Pulling Activity ID for selected Fixture?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim act As New Activities
        For Each row_handle As Integer In gv.GetSelectedRows
            act.UpdateActIds(Activities.Discipline.Fixture, Activities.Keys.Erect, gv.GetDataRow(row_handle).Item("Tag"), "")
        Next
        getData()
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Change Team for All {0}{1} Selected Lighting?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmEditText With {.Text = "Change Team"}
        frm.lblTitle.Text = "Please type the New value"
        frm.ShowDialog(Me)
        If frm.isUpdated Then
            Dim act As New Activities
            For Each row_handle As Integer In gv.GetSelectedRows
                act.UpdateTeam(Activities.Discipline.Fixture, gv.GetDataRow(row_handle).Item("Tag"), frm.newValye)
            Next
            msgR = MsgBox(String.Format("Lighting Have Been Updated {0} Do You Want To Refresh?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Installed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint(False)
        frm.ShowDialog(Me)
        If frm.isSelected Then
            For Each row_handle As Integer In gv.GetSelectedRows
                light.UpdateInstalled(gv.GetDataRow(row_handle).Item("Id"), frm.selectedDate, 1)
            Next
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        If gv.RowCount = 0 Then Exit Sub
        If gv.GetSelectedRows.Length = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        Dim itemId As Integer = gv.GetDataRow(row_handle).Item("Id")
        Dim groupId As ResourcesMan.GROUPID = ResourcesMan.GROUPID.Lighting
        Dim frm As New frmItemResource(itemId, groupId)
        frm.lblItem.Text = "Tag: " & gv.GetDataRow(row_handle).Item("Tag") & vbTab & "Discipline: Lighting"
        frm.Show()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        Dim frm As New frmSelectResource
        Dim res As New ResourcesMan
        frm.ShowDialog(Me)
        If frm.IsSelected Then
            For Each row_handle As Integer In gv.GetSelectedRows
                For inx As Integer = 1 To frm.ResId.Count
                    Dim unused = res.Assign(frm.ResId.Item(inx), gv.GetDataRow(row_handle).Item("Id"), ResourcesMan.GROUPID.Lighting)
                Next
            Next
            Dim msgR As MsgBoxResult = MsgBox("Resource Has Been Assigned.", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Clear All Resources For All {0}{1} Selected Lighting?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim res As ResourcesManItem, itemId As Integer = 0, groupId As ResourcesManItem.GROUPID = ResourcesMan.GROUPID.Lighting
        For Each row_handle As Integer In gv.GetSelectedRows
            itemId = gv.GetDataRow(row_handle).Item("Id")
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

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        grd.ShowPrintPreview()
    End Sub

    Private Sub frmLighting_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class