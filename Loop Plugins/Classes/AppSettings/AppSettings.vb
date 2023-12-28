Imports System.ComponentModel

Public Class AppSettings
    Private pe As New PublicErrors

    Public Property LoopIntegrity() As Boolean
        Get
            Try
                Return (
                    IIf(
                    DB.ExcutResult("SELECT LoopIntegrity FROM dbo.AppSettings WHERE Id = (SELECT MAX(Id) FROM dbo.AppSettings)") = "True",
                    True, False
                    ))
            Catch ex As Exception
                pe.RaiseDataReadError(ex.Message)
            End Try
            Return False
        End Get
        Set(ByVal value As Boolean)
            Try
                If value Then
                    DB.ExcuteNoneResult("UPDATE dbo.AppSettings SET LoopIntegrity = 1")
                Else
                    DB.ExcuteNoneResult("UPDATE dbo.AppSettings SET LoopIntegrity = 0")
                End If
            Catch ex As Exception
                pe.RaiseDataExecuteError(ex.Message)
            End Try
        End Set
    End Property
    Public ReadOnly Property DBVersion() As String
        Get
            Try
                Return (
                    DB.ExcutResult("SELECT SetValue FROM [dbo].[tblSettings] WHERE SetName = 'VERSION'"))
            Catch ex As Exception
                pe.RaiseDataReadError(ex.Message)
            End Try
            Return ""
        End Get
    End Property
    Public ReadOnly Property LoopMailTo(ByVal stepName As LoopsAPI.MailTypes) As String
        Get
            Dim mType As String = "", mailTo As String = ""
            Select Case stepName
                Case LoopsAPI.MailTypes.ConstructionReleased
                    mType = "ConsComplete"
                Case LoopsAPI.MailTypes.FolderApproved
                    mType = "FolderApproved"
                Case LoopsAPI.MailTypes.FolderBlockage
                    mType = "FolderBlockage"
                Case LoopsAPI.MailTypes.FolderPrepared
                    mType = "FolderPrepared"
                Case LoopsAPI.MailTypes.FolderReady
                    mType = "FolderReady"
                Case LoopsAPI.MailTypes.LoopDone
                    mType = "LoopDone"
                Case LoopsAPI.MailTypes.QCReleased
                    mType = "QCReleased"
                Case LoopsAPI.MailTypes.SubmittedToPrecomm
                    mType = "SubmittedToPrecomm"
                Case LoopsAPI.MailTypes.ResolvedBlockage
                    mType = "FolderBlockage"
                Case LoopsAPI.MailTypes.ReturnFromQC
                    mType = "ReturnFromQC"
                Case LoopsAPI.MailTypes.SubmitToQC
                    mType = "SubmitToQC"
            End Select
            Try
                Dim dt As DataTable = DB.ReturnDataTable(String.Format("SELECT email FROM LOOPS.tblUsers WHERE UserGroup LIKE '%{0}%'", mType))
                For inx As Integer = 0 To dt.Rows.Count - 1
                    mailTo &= dt.Rows(inx).Item("email")
                Next
                Return (mailTo)
            Catch ex As Exception
                Return ""
            End Try
            Return ""
        End Get
    End Property

    Public Property CableIntegrity As Boolean
    Public Property EquipmentIntegrity As Boolean
    Public Property InstrumentIntegrity As Boolean
    Public Property MotorIntegrity As Boolean

End Class
