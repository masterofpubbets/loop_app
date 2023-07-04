Public Class Reports

    Public Enum ReportTypes
        EICADAILYTRACKINGELEResources = 1
        EICADAILYTRACKINGINSResources = 2
    End Enum

    Public Overloads Function GetItems(ByVal reportType As ReportTypes) As DataTable
        Try
            Select Case reportType
                Case ReportTypes.EICADAILYTRACKINGELEResources
                    Return (DB.ReturnDataTable("EXEC DailyTrackingResourceAllEle"))
                Case ReportTypes.EICADAILYTRACKINGINSResources
                    Return (DB.ReturnDataTable("EXEC DailyTrackingResourceAllIns"))
            End Select

        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

End Class
