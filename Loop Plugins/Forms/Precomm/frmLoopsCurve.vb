Imports System.ComponentModel
Imports DevExpress.XtraCharts

Public Class frmLoopsCurve

    Private Sub InitiateChart()
        Dim dtSummary As New DataTable

        chrt.Series(0).DataSource = LoopPlanning.GetLoopCurve()
        chrt.Series(1).DataSource = LoopPlanning.GetLoopStatus

        ' Specify data members to bind the series.
        chrt.Series(0).ArgumentScaleType = ScaleType.DateTime
        chrt.Series(0).ArgumentDataMember = "Dates"
        chrt.Series(0).ValueScaleType = ScaleType.Numerical
        chrt.Series(0).ValueDataMembers.AddRange(New String() {"LoopsPerDay"})

        ' Specify data members to bind the series.
        chrt.Series(1).ArgumentScaleType = ScaleType.DateTime
        chrt.Series(1).ArgumentDataMember = "Done Date"
        chrt.Series(1).ValueScaleType = ScaleType.Numerical
        chrt.Series(1).ValueDataMembers.AddRange(New String() {"Total Done"})


        ' Set some properties to get a nice-looking chart.
        'CType(series.View, SideBySideBarSeriesView).ColorEach = True
        CType(chrt.Diagram, XYDiagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False
        chrt.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True

    End Sub
    Private Sub frmLoopsCurve_Load(sender As Object, e As EventArgs) Handles Me.Load
        InitiateChart()



    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        chrt.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        InitiateChart()
    End Sub

    Private Sub frmLoopsCurve_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class