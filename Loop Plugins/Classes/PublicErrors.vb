Public Class PublicErrors
    Public Shared Event DataConnectionError()
    Public Shared Event ILDDBConnectionError()
    Public Shared Event DataReadError()
    Public Shared Event DataExecuteError(ByVal er As String)
    Public Shared Event ReadFileError(ByVal er As String)

    Public Sub RaiseDataConnectionError()
        RaiseEvent DataConnectionError()
    End Sub
    Public Sub RaiseDataReadError()
        RaiseEvent DataReadError()
    End Sub
    Public Sub RaiseILDDBConnectionError()
        RaiseEvent ILDDBConnectionError()
    End Sub
    Public Sub RaiseDataExecuteError(ByVal er As String)
        RaiseEvent DataExecuteError(er)
    End Sub
    Public Sub RaiseReadFileError(ByVal er As String)
        RaiseEvent ReadFileError(er)
    End Sub
End Class
