Imports DevExpress.Pdf
Imports DevExpress.XtraPdfViewer

Public Class frmExtractILD2
    Private ILD As New ExtractILD
    Private CurPage As Integer = 0
    Private PdfsCount As Integer = 0
    Private isDelete As Boolean = False

    Private Sub StartExtract()
        Dim msg As MsgBoxResult = MsgBox("Do You Want To Start Extracting Selected ILD File", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub
        If p.DocumentFilePath = "" Then
            MsgBox("Please Select An ILD Pdf File First", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Trim(txtLoopName.Text) = "" Then
            MsgBox("Please Type The Loop Tag Identifier" & vbCrLf & "If You Don't Know Contact Administartor", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        isDelete = False
        lblOp.ForeColor = Color.SeaGreen
        lblCount.ForeColor = Color.SeaGreen
        ILD.ExtractILDPDF(p.DocumentFilePath, Val(txtReadFrom.Text), Val(txtReadTo.Text), txtLoopName.Text, txt2Header.Text)
    End Sub
    Private Sub StartDelete()
        Dim msg As MsgBoxResult = MsgBox("Do You Want To Delete Selected ILD File", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub
        If p.DocumentFilePath = "" Then
            MsgBox("Please Select An ILD Pdf File First", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Trim(txtLoopName.Text) = "" Then
            MsgBox("Please Type The Loop Tag Identifier" & vbCrLf & "If You Don't Know Contact Administartor", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        isDelete = True
        lblOp.ForeColor = Color.SaddleBrown
        lblCount.ForeColor = Color.SaddleBrown
        ILD.DeleteILDPDF(p.DocumentFilePath, Val(txtReadFrom.Text), Val(txtReadTo.Text), txtLoopName.Text)
    End Sub
    Private Sub StartReplace()
        Dim msg As MsgBoxResult = MsgBox("Do You Want To Replace Existing ILDs with Selected one", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub
        If p.DocumentFilePath = "" Then
            MsgBox("Please Select An ILD Pdf File First", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        If Trim(txtLoopName.Text) = "" Then
            MsgBox("Please Type The Loop Tag Identifier" & vbCrLf & "If You Don't Know Contact Administartor", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        isDelete = True
        lblOp.ForeColor = Color.SaddleBrown
        lblCount.ForeColor = Color.SaddleBrown
        ILD.DeleteILDPDF(p.DocumentFilePath, Val(txtReadFrom.Text), Val(txtReadTo.Text), txtLoopName.Text)

        isDelete = False
        lblOp.ForeColor = Color.SeaGreen
        lblCount.ForeColor = Color.SeaGreen
        ILD.ExtractILDPDF(p.DocumentFilePath, Val(txtReadFrom.Text), Val(txtReadTo.Text), txtLoopName.Text, txt2Header.Text)
    End Sub
    Private Sub HandlePDFCount(ByVal cnt As Integer)
        PdfsCount = cnt + 1
        lblCount.Visible = True
        lblOp.Visible = True
    End Sub
    Private Sub HandleReadPages(ByVal inx As Integer)
        If isDelete Then
            lblCount.Text = String.Format("Delete {0} / {1}", inx, PdfsCount)
        Else
            lblCount.Text = String.Format("Reading {0} / {1}", inx, PdfsCount)
        End If
    End Sub
    Private Sub HandleLoopName(ByVal lname As String)
        lblOp.Text = lname
    End Sub
    Private Sub HandleFinished()
        If isDelete Then
            lblOp.Text = "Deleting Has Been Finished"
        Else
            lblOp.Text = "Extracting Has Been Finished"
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then Exit Sub
        lblSPath.Text = opnFle.FileName
        p.LoadDocument(opnFle.FileName)
        lblTotal.Text = "Total Pages: " & p.PageCount
        txtReadTo.Text = p.PageCount
        RepositoryItemComboBox1.Items.Clear()
        For inx As Integer = 1 To p.PageCount
            RepositoryItemComboBox1.Items.Add(inx)
        Next
    End Sub

    Private Sub p_CurrentPageChanged(sender As Object, e As PdfCurrentPageChangedEventArgs) Handles p.CurrentPageChanged
        lblCPage.Text = "Current Page: " & e.PageNumber.ToString
        CurPage = e.PageNumber
    End Sub

    Private Sub txtReadFrom_Validated(sender As Object, e As EventArgs) Handles txtReadFrom.Validated
        If Trim(txtReadFrom.Text) = "" Then
            txtReadFrom.Text = "1"
            Exit Sub
        End If
        If Not IsNumeric(txtReadFrom.Text) Then
            txtReadFrom.Text = "1"
            Exit Sub
        End If
        If Val(txtReadFrom.Text) > p.PageCount Then
            txtReadFrom.Text = "1"
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Try
            If CurPage = 0 Then Exit Sub
            sveFle.FileName = ""
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            Using source As New PdfDocumentProcessor()
                source.LoadDocument(p.DocumentFilePath)
                Using target As New PdfDocumentProcessor()
                    target.CreateEmptyDocument(sveFle.FileName & ".pdf")
                    target.Document.Pages.Add(source.Document.Pages(CurPage - 1))
                    IO.File.WriteAllText(sveFle.FileName & ".txt", target.Text)
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmExtractILD2_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler ILD.PDFPageCount, AddressOf HandlePDFCount
        AddHandler ILD.SheetIndex, AddressOf HandleReadPages
        AddHandler ILD.LoopFinished, AddressOf HandleLoopName
        AddHandler ILD.ExtractingFinished, AddressOf HandleFinished
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        StartExtract()
    End Sub

    Private Sub txtReadTo_Validated(sender As Object, e As EventArgs) Handles txtReadTo.Validated
        If Trim(txtReadTo.Text) = "" Then
            txtReadTo.Text = p.PageCount
            Exit Sub
        End If
        If Not IsNumeric(txtReadTo.Text) Then
            txtReadTo.Text = p.PageCount
            Exit Sub
        End If
        If Val(txtReadTo.Text) > p.PageCount Then
            txtReadTo.Text = p.PageCount
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        StartDelete()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim msg As MsgBoxResult = MsgBox("Do You Want To Update All Loops Description" & vbCrLf & "Old Description Will Be Overwritten", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub
        ILD.AddLoopDescription()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim msg As MsgBoxResult = MsgBox("Do You Want To Update Only Loops Without Description", MsgBoxStyle.YesNo, Me.Text)
        If msg = MsgBoxResult.No Then Exit Sub
        ILD.AddLoopDescription(False)
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        StartReplace()
    End Sub
End Class