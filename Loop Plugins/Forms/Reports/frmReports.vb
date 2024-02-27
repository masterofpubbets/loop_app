Imports System.ComponentModel
Imports DevExpress.XtraGrid.Columns
Public Class frmReports
    Private rptType As Reports.ReportTypes
    Private rpt As New Reports
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews

    Public Sub New(ByVal ReportType As Reports.ReportTypes)

        ' This call is required by the designer.
        InitializeComponent()
        rptType = ReportType
        Select Case rptType
            Case Reports.ReportTypes.EICAITRCLOSED
                barClipboardTag.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Me.Text = "ITR Closed"
            Case Reports.ReportTypes.LOOPSUMMARY
                Me.Text = "Loop Folder Summary"
            Case Reports.ReportTypes.EICADAILYTRACKINGINSResources
                Me.Text = "IN Resource Daily Tracking"
            Case Reports.ReportTypes.EICADAILYTRACKINGELEResources
                Me.Text = "EL Resource Daily Tracking"
        End Select
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub formatColumnsWidth()
        Try
            If IsNothing(colWidth) Then
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = 100
                Next
            Else
                gv.FocusedRowHandle = focusedRowHandler
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = colWidth.Item(inx)
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub saveColumnsWidth()
        Try
            If gv.RowCount <> 0 Then
                focusedRowHandler = gv.FocusedRowHandle

                If IsNothing(colWidth) Then
                    colWidth = New Collection
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                Else
                    colWidth.Clear()
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub getData()
        saveColumnsWidth()
        grd.DataSource = rpt.GetItems(rptType)
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.OptionsSelection.MultiSelect = True


        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
        gv.BestFitColumns(True)

    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        getData()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        getData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
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

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        grd.ShowPrintPreview()
    End Sub

    Private Sub frmReports_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        grdView.CopySelectedItems(gv, "Tag")
    End Sub
End Class