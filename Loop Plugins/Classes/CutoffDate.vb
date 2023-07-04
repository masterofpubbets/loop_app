Public Class CutoffDate
    Public Function changeCutoffDate(ByVal value As Date) As Date
        Try
            DB.ExcuteNoneResult(String.Format("UPDATE tblTMP SET tmp_date = '{0}' WHERE id=1", Format(value, "MM/dd/yyyy")))
            Return (DB.ExcutResult("select [tmp_date] from [tblTMP] where [tmp_id]=1"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function CurrentCutoffDate() As Date
        Try
            Return (DB.ExcutResult("select [tmp_date] from [tblTMP] where [tmp_id]=1"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
End Class
