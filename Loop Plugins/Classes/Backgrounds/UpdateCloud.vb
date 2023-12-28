Imports System.ComponentModel

Public Class UpdateCloud
    Private bw As BackgroundWorker = New BackgroundWorker
    Private go As Boolean = True
    Public Event CloudUpdated()
    Private lpAPI As New LoopsAPI
    Private fds As LoopFolders
    Public Event Errors(ByVal e As String)
    Private mType As LoopsAPI.MailTypes
    Private usersMailTo As String = "", usersMailCC As String = ""

    Public Sub New()
        bw.WorkerReportsProgress = True
        bw.WorkerSupportsCancellation = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub
    Public Sub Start(ByRef folders As LoopFolders, mailtype As LoopsAPI.MailTypes, mailTo As String, mailCC As String)
        If Not bw.IsBusy = True Then
            fds = folders
            mType = mailtype
            usersMailTo = mailTo
            usersMailCC = mailCC
            bw.RunWorkerAsync()
            go = True
        End If
    End Sub
    Public Sub Cancel()
        If bw.WorkerSupportsCancellation = True Then
            bw.CancelAsync()
            go = False
        End If
    End Sub
    Private Function InternalWorks() As Boolean
        Try
            Dim dt As DataTable = fds.GetLoopsFoldersForPlanning
            For inx As Integer = 0 To dt.Rows.Count - 1
                lpAPI.UpdateFolderStep(dt.Rows(inx).Item("Loop Name"), mType, dt.Rows(inx).Item("Area"), dt.Rows(inx).Item("Description"))
            Next
            Return lpAPI.SendMail(mType, usersMailTo, usersMailCC)
        Catch ex As Exception
            RaiseEvent Errors(ex.Message)
            Return False
        End Try
        Return False
    End Function
    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim DT As New DataTable
        While go
            If bw.CancellationPending = True Then
                e.Cancel = True
            Else
                If InternalWorks() Then
                    RaiseEvent CloudUpdated()
                End If
                e.Cancel = True
            End If
        End While

    End Sub
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        If e.Cancelled = True Then

        ElseIf e.Error IsNot Nothing Then

        Else

        End If
    End Sub
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        'Me.tbProgress.Text = e.ProgressPercentage.ToString() & "%"
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
