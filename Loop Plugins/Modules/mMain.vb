Module mMain
    Public DB As New EAMS.DataBaseTools.SQLServerTools
    Public AccDB As New EAMS.DataBaseTools.MSAccessTools

    Public DBPath As String = ""
    Public DBName As String = ""
    Public PCADBName As String = ""
    Public _PCAUpdate As Integer = 0
    Public _ValUp As Integer = 0
    Public _AutoCutoff As Integer = 0
    Public _UpdateSlaveDevise As Integer = 0
    Public _UpdateLoopConsFinished As Integer = 0
    Public _UpdateInsEqPCA As Integer = 0
    Public _SetInsFinal As Integer = 0
    Public _WeekEndDay As Integer = 0
    Public _TimeInte As Integer = 100
    Public _TimeEna As Integer = -1
    Public Const SheetName As String = "Template"
    Public _LoopConsReleasedQCBacklog As Integer = 0
    Public UserName As String = ""
    Public Password As String = ""
    Public ILDDBFile As String = ""
    Public SharedFolder As String = ""
    Private pe As New PublicErrors
    Public RFIPath As String = ""

    Public Const LoopWeblink As String = "https://loopfolder-web.web.app/loopfolder/"


    Public Sub LoadSettings()
        _LoopConsReleasedQCBacklog = Val(GetSetting("TR", "EIKA", "LoopConsReleasedQCBacklog", 0))
        DBPath = GetSetting("TR", "EIKA", "DBLoc", "")
        DBName = GetSetting("TR", "EIKA", "DBName", "")
        UserName = GetSetting("TR", "EIKA", "U", "")
        ILDDBFile = GetSetting("TR", "EIKA", "ILDDBFile", "")
        SharedFolder = GetSetting("TR", "EIKA", "SharedFolder", "")
        RFIPath = GetSetting("TR", "EIKA", "RFIPath", "")
    End Sub

    Public Sub EICADBConnect()
        Try
            DB.DataBaseLocation = DBPath
            DB.DataBaseName = DBName
            DB.Connect()
        Catch ex As Exception
            pe.RaiseDataConnectionError(ex.Message)
        End Try
    End Sub
    Public Sub DBConnect()
        Try
            If FileIO.FileSystem.FileExists(ILDDBFile) Then
                AccDB.DataBaseLocation = ILDDBFile
                AccDB.Connect()
                EICADBConnect()
            Else
                'error for not showing the ilf db
                pe.RaiseReadFileError("Internal DB Not Found.")
            End If
        Catch ex As Exception
            pe.RaiseReadFileError(ex.Message)
        End Try
    End Sub
End Module
