Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid


Public Class frmHCSSetSteps
    Private loops As New LoopsSteps
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private fs As New FileSystem
    Private lpAPI As New LoopsAPI


    Private Sub CheckAuth()
        rpHandover.Visible = False
        rpQC.Visible = False
        rpPrecom.Visible = False

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
            rpQC.Visible = True
            rpPrecom.Visible = True
            rpBlockage.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "handover", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
            rpBlockage.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            rpQC.Visible = True
            rpBlockage.Visible = True
            Exit Sub
        End If
        If InStr(Users.userType, "precomm", CompareMethod.Text) > 0 Then
            rpPrecom.Visible = True
            rpBlockage.Visible = True
            Exit Sub
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
    Private Sub getData()
        saveColumnsWidth()
        grd.DataSource = loops.getLoopsSteps
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            gv.Columns("Folder Printed HO").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Final Approval").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("QC Released").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Folder Ready QCC").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Submitted To Precomm").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Done").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        End If
        If InStr(Users.userType, "handover", CompareMethod.Text) > 0 Then
            gv.Columns("Folder Printed HO").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Final Approval").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            gv.Columns("QC Released").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Folder Ready QCC").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Submitted To Precomm").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        End If
        If InStr(Users.userType, "precomm", CompareMethod.Text) > 0 Then
            gv.Columns("Submitted To Precomm").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
            gv.Columns("Done").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        End If



        gv.OptionsSelection.MultiSelect = True

        'conditional format
        'Dim gridFormatRule As New GridFormatRule()
        'Dim formatConditionRuleExpression As New FormatConditionRuleDataBar() With {.PredefinedName = "BlueGradientDataBar"}
        'gridFormatRule.Column = gv.Columns("LoopPriority")
        'gridFormatRule.Rule = formatConditionRuleExpression
        'gv.FormatRules.Add(gridFormatRule)

        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
        gv.BestFitColumns(True)

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Loops Filter"
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

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        getData()
    End Sub

    Private Sub frmHCSSetSteps_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        grdView.CopySelectedItems(gv, "Loop Name")
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        grdView.CopySelectedItems(gv, "Subsystem")
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Folder Prepared?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                loops.setHCSFolderPrepared(gv.GetDataRow(row_handle).Item("Loop Name"), frm.selectedDate, gv.GetDataRow(row_handle).Item("Area"), desc)
            Next
            loops.SendNotificationsMail(LoopsAPI.MailTypes.FolderPrepared)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Folder Approved?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        Dim result As String = ""
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                If Not IsDBNull(gv.GetDataRow(row_handle).Item("Done")) Then
                    loops.setHCSFolderApproved(gv.GetDataRow(row_handle).Item("Loop Name"), frm.selectedDate, gv.GetDataRow(row_handle).Item("Area"), desc)
                Else
                    result &= "Cannot Update Loop: " & gv.GetDataRow(row_handle).Item("Loop Name") & " Because It is Not Done" & vbCrLf
                End If
            Next
            If result <> "" Then
                Dim frmResult As New frmResults
                frmResults.txt.Text = result
                frmResults.ShowDialog(Me)
            End If
            loops.SendNotificationsMail(LoopsAPI.MailTypes.FolderApproved)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
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

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                loops.setHCSFolderQCReleased(gv.GetDataRow(row_handle).Item("Loop Name"), frm.selectedDate, gv.GetDataRow(row_handle).Item("Area"), desc)
            Next
            loops.SendNotificationsMail(LoopsAPI.MailTypes.QCReleased)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Ready?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                loops.setHCSFolderReady(gv.GetDataRow(row_handle).Item("Loop Name"), frm.selectedDate, gv.GetDataRow(row_handle).Item("Area"), desc)
            Next
            loops.SendNotificationsMail(LoopsAPI.MailTypes.FolderReady)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick, BarButtonItem13.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Submitted To Pre-Comm?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                loops.setHCSFolderSubmitToPrecomm(gv.GetDataRow(row_handle).Item("Loop Name"), frm.selectedDate, gv.GetDataRow(row_handle).Item("Area"), desc)
            Next
            loops.SendNotificationsMail(LoopsAPI.MailTypes.SubmittedToPrecomm)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Loop Done?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDateConstraint
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                loops.setHCSFolderDone(gv.GetDataRow(row_handle).Item("Loop Name"), frm.selectedDate, gv.GetDataRow(row_handle).Item("Area"), desc)
            Next
            loops.SendNotificationsMail(LoopsAPI.MailTypes.LoopDone)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim msgR As MsgBoxResult = MsgBox(String.Format("Do You Want To Add Blockage To Selected Folders?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmAddConsEntry
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                ''add blockage here
                If loops.addBlockage(frm.catName, gv.GetDataRow(row_handle).Item("Id"), gv.GetDataRow(row_handle).Item("Loop Name"), desc, gv.GetDataRow(row_handle).Item("Area"), frm.description, Users.userFullName, Users.mail, Users.id, frm.selectedUserName, frm.selectedUserMail, frm.selectedUserId, gv.GetDataRow(row_handle).Item("Folder Status")) Then
                End If

            Next
            loops.SendNotificationsMail(LoopsAPI.MailTypes.FolderBlockage)
            msgR = MsgBox(String.Format("Loops Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            getData()

        End If
    End Sub

    Private Sub gv_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gv.RowCellStyle
        If e.Column.FieldName = "Has Blockage" Then
            If e.CellValue = "Yes" Then
                e.Appearance.BackColor = Color.LightPink
            End If
        End If
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

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        For Each row_handle As Integer In gv.GetSelectedRows
            Dim frm As New frmQRCodeViewer
            frm.lbl.Text = "Loop: " & gv.GetDataRow(row_handle).Item("Loop Name")
            frm.pic.Image = lpAPI.GenerateQRCode(gv.GetDataRow(row_handle).Item("Loop Name"))
            frm.Show()
        Next
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim inx As Integer = 0
        Dim filter As String = ""
        For Each row_handle As Integer In gv.GetSelectedRows
            If inx = 0 Then
                filter = "[Loop Name] LIKE '" & gv.GetDataRow(row_handle).Item("Loop Name") & "'"
            Else
                filter &= " OR [Loop Name] LIKE '" & gv.GetDataRow(row_handle).Item("Loop Name") & "'"
            End If
            inx += 1
        Next
        Dim frm As New frmLoopConstraints2 With {
            ._filterColumn = "Loop Name",
        ._filter = filter
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Try
            Dim pdfs As List(Of String)
            Dim pdfsFName As New List(Of String)

            Dim row_handle As Integer = gv.GetSelectedRows(0)
            If row_handle < 0 Then Exit Sub
            pdfs = fs.FindFile(gv.GetDataRow(row_handle).Item("Loop Name") & "*", SharedFolder, pdfsFName)
            If IsNothing(pdfs) Then
                MsgBox("No PDF associated to this Loop!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If pdfs.Count = 0 Then
                MsgBox("No PDF associated to this Loop!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If IO.File.Exists(pdfs.Item(0)) Then
                Dim frm As New frmPdf() With {.PDFPath = pdfs.Item(0), .Text = gv.GetDataRow(row_handle).Item("Loop Name")}
                frm.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class