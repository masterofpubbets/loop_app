Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Public Class Notifications


    Public Shared Function PushMappedNotification(issuedByName As String, issuedToId As Integer, header As String, description As String, mappingFilter As String)
        Try
            DB.ExcuteNoneResult("TEMPDATA.PushNotification '" & issuedByName & "'," & issuedToId & ",'" & header & "',NULL ,'" & description & "','" & mappingFilter & "'")

        Catch ex As Exception

        End Try
        Return False
    End Function
End Class
