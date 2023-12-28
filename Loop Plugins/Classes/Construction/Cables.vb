Public Class Cables
    Inherits Construction

    Public Function SetPulled(ByVal tag As String, ByVal qnty As Double, ByVal pulledDate As Date, ByVal mark1 As Integer, ByVal mark2 As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC AddPartialEC '" & tag & "'," & qnty & ",'" & Format(pulledDate, "MM/dd/yyyy") & "',NULL,0,'" & Users.userFullName & "'," & mark1 & "," & mark2)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetConFrom(ByVal tag As String, ByVal ConDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetCableConFrom '" & tag & "','" & Format(ConDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetConTo(ByVal tag As String, ByVal ConDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetCableConTo '" & tag & "','" & Format(ConDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetQCReleased(ByVal tag As String, ByVal pulledDate As Date, ByVal mark1 As Integer, ByVal mark2 As String, ByVal rfiNumber As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetCableQCReleased '" & tag & "','" & Format(pulledDate, "MM/dd/yyyy") & "','" & Users.userFullName & "'," & mark1 & "," & mark2 & ",'" & rfiNumber & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetICQCReleased(ByVal tag As String, ByVal pulledDate As Date, ByVal mark1 As Integer, ByVal mark2 As String, ByVal rfiNumber As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetICCableQCReleased '" & tag & "','" & Format(pulledDate, "MM/dd/yyyy") & "','" & Users.userFullName & "'," & mark1 & "," & mark2 & ",'" & rfiNumber & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function ClearQCReleased(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.ClearECCableQCReleased '" & tag & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function ClearICQCReleased(ByVal tag As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.ClearICCableQCReleased '" & tag & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetICConFrom(ByVal tag As String, ByVal ConDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetICCableConFrom '" & tag & "','" & Format(ConDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetICConTo(ByVal tag As String, ByVal ConDate As Date) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.SetICCableConTo '" & tag & "','" & Format(ConDate, "MM/dd/yyyy") & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function SetICPulled(ByVal tag As String, ByVal qnty As Double, ByVal pulledDate As Date, ByVal mark1 As Integer, ByVal mark2 As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC AddPartialIC '" & tag & "'," & qnty & ",'" & Format(pulledDate, "MM/dd/yyyy") & "',NULL,0,'" & Users.userFullName & "'," & mark1 & "," & mark2)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function MoveECIC(ByVal tag As String, Optional ByVal actIdPulling As String = "", Optional ByVal actIdConFrom As String = "", Optional ByVal actIdConTo As String = "", Optional ByVal actIdTest As String = "", Optional ByVal type As String = "") As Boolean
        Try
            Dim sql As String = "EXEC PLANNING.MoveECIC '" & tag & "',"
            If actIdPulling = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdPulling & "',"
            End If
            If actIdConFrom = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdConFrom & "',"
            End If
            If actIdConTo = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdConTo & "',"
            End If
            If actIdTest = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdTest & "',"
            End If
            If type = "" Then
                sql &= "NULL"
            Else
                sql &= "'" & type & "'"
            End If


            DB.ExcuteNoneResult(sql)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function MoveICEC(ByVal tag As String, Optional ByVal actIdPulling As String = "", Optional ByVal actIdConFrom As String = "", Optional ByVal actIdConTo As String = "", Optional ByVal actIdTest As String = "", Optional ByVal type As String = "") As Boolean
        Try
            Dim sql As String = "EXEC PLANNING.MoveICEC '" & tag & "',"
            If actIdPulling = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdPulling & "',"
            End If
            If actIdConFrom = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdConFrom & "',"
            End If
            If actIdConTo = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdConTo & "',"
            End If
            If actIdTest = "" Then
                sql &= "NULL,"
            Else
                sql &= "'" & actIdTest & "',"
            End If
            If type = "" Then
                sql &= "NULL"
            Else
                sql &= "'" & type & "'"
            End If


            DB.ExcuteNoneResult(sql)
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function ChangeRouting(ByVal tag As String, ByVal discipline As String, ByVal routing As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.ChangeCableRoute '" & tag & "','" & discipline & "','" & routing & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function ChangeType(ByVal tag As String, ByVal type As String, ByVal routing As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.ChangeCableType '" & tag & "','" & type & "','" & routing & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function DeleteProduction(ByVal proId As Integer, ByVal discipline As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.DeleteCableProduction " & proId & ",'" & discipline & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function OtherCablePercentage(ByVal proId As Integer, ByVal discipline As String, ByVal tag As String) As Double
        Try
            Return Val(DB.ExcutResult("SELECT CONSTRUCTION.GetCableTotalPercentageOther ('" & tag & "','" & discipline & "'," & proId & ")"))
        Catch ex As Exception
            Return 0
        End Try
        Return 0
    End Function
    Public Function UpdateCableProduction(ByVal proId As Integer, ByVal discipline As String, ByVal percentage As Double, ByVal mark1From As Integer, ByVal mark1To As Integer, ByVal proDate As Date, ByVal actualDrum As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC CONSTRUCTION.UpdateCableProduction '" & discipline & "'," & proId & "," & percentage & ",'" & Format(proDate, "MM/dd/yyyy") & "'," & mark1From & "," & mark1To & ",'" & actualDrum & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function Delete(tag As String, discipline As String) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC PLANNING.DeleteCable '" & tag & "','" & discipline & "'")
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class
