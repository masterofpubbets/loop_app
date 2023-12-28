Imports System.ComponentModel
Imports DevExpress.XtraGrid.Columns

Public Class frmDataResult
    Private opKey As String
    Private resultType As en_ResultType
    Private dt As New DataTable
    Private grdView As New GridViews

    Public Enum en_ResultType
        LoopFolders = 1
        LoopPlanning = 2
        ItemTasks = 3
    End Enum

    Public Sub New(operationKey As String, item As en_ResultType, Optional ByRef resultDT As DataTable = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        opKey = operationKey
        resultType = item
        dt = resultDT
    End Sub

    Private Sub GetData()
        If Not IsNothing(dt) Then
            grd.DataSource = dt
            gv.BestFitColumns(True)
        End If
    End Sub

    Private Sub frmDataResult_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Results Filter"
        For inx As Integer = 0 To gv.Columns.Count - 1
            frm.cmbSearchIn.Items.Add(gv.Columns.Item(inx).FieldName)
        Next
        frm.ShowDialog(Me)
        If Not frm.isCancel Then
            Dim bc As String = ""
            If Not frm.Exact Then bc = "%"
            Dim _filter As String = ""
            For inx As Integer = 1 To frm.searchValues.Count
                If inx <> 1 Then
                    _filter &= String.Format("OR [{0}] LIKE '{2}{1}{2}'", frm.searchField, frm.searchValues.Item(inx), bc)
                Else
                    _filter = String.Format("[{0}] LIKE '{2}{1}{2}'", frm.searchField, frm.searchValues.Item(inx), bc)
                End If
            Next
            gv.Columns(frm.searchField).FilterInfo = New ColumnFilterInfo(_filter)
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            grd.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDataResult_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Select Case resultType
            Case en_ResultType.LoopFolders
                If MsgBox("Do you want to close the results" & vbCrLf & "All results operation will be deleted!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            Case en_ResultType.LoopPlanning
                If MsgBox("Do you want to close the results" & vbCrLf & "All results operation will be deleted!", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            Case Else
                e.Cancel = False
        End Select
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
    End Sub
End Class