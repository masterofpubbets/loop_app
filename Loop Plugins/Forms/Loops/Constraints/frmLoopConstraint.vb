Public Class frmLoopConstraint
    Private DT As New DataTable
    Private Builder As SqlClient.SqlCommandBuilder
    Private cmd As New SqlClient.SqlCommand("select tblinsloop.TBL_ID AS ID,Area,LoopName,L_remarks AS Responsible,[Status] as [Constraint],Constraints as [Constraint Description],Active from tblinsloop where status is not null", DB.DBConnection)
    Private DA As New SqlClient.SqlDataAdapter(cmd)
    Private ild As New ExtractILD
    Private Sub GetData()
        DT = New DataTable
        DA.Fill(DT)
        Builder = New SqlClient.SqlCommandBuilder(DA)
        DA.InsertCommand = Builder.GetInsertCommand
        DA.UpdateCommand = Builder.GetUpdateCommand
        GRD.DataSource = DT
    End Sub
    Private Sub h_Index(ByVal inx As Integer)
        pBar.EditValue = inx
    End Sub
    Private Sub h_LoopCnt(ByVal inx As Integer)
        RepositoryItemProgressBar1.Maximum = inx
        pBar.EditValue = 0
    End Sub
    Private Sub h_Finished()
        pBar.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        MsgBox("Update Loop Status Has Been Finished", MsgBoxStyle.Information, Me.Text)
        GetData()
    End Sub
    Private Sub frmLoopConstraint_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler ild.ItemIndex, AddressOf h_Index
        AddHandler ild.FileCount, AddressOf h_LoopCnt
        AddHandler ild.UpdateLoopFinished, AddressOf h_Finished
        GetData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Try
            Dim rws As Integer = 0
            DT = GRD.DataSource
            rws = DA.Update(DT)
            MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
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

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim msgr As New MsgBoxResult
        msgr = MsgBox("Are You Sure You Want To Remove Missing ILD Status?", vbYesNo, Me.Text)
        If msgr = MsgBoxResult.No Then Exit Sub
        pBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        ild.RemoveMissingILDStatus()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim frm As New frmDefaultCons
        frm.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            AccDB.ExportDataHeaderToExcel(sveFle.FileName, "select '' as [Loop Name],'' as [Constraint],'' as Responsible,'' as [Constraint Description]", SheetName)
            MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
            Process.Start(sveFle.FileName)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try

    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
        dt = ex.GetSheetData(opnFle.FileName.ToString, SheetName, "[Loop Name] is not null")
        If dt.Rows.Count = 0 Then
            MsgBox("No Constraints To Upload", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim frm As New frmLoadCons
        frm.GridControl2.DataSource = dt
        frm.Text = opnFle.FileName
        frm.ShowDialog(Me)
        GetData()
    End Sub
End Class