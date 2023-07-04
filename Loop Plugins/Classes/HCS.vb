Public Class HCS
    Public Event ProgressIndex(ByVal cnt As Integer)
    Public Event ProgressDataCount(ByVal cnt As Integer)
    Public Event Err(ByVal errmsg As String)
    Public Event ProductionUpdated()
    Private ex As New EAMS.MSOffice.Excel, dt As New DataTable
    Public Event HCSRestoreStatus(ByVal s As String)
    Public Event EICAItemsUpdated()


    Public Sub New()
        AddHandler ex.Err, AddressOf OnErr
    End Sub

    Public Enum e_DataType
        ElectricalCables = 1
        JunctionBox = 2
        MaterialsArrivals = 3
        SubSystem = 6
        System = 7
        Instruments = 8
        TestPacks = 9
        NoActualLength = 10
        LOOPS = 11
        Motors = 13
        ElectricalEquipment = 15
        InstrumentsCable = 16
        InstrumentEquipment = 17
        ElectricalJB = 18
        P6Activity = 19
        QAQC = 20
        ElectricalCableTray = 22
        LightingCables = 23
        LightingFixture = 24
        SubContractor = 25
        Unit = 26
        Area = 27
        InstrumentCableTray = 28
        ForeCastDate = 29
        Groups = 30
        CacheMaterial = 31
        Projects = 33
        ILD = 34
        InTools = 35
        Sequence = 36
        PartialEleCableTray = 37
        PartialInsCableTray = 38
        EleDrum = 39
        InsDrum = 40
        Block = 41
        AssignDrums = 42
        ProjectElements = 43
        ProjectGroups = 44
        ProjectItems = 45
        ProjectPunchs = 46
        ProjectSubsystems = 47
        ProjectSystems = 48
        ProjectTasks = 49
    End Enum
    Private Sub OnErr(ByVal msg As String)
        RaiseEvent Err(msg)
    End Sub

