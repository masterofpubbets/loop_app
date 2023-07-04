Imports System.IO
Imports System.Windows.Controls

Public Class GridViews

    Public Function ApplyViewLayout(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fileName As String) As Boolean
        If IO.File.Exists(fileName) Then
            Try
                grdView.OptionsLayout.StoreAllOptions = True
                grdView.OptionsLayout.StoreAllOptions = True
                grdView.OptionsLayout.StoreAppearance = True
                grdView.OptionsLayout.StoreDataSettings = True
                grdView.OptionsLayout.StoreVisualOptions = True
                grdView.OptionsLayout.StoreFormatRules = True
                grdView.RestoreLayoutFromXml(fileName)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
        Return False
    End Function
    Private Function setViewIndex(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByRef dt As DataTable) As Boolean
        Try
            For inx As Integer = 0 To dt.Rows.Count - 1
                grdView.Columns(dt.Rows(inx).Item("Field Name")).Width = Val(dt.Rows(inx).Item("Width"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).AbsoluteIndex = Val(dt.Rows(inx).Item("AbsoluteIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).GroupIndex = Val(dt.Rows(inx).Item("GroupIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).SortIndex = Val(dt.Rows(inx).Item("SortIndex"))
                grdView.Columns(dt.Rows(inx).Item("Field Name")).VisibleIndex = Val(dt.Rows(inx).Item("VisibleIndex"))
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Overloads Function SaveViewLayout(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal viewName As String) As Boolean
        Try
            If IO.File.Exists(viewName) Then IO.File.Delete(viewName)
            grdView.OptionsLayout.StoreAllOptions = True
            grdView.OptionsLayout.StoreAllOptions = True
            grdView.OptionsLayout.StoreAppearance = True
            grdView.OptionsLayout.StoreDataSettings = True
            grdView.OptionsLayout.StoreVisualOptions = True
            grdView.OptionsLayout.StoreFormatRules = True
            grdView.SaveLayoutToXml(viewName)

            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function CopySelectedItems(ByRef grdView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal columnName As String) As Boolean
        Try
            Dim copied As String = ""
            For Each row_handle As Integer In grdView.GetSelectedRows
                copied &= grdView.GetDataRow(row_handle).Item(columnName) & vbCrLf
            Next
            Clipboard.Clear()
            Clipboard.SetText(copied)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

End Class
