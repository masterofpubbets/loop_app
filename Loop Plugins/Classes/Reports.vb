Public Class Reports

    Public Enum ReportTypes
        EICADAILYTRACKINGELEResources = 1
        EICADAILYTRACKINGINSResources = 2
        LOOPSUMMARY = 3
        EICAITRCLOSED = 4
        LOOPBLOCKAGERESPONSIBLE = 5
        SubsystemDailyTracking = 6
    End Enum

    Public Overloads Function GetItems(ByVal reportType As ReportTypes) As DataTable
        Try
            Select Case reportType
                Case ReportTypes.EICADAILYTRACKINGELEResources
                    Return (DB.ReturnDataTable("EXEC DailyTrackingResourceAllEle"))
                Case ReportTypes.EICADAILYTRACKINGINSResources
                    Return (DB.ReturnDataTable("EXEC DailyTrackingResourceAllIns"))
                Case ReportTypes.LOOPSUMMARY
                    Return (DB.ReturnDataTable("EXEC LOOPS.GetSummary"))
                Case ReportTypes.EICAITRCLOSED
                    Return (DB.ReturnDataTableExcuteFromFile(Application.StartupPath & "\sqries\PendingItems.txt"))
                Case ReportTypes.LOOPBLOCKAGERESPONSIBLE
                    Return (DB.ReturnDataTableExcuteFromFile(Application.StartupPath & "\sqries\LoopFolderBlockageRespSummary.txt"))
                Case ReportTypes.SubsystemDailyTracking
                    Return (DB.ReturnDataTable("EXEC [dbo].[DailyTrackingSubsystem]"))
            End Select

        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

End Class
