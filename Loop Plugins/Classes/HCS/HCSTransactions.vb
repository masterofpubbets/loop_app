Public Class HCSTransactions
    Private pe As New PublicErrors

    Public Property HCSDBBLocation As String
        Get
            Return DB.ExcutResult("SELECT SetValue FROM tblSettings WHERE SetName ='HCSDBLocation'")
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSDBLocation'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,SetValue) VALUES ('HCSDBLocation','" & value & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET SetValue = '" & value & "' WHERE SetName ='HCSDBLocation'")
            End If
        End Set
    End Property
    Public Property HCSDBBName As String
        Get
            Return DB.ExcutResult("SELECT SetValue FROM tblSettings WHERE SetName ='HCSDBBName'")
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSDBBName'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,SetValue) VALUES ('HCSDBBName','" & value & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET SetValue = '" & value & "' WHERE SetName ='HCSDBBName'")
            End If
        End Set
    End Property
    Public Property HCSElementQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSElementQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSElementQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSElementQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSElementQuery'")
            End If
        End Set
    End Property
    Public Property HCSTasksQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSTasksQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSTasksQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSTasksQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSTasksQuery'")
            End If
        End Set
    End Property
    Public Property HCSLoopApprovedQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSLoopApprovedQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSLoopApprovedQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSLoopApprovedQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSLoopApprovedQuery'")
            End If
        End Set
    End Property
    Public Property HCSSoloRunApprovedQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSSoloRunApprovedQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSSoloRunApprovedQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSSoloRunApprovedQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSSoloRunApprovedQuery'")
            End If
        End Set
    End Property
    Public Property HCSClosedItemsQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSClosedItemsQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSClosedItemsQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSClosedItemsQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSClosedItemsQuery'")
            End If
        End Set
    End Property
    Public Property HCSGroupsQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSGroupsQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSGroupsQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSGroupsQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSGroupsQuery'")
            End If
        End Set
    End Property
    Public Property HCSUpdateSubsystemQuery As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='HCSUpdateSubsystemQuery'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='HCSUpdateSubsystemQuery'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('HCSUpdateSubsystemQuery','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='HCSUpdateSubsystemQuery'")
            End If
        End Set
    End Property
    Public Property HCSFinalClean As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='FinalClean'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='FinalClean'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('FinalClean','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='FinalClean'")
            End If
        End Set
    End Property
    Private Function GetHCSElements() As DataTable
        Try
            Dim HCSDB As New EAMS.DataBaseTools.SQLServerTools With {
                .DataBaseName = Me.HCSDBBName,
                .DataBaseLocation = Me.HCSDBBLocation
            }
            HCSDB.Connect()
            Return HCSDB.ReturnDataTable(Me.HCSElementQuery)
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Function GetHCSTasks() As DataTable
        Try
            Dim HCSDB As New EAMS.DataBaseTools.SQLServerTools With {
                .DataBaseName = Me.HCSDBBName,
                .DataBaseLocation = Me.HCSDBBLocation
            }
            HCSDB.Connect()
            Return HCSDB.ReturnDataTable(Me.HCSTasksQuery)
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Function GetHCSGroups() As DataTable
        Try
            Dim HCSDB As New EAMS.DataBaseTools.SQLServerTools With {
                .DataBaseName = Me.HCSDBBName,
                .DataBaseLocation = Me.HCSDBBLocation
            }
            HCSDB.Connect()
            Return HCSDB.ReturnDataTable(Me.HCSGroupsQuery)
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Function GetLoopApproved() As DataTable
        Try
            Dim HCSDB As New EAMS.DataBaseTools.SQLServerTools With {
                .DataBaseName = Me.HCSDBBName,
                .DataBaseLocation = Me.HCSDBBLocation
            }
            HCSDB.Connect()
            Return HCSDB.ReturnDataTable(Me.HCSLoopApprovedQuery)
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Function GetSoloRunApproved() As DataTable
        Try
            Dim HCSDB As New EAMS.DataBaseTools.SQLServerTools With {
                .DataBaseName = Me.HCSDBBName,
                .DataBaseLocation = Me.HCSDBBLocation
            }
            HCSDB.Connect()
            Return HCSDB.ReturnDataTable(Me.HCSSoloRunApprovedQuery)
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Sub AddToTempElementDT(ByRef dt As DataTable, ByRef row As DataRow)
        Dim temp() As String = Split(row("Group"), ";",, CompareMethod.Text)
        For inx As Integer = 0 To temp.Length - 1
            dt.Rows.Add(row("ElementTag"),
                        row("Type"),
                        row("Discipline"),
                        row("Description"),
                        temp(inx),
                        row("GroupType"),
                        row("GroupActive"),
                        row("Subsystem"),
                        row("Subcontract")
                        )
        Next
    End Sub
    Private Function DivideGroupedElement() As Boolean
        Try
            Dim sqlTemp As String = "SELECT ElementTag, Type, Discipline, Description, [Group], GroupType, GroupActive, Subsystem, Subcontract FROM [HCS].ProjectElements WHERE [Group] LIKE '%;%'"
            Dim dt As New DataTable
            Dim dtTemp As DataTable = DB.ReturnDataTable(sqlTemp)

            For inx As Integer = 0 To dtTemp.Columns.Count - 1
                dt.Columns.Add(dtTemp.Columns.Item(inx).ColumnName, System.Type.GetType("System.String"))
            Next

            For Each row As DataRow In dtTemp.Rows
                AddToTempElementDT(dt, row)
            Next

            Try
                Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                    bcp.BulkCopyTimeout = 0
                    bcp.DestinationTableName = "[HCS].[ProjectElements]"
                    bcp.BatchSize = 1000
                    bcp.ColumnMappings.Clear()

                    If dt.Columns.Contains("ElementTag") Then bcp.ColumnMappings.Add("ElementTag", "ElementTag")
                    If dt.Columns.Contains("Type") Then bcp.ColumnMappings.Add("Type", "Type")
                    If dt.Columns.Contains("Discipline") Then bcp.ColumnMappings.Add("Discipline", "Discipline")
                    If dt.Columns.Contains("Description") Then bcp.ColumnMappings.Add("Description", "Description")
                    If dt.Columns.Contains("Group") Then bcp.ColumnMappings.Add("Group", "Group")
                    If dt.Columns.Contains("GroupType") Then bcp.ColumnMappings.Add("GroupType", "GroupType")
                    If dt.Columns.Contains("GroupActive") Then bcp.ColumnMappings.Add("GroupActive", "GroupActive")
                    If dt.Columns.Contains("Subsystem") Then bcp.ColumnMappings.Add("Subsystem", "Subsystem")
                    If dt.Columns.Contains("Subcontract") Then bcp.ColumnMappings.Add("Subcontract", "Subcontract")

                    bcp.WriteToServer(dt)
                End Using
                DB.ExcuteNoneResult("DELETE FROM [HCS].ProjectElements WHERE [Group] LIKE '%;%'")
            Catch ex As Exception

            End Try



            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return False
    End Function
    Public Function DownloadHCSElements() As Boolean
        Try
            Dim dt As DataTable = Me.GetHCSElements
            DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].[ProjectElements]")
            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "[HCS].[ProjectElements]"
                bcp.BatchSize = 1000
                bcp.ColumnMappings.Clear()

                If dt.Columns.Contains("ElementTag") Then bcp.ColumnMappings.Add("ElementTag", "ElementTag")
                If dt.Columns.Contains("Type") Then bcp.ColumnMappings.Add("Type", "Type")
                If dt.Columns.Contains("Discipline") Then bcp.ColumnMappings.Add("Discipline", "Discipline")
                If dt.Columns.Contains("Description") Then bcp.ColumnMappings.Add("Description", "Description")
                If dt.Columns.Contains("Group") Then bcp.ColumnMappings.Add("Group", "Group")
                If dt.Columns.Contains("GroupType") Then bcp.ColumnMappings.Add("GroupType", "GroupType")
                If dt.Columns.Contains("GroupActive") Then bcp.ColumnMappings.Add("GroupActive", "GroupActive")
                If dt.Columns.Contains("Subsystem") Then bcp.ColumnMappings.Add("Subsystem", "Subsystem")
                If dt.Columns.Contains("Subcontract") Then bcp.ColumnMappings.Add("Subcontract", "Subcontract")

                bcp.WriteToServer(dt)
            End Using
            DB.ExcuteNoneResult("EXEC HCS.AddAdditionalElements")
            Return DivideGroupedElement()
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function DownloadHCSITRs() As Boolean
        Try
            Dim dt As DataTable = Me.GetHCSTasks
            DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].[ProjectTasks]")
            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "[HCS].[ProjectTasks]"
                bcp.BatchSize = 1000
                bcp.ColumnMappings.Clear()

                If dt.Columns.Contains("TaskSubcontract") Then bcp.ColumnMappings.Add("TaskSubcontract", "Subcontractor")
                If dt.Columns.Contains("Module") Then bcp.ColumnMappings.Add("Module", "Module")
                If dt.Columns.Contains("ClosingDate") Then bcp.ColumnMappings.Add("ClosingDate", "ClosingDate")
                If dt.Columns.Contains("ClosingRemarks") Then bcp.ColumnMappings.Add("ClosingRemarks", "ClosingRemarks")
                If dt.Columns.Contains("ElementTag") Then bcp.ColumnMappings.Add("ElementTag", "ElementCode")
                If dt.Columns.Contains("FormName") Then bcp.ColumnMappings.Add("FormName", "DocName")
                If dt.Columns.Contains("ActivityDescription") Then bcp.ColumnMappings.Add("ActivityDescription", "Description")
                If dt.Columns.Contains("Phase") Then bcp.ColumnMappings.Add("Phase", "Phase")

                bcp.WriteToServer(dt)
            End Using

            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function DownloadHCSGroups() As Boolean
        Try
            Dim dt As DataTable = Me.GetHCSGroups
            DB.ExcuteNoneResult("TRUNCATE TABLE [HCS].[ProjectGroups]")
            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "[HCS].[ProjectGroups]"
                bcp.BatchSize = 1000
                bcp.ColumnMappings.Clear()

                If dt.Columns.Contains("Area") Then bcp.ColumnMappings.Add("Area", "Area")
                If dt.Columns.Contains("ElementTag") Then bcp.ColumnMappings.Add("ElementTag", "GroupName")
                If dt.Columns.Contains("Type") Then bcp.ColumnMappings.Add("Type", "Type")
                If dt.Columns.Contains("Discipline") Then bcp.ColumnMappings.Add("Discipline", "Discipline")
                If dt.Columns.Contains("Description") Then bcp.ColumnMappings.Add("Description", "Description")
                If dt.Columns.Contains("Subsystem") Then bcp.ColumnMappings.Add("Subsystem", "SubSystem")
                If dt.Columns.Contains("Subcontract") Then bcp.ColumnMappings.Add("Subcontract", "Subcontractor")

                bcp.WriteToServer(dt)
            End Using

            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function DownloadLoopApproved() As Boolean
        Try
            Dim dtLoopApproved As DataTable = Me.GetLoopApproved
            Dim loopList As New LoopFolders
            Dim dt As New DataTable
            Dim lf As New LoopFolders

            dt.TableName = "LoopData"
            dt.Columns.Add("Tag", Type.GetType("System.String"))
            dt.Columns.Add("Area", Type.GetType("System.String"))
            dt.Columns.Add("Description", Type.GetType("System.String"))
            dt.Columns.Add("FinalApproval", Type.GetType("System.DateTime"))

            For inx As Integer = 0 To dtLoopApproved.Rows.Count - 1
                dt.Rows.Add(
                        dtLoopApproved.Rows(inx).Item("ElementTag"),
                        "NOUPDATE",
                        "",
                        Now()
                    )
                loopList.Add(New LoopFolder(
                                 dtLoopApproved.Rows(inx).Item("ElementTag"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 Now(), 'Final approved
                                 "NOUPDATE",
                                 "",
                                 "",
                                 ""
                    ))
            Next


            Dim opKey As String = lf.UploadTempProgress(Enumerations.UpdateType.UPDATELOOPFOLDERAPPROVED, dt)
            If opKey <> "" Then
                If lf.UpdateData(opKey) Then
                    lf.DeleteTempData(opKey)
                End If

                lf.CheckIntgerity()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function DownloadSoloRunApproved() As Boolean
        Try
            Dim dtLoopApproved As DataTable = Me.GetSoloRunApproved
            Dim solorun As New Soloruns
            Dim dt As New DataTable
            Dim lf As New Soloruns

            dt.TableName = "SoloRunData"
            dt.Columns.Add("Tag", Type.GetType("System.String"))
            dt.Columns.Add("Area", Type.GetType("System.String"))
            dt.Columns.Add("Description", Type.GetType("System.String"))
            dt.Columns.Add("FinalApproval", Type.GetType("System.DateTime"))

            For inx As Integer = 0 To dtLoopApproved.Rows.Count - 1
                dt.Rows.Add(
                        dtLoopApproved.Rows(inx).Item("ElementTag"),
                        "NOUPDATE",
                        "",
                        Now()
                    )
                solorun.Add(New Solorun(
                                 dtLoopApproved.Rows(inx).Item("ElementTag"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 Now(), 'Final approved
                                 "NOUPDATE",
                                 "",
                                 "",
                                 ""
                    ))
            Next


            Dim opKey As String = lf.UploadTempProgress(Enumerations.UpdateType.UPDATELOOPFOLDERAPPROVED, dt)
            If opKey <> "" Then
                If lf.UpdateData(opKey) Then
                    lf.DeleteTempData(opKey)
                End If

                lf.CheckIntgerity()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function

    Public Function UpdateLoopQCReleasedFromHCS() As Boolean
        Try
            DB.ExcuteNoneResult("EXEC LOOPS.UpdateQCReleasedFromHCS")
            DB.ExcuteNoneResult("EXEC dbo.CheckLoopIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateMotorsQCReleasedFromHCS() As Boolean
        Try
            DB.ExcuteNoneResult("EXEC MOTORS.UpdateQCReleasedFromHCS")
            DB.ExcuteNoneResult("EXEC dbo.CheckSolorunIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateEICAItemsSubsystemFromHCS() As Boolean
        Try
            DB.ExcuteNoneResult(Me.HCSUpdateSubsystemQuery)
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateEICALoopsWithHCS() As Boolean
        Try
            DB.ExcuteNoneResult("HCS.UpdateLoopWithHCS")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateEICAMotorsWithHCS() As Boolean
        Try
            DB.ExcuteNoneResult("HCS.UpdateMotorWithHCS")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ApplyFinalClean() As Boolean
        Try
            If Me.HCSFinalClean <> "" Then  DB.ExcuteNoneResult(Me.HCSFinalClean)
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
End Class
