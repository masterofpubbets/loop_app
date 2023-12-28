Imports DevExpress.Spreadsheet
Imports DevExpress.Spreadsheet.Export
Imports DevExpress.XtraSpreadsheet
'Imports Microsoft.Office.Interop.Excel
Imports Worksheet = DevExpress.Spreadsheet.Worksheet

Public Class DevExpressUserSpreadSheet
    Public Event err(errorMessage As String)
    Private Sub exporter_CellValueConversionError(ByVal sender As Object, ByVal e As CellValueConversionErrorEventArgs)
        RaiseEvent err("Error in cell " & e.Cell.GetReferenceA1())
        e.DataTableValue = Nothing
        e.Action = DataTableExporterAction.Continue
    End Sub
    Public Sub disableAddNewSheet(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl)
        sheet.Options.Behavior.Worksheet.Insert = DocumentCapability.Disabled
    End Sub
    Public Overloads Sub autoFilterActiveSheet(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal firstColumn As String, ByVal lastColumn As String)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        Dim range As CellRange = worksheet(firstColumn & ":" & lastColumn)
        worksheet.AutoFilter.Apply(range)
    End Sub
    Public Overloads Sub autoFilterActiveSheet(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal firstColumn As Integer, ByVal lastColumn As Integer)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        Dim range As CellRange = worksheet(firstColumn, lastColumn)
        worksheet.AutoFilter.Apply(range)
    End Sub
    Public Overloads Sub autoColumnsFitActiveSheet(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal firstColumn As String, ByVal lastColumn As String)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        worksheet.Columns.AutoFit(firstColumn, lastColumn)
    End Sub
    Public Overloads Sub autoColumnsFitActiveSheet(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal firstColumn As Integer, ByVal lastColumn As Integer)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        worksheet.Columns.AutoFit(firstColumn, lastColumn)
    End Sub
    Public Sub renameActiveSheet(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal name As String)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        worksheet.Name = name
    End Sub
    Public Overloads Sub setActiveSheetValue(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal cellName As String, ByVal value As String)
        Try
            Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
            worksheet.Cells(cellName).Value = value
        Catch ex As Exception
            RaiseEvent err(ex.Message)
        End Try
    End Sub
    Public Overloads Sub setActiveSheetValue(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, rowInx As Integer, colInx As Integer, value As String)
        Try
            sheet.Document.Worksheets.ActiveWorksheet.Item(rowInx, colInx).SetValue(value)
        Catch ex As Exception
            RaiseEvent err(ex.Message)
        End Try
    End Sub
    Public Overloads Function convertActiveSheetToDatatable(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl) As DataTable
        Try
            Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
            'worksheet.Selection = worksheet.Range("B3:F9")
            ' Dim range As CellRange = worksheet.Selection
            Dim range As CellRange = worksheet.GetUsedRange()
            Dim rangeHasHeaders As Boolean = True

            ' Create a data table with column names obtained from the first row in a range if it has headers.
            ' Column data types are obtained from cell value types of cells in the first data row of the worksheet range.
            Dim dataTable As New System.Data.DataTable
            dataTable = worksheet.CreateDataTable(range, rangeHasHeaders)
            For col As Integer = 0 To range.ColumnCount - 1
                Dim cellType As CellValueType = range(0, col).Value.Type
                For r As Integer = 1 To range.RowCount - 1
                    If cellType <> range(r, col).Value.Type Then
                        dataTable.Columns(col).DataType = GetType(String)
                        Exit For
                    End If
                Next r
            Next col

            ' Create the exporter that obtains data from the specified range, 
            ' skips the header row (if required) and populates the previously created data table. 
            Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dataTable, rangeHasHeaders)
            ' Handle value conversion errors.
            AddHandler exporter.CellValueConversionError, AddressOf exporter_CellValueConversionError
            ' Perform the export.
            exporter.Export()
            Return dataTable
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Overloads Function convertActiveSheetToDatatable(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, sheetName As String) As DataTable
        Try
            Dim worksheet As Worksheet = sheet.Document.Worksheets.Item(sheetName)
            'worksheet.Selection = worksheet.Range("B3:F9")
            ' Dim range As CellRange = worksheet.Selection
            Dim range As CellRange = worksheet.GetUsedRange()
            Dim rangeHasHeaders As Boolean = True

            ' Create a data table with column names obtained from the first row in a range if it has headers.
            ' Column data types are obtained from cell value types of cells in the first data row of the worksheet range.
            Dim dataTable As New System.Data.DataTable
            dataTable = worksheet.CreateDataTable(range, rangeHasHeaders)
            For col As Integer = 0 To range.ColumnCount - 1
                Dim cellType As CellValueType = range(0, col).Value.Type
                For r As Integer = 1 To range.RowCount - 1
                    If cellType <> range(r, col).Value.Type Then
                        dataTable.Columns(col).DataType = GetType(String)
                        Exit For
                    End If
                Next r
            Next col

            ' Create the exporter that obtains data from the specified range, 
            ' skips the header row (if required) and populates the previously created data table. 
            Dim exporter As DataTableExporter = worksheet.CreateDataTableExporter(range, dataTable, rangeHasHeaders)
            ' Handle value conversion errors.
            AddHandler exporter.CellValueConversionError, AddressOf exporter_CellValueConversionError
            ' Perform the export.
            exporter.Export()
            Return dataTable
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function ColumnExists(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, name As String) As Boolean
        Try
            Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
            Dim range As CellRange = worksheet.GetUsedRange()

            For col As Integer = 0 To range.ColumnCount - 1
                If name = range(0, col).Value Then
                    Return True
                End If
            Next col
            Return False
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Sub RemoveEmptyColumnHeader(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        Dim range As CellRange = worksheet.GetUsedRange()

        For col As Integer = 0 To range.ColumnCount - 1
            If range(0, col).Value.IsEmpty Then
                worksheet.Columns.Remove(col)
            End If
        Next col
    End Sub
    Public Sub RemoveEmptyColumnHeader(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, ByVal colIndex As Integer)
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        Dim range As CellRange = worksheet.GetUsedRange()

        For col As Integer = 0 To colIndex
            If sheet.Document.Worksheets.ActiveWorksheet.Columns.Item(col).Item(0).Value.IsEmpty Then
                worksheet.Columns.Remove(col)
            End If
        Next col
    End Sub
    Public Function GetColumnIndex(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, colName As String) As Integer
        Dim worksheet As Worksheet = sheet.Document.Worksheets.ActiveWorksheet
        Dim range As CellRange = worksheet.GetUsedRange()

        For col As Integer = 0 To range.ColumnCount - 1
            If Not range(0, col).Value.IsEmpty Then
                If range(0, col).Value.ToString = colName Then
                    Return col
                End If
            End If
        Next col
        Return -1
    End Function
    Public Function GetFirstColumnEmptyIndex(ByRef sheet As DevExpress.XtraSpreadsheet.SpreadsheetControl, Optional Startindex As Integer = 0) As Integer
        If Startindex > 100 Then
            Return 100
        Else
            If sheet.Document.Worksheets.ActiveWorksheet.Item(0, Startindex).Value.IsEmpty Then
                Return Startindex
            Else
                Return GetFirstColumnEmptyIndex(sheet, Startindex + 1)
            End If
        End If
        Return Startindex
    End Function
End Class
