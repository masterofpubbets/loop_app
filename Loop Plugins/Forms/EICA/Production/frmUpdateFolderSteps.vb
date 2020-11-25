Imports DevExpress.Spreadsheet
Imports DevExpress.Spreadsheet.Export
Public Class frmUpdateFolderSteps
    Private DtSteps As New DataTable
    Private UpdateDate As Date = Now

    Private Sub PrepareSheets()
        sc.Document.Worksheets.Add("Folder Preparation")
        sc.Document.Worksheets.RemoveAt(0)
        sc.Document.Worksheets.Add("QC Release")
        sc.Document.Worksheets.Add("HCS Folder Ready")
        sc.Document.Worksheets.Add("Submitted To Precom")
        sc.Document.Worksheets.Add("Loop Done")
        sc.Document.Worksheets.Add("Submitted For Certificate")
        sc.Document.Worksheets.Add("Final Approval")
        sc.Document.Worksheets.Item("Folder Preparation").ActiveView.TabColor = Color.Cyan
        sc.Document.Worksheets.Item("QC Release").ActiveView.TabColor = Color.LightCoral
        sc.Document.Worksheets.Item("HCS Folder Ready").ActiveView.TabColor = Color.Gold
        sc.Document.Worksheets.Item("Submitted To Precom").ActiveView.TabColor = Color.LightBlue
        sc.Document.Worksheets.Item("Loop Done").ActiveView.TabColor = Color.Lime
        sc.Document.Worksheets.Item("Submitted For Certificate").ActiveView.TabColor = Color.LightPink
        sc.Document.Worksheets.Item("Final Approval").ActiveView.TabColor = Color.LightSkyBlue

        For inx As Integer = 0 To sc.Document.Worksheets.Count - 1
            sc.Document.Worksheets.Item(inx).Columns.Item(0).Item(0).Value = "Loop Name"
            sc.Document.Worksheets.Item(inx).Columns.Item(0).Item(0).FillColor = Color.Navy
            sc.Document.Worksheets.Item(inx).Columns.Item(0).Item(0).Font.Color = Color.White
            sc.Document.Worksheets.Item(inx).Columns.AutoFit(0, 0)
        Next

        tre.Nodes.Clear()
        tre.Nodes.Add("Loops Steps", "Loops Steps", 11, 11)
        tre.Nodes.Item("Loops Steps").Nodes.Add("Folder Preparation", "Folder Preparation", 12, 12)
        tre.Nodes.Item("Loops Steps").Nodes.Item("Folder Preparation").Nodes.Add("Update Folder Preparation", "Update Folder Preparation: 0", 0, 0)
        tre.Nodes.Item("Loops Steps").Nodes.Add("QC Release", "QC Release", 4, 4)
        tre.Nodes.Item("Loops Steps").Nodes.Item("QC Release").Nodes.Add("Update QC Release", "Update QC Release: 0", 0, 0)
        tre.Nodes.Item("Loops Steps").Nodes.Add("HCS Folder Ready", "HCS Folder Ready", 5, 5)
        tre.Nodes.Item("Loops Steps").Nodes.Item("HCS Folder Ready").Nodes.Add("Update HCS Folder Ready", "Update HCS Folder Ready: 0", 0, 0)
        tre.Nodes.Item("Loops Steps").Nodes.Add("Submitted To Precom", "Submitted To Precom", 13, 13)
        tre.Nodes.Item("Loops Steps").Nodes.Item("Submitted To Precom").Nodes.Add("Update Submitted To Precom", "Update Submitted To Precom: 0", 0, 0)
        tre.Nodes.Item("Loops Steps").Nodes.Add("Loop Done", "Loop Done", 14, 14)
        tre.Nodes.Item("Loops Steps").Nodes.Item("Loop Done").Nodes.Add("Update Loop Done", "Update Loop Done: 0", 0, 0)
        tre.Nodes.Item("Loops Steps").Nodes.Add("Submitted For Certificate", "Submitted For Certificate", 15, 15)
        tre.Nodes.Item("Loops Steps").Nodes.Item("Submitted For Certificate").Nodes.Add("Update Submitted For Certificate", "Update Submitted For Certificate: 0", 0, 0)
        tre.Nodes.Item("Loops Steps").Nodes.Add("Final Approval", "Final Approval", 16, 16)
        tre.Nodes.Item("Loops Steps").Nodes.Item("Final Approval").Nodes.Add("Update Final Approval", "Update Final Approval: 0", 0, 0)
        tre.ExpandAll()

    End Sub
