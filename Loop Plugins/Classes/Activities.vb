Public Class Activities
    Inherits Construction
    Private pe As New PublicErrors

    Public Enum Discipline
        EleCable = 1
        InsCable = 2
        EleTray = 3
        InsTray = 4
        EleJB = 5
        InsJB = 6
        EleEq = 7
        InsEq = 8
        Ins = 9
        Fixture = 10
        MiscItem = 11
        MiscCable = 12
        Equipment = 13
    End Enum
    Public Enum Keys
        Pulling = 1
        Conn1 = 2
        Conn2 = 3
        Test = 4
        Erect = 5
        Calib = 6
        Hook = 7
        GlandFrom = 8
        GlandTo = 9
    End Enum

    Public Function CreateGlandingActivities() As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.CreateGlandingActs")
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function UpdateP6Scope(ByVal PCSDBName As String, ByVal BaseLine As String) As Boolean
        Try
            Dim temp As String
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\EICAPCSU.dll")
            temp = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult(Replace(Replace(Replace(temp, "PCSXXXX", PCSDBName), "BASEXXXX", BaseLine), "EICAXXXX", DB.DataBaseName))
            '
            Dim dt As New DataTable, done As Double = 0
            dt = DB.ReturnDataTable(Replace(Replace(Replace(My.Resources.PCSDone, "PCSXXX", PCSDBName), "EICAxxx", DB.DataBaseName), "Basexxx", BaseLine))
            For Each r As DataRow In dt.Rows
                done = 0
                For iny As Integer = 0 To dt.Columns.Count - 1
                    If dt.Columns.Item(iny).ColumnName.Length = 10 Then
                        done += r(dt.Columns.Item(iny).ColumnName)
                    End If
                Next
                DB.ExcuteNoneResult(String.Format("update tblActIDS set PCSDone={0} where ActID ='{1}'", done, r("actid")))
            Next
            '
            DB.ExcuteNoneResult("UPDATE tblActIDS SET SubCon = LTRIM(SubCon)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET SubCon = RTRIM(SubCon)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET ActID = LTRIM(ActID)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET ActID = RTRIM(ActID)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET PCS_Area = LTRIM(PCS_Area)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET PCS_Area = RTRIM(PCS_Area)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET Family = LTRIM(Family)")
            DB.ExcuteNoneResult("UPDATE tblActIDS SET Family = RTRIM(Family)")

            Return CreateGlandingActivities()
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function UpdateActIds(ByVal disc As Discipline, ByVal key As Keys, ByVal tag As String, ByVal actId As String) As Boolean
        Try
            If actId <> "" Then
                DB.ExcuteNoneResult("EXEC PLANNING.ChangeActIds '" & tag & "','" & actId & "','" & disc.ToString & "','" & key.ToString & "'")
            Else
                DB.ExcuteNoneResult("EXEC PLANNING.ChangeActIds '" & tag & "',NULL,'" & disc.ToString & "','" & key.ToString & "'")
            End If
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function

    Public Function UpdateArea(ByVal disc As Discipline, ByVal tag As String, ByVal area As String) As Boolean
        Try
            If area <> "" Then
                DB.ExcuteNoneResult("EXEC PLANNING.ChangeArea '" & tag & "','" & area & "','" & disc.ToString & "'")
            End If
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Function UpdateTeam(ByVal disc As Discipline, ByVal tag As String, ByVal team As String) As Boolean
        Try
            If team <> "" Then
                DB.ExcuteNoneResult("EXEC PLANNING.ChangeTeam '" & tag & "','" & team & "','" & disc.ToString & "'")
            Else
                DB.ExcuteNoneResult("EXEC PLANNING.ChangeTeam '" & tag & "'," & "NULL" & ",'" & disc.ToString & "'")
            End If
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Function SetWorkfront(ByVal disc As Discipline, ByVal key As Keys, ByVal tag As String, ByVal wfDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.SetWorkfront '" & tag & "','" & Format(wfDate, "MM/dd/yyyy") & "','" & disc.ToString & "','" & key.ToString & "'")
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Function ClearWorkfront(ByVal disc As Discipline, ByVal key As Keys, ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.SetWorkfront '" & tag & "',NULL,'" & disc.ToString & "','" & key.ToString & "'")
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Function IsActivityExists(ByVal actId As String, Optional actName As String = "") As Boolean
        If actName <> "" Then
            If DB.ExcutResult("SELECT ActID FROM tblActIDS WHERE ActName ='" & actName & "'") = "" Then
                Return False
            Else
                Return True
            End If
        Else
            If DB.ExcutResult("SELECT ActID FROM tblActIDS WHERE ActID ='" & actId & "'") = "" Then
                Return False
            Else
                Return True
            End If
        End If
        Return True
    End Function
    Public Function AddActivity(ByVal ActID As String, ByVal ActName As String, ByVal PCS_Area As String, ByVal SubCon As String, ByVal PCS_Budget As Double, ByVal Family As String, ByVal EICA_Area As String, ByVal EICA_Budget As Double, ByVal Package As String, ByVal EstimatedScope As Double, ByVal KeyQnty As Byte, ByVal WPS As String, ByVal ResourceId As String, ByVal ResourceName As String, ByVal Location As String, ByVal Team As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal UOM As String) As Boolean
        Try
            Dim sqlData As String = ""
            sqlData &= "'" & ActID & "',"
            sqlData &= "'" & ActName & "',"
            sqlData &= "'" & PCS_Area & "',"
            sqlData &= "'" & SubCon & "',"
            sqlData &= "" & PCS_Budget & ","
            sqlData &= "'" & Family & "',"
            sqlData &= "'" & EICA_Area & "',"
            sqlData &= "" & EICA_Budget & ","
            sqlData &= "'" & Package & "',"
            sqlData &= "" & EstimatedScope & ","
            sqlData &= "" & KeyQnty & ","
            sqlData &= "'" & WPS & "',"
            sqlData &= "'" & ResourceId & "',"
            sqlData &= "'" & ResourceName & "',"
            sqlData &= "'" & Location & "',"
            sqlData &= "'" & Team & "',"
            sqlData &= "'" & Format(StartDate, "MM/dd/yyyy") & "',"
            sqlData &= "'" & Format(EndDate, "MM/dd/yyyy") & "',"
            sqlData &= "'" & UOM & "'"
            DB.ExcuteNoneResult("EXEC PLANNING.AddActivity " & sqlData)
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function

End Class
