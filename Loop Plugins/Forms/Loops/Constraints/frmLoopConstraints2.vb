Imports System.ComponentModel
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class frmLoopConstraints2
    Private loops As New LoopsSteps
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews


    Private Sub ShowRadialMenu()
        ' Display Radial Menu
        If rMenu Is Nothing Then
            Return
        End If
        Dim pt As Point = Me.Location
        pt.Offset(Me.Width \ 2, Me.Height \ 2)
        rMenu.ShowPopup(pt)
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
    Private Sub GetLoop()
        saveColumnsWidth()
        grd.DataSource = loops.getLoopsConstraints
        formatColumnsWidth()

        gv.OptionsSelection.MultiSelect = True

        gv.Columns("Issued By Mail").Visible = False
        gv.Columns("Issued To Mail").Visible = False
        gv.Columns("Loop Description").Visible = False
        gv.Columns("LoopID").Visible = False
        gv.Columns("ID").Visible = False


        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
        gv.BestFitColumns(True)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetLoop()
    End Sub

    Private Sub frmLoopConstraints2_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        GetLoop()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Loops Filter"
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

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
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
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Close Blockage For Selected Folders?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim result As String = ""
        For Each row_handle As Integer In gv.GetSelectedRows
            ''close blockage here
            If gv.GetDataRow(row_handle).Item("Issued To") = Users.userFullName Then
                If loops.closeBlockage(gv.GetDataRow(row_handle).Item("ID")) Then
                End If
            ElseIf gv.GetDataRow(row_handle).Item("Issued By") = Users.userFullName Then
                If loops.closeBlockage(gv.GetDataRow(row_handle).Item("ID")) Then
                End If
            ElseIf instr(Users.userType, "admin", CompareMethod.Text) > 0 Then
                If loops.closeBlockage(gv.GetDataRow(row_handle).Item("ID")) Then
                End If
            Else
                result &= "Only the responsible or the admin can close the blockage for this loop: " & gv.GetDataRow(row_handle).Item("Loop Name") & vbCrLf
            End If

        Next
        If result <> "" Then
            Dim frmErr As New frmResults
            frmErr.txt.Text = result
            frmErr.ShowDialog(Me)
        End If
        msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        GetLoop()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Re-assign Blockage To Another User?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectUser
        frm.ShowDialog(Me)
        Dim result As String = ""
        If frm.selectedUserName <> "" Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Loop Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Loop Description")
                End If
                ''add blockage here
                If gv.GetDataRow(row_handle).Item("Issued To") = Users.userFullName Then
                    If loops.reassignResponsible(gv.GetDataRow(row_handle).Item("Constraint Category"), gv.GetDataRow(row_handle).Item("ID"), gv.GetDataRow(row_handle).Item("LoopID"), gv.GetDataRow(row_handle).Item("Loop Name"), desc, gv.GetDataRow(row_handle).Item("Area"), desc, Users.userFullName, Users.mail, Users.id, frm.selectedUserName, frm.selectedUsermail, frm.selectedUserId, gv.GetDataRow(row_handle).Item("Folder Status")) Then
                    End If
                ElseIf gv.GetDataRow(row_handle).Item("Issued By") = Users.userFullName Then
                    If loops.reassignResponsible(gv.GetDataRow(row_handle).Item("Constraint Category"), gv.GetDataRow(row_handle).Item("ID"), gv.GetDataRow(row_handle).Item("LoopID"), gv.GetDataRow(row_handle).Item("Loop Name"), desc, gv.GetDataRow(row_handle).Item("Area"), desc, Users.userFullName, Users.mail, Users.id, frm.selectedUserName, frm.selectedUsermail, frm.selectedUserId, gv.GetDataRow(row_handle).Item("Folder Status")) Then
                    End If
                ElseIf Users.userType = "admin" Then
                    If loops.reassignResponsible(gv.GetDataRow(row_handle).Item("Constraint Category"), gv.GetDataRow(row_handle).Item("ID"), gv.GetDataRow(row_handle).Item("LoopID"), gv.GetDataRow(row_handle).Item("Loop Name"), desc, gv.GetDataRow(row_handle).Item("Area"), desc, Users.userFullName, Users.mail, Users.id, frm.selectedUserName, frm.selectedUsermail, frm.selectedUserId, gv.GetDataRow(row_handle).Item("Folder Status")) Then
                    End If
                Else
                    result &= "Only the responsible or the admin can reassign responsible for this loop: " & gv.GetDataRow(row_handle).Item("Loop Name") & vbCrLf
                End If

            Next

            'loops.SendNotificationsMail(LoopsAPI.MailTypes.FolderBlockage)

            If result <> "" Then
                Dim frmErr As New frmResults
                frmErr.txt.Text = result
                frmErr.ShowDialog(Me)
            End If

            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            GetLoop()
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Add Comment For Selected Folders?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frmComment As New frmAddComment
        frmComment.ShowDialog(Me)
        If frmComment.Comment = "" Then Exit Sub
        Dim result As String = ""
        For Each row_handle As Integer In gv.GetSelectedRows
            ''close blockage here
            If gv.GetDataRow(row_handle).Item("Issued To") = Users.userFullName Then
                If loops.addComment(gv.GetDataRow(row_handle).Item("ID"), frmComment.Comment) Then
                End If
            ElseIf instr(Users.userType, "admin", CompareMethod.Text) > 0 Then
                If loops.addComment(gv.GetDataRow(row_handle).Item("ID"), frmComment.Comment) Then
                End If
            Else
                result &= "Only the responsible or the admin can add comment for this loop: " & gv.GetDataRow(row_handle).Item("Loop Name") & vbCrLf
            End If

        Next
        If result <> "" Then
            Dim frmErr As New frmResults
            frmErr.txt.Text = result
            frmErr.ShowDialog(Me)
        End If
        msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        GetLoop()
    End Sub

    Private Sub gv_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv.CustomDrawCell
        If e.Column.FieldName = "LoopPriority" Then
            If Not IsDBNull(e.CellValue) Then
                If e.CellValue < 20 Then
                    e.Cache.FillEllipse(Convert.ToSingle(e.Bounds.X + e.Bounds.Height / 2), e.Bounds.Y + 3, e.Bounds.Height - 5, e.Bounds.Height - 5, Color.Red)
                    'e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                    e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To remove Comment For Selected Folders?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim result As String = ""
        For Each row_handle As Integer In gv.GetSelectedRows
            ''close blockage here
            If gv.GetDataRow(row_handle).Item("Issued To") = Users.userFullName Then
                If loops.removeComment(gv.GetDataRow(row_handle).Item("ID")) Then
                End If
            ElseIf instr(Users.userType, "admin", CompareMethod.Text) > 0 Then
                If loops.removeComment(gv.GetDataRow(row_handle).Item("ID")) Then
                End If
            Else
                result &= "Only the responsible or the admin can remove comment for this loop: " & gv.GetDataRow(row_handle).Item("Loop Name") & vbCrLf
            End If

        Next
        If result <> "" Then
            Dim frmErr As New frmResults
            frmErr.txt.Text = result
            frmErr.ShowDialog(Me)
        End If
        msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        GetLoop()
    End Sub

    Private Sub frmLoopConstraints2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        grdView.CopySelectedItems(gv, "Loop Name")
    End Sub
    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles grd.KeyDown
        Select Case e.KeyCode
            Case Keys.Space
                ShowRadialMenu()
        End Select
    End Sub
End Class