#Region "Restore HCS"
    Private Sub TruncateHCSTables(ByVal TableName As e_DataType)
        Dim tblName As String = ""
        Try
            Select Case TableName
                Case e_DataType.ProjectElements
                    tblName = "Elements"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectElements")
                Case e_DataType.ProjectGroups
                    tblName = "Groups"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectGroups")
                Case e_DataType.ProjectItems
                    tblName = "Items"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectItems")
                Case e_DataType.ProjectPunchs
                    tblName = "Punchs"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectPunchs")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectPunchs] ALTER column [SignedByTR] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectPunchs] ALTER column [SignedBySubcon] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectPunchs] ALTER column [SignedByClient] NVARCHAR(100)")
                Case e_DataType.ProjectSubsystems
                    tblName = "Subsystems"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectSubsystems")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [Data3] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [Data4] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [Data5] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [Data6] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [Data7] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [Data8] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [TargetDate] NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectSubsystems] ALTER column [PlanningDate] NVARCHAR(100)")
                Case e_DataType.ProjectSystems
                    tblName = "Systems"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectSystems")
                Case e_DataType.ProjectTasks
                    tblName = "Tasks"
                    DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].ProjectTasks")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectTasks] ALTER column SignedByClient NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectTasks] ALTER column SignedBySubcon NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectTasks] ALTER column SignedByTR NVARCHAR(100)")
                    DB.ExcuteNoneResult("ALTER TABLE [HCS].[ProjectTasks] ALTER column Printdate NVARCHAR(100)")
            End Select
            RaiseEvent HCSRestoreStatus(tblName & " Has Been Cleared")
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
            RaiseEvent HCSRestoreStatus(tblName & " Cleared Failed")
        End Try
    End Sub
    Private Sub RestoreData(ByVal TableName As e_DataType, FilePath As String, ByVal SheetName As String, ByVal BatchSize As Integer)
        Try
            Dim DT As New DataTable
            Dim exl As New EAMS.MSOffice.Excel
            Dim tblName As String = ""
            Select Case TableName
                Case e_DataType.ProjectElements
                    tblName = "[HCS].ProjectElements"
                Case e_DataType.ProjectGroups
                    tblName = "[HCS].ProjectGroups"
                Case e_DataType.ProjectItems
                    tblName = "[HCS].ProjectItems"
                Case e_DataType.ProjectPunchs
                    tblName = "[HCS].ProjectPunchs"
                Case e_DataType.ProjectSubsystems
                    tblName = "[HCS].ProjectSubsystems"
                Case e_DataType.ProjectSystems
                    tblName = "[HCS].ProjectSystems"
                Case e_DataType.ProjectTasks
                    tblName = "[HCS].ProjectTasks"
            End Select
            DT = exl.GetSheetData(FilePath, SheetName)
            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = tblName
                bcp.BatchSize = BatchSize
                bcp.ColumnMappings.Clear()
                For inx As Integer = 0 To DT.Columns.Count - 1
                    bcp.ColumnMappings.Add(DT.Columns(inx).ColumnName, DT.Columns(inx).ColumnName)
                Next
                bcp.WriteToServer(DT)
            End Using
            FixHCSData(TableName)
            RaiseEvent HCSRestoreStatus(Replace(tblName, "[HCS].Project", "",,, CompareMethod.Text) & " Has Been Restored")
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Private Sub FixHCSData(ByVal TableName As e_DataType)
        Dim tblName As String = ""
        Select Case TableName
            Case e_DataType.ProjectPunchs
                tblName = "Punchs"
                DB.ExcuteNoneResult("update [HCS].[ProjectPunchs] set [SignedByTR]=replace([SignedByTR],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectPunchs] set [SignedBySubcon]=replace([SignedBySubcon],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectPunchs] set [SignedByClient]=replace([SignedByClient],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectPunchs] set [SignedByTR]=null where [SignedByTR]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectPunchs] set [SignedBySubcon]=null where [SignedBySubcon]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectPunchs] set [SignedByClient]=null where [SignedByClient]=''")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectPunchs] alter column [SignedByTR] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectPunchs] alter column [SignedBySubcon] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectPunchs] alter column [SignedByClient] date")
            Case e_DataType.ProjectSubsystems
                tblName = "Subsystems"
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data3]=replace([Data3],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data4]=replace([Data4],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data5]=replace([Data5],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data6]=replace([Data6],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data7]=replace([Data7],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data7]=replace([Data7],'-','/')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data8]=replace([Data8],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [TargetDate]=replace([TargetDate],'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [PlanningDate]=replace([PlanningDate],'''','')")

                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data3]=null where [Data3]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data4]=null where [Data4]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data5]=null where [Data5]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data6]=null where [Data6]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data7]=null where [Data7]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [Data8]=null where [Data8]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [TargetDate]=null where [TargetDate]=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectSubsystems] set [PlanningDate]=null where [PlanningDate]=''")

                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [Data3] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [Data4] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [Data5] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [Data6] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [Data7] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [Data8] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [TargetDate] date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectSubsystems] alter column [PlanningDate] date")

            Case e_DataType.ProjectTasks
                tblName = "Tasks"
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set SignedByClient=replace(SignedByClient,'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set SignedBySubcon=replace(SignedBySubcon,'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set SignedByTR=replace(SignedByTR,'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set PrintDate=replace(PrintDate,'''','')")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set SignedByClient=null where SignedByClient=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set SignedBySubcon=null where SignedBySubcon=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set SignedByTR=null where SignedByTR=''")
                DB.ExcuteNoneResult("update [HCS].[ProjectTasks] set PrintDate=null where PrintDate=''")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectTasks] alter column SignedByClient date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectTasks] alter column SignedBySubcon date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectTasks] alter column SignedByTR date")
                DB.ExcuteNoneResult("alter table [HCS].[ProjectTasks] alter column Printdate date")

        End Select
        RaiseEvent HCSRestoreStatus(tblName & " Has Been Fixed")
    End Sub
    Public Sub RestoreTable(ByVal TableName As e_DataType, FilePath As String, ByVal SheetName As String, ByVal BatchSize As Integer)
        Try
            TruncateHCSTables(TableName)
            Application.DoEvents()
            RestoreData(TableName, FilePath, SheetName, BatchSize)
            Application.DoEvents()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

#End Region
End Class
