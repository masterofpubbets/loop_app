Public Class Lighting
    Inherits Construction


    Public Function UpdateInstalled(ByVal id As Integer, ByVal installedDate As Date, Optional overwrite As Byte = 0) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetLightingInstalled " & id & ",'" & Format(installedDate, "MM/dd/yyyy") & "','" & Users.userFullName & "'," & overwrite)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

End Class
