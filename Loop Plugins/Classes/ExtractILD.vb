Imports DevExpress.Pdf

Public Class ExtractILD
    Public Event ItemIndex(ByVal inx As Integer)
    Public Event SheetIndex(ByVal inx As Integer)
    Public Event PDFPageCount(ByVal inx As Integer)
    Public Event FileIndex(ByVal inx As Integer)
    Public Event FileCount(ByVal inx As Integer)
    Public Event LoopFinished(ByVal lname As String)
    Public Event SearchingFinished()
    Public Event ExtractingFinished()
    Public Event UpdateLoopFinished()
    Public Event CopyToEICAFinished()
    Public Event ValidateEICAILDFinished()
    Private st As New EAMS.StringFunctions.StringsFunction
    Public Event Err(ByVal er As String)

    Private Sub CleanILDTable()
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Not Like '%[0-9]%'")
        AccDB.ExcuteNoneResult("Delete From tblild Where item Like '%Controller%'")
        AccDB.ExcuteNoneResult("Delete From tblild Where item Like '%DETECTOR%'")
        AccDB.ExcuteNoneResult("Delete From tblild Where item Like '-%'")
        AccDB.ExcuteNoneResult("Delete From tblild Where item Like 'sum%'")
        AccDB.ExcuteNoneResult("Delete From tblild Where ITEM Like Loop_Name + '-%'")
        AccDB.ExcuteNoneResult("Delete From tblild Where ITEM Like '%[+]%'")
        AccDB.ExcuteNoneResult("update TBLILD set loop_name=replace(loop_name,' ','')")
        AccDB.ExcuteNoneResult("update TBLILD set loop_name=replace(loop_name,'ild','')")
    End Sub
    Public Sub DeleteILDPDF(ByVal PDFPath As String, ByVal StartPage As Integer, ByVal EndPage As Integer, ByVal _loopname As String)
        Using source As New PdfDocumentProcessor()
            source.LoadDocument(PDFPath)
            Dim FN As String = st.GetFileName(PDFPath)
            Using target As New PdfDocumentProcessor()
                RaiseEvent PDFPageCount(EndPage - 1)
                For inx As Integer = StartPage - 1 To EndPage - 1
                    target.CreateEmptyDocument(String.Format("{0}\{1}_{2}.pdf", SharedFolder, FN, inx))
                    target.Document.Pages.Add(source.Document.Pages(inx))
                    IO.File.WriteAllText(String.Format("{0}\{1}_{2}.bin", SharedFolder, FN, inx), target.Text)
                    ExtractPagesAndRemoveFromDB("sheet", _loopname, String.Format("{0}\{1}_{2}.bin", SharedFolder, FN, inx), String.Format("{1}_{2}.bin", SharedFolder, FN, inx))
                    Application.DoEvents()
                    RaiseEvent SheetIndex(inx + 1)
                Next
            End Using
        End Using
        RaiseEvent ExtractingFinished()
    End Sub
    Public Sub ExtractILDPDF(ByVal PDFPath As String, ByVal StartPage As Integer, ByVal EndPage As Integer, ByVal _loopname As String, Optional _2ndLoopHeader As String = "")
        Using source As New PdfDocumentProcessor()
            source.LoadDocument(PDFPath)
            Dim FN As String = st.GetFileName(PDFPath)
            Using target As New PdfDocumentProcessor()
                RaiseEvent PDFPageCount(EndPage - 1)
                For inx As Integer = StartPage - 1 To EndPage - 1
                    target.CreateEmptyDocument(String.Format("{0}\{1}_{2}.pdf", SharedFolder, FN, inx))
                    target.Document.Pages.Add(source.Document.Pages(inx))
                    IO.File.WriteAllText(String.Format("{0}\{1}_{2}.bin", SharedFolder, FN, inx), target.Text)
                    ExtractPages("sheet", _loopname, String.Format("{0}\{1}_{2}.bin", SharedFolder, FN, inx), String.Format("{1}_{2}.bin", SharedFolder, FN, inx), _2ndLoopHeader)
                    Application.DoEvents()
                    RaiseEvent SheetIndex(inx + 1)
                Next
            End Using
        End Using
        CleanILDTable()
        RaiseEvent ExtractingFinished()
    End Sub
    Public Sub AddLoopDescription(Optional ByVal OverwriteAll As Boolean = True)
        Dim dt As New DataTable
        Dim BINPath As String = ""
        Dim sql As String = ""
        If OverwriteAll Then
            sql = "SELECT distinct loop_name,filename from tblild where filename is not null"
        Else
            sql = "SELECT distinct loop_name,filename from tblild where filename is not null and LoopDescription is null"
        End If
        dt = AccDB.ReturnDataTable(sql)
        RaiseEvent PDFPageCount(dt.Rows.Count)
        For inx As Integer = 0 To dt.Rows.Count - 1
            BINPath = String.Format("{0}\{1}.bin", SharedFolder, dt.Rows(inx).Item("filename"))
            ExtractLoopDescription(dt.Rows(inx).Item("loop_name"), BINPath)
            RaiseEvent SheetIndex(inx + 1)
            Application.DoEvents()
        Next
        RaiseEvent SheetIndex(dt.Rows.Count)
        Application.DoEvents()
        RaiseEvent ExtractingFinished()
    End Sub
    Private Function GetInsTag(ByVal value As String) As String
        Try
            Dim temp() As String
            Dim temp2() As String
            Dim Tag As String = ""
            temp = Split(st.SubString(value, "TAG: "), "-")
            temp2 = Split(temp(0), " ")
            Tag = temp2(temp2.Length - 1)
            If UBound(temp) > 0 Then
                temp2 = Split(temp(1), " ")
                Tag = String.Format("{0}-{1}", Tag, temp2(0))
                temp2 = Split(temp(2), " ")
                Tag = Tag & "-" & temp2(0)
            End If
            Return Tag
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function PreFile(ByVal path As String, ByRef prePath As String, ByVal _loopname As String) As Boolean
        Dim obj As New System.IO.StreamReader(path)
        Dim w As New System.IO.StringWriter
        Dim t As String = ""
        Dim inx As Integer = 0
        Try
            If InStr(_loopname, ":", CompareMethod.Text) > 0 Then
                Do While obj.Peek() <> -1
                    t = obj.ReadLine()
                    If InStr(t, _loopname) > 0 Then
                        w.WriteLine(_loopname)
                        w.WriteLine(Trim(Replace(t, _loopname, "")))
                    Else
                        w.WriteLine(t)
                    End If
                    inx += 1
                    RaiseEvent ItemIndex(inx)
                    Application.DoEvents()
                Loop
            Else
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
                    RaiseEvent ItemIndex(inx)
                    Application.DoEvents()
                Loop
            End If

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
    Private Sub ExtractPages(ByVal _Sep As String, ByVal _loopname As String, ByVal FilePath As String, ByVal FileName As String, Optional _2ndLoopHeader As String = "")
        Try
            Dim outputDir As String = Application.StartupPath & "\_LoopBin"
            Const TracholdCharacterToRead = 7
            Dim _new As Boolean = False
            Dim t As String = ""
            Dim w As New System.IO.StringWriter
            Dim inx As Integer = 0
            Dim _ReadLoopWord As Boolean = False
            Dim LoopName As String = ""
            Dim temp() As String
            Dim iny As Integer = 0
            Dim di As New IO.DirectoryInfo(outputDir & "\")
            Dim fiArr As IO.FileInfo() = di.GetFiles()
            Dim f As String = ""
            Dim ExtraInfo As String = ""

            If Not PreFile(FilePath, Application.StartupPath & "\tmp\_tmpILD.tmp", _loopname) Then
                Exit Sub
            End If
            '--------------------------------------------
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\tmp\_tmpILD.tmp")

            Do While obj.Peek() <> -1
                t = obj.ReadLine()
                If Not _new Then
                    w = New System.IO.StringWriter
                    _new = True
                End If

                If _2ndLoopHeader <> "" Then
                    If InStr(t, _2ndLoopHeader, CompareMethod.Text) > 0 Then
                        ExtraInfo = Replace(t, _2ndLoopHeader, "",,, CompareMethod.Text)
                    End If
                End If

                If (Trim(t) <> "") Then
                    If (t <> vbNewLine) Then
                        '-----------------------Parse
                        If Len(t) < TracholdCharacterToRead Then
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
                                                If Len(temp(iny)) > TracholdCharacterToRead Then
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

                inx += 1
                Application.DoEvents()
            Loop
            obj.Close()
            If LoopName <> "" Then
                Try
                    'AccDB.ExcuteNoneResult(String.Format("insert into tblNewLoopAdded (loopname) values ('{0}')", Replace(LoopName, " ", "",,, CompareMethod.Text)))
                    IO.File.AppendAllText(String.Format("{0}\{1}.txt", outputDir, LoopName), w.ToString, System.Text.Encoding.Unicode)
                    'Add to DB
                    obj = New System.IO.StreamReader(String.Format("{0}\{1}.txt", outputDir, LoopName))
                    f = Replace(FileName, ".bin", "", CompareMethod.Text)
                    Do While obj.Peek() <> -1
                        AccDB.ExcuteNoneResult(String.Format("insert into tblILD ([Loop_Name],[Item],FileName,Updated_Date,extrainfo) values ('{0}','{1}','{2}','{3}','{4}')", LoopName, Replace(obj.ReadLine(), "'", ""), f, Now, ExtraInfo))
                    Loop
                    obj.Close()
                    Application.DoEvents()
                    '------
                    RaiseEvent LoopFinished(LoopName)
                    IO.File.Delete(String.Format("{0}\{1}.txt", outputDir, LoopName))
                Catch ex As Exception
                    LoopName = ""
                End Try
                LoopName = ""
                _new = False
            End If

        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Private Sub ExtractPagesAndRemoveFromDB(ByVal _Sep As String, ByVal _loopname As String, ByVal FilePath As String, ByVal FileName As String)
        Try
            Dim outputDir As String = Application.StartupPath & "\_LoopBin"
            Const TracholdCharacterToRead = 7
            Dim _new As Boolean = False
            Dim t As String = ""
            Dim w As New System.IO.StringWriter
            Dim inx As Integer = 0
            Dim _ReadLoopWord As Boolean = False
            Dim LoopName As String = ""
            Dim temp() As String
            Dim iny As Integer = 0
            Dim di As New IO.DirectoryInfo(outputDir & "\")
            Dim fiArr As IO.FileInfo() = di.GetFiles()
            Dim f As String = ""

            If Not PreFile(FilePath, Application.StartupPath & "\tmp\_tmpILD.tmp", _loopname) Then
                Exit Sub
            End If
            '--------------------------------------------
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\tmp\_tmpILD.tmp")

            Do While obj.Peek() <> -1
                t = obj.ReadLine()
                If Not _new Then
                    w = New System.IO.StringWriter
                    _new = True
                End If

                If (Trim(t) <> "") Then
                    If (t <> vbNewLine) Then
                        '-----------------------Parse
                        If Len(t) < TracholdCharacterToRead Then
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
                                                If Len(temp(iny)) > TracholdCharacterToRead Then
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

                inx += 1
                Application.DoEvents()
            Loop
            obj.Close()
            If LoopName <> "" Then
                AccDB.ExcuteNoneResult(String.Format("delete from tblILD where [Loop_Name]='{0}'", Replace(LoopName, " ", "",,, CompareMethod.Text)))
                RaiseEvent LoopFinished(LoopName)
                IO.File.Delete(String.Format("{0}\{1}.txt", outputDir, LoopName))
                Application.DoEvents()
                LoopName = ""
                _new = False
            End If

        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Private Sub ExtractLoopDescription(ByVal _loopname As String, ByVal FilePath As String)
        Try
            Dim _new As Boolean = False
            Dim t As String = ""
            Dim w As New System.IO.StringWriter
            Dim inx As Integer = 0
            Dim _ReadLoopWord As Boolean = False
            Dim LoopDescription As String = ""

            '--------------------------------------------
            Dim obj As New System.IO.StreamReader(FilePath)

            Do While obj.Peek() <> -1
                t = obj.ReadLine()
                If Not _new Then
                    w = New System.IO.StringWriter
                    _new = True
                End If
                If (Trim(t) <> "") Then
                    If (t <> vbNewLine) Then
                        If _ReadLoopWord Then
                            _ReadLoopWord = False
                            If LoopDescription = "" Then
                                LoopDescription = t
                                GoTo cls
                            End If
                        End If
                    End If
                End If

                If InStr(Replace(t, " ", "",,, CompareMethod.Text), _loopname) > 0 Then
                    _ReadLoopWord = True
                End If

                inx += 1
                Application.DoEvents()
            Loop
cls:
            obj.Close()
            If LoopDescription <> "" Then
                AccDB.ExcuteNoneResult(String.Format("update tblild set loopdescription = '{0}' where loop_name='{1}'", Replace(LoopDescription, ",", "/",,, CompareMethod.Text), _loopname))
                RaiseEvent LoopFinished(LoopDescription)
                Application.DoEvents()
                LoopDescription = ""
                _new = False
            End If

        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub CopyILDToEICA()
        Try
            DB.Close()
            DB.Connect()
            Dim DT As New DataTable
            DT = AccDB.ReturnDataTable("SELECT distinct [Loop_Name],[Item],[Segment],LoopDescription FROM [tblILD]")
            Using bcp As New SqlClient.SqlBulkCopy(DB.DBConnection)
                bcp.DestinationTableName = "tblILD"
                bcp.BatchSize = 10000
                bcp.ColumnMappings.Clear()
                bcp.ColumnMappings.Add("Loop_Name", "Loop_Name")
                bcp.ColumnMappings.Add("Item", "Item")
                bcp.ColumnMappings.Add("Segment", "Segment")
                bcp.ColumnMappings.Add("LoopDescription", "Loop_Type")
                bcp.WriteToServer(DT)
            End Using
            RaiseEvent CopyToEICAFinished()
            ValidateEICAILDTables()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub
    Public Sub DeleteEICAILDs()
        DB.ExcuteNoneResult("delete from tblild")
    End Sub

    Public Sub ValidateEICAILDTables()
        Try
            Dim temp() As String = Split(My.Resources.ValidiateILD, "go", , CompareMethod.Text)
            For inx = 0 To temp.Count - 1
                If temp(inx) <> "" Then
                    DB.ExcuteNoneResult(temp(inx))
                End If
            Next
            DB.ExcuteNoneResult(My.Resources.UpdateLoopDescription)
            RaiseEvent ValidateEICAILDFinished()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub UpdateLoopConsFinished()
        Try
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinished.txt")

            Dim obj2 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopQCBackLog.txt")

            Dim obj3 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrNONFinished.txt")
            Dim obj4 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinishedHCS.txt")
            Dim obj6 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinishedTP.txt")
            Dim obj7 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopInsFinalInst.txt")
            Dim obj8 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopMissStep.txt")


            DB.ExcuteNoneResult("exec spLMJC", 0)
            DB.ExcuteNoneResult(obj.ReadToEnd, 0)
            obj.Close()
            DB.ExcuteNoneResult(obj3.ReadToEnd, 0)
            obj3.Close()
            If _LoopConsReleasedQCBacklog = 1 Then
                DB.ExcuteNoneResult(obj2.ReadToEnd, 0)
            End If
            obj2.Close()
            DB.ExcuteNoneResult(obj4.ReadToEnd, 0)
            obj4.Close()
            DB.ExcuteNoneResult(obj7.ReadToEnd, 0)
            obj7.Close()
            DB.ExcuteNoneResult(obj6.ReadToEnd, 0)
            obj6.Close()
            DB.ExcuteNoneResult(obj8.ReadToEnd, 0)
            obj8.Close()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub UpdateLoopConsFinishedWithoutMasterJobard()
        Try
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinished.txt")

            Dim obj2 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopQCBackLog.txt")

            Dim obj3 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrNONFinished.txt")
            Dim obj4 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinishedHCS.txt")
            Dim obj6 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinishedTP.txt")
            Dim obj7 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopInsFinalInst.txt")
            Dim obj8 As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopMissStep.txt")



            DB.ExcuteNoneResult(obj.ReadToEnd, 0)
            obj.Close()
            DB.ExcuteNoneResult(obj3.ReadToEnd, 0)
            obj3.Close()
            If _LoopConsReleasedQCBacklog = 1 Then
                DB.ExcuteNoneResult(obj2.ReadToEnd, 0)
            End If
            obj2.Close()
            DB.ExcuteNoneResult(obj4.ReadToEnd, 0)
            obj4.Close()
            DB.ExcuteNoneResult(obj7.ReadToEnd, 0)
            obj7.Close()
            DB.ExcuteNoneResult(obj6.ReadToEnd, 0)
            obj6.Close()
            DB.ExcuteNoneResult(obj8.ReadToEnd, 0)
            obj8.Close()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub UpdateLoopHCSIndexSigned()
        DB.ExcuteNoneResult("update HCS10031_PLANNING.[dbo].[getProjectTasks('10031')] set HCS10031_PLANNING.[dbo].[getProjectTasks('10031')].[SignedByTR]=null where HCS10031_PLANNING.[dbo].[getProjectTasks('10031')].[SignedByTR]=''")
        DB.ExcuteNoneResult(My.Resources.UpdateIndexDone)
        DB.ExcuteNoneResult(My.Resources.UpdateSubmitForCert)
    End Sub

    Public Function ReturnILDContainsWord(ByVal Keyword As String) As DataTable
        Dim dt As New DataTable
        Dim fs As New EAMS.FilesSystem.FileSearch
        Dim dtrslt As New DataTable("ILDs")

        dtrslt.Columns.Add("Loop Name", Type.GetType("System.String"))
        dtrslt.Columns.Add("File Name", Type.GetType("System.String"))

        dt = AccDB.ReturnDataTable("select distinct Loop_name,FileName from tblILD where filename is not null")
        RaiseEvent FileCount(dt.Rows.Count)
        For inx As Integer = 0 To dt.Rows.Count - 1
            If fs.IsContainsWord(Keyword, String.Format("{0}\{1}.bin", SharedFolder, dt.Rows(inx).Item("filename"))) Then
                dtrslt.Rows.Add(dt.Rows(inx).Item("Loop_name"), dt.Rows(inx).Item("filename"))
            End If
            Application.DoEvents()
            RaiseEvent FileIndex(inx + 1)
        Next
        RaiseEvent SearchingFinished()
        Return dtrslt
    End Function
    Public Function ReturnILD_NO_ContainsWord(ByVal Keyword As String) As DataTable
        Dim dt As New DataTable
        Dim fs As New EAMS.FilesSystem.FileSearch
        Dim dtrslt As New DataTable("ILDs")

        dtrslt.Columns.Add("Loop Name", Type.GetType("System.String"))
        dtrslt.Columns.Add("File Name", Type.GetType("System.String"))

        dt = AccDB.ReturnDataTable("select distinct Loop_name,FileName from tblILD where filename is not null")
        RaiseEvent FileCount(dt.Rows.Count)
        For inx As Integer = 0 To dt.Rows.Count - 1
            If Not fs.IsContainsWord(Keyword, String.Format("{0}\{1}.bin", SharedFolder, dt.Rows(inx).Item("filename"))) Then
                dtrslt.Rows.Add(dt.Rows(inx).Item("Loop_name"), dt.Rows(inx).Item("filename"))
            End If
            Application.DoEvents()
            RaiseEvent FileIndex(inx + 1)
        Next
        RaiseEvent SearchingFinished()
        Return dtrslt
    End Function

    Public Sub RemoveMissingILDStatus()
        Dim dtEICA As New DataTable, dt As New DataTable
        Dim dr() As DataRow
        dtEICA = DB.ReturnDataTable("SELECT [LoopName] FROM [tblInsLoop] WHERE STATUS in ('ON HOLD MISSING ILD','On Hold Logical')")
        dt = AccDB.ReturnDataTable(My.Resources.ILDWithFile)
        RaiseEvent FileCount(dtEICA.Rows.Count)
        For inx As Integer = 0 To dtEICA.Rows.Count - 1
            dr = dt.Select(String.Format("loop_name='{0}'", dtEICA.Rows(inx).Item("loopname")))
            If dr.Length <> 0 Then
                DB.ExcuteNoneResult(String.Format("update tblInsLoop set [STATUS]=null,L_Remarks=null,Constraints=null where loopname='{0}'", dtEICA.Rows(inx).Item("loopname")))
            End If
            RaiseEvent ItemIndex(inx + 1)
            Application.DoEvents()
        Next
        RemoveMissingVendorILDStatus()
        RaiseEvent UpdateLoopFinished()
    End Sub
    Private Sub RemoveMissingVendorILDStatus()
        Dim dtEICA As New DataTable, dt As New DataTable
        Dim dr() As DataRow
        dtEICA = DB.ReturnDataTable("SELECT [LoopName] FROM [tblInsLoop] WHERE STATUS in ('On Hold Vendor/Missing ILD')")
        dt = AccDB.ReturnDataTable(My.Resources.ILDWithFile)
        RaiseEvent FileCount(dtEICA.Rows.Count)
        For inx As Integer = 0 To dtEICA.Rows.Count - 1
            dr = dt.Select(String.Format("loop_name='{0}'", dtEICA.Rows(inx).Item("loopname")))
            If dr.Length <> 0 Then
                DB.ExcuteNoneResult(String.Format("update tblInsLoop set [STATUS]='On Hold Vendor',L_Remarks=null,Constraints=null where loopname='{0}'", dtEICA.Rows(inx).Item("loopname")))
            End If
            RaiseEvent ItemIndex(inx + 1)
            Application.DoEvents()
        Next
    End Sub
End Class