#Region "Update Steps"
    Private Sub UpdateFolderPreparation()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("Folder Preparation")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 96, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("Folder Preparation").Nodes.Item(0).Text = "Update Folder Preparation: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Private Sub UpdateQCRelease()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("QC Release")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 92, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("QC Release").Nodes.Item(0).Text = "Update QC Release: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Private Sub UpdateHCSFolderReady()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("HCS Folder Ready")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 97, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("HCS Folder Ready").Nodes.Item(0).Text = "Update HCS Folder Ready: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Private Sub UpdateSubmittedToPrecom()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("Submitted To Precom")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 911, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("Submitted To Precom").Nodes.Item(0).Text = "Update Submitted To Precom: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Private Sub UpdateSubmittedForCertificate()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("Submitted For Certificate")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 914, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("Submitted For Certificate").Nodes.Item(0).Text = "Update Submitted For Certificate: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Private Sub UpdateLoopDone()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("Loop Done")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 91, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("Loop Done").Nodes.Item(0).Text = "Update Loop Done: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Private Sub UpdateFinalApproval()
        Dim worksheet As Worksheet = sc.Document.Worksheets.Item("Final Approval")
        Dim range As Range = worksheet("A:A")
        Dim dt As DataTable = worksheet.CreateDataTable(range, True)
        Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dt, True)
        exporter.Export()
        Dim x As Integer = 1
        For Each dr In dt.Rows
            DtSteps.Rows.Add(dr("loop name"), 98, 0, 0, 0, "Loop Plugin", My.User.Name, UpdateDate, DBNull.Value, DBNull.Value)
            tre.Nodes.Item("Loops Steps").Nodes.Item("Final Approval").Nodes.Item(0).Text = "Update Final Approval: " & x
            Application.DoEvents()
            x += 1
        Next
    End Sub
    Public Sub CopyProductionToEICA()
        DB.Close()
        DB.Connect()
        Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
            bcp.DestinationTableName = "tbl_Update_MileStone"
            bcp.BatchSize = 10000
            bcp.ColumnMappings.Clear()
            bcp.ColumnMappings.Add("item_type", "item_type")
            bcp.ColumnMappings.Add("tag", "tag")
            bcp.ColumnMappings.Add("ms_1", "ms_1")
            bcp.ColumnMappings.Add("ms_2", "ms_2")
            bcp.ColumnMappings.Add("ms_3", "ms_3")
            bcp.ColumnMappings.Add("update_user", "update_user")
            bcp.ColumnMappings.Add("update_date", "update_date")
            bcp.ColumnMappings.Add("update_err", "update_err")
            bcp.ColumnMappings.Add("reported_by", "reported_by")
            bcp.ColumnMappings.Add("ms_4", "ms_4")
            bcp.WriteToServer(DtSteps)
        End Using
    End Sub
    Private Sub UpdateEICA()
        Dim temp() As String = Split(Replace(My.Resources.UpdateEICA, "userxxx", String.Format("'{0}'", My.User.Name),,, CompareMethod.Text), "GO")
        For inx As Integer = 0 To temp.Length - 1
            DB.ExcuteNoneResult(temp(inx), 500)
        Next
    End Sub
    Private Sub OnProgressFinished()
        Dim frm As New frmProReport()
        frm.ShowDialog(Me)
        DB.ExcuteNoneResult(String.Format("delete from tbl_Update_MileStone WHERE update_user ='{0}'", My.User.Name))
    End Sub
#End Region

    Private Sub frmUpdateFolderSteps_Load(sender As Object, e As EventArgs) Handles Me.Load
        PrepareSheets()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim msgR As MsgBoxResult = MsgBox("Do You Want to Load loop Steps To EICA", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Dim frm As New frmSelectDate
        frm.ShowDialog(Me)
        UpdateDate = CDate(Format(frm.dte.EditValue, "MM/dd/yyyy"))
        DtSteps = New DataTable
        DtSteps.Columns.Clear()
        DtSteps.Columns.Add("Tag")
        DtSteps.Columns.Add("item_type")
        DtSteps.Columns.Add("ms_1")
        DtSteps.Columns.Add("ms_2")
        DtSteps.Columns.Add("ms_3")
        DtSteps.Columns.Add("ms_4")
        DtSteps.Columns.Add("update_user")
        DtSteps.Columns.Add("update_date")
        DtSteps.Columns.Add("update_err")
        DtSteps.Columns.Add("reported_by")
        DtSteps.Columns("item_type").DataType = System.Type.GetType("System.Int32")
        'DtSteps.Columns("update_date").DataType = System.Type.GetType("System.Date")
        UpdateFolderPreparation()
        UpdateQCRelease()
        UpdateHCSFolderReady()
        UpdateSubmittedToPrecom()
        UpdateLoopDone()
        UpdateSubmittedForCertificate()
        UpdateFinalApproval()
        tre.Nodes.Add("Clone To EICA", "Clone To EICA", 7, 7)
        Application.DoEvents()
        CopyProductionToEICA()
        tre.Nodes.Add("Update EICA Production", "Update EICA Production", 17, 17)
        Application.DoEvents()
        UpdateEICA()
        MsgBox("Process Has Been Finished", MsgBoxStyle.OkOnly, Me.Text)
        OnProgressFinished()
    End Sub
End Class