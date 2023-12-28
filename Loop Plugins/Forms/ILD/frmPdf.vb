Imports System.ComponentModel
Imports DevExpress.Pdf

Public Class frmPdf
    Public PDFPath As String = ""

    Private Sub frmPdf_Load(sender As Object, e As EventArgs) Handles Me.Load
        If PDFPath <> "" Then
            p.LoadDocument(PDFPath)
        End If
    End Sub

    Private Sub frmPdf_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class