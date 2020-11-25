Public Class frmFindItemByDiscipline
    Public Discipline As String = ""
    Public ItemTag As String = ""

    Private Sub GetEleCables(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select ec_id from tblEleCableList")
        Else
            DB.Fill(lst, String.Format("select ec_id from tblEleCableList where ec_id like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub GetEleEq(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select TAG from tblElectricalEquipment")
        Else
            DB.Fill(lst, String.Format("select TAG from tblElectricalEquipment where TAG like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub GetEleJB(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select TAG from tblEleJunctionBox")
        Else
            DB.Fill(lst, String.Format("select TAG from tblEleJunctionBox where TAG like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub GetInsCables(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select ic_id from tblInsCableList")
        Else
            DB.Fill(lst, String.Format("select ic_id from tblInsCableList where ic_id like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub GetInsJB(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select JunctionBox from JunctionBox")
        Else
            DB.Fill(lst, String.Format("select JunctionBox from JunctionBox where JunctionBox like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub GetIns(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select Instrument_Tag from tblInstruments")
        Else
            DB.Fill(lst, String.Format("select Instrument_Tag from tblInstruments where Instrument_Tag like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub GetInsEq(Optional ByVal Tag As String = "")
        If Tag = "" Then
            DB.Fill(lst, "select TAG from tblInsEquipment")
        Else
            DB.Fill(lst, String.Format("select TAG from tblInsEquipment where TAG like '%{0}%'", Tag))
        End If
    End Sub
    Private Sub Search()
        If rEleCable.Checked Then
            GetEleCables(txt.Text)
        End If
        If rEleEq.Checked Then
            GetEleEq(txt.Text)
        End If
        If rEleJB.Checked Then
            GetEleJB(txt.Text)
        End If
        If rInsCable.Checked Then
            GetInsCables(txt.Text)
        End If
        If rIns.Checked Then
            GetIns(txt.Text)
        End If
        If rInsJB.Checked Then
            GetInsJB(txt.Text)
        End If
        If rInsEq.Checked Then
            GetInsEq(txt.Text)
        End If
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ItemTag = ""
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Search()
    End Sub

    Private Sub txt_TextChanged(sender As Object, e As EventArgs) Handles txt.TextChanged
        If ckLive.Checked Then
            Search()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click, lst.DoubleClick
        Dim Dis As String = ""
        If rEleCable.Checked Then
            Dis = "Ele Cable"
        End If
        If rEleEq.Checked Then
            Dis = "Ele Eq"
        End If
        If rEleJB.Checked Then
            Dis = "Ele JB"
        End If
        If rInsCable.Checked Then
            Dis = "Ins Cable"
        End If
        If rIns.Checked Then
            Dis = "Instrument"
        End If
        If rInsJB.Checked Then
            Dis = "Ins JB"
        End If
        If rInsEq.Checked Then
            Dis = "Ins Eq"
        End If
        If lst.Items.Count = 0 Then
            If Trim(txt.Text) = "" Then
                MsgBox("Please type item tag", MsgBoxStyle.Exclamation, "Find Item")
                Exit Sub
            Else
                Dim msgR As MsgBoxResult = MsgBox(String.Format("Cannot find the item{0}{1}{0}In {2}{0}Do you want to select it anyway?", vbCrLf, txt.Text, Dis), MsgBoxStyle.YesNo, "Find Item")
                If msgR = MsgBoxResult.No Then Exit Sub
                ItemTag = txt.Text
                Discipline = Dis
                Me.Close()
            End If
        Else
            If lst.SelectedIndex = -1 Then
                MsgBox("Please select item from the list", MsgBoxStyle.Exclamation, "Find Item")
            Else
                ItemTag = lst.SelectedItem.ToString
                Discipline = Dis
                Me.Close()
            End If
        End If
    End Sub
End Class