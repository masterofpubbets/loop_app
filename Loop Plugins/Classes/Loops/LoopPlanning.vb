Imports System.ComponentModel
Imports System.Runtime.Remoting.Metadata.W3cXsd2001
Imports System.Windows
Imports DevExpress.XtraGantt
Imports MS.Internal

Public Class LoopPlanning
    Private Shared pe As New PublicErrors
    Private Shared Activities = New List(Of LoopTask)()
    Public Shared Event DataLoaded()



    Public Shared Function GetLoopCurve() As DataTable
        Dim dt As New DataTable, dtTemp As New DataTable, dtActual As New DataTable, dr As DataRow(), id As Integer = 1
        dtTemp.TableName = "LoopsCurve"
        dtTemp.Columns.Add("Id", System.Type.GetType("System.Int16"))
        dtTemp.Columns.Add("Dates", System.Type.GetType("System.DateTime"))
        dtTemp.Columns.Add("LoopsPerDay", System.Type.GetType("System.Int16"))


        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopSpeed")

            Dim inx As Integer, iny As Integer
            Dim startDate As Date
            Dim endDate As Date
            Dim days As Integer

            For inx = 0 To dt.Rows.Count - 1
                startDate = dt.Rows(inx).Item("Start Date")
                endDate = dt.Rows(inx).Item("Target Date")
                days = dt.Rows(inx).Item("Duration")

                For iny = 0 To days
                    dr = dtTemp.Select("Dates ='" & DateAdd("D", iny, startDate) & "'")
                    If dr.Length > 0 Then
                        dr(0).Item("LoopsPerDay") += Math.Round(dt.Rows(inx).Item("Total Loops") / (days + 1), 0)

                    Else
                        dtTemp.Rows.Add(id, DateAdd("D", iny, startDate), Math.Round(dt.Rows(inx).Item("Total Loops") / (days + 1), 0))
                        id += 1
                    End If

                Next
            Next

            Return dtTemp
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Shared Function GetLoopStatus() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopStatus")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Shared Function GetLoopPlanningSubsystemSummary() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopPlanningSubsystemsSummary")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Shared Function GetLoopPlanningSubsystemSAT() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopPlanningSubsystemSAT")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Shared Function GetLoopPlanningSubsystemNoSAT() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopPlanningSubsystemNoSAT")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Shared Function GetLoopPlanningLoopNoSAT() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopPlanningLoopsNoSAT")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Shared Function GetLoopPlanningEquipmentSAT() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopPlanningEquipmentSAT")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function
    Private Shared Function GetLoopPlanningLoopsSAT() As DataTable
        Dim dt As New DataTable
        Try
            dt = DB.ReturnDataTable("EXEC PRECOMM.LoopPlanningLoopsSAT")
            Return dt
        Catch ex As Exception
            pe.RaiseDataReadError(ex.Message)
        End Try
        Return Nothing
    End Function

    Private Shared Sub AddToList(parentId As Integer, ByRef tasksTemp As List(Of LoopTask), ByRef dt As DataTable, searchBy As String, searchIn As String, orderBy As String)
        Dim drTemp As DataRow()
        drTemp = dt.Select(searchIn & " = '" & searchBy & "'", orderBy)
        For Each row As DataRow In drTemp
            tasksTemp.Add(New LoopTask(row("Name"),
                                           row("Description"),
                                           row("ID"),
                                           parentId,
                                           row("Area"),
                                           row("Loops"),
                                           row("Vendors"),
                                           row("Sats"),
                                           row("Sat Done"),
                                           IIf(IsDBNull(row("Sat Late Finished")), "1/1/1900", row("Sat Late Finished")),
                                           IIf(IsDBNull(row("Actual Start")), "1/1/1900", row("Actual Start")),
                                           IIf(IsDBNull(row("Actual Finished")), "1/1/1900", row("Actual Finished")),
                                           row("Actual Duration"),
                                           row("LoopDone"),
                                           row("Progress"),
                                           row("ItemType"),
                                           row("DependencyType"),
                                           row("DependencyLag"),
                                           {row("SuccessorIds")},
                                           {row("PredecessorIds")}))
        Next
    End Sub
    Private Shared Sub AddLoopToList(parentId As Integer, ByRef tasksTemp As List(Of LoopTask), ByRef dt As DataTable, searchBy As String, searchIn As String, orderBy As String, ByRef loopInx As Integer)
        Dim drTemp As DataRow()
        drTemp = dt.Select(searchIn & " = '" & searchBy & "'", orderBy)
        For Each row As DataRow In drTemp
            tasksTemp.Add(New LoopTask(row("Name"),
                                           row("Description"),
                                           Val("5" & Str(loopInx)),
                                           parentId,
                                           row("Area"),
                                           row("Loops"),
                                           row("Vendors"),
                                           row("Sats"),
                                           row("Sat Done"),
                                           IIf(IsDBNull(row("Sat Late Finished")), "1/1/1900", row("Sat Late Finished")),
                                           IIf(IsDBNull(row("Actual Start")), "1/1/1900", row("Actual Start")),
                                           IIf(IsDBNull(row("Actual Finished")), "1/1/1900", row("Actual Finished")),
                                           row("Actual Duration"),
                                           row("LoopDone"),
                                           row("Progress"),
                                           row("ItemType"),
                                           row("DependencyType"),
                                           row("DependencyLag"),
                                           {row("SuccessorIds")},
                                           {row("PredecessorIds")}))
            loopInx += 1
        Next
    End Sub
    Private Shared Sub AddToListEquipmentSAT(parentId As Integer,
                                             ByRef tasksTemp As List(Of LoopTask),
                                             ByRef dt As DataTable, searchBy As String,
                                             searchIn As String, orderBy As String,
                                             ByRef dtLoops As DataTable,
                                             ByRef loopinx As Integer
                                            )
        Dim drTemp As DataRow()
        drTemp = dt.Select(searchIn & " = '" & searchBy & "'", orderBy)
        For Each row As DataRow In drTemp
            tasksTemp.Add(New LoopTask(row("Name"),
                                           row("Description"),
                                           row("ID"),
                                           parentId,
                                           row("Area"),
                                           row("Loops"),
                                           row("Vendors"),
                                           row("Sats"),
                                           row("Sat Done"),
                                           IIf(IsDBNull(row("Sat Late Finished")), "1/1/1900", row("Sat Late Finished")),
                                           IIf(IsDBNull(row("Actual Start")), "1/1/1900", row("Actual Start")),
                                           IIf(IsDBNull(row("Actual Finished")), "1/1/1900", row("Actual Finished")),
                                           row("Actual Duration"),
                                           row("LoopDone"),
                                           row("Progress"),
                                           row("ItemType"),
                                           row("DependencyType"),
                                           row("DependencyLag"),
                                           {row("SuccessorIds")},
                                           {row("PredecessorIds")}))

            AddLoopToList(row("ID"), tasksTemp, dtLoops, row("Name"), "Equipment", "[Actual Start]", loopinx)
        Next
    End Sub
    Public Shared Function LoadData() As IList(Of LoopTask)
        Try
            Dim tasksTemp As New List(Of LoopTask)
            tasksTemp = New List(Of LoopTask)()
            Dim dtSubsystemSummary As New DataTable, dtSubsystemSAT As New DataTable, dtSubsystemNoSAT As New DataTable
            Dim dtLoopsNoSat As New DataTable, dtEquipmentSat As New DataTable, dtLoopsSAT As New DataTable
            Dim loopInx As Integer = 1

            dtSubsystemSummary = GetLoopPlanningSubsystemSummary()
            dtSubsystemSAT = GetLoopPlanningSubsystemSAT()
            dtSubsystemNoSAT = GetLoopPlanningSubsystemNoSAT()
            dtLoopsNoSat = GetLoopPlanningLoopNoSAT()
            dtEquipmentSat = GetLoopPlanningEquipmentSAT()
            dtLoopsSAT = GetLoopPlanningLoopsSAT()

            'Add Subsystem Summaries
            For inx As Integer = 0 To dtSubsystemSummary.Rows.Count - 1
                tasksTemp.Add(New LoopTask(dtSubsystemSummary.Rows(inx).Item("Name"),
                                           IIf(IsDBNull(dtSubsystemSummary.Rows(inx).Item("Description")), "-", dtSubsystemSummary.Rows(inx).Item("Description")),
                                           dtSubsystemSummary.Rows(inx).Item("ID"),
                                           dtSubsystemSummary.Rows(inx).Item("ParentId"),
                                           dtSubsystemSummary.Rows(inx).Item("Area"),
                                           dtSubsystemSummary.Rows(inx).Item("Loops"),
                                           dtSubsystemSummary.Rows(inx).Item("Vendors"),
                                           dtSubsystemSummary.Rows(inx).Item("Sats"),
                                           dtSubsystemSummary.Rows(inx).Item("Sat Done"),
                                           IIf(IsDBNull(dtSubsystemSummary.Rows(inx).Item("Sat Late Finished")), "1/1/1900", dtSubsystemSummary.Rows(inx).Item("Sat Late Finished")),
                                           IIf(IsDBNull(dtSubsystemSummary.Rows(inx).Item("Actual Start")), "1/1/1900", dtSubsystemSummary.Rows(inx).Item("Actual Start")),
                                           IIf(IsDBNull(dtSubsystemSummary.Rows(inx).Item("Actual Finished")), "1/1/1900", dtSubsystemSummary.Rows(inx).Item("Actual Finished")),
                                           dtSubsystemSummary.Rows(inx).Item("Actual Duration"),
                                           dtSubsystemSummary.Rows(inx).Item("LoopDone"),
                                           dtSubsystemSummary.Rows(inx).Item("Progress"),
                                           dtSubsystemSummary.Rows(inx).Item("ItemType"),
                                           dtSubsystemSummary.Rows(inx).Item("DependencyType"),
                                           dtSubsystemSummary.Rows(inx).Item("DependencyLag"),
                                           {dtSubsystemSummary.Rows(inx).Item("SuccessorIds")},
                                           {dtSubsystemSummary.Rows(inx).Item("PredecessorIds")}))
            Next

            'END Subsystem Summaries

            'Add Subsystem SAT
            For inx As Integer = 0 To dtSubsystemSAT.Rows.Count - 1
                tasksTemp.Add(New LoopTask(dtSubsystemSAT.Rows(inx).Item("Name"),
                                           IIf(IsDBNull(dtSubsystemSAT.Rows(inx).Item("Description")), "-", dtSubsystemSAT.Rows(inx).Item("Description")),
                                           dtSubsystemSAT.Rows(inx).Item("ID"),
                                           dtSubsystemSAT.Rows(inx).Item("ParentId"),
                                           dtSubsystemSAT.Rows(inx).Item("Area"),
                                           dtSubsystemSAT.Rows(inx).Item("Loops"),
                                           dtSubsystemSAT.Rows(inx).Item("Vendors"),
                                           dtSubsystemSAT.Rows(inx).Item("Sats"),
                                           dtSubsystemSAT.Rows(inx).Item("Sat Done"),
                                           IIf(IsDBNull(dtSubsystemSAT.Rows(inx).Item("Sat Late Finished")), "1/1/1900", dtSubsystemSAT.Rows(inx).Item("Sat Late Finished")),
                                           IIf(IsDBNull(dtSubsystemSAT.Rows(inx).Item("Actual Start")), "1/1/1900", dtSubsystemSAT.Rows(inx).Item("Actual Start")),
                                           IIf(IsDBNull(dtSubsystemSAT.Rows(inx).Item("Actual Finished")), "1/1/1900", dtSubsystemSAT.Rows(inx).Item("Actual Finished")),
                                           dtSubsystemSAT.Rows(inx).Item("Actual Duration"),
                                           dtSubsystemSAT.Rows(inx).Item("LoopDone"),
                                           dtSubsystemSAT.Rows(inx).Item("Progress"),
                                           dtSubsystemSAT.Rows(inx).Item("ItemType"),
                                           dtSubsystemSAT.Rows(inx).Item("DependencyType"),
                                           dtSubsystemSAT.Rows(inx).Item("DependencyLag"),
                                           {dtSubsystemSAT.Rows(inx).Item("SuccessorIds")},
                                           {dtSubsystemSAT.Rows(inx).Item("PredecessorIds")}))


                'Get Equipment SAT With its Loops
                AddToListEquipmentSAT(dtSubsystemSAT.Rows(inx).Item("ID"),
                                      tasksTemp,
                                      dtEquipmentSat,
                                      dtSubsystemSAT.Rows(inx).Item("Name"),
                                      "Subsystem",
                                      "[Actual Start]",
                                       dtLoopsSAT,
                                       loopInx
                                        )
                'END Get Equipment SAT
            Next

            'END Subsystem SAT

            'Add Subsystem No SAT
            For inx As Integer = 0 To dtSubsystemNoSAT.Rows.Count - 1
                tasksTemp.Add(New LoopTask(dtSubsystemNoSAT.Rows(inx).Item("Name"),
                                           IIf(IsDBNull(dtSubsystemNoSAT.Rows(inx).Item("Description")), "-", dtSubsystemNoSAT.Rows(inx).Item("Description")),
                                           dtSubsystemNoSAT.Rows(inx).Item("ID"),
                                           dtSubsystemNoSAT.Rows(inx).Item("ParentId"),
                                           dtSubsystemNoSAT.Rows(inx).Item("Area"),
                                           dtSubsystemNoSAT.Rows(inx).Item("Loops"),
                                           dtSubsystemNoSAT.Rows(inx).Item("Vendors"),
                                           dtSubsystemNoSAT.Rows(inx).Item("Sats"),
                                           dtSubsystemNoSAT.Rows(inx).Item("Sat Done"),
                                           IIf(IsDBNull(dtSubsystemNoSAT.Rows(inx).Item("Sat Late Finished")), "1/1/1900", dtSubsystemNoSAT.Rows(inx).Item("Sat Late Finished")),
                                           IIf(IsDBNull(dtSubsystemNoSAT.Rows(inx).Item("Actual Start")), "1/1/1900", dtSubsystemNoSAT.Rows(inx).Item("Actual Start")),
                                           IIf(IsDBNull(dtSubsystemNoSAT.Rows(inx).Item("Actual Finished")), "1/1/1900", dtSubsystemNoSAT.Rows(inx).Item("Actual Finished")),
                                           dtSubsystemNoSAT.Rows(inx).Item("Actual Duration"),
                                           dtSubsystemNoSAT.Rows(inx).Item("LoopDone"),
                                           dtSubsystemNoSAT.Rows(inx).Item("Progress"),
                                           dtSubsystemNoSAT.Rows(inx).Item("ItemType"),
                                           dtSubsystemNoSAT.Rows(inx).Item("DependencyType"),
                                           dtSubsystemNoSAT.Rows(inx).Item("DependencyLag"),
                                           {dtSubsystemNoSAT.Rows(inx).Item("SuccessorIds")},
                                           {dtSubsystemNoSAT.Rows(inx).Item("PredecessorIds")}))

                'Get Loops Inside
                AddToList(dtSubsystemNoSAT.Rows(inx).Item("ID"), tasksTemp, dtLoopsNoSat, dtSubsystemNoSAT.Rows(inx).Item("Name"), "Subsystem", "[Actual Start]")
            Next

            'END Subsystem No SAT


            Return tasksTemp

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Sub IniateGant(ByRef gntControl As DevExpress.XtraGantt.GanttControl)
        gntControl.TreeListMappings.KeyFieldName = "Id"
        gntControl.TreeListMappings.ParentFieldName = "ParentId"
        gntControl.ChartMappings.TextFieldName = "Name"

        gntControl.ChartMappings.StartDateFieldName = "StartDate"
        gntControl.ChartMappings.FinishDateFieldName = "FinishDate"
        gntControl.ChartMappings.DurationFieldName = "Duration"

        gntControl.ChartMappings.PredecessorsFieldName = "Predecessors"
        gntControl.ChartMappings.ProgressFieldName = "Progress"

        gntControl.DependencyMappings.SuccessorFieldName = "Successors"
        gntControl.DependencyMappings.PredecessorFieldName = "Predecessors"
        gntControl.DependencyMappings.TypeFieldName = "DependencyType"
        gntControl.DependencyMappings.LagFieldName = "DependencyLag"

        Activities = LoadData()
        gntControl.DataSource = Activities
        gntControl.RefreshDataSource()
        If gntControl.Columns.Count > 0 Then
            gntControl.Columns("DependencyLag").Visible = False
            gntControl.Columns("DependencyType").Visible = False
            gntControl.Columns("Predecessors").Visible = False
        End If
        RaiseEvent DataLoaded()
    End Sub
    Public Sub Refresh(ByRef gntControl As DevExpress.XtraGantt.GanttControl)
        'gntControl.DataSource = Nothing
        gntControl.DataSource = Activities
        gntControl.RefreshDataSource()
        RaiseEvent DataLoaded()
    End Sub
    Public Overloads Function GetSelectedTasks(ByRef gntControl As DevExpress.XtraGantt.GanttControl) As IList(Of LoopTask)
        Try
            Dim selectedTasks = New List(Of LoopTask)()
            For Each nd In gntControl.Selection

                selectedTasks.Add(New LoopTask(nd.Item("Name"), nd.Item("Description"), nd.Item("Id"), nd.Item("ParentId"), nd.Item("Area"), nd.Item("Loops"), nd.Item("Vendors"), nd.Item("Sats"), nd.Item("SatDone"), nd.Item("SatLateFinishedDate"), nd.Item("StartDate"), nd.Item("FinishDate"), DateDiff(DateInterval.Day, nd.Item("StartDate"), nd.Item("FinishDate")), nd.Item("LoopDone"), nd.Item("Progress"), nd.Item("ItemType"), nd.Item("DependencyType"), nd.Item("DependencyLag"),
                                       Nothing,
                                       Nothing))
            Next
            Return selectedTasks
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Overloads Function GetSelectedTasks(ByRef gntControl As DevExpress.XtraGantt.GanttControl, itemType As String) As IList(Of String)
        Try
            Dim selectedTasks = New List(Of String)()
            For Each nd In gntControl.Selection

                If nd.Item("ItemType") = itemType Then
                    selectedTasks.Add(nd.Item("Name"))
                End If
            Next
            Return selectedTasks
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function GetPredecessors(ByRef gntControl As DevExpress.XtraGantt.GanttControl, ByVal taskId As Integer) As DataTable
        Try
            Dim predecessorNodes As IEnumerable(Of GanttControlNode) = gntControl.GetPredecessorNodes(TryCast(gntControl.FindNodeByFieldValue("Id", taskId), GanttControlNode))
            Dim dt As New DataTable
            dt.Columns.Add("Id")
            dt.Columns.Add("Item Type")
            dt.Columns.Add("Name")
            dt.Columns.Add("Description")
            dt.Columns.Add("Start Date")
            dt.Columns.Add("Finish Date")
            dt.Columns.Add("Progress")

            dt.TableName = "Predecessors"
            If Not IsNothing(predecessorNodes) Then
                For Each nd In predecessorNodes
                    dt.Rows.Add(nd.Item("Id"), nd.Item("ItemType"), nd.Item("Name"), nd.Item("Description"), nd.Item("StartDate"), nd.Item("FinishDate"), nd.Item("Progress"))
                Next
                Return dt
            End If
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function
    Public Function GetSuccessors(ByRef gntControl As DevExpress.XtraGantt.GanttControl, ByVal taskId As Integer) As DataTable
        Try
            Dim predecessorNodes As IEnumerable(Of GanttControlNode) = gntControl.GetSuccessorNodes(TryCast(gntControl.FindNodeByFieldValue("Id", taskId), GanttControlNode))
            Dim dt As New DataTable
            dt.Columns.Add("Id")
            dt.Columns.Add("Item Type")
            dt.Columns.Add("Name")
            dt.Columns.Add("Description")
            dt.Columns.Add("Start Date")
            dt.Columns.Add("Finish Date")
            dt.Columns.Add("Progress")

            dt.TableName = "Successors"
            If Not IsNothing(predecessorNodes) Then
                For Each nd In predecessorNodes
                    dt.Rows.Add(nd.Item("Id"), nd.Item("ItemType"), nd.Item("Name"), nd.Item("Description"), nd.Item("StartDate"), nd.Item("FinishDate"), nd.Item("Progress"))
                Next
                Return dt
            End If
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
        Return Nothing
    End Function

End Class
