Imports System.ComponentModel
Public Class EICANotifications
    Private bw As BackgroundWorker = New BackgroundWorker
    Private go As Boolean = True
    Public Event GlobalNotifications(
                                    loopBlockagesCount As Integer,
                                    solorunBlockagesCount As Integer,
                                    PushedNotifications As DataTable,
                                    PushedMappedNotifications As DataTable
                                    )
    Public Event Errors(ByVal e As String)
    Private loopBlockagesCount As Integer = 0
    Private solorunBlockagesCount As Integer = 0
    Private pushedNoti As New DataTable
    Private pushedMappedNoti As New DataTable



    Public Sub New()
        bw.WorkerReportsProgress = True
        bw.WorkerSupportsCancellation = True
        AddHandler bw.DoWork, AddressOf bw_DoWork
        AddHandler bw.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler bw.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub
    Public Sub Start()
        If Not bw.IsBusy = True Then
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
            ' Number of Loop blockages
            loopBlockagesCount = Val(
                DB.ExcutResult("
                    SELECT
                    COUNT(*) AS OpenBlockages
                    FROM LOOPS.tblLoopsCons
                    WHERE issuedToId = " & Users.id & " AND isClosed = 0"
                    )
            )

            ' Number of Solo Run blockages
            solorunBlockagesCount = Val(
                DB.ExcutResult("
                    SELECT
                    COUNT(*) AS OpenBlockages
                    FROM MOTORS.tblFoldersCons
                    WHERE issuedToId = " & Users.id & " AND isClosed = 0"
                    )
            )

            ' Pushed Notifications
            pushedNoti = DB.ReturnDataTable("EXEC TEMPDATA.GetNotification " & Users.id)

            ' Pushed Mapped Notifications
            pushedMappedNoti = DB.ReturnDataTable("EXEC TEMPDATA.GetMappingNotification " & Users.id)
            DB.ExcuteNoneResult("EXEC TEMPDATA.SetAsReadNotification " & Users.id)

            Return True
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
                    RaiseEvent GlobalNotifications(
                                                    loopBlockagesCount,
                                                    solorunBlockagesCount,
                                                    pushedNoti,
                                                    pushedMappedNoti
                                                  )
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
