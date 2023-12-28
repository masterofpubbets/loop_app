Public Class Planning
    Private er As New PublicErrors

    Public Enum ItemsTypes
        PDSModelSummary = 1
    End Enum


    Public Overloads Function GetItems(ByVal itemType As ItemsTypes) As DataTable
        Try
            Select Case itemType
                Case ItemsTypes.PDSModelSummary
                    Return (DB.ReturnDataTable("EXEC PLANNING.GetPDSModelSummary"))
            End Select

        Catch ex As Exception
            er.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
End Class
