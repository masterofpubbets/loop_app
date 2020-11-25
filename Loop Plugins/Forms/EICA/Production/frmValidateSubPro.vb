Imports DevExpress.Data

Public Class frmValidateSubPro
    Private common_DT As New DataTable
    Private common_Builder As SqlClient.SqlCommandBuilder
    Private common_Cmd As New SqlClient.SqlCommand(My.Resources.ICCableValidate, DB.DBConnection)
    Private common_DA As New SqlClient.SqlDataAdapter(common_Cmd)

    Private ic_DT As New DataTable
    Private ic_Builder As SqlClient.SqlCommandBuilder
    Private ic_cmd As New SqlClient.SqlCommand(My.Resources.ICCableValidate, DB.DBConnection)
    Private ic_DA As New SqlClient.SqlDataAdapter(ic_cmd)

    Private ec_DT As New DataTable
    Private ec_Builder As SqlClient.SqlCommandBuilder
    Private ec_cmd As New SqlClient.SqlCommand(My.Resources.ECCableValidate, DB.DBConnection)
    Private ec_DA As New SqlClient.SqlDataAdapter(ec_cmd)

    Private eeq_DT As New DataTable
    Private eeq_Builder As SqlClient.SqlCommandBuilder
    Private eeq_cmd As New SqlClient.SqlCommand(My.Resources.EEqValidate, DB.DBConnection)
    Private eeq_DA As New SqlClient.SqlDataAdapter(eeq_cmd)

    Private ieqDT As New DataTable
    Private ieqBuilder As SqlClient.SqlCommandBuilder
    Private ieqcmd As New SqlClient.SqlCommand(My.Resources.IEqValidate, DB.DBConnection)
    Private ieqDA As New SqlClient.SqlDataAdapter(ieqcmd)

    Private ejb_DT As New DataTable
    Private ejb_Builder As SqlClient.SqlCommandBuilder
    Private ejb_cmd As New SqlClient.SqlCommand(My.Resources.EJBValidate, DB.DBConnection)
    Private ejb_DA As New SqlClient.SqlDataAdapter(ejb_cmd)

    Private ijb_DT As New DataTable
    Private ijb_Builder As SqlClient.SqlCommandBuilder
    Private ijb_cmd As New SqlClient.SqlCommand(My.Resources.IJBValidate, DB.DBConnection)
    Private ijb_DA As New SqlClient.SqlDataAdapter(ijb_cmd)

    Private ins_DT As New DataTable
    Private ins_Builder As SqlClient.SqlCommandBuilder
    Private ins_cmd As New SqlClient.SqlCommand(My.Resources.InsValidate, DB.DBConnection)
    Private ins_DA As New SqlClient.SqlDataAdapter(ins_cmd)


    Private Sub GetLoopCardData()
        grdLoop.DataSource = DB.ReturnDataTable(My.Resources.Loop_Map)
    End Sub
    Private Sub GetData_IEq_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.IEqValidate, "order by Area,TAG", String.Format(" where tag='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 8
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(7).OptionsColumn.AllowEdit = True
        gvItem.Columns(7).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_Ins_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.InsValidate, "order by Area,Instrument_Tag", String.Format(" where Instrument_Tag='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 15
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(9).OptionsColumn.AllowEdit = True
        gvItem.Columns(9).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(11).OptionsColumn.AllowEdit = True
        gvItem.Columns(11).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(14).OptionsColumn.AllowEdit = True
        gvItem.Columns(14).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub

    Private Sub GetData_IJB_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.IJBValidate, "order by Area,JunctionBox", String.Format(" where JunctionBox='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 7
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(6).OptionsColumn.AllowEdit = True
        gvItem.Columns(6).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_EEq_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.EEqValidate, "order by Area,TAG", String.Format(" where TAG='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 8
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(7).OptionsColumn.AllowEdit = True
        gvItem.Columns(7).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_EJB_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.EJBValidate, "order by Area,TAG", String.Format(" where TAG='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 7
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(6).OptionsColumn.AllowEdit = True
        gvItem.Columns(6).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_IC_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.ICCableValidate, "order by [tblInsCableList].Area,[IC_ID]", String.Format(" where IC_ID='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 18
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(11).OptionsColumn.AllowEdit = True
        gvItem.Columns(11).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(13).OptionsColumn.AllowEdit = True
        gvItem.Columns(13).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(15).OptionsColumn.AllowEdit = True
        gvItem.Columns(15).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(17).OptionsColumn.AllowEdit = True
        gvItem.Columns(17).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_EC_Loop(ByVal Item As String)
        common_Cmd = New SqlClient.SqlCommand(Replace(My.Resources.ECCableValidate, "order by [tblEleCableList].Area,[EC_ID]", String.Format(" where EC_ID='{0}'", Item),, CompareMethod.Text), DB.DBConnection)
        common_DA = New SqlClient.SqlDataAdapter(common_Cmd)

        common_DT = New DataTable
        common_DA.Fill(common_DT)
        common_Builder = New SqlClient.SqlCommandBuilder(common_DA)
        common_DA.UpdateCommand = common_Builder.GetUpdateCommand

        gvItem.Columns.Clear()
        grdItem.DataSource = common_DT

        For inx As Integer = 0 To 17
            gvItem.Columns(inx).OptionsColumn.AllowEdit = False
            gvItem.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvItem.Columns(10).OptionsColumn.AllowEdit = True
        gvItem.Columns(10).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(12).OptionsColumn.AllowEdit = True
        gvItem.Columns(12).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(14).OptionsColumn.AllowEdit = True
        gvItem.Columns(14).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvItem.Columns(16).OptionsColumn.AllowEdit = True
        gvItem.Columns(16).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_Ins()
        ins_DT = New DataTable
        ins_DA.Fill(ins_DT)
        ins_Builder = New SqlClient.SqlCommandBuilder(ins_DA)
        ins_DA.UpdateCommand = ins_Builder.GetUpdateCommand
        grdIns.DataSource = ins_DT

        For inx As Integer = 0 To 15
            gvIns.Columns(inx).OptionsColumn.AllowEdit = False
            gvIns.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvIns.Columns(9).OptionsColumn.AllowEdit = True
        gvIns.Columns(9).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvIns.Columns(11).OptionsColumn.AllowEdit = True
        gvIns.Columns(11).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvIns.Columns(14).OptionsColumn.AllowEdit = True
        gvIns.Columns(14).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_IJB()
        ijb_DT = New DataTable
        ijb_DA.Fill(ijb_DT)
        ijb_Builder = New SqlClient.SqlCommandBuilder(ijb_DA)
        ijb_DA.UpdateCommand = ijb_Builder.GetUpdateCommand
        grdIJB.DataSource = ijb_DT

        For inx As Integer = 0 To 7
            gvIJB.Columns(inx).OptionsColumn.AllowEdit = False
            gvIJB.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvIJB.Columns(6).OptionsColumn.AllowEdit = True
        gvIJB.Columns(6).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub
    Private Sub GetData_EJB()
        ejb_DT = New DataTable
        ejb_DA.Fill(ejb_DT)
        ejb_Builder = New SqlClient.SqlCommandBuilder(ejb_DA)
        ejb_DA.UpdateCommand = ejb_Builder.GetUpdateCommand
        grdEJB.DataSource = ejb_DT

        For inx As Integer = 0 To 7
            gvEJB.Columns(inx).OptionsColumn.AllowEdit = False
            gvEJB.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvEJB.Columns(6).OptionsColumn.AllowEdit = True
        gvEJB.Columns(6).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub

    Private Sub GetData_IEq()
        ieqDT = New DataTable
        ieqDA.Fill(ieqDT)
        ieqBuilder = New SqlClient.SqlCommandBuilder(ieqDA)
        ieqDA.UpdateCommand = ieqBuilder.GetUpdateCommand
        grdIEq.DataSource = ieqDT

        For inx As Integer = 0 To 8
            gvIEq.Columns(inx).OptionsColumn.AllowEdit = False
            gvIEq.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvIEq.Columns(7).OptionsColumn.AllowEdit = True
        gvIEq.Columns(7).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub

    Private Sub GetData_EEq()
        eeq_DT = New DataTable
        eeq_DA.Fill(eeq_DT)
        eeq_Builder = New SqlClient.SqlCommandBuilder(eeq_DA)
        eeq_DA.UpdateCommand = eeq_Builder.GetUpdateCommand
        grdEEq.DataSource = eeq_DT

        For inx As Integer = 0 To 8
            gvEEq.Columns(inx).OptionsColumn.AllowEdit = False
            gvEEq.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvEEq.Columns(7).OptionsColumn.AllowEdit = True
        gvEEq.Columns(7).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub

    Private Sub GetData_IC()
        ic_DT = New DataTable
        ic_DA.Fill(ic_DT)
        ic_Builder = New SqlClient.SqlCommandBuilder(ic_DA)
        ic_DA.UpdateCommand = ic_Builder.GetUpdateCommand
        grdInsCable.DataSource = ic_DT

        For inx As Integer = 0 To 18
            gvIC.Columns(inx).OptionsColumn.AllowEdit = False
            gvIC.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvIC.Columns(11).OptionsColumn.AllowEdit = True
        gvIC.Columns(11).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvIC.Columns(13).OptionsColumn.AllowEdit = True
        gvIC.Columns(13).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvIC.Columns(15).OptionsColumn.AllowEdit = True
        gvIC.Columns(15).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvIC.Columns(17).OptionsColumn.AllowEdit = True
        gvIC.Columns(17).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub

    Private Sub GetData_EC()
        ec_DT = New DataTable
        ec_DA.Fill(ec_DT)
        ec_Builder = New SqlClient.SqlCommandBuilder(ec_DA)
        ec_DA.UpdateCommand = ec_Builder.GetUpdateCommand
        grdEC.DataSource = ec_DT

        For inx As Integer = 0 To 17
            gvEC.Columns(inx).OptionsColumn.AllowEdit = False
            gvEC.Columns(inx).AppearanceCell.BackColor = Color.LightGray
        Next
        gvEC.Columns(10).OptionsColumn.AllowEdit = True
        gvEC.Columns(10).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvEC.Columns(12).OptionsColumn.AllowEdit = True
        gvEC.Columns(12).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvEC.Columns(14).OptionsColumn.AllowEdit = True
        gvEC.Columns(14).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gvEC.Columns(16).OptionsColumn.AllowEdit = True
        gvEC.Columns(16).AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
    End Sub

    Private Sub frmValidatePro_Load(sender As Object, e As EventArgs) Handles Me.Load
        NavigationPane1.SelectedPageIndex = 7
        Application.DoEvents()
        GetLoopCardData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Save Changes?", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        Select Case NavigationPane1.SelectedPage.Caption
            Case "Instrument Cables"
                gvIC.CloseEditor()
                gvIC.UpdateCurrentRow()
                ic_DA.Update(ic_DT)
            Case "Electrical Cables"
                gvEC.CloseEditor()
                gvEC.UpdateCurrentRow()
                ec_DA.Update(ec_DT)
            Case "Electrical Equipment"
                gvEEq.CloseEditor()
                gvEEq.UpdateCurrentRow()
                eeq_DA.Update(eeq_DT)
            Case "Instrument Equipment"
                gvIEq.CloseEditor()
                gvIEq.UpdateCurrentRow()
                ieqDA.Update(ieqDT)
            Case "Electrical JB"
                gvEJB.CloseEditor()
                gvEJB.UpdateCurrentRow()
                ejb_DA.Update(ejb_DT)
            Case "Instrument JB"
                gvIJB.CloseEditor()
                gvIJB.UpdateCurrentRow()
                ijb_DA.Update(ijb_DT)
            Case "Instruments"
                gvIns.CloseEditor()
                gvIns.UpdateCurrentRow()
                ins_DA.Update(ins_DT)
        End Select
    End Sub

    Private Sub NavigationPane1_SelectedPageIndexChanged(sender As Object, e As EventArgs) Handles NavigationPane1.SelectedPageIndexChanged
        Select Case NavigationPane1.SelectedPage.Caption
            Case "Instrument Cables"
                GetData_IC()
            Case "Electrical Cables"
                GetData_EC()
            Case "Electrical Equipment"
                GetData_EEq()
            Case "Instrument Equipment"
                GetData_IEq()
            Case "Electrical JB"
                GetData_EJB()
            Case "Instrument JB"
                GetData_IJB()
            Case "Instruments"
                GetData_Ins()
            Case "Filter By Loops"
                'GetLoopCardData()
        End Select
    End Sub

    Private Sub gvLoop_Click(sender As Object, e As EventArgs) Handles gvLoop.Click
        For Each row_handle As Integer In gvLoop.GetSelectedRows
            Select Case gvLoop.GetDataRow(row_handle).Item("Discipline").ToString
                Case "Instrument Equipment"
                    GetData_IEq_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
                Case "Instruments"
                    GetData_Ins_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
                Case "Instrument JB"
                    GetData_IJB_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
                Case "Electrical Equipment"
                    GetData_EEq_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
                Case "Electrical JB"
                    GetData_EJB_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
                Case "Instrument Cable"
                    GetData_IC_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
                Case "Electrical Cable"
                    GetData_EC_Loop(gvLoop.GetDataRow(row_handle).Item("Item").ToString)
            End Select
        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        gvItem.CloseEditor()
        gvItem.UpdateCurrentRow()
        common_DA.Update(common_DT)
        MsgBox("Updated", MsgBoxStyle.Information, Me.Text)
    End Sub
End Class