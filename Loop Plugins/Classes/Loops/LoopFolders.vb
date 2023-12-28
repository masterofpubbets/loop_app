Public Class LoopFolders
    Private LoopFolderUpdate As New List(Of LoopFolder)
    Private pe As New PublicErrors
    Public LoopColumns As New List(Of ColumnObject)
    Public LoopProgressColumns As New List(Of ColumnObject)

    Public Sub New()
        LoopColumns.Add(New ColumnObject(0, "A1", "Tag", False, ColumnObject.en_SystemType.DataStrings, False))
        LoopColumns.Add(New ColumnObject(1, "B1", "Description", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopColumns.Add(New ColumnObject(2, "C1", "Area", False, ColumnObject.en_SystemType.DataStrings, False))
        LoopColumns.Add(New ColumnObject(3, "D1", "Type", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopColumns.Add(New ColumnObject(4, "E1", "Subtype", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopColumns.Add(New ColumnObject(5, "F1", "ActId", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopColumns.Add(New ColumnObject(6, "G1", "Vendor", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopColumns.Add(New ColumnObject(9, "H1", "StartDate", False, ColumnObject.en_SystemType.DataDate, True))
        LoopColumns.Add(New ColumnObject(10, "I1", "FinishDate", False, ColumnObject.en_SystemType.DataDate, True))
        LoopColumns.Add(New ColumnObject(6, "J1", "Subsystem", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopColumns.Add(New ColumnObject(6, "K1", "Priority", False, ColumnObject.en_SystemType.Int16, True))
        LoopColumns.Add(New ColumnObject(6, "L1", "PDSModel", False, ColumnObject.en_SystemType.DataStrings, True))

        LoopProgressColumns.Add(New ColumnObject(6, "A1", "Tag", False, ColumnObject.en_SystemType.DataStrings, True))
        LoopProgressColumns.Add(New ColumnObject(6, "B1", "ConstrRelease", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "C1", "QCRelease", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "D1", "FolderPreparation", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "E1", "SubmitToQC", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "F1", "FolderReady", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "G1", "ReturnFromQC", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "H1", "SubmittedToPrecom", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "I1", "Done", False, ColumnObject.en_SystemType.DataDate, True))
        LoopProgressColumns.Add(New ColumnObject(6, "J1", "FinalApproval", False, ColumnObject.en_SystemType.DataDate, True))


    End Sub
    Public Function GetLoopsFoldersForPlanning() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Loop Name", System.Type.GetType("System.String"))
        dt.Columns.Add("Description", System.Type.GetType("System.String"))
        dt.Columns.Add("Start Date", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Finish Date", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Progress", System.Type.GetType("System.Double"))
        dt.Columns.Add("Vendor", System.Type.GetType("System.String"))
        dt.Columns.Add("Submit To QC", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Folder Preparation", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Construction Complete", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("QC Release", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Folder Ready", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Return From QC", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Submitted To Precom", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Done", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Final Approval", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Area", System.Type.GetType("System.String"))
        dt.Columns.Add("Type", System.Type.GetType("System.String"))
        dt.Columns.Add("Subtype", System.Type.GetType("System.String"))
        dt.Columns.Add("ActId", System.Type.GetType("System.String"))

        Try
            For Each lf As LoopFolder In LoopFolderUpdate
                dt.Rows.Add(lf.Name, lf.Description,
                            IIf(lf.StartDate.Year = 1, DBNull.Value, lf.StartDate),
                            IIf(lf.FinishDate.Year = 1, DBNull.Value, lf.FinishDate),
                            lf.Progress, lf.Vendors,
                            IIf(lf.FolderPreparation.Year = 1, DBNull.Value, lf.FolderPreparation),
                            IIf(lf.ConstrRelease.Year = 1, DBNull.Value, lf.ConstrRelease),
                            IIf(lf.QCRelease.Year = 1, DBNull.Value, lf.QCRelease),
                            IIf(lf.SubmittedToQC.Year = 1, DBNull.Value, lf.SubmittedToQC),
                            IIf(lf.FolderReady.Year = 1, DBNull.Value, lf.FolderReady),
                            IIf(lf.ReturnFromQC.Year = 1, DBNull.Value, lf.ReturnFromQC),
                            IIf(lf.SubmittedToPrecom.Year = 1, DBNull.Value, lf.SubmittedToPrecom),
                            IIf(lf.Done.Year = 1, DBNull.Value, lf.Done),
                            IIf(lf.FinalApproval.Year = 1, DBNull.Value, lf.FinalApproval),
                            lf.Area,
                            lf.Type,
                            lf.Subtype,
                            lf.ActId
                 )
            Next
            Return dt
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function LoopMap(Optional subsystem As String = "", Optional loopName As String = "") As DataTable
        Try

        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function ClearData() As Boolean
        LoopFolderUpdate = New List(Of LoopFolder)
        Return True
    End Function
    Public Sub Add(ByVal lFolder As LoopFolder)
        LoopFolderUpdate.Add(lFolder)
    End Sub
    Public Function UpdateDBFromPlanning(ByVal UpdateType As Enumerations.UpdateType, ByVal updateDate As Date, Optional ByRef results As DataTable = Nothing) As Boolean
        Try
            Dim uuId As Guid = Guid.NewGuid()
            Dim tranKey As String = uuId.ToString
            Dim dt As New DataTable
            dt = Me.GetLoopsFoldersForPlanning

            dt.Columns.Add("ReportedBy", System.Type.GetType("System.String"), "'" & Users.userFullName & "'")
            dt.Columns.Add("OpKey", System.Type.GetType("System.String"), "'" & tranKey & "'")
            dt.Columns.Add("UpdateType", System.Type.GetType("System.String"), "'" & UpdateType.ToString & "'")


            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "TEMPDATA.LoopTemp"
                bcp.BatchSize = 1000

                bcp.ColumnMappings.Clear()
                bcp.ColumnMappings.Add("Loop Name", "Tag")
                bcp.ColumnMappings.Add("Description", "Description")
                bcp.ColumnMappings.Add("Start Date", "StartDate")
                bcp.ColumnMappings.Add("Finish Date", "FinishDate")
                bcp.ColumnMappings.Add("Progress", "Progress")
                bcp.ColumnMappings.Add("Vendor", "Vendor")
                bcp.ColumnMappings.Add("Folder Preparation", "FolderPreparation")
                bcp.ColumnMappings.Add("Construction Complete", "ConstrRelease")
                bcp.ColumnMappings.Add("QC Release", "QCRelease")
                bcp.ColumnMappings.Add("Submit To QC", "SubmitToQC")
                bcp.ColumnMappings.Add("Folder Ready", "FolderReady")
                bcp.ColumnMappings.Add("Return From QC", "ReturnFromQC")
                bcp.ColumnMappings.Add("Submitted To Precom", "SubmittedToPrecom")
                bcp.ColumnMappings.Add("Done", "Done")
                bcp.ColumnMappings.Add("Final Approval", "FinalApproval")
                bcp.ColumnMappings.Add("UpdateType", "UpdateType")
                bcp.ColumnMappings.Add("ReportedBy", "ReportedBy")
                bcp.ColumnMappings.Add("OpKey", "OpKey")

                bcp.WriteToServer(dt)

                DB.ExcuteNoneResult("EXEC TEMPDATA.UpdateLoopsNoOverwrite '" & tranKey & "','" & updateDate & "'", 0)
                If Not IsNothing(results) Then
                    results = DB.ReturnDataTable("EXEC TEMPDATA.GetResults '" & tranKey & "'")
                    DB.ExcuteNoneResult("DELETE FROM TEMPDATA.LoopTemp WHERE OpKey ='" & tranKey & "'")
                End If
                Return True
            End Using
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return False
    End Function
    Private Function CheckTempDatatable(ByRef dt As DataTable) As Boolean
        If IsNothing(dt) Then
            Return False
        End If
        If Not dt.Columns.Contains("Tag") Then
            Return False
        End If
        Return True
    End Function
    Private Sub CleanDatatable(ByRef dt As DataTable)
        For Each col As DataColumn In dt.Columns
            If col.ColumnName.Contains("Date") Then
                'For Each row As DataRow In dt.Rows
                '    If row.IsNull(col) Then
                '        row(col) = "1/1/1900"
                '    End If
                'Next
            Else
                For Each row As DataRow In dt.Rows
                    If row.IsNull(col) Then
                        Select Case col.DataType
                            Case Type.GetType("System.String")
                                row(col) = "SETASNULL"
                                Exit Select
                        End Select
                    End If
                Next
            End If
        Next
    End Sub
    Public Function UploadTempData(ByVal UpdateType As Enumerations.UpdateType, ByRef data As DataTable) As String
        Try
            If CheckTempDatatable(data) Then
                Dim uuId As Guid = Guid.NewGuid()
                Dim tranKey As String = uuId.ToString

                CleanDatatable(data)

                data.Columns.Add("ReportedBy", System.Type.GetType("System.String"), "'" & Users.userFullName & "'")
                data.Columns.Add("OpKey", System.Type.GetType("System.String"), "'" & tranKey & "'")
                data.Columns.Add("UpdateType", System.Type.GetType("System.String"), "'" & UpdateType.ToString & "'")

                Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                    bcp.BulkCopyTimeout = 0
                    bcp.DestinationTableName = "TEMPDATA.LoopTemp"
                    bcp.BatchSize = 1000
                    bcp.ColumnMappings.Clear()

                    For Each col As ColumnObject In LoopColumns
                        If data.Columns.Contains(col.Name) Then
                            bcp.ColumnMappings.Add(col.Name, col.Name)
                        End If
                    Next
                    bcp.ColumnMappings.Add("ReportedBy", "ReportedBy")
                    bcp.ColumnMappings.Add("OpKey", "OpKey")
                    bcp.ColumnMappings.Add("UpdateType", "UpdateType")

                    bcp.WriteToServer(data)
                End Using

                Return tranKey

            Else
                pe.RaiseUnknownError("Data must contain columns {Tag}")
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return ""
        End Try
        Return ""
    End Function

    Public Function UploadTempProgress(ByVal UpdateType As Enumerations.UpdateType, ByRef data As DataTable) As String
        Try

            Dim uuId As Guid = Guid.NewGuid()
            Dim tranKey As String = uuId.ToString

            data.Columns.Add("ReportedBy", System.Type.GetType("System.String"), "'" & Users.userFullName & "'")
            data.Columns.Add("OpKey", System.Type.GetType("System.String"), "'" & tranKey & "'")
            data.Columns.Add("UpdateType", System.Type.GetType("System.String"), "'" & UpdateType.ToString & "'")

            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "TEMPDATA.LoopTemp"
                bcp.BatchSize = 1000
                bcp.ColumnMappings.Clear()

                For Each col As ColumnObject In LoopProgressColumns
                    If data.Columns.Contains(col.Name) Then
                        bcp.ColumnMappings.Add(col.Name, col.Name)
                    End If
                Next
                bcp.ColumnMappings.Add("ReportedBy", "ReportedBy")
                bcp.ColumnMappings.Add("OpKey", "OpKey")
                bcp.ColumnMappings.Add("UpdateType", "UpdateType")

                bcp.WriteToServer(data)
            End Using

            Return tranKey


        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return ""
        End Try
        Return ""
    End Function
    Public Function UpdateData(opKey As String, Optional ByRef results As DataTable = Nothing) As Boolean
        Try
            results = DB.ReturnDataTable("EXEC TEMPDATA.UpdateLoopsBasicData '" & opKey & "'", 0)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function DeleteTempData(opKey As String) As Boolean
        Try
            DB.ExcuteNoneResult("DELETE FROM TEMPDATA.LoopTemp WHERE OpKey ='" & opKey & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function CreateLoopPriority() As Boolean
        Try
            DB.ExcuteNoneResult("LOOPS.CreateLoopPriorities")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function CheckIntgerity() As Boolean
        Try
            DB.ExcuteNoneResult("EXEC dbo.CheckLoopIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function HCSTasks(ByRef LoopFolders As List(Of String)) As DataTable
        Try
            Dim dt As New DataTable
            Dim dtTemp As New DataTable

            DB.ExcuteNoneResult("DELETE FROM TEMPDATA.GroupFilter WHERE UserName = '" & Users.userName & "'")

            dtTemp.Columns.Add("GroupName", System.Type.GetType("System.String"))
            dtTemp.Columns.Add("UserName", System.Type.GetType("System.String"), "'" & Users.userName & "'")

            For Each gName As String In LoopFolders
                dtTemp.Rows.Add(gName)
            Next


            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "TEMPDATA.GroupFilter"
                bcp.BatchSize = 1000
                bcp.ColumnMappings.Clear()
                bcp.ColumnMappings.Add("GroupName", "GroupName")
                bcp.ColumnMappings.Add("UserName", "UserName")

                bcp.WriteToServer(dtTemp)
            End Using

            Return (DB.ReturnDataTable("EXEC HCS.GetGroupTasks '" & Users.userName & "'"))

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function
End Class

