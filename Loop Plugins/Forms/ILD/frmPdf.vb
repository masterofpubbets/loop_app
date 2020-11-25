Imports DevExpress.Pdf

Public Class frmPdf
    Public PDFPath As String = ""

    Private Sub frmPdf_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PDFPath <> "" Then
            p.LoadDocument(PDFPath)
        End If
    End Sub
End Class