Imports System.ComponentModel
Imports DevExpress.Pdf

Public Class frmExtractILD3
    Private ILD As New ExtractILD
    Private isDelete As Boolean = False
    Private loopCounter As Integer = 0


    Private Sub HandleLoopName(ByVal lname As String)
        lblOp.Text = lname
        loopCounter += 1
        lblCount.Text = "Total Read: " & loopCounter
    End Sub
    Private Sub HandleFinished()
        If isDelete Then
            lblOp.Text = "Deleting Has Been Finished"
        Else
            lblOp.Text = "Extracting Has Been Finished"
        End If
        MsgBox("Proccess has been finished.", MsgBoxStyle.Information, Me.Text)
    End Sub

    Private Sub StartExtract(ByVal path As String)
        Dim msg As MsgBoxResult = MsgBox("Do You Want To Start Extracting Selected ILD File", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub

        isDelete = False
        lblOp.ForeColor = Color.SeaGreen
        lblCount.ForeColor = Color.SeaGreen
        ILD.ExtractILDNativeText(path, txtLoopName.Text, txtSheetEnd.Text, txtDesc1.Text, txtDesc2.Text, txtDesc3.Text)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        opnFile.ShowDialog()
        If opnFile.FileName <> "" Then
            lblSPath.Text = opnFile.FileName
            Try
                rtxt.LoadFile(opnFile.FileName, RichTextBoxStreamType.PlainText)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub frmExtractILD3_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler ILD.LoopFinished, AddressOf HandleLoopName
        AddHandler ILD.ExtractingFinished, AddressOf HandleFinished
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        loopCounter = 0
        If Trim(lblSPath.Text) = "" Then
            MsgBox("Please Select A Native Text File!", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Trim(txtLoopName.Text) = "" Then
            MsgBox("Please Type The Loop Tag Identifier" & vbCrLf & "If You Don't Know Contact Administartor.", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        lblOp.Visible = True
        lblCount.Visible = True

        Try
            StartExtract(lblSPath.Text)
        Catch ex As Exception

        End Try
        lblOp.Visible = False
        lblCount.Visible = False

    End Sub

    Private Sub frmExtractILD3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class