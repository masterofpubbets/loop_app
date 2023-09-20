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
    Public Function SetInstalled(ByVal tag As String, ByVal qcDate As Date, Optional overwrite As Byte = 0) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstInstalled '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "'," & overwrite)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetCalibrated(ByVal tag As String, ByVal qcDate As Date, Optional overwrite As Byte = 0) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstCalibrated '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "'," & overwrite)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetHookup(ByVal tag As String, ByVal qcDate As Date, Optional overwrite As Byte = 0) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstHookup '" & tag & "','" & Format(qcDate, "MM/dd/yyyy") & "'," & overwrite)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearInstalled(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstInstalled '" & tag & "',NULL, 1")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearCalibrated(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstCalibrated '" & tag & "',NULL, 1")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function ClearHookup(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetInstHookup '" & tag & "',NULL, 1")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetHookupName(ByVal tag As String, ByVal hookupName As String) As Boolean
        Try
            If hookupName = "NULL" Then
                DB.ExcuteNoneResult("EXEC PLANNING.SetInstHookupScope '" & tag & "'")
            Else
                DB.ExcuteNoneResult("EXEC PLANNING.SetInstHookupScope '" & tag & "','" & hookupName & "'")
            End If
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function SetCalibrationScope(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.SetInstCalibrationScope '" & tag & "','Yes'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function RemoveCalibrationScope(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.SetInstCalibrationScope '" & tag & "','No'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function RemoveInstallationScope(ByVal tag As String, ByVal scope As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.SetInstallationScope '" & tag & "','" & scope & "'")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
End Class
