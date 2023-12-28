Imports DevExpress.XtraScheduler.Internal.Implementations
Imports Loop_App.Construction

Public Class ResourcesMan
    Public pe As New PublicErrors

    Public Enum GROUPID
        ElecatricalCable = 100
        InstrumentCable = 200
        ElectricalEquipment = 300
        InstrumentEquipment = 400
        UniversalEquipment = 500
        ElectricalTray = 600
        InstrumentTray = 700
        Instrument = 800
        Lighting = 900
        Items = 1000
        MiscCables = 1100
    End Enum
    Public Overridable Function GetResources() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC dbo.GetResource "))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function IsResourceExists(resourceName As String) As Boolean
        Try
            If DB.ExcutResult("SELECT ResourcesName FROM dbo.tblResources WHERE ResourcesName = '" & resourceName & "'") <> "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return True
        End Try
        Return True
    End Function
    Public Function IsResourceExists(resourceName As String, ByVal id As Integer) As Boolean
        Try
            If DB.ExcutResult("SELECT ResourcesName FROM dbo.tblResources WHERE ResourcesName = '" & resourceName & "' AND id <> " & id) <> "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return True
        End Try
        Return True
    End Function
    Public Function AddResource(filePath As String, resourceName As String, remark As String) As Boolean
        Try
            Dim temp() As String = Split(filePath, ".",, CompareMethod.Text)
            Dim suffix As String = temp(temp.Length - 1)
            If remark = "" Then
                DB.ExcuteNoneResult("EXEC dbo.AddResource '" & resourceName & "','" & suffix & "',NULL")
            Else
                DB.ExcuteNoneResult("EXEC dbo.AddResource '" & resourceName & "','" & suffix & "','" & remark & "'")
            End If

            If filePath <> "" Then DB.SaveBinary(filePath, "tblResources", "Resource", "ResourcesName", resourceName)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Function EditResource(filePath As String, resourceName As String, remark As String, id As Integer, Optional ByVal resourceUpdated As Boolean = False) As Boolean
        Try
            Dim temp() As String = Split(filePath, ".",, CompareMethod.Text)
            Dim suffix As String = temp(temp.Length - 1)
            If remark = "" Then
                DB.ExcuteNoneResult("EXEC dbo.EditResource '" & resourceName & "','" & suffix & "',NULL," & id)
            Else
                DB.ExcuteNoneResult("EXEC dbo.EditResource '" & resourceName & "','" & suffix & "','" & remark & "'," & id)
            End If
            If (filePath <> "") AndAlso resourceUpdated Then
                DB.SaveBinary(filePath, "tblResources", "Resource", "ResourcesName", resourceName)
            End If
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Overridable Function DeleteResource(resId As Integer) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC dbo.DeleteResource " & resId)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Public Sub ShowResource(ByVal resID As Integer)
        Try
            Dim resDT As New DataTable
            resDT = DB.ReturnDataTable("SELECT * FROM dbo.tblResources WHERE id = " & resID)
            If Not IsDBNull(resDT.Rows(0).Item("Resource")) Then
                If resDT.Rows.Count > 0 Then
                    If FileIO.FileSystem.FileExists(Application.StartupPath & "\tmp2\" & resDT.Rows(0).Item("ResourcesName") & "." & resDT.Rows(0).Item("Suffix")) Then
                        FileIO.FileSystem.DeleteFile(Application.StartupPath & "\tmp2\" & resDT.Rows(0).Item("ResourcesName") & "." & resDT.Rows(0).Item("Suffix"))
                    End If
                    Dim _fileData() As Byte = DB.GetImageByte("SELECT [Resource] FROM dbo.tblResources WHERE id = " & resID)
                    My.Computer.FileSystem.WriteAllBytes(Application.StartupPath & "\tmp2\" & resDT.Rows(0).Item("ResourcesName") & "." & resDT.Rows(0).Item("Suffix"), _fileData, False)
                    Process.Start(Application.StartupPath & "\tmp2\" & resDT.Rows(0).Item("ResourcesName") & "." & resDT.Rows(0).Item("Suffix"))
                End If
            End If
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try

    End Sub

    Public Function Assign(resId As Integer, itemId As Integer, ByVal itemGroup As GROUPID) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC ENGINEERING.AssignResource " & resId & "," & itemId & "," & CInt(itemGroup))
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function

End Class
