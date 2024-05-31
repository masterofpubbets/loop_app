Public Class Solorun

    Public Sub New(ByVal folderName As String,
                   ByVal actualStartDate As DateTime,
                   ByVal actualFinishDate As DateTime,
                   ByVal folderProgress As Double,
                   ByVal loopVendor As String,
                   ByVal loopDescription As String,
                   Optional lFolderPreparation As Date = Nothing,
                   Optional lConstrRelease As Date = Nothing,
                   Optional lQCRelease As Date = Nothing,
                   Optional lFolderReady As Date = Nothing,
                   Optional lSubmittedToPrecom As Date = Nothing,
                   Optional lDone As Date = Nothing,
                   Optional lFinalApproval As Date = Nothing,
                   Optional lArea As String = "",
                   Optional lType As String = "",
                   Optional lSubtype As String = "",
                   Optional lActid As String = "",
                   Optional lSubmitToQC As Date = Nothing,
                   Optional lReturnFromQC As Date = Nothing,
                   Optional lSubsystem As String = "",
                   Optional lPriority As Integer = 0,
                   Optional lPDSModel As String = "",
                   Optional lControllerLocation As String = "",
                   Optional lConsTargetDate As Date = Nothing,
                   Optional lFailedDate As Date = Nothing
                   )

        Me.Name = folderName
        Me.StartDate = actualStartDate
        Me.FinishDate = actualFinishDate
        Me.Progress = folderProgress
        Me.Vendors = loopVendor
        Me.Description = loopDescription
        Me.ControllerLocation = lControllerLocation

        If Not IsNothing(lFolderPreparation) Then Me.FolderPreparation = lFolderPreparation
        If Not IsNothing(lConstrRelease) Then Me.ConstrRelease = lConstrRelease
        If Not IsNothing(lQCRelease) Then Me.QCRelease = lQCRelease
        If Not IsNothing(lFolderReady) Then Me.FolderReady = lFolderReady
        If Not IsNothing(lSubmittedToPrecom) Then Me.SubmittedToPrecom = lSubmittedToPrecom
        If Not IsNothing(lDone) Then Me.Done = lDone
        If Not IsNothing(lFinalApproval) Then Me.FinalApproval = lFinalApproval
        If Not IsNothing(lSubmitToQC) Then Me.SubmittedToQC = lSubmitToQC
        If Not IsNothing(lReturnFromQC) Then Me.ReturnFromQC = lReturnFromQC
        If Not IsNothing(lConsTargetDate) Then Me.ConsTarget = lConsTargetDate
        If Not IsNothing(lFailedDate) Then Me.Failed = lFailedDate

        Me.Area = lArea
        Me.Type = lType
        Me.Subtype = lSubtype
        Me.ActId = lActid
        Me.Subsystem = lSubsystem
        Me.Priority = lPriority
        Me.PDSModel = lPDSModel

    End Sub
    Public Property Name() As String
    Public Property StartDate() As DateTime
    Public Property FinishDate() As DateTime
    Public Property Progress() As Double
    Public Property Vendors() As String
    Public Property Description() As String
    Public Property FolderPreparation() As Date
    Public Property ConstrRelease() As Date
    Public Property QCRelease() As Date
    Public Property FolderReady() As Date
    Public Property SubmittedToPrecom() As Date
    Public Property SubmittedToQC() As Date
    Public Property ReturnFromQC() As Date
    Public Property Done() As Date
    Public Property FinalApproval() As Date
    Public Property Area() As String
    Public Property ActId() As String
    Public Property Type() As String
    Public Property Subtype() As String
    Public Property Subsystem() As String
    Public Property Priority() As Integer
    Public Property PDSModel() As String
    Public Property ControllerLocation() As String
    Public Property ConsTarget() As Date
    Public Property Failed() As Date
End Class
