Imports Newtonsoft.Json.Linq

Public Class Firebase
    Private http As New HTTPService

    Public Enum FBPropertyType
        FOLDER_STATUS = 1
        HAS_BLOCKAGE = 2
    End Enum
    Public Function UpdateLoopFolder(ByVal propertyType As FBPropertyType, ByVal loopName As String, Optional folderStatus As String = "", Optional ByVal hasBlockage As String = "") As Boolean
        Try
            Dim result As String = ""
            Dim data As New JObject
            Dim functionName As String = ""
            data.Add("collectionName", "lf-" & Users.ProUUID)
            data.Add("loopName", loopName)
            data.Add("folderStatus", folderStatus)
            data.Add("hasBlockage", hasBlockage)

            Select Case propertyType
                Case FBPropertyType.FOLDER_STATUS
                    functionName = "updateLoopFolderStatus"
                Case FBPropertyType.HAS_BLOCKAGE
                    functionName = "updateLoopFolderHasBlackage"
            End Select

            Return http.httpPost(data, result, "https://us-central1-loopfolder-web.cloudfunctions.net/" & functionName)
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

End Class
