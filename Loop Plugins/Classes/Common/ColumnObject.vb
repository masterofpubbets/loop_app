Public Class ColumnObject

    Public Enum en_SystemType
        DataStrings = 1
        DataBit = 2
        DataInteger = 3
        DataDate = 4
        Int16 = 5
    End Enum
    Public Sub New(columnIndex As Integer, columnIdexName As String, columnName As String,
                   Optional ProStep As Boolean = False,
                   Optional columnDataType As en_SystemType = en_SystemType.DataStrings,
                   Optional columnAllowNull As Boolean = True)

        Me.Index = columnIndex
        Me.IndexName = columnIdexName
        Me.Name = columnName

        Select Case columnDataType
            Case en_SystemType.DataStrings
                Me.DataType = Type.GetType("System.String")
            Case en_SystemType.DataDate
                Me.DataType = Type.GetType("System.DateTime")
            Case en_SystemType.Int16
                Me.DataType = Type.GetType("System.Int16")
        End Select

        Me.AllowNull = columnAllowNull

    End Sub
    Public Property Index As Integer
    Public Property IndexName As String
    Public Property Name As String
    Public Property IsProductionStep As Boolean
    Public Property DataType As Type
    Public Property AllowNull As Boolean
End Class
