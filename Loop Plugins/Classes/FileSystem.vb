Imports System.IO

Public Class FileSystem
    Private pe As New PublicErrors

    Public Sub rec(ByVal SourcePath As String)
        Dim SourceDir As DirectoryInfo = New DirectoryInfo(SourcePath)
        Dim pathIndex As Integer
        pathIndex = SourcePath.LastIndexOf("\")
        ' the source directory must exist, otherwise throw an exception

        If SourceDir.Exists Then
            Dim SubDir As DirectoryInfo
            For Each SubDir In SourceDir.GetDirectories()
                Console.WriteLine(SubDir.Name)
                rec(SubDir.FullName)
            Next


            For Each childFile As FileInfo In SourceDir.GetFiles("*", SearchOption.AllDirectories).Where(Function(file) file.Extension.ToLower = ".pdf" Or file.Extension.ToLower = ".docx")
                Console.WriteLine(childFile.Name)
            Next
        Else
            Throw New DirectoryNotFoundException("Source directory does not exist: " + SourceDir.FullName)
        End If

    End Sub
    Public Function FindFile(ByVal filePatern As String, ByVal sourceDirectory As String, Optional fileNames As List(Of String) = Nothing) As List(Of String)
        Try
            Dim SourceDir As DirectoryInfo = New DirectoryInfo(sourceDirectory)
            Dim tmp As New List(Of String)
            For Each childFile As FileInfo In SourceDir.GetFiles(filePatern, SearchOption.AllDirectories)
                tmp.Add(childFile.FullName)
                If Not IsNothing(fileNames) Then fileNames.Add(childFile.Name)
            Next
            Return tmp
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function OpenFile(ByVal filePatern As String, ByVal sourceDirectory As String, Optional fileNames As List(Of String) = Nothing) As Boolean
        Try
            Dim SourceDir As DirectoryInfo = New DirectoryInfo(sourceDirectory)
            Dim tmp As New List(Of String)
            For Each childFile As FileInfo In SourceDir.GetFiles(filePatern, SearchOption.AllDirectories)
                tmp.Add(childFile.FullName)
                If Not IsNothing(fileNames) Then fileNames.Add(childFile.Name)
            Next
            If tmp.Count = 0 Then
                pe.RaiseReadFileError("File not exists.")
                Return False
            End If
            Process.Start(tmp.Item(0))
            Return True
        Catch ex As Exception
            pe.RaiseReadFileError(ex.Message)
        End Try
        Return False
    End Function
    Public Function ReadTextFile(ByVal filePath As String) As String
        Try
            Dim obj As New System.IO.StreamReader(filePath)
            Dim q As String = obj.ReadToEnd
            obj.Close()
            Return q
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return ""
    End Function

End Class
