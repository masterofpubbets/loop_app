Imports System.ComponentModel

Public Class frmExtractILD
    Private _Sep As String = "SHEET"
    Private _loopname As String = "Loop Name"
    Dim st As New EAMS.StringFunctions.StringsFunction


    Private Sub ValidateILDTables()
        Dim temp() As String = Split(My.Resources.ValidiateILD, "go", , CompareMethod.Text)
        For inx = 0 To temp.Count - 1
            If temp(inx) <> "" Then
                DB.ExcuteNoneResult(temp(inx))
            End If
        Next
    End Sub
    Private Sub LoadILDItemsFile(ByVal FleName As String, ByVal FilePath As String)
        lblOp.Text = "Proccessing " & st.SubString(FleName, ".txt")
        Application.DoEvents()
        Dim obj As New System.IO.StreamReader(FilePath)
        Do While obj.Peek() <> -1
            DB.ExcuteNoneResult(String.Format("insert into tblILD ([Loop_Name],[Item]) values ('{0}','{1}')", st.SubString(FleName, ".txt"), Replace(obj.ReadLine(), "'", "")))
        Loop
    End Sub

    Private Sub CheckILDItemsFiles()
        Try
            Dim inx As Integer = 1
            lblVal.Visible = True
            lblOp.Visible = True
            lblCount.Visible = True
            lblOp.Text = ""
            lblCount.Text = ""
            lblOp.ForeColor = Color.CadetBlue
            lblCount.ForeColor = Color.CadetBlue
            txtLoopName.Enabled = False
            txtSep.Enabled = False
            Dim di As New IO.DirectoryInfo(lblDD.Text & "\")
            Dim fiArr As IO.FileInfo() = di.GetFiles()
            Dim fri As IO.FileInfo
            Application.DoEvents()
            For Each fri In fiArr
                If DB.ExcutResult(String.Format("select replace(Loop_Name,' ','') as loopname from tblILD where Loop_Name ='{0}'", Replace(st.SubString(fri.Name, ".txt"), " ", "",,, CompareMethod.Binary))) = "" Then
                    LoadILDItemsFile(fri.Name, fri.FullName)
                    'CheckILDItemsFiles()
                End If
                Application.DoEvents()
                lblCount.Text = String.Format("{0} / {1}", inx, fiArr.Length)
                inx += 1
            Next
            lblVal.Visible = False
            lblOp.Visible = False
            lblCount.Visible = False
            txtLoopName.Enabled = True
            txtSep.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            lblVal.Visible = False
            lblOp.Visible = False
            lblCount.Visible = False
            txtLoopName.Enabled = True
            txtSep.Enabled = True
        End Try

    End Sub

    Private Sub txtSep_Validated(sender As Object, e As System.EventArgs) Handles txtSep.Validated
        If Trim(txtSep.Text) = "" Then
            txtSep.Text = _Sep
        End If
    End Sub

    Private Sub txtLoopName_Validated(sender As Object, e As System.EventArgs) Handles txtLoopName.Validated
        If Trim(txtLoopName.Text) = "" Then
            txtLoopName.Text = _loopname
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        opnFle.ShowDialog()
        If opnFle.FileName = "" Then Exit Sub
        lblSPath.Text = opnFle.FileName
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        fld.ShowDialog()
        If fld.SelectedPath = "" Then Exit Sub
        lblDD.Text = fld.SelectedPath
    End Sub

    Private Function GetInsTag(ByVal value As String) As String
        Try
            Dim temp() As String
            Dim temp2() As String
            Dim Tag As String = ""
            temp = Split(st.SubString(value, "TAG: "), "-")
            temp2 = Split(temp(0), " ")
            Tag = temp2(temp2.Length - 1)
            temp2 = Split(temp(1), " ")
            Tag = Tag & "-" & temp2(0)
            temp2 = Split(temp(2), " ")
            Tag = Tag & "-" & temp2(0)
            Return Tag
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Function PreFile(ByVal path As String, ByRef prePath As String) As Boolean
        Dim obj As New System.IO.StreamReader(path)
        Dim w As New System.IO.StringWriter
        Dim t As String = ""
        Dim inx As Integer = 0
        Try
            lblCount.Text = 0
            lblOp.Text = "Prepare the File"
            Do While obj.Peek() <> -1
                t = obj.ReadLine()
                If InStr(t, _loopname) > 0 Then
                    If Len(t) < Len(_loopname) + 6 Then
                        w.WriteLine(t)
                    Else
                        w.WriteLine(_loopname)
                        w.WriteLine(Trim(Replace(Replace(t, _loopname, ""), ":", "")))
                    End If
                Else
                    w.WriteLine(t)
                End If
                inx += 1
                lblCount.Text = inx
                Application.DoEvents()
            Loop
            obj.Close()
            If FileIO.FileSystem.FileExists(prePath) Then
                FileIO.FileSystem.DeleteFile(prePath)
            End If
            IO.File.AppendAllText(prePath, w.ToString, System.Text.Encoding.Unicode)
            Return True
        Catch ex As Exception
            Return False
        End Try

        Return False
    End Function

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            _Sep = txtSep.Text
            _loopname = txtLoopName.Text
            If lblDD.Text = "..." Then
                MsgBox("You must select output directory", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            Dim _new As Boolean = False
            Dim t As String = ""
            Dim w As New System.IO.StringWriter
            Dim inx As Integer = 0
            Dim _ReadLoopWord As Boolean = False
            Dim LoopName As String = ""
            Dim temp() As String
            Dim iny As Integer = 0
            Dim di As New IO.DirectoryInfo(lblDD.Text & "\")
            Dim fiArr As IO.FileInfo() = di.GetFiles()
            Dim fri As IO.FileInfo
            lblCount.Visible = True
            lblOp.Visible = True
            lblOp.Text = "Proccessing ILD"
            lblOp.ForeColor = Color.CadetBlue
            lblCount.ForeColor = Color.CadetBlue
            'Prepare the File
            txtLoopName.Enabled = False
            txtSep.Enabled = False
            Dim msgR As MsgBoxResult = MsgBox(String.Format("All Content of{0}{1}{0}Will be deleted. Do You Want To Proceed?", vbCrLf, lblDD.Text), MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then Exit Sub
            For Each fri In fiArr
                fri.Delete()
            Next
            If Not PreFile(lblSPath.Text, Application.StartupPath & "\tmp\_tmpILD.tmp") Then
                Exit Sub
            End If
            '--------------------------------------------
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\tmp\_tmpILD.tmp")
            lblCount.Text = 0
            lblOp.Text = "Proccessing ILD"
            Do While obj.Peek() <> -1
                t = obj.ReadLine()
                If Not _new Then
                    w = New System.IO.StringWriter
                    _new = True
                End If
                If InStr(t, _Sep, CompareMethod.Text) > 0 Then
                    If LoopName <> "" Then
                        Try
                            IO.File.AppendAllText(lblDD.Text & "\" & LoopName & ".txt", w.ToString, System.Text.Encoding.Unicode)
                        Catch ex As Exception
                            LoopName = ""
                        End Try
                        LoopName = ""
                        _new = False
                    End If
                Else
                    If (Trim(t) <> "") Then
                        If (t <> vbNewLine) Then
                            '-----------------------Parse
                            If Len(t) < 7 Then
                            Else
                                If InStr(t, "-") = 0 Then
                                Else
                                    If InStr(t, "tag:", CompareMethod.Text) = 0 Then
                                        If InStr(t, "IX", CompareMethod.Text) <> 0 Then
                                            w.WriteLine(st.RemoveMiddleSpace(t))
                                        Else
                                            temp = Split(t, " ")
                                            If temp.Length = 1 Then
                                                w.WriteLine(t)
                                            Else
                                                For iny = 0 To temp.Length - 1
                                                    If Trim(st.RemoveMiddleSpace(temp(iny))) <> "" Then
                                                        If Len(temp(iny)) > 7 Then
                                                            w.WriteLine(st.RemoveMiddleSpace(temp(iny)))
                                                        End If
                                                    End If
                                                Next
                                            End If
                                        End If
                                    Else
                                        w.WriteLine(GetInsTag(t))
                                    End If
                                End If
                            End If
                            '-----------------------

                            If _ReadLoopWord Then
                                _ReadLoopWord = False
                                LoopName = t
                            End If
                        End If
                    End If

                    If InStr(t, _loopname) > 0 Then
                        _ReadLoopWord = True
                    End If
                End If
                inx += 1
                lblCount.Text = inx
                Application.DoEvents()
            Loop
            obj.Close()
            IO.File.Delete(Application.StartupPath & "\tmp\_tmpILD.tmp")
            '-------------Processing Loop Files

            Dim di2 As New IO.DirectoryInfo(lblDD.Text & "\")
            Dim fiArr2 As IO.FileInfo() = di2.GetFiles()
            lblCount.Text = "0 / " & fiArr2.Length
            inx = 1
            For Each fri In fiArr
                lblOp.Text = "Proccessing " & st.SubString(fri.Name, ".txt")
                lblCount.Text = String.Format("{0} / {1}", inx, fiArr.Length)
                obj = New System.IO.StreamReader(fri.FullName)
                Do While obj.Peek() <> -1
                    DB.ExcuteNoneResult(String.Format("insert into tblILD ([Loop_Name],[Item]) values ('{0}','{1}')", st.SubString(fri.Name, ".txt"), Replace(obj.ReadLine(), "'", "")))
                Loop
                Application.DoEvents()
                inx += 1
            Next fri
            obj.Close()
            '---------------------------------
            temp = Split(My.Resources.ValidiateILD, "go", , CompareMethod.Text)
            For inx = 0 To temp.Count - 1
                If temp(inx) <> "" Then
                    DB.ExcuteNoneResult(temp(inx))
                End If
                Application.DoEvents()
            Next
            MsgBox("Proccessing ILD has been finished", MsgBoxStyle.Exclamation, Me.Text)
            lblCount.Visible = False
            lblOp.Visible = False
        Catch ex As Exception
            lblCount.Visible = False
            lblOp.Visible = False
            txtLoopName.Enabled = True
            txtSep.Enabled = True
            lblOp.Text = "An Error Occured While Reading ILD"
        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If lblDD.Text = "..." Then
            MsgBox("You must select Items Files directory", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        CheckILDItemsFiles()
        ValidateILDTables()
        MsgBox("Validate Process Has Been Finished", MsgBoxStyle.OkOnly, Me.Text)
    End Sub

    Private Sub frmExtractILD_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub
End Class