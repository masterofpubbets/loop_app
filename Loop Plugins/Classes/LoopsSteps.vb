Public Class LoopsSteps
    Private loopAPI As New LoopsAPI


    Private Function GenerateUUID() As String
        Dim myuuid As Guid = Guid.NewGuid()
        Return myuuid.ToString()
    End Function

    Public Function SendNotificationsMail(ByVal stepName As LoopsAPI.MailTypes) As Boolean
        Try
            Dim sql As String = ""
            Dim dt As New DataTable
            Dim mailTo = ""

            Select Case stepName
                Case LoopsAPI.MailTypes.FolderApproved
                    'send mail for folder qc approved
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%FolderApproved%'"
                Case LoopsAPI.MailTypes.ConstructionReleased
                    'send mail for folder construction released
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE department LIKE '%qc%' OR department LIKE '%pre%com%'"
                Case LoopsAPI.MailTypes.FolderBlockage
                    ' step_Name = "FolderBlockage"
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%FolderBlockage%'"
                Case LoopsAPI.MailTypes.FolderPrepared
                    'send mail for folder prepared
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%FolderPrepared%'"
                Case LoopsAPI.MailTypes.FolderReady
                    'send mail for folder ready
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%FolderReady%'"
                Case LoopsAPI.MailTypes.LoopDone
                    'send mail for folder loop done
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%LoopDone%'"
                Case LoopsAPI.MailTypes.SubmittedToPrecomm
                    'send mail for folder submitted to precomm
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%SubmittedToPrecomm%'"
                Case LoopsAPI.MailTypes.QCReleased
                    'send mail for folder QC Released
                    sql = "SELECT [email],[UserGroup] FROM [LOOPS].[tblUsers] WHERE userGroup LIKE '%QCReleased%'"
            End Select

            dt = DB.ReturnDataTable(sql)
            mailTo = ""
            For inx As Integer = 0 To dt.Rows.Count - 1
                mailTo &= dt.Rows(inx).Item("email").ToString & ","
            Next
            If loopAPI.SendMail(stepName, mailTo, "ealy@trsa.es") Then
                Return loopAPI.ClearSendedLoops()
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Overloads Function getLoopsSteps() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC LOOPS.GetLoopsHCS"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Overloads Function getLoopsConstraints() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC LOOPS.GetLoopsConstraints"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function setHCSFolderPrepared(ByVal tag As String, stepDate As Date, ByVal area As String, ByVal description As String, Optional ByRef results As String = "") As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.UpdateLoopFolderPrepartion '{0}', '{1}'", tag, Format(stepDate, "MM/dd/yyyy")))
            'Call API for folder Prepartion
            loopAPI.UpdateFolderStep(tag, LoopsAPI.MailTypes.FolderPrepared, area, description)
            '------------------------------
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function setHCSFolderApproved(ByVal tag As String, stepDate As Date, ByVal area As String, ByVal description As String, Optional ByRef results As String = "") As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.UpdateLoopFolderApproved '{0}', '{1}'", tag, Format(stepDate, "MM/dd/yyyy")))
            'Call API for folder Approved
            loopAPI.UpdateFolderStep(tag, LoopsAPI.MailTypes.FolderApproved, area, description)
            '------------------------------
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function setHCSFolderQCReleased(ByVal tag As String, stepDate As Date, ByVal area As String, ByVal description As String, Optional ByRef results As String = "") As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.UpdateLoopQCReleased '{0}', '{1}'", tag, Format(stepDate, "MM/dd/yyyy")))
            'Call API for folder Approved
            loopAPI.UpdateFolderStep(tag, LoopsAPI.MailTypes.QCReleased, area, description)
            '------------------------------
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function setHCSFolderReady(ByVal tag As String, stepDate As Date, ByVal area As String, ByVal description As String, Optional ByRef results As String = "") As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.UpdateLoopFolderReady '{0}', '{1}'", tag, Format(stepDate, "MM/dd/yyyy")))
            'Call API for folder Approved
            loopAPI.UpdateFolderStep(tag, LoopsAPI.MailTypes.FolderReady, area, description)
            '------------------------------
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function setHCSFolderSubmitToPrecomm(ByVal tag As String, stepDate As Date, ByVal area As String, ByVal description As String, Optional ByRef results As String = "") As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.UpdateLoopSubmitToPrecomm '{0}', '{1}'", tag, Format(stepDate, "MM/dd/yyyy")))
            'Call API for folder Approved
            loopAPI.UpdateFolderStep(tag, LoopsAPI.MailTypes.SubmittedToPrecomm, area, description)
            '------------------------------
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function setHCSFolderDone(ByVal tag As String, stepDate As Date, ByVal area As String, ByVal description As String, Optional ByRef results As String = "") As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.UpdateLoopDone '{0}', '{1}'", tag, Format(stepDate, "MM/dd/yyyy")))
            'Call API for folder Approved
            loopAPI.UpdateFolderStep(tag, LoopsAPI.MailTypes.LoopDone, area, description)
            '------------------------------
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function addBlockage(ByVal catName As String, ByVal loopId As Integer, ByVal loopName As String, ByVal loopDesc As String, ByVal loopArea As String, ByVal description As String, ByVal issuedByName As String, ByVal issuedByEmail As String, ByVal issuedById As Integer, ByVal issuedToName As String, ByVal issuedToEmail As String, ByVal issuedToId As Integer, ByVal loopStatus As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.AddBlockage '{0}', {1}, '{2}', {3},{4}", catName, loopId, Replace(description, "'", "''",,, CompareMethod.Text), issuedById, issuedToId))
            'Call API for folder Approved
            loopAPI.AddBlockage(loopName, loopArea, loopDesc, description, issuedToName, issuedToEmail, issuedByName, issuedByEmail, loopStatus)
            '------------------------------
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function closeBlockage(ByVal loopId As Integer) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.CloseBlockage {0}", loopId))
            Return True
            'Call API for folder Approved
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function reassignResponsible(ByVal catName As String, ByVal consId As Integer, ByVal loopId As Integer, ByVal loopName As String, ByVal loopDesc As String, ByVal loopArea As String, ByVal description As String, ByVal issuedByName As String, ByVal issuedByEmail As String, ByVal issuedById As Integer, ByVal issuedToName As String, ByVal issuedToEmail As String, ByVal issuedToId As Integer, ByVal loopStatus As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.ReassignBlockage {0}, '{1}', {2}, '{3}', {4},{5}", consId, catName, loopId, Replace(description, "'", "''",,, CompareMethod.Text), issuedById, issuedToId))
            'Call API for folder Approved
            loopAPI.AddBlockage(loopName, loopArea, loopDesc, description, issuedToName, issuedToEmail, issuedByName, issuedByEmail, loopStatus)
            '-----------------------------
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function addComment(ByVal loopId As Integer, ByVal comment As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.AddComment {0},'{1}'", loopId, comment))
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function removeComment(ByVal loopId As Integer) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC LOOPS.AddComment {0},NULL", loopId))
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class
