Public Class LoopProcess
    Public Event TotalRows(ByVal Count As Integer)
    Public Event Progress(ByVal inx As Integer)
    Public Event Finished()
    Public Event Err(ByVal dec As String)

#Region "Loop Tasks"
    Public Sub UpdateWarRoom(ByVal filePath As String)
        Dim exl As New EAMS.MSOffice.Excel, dt As New DataTable
        Dim inx As Integer = 0
        dt = exl.GetSheetData(filePath, "Template")
        RaiseEvent TotalRows(dt.Rows.Count)
        Try
            For inx = 0 To dt.Rows.Count - 1
                If ((Not IsDBNull(dt.Rows(inx).Item("Meeting Date"))) And (Not IsDBNull(dt.Rows(inx).Item("Loop Name")))) Then
                    'Material
                    If Not IsDBNull(dt.Rows(inx).Item("Material Constrain")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Material Constrain] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Material Constrain"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Material Constrain]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Material Constrain")))
                        End If
                    End If
                    '--------------------
                    'Construction Target Date
                    If Not IsDBNull(dt.Rows(inx).Item("Construction Target Date")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Construction Target Date] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Construction Target Date"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Construction Target Date]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Construction Target Date")))
                        End If
                    End If
                    '--------------------
                    'Construction Constraint
                    If Not IsDBNull(dt.Rows(inx).Item("Construction Constraint")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Construction Constraint] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Construction Constraint"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Construction Constraint]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Construction Constraint")))
                        End If
                    End If
                    '--------------------
                    'Construction Action BY
                    If Not IsDBNull(dt.Rows(inx).Item("Construction Action BY")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Construction Action BY] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Construction Action BY"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Construction Action BY]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Construction Action BY")))
                        End If
                    End If
                    '--------------------
                    'QC Target Date
                    If Not IsDBNull(dt.Rows(inx).Item("QC Target Date")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [QC Target Date] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("QC Target Date"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[QC Target Date]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("QC Target Date")))
                        End If
                    End If
                    '--------------------
                    'QC Constraint
                    If Not IsDBNull(dt.Rows(inx).Item("QC Constraint")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [QC Constraint] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("QC Constraint"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[QC Constraint]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("QC Constraint")))
                        End If
                    End If
                    '--------------------
                    'QC Action BY
                    If Not IsDBNull(dt.Rows(inx).Item("QC Action BY")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [QC Action BY] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("QC Action BY"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[QC Action BY]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("QC Action BY")))
                        End If
                    End If
                    '--------------------
                    'HCS Target Date
                    If Not IsDBNull(dt.Rows(inx).Item("HCS Target Date")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [HCS Target Date] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("HCS Target Date"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[HCS Target Date]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("HCS Target Date")))
                        End If
                    End If
                    '--------------------
                    'HCS Constraint
                    If Not IsDBNull(dt.Rows(inx).Item("HCS Constraint")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [HCS Constraint] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("HCS Constraint"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[HCS Constraint]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("HCS Constraint")))
                        End If
                    End If
                    '--------------------
                    'HCS Action BY
                    If Not IsDBNull(dt.Rows(inx).Item("HCS Action BY")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [HCS Action BY] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("HCS Action BY"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[HCS Action BY]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("HCS Action BY")))
                        End If
                    End If
                    '--------------------
                    'Precomm Target Date
                    If Not IsDBNull(dt.Rows(inx).Item("Precomm Target Date")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Precomm Target Date] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Precomm Target Date"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Precomm Target Date]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Precomm Target Date")))
                        End If
                    End If
                    '--------------------
                    'Precomm Constraint
                    If Not IsDBNull(dt.Rows(inx).Item("Precomm Constraint")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Precomm Constraint] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Precomm Constraint"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Precomm Constraint]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Precomm Constraint")))
                        End If
                    End If
                    '--------------------
                    'Precomm Action BY
                    If Not IsDBNull(dt.Rows(inx).Item("Precomm Action BY")) Then
                        If AccDB.ExcutResult(String.Format("select [Loop Name] from tblWarRoom where [Loop Name]='{0}'", dt.Rows(inx).Item("Loop Name"))) <> "" Then
                            AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set [Precomm Action BY] ='{0}' where [Loop Name]='{1}'", dt.Rows(inx).Item("Precomm Action BY"), dt.Rows(inx).Item("Loop Name")))
                        Else
                            AccDB.ExcuteNoneResult(String.Format("insert into tblWarRoom ([Meeting Date],[Loop Name],[Precomm Action BY]) values ('{0}','{1}','{2}')", dt.Rows(inx).Item("Meeting Date"), dt.Rows(inx).Item("Loop Name"), dt.Rows(inx).Item("Precomm Action BY")))
                        End If
                    End If
                    '--------------------
                End If
                Application.DoEvents()
                RaiseEvent Progress(inx + 1)
            Next
            RaiseEvent Finished()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Public Sub UpdateFolderStatus()
        Try
            Dim dt As New DataTable
            Dim dtWR As New DataTable, dr As DataRow()
            dtWR = AccDB.ReturnDataTable("select [Loop Name] from tblWarRoom")
            dt = DB.ReturnDataTable(My.Resources.FolderStatus)
            RaiseEvent TotalRows(dtWR.Rows.Count)
            For inx As Integer = 0 To dtWR.Rows.Count - 1
                dr = dt.Select(String.Format("LoopName ='{0}'", dtWR.Rows(inx).Item("Loop Name")))
                AccDB.ExcuteNoneResult(String.Format("update tblWarRoom set STATUS='{0}' where [Loop Name]='{1}'", dr(0).Item("Folder Location"), dtWR.Rows(inx).Item("Loop Name")))
                Application.DoEvents()
                RaiseEvent Progress(inx + 1)
            Next
            RaiseEvent Finished()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Public Sub UpdateDeactivatedLoopInHCS()
        Try
            DB.ExcuteNoneResult(My.Resources.UpdateDeactivatedLoopInHCS)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub UpdateLoopInfoFromHCS()
        Try
            DB.ExcuteNoneResult(My.Resources.UpdateLoopInfoFromHCS, 99999)
            DB.ExcuteNoneResult(My.Resources.UpdateLoopTargetDate, 99999)
        Catch ex As Exception
        End Try
    End Sub
#End Region

End Class
