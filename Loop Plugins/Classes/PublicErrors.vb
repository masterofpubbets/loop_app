Public Class PublicErrors
    Public Shared Event DataConnectionError(ByVal er As String)
    Public Shared Event ILDDBConnectionError(ByVal er As String)
    Public Shared Event DataReadError(ByVal er As String)
    Public Shared Event DataExecuteError(ByVal er As String)
    Public Shared Event ReadFileError(ByVal er As String)
    Public Shared Event UnknownError(ByVal er As String)

    Public Sub RaiseDataConnectionError(ByVal er As String)
        RaiseEvent DataConnectionError(er)
    End Sub
    Public Sub RaiseDataReadError(ByVal er As String)
        RaiseEvent DataReadError(er)
    End Sub
    Public Sub RaiseILDDBConnectionError(ByVal er As String)
        RaiseEvent ILDDBConnectionError(er)
    End Sub
    Public Sub RaiseDataExecuteError(ByVal er As String)
        RaiseEvent DataExecuteError(er)
    End Sub
    Public Sub RaiseReadFileError(ByVal er As String)
        RaiseEvent ReadFileError(er)
    End Sub
    Public Sub RaiseUnknownError(ByVal er As String)
        RaiseEvent UnknownError(er)
    End Sub
End Class
