Public Class Equipment
    Inherits Construction
    Private ReadOnly pe As New PublicErrors


    Public Function SetInstalled(ByVal tag As String, ByVal installedDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetEquipmentInstalled '" & tag & "','" & Format(installedDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearInstalled(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetEquipmentInstalled '" & tag & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetQCReleased(ByVal tag As String, ByVal qcDate As Date, ByVal rfiNo As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetEquipmentQC '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "','" & rfiNo & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearQCReleased(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.ClearEquipmentQC '" & tag & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function

End Class
