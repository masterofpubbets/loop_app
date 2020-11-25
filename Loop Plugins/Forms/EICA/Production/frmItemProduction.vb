Public Class frmItemProduction

    Private sub GetData
        Select Case lblDis.Text
                Case "Ele Cable"
                    GetEleCableProduction(lblItem.Text)
                Case "Ins Cable"
                    GetInsCableProduction(lblItem.Text)
                Case "Ele Eq"
                    GetEEqProduction(lblItem.Text)
                Case "Ins Eq"
                    GetIEqProduction(lblItem.Text)
                Case "Ele JB"
                    GetEJBProduction(lblItem.Text)
                Case "Ins JB"
                    GetIJBProduction(lblItem.Text)
                Case "Instrument"
                    GetInsProduction(lblItem.Text)
            End Select
    End sub
    Private Sub GetEleCableProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where tag ='{1}'", My.Resources.EcPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub GetInsCableProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where tag ='{1}'", My.Resources.IcPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub GetEEqProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where tag ='{1}'", My.Resources.EEQPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub GetIEqProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where tag ='{1}'", My.Resources.IEQPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub GetEJBProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where tag ='{1}'", My.Resources.EJBPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub GetIJBProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where junctionbox ='{1}'", My.Resources.IJBPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub GetInsProduction(ByVal Tag As String)
        If GridView1.Columns.Count > 0 Then
            GridView1.Columns.Clear()
        End If
        Dim dt As New DataTable
        dt = DB.ReturnDataTable(String.Format("{0} where Instrument_Tag ='{1}'", My.Resources.InsPro, Tag))
        grd.DataSource = dt
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim frm As New frmFindItemByDiscipline
        frm.ShowDialog(Me)
        If frm.ItemTag <> "" Then
            lblItem.Text = frm.ItemTag
            lblDis.Text = frm.Discipline
            GetData
        End If
        frm = Nothing
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _itemType As Integer
        Select Case lblDis.Text
            Case "Ele Cable"
                _itemType = 1
            Case "Ins Cable"
                _itemType = 2
            Case "Ele Eq"
                _itemType = 3
            Case "Ins Eq"
                _itemType = 4
            Case "Ele JB"
                _itemType = 5
            Case "Ins JB"
                _itemType = 6
            Case "Instrument"
                _itemType = 7
        End Select
        Dim frm As New frmSelectStep(_itemType)
        frm.ShowDialog(Me)

        If frm.colSteps.Count<1
            frm=Nothing
            Exit Sub 
        End If

        Dim p As New Production

        If GridView1.RowCount = 0 Then
            If lblItem.Text = "No Item Found" Then
                MsgBox("Please select an item first", MsgBoxStyle.Exclamation, Me.Text)
                frm = Nothing
                Exit Sub
            Else
                'item not in eica
                Dim msgR As MsgBoxResult = MsgBox("This item not in EICA do you want to add production anyway?", MsgBoxStyle.YesNo, Me.Text)
                If msgR = MsgBoxResult.No Then Exit Sub
                For inx As Integer = 1 To frm.colSteps.Count
                    p.AddTempItem(lblItem.Text, lblDis.Text, frm.colSteps.Item(inx))
                Next
                MsgBox("Item has been send to EICA Team for review", MsgBoxStyle.Information, Me.Text)
            End If
        Else
            'Item in eica
            For inx As Integer = 1 To frm.colSteps.Count
                p.AddTempItem(lblItem.Text, lblDis.Text, frm.colSteps.Item(inx))
            Next
            'update production in eica itself
            DB.ExcuteNoneResult("exec ADDPRO_TEMP")
            MsgBox("Item has been updated in EICA", MsgBoxStyle.Information, Me.Text)
            GetData
        End If
        frm = Nothing
    End Sub
End Class