Public Class frmUsers
    Private user As New Users

    Private Sub GetData()
        grd.DataSource = user.GetUsers
        gv.BestFitColumns(True)
    End Sub

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Users.UsersDataChanged, AddressOf GetData
        GetData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmAddUser
        frm.ShowDialog(Me)
        If frm.isAdded Then GetData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        For Each row_handle As Integer In gv.GetSelectedRows
            Dim frm As New frmEditUser
            frm.txtUserName.Text = gv.GetDataRow(row_handle).Item("User Name")
            frm.txtName.Text = gv.GetDataRow(row_handle).Item("Full Name")
            frm.txtEmail.Text = gv.GetDataRow(row_handle).Item("EMail")

            frm.ckcmbUserType.EditValue = gv.GetDataRow(row_handle).Item("User Type")

            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "admin", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("Admin").CheckState = CheckState.Checked
            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "handover", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("Handover").CheckState = CheckState.Checked
            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "qc", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("QC").CheckState = CheckState.Checked
            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "precomm", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("Precomm").CheckState = CheckState.Checked
            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "construction", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("Construction").CheckState = CheckState.Checked
            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "planning", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("Planning").CheckState = CheckState.Checked
            If InStr(gv.GetDataRow(row_handle).Item("User Type"), "ReadOnly", CompareMethod.Text) Then frm.ckcmbUserType.Properties.Items.Item("ReadOnly").CheckState = CheckState.Checked

            frm.txtDepartment.Text = gv.GetDataRow(row_handle).Item("Department")
            frm.txtJob.Text = gv.GetDataRow(row_handle).Item("Job")
            frm.pic.Image = DB.GetImage("SELECT UserPhoto FROM LOOPS.tblUsers WHERE userName ='" & gv.GetDataRow(row_handle).Item("User Name") & "'")
            frm.txtTRUserName.Text = gv.GetDataRow(row_handle).Item("TRUserName")

            If InStr(gv.GetDataRow(row_handle).Item("Group"), "FolderPrepared", CompareMethod.Text) Then frm.ckFolderPrepared.Checked = True
            If InStr(gv.GetDataRow(row_handle).Item("Group"), "FolderApproved", CompareMethod.Text) Then frm.ckQCApproved.Checked = True
            If InStr(gv.GetDataRow(row_handle).Item("Group"), "FolderReady", CompareMethod.Text) Then frm.ckQCFolderReady.Checked = True
            If InStr(gv.GetDataRow(row_handle).Item("Group"), "SubmittedToPrecomm", CompareMethod.Text) Then frm.ckSubmittedToPrecomm.Checked = True
            If InStr(gv.GetDataRow(row_handle).Item("Group"), "LoopDone", CompareMethod.Text) Then frm.ckLoopDone.Checked = True

            frm.Text &= ": " & gv.GetDataRow(row_handle).Item("Full Name")
            frm.Show()
        Next
    End Sub
End Class