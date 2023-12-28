Imports System.ComponentModel

Public Class LoopTask
    Private pe As New PublicErrors

    Public Sub New(ByVal taskName As String, ByVal taskDescription As String, ByVal taskId As Integer, ByVal taskParentId As Integer, ByVal taskArea As String, ByVal taskLoops As Integer, ByVal taskvendors As String, ByVal taskSats As Integer, ByVal taskSatsDone As Integer, ByVal taskSatLateFinishedDate As String, ByVal startDate As String, ByVal endDate As String,
                   ByVal taskDuration As Integer, ByVal taskLoopDone As Double, ByVal taskProgress As Double, ByVal item_Type As String, ByVal taskDependencyType As String, ByVal taskDependencyLag As Double, ByVal successorIds() As Integer, ByVal predecessorIds() As Integer
                   )
        Me.Name = taskName
        Me.Description = taskDescription
        Me.Id = taskId
        Me.ParentId = taskParentId
        Me.Area = taskArea
        Me.Loops = taskLoops
        Me.Vendors = taskvendors
        Me.Sats = taskSats
        Me.SatDone = taskSatsDone
        Me.ItemType = item_Type

        Try
            If taskSatLateFinishedDate <> "" Then Me.SatLateFinishedDate = CDate(taskSatLateFinishedDate)

            If startDate <> "" Then
                Me.StartDate = CDate(startDate)
            End If
            If endDate <> "" Then
                Me.FinishDate = CDate(endDate)
            End If
            If ((endDate <> "") And (startDate <> "")) Then
                Me.Duration = TimeSpan.FromDays(DateDiff(DateInterval.Day, CDate(startDate), CDate(endDate)))
            End If

            Me.LoopDone = taskLoopDone
            Me.Progress = taskProgress

            'Me.DependencyType = taskDependencyType
            'Me.DependencyLag = taskDependencyLag

            Me.Predecessors = New BindingList(Of Integer)()
            If Not IsNothing(predecessorIds) Then
                For Each predecessor As Integer In predecessorIds
                    Me.Predecessors.Add(predecessor)
                Next predecessor
            End If

            Me.Successors = New BindingList(Of Integer)()
            If Not IsNothing(successorIds) Then
                For Each successor As Integer In successorIds
                    Me.Successors.Add(successor)
                Next successor
            End If
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Public Property Id() As Integer
    Public Property ParentId() As Integer
    Private privatePredecessors As BindingList(Of Integer)
    Private privateSuccessors As BindingList(Of Integer)
    Public Property Predecessors() As BindingList(Of Integer)
        Get
            Return privatePredecessors
        End Get
        Private Set(ByVal value As BindingList(Of Integer))
            privatePredecessors = value
        End Set
    End Property
    Public Property Successors() As BindingList(Of Integer)
        Get
            Return privateSuccessors
        End Get
        Private Set(ByVal value As BindingList(Of Integer))
            privateSuccessors = value
        End Set
    End Property
    Public Property Name() As String
    Public Property Description() As String
    Public Property Area() As String
    Public Property ItemType() As String
    Public Property Loops() As Integer
    Public Property Vendors() As String
    Public Property Sats() As Integer
    Public Property SatDone() As Integer
    Public Property SatLateFinishedDate() As DateTime
    Public Property StartDate() As DateTime
    Public Property FinishDate() As DateTime
    Public Property Duration() As TimeSpan
    Public Property Progress() As Double
    Public Property LoopDone() As Double
    Public Property DependencyType() As DevExpress.XtraGantt.DependencyType
    Public Property DependencyLag() As Double

End Class
