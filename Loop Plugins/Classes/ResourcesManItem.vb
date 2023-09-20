Public Class ResourcesManItem
    Inherits ResourcesMan
    Private _itemId As Integer = 0
    Private _groupId As GROUPID

    Public Sub New(ByVal ItemId As Integer, ByVal ItemGroupId As GROUPID)
        _itemId = ItemId
        _groupId = ItemGroupId
    End Sub

    Public Overrides Function GetResources() As DataTable
        Try
            Return (DB.ReturnDataTable("EXEC dbo.GetResourceItem " & _itemId & "," & _groupId))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function ClearResources() As Boolean
        Try
            DB.ExcuteNoneResult("EXEC ENGINEERING.ClearResourceItem " & _itemId & "," & _groupId)
            Return (True)
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Overrides Function DeleteResource(resId As Integer) As Boolean
        Try
            DB.ExcuteNoneResult("EXEC ENGINEERING.DeleteResourceItem " & resId)
            Return (True)
        Catch ex As Exception
            pe.RaiseDataExecuteError(ex.Message)
            Return False
        End Try
        Return False
    End Function

End Class
