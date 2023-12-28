Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraSplashScreen
Public Class frmSelectActId
    Private Acts As New Activities
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Public ActId As String = ""
    Public Area As String = ""
    Public isSelect As Boolean = False
    Private grdView As New GridViews
    Private opnedHandle As IOverlaySplashScreenHandle

    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
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
    Private Sub GetData()
        saveColumnsWidth()
        grd.DataSource = Acts.GetItems(Construction.ItemsTypes.ACTIVITIES)
        formatColumnsWidth()

        gv.OptionsSelection.MultiSelect = True

        gv.Columns("PCS Budget").AppearanceCell.BackColor = Color.FromArgb(182, 173, 144)
        gv.Columns("EICA Budget").AppearanceCell.BackColor = Color.FromArgb(194, 197, 170)
        gv.Columns("Done").AppearanceCell.BackColor = Color.FromArgb(164, 172, 134)
        gv.Columns("Id").Visible = False

        gv.BestFitColumns()

        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
        gv.BestFitColumns(True)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub frmSelectActId_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetData()
        Try
            If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & "Activities", "")) Then
                grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & "Activities", ""))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If gv.GetSelectedRows.Count = 0 Then
            MsgBox("You have to select an Activity!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        ActId = gv.GetDataRow(row_handle).Item("ActID")
        Area = gv.GetDataRow(row_handle).Item("EICA Area")
        isSelect = True
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ShowProgressPanel()
        GetData()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        opnFle.FileName = ""
        opnFle.ShowDialog()
        Try
            If opnFle.FileName <> "" Then
                grdView.ApplyViewLayout(gv, opnFle.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        grdView.CopySelectedItems(gv, "ActID")
        Me.Close()
    End Sub
End Class