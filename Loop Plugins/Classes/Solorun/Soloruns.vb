Public Class Soloruns
    Private SolorunFolderUpdate As New List(Of Solorun)
    Private pe As New PublicErrors
    Public FolderColumns As New List(Of ColumnObject)
    Public FolderProgressColumns As New List(Of ColumnObject)

    Public Sub New()
        FolderColumns.Add(New ColumnObject(0, "A1", "Tag", False, ColumnObject.en_SystemType.DataStrings, False))
        FolderColumns.Add(New ColumnObject(1, "B1", "Description", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(2, "C1", "Area", False, ColumnObject.en_SystemType.DataStrings, False))
        FolderColumns.Add(New ColumnObject(3, "D1", "Type", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(4, "E1", "Subtype", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(5, "F1", "ActId", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(6, "G1", "Vendor", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(9, "H1", "StartDate", False, ColumnObject.en_SystemType.DataDate, True))
        FolderColumns.Add(New ColumnObject(10, "I1", "FinishDate", False, ColumnObject.en_SystemType.DataDate, True))
        FolderColumns.Add(New ColumnObject(6, "J1", "Subsystem", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(6, "K1", "Priority", False, ColumnObject.en_SystemType.Int16, True))
        FolderColumns.Add(New ColumnObject(6, "L1", "PDSModel", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderColumns.Add(New ColumnObject(6, "M1", "ControllerLocation", False, ColumnObject.en_SystemType.DataStrings, True))

        FolderProgressColumns.Add(New ColumnObject(6, "A1", "Tag", False, ColumnObject.en_SystemType.DataStrings, True))
        FolderProgressColumns.Add(New ColumnObject(6, "B1", "ConstrRelease", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "C1", "QCRelease", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "D1", "FolderPreparation", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "E1", "SubmitToQC", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "F1", "FolderReady", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "G1", "ReturnFromQC", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "H1", "SubmittedToPrecom", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "I1", "Done", False, ColumnObject.en_SystemType.DataDate, True))
        FolderProgressColumns.Add(New ColumnObject(6, "J1", "FinalApproval", False, ColumnObject.en_SystemType.DataDate, True))


    End Sub
    Public Function GetFoldersForPlanning() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Folder Name", System.Type.GetType("System.String"))
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
            For Each lf As Solorun In SolorunFolderUpdate
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
    Public Function GetFoldersLog() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC MOTORS.GetLog"))
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function ClearData() As Boolean
        SolorunFolderUpdate = New List(Of Solorun)
        Return True
    End Function
    Public Sub Add(ByVal lFolder As Solorun)
        SolorunFolderUpdate.Add(lFolder)
    End Sub
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
                For Each row As DataRow In dt.Rows
                    If row.IsNull(col) Then
                        row(col) = "1/1/0001"
                    End If
                    If row(col) = "" Then
                        row(col) = "1/1/0001"
                    End If
                Next
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
                    bcp.DestinationTableName = "TEMPDATA.SolorunTemp"
                    bcp.BatchSize = 1000
                    bcp.ColumnMappings.Clear()

                    For Each col As ColumnObject In FolderColumns
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
                bcp.DestinationTableName = "TEMPDATA.SolorunTemp"
                bcp.BatchSize = 1000
                bcp.ColumnMappings.Clear()

                For Each col As ColumnObject In FolderProgressColumns
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
            results = DB.ReturnDataTable("EXEC TEMPDATA.UpdateSolorunBasicData '" & opKey & "'", 0)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function AddNewData(opKey As String, Optional ByRef results As DataTable = Nothing) As Boolean
        Try
            results = DB.ReturnDataTable("EXEC TEMPDATA.UploadSolorunsBasicData '" & opKey & "'", 0)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function ChangeStatus(opKey As String, Optional ByRef results As DataTable = Nothing, Optional status As Byte = 0) As Boolean
        Try
            results = DB.ReturnDataTable("EXEC TEMPDATA.ChangeSolorunStatus '" & opKey & "'," & status, 0)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function Delete(opKey As String, Optional ByRef results As DataTable = Nothing) As Boolean
        Try
            results = DB.ReturnDataTable("EXEC TEMPDATA.DeleteSolorun '" & opKey & "'", 0)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function DeleteTempData(opKey As String) As Boolean
        Try
            DB.ExcuteNoneResult("DELETE FROM TEMPDATA.SolorunTemp WHERE OpKey ='" & opKey & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function CreateLoopPriority() As Boolean
        Try
            DB.ExcuteNoneResult("MOTORS.CreateSolorunPriorities")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function CheckIntgerity() As Boolean
        Try
            DB.ExcuteNoneResult("EXEC dbo.CheckSolorunIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function HCSTasks(ByRef folders As List(Of String)) As DataTable
        Try
            Dim dt As New DataTable
            Dim dtTemp As New DataTable

            DB.ExcuteNoneResult("DELETE FROM TEMPDATA.GroupFilter WHERE UserName = '" & Users.userName & "'")

            dtTemp.Columns.Add("GroupName", System.Type.GetType("System.String"))
            dtTemp.Columns.Add("UserName", System.Type.GetType("System.String"), "'" & Users.userName & "'")

            For Each gName As String In folders
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
