Public Class CReport
    Private pe As New PublicErrors
    Public Function CrExportToPDF(
                                ReportSource As String,
                                PDFFullPath As String,
                                DataBaseLocation As String,
                                DataBaseName As String,
                                Optional UserName As String = "",
                                Optional Pass As String = "",
                                Optional Parameter As String = ""
                             ) As Boolean

        Try
            Dim crtableLogoninfo As New CrystalDecisions.Shared.TableLogOnInfo()
            Dim crConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo()
            Dim CrTables As CrystalDecisions.CrystalReports.Engine.Tables
            Dim CrTable As CrystalDecisions.CrystalReports.Engine.Table
            Dim CrExportOptions As New CrystalDecisions.Shared.ExportOptions
            Dim CrDiskFileDestinationOptions As New CrystalDecisions.Shared.DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions()
            Dim crReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            crReportDocument.Load(ReportSource)
            'Get the DB Connection
            CrTables = crReportDocument.Database.Tables
            For Each CrTable In CrTables
                'crtableLogoninfo = CrTable.LogOnInfo
                crConnectionInfo.ServerName = DataBaseLocation
                crConnectionInfo.DatabaseName = DataBaseName
                If Pass <> "" Then
                    crConnectionInfo.IntegratedSecurity = False
                    crConnectionInfo.Password = Pass
                    crConnectionInfo.UserID = UserName
                Else
                    crConnectionInfo.IntegratedSecurity = True
                End If
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
                CrTable.Location.Substring(CrTable.Location.LastIndexOf(".") + 1)
            Next
            crReportDocument.ReportOptions.EnableSaveDataWithReport = False
            '
            CrDiskFileDestinationOptions.DiskFileName = PDFFullPath
            CrExportOptions = crReportDocument.ExportOptions
            With CrExportOptions
                .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
                .ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            If Parameter <> "" Then
                crReportDocument.SetParameterValue(0, Parameter)
            End If
            crReportDocument.Export()
            Return True
        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
            Return False
        End Try
        Return False
    End Function

End Class
