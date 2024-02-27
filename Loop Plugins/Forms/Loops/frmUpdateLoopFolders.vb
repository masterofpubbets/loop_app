Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls

Public Class frmUpdateLoopFolders
    Private sheet As New DevExpressUserSpreadSheet
    Private lf As New LoopFolders
    Private prepared As Boolean = False
    Const SHEETNAME = "Loops"
    Private loadedFolders As List(Of LoopFolder) = Nothing
    Private IsAddNew As Boolean = False
    Private DisabledConfirmation As Boolean = False

    Public Sub New(Optional folders As List(Of LoopFolder) = Nothing, Optional bhIsAddNew As Boolean = False)

        ' This call is required by the designer.
        InitializeComponent()

        loadedFolders = folders
        IsAddNew = bhIsAddNew
        If IsAddNew Then
            btnAddNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        End If
    End Sub

    Private Sub prepareSheets()
        sheet.renameActiveSheet(ss, SHEETNAME)
        prepared = False
        For Each c As ColumnObject In lf.LoopColumns
            If Not c.IsProductionStep Then
                sheet.setActiveSheetValue(ss, c.IndexName, c.Name)
            End If
        Next

        If Not IsAddNew Then
            If Not IsNothing(loadedFolders) Then
                Dim rInx As Integer = 1
                For Each lf As LoopFolder In loadedFolders
                    sheet.setActiveSheetValue(ss, rInx, 0, lf.Name)
                    sheet.setActiveSheetValue(ss, rInx, 1, lf.Description)
                    sheet.setActiveSheetValue(ss, rInx, 2, lf.Area)
                    sheet.setActiveSheetValue(ss, rInx, 3, lf.Type)
                    sheet.setActiveSheetValue(ss, rInx, 4, lf.Subtype)
                    sheet.setActiveSheetValue(ss, rInx, 5, lf.ActId)
                    sheet.setActiveSheetValue(ss, rInx, 6, lf.Vendors)
                    sheet.setActiveSheetValue(ss, rInx, 7, IIf(lf.StartDate = "1/1/0001", "", lf.StartDate))
                    sheet.setActiveSheetValue(ss, rInx, 8, IIf(lf.FinishDate = "1/1/0001", "", lf.FinishDate))
                    sheet.setActiveSheetValue(ss, rInx, 9, lf.Subsystem)
                    sheet.setActiveSheetValue(ss, rInx, 10, IIf(lf.Priority = -1, "", lf.Priority))
                    sheet.setActiveSheetValue(ss, rInx, 11, lf.PDSModel)
                    sheet.setActiveSheetValue(ss, rInx, 12, lf.ControllerLocation)
                    rInx += 1
                Next
            End If
        End If

        sheet.autoFilterActiveSheet(ss, 0, sheet.GetFirstColumnEmptyIndex(ss))
        sheet.autoColumnsFitActiveSheet(ss, 0, sheet.GetFirstColumnEmptyIndex(ss))

        prepared = True
    End Sub

    Private Sub frmUpdateLoopFolders_Load(sender As Object, e As EventArgs) Handles Me.Load
        prepareSheets()
    End Sub

    Private Sub tgType_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgType.EditValueChanging
        If tgType.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Type" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub tgDescription_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgDescription.EditValueChanging
        If tgDescription.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Description" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgSubtype_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgSubtype.EditValueChanging
        If tgSubtype.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Subtype" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgActId_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgActId.EditValueChanging
        If tgActId.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "ActId" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgVendor_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgVendor.EditValueChanging
        If tgVendor.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Vendor" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgStartDate_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgStartDate.EditValueChanging
        If tgStartDate.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Start Date" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgFinishDate_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgFinishDate.EditValueChanging
        If tgFinishDate.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Finish Date" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub tgcontrollerlocation_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgControllerLocation.EditValueChanging
        If tgControllerLocation.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Controller Location" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub tgFinishDate_EditValueChanged(sender As Object, e As EventArgs) Handles tgFinishDate.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "FinishDate")
        If Not IsNothing(c) Then
            If tgFinishDate.IsOn Then
                If Not sheet.ColumnExists(ss, c.Name) Then
                    Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                    ss.ActiveWorksheet.Columns.Insert(inx)
                    sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                    sheet.RemoveEmptyColumnHeader(ss, c.Index)
                End If
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles tgStartDate.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "StartDate")
        If Not IsNothing(c) Then
            If tgStartDate.IsOn Then
                If Not sheet.ColumnExists(ss, c.Name) Then
                    Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                    ss.ActiveWorksheet.Columns.Insert(inx)
                    sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                    sheet.RemoveEmptyColumnHeader(ss, c.Index)
                End If
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgType_EditValueChanged(sender As Object, e As EventArgs) Handles tgType.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Type")
        If Not IsNothing(c) Then
            If tgType.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgDescription_EditValueChanged(sender As Object, e As EventArgs) Handles tgDescription.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Description")
        If Not IsNothing(c) Then
            If tgDescription.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgSubtype_EditValueChanged(sender As Object, e As EventArgs) Handles tgSubtype.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Subtype")
        If Not IsNothing(c) Then
            If tgSubtype.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgActId_EditValueChanged(sender As Object, e As EventArgs) Handles tgActId.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "ActId")
        If Not IsNothing(c) Then
            If tgActId.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgVendor_EditValueChanged(sender As Object, e As EventArgs) Handles tgVendor.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Vendor")
        If Not IsNothing(c) Then
            If tgVendor.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub
    Private Sub tgControllerLocation_EditValueChanged(sender As Object, e As EventArgs) Handles tgControllerLocation.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "ControllerLocation")
        If Not IsNothing(c) Then
            If tgControllerLocation.IsOn Then
                If Not sheet.ColumnExists(ss, c.Name) Then
                    Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                    ss.ActiveWorksheet.Columns.Insert(inx)
                    sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                    sheet.RemoveEmptyColumnHeader(ss, c.Index)
                End If
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUpdate.ItemClick
        If MsgBox("Do you want to update Loops?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim dt As New DataTable
        dt = sheet.convertActiveSheetToDatatable(ss, SHEETNAME)
        If IsNothing(dt) Then
            MsgBox("Nothing to update!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If dt.Rows.Count = 0 Then
            MsgBox("Nothing to update!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim opKey As String = lf.UploadTempData(Enumerations.UpdateType.UPDATEDATA, dt)
        If opKey <> "" Then
            Dim dtResult As New DataTable
            If lf.UpdateData(opKey, dtResult) Then
                Dim frm As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                frm.ShowDialog(Me)
                lf.DeleteTempData(opKey)
            End If

        Else
            MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub

    Private Sub tgSubsystem_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgSubsystem.EditValueChanging
        If tgSubsystem.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Subsystem" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgSubsystem_EditValueChanged(sender As Object, e As EventArgs) Handles tgSubsystem.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Subsystem")
        If Not IsNothing(c) Then
            If tgSubsystem.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        sheet.autoFilterActiveSheet(ss, 0, sheet.GetFirstColumnEmptyIndex(ss))
        sheet.autoColumnsFitActiveSheet(ss, 0, sheet.GetFirstColumnEmptyIndex(ss))
    End Sub

    Private Sub ss_ColumnsRemoving(sender As Object, e As DevExpress.Spreadsheet.ColumnsChangingEventArgs) Handles ss.ColumnsRemoving
        For inx As Integer = e.StartIndex To e.StartIndex + e.Count - 1
            Dim ix As Integer = inx
            If Not IsNothing(lf.LoopColumns.Find(Function(c) c.Name = ss.ActiveWorksheet.Item(0, ix).Value.ToString())) Then
                e.Cancel = True
            End If
        Next
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim frm As New frmSelectActId
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim colInx As Integer = sheet.GetColumnIndex(ss, "ActId")
            If colInx > -1 Then
                ss.Selection.Value = frm.ActId
            Else
                MsgBox("You do not have ActId Column!", MsgBoxStyle.Exclamation, Me.Text)
            End If
        End If
    End Sub

    Private Sub tgArea_EditValueChanged(sender As Object, e As EventArgs) Handles tgArea.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Area")
        If Not IsNothing(c) Then
            If tgArea.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgArea_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgArea.EditValueChanging
        If tgArea.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Area" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub ss_SheetRemoving(sender As Object, e As DevExpress.Spreadsheet.SheetRemovingEventArgs) Handles ss.SheetRemoving
        If e.SheetName = SHEETNAME Then
            MsgBox("You cannot delete main sheet", MsgBoxStyle.Exclamation, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub ss_SheetRenaming(sender As Object, e As DevExpress.Spreadsheet.SheetRenamingEventArgs) Handles ss.SheetRenaming
        If e.OldName = SHEETNAME Then e.Cancel = True
        If e.NewName = SHEETNAME Then e.Cancel = True
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim frm As New frmSelectArea
        frm.ShowDialog(Me)
        If frm.isSelect Then
            Dim colInx As Integer = sheet.GetColumnIndex(ss, "Area")
            If colInx > -1 Then
                ss.Selection.Value = frm.Area
            Else
                MsgBox("You do not have Area Column!", MsgBoxStyle.Exclamation, Me.Text)
            End If
        End If
    End Sub

    Private Sub frmUpdateLoopFolders_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    Private Sub tgPriority_EditValueChanged(sender As Object, e As EventArgs) Handles tgPriority.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "Priority")
        If Not IsNothing(c) Then
            If tgPriority.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub tgPriority_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgPriority.EditValueChanging
        If tgPriority.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "Priority" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgPDSModel_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles tgPDSModel.EditValueChanging
        If tgPDSModel.IsOn And Not DisabledConfirmation Then
            If MsgBox("Do you want to delete column(" & "PDSModel" & ")?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub tgPDSModel_EditValueChanged(sender As Object, e As EventArgs) Handles tgPDSModel.EditValueChanged
        If Not prepared Then
            Exit Sub
        End If
        Dim c As ColumnObject = lf.LoopColumns.Find(Function(x) x.Name = "PDSModel")
        If Not IsNothing(c) Then
            If tgPDSModel.IsOn Then
                Dim inx As Integer = sheet.GetFirstColumnEmptyIndex(ss, 1)
                ss.ActiveWorksheet.Columns.Insert(inx)
                sheet.setActiveSheetValue(ss, 0, inx, c.Name)
                sheet.RemoveEmptyColumnHeader(ss, c.Index)
            Else
                Dim colInx As Integer = sheet.GetColumnIndex(ss, c.Name)
                If colInx > -1 Then ss.ActiveWorksheet.Columns.Item(colInx).Delete()
            End If
        End If
    End Sub

    Private Sub frmUpdateLoopFolders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    Private Sub btnAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddNew.ItemClick
        If MsgBox("Do you want to Add these Loops?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        Dim dt As New DataTable
        dt = sheet.convertActiveSheetToDatatable(ss, SHEETNAME)
        If IsNothing(dt) Then
            MsgBox("Nothing to import!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If dt.Rows.Count = 0 Then
            MsgBox("Nothing to import!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim opKey As String = lf.UploadTempData(Enumerations.UpdateType.UPDATEDATA, dt)
        If opKey <> "" Then
            Dim dtResult As New DataTable
            If lf.AddNewData(opKey, dtResult) Then
                Dim frm As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                frm.ShowDialog(Me)
                lf.DeleteTempData(opKey)
            End If

        Else
            MsgBox("Something is wrong. Nothing to import.", MsgBoxStyle.Exclamation, Me.Text)
        End If
    End Sub
    Private Sub tgAll_Toggled(sender As Object, e As EventArgs) Handles tgAll.Toggled
        If Not tgAll.IsOn Then
            If MsgBox("Do you want to delete all columns?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        End If
        DisabledConfirmation = True
        tgType.IsOn = tgAll.IsOn
        tgArea.IsOn = tgAll.IsOn
        tgDescription.IsOn = tgAll.IsOn
        tgSubtype.IsOn = tgAll.IsOn
        tgActId.IsOn = tgAll.IsOn
        tgVendor.IsOn = tgAll.IsOn
        tgStartDate.IsOn = tgAll.IsOn
        tgFinishDate.IsOn = tgAll.IsOn
        tgSubsystem.IsOn = tgAll.IsOn
        tgPriority.IsOn = tgAll.IsOn
        tgPDSModel.IsOn = tgAll.IsOn
        tgControllerLocation.IsOn = tgAll.IsOn
        DisabledConfirmation = False
    End Sub
End Class