Public Class LoopMap
    Private Shared dtLoopMap As DataTable

    Public Sub New()
        If IsNothing(dtLoopMap) Then
            dtLoopMap = New DataTable
            dtLoopMap = DB.ReturnDataTable("EXEC PRECOMM.LoopMap")
        End If
    End Sub
    Public Overloads Shared ReadOnly Property LoopMap As DataTable
        Get
            Return dtLoopMap
        End Get
    End Property
    Public Overloads Shared ReadOnly Property LoopMap(subsystem As String) As DataTable
        Get
            Dim dr As DataRow()
            Dim dt As New DataTable

            For inx As Integer = 0 To dtLoopMap.Columns.Count - 1
                dt.Columns.Add(dtLoopMap.Columns.Item(inx).ColumnName, Type.GetType(dtLoopMap.Columns.Item(inx).DataType.FullName))
            Next

            dr = dtLoopMap.Select("Subsystem ='" & subsystem & "'")
            For Each r As DataRow In dr
                dt.Rows.Add(r.ItemArray)
            Next
            Return dt
        End Get
    End Property
    Public Overloads Shared ReadOnly Property LoopMap(subsystem As List(Of String)) As DataTable
        Get
            Dim dr As DataRow()
            Dim dt As New DataTable
            Dim q As String = "Subsystem IN ('"

            If subsystem.Count > 0 Then
                For Each item As String In subsystem
                    q &= item & "', '"
                Next
                q &= subsystem.Item(0) & "')"
                For inx As Integer = 0 To dtLoopMap.Columns.Count - 1
                    dt.Columns.Add(dtLoopMap.Columns.Item(inx).ColumnName, Type.GetType(dtLoopMap.Columns.Item(inx).DataType.FullName))
                Next

                dr = dtLoopMap.Select(q)
                For Each r As DataRow In dr
                    dt.Rows.Add(r.ItemArray)
                Next
            End If

            Return dt
        End Get
    End Property
End Class
