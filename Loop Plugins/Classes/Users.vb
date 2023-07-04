Public Class Users
    Public Shared userFullName As String = ""
    Public Shared userName As String = ""
    Public Shared userType As String = ""
    Public Shared ProUUID As String = ""
    Public Shared mail As String = ""
    Public Shared id As Integer
    Public Shared Event userChanged()
    Private pe As New PublicErrors
    Public Shared Event UsersDataChanged()


    Public Function loggin(ByVal loginUserName As String, ByVal password As String) As Integer
        Try
            Dim enc As New EAMS.Coding.EncodeString
            If Val(DB.ExcutResult("SELECT COUNT(*) FROM LOOPS.tblUsers")) = 0 Then
                userType = "admin"
                RaiseEvent userChanged()
                Return -1
            Else
                If DB.ExcutResult("SELECT userType FROM LOOPS.tblUsers WHERE userName ='" & loginUserName & "' AND pass ='" & enc.Encode(password) & "'") = "" Then
                    RaiseEvent userChanged()
                    Return 0
                Else
                    userType = DB.ExcutResult("SELECT userType FROM LOOPS.tblUsers WHERE userName ='" & loginUserName & "' AND pass ='" & enc.Encode(password) & "'")
                    userFullName = DB.ExcutResult("SELECT fullName FROM LOOPS.tblUsers WHERE userName ='" & loginUserName & "' AND pass ='" & enc.Encode(password) & "'")
                    mail = DB.ExcutResult("SELECT email FROM LOOPS.tblUsers WHERE userName ='" & loginUserName & "' AND pass ='" & enc.Encode(password) & "'")
                    id = DB.ExcutResult("SELECT id FROM LOOPS.tblUsers WHERE userName ='" & loginUserName & "' AND pass ='" & enc.Encode(password) & "'")
                    userName = loginUserName
                    RaiseEvent userChanged()
                    Return 1
                End If
            End If
        Catch ex As Exception
            Return 0
        End Try
        Return 0
    End Function
    Public Function ResetPassword(ByVal newPass As String) As Boolean
        Try
            Dim enc As New EAMS.Coding.EncodeString
            DB.ExcuteNoneResult("UPDATE LOOPS.tblUsers SET pass ='" & enc.Encode(newPass) & "' WHERE userName ='" & userName & "'")
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Public Overloads Function GetUsers() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC LOOPS.GetLoopUser"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function

    Public Function AddUser(ByVal userName As String, ByVal fullName As String, ByVal pass As String, ByVal userType As String, ByVal email As String, ByVal department As String, ByVal job As String, userGroup As String, trUserName As String, Optional imgPath As String = "") As Boolean
        Try
            Dim enc As New EAMS.Coding.EncodeString
            DB.ExcuteNoneResult("EXEC LOOPS.AddLoopUser '" & userName & "','" & fullName & "','" & email & "','" & userType & "','" & enc.Encode(pass) & "','" & department & "','" & job & "','" & userGroup & "','" & trUserName & "'")
            If imgPath <> "" Then
                DB.SaveImage(imgPath, "LOOPS.tblUsers", "UserPhoto", "userName", userName)
            End If
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
    Public Function EditUser(ByVal userName As String, ByVal fullName As String, ByVal userType As String, ByVal email As String, ByVal department As String, ByVal job As String, userGroup As String, trUserName As String, img As PictureBox) As Boolean
        Try
            Dim enc As New EAMS.Coding.EncodeString
            DB.ExcuteNoneResult("EXEC LOOPS.EditLoopUser '" & userName & "','" & fullName & "','" & email & "','" & userType & "','" & department & "','" & job & "','" & userGroup & "','" & trUserName & "'")
            DB.SaveImage(img, "LOOPS.tblUsers", "UserPhoto", "userName", userName)
            RaiseEvent UsersDataChanged()
            Return True
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
        End Try
        Return False
    End Function
End Class
