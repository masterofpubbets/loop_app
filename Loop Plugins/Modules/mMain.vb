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
    Public ILDDBFolder As String = ""
    Public SharedFolder As String = ""


    Public Sub LoadSettings()
        DB.DataBaseLocation = GetSetting("TR", "EIKA", "DBLoc", "TR-SQL-ZOR\TRAPP")
        DB.DataBaseName = GetSetting("TR", "EIKA", "DBName", "TREICAKNPC")
        PCADBName = GetSetting("TR", "EIKA", "PCADBName", "")
        _PCAUpdate = Val(GetSetting("TR", "EIKA", "_PCAUpdate", 0))
        _ValUp = Val(GetSetting("TR", "EIKA", "_ValUp", 0))
        _AutoCutoff = Val(GetSetting("TR", "EIKA", "_AutoCutoff", 0))
        _UpdateSlaveDevise = Val(GetSetting("TR", "EIKA", "_UpdateSlaveDevise", 0))
        _UpdateLoopConsFinished = Val(GetSetting("TR", "EIKA", "_UpdateLoopConsFinished", 0))
        _UpdateInsEqPCA = Val(GetSetting("TR", "EIKA", "_UpdateInsEqPCA", 0))
        _SetInsFinal = Val(GetSetting("TR", "EIKA", "_SetInsFinal", 0))
        _WeekEndDay = Val(GetSetting("TR", "EIKA", "_WeekEndDay", 5))
        ' _TimeInte = Val(GetSetting("TR", "EIKA", "_TimeInte", 20))
        _TimeEna = Val(GetSetting("TR", "EIKA", "_TimeEna", -1))
        _LoopConsReleasedQCBacklog = Val(GetSetting("TR", "EIKA", "LoopConsReleasedQCBacklog", 0))
        UserName = GetSetting("TR", "EIKA", "U", "")
        Password = GetSetting("TR", "EIKA", "P", "")
        ILDDBFolder = GetSetting("TR", "EIKA", "ILDDBFolder", "")
        SharedFolder = GetSetting("TR", "EIKA", "SharedFolder", "")
    End Sub

    Public Sub EICADBConnect()
        LoadSettings()
        Try
            If UserName <> "" Then
                DB.UserName = UserName
                DB.Pass = Password
            End If
            DB.Connect()
        Catch ex As Exception
            MsgBox(String.Format("Database Connection Failed{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub
    Public Sub DBConnect()
        LoadSettings()
        Try
            If FileIO.FileSystem.FileExists(ILDDBFolder & "\ILDDB.ilddb") Then
                AccDB.DataBaseLocation = ILDDBFolder & "\ILDDB.ilddb"
                AccDB.Connect()
            End If
        Catch ex As Exception
            MsgBox(String.Format("Database Connection Failed{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub
End Module
