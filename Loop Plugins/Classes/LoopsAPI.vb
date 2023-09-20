Public Class LoopsAPI
    Private php As New HTTPService
    Private fb As New Firebase


    Public Enum MailTypes
        FolderPrepared = 1
        FolderReady = 2
        FolderApproved = 3
        SubmittedToPrecomm = 4
        LoopDone = 5
        FolderBlockage = 6
        ConstructionReleased = 7
        QCReleased = 8
        ResolvedBlockage = 9
    End Enum

    Private Function GetStepName(ByVal stepName As MailTypes) As String
        Dim step_Name As String = ""
        Select Case stepName
            Case MailTypes.FolderApproved
                step_Name = "FolderApproved"
            Case MailTypes.ConstructionReleased
                step_Name = "ConstructionReleased"
            Case MailTypes.FolderBlockage
                step_Name = "FolderBlockage"
            Case MailTypes.FolderPrepared
                step_Name = "FolderPrepared"
            Case MailTypes.FolderReady
                step_Name = "FolderReady"
            Case MailTypes.LoopDone
                step_Name = "LoopDone"
            Case MailTypes.SubmittedToPrecomm
                step_Name = "SubmittedToPrecomm"
            Case MailTypes.QCReleased
                step_Name = "QCReleased"
        End Select
        Return step_Name
    End Function
    Public Function UpdateFolderStep(ByVal tag As String, ByVal stepName As MailTypes, ByVal area As String, ByVal description As String) As Boolean
        Try
            Dim url As String = "https://trprojectssolutions.com/loops/addnewfolder.php?loopname=" & tag & "&loopstatus=" & GetStepName(stepName) & "&prouuid=" & Users.ProUUID & "&area=" & area & "&description=" & Replace(description, "&", "and",,, CompareMethod.Text)
            If php.httpGet(url) = "done" Then
                Return fb.UpdateLoopFolder(Firebase.FBPropertyType.FOLDER_STATUS, tag, GetStepName(stepName))
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function SendMail(ByVal mailType As MailTypes, ByVal mailTo As String, ByVal mailCC As String) As Boolean
        Try
            Dim url As String = ""
            Select Case mailType
                Case MailTypes.FolderBlockage
                    url = "https://trprojectssolutions.com/loops/sendblockagenotifications.php?mailcc=" & mailTo
                Case MailTypes.SubmittedToPrecomm
                    url = "https://trprojectssolutions.com/loops/sendblockagenotifications.php?mailcc=" & mailTo
                Case Else
                    url = "https://trprojectssolutions.com/loops/sendloopnotification.php?" & "loopstatus=" & GetStepName(mailType) & "&prouuid=" & Users.ProUUID & "&tocc=" & mailCC & "&toc=" & mailTo
            End Select
            If php.httpGet(url) = "The email message was sent." Then
                Return True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function ClearSendedLoops() As Boolean
        Try
            Dim url As String = "https://trprojectssolutions.com/loops/clearloops.php?prouuid=" & Users.ProUUID
            If php.httpGet(url) = "done" Then
                Return True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function AddBlockage(ByVal loopName As String, ByVal area As String, ByVal description As String, ByVal blockage As String, ByVal issuedTo As String, ByVal issuedToMail As String, ByVal issuedBy As String, ByVal issuedByMail As String, ByVal loopStatus As String) As Boolean
        Try
            Dim url As String = "https://trprojectssolutions.com/loops/addblockage.php?loopname=" & loopName & "&area=" & area & "&description=" & Replace(description, "&", "and",,, CompareMethod.Text) & "&blockage=" & blockage & "&issuedto=" & issuedTo & "&issuedtomail=" & issuedToMail & "&issuedby=" & issuedBy & "&issuedbymail=" & issuedByMail & "&loopstatus=" & loopStatus
            If php.httpGet(url) = "done" Then
                Return (fb.UpdateLoopFolder(Firebase.FBPropertyType.HAS_BLOCKAGE, loopName, "", "Yes"))
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function ResolveBlockage(ByVal loopName As String, ByVal area As String, ByVal description As String, ByVal blockage As String, ByVal issuedTo As String, ByVal issuedToMail As String, ByVal issuedBy As String, ByVal issuedByMail As String, ByVal loopStatus As String) As Boolean
        'not developed
        Try
            Dim url As String = "https://trprojectssolutions.com/loops/resolveblockage.php?loopname=" & loopName & "&area=" & area & "&description=" & Replace(description, "&", "and",,, CompareMethod.Text) & "&blockage=" & blockage & "&issuedto=" & issuedTo & "&issuedtomail=" & issuedToMail & "&issuedby=" & issuedBy & "&issuedbymail=" & issuedByMail & "&loopstatus=" & loopStatus
            If php.httpGet(url) = "done" Then
                Return True
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Function GenerateAndSaveQRCode() As Boolean
        Dim dt As New DataTable

        Dim qrcode As String = ""
        Dim qr As New QRCode
        dt = DB.ReturnDataTable("SELECT [TBL_ID], LoopName, ProUUID, qrCode FROM [tblInsLoop]")
        Try
            For inx As Integer = 0 To dt.Rows.Count - 1
                qrcode = LoopWeblink & dt.Rows(inx).Item("ProUUID") & "/" & dt.Rows(inx).Item("LoopName")
                Dim qrImgPath As String = qr.GenerateQRCode(qrcode, dt.Rows(inx).Item("LoopName"))
                'save to db
                DB.SaveBinary(qrImgPath, "tblInsLoop", "qrCode", "LoopName", dt.Rows(inx).Item("LoopName"))
                'delete
                If FileIO.FileSystem.FileExists(qrImgPath) Then
                    FileIO.FileSystem.DeleteFile(qrImgPath)
                End If
            Next
            Return True
        Catch ex As Exception

        End Try
        Return (False)
    End Function
    Public Function GenerateQRCode(ByVal loopName As String) As Image
        Dim dt As New DataTable
        Dim qr As New QRCode
        Try
            Dim qrcode As String = LoopWeblink & Users.ProUUID & "/" & loopName
            Return qr.GenerateQRCode(qrcode)
        Catch ex As Exception


        End Try
        Return (Nothing)
    End Function

End Class
