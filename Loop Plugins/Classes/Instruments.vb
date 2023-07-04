Public Class Instruments
    Inherits Construction
    Private ReadOnly pe As New PublicErrors


    Public Function SetInstalledQCReleased(ByVal tag As String, ByVal qcDate As Date, ByVal rfiNo As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstQCInstalled '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "','" & rfiNo & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearInstalledQCReleased(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstQCInstalled '" & tag & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetCalibrationQCReleased(ByVal tag As String, ByVal qcDate As Date, ByVal rfiNo As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetCalibrationQCInstalled '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "','" & rfiNo & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearCalibrationQCReleased(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetCalibrationQCInstalled '" & tag & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetHookupQCReleased(ByVal tag As String, ByVal qcDate As Date, ByVal rfiNo As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetHookupQCInstalled '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "','" & rfiNo & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearHookupQCReleased(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetHookupQCInstalled '" & tag & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetInstalled(ByVal tag As String, ByVal qcDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstInstalled '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetCalibrated(ByVal tag As String, ByVal qcDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstCalibrated '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetHookup(ByVal tag As String, ByVal qcDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstHookup '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
End Class
