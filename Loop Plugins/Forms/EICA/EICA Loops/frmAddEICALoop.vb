Public Class frmAddEICALoop
    Private DT As New DataTable
    Private Builder As SqlClient.SqlCommandBuilder
    Private cmd As New SqlClient.SqlCommand("SELECT [TBL_ID] AS ID,[LoopName],[L_Type],[Sub_Type],[L_Description],[Subsystem],[Area],[Planning_START_Date],[Planning_FINISH_Date],[Active],[PID],[ACTIVITYID],[LoopPriority],[Subcontractor],[Vendor] FROM tblInsLoop", DB.DBConnection)
    Private DA As New SqlClient.SqlDataAdapter(cmd)


    Private Sub GetData()
        DT = New DataTable
        DA.Fill(DT)
        Builder = New SqlClient.SqlCommandBuilder(DA)
        DA.InsertCommand = Builder.GetInsertCommand
        DA.UpdateCommand = Builder.GetUpdateCommand
        GRD.DataSource = DT
    End Sub


    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick, BarButtonItem10.ItemClick
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName = "" Then Exit Sub
        AccDB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT '' AS [LoopName],'' AS [L_Type],'' AS [Sub_Type],'' AS [L_Description],'' AS [Subsystem],'' AS [Area],'' AS [Planning_START_Date],'' AS [Planning_FINISH_Date],'' AS [Active],'' AS [PID],'' AS [ACTIVITYID],'' AS [LoopPriority],'' AS [Subcontractor],'' AS [Vendor]", SheetName)
        MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
        Process.Start(sveFle.FileName)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub frmAddEICALoop_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[LoopName] is not null")
        If dt.Rows.Count = 0 Then
            MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmAddLoopProgress
        frm.GridControl2.DataSource = dt
        frm.Text = opnFle.FileName
        frm.ShowDialog(Me)
        GetData()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            Dim rws As Integer = 0
            DT = GRD.DataSource
            rws = DA.Update(DT)
            MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            GRD.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            Dim msg As MsgBoxResult = MsgBox("Are You Sure You Want To Delete Selected Loop", MsgBoxStyle.YesNo, Me.Text)
            If msg = MsgBoxResult.No Then Exit Sub
            GridView2.DeleteSelectedRows()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName = "" Then Exit Sub
        AccDB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT '' as [LoopName],'' as [Folder_Preparation],'' as [TR_Loop_Folder_QC_Release],'' as [HCS_Folder_Ready],'' as [Submitted_to_Precom],'' as [L_Done],'' as [Submitted_For_Certificate],'' as [L_FinalApproval]", SheetName)
        MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
        Process.Start(sveFle.FileName)
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[LoopName] is not null")
        If dt.Rows.Count = 0 Then
            MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmEditLoopBProgress
        frm.GridControl2.DataSource = dt
        frm.Text = opnFle.FileName
        frm.ShowDialog(Me)
        GetData()
    End Sub

End Class