Imports System.ComponentModel

Public Class frmLoadCons
    Public LoadType As en_LoadType = en_LoadType.LoadConstraints

    Public Enum en_LoadType
        LoadConstraints = 1
        ClearConstraint = 2
    End Enum

    Private Sub LoadConstriants()
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Apply Loaded Constraints", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        pBar.Properties.Maximum = GridView3.RowCount
        pBar.EditValue = 0
        pBar.Visible = True
        For inx As Integer = 0 To GridView3.RowCount - 1
            If IsDBNull(GridView3.GetDataRow(inx).Item("Remarks")) Then
                DB.ExcuteNoneResult(String.Format("exec sp_AddLoopConstraint '{0}','{1}','{2}','{3}','{4}',null", GridView3.GetDataRow(inx).Item("LoopName"), GridView3.GetDataRow(inx).Item("Constraint"), GridView3.GetDataRow(inx).Item("Department"), GridView3.GetDataRow(inx).Item("ActionBy"), Format(GridView3.GetDataRow(inx).Item("ForecastDate"), "MM/dd/yyyy")))
            Else
                DB.ExcuteNoneResult(String.Format("exec sp_AddLoopConstraint '{0}','{1}','{2}','{3}','{4}','{5}'", GridView3.GetDataRow(inx).Item("LoopName"), GridView3.GetDataRow(inx).Item("Constraint"), GridView3.GetDataRow(inx).Item("Department"), GridView3.GetDataRow(inx).Item("ActionBy"), Format(GridView3.GetDataRow(inx).Item("ForecastDate"), "MM/dd/yyyy"), GridView3.GetDataRow(inx).Item("Remarks")))
            End If
            Application.DoEvents()
            pBar.EditValue = inx + 1
        Next
        MsgBox("Constraints Have Been Uploaded", MsgBoxStyle.Information, Me.Text)
        pBar.Visible = False
    End Sub
    Private Sub ClearConstriants()
        Dim msgR As MsgBoxResult = MsgBox("Do You Want To Apply Loaded Constraints", MsgBoxStyle.YesNo, Me.Text)
        If msgR = MsgBoxResult.No Then Exit Sub
        pBar.Properties.Maximum = GridView3.RowCount
        pBar.EditValue = 0
        pBar.Visible = True
        For inx As Integer = 0 To GridView3.RowCount - 1
            DB.ExcuteNoneResult(String.Format("exec sp_CloseLoopConstraintName '{0}'", GridView3.GetDataRow(inx).Item("LoopName")))
            Application.DoEvents()
            pBar.EditValue = inx + 1
        Next
        MsgBox("Constraints Have Been Cleared", MsgBoxStyle.Information, Me.Text)
        pBar.Visible = False
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            Select Case LoadType
                Case en_LoadType.LoadConstraints
                    LoadConstriants()
                Case en_LoadType.ClearConstraint
                    ClearConstriants()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Dim msgr As MsgBoxResult = MsgBox("Do You Want To Cancel The Operation", MsgBoxStyle.YesNo, Me.Text)
            If msgr = MsgBoxResult.Yes Then
                Exit Try
            End If
        End Try

    End Sub

    Private Sub frmLoadCons_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class