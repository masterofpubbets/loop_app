Imports DevExpress.Pdf
Imports DevExpress.XtraSpreadsheet.Model.NumberFormatting

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
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Like '[0-9]/[0-9]/[0-9]'")
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Like '[0-9][0-9]/[0-9][0-9]/[0-9][0-9]'")
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Like '[0-9][0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]'")
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Like '[0-9]/[0-9][0-9]/[0-9][0-9][0-9][0-9]'")
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Like '[0-9][0-9]/[0-9]/[0-9][0-9][0-9][0-9]'")
        AccDB.ExcuteNoneResult("Delete From tblILD Where item Like '[0-9]/[0-9]/[0-9][0-9][0-9]'")
        AccDB.ExcuteNoneResult("Delete From tblild Where LEN(item) < 6")
        AccDB.ExcuteNoneResult("Delete From tblild Where item LIKE '%.%'")
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
    Public Sub ExtractILDNativeText(ByVal filePath As String, loopIdent As String, ByVal sheetEnd As String, disIdent1 As String, disIdent2 As String, disIdent3 As String)
        ExtractTextFile(filePath, loopIdent, sheetEnd, disIdent1, disIdent2, disIdent3)
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
    Private Sub ExtractPages(ByVal _Sep As String, ByVal _loopname As String, ByVal FilePath As String, ByVal FileName As String, Optional _2ndLoopHeader As String = "", Optional overwrite As Boolean = False)
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
            Dim ExtraInfoFag As Boolean = False

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
                        ExtraInfoFag = True

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

                                    'get the Extra Info
                                    If (ExtraInfoFag AndAlso (InStr(t, _2ndLoopHeader, CompareMethod.Text) = 0)) Then
                                        ExtraInfo = t
                                        ExtraInfoFag = False
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


                                    '----------------

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
    Private Overloads Sub ExtractTextFile(ByVal FilePath As String, loopIdent As String, ByVal sheetEnd As String, disIdent1 As String, disIdent2 As String, disIdent3 As String)
        Try
            Const TracholdCharacterToRead = 4
            Dim LoopName As String = ""
            Dim hasLoopName As Boolean = False, hasDes1 As Boolean = False, hasDes2 As Boolean = False, hasDes3 As Boolean = False
            Dim donotAdd As Boolean = False

            Dim tmp As String = ""
            Dim desc1 As String = "", desc2 As String = "", desc3 As String = ""

            Dim itemsCol As New Collection
            Dim fileName As String = ""
            Dim t() As String = Split(FilePath, "\",, CompareMethod.Text)
            t = Split(t(UBound(t)), ".",, CompareMethod.Text)
            fileName = t(0)

            Dim obj As New System.IO.StreamReader(FilePath)
            Do While obj.Peek() <> -1
                tmp = obj.ReadLine()

                If Len(tmp) > TracholdCharacterToRead Then

                    If InStr(tmp, sheetEnd, CompareMethod.Text) > 0 Then
                        'save to local db
                        SavetoLocal(LoopName, itemsCol, desc1, desc2, desc3, fileName)
                        RaiseEvent LoopFinished(LoopName)
                        'clean
                        desc1 = ""
                        desc2 = ""
                        desc3 = ""
                        LoopName = ""
                        itemsCol = New Collection
                        donotAdd = False
                        Application.DoEvents()
                        GoTo nl
                        '------
                    End If

                    If hasLoopName Then
                        If Trim(tmp) <> "" Then
                            hasLoopName = False
                            LoopName = FixLoopName(tmp)
                        Else
                            GoTo nl
                        End If
                    End If

                    If hasDes1 Then
                        hasDes1 = False
                        desc1 = tmp
                        donotAdd = False
                    End If

                    If hasDes2 Then
                        hasDes2 = False
                        desc2 = tmp
                        donotAdd = False
                    End If

                    If hasDes3 Then
                        hasDes3 = False
                        desc3 = tmp
                        donotAdd = False
                    End If

                    If InStr(tmp, loopIdent, CompareMethod.Text) > 0 Then
                        If Not CheckLoopName(loopIdent, tmp, LoopName) Then
                            hasLoopName = True
                            donotAdd = True
                        Else
                            GoTo nl
                        End If
                    End If

                    If (disIdent1 <> "") AndAlso InStr(tmp, disIdent1, CompareMethod.Text) > 0 Then
                        If Not CheckDescription(disIdent1, tmp, desc1) Then
                            hasDes1 = True
                            donotAdd = True
                        Else
                            GoTo nl
                        End If
                    End If

                    If (disIdent2 <> "") AndAlso InStr(tmp, disIdent2, CompareMethod.Text) > 0 Then
                        If Not CheckDescription(disIdent2, tmp, desc2) Then
                            hasDes2 = True
                            donotAdd = True
                        Else
                            GoTo nl
                        End If
                    End If

                    If (disIdent3 <> "") AndAlso InStr(tmp, disIdent3, CompareMethod.Text) > 0 Then
                        If Not CheckDescription(disIdent3, tmp, desc3) Then
                            hasDes3 = True
                            donotAdd = True
                        Else
                            GoTo nl
                        End If
                    End If

                    If Not donotAdd Then
                        If InStr(tmp, "tag", CompareMethod.Text) > 0 Then
                            AddInstrumentTag(tmp, itemsCol)
                        Else
                            AddItemTag(tmp, itemsCol)
                        End If
                    End If

                End If

nl:

            Loop
            obj.Close()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Private Function CheckDescription(ByRef descIdentity As String, ByRef line As String, ByRef desc As String) As Boolean
        Dim tmp() As String = Split(line, descIdentity,, CompareMethod.Text)
        If UBound(tmp) > 0 Then
            If Len(Trim(tmp(1))) > 0 Then
                desc = tmp(1)
                Return True
            End If
        End If
        Return False
    End Function
    Private Function CheckLoopName(ByRef loopIdentity As String, ByRef line As String, ByRef loopName As String) As Boolean
        Dim tmp() As String = Split(line, loopIdentity,, CompareMethod.Text)
        If UBound(tmp) > 0 Then
            If Len(Trim(tmp(1))) > 4 Then
                loopName = tmp(1)
                Return True
            End If
        End If
        Return False
    End Function
    Private Function FixLoopName(ByVal loopName As String) As String
        Try
            Dim tmp() As String = Split(Trim(loopName), " ",, CompareMethod.Text)
            Return tmp(0)
        Catch ex As Exception

        End Try
        Return ""
    End Function
    Private Function AddItemTag(ByVal item As String, ByRef col As Collection) As Boolean
        Try
            If item = "" Then Return ""
            Dim tmp() As String
            tmp = Split(item, " ",, CompareMethod.Text)
            For inx As Integer = 0 To UBound(tmp)
                If Not ItemExistsCol(col, tmp(inx)) Then col.Add(tmp(inx))
            Next
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
    Private Function AddInstrumentTag(ByVal item As String, ByRef col As Collection) As Boolean
        Try
            item = Replace(Replace(item, "tag", "",,, CompareMethod.Text), ":", "",,, CompareMethod.Text)
            item = RTrim(LTrim(item))
            Dim tmp() As String
            tmp = Split(item, " ",, CompareMethod.Text)
            item = tmp(0) & tmp(1)
            For inx As Integer = 0 To UBound(tmp)
                If Not ItemExistsCol(col, item) Then col.Add(item)
            Next
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function

    Private Function ItemExistsCol(ByRef col As Collection, ByRef item As String) As Boolean
        If IsNothing(col) Then Return False
        For inx As Integer = 1 To col.Count
            If item = col.Item(inx) Then Return True
        Next
        Return False
    End Function
    Private Function SavetoLocal(ByVal loopName As String, ByRef itemsCol As Collection, ByVal desc1 As String, ByVal desc2 As String, ByVal desc3 As String, ByVal FileName As String) As Boolean
        Try
            For inx As Integer = 1 To itemsCol.Count
                AccDB.ExcuteNoneResult(String.Format("insert into tblILD ([Loop_Name],[Item],LoopDescription,LoopDescription2,LoopDescription3,FileName,Updated_Date) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", loopName, itemsCol.Item(inx), desc1, desc2, desc3, FileName, Now))
            Next

        Catch ex As Exception

        End Try
        Return False
    End Function
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
            DT = AccDB.ReturnDataTable("SELECT distinct [Loop_Name],[Item],[Segment],LoopDescription,LoopDescription2,LoopDescription3 FROM [tblILD]")
            Using bcp As New SqlClient.SqlBulkCopy(DB.DBConnection)
                bcp.DestinationTableName = "tblILD"
                bcp.BatchSize = 10000
                bcp.ColumnMappings.Clear()
                bcp.ColumnMappings.Add("Loop_Name", "Loop_Name")
                bcp.ColumnMappings.Add("Item", "Item")
                bcp.ColumnMappings.Add("Segment", "Segment")
                bcp.ColumnMappings.Add("LoopDescription", "Description1")
                bcp.ColumnMappings.Add("LoopDescription2", "Description2")
                bcp.ColumnMappings.Add("LoopDescription3", "Description3")
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
