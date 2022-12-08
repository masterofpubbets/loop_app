Imports DevExpress.XtraCharts
Public Class frmLoopStepStatus
    Private Sub frmLoopStepStatus_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub GetDiff()
        grdInsPP.DataSource = DB.ReturnDataTable(My.Resources.DiffQCPrecomm)
        grd2.DataSource = DB.ReturnDataTable(My.Resources.LoopCalculationSummary)
    End Sub
    Private Sub GetData()
        Dim pTarget0(0) As Double
        Dim pTarget1(0) As Double
        Dim pTarget2(0) As Double
        Dim pTarget3(0) As Double
        Dim pTarget4(0) As Double
        Dim dt As New DataTable

        dt = DB.ReturnDataTable(My.Resources.LoopsSteps)
        Dim dr As DataRow() = dt.Select("type='TR_Loop_Folder_QC_Release'")

        Chrt.Series("QC Released").Points.Clear()
        Chrt.Series("HCS Folder Ready").Points.Clear()
        Chrt.Series("Submitted To Precomm").Points.Clear()
        Chrt.Series("Loop Done").Points.Clear()
        Chrt.Series("Precomm Constraints").Points.Clear()

        'QC Released
        For inx As Integer = 3 To dt.Columns.Count - 1
            pTarget1(0) = dr(0).Item(inx)
            Chrt.Series("QC Released").Points.Add(New SeriesPoint(dt.Columns(inx).ColumnName, pTarget1(0)))
            Application.DoEvents()
        Next
        'HCS_Folder_Ready
        dr = dt.Select("type='HCS_Folder_Ready'")
        For inx As Integer = 3 To dt.Columns.Count - 1
            pTarget1(0) = dr(0).Item(inx)
            Chrt.Series("HCS Folder Ready").Points.Add(New SeriesPoint(dt.Columns(inx).ColumnName, pTarget1(0)))
            Application.DoEvents()
        Next
        'HCS_Folder_Ready
        dr = dt.Select("type='Submitted_to_Precom'")
        For inx As Integer = 3 To dt.Columns.Count - 1
            pTarget1(0) = dr(0).Item(inx)
            Chrt.Series("Submitted To Precomm").Points.Add(New SeriesPoint(dt.Columns(inx).ColumnName, pTarget1(0)))
            Application.DoEvents()
        Next
        'HCS_Folder_Ready
        dr = dt.Select("type='Loop Test'")
        For inx As Integer = 3 To dt.Columns.Count - 1
            pTarget1(0) = dr(0).Item(inx)
            Chrt.Series("Loop Done").Points.Add(New SeriesPoint(dt.Columns(inx).ColumnName, pTarget1(0)))
            Application.DoEvents()
        Next
        'Precomm Constraints
        dr = dt.Select("type='Diff QC_Release And Loop Done'")
        For inx As Integer = 3 To dt.Columns.Count - 1
            pTarget1(0) = dr(0).Item(inx)
            Chrt.Series("Precomm Constraints").Points.Add(New SeriesPoint(dt.Columns(inx).ColumnName, Chrt.Series("Loop Done").Points.Item(inx - 3).Values(0), Chrt.Series("QC Released").Points.Item(inx - 3).Values(0), Chrt.Series("Loop Done").Points.Item(inx - 3).Values(0), pTarget1(0)))
            Application.DoEvents()
        Next
        GetDiff()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GetData()
    End Sub
End Class