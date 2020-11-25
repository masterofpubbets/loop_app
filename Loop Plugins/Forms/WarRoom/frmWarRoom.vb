Public Class frmWarRoom
    Private DT As New DataTable
    Private Builder As OleDb.OleDbCommandBuilder
    Dim cmd As New OleDb.OleDbCommand("select * from tblwarroom", AccDB.Connection)
    Dim DA As New OleDb.OleDbDataAdapter(cmd)
    Private lP As New LoopProcess


    Private Sub H_Progress(ByVal inx As Integer)
        pBar.EditValue = inx + 1
        pBar.Caption = inx + 1 & " / " & RepositoryItemProgressBar1.Maximum
        pBar2.EditValue = inx + 1
        pBar2.Caption = inx + 1 & " / " & RepositoryItemProgressBar1.Maximum
    End Sub
    Private Sub H_RowwsCount(ByVal Count As Integer)
        RepositoryItemProgressBar1.Maximum = Count + 1
        RepositoryItemProgressBar2.Maximum = Count + 1
    End Sub
    Private Sub H_Finished()
        MsgBox("Update Has Been Finished", MsgBoxStyle.Information, Me.Text)
        Getdata()
    End Sub
    Private Sub H_Err(ByVal msg As String)
        MsgBox(msg, vbCritical, Me.Text)
    End Sub
    Private Sub Getdata()
        DT = New DataTable
        DA.Fill(DT)
        Builder = New OleDb.OleDbCommandBuilder(DA)
        DA.InsertCommand = Builder.GetInsertCommand
        DA.UpdateCommand = Builder.GetUpdateCommand
        GRD.DataSource = DT
    End Sub

    Private Sub frmWarRoom_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler lP.Err, AddressOf H_Err
        AddHandler lP.Finished, AddressOf H_Finished
        AddHandler lP.Progress, AddressOf H_Progress
        AddHandler lP.TotalRows, AddressOf H_RowwsCount
        Getdata()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName = "" Then Exit Sub
        AccDB.ExportDataHeaderToExcel(sveFle.FileName, "SELECT [Meeting Date],[Loop Name],[Material Constrain],[Construction Target Date],[Construction Constraint],[Construction Action BY],[QC Target Date],[QC Constraint],[QC Action BY],[HCS Target Date],[HCS Constraint],[HCS Action BY],[Precomm Target Date],[Precomm Constraint],[Precomm Action BY] FROM [tblwarroom]", SheetName)
        MsgBox("Template File has been downloaded", MsgBoxStyle.OkOnly, Me.Text)
        Process.Start(sveFle.FileName)
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then
            Exit Sub
        End If
        lP.UpdateWarRoom(opnFle.FileName)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Getdata()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            Dim rws As Integer = 0
            DT = GRD.DataSource
            rws = DA.Update(DT)
            MsgBox(String.Format("All changes has been updated{0}Record(s) affected: {1}", vbCrLf, rws), MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim msgR As MsgBoxResult = MsgBox("Are You Sure You Want To Delete All", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        AccDB.ExcuteNoneResult("Delete from tblwarroom")
        Getdata 
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
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

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        If DB.DBStatus = ConnectionState.Closed Then
            MsgBox("EICA Is Offline" & vbCrLf & "You Have To Connect to EICA First", vbExclamation, Me.Text)
            Exit Sub
        End If
        Dim msgR As MsgBoxResult = MsgBox("Please Wait While Updating Folder Status", vbOKCancel, Me.Text)
        If msgR = MsgBoxResult.Cancel Then Exit Sub
        lP.UpdateFolderStatus()
    End Sub
End Class