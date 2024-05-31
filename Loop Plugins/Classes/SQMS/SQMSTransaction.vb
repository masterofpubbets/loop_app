Public Class SQMSTransaction
    Public TasksColumns As New List(Of ColumnObject)
    Private pe As New PublicErrors

    Public Sub New()
        TasksColumns.Add(New ColumnObject(0, "A1", "TaskCode", False, ColumnObject.en_SystemType.DataStrings, False))
        TasksColumns.Add(New ColumnObject(1, "B1", "ElementTag", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(2, "C1", "NodeLevel", False, ColumnObject.en_SystemType.DataStrings, False))
        TasksColumns.Add(New ColumnObject(3, "D1", "FormName", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(4, "E1", "FormDescription", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(5, "F1", "ActivityDescription", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(6, "G1", "Type", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(7, "H1", "Class", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(8, "I1", "Phase", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(9, "J1", "TaskSubcontract", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(10, "K1", "Discipline", False, ColumnObject.en_SystemType.Int16, True))
        TasksColumns.Add(New ColumnObject(11, "L1", "Location", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(6, "M1", "Unit", False, ColumnObject.en_SystemType.DataStrings, True))

        TasksColumns.Add(New ColumnObject(0, "N1", "Area", False, ColumnObject.en_SystemType.DataStrings, False))
        TasksColumns.Add(New ColumnObject(1, "O1", "System", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(2, "P1", "Subsystem", False, ColumnObject.en_SystemType.DataStrings, False))
        TasksColumns.Add(New ColumnObject(3, "Q1", "Module", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(4, "R1", "Package", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(5, "S1", "Group", False, ColumnObject.en_SystemType.DataStrings, True))

        TasksColumns.Add(New ColumnObject(6, "T1", "ManHours", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(7, "V1", "MasterTask", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(8, "U1", "DossierTask", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(9, "W1", "Sct", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(10, "X1", "TestPackageTask", False, ColumnObject.en_SystemType.Int16, True))
        TasksColumns.Add(New ColumnObject(11, "Y1", "TaskLocation", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(6, "Z1", "SubcontractorSign", False, ColumnObject.en_SystemType.DataStrings, True))

        TasksColumns.Add(New ColumnObject(6, "AA1", "ContractorSign", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(7, "AB1", "CompanySign", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(8, "AC1", "NoApplicable", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(9, "AD1", "ClosedByContractor", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(10, "AE1", "SignedTaskFileCount", False, ColumnObject.en_SystemType.Int16, True))
        TasksColumns.Add(New ColumnObject(11, "AF1", "Status", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(6, "AG1", "ClosingDate", False, ColumnObject.en_SystemType.DataStrings, True))

        TasksColumns.Add(New ColumnObject(6, "AH1", "ClosingUser", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(7, "AI1", "ClosingRemarks", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(8, "AJ1", "TaskRemarks", False, ColumnObject.en_SystemType.DataDate, True))
        TasksColumns.Add(New ColumnObject(9, "AK1", "Active", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(10, "AL1", "QcApprovalUser", False, ColumnObject.en_SystemType.Int16, True))
        TasksColumns.Add(New ColumnObject(11, "AM1", "QcApprovalDate", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(6, "AN1", "ITPType", False, ColumnObject.en_SystemType.DataStrings, True))
        TasksColumns.Add(New ColumnObject(6, "AO1", "TestPackageType", False, ColumnObject.en_SystemType.DataStrings, True))
    End Sub
    Public Property SQMSDBBLocation As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='SQMSDBBLocation'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='SQMSDBBLocation'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('SQMSDBBLocation','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='SQMSDBBLocation'")
            End If
        End Set
    End Property
    Public Property SQMSDBBName As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='SQMSDBBName'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='SQMSDBBName'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('SQMSDBBName','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='SQMSDBBName'")
            End If
        End Set
    End Property
    Public Property MotorSoloRunScope As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='MotorSoloRunScope'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='MotorSoloRunScope'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('MotorSoloRunScope','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='MotorSoloRunScope'")
            End If
        End Set
    End Property
    Public Property MotorSoloRunApproved As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='MotorSoloRunApproved'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='MotorSoloRunApproved'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('MotorSoloRunApproved','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='MotorSoloRunApproved'")
            End If
        End Set
    End Property
    Public Property LoopTestScope As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='LoopTestScope'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='LoopTestScope'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('LoopTestScope','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='LoopTestScope'")
            End If
        End Set
    End Property
    Public Property LoopTestApproved As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='LoopTestApproved'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='LoopTestApproved'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('LoopTestApproved','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='LoopTestApproved'")
            End If
        End Set
    End Property
    Public Property LoopFolderRequiredTasks As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='LoopFolderRequiredTasks'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='LoopFolderRequiredTasks'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('LoopFolderRequiredTasks','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='LoopFolderRequiredTasks'")
            End If
        End Set
    End Property
    Public Property SoloRunRequiredTasks As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='SoloRunRequiredTasks'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='SoloRunRequiredTasks'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('SoloRunRequiredTasks','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='SoloRunRequiredTasks'")
            End If
        End Set
    End Property
    Public Property BoxupScope As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='BoxupScope'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='BoxupScope'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('BoxupScope','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='BoxupScope'")
            End If
        End Set
    End Property
    Public Property BoxupRequiredTask As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='BoxupRequiredTask'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='BoxupRequiredTask'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('BoxupRequiredTask','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='BoxupRequiredTask'")
            End If
        End Set
    End Property
    Public Property BoxupApproved As String
        Get
            Return Replace(DB.ExcutResult("SELECT LongValue FROM tblSettings WHERE SetName ='BoxupApproved'"), "''", "'",,, CompareMethod.Text)
        End Get
        Set(value As String)
            If DB.ExcutResult("SELECT SetId FROM tblSettings WHERE SetName ='BoxupApproved'") = "" Then
                DB.ExcuteNoneResult("INSERT INTO tblSettings (SetName,LongValue) VALUES ('BoxupApproved','" & Replace(value, "'", "''",,, CompareMethod.Text) & "')")
            Else
                DB.ExcuteNoneResult("UPDATE tblSettings SET LongValue = '" & Replace(value, "'", "''",,, CompareMethod.Text) & "' WHERE SetName ='BoxupApproved'")
            End If
        End Set
    End Property
    Public Property FinalClean As String
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
    Private Sub AddMultiGroupItems(ByRef dt As DataTable, ByRef row As DataRow)
        Try
            Dim temp() As String = Split(row("Group"), ",",, CompareMethod.Text)
            For inx As Integer = 0 To temp.Length - 1
                row("Group") = temp(inx)
                dt.Rows.Add(row.ItemArray)
            Next
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Public Function UploadTasksToEICA(ByRef dt As DataTable) As Boolean
        Try
            DB.ExcuteNoneResult("TRUNCATE TABLE HCS.SQMSTasks")
            Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                bcp.BulkCopyTimeout = 0
                bcp.DestinationTableName = "HCS.SQMSTasks"
                bcp.BatchSize = 6000
                bcp.ColumnMappings.Clear()

                For Each C As ColumnObject In TasksColumns
                    If dt.Columns.Contains(C.Name) Then bcp.ColumnMappings.Add(C.Name, C.Name)
                Next

                bcp.WriteToServer(dt)
            End Using

            Return LoadElements()

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Private Function LoadElements() As Boolean
        Try
            If DivideGroupedElement() Then
                DB.ExcuteNoneResult(My.Resources.UploadToElements)  'Upload Element and Groups From SQMS and Additional Tasks
                Return True
            End If
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Private Function DivideGroupedElement() As Boolean
        Try
            Dim sqlTemp As String = "SELECT * FROM [HCS].SQMSTasks WHERE [Group] LIKE '%,%'"
            Dim dt As New DataTable
            Dim dtTemp As DataTable = DB.ReturnDataTable(sqlTemp)
            Dim column As New DataColumn

            dtTemp.Columns.Remove("Source")

            With column
                .ColumnName = "Source"
                .DataType = System.Type.GetType("System.String")
                .DefaultValue = "MultiItem"
                .Unique = False
            End With

            For inx As Integer = 0 To dtTemp.Columns.Count - 1
                dt.Columns.Add(dtTemp.Columns.Item(inx).ColumnName, System.Type.GetType("System.String"))
            Next
            dt.Columns.Add(column)

            For Each row As DataRow In dtTemp.Rows
                AddMultiGroupItems(dt, row)
            Next

            Try
                Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
                    bcp.BulkCopyTimeout = 0
                    bcp.DestinationTableName = "[HCS].[SQMSTasks]"
                    bcp.BatchSize = 6000
                    bcp.ColumnMappings.Clear()

                    For colInx As Integer = 0 To dt.Columns.Count - 1
                        bcp.ColumnMappings.Add(dt.Columns(colInx).ColumnName, dt.Columns(colInx).ColumnName)
                    Next

                    bcp.WriteToServer(dt)
                End Using
                DB.ExcuteNoneResult("DELETE FROM [HCS].SQMSTasks WHERE [Group] LIKE '%,%'")
            Catch ex As Exception

            End Try



            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return False
    End Function
    Public Function UpdateLoopQCReleasedFromSQMS() As Boolean
        Try
            Dim taskFilter As String = Me.LoopFolderRequiredTasks
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateLoopQCRealeasedFromSQMS, "XXFilterXX", taskFilter,,, CompareMethod.Text))
            DB.ExcuteNoneResult("EXEC dbo.CheckLoopIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateBoxupQCReleasedFromSQMS() As Boolean
        Try
            Dim taskFilter As String = Me.BoxupRequiredTask
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateBoxupQCRealeasedFromSQMS, "XXFilterXX", taskFilter,,, CompareMethod.Text))
            DB.ExcuteNoneResult("EXEC dbo.CheckBoxupIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateSoloRunQCReleasedFromSQMS() As Boolean
        Try
            Dim taskFilter As String = Me.SoloRunRequiredTasks
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateSoloRunQCRealeasedFromSQMS, "XXFilterXX", taskFilter,,, CompareMethod.Text))
            DB.ExcuteNoneResult("EXEC dbo.CheckSolorunIntgerity")
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateEICAMotorsWithHCS() As Boolean
        Try

            Dim taskFilter As String = Me.MotorSoloRunScope
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateEICASoloRunWithSQMS, "XXXFilterXXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateEICABoxupWithHCS() As Boolean
        Try

            Dim taskFilter As String = Me.BoxupScope
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateEICABoxUpWithSQMS, "XXXFilterXXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateEICALoopsWithHCS() As Boolean
        Try
            Dim taskFilter As String = Me.LoopTestScope
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateEICALoopWithSQMS, "XXXFilterXXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateSoloRunQSMSApproved() As Boolean
        Try
            Dim taskFilter As String = Me.MotorSoloRunApproved
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateSoloRunQSMSApproved, "XXXFilterXXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateLoopQSMSApproved() As Boolean
        Try
            Dim taskFilter As String = Me.LoopTestApproved
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateLoopQSMSApproved, "XXXFilterXXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UpdateBoxupQSMSApproved() As Boolean
        Try
            Dim taskFilter As String = Me.BoxupApproved
            DB.ExcuteNoneResult(Replace(My.Resources.UpdateBoxupQSMSApproved, "XXXFilterXXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function CashLoopSQMSTasks() As Boolean
        Try
            Dim taskFilter As String = Me.LoopFolderRequiredTasks
            DB.ExcuteNoneResult(Replace(My.Resources.CashLoopSQMSTasks, "XXFilterXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function CashSoloRunSQMSTasks() As Boolean
        Try
            Dim taskFilter As String = Me.SoloRunRequiredTasks
            DB.ExcuteNoneResult(Replace(My.Resources.CashSoloRunSQMSTasks, "XXFilterXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function CashBoxupSQMSTasks() As Boolean
        Try
            Dim taskFilter As String = Me.BoxupRequiredTask
            DB.ExcuteNoneResult(Replace(My.Resources.CashBoxupSQMSTasks, "XXFilterXX", taskFilter,,, CompareMethod.Text))
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function UPDATEICASubsystemWITHSQMS() As Boolean
        Try
            Dim taskFilter As String = Me.SoloRunRequiredTasks
            DB.ExcuteNoneResult(My.Resources.UpdateSubsystem)
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function CleanningTempTables() As Boolean
        Try
            DB.ExcuteNoneResult("TRUNCATE TABLE TEMPDATA.BoxupTasks")
            DB.ExcuteNoneResult("TRUNCATE TABLE TEMPDATA.BoxupSQMSTasks")
            DB.ExcuteNoneResult("TRUNCATE TABLE TEMPDATA.LoopTasks")
            DB.ExcuteNoneResult("TRUNCATE TABLE TEMPDATA.LoopSQMSTasks")
            DB.ExcuteNoneResult("TRUNCATE TABLE TEMPDATA.SoloRunTasks")
            DB.ExcuteNoneResult("TRUNCATE TABLE TEMPDATA.SoloRunSQMSTasks")
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function
End Class
