Public Class CutoffDate
    Public Property CurrentCutoffDate As Date
        Get
            Return (DB.ExcutResult("select [tmp_date] from [tblTMP] where [tmp_id]=1"))
        End Get
        Set(value As Date)
            DB.ExcuteNoneResult(
            String.Format("UPDATE tblTMP SET tmp_date = '{0}' WHERE tmp_id=1", Format(value, "MM/dd/yyyy"))
            )
        End Set
    End Property
    Public Property ReportCutoffDate As Date
        Get
            Return (DB.ExcutResult(
                "select 
                CASE WHEN [ReportCutoffDate] IS NULL THEN '1/1/1900'
                ELSE ReportCutoffDate END
                from [tblTMP] where [tmp_id]=1"
                ))
        End Get
        Set(value As Date)
            DB.ExcuteNoneResult(
            String.Format("UPDATE tblTMP SET ReportCutoffDate = '{0}' WHERE tmp_id=1", Format(value, "MM/dd/yyyy"))
            )
        End Set
    End Property
End Class
