
Public Class SolorunSteps

    Public Overloads Function getSteps() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC MOTORS.GetFoldersHCS"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Overloads Function getConstraints() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC MOTORS.GetFolderConstraints"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function addBlockage(ByVal catName As String, ByVal folderId As Integer, ByVal loopName As String, ByVal loopDesc As String, ByVal loopArea As String, ByVal description As String, ByVal issuedByName As String, ByVal issuedByEmail As String, ByVal issuedById As Integer, ByVal issuedToName As String, ByVal issuedToEmail As String, ByVal issuedToId As Integer, ByVal loopStatus As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC MOTORS.AddBlockage '{0}', {1}, '{2}', {3},{4}", catName, folderId, Replace(description, "'", "''",,, CompareMethod.Text), issuedById, issuedToId))

            'Register Notification
            DB.ExcuteNoneResult("TEMPDATA.PushNotification '" & issuedByName & "'," & issuedToId & ",'Solo Run Blockage','" & loopName & "','" & description & "'")

        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function closeBlockage(ByVal folderId As Integer) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC MOTORS.CloseBlockage {0},{1}", folderId, Users.id))
            Return True
            'Call API for folder Approved
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function reassignResponsible(ByVal catName As String, ByVal consId As Integer, ByVal folderId As Integer, ByVal folderName As String, ByVal loopDesc As String, ByVal loopArea As String, ByVal description As String, ByVal issuedByName As String, ByVal issuedByEmail As String, ByVal issuedById As Integer, ByVal issuedToName As String, ByVal issuedToEmail As String, ByVal issuedToId As Integer, ByVal loopStatus As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC MOTORS.ReassignBlockage {0}, '{1}', {2}, '{3}', {4},{5},{6}", consId, catName, folderId, Replace(description, "'", "''",,, CompareMethod.Text), issuedById, issuedToId, Users.id))
            'Call API for folder Approved
            '-----------------------------
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function addComment(ByVal folderId As Integer, ByVal comment As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC MOTORS.AddComment {0},'{1}'", folderId, comment))
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function removeComment(ByVal folderId As Integer) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("EXEC MOTORS.AddComment {0},NULL", folderId))
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class
