Imports DevExpress.XtraGrid.Columns

Public Class frmSelectUser
    Private user As New Users
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Public selectedUserName As String = ""
    Public selectedUserId As Integer = -1
    Public selectedUsermail As String = ""

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
        grd.DataSource = user.GetUsers
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub

        gv.Columns("Full Name").AppearanceCell.BackColor = Color.LightGray


        gv.OptionsSelection.MultiSelect = False


        If _filter <> "" Then
            gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
        End If
        gv.BestFitColumns(True)

    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If gv.RowCount = 0 Then Exit Sub
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        If row_handle < 0 Then Exit Sub
        selectedUserName = gv.GetDataRow(row_handle).Item("Full Name")
        selectedUserId = gv.GetDataRow(row_handle).Item("Id")
        selectedUsermail = gv.GetDataRow(row_handle).Item("EMail")
        Me.Close()
    End Sub

    Private Sub frmSelectUser_Load(sender As Object, e As EventArgs) Handles Me.Load
        getData()
    End Sub
End Class