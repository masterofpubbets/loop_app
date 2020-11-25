Public Class Engineering
    Public Event Err(ByVal errmsg As String)
    Public Event ProgressDataCount(ByVal cnt As Integer)
    Public Event UploadFinish()
    Public Event CheckFinish()
    Public Event MaterialsUpdated()
    Public Event InstrumentsWithTPUpdated()
    Public Event InstrumentsWithEQUpdated()
    Public Event UpdateProgressComplete()
    Public Event ProgressIndex(ByVal cnt As Integer)
    Public Event LoopProgressIndex(ByVal cnt As Integer)
    Public Event LoopCount(ByVal cnt As Integer)
    Public Event GenerateLoopStatusReportDone()
    Public Event Fixed(ByVal item As e_DataType)
    Public Event LoopsUpdated()
    Public Event UpdateMileStoneProgress(inx As Integer)
    Public Event UpdateMileStoneCount(inx As Integer)
    Public Event ForeCastUpdated()
    Public Event SlaveInstrumentUpdated()
    Public Event InsKitLinked()
    Public Event OverrideMaterialsUpdated()
    Public Event LoopConsFinished()
    Public Event P6Updated()
    Public Event DGNDownloaded()
    Public Event DGNPrinted()
    Public Event ReportsExported()
    Public Event InstrumentsUpdated()







    Public Enum e_DataType
        ElectricalCables = 1
        JunctionBox = 2
        MaterialsArrivals = 3
        SubSystem = 6
        System = 7
        Instruments = 8
        TestPacks = 9
        NoActualLength = 10
        LOOPS = 11
        Motors = 13
        ElectricalEquipment = 15
        InstrumentsCable = 16
        InstrumentEquipment = 17
        ElectricalJB = 18
        P6Activity = 19
        QAQC = 20
        ElectricalCableTray = 22
        LightingCables = 23
        LightingFixture = 24
        SubContractor = 25
        Unit = 26
        Area = 27
        InstrumentCableTray = 28
        ForeCastDate = 29
        Groups = 30
        CacheMaterial = 31
        Projects = 33
        ILD = 34
        InTools = 35
        Sequence = 36
        PartialEleCableTray = 37
        PartialInsCableTray = 38
        EleDrum = 39
        InsDrum = 40
        Block = 41
        AssignDrums = 42
        MiscItems = 43
        MiscItemsPartial = 44
    End Enum

    Public Enum en_MileStone
        ElectricalCablePulled = 11
        ElectricalCableCon1End = 12
        ElectricalCableConOEnd = 13
        InstrumentsInstalled = 21
        InstrumentsCalibrated = 22
        SingleCoreCablePulled = 31
        SingleCoreCableCon1End = 32
        SingleCoreCableConOEnd = 33
        SingleCoreCableMegger = 34
        MultiCoreCablePulled = 41
        MultiCoreCableCon1End = 42
        MultiCoreCableConOEnd = 43
        MultiCoreCableMegger = 44
        ControlStationInstall = 51
        JunctionBoxInstalled = 61
    End Enum

    Public Enum e_OverrideUpload
        OverrideData = 1
        NoOverrideData = 2
    End Enum

    Public Enum e_AddDublicated
        Yes = 1
        No = 2
    End Enum

    Public Sub UpdateSlaveDevise()
        Try
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateInsSlaveDate.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                DB.ExcuteNoneResult(temp(inx))
            Next
            RaiseEvent SlaveInstrumentUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub


    Public Sub UpdateProgressFromCachTable(ByVal OverridesProgress As Boolean)
        Dim lst As New ListBox, inx As Integer
        DB.ExcuteNoneResult("update tbl_Update_MileStone set reported_by= 'Cached' where reported_by is null")
        DB.Fill(lst, "select tbl_id from [tbl_Update_MileStone]")

        For inx = 0 To lst.Items.Count - 1
            RaiseEvent UpdateMileStoneCount(lst.Items.Count)
            Application.DoEvents()
            Select Case Val(DB.ExcutResult("select item_type from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))
                Case 11
                Case 12
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblelecablelist set [EC_Plan_Connected_Date_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            
                        End If

                    Else

                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select EC_Plan_Connected_Date_From from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblelecablelist set [EC_Plan_Connected_Date_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                             
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Already Connected From' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 13
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblelecablelist set [EC_Plan_Connected_Date_To]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                       
                        End If
                    Else
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select EC_Plan_Connected_Date_To from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblelecablelist set [EC_Plan_Connected_Date_To]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                               
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Already Connected To' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 14
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblelecablelist set [EC_Megger]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                           
                        End If
                    Else
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select EC_Megger from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblelecablelist set [EC_Megger]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                               
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Already Meggerd' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 15
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblelecablelist set [TR_QC_Released]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select TR_QC_Released from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblelecablelist set [TR_QC_Released]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Already Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 16
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblelecablelist set [EC_Cable_Gland_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select EC_Cable_Gland_From from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblelecablelist set [EC_Cable_Gland_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Already Gland From' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 17
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblelecablelist set [EC_Cable_Gland_To]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select ec_id from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select EC_Cable_Gland_To from tblelecablelist where ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblelecablelist set [EC_Cable_Gland_To]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE ec_id='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='EC Cable Already Gland To' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 21
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInstruments set [Installation_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select Installation_Date from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInstruments set [Installation_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 22
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInstruments set [Calibration_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Calibration_Date] from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInstruments set [Calibration_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Already Calibrated' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 23
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInstruments set [HookUp_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [HookUp_Date] from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInstruments set [HookUp_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Already Hooked Up' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 24
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInstruments set [Final_Installed_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Final_Installed_Date] from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInstruments set [Final_Installed_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Already Final Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 25 'Calibration_QC_Date
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInstruments set [Calibration_QC_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Calibration_QC_Date] from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInstruments set [Calibration_QC_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Already Final Calibration Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 26 'Hookup_QC_Date
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInstruments set [Hookup_QC_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Instrument_Tag from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instruments Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Hookup_QC_Date] from tblInstruments where Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInstruments set [Hookup_QC_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Instrument_Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Already Final Hookup Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 31

                Case 32
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableList set [IC_Plan_Connected_Date_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                          
                        End If
                    Else
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [IC_Plan_Connected_Date_From] from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableList set [IC_Plan_Connected_Date_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                                
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Already Connect 1 End' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 33
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableList set [IC_Plan_Connected_Date_To]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            
                        End If
                    Else
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [IC_Plan_Connected_Date_To] from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableList set [IC_Plan_Connected_Date_To]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                               
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Already Connect 2 End' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 34
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableList set [IC_Megger]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            
                        End If
                    Else
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [IC_Megger] from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableList set [IC_Megger]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                               
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Already Megger' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 35
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableList set [IC_Cable_Gland_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [IC_Cable_Gland_From] from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableList set [IC_Cable_Gland_From]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Already Gland 1 End' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 36
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableList set [IC_Cable_Gland_TO]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [IC_Cable_Gland_TO] from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableList set [IC_Cable_Gland_TO]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Already Gland 2 End' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 37
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableList set [TR_QC_Released]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select IC_ID from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [TR_QC_Released] from tblInsCableList where IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableList set [TR_QC_Released]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IC_ID='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Ins Cable Already Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 51
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select IN_Cable_Tray from tblInsCableTray where IN_Cable_Tray='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Cable Tray Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsCableTray set [IN_Tray_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IN_Cable_Tray='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select IN_Cable_Tray from tblInsCableTray where IN_Cable_Tray='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Cable Tray Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [IN_Tray_Installed] from tblInsCableTray where IN_Cable_Tray='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsCableTray set [IN_Tray_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE IN_Cable_Tray='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Cable Tray Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 61
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select JunctionBox from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update JunctionBox set [JI_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select JunctionBox from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [JI_Installed] from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update JunctionBox set [JI_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else

                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 62
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select JunctionBox from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update JunctionBox set [JI_Frame_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select JunctionBox from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [JI_Frame_Installed] from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update JunctionBox set [JI_Frame_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else

                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Frame Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If


                Case 63
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select JunctionBox from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update JunctionBox set [JI_TRQC]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select JunctionBox from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [JI_TRQC] from JunctionBox where JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update JunctionBox set [JI_TRQC]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE JunctionBox='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else

                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='JunctionBox Frame Already Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 71
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select TAG from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblMotor set [installed_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select TAG from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [installed_date] from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblMotor set [installed_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 72
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select TAG from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblMotor set [motor_test_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select TAG from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [motor_test_date] from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblMotor set [motor_test_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Already Tested' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 73
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select TAG from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblMotor set [solo_run_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select TAG from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [solo_run_date] from tblMotor where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblMotor set [solo_run_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Motor Already Solo Run Done' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 81 'Electrical Cable Trays
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select TAG from tblEleCableTray where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Tray Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblEleCableTray set [EL_Tray_Installed_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select TAG from tblEleCableTray where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Tray Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [EL_Tray_Installed_date] from tblEleCableTray where TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblEleCableTray set [EL_Tray_Installed_date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE TAG='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Tray Already Erected' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 90
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [L_Constr_Release]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else

                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [L_Constr_Release] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [L_Constr_Release]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Released By Construction' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 91
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [L_Done]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else

                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [L_Done] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [L_Done]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Done' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 95
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Loops_Client_QC_Release]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Loops_Client_QC_Release] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Loops_Client_QC_Release]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Released from the Client QA/QC' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 92
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [TR_Loop_Folder_QC_Release]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [TR_Loop_Folder_QC_Release] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [TR_Loop_Folder_QC_Release]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Released from TR QA/QC' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 93
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Punch_To_SubContractor]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Punch_To_SubContractor] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Punch_To_SubContractor]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Released to Sub-Contractor' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 94
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [SubContractor_To_Cons]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [SubContractor_To_Cons] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [SubContractor_To_Cons]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Returned to Construction' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If

                Case 96
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Folder_Preparation]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Folder_Preparation] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Folder_Preparation]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Folder Prepared' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 97
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [HCS_Folder_Ready]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [HCS_Folder_Ready] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [HCS_Folder_Ready]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already HCS Folder Ready' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If
                Case 98
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [L_FinalApproval]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [L_FinalApproval] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [L_FinalApproval]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Certificate' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If
                Case 99
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [HCS_Submitted_To_Client]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [HCS_Submitted_To_Client] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [HCS_Submitted_To_Client]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Delivered To ClientQC' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If
                Case 910
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Folder_Client_Approved]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Folder_Client_Approved] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Folder_Client_Approved]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Client Approved' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 911
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Submitted_to_Precom]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Submitted_to_Precom] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Submitted_to_Precom]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Submitted to Precom' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 912
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Submitted_To_Client_Precom]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Submitted_To_Client_Precom] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Submitted_To_Client_Precom]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Submitted to Manf' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 913
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Client_Precom_Approved]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Client_Precom_Approved] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Client_Precom_Approved]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Manf Approved' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 914
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Submitted_For_Certificate]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Submitted_For_Certificate] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Submitted_For_Certificate]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Submitted for Certificate' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 915
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Precom_Reject]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Precom_Reject] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Precom_Reject]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Rejected by Precom' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 916
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Client_Precom_Reject]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Client_Precom_Reject] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Client_Precom_Reject]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Rejected by Manf' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 917
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblInsLoop set [Client_Reject]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select LoopName from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Client_Reject] from tblInsLoop where LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblInsLoop set [Client_Reject]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE LoopName='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Loop Already Rejected by Client' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If
                Case 111    'Electrical Equipment
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult(String.Format("select TAG from tblElectricalEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult(String.Format("update tblElectricalEquipment set [Installed_Date]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                        End If
                    Else
                        If DB.ExcutResult(String.Format("select TAG from tblElectricalEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult(String.Format("select Installed_Date from tblElectricalEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                                DB.ExcuteNoneResult(String.Format("update tblElectricalEquipment set [Installed_Date]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Equipment Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 114    'Electrical Equipment QC
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult(String.Format("select TAG from tblElectricalEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult(String.Format("update tblElectricalEquipment set [TR_QC_Released]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                        End If
                    Else
                        If DB.ExcutResult(String.Format("select TAG from tblElectricalEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult(String.Format("select TR_QC_Released from tblElectricalEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                                DB.ExcuteNoneResult(String.Format("update tblElectricalEquipment set [TR_QC_Released]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical Equipment Already Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 112    'Electrical JB
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult(String.Format("select tag from tblEleJunctionBox where tag='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical JB Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult(String.Format("update tblEleJunctionBox set [JE_Installed]='{0}' WHERE tag='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                        End If
                    Else
                        If DB.ExcutResult(String.Format("select tag from tblEleJunctionBox where tag='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical JB Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult(String.Format("select JE_Installed from tblEleJunctionBox where tag='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                                DB.ExcuteNoneResult(String.Format("update tblEleJunctionBox set [JE_Installed]='{0}' WHERE tag='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Electrical JB Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 211    'Instrument Equipment
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult(String.Format("select TAG from tblInsEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult(String.Format("update tblInsEquipment set [Installed_Date]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                        End If
                    Else
                        If DB.ExcutResult(String.Format("select TAG from tblInsEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult(String.Format("select Installed_Date from tblInsEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                                DB.ExcuteNoneResult(String.Format("update tblInsEquipment set [Installed_Date]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Equipment Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 212    'Instrument Equipment QC
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult(String.Format("select TAG from tblInsEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult(String.Format("update tblInsEquipment set [TR_QC_Released]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                        End If
                    Else
                        If DB.ExcutResult(String.Format("select TAG from tblInsEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Equipment Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult(String.Format("select TR_QC_Released from tblInsEquipment where TAG='{0}'", DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)))) = "" Then
                                DB.ExcuteNoneResult(String.Format("update tblInsEquipment set [TR_QC_Released]='{0}' WHERE TAG='{1}'", Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy"), DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))))
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Instrument Equipment Already Released' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 113    'Lighting Fixture
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Tag from tblLightingFixture where Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Lighting Fixture Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblLightingFixture set [lf_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select Tag from tblLightingFixture where Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Lighting FIxture Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select lf_Installed from tblLightingFixture where Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblLightingFixture set [lf_Installed]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE Tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='Lighting Fixture Already Installed' where tbl_id=" & lst.Items(inx))
                            End If
                        End If
                    End If

                Case 101    'Lighting Cable Pulled

                Case 102    'Lighting Cable Glanding
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Tag from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblMSCCable set [Glanding_FROM_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select tag from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Glanding_FROM_Date] from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblMSCCable set [Glanding_FROM_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Already Glanded' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 103    'Lighting Cable Connected
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Tag from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblMSCCable set [Connection_From_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select tag from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [Connection_From_Date] from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblMSCCable set [Connection_From_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Already Connected' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
                Case 104    'Lighting Cable QC
                    If OverridesProgress Then   'Overrides Existing Miles Stone
                        'Overrides Existing Miles Stone
                        If DB.ExcutResult("select Tag from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            DB.ExcuteNoneResult("update tblMSCCable set [QCReleased_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                        End If
                    Else
                        If DB.ExcutResult("select tag from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                            DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Not Found' where tbl_id=" & lst.Items(inx))
                        Else
                            If DB.ExcutResult("select [QCReleased_Date] from tblMSCCable where tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'") = "" Then
                                DB.ExcuteNoneResult("update tblMSCCable set [QCReleased_Date]='" & Format(CDate(DB.ExcutResult("select update_date from tbl_Update_MileStone where tbl_id=" & lst.Items(inx))), "MM/dd/yyyy") & "' WHERE tag='" & DB.ExcutResult("select tag from tbl_Update_MileStone where tbl_id=" & lst.Items(inx)) & "'")
                            Else
                                DB.ExcuteNoneResult("update tbl_Update_MileStone set update_err='MISC Cable Already Tested' where tbl_id=" & lst.Items(inx))
                            End If
                        End If

                    End If
            End Select

            Application.DoEvents()
            RaiseEvent UpdateMileStoneProgress(inx + 1)
            Application.DoEvents()
        Next
        If _PCAUpdate = -1 Then UpdatetblInstrumentsTP()
        If _UpdateInsEqPCA = -1 Then UpdatetblInstrumentsEQ()
        If _SetInsFinal = -1 Then UpdateInsInstallationMissing()
        If _UpdateSlaveDevise = -1 Then UpdateSlaveDevise()
        If _UpdateLoopConsFinished = -1 Then UpdateLoopConsFinished()
        If _LoopConsReleasedQCBacklog = 0 Then UpdateLoopConsFinishedBacklog()
        UpdateP6()
        ' WatchDogRelease()
        DB.ExcuteNoneResult("update [tblTMP] set [Production_Updated] ='True' where [tmp_id]=1")
        DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                            My.User.Name & " Has Update EICA Production','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Production Update')")
        DB.ExcuteNoneResult("update tblinsloop set status='Approved' where status ='On Hold' and TR_Loop_Folder_QC_Release is not null")
        RaiseEvent UpdateProgressComplete()
    End Sub

    Public Sub UpdateProductionFromNativeFiles(ByVal filePath As String, ByVal DataType As e_DataType, ByRef grd As DataGridView, ByVal OverridesProgress As Boolean)
        Try
            DB.ExcuteNoneResult(String.Format("delete from tbl_Update_MileStone WHERE update_user ='{0}'", My.User.Name))
            Dim ex As New EAMS.MSOffice.Excel, dt As New DataTable
            Dim inx As Integer = 0
            DB.ExcuteNoneResult("delete from tbllog")
            dt = ex.GetSheetData(filePath, SheetName)
            RaiseEvent ProgressDataCount(dt.Rows.Count)
            grd.DataSource = dt
            For inx = 0 To dt.Rows.Count - 1
                Select Case DataType
                    Case Engineering.e_DataType.ElectricalEquipment
                        If Not IsDBNull(dt.Rows(inx).Item("Installed_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 111 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Installed_Date")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_QC_Released")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 114 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("TR_QC_Released")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case Engineering.e_DataType.ElectricalCables
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Plan_Pulled_Date")) Then
                            If Not IsDBNull(dt.Rows(inx).Item("PercentageDone")) Then
                                DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,ms_1,ms_2,ms_3,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 11 & ",'" & dt.Rows(inx).Item("ec_Plan_Real_Qty_Pulled") & "','" & dt.Rows(inx).Item("EC_ActualDrum") & "'," & dt.Rows(inx).Item("PercentageDone") & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("ec_Plan_Pulled_Date")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')", 0)
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Cable_Gland_From")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 16 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("ec_Cable_Gland_From")), "MM/dd/yyyy") & "')", 0)
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Cable_Gland_To")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 17 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("ec_Cable_Gland_To")), "MM/dd/yyyy") & "')", 0)
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Plan_Connected_Date_From")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 12 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("ec_Plan_Connected_Date_From")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')", 0)
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Plan_Connected_Date_To")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 13 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("ec_Plan_Connected_Date_To")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')", 0)
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Megger")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 14 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("ec_Megger")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')", 0)
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("tr_qc_released")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 15 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("tr_qc_released")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')", 0)
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case e_DataType.ElectricalJB
                        If Not IsDBNull(dt.Rows(inx).Item("JE_Installed")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 112 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("JE_Installed")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.ElectricalCableTray
                        If Not IsDBNull(dt.Rows(inx).Item("EL_Tray_Installed_date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 81 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("EL_Tray_Installed_date")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.LightingCables
                        If Not IsDBNull(dt.Rows(inx).Item("Pulling_Date")) Then
                            If Not IsDBNull(dt.Rows(inx).Item("PercentageDone")) Then
                                DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_1,ms_2,ms_3,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 101 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Pulling_Date")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Pulled_Length") & "','" & dt.Rows(inx).Item("Actual_Drum") & "'," & dt.Rows(inx).Item("PercentageDone") & ",'" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Glanding_FROM_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 102 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Glanding_FROM_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Connection_From_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 103 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Connection_From_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("QCReleased_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 104 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("QCReleased_Date")), "MM/dd/yyyy") & "')")
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case e_DataType.LightingFixture
                        If Not IsDBNull(dt.Rows(inx).Item("LF_Installed")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 113 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("LF_Installed")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.Instruments
                        If Not IsDBNull(dt.Rows(inx).Item("Calibration_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 22 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Calibration_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Installation_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 21 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Installation_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("HookUp_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 23 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("HookUp_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Final_Installed_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 24 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Final_Installed_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Hookup_QC_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 26 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Hookup_QC_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Calibration_QC_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 25 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Calibration_QC_Date")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.InstrumentsCable
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Plan_Pulled_Date")) Then
                            If Not IsDBNull(dt.Rows(inx).Item("PercentageDone")) Then
                                DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,ms_1,ms_2,ms_3,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 31 & ",'" & dt.Rows(inx).Item("IC_Plan_Real_Qty_Pulled") & "','" & dt.Rows(inx).Item("iC_ActualDrum") & "'," & dt.Rows(inx).Item("PercentageDone") & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IC_Plan_Pulled_Date")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Cable_Gland_From")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 35 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IC_Cable_Gland_From")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Cable_Gland_To")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 36 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IC_Cable_Gland_To")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Plan_Connected_Date_From")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 32 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IC_Plan_Connected_Date_From")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Plan_Connected_Date_To")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 33 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IC_Plan_Connected_Date_To")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Megger")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 34 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IC_Megger")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_QC_Released")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 37 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("TR_QC_Released")), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "')")
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case e_DataType.JunctionBox
                        If Not IsDBNull(dt.Rows(inx).Item("JI_Installed")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 61 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("JI_Installed")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("JI_Frame_Installed")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 62 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("JI_Frame_Installed")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("JI_TRQC")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 63 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("JI_TRQC")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.InstrumentEquipment
                        If Not IsDBNull(dt.Rows(inx).Item("Installed_Date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 211 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Installed_Date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_QC_Released")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 212 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("TR_QC_Released")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.LOOPS
                        If Not IsDBNull(dt.Rows(inx).Item("Folder_Preparation")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 96 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Folder_Preparation")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("L_Constr_Release")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 90 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("L_Constr_Release")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_Loop_Folder_QC_Release")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 92 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("TR_Loop_Folder_QC_Release")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Punch_To_SubContractor")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 93 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Punch_To_SubContractor")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("SubContractor_To_Cons")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 94 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("SubContractor_To_Cons")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Loops_Client_QC_Release")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 95 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Loops_Client_QC_Release")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("HCS_Folder_Ready")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 97 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("HCS_Folder_Ready")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("HCS_Submitted_To_Client")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 99 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("HCS_Submitted_To_Client")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Client_Reject")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 917 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Client_Reject")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Folder_Client_Approved")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 910 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Folder_Client_Approved")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Submitted_to_Precom")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 911 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Submitted_to_Precom")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Precom_Reject")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 915 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Precom_Reject")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Submitted_To_Client_Precom")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 912 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Submitted_To_Client_Precom")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Client_Precom_Reject")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 916 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Client_Precom_Reject")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Client_Precom_Approved")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 913 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Client_Precom_Approved")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("L_Done")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 91 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("L_Done")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Submitted_For_Certificate")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 914 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Submitted_For_Certificate")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("L_FinalApproval")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 98 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("L_FinalApproval")), "MM/dd/yyyy") & "')")
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case e_DataType.InstrumentCableTray
                        If Not IsDBNull(dt.Rows(inx).Item("IN_Tray_Installed")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 51 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("IN_Tray_Installed")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.PartialEleCableTray
                        If Not IsDBNull(dt.Rows(inx).Item("Closed Date")) Then
                            DB.ExcuteNoneResult("exec AddPartialECT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "' ,Null," & dt.Rows(inx).Item("Production_Qnty") & ",'" & Format(CDate(dt.Rows(inx).Item("Closed Date")), "MM/dd/yyyy").ToString & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "'")
                        Else
                            If Not IsDBNull(dt.Rows(inx).Item("Production_Date")) Then
                                DB.ExcuteNoneResult("exec AddPartialECT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Production_Date")), "MM/dd/yyyy") & "'," & dt.Rows(inx).Item("Production_Qnty") & ",Null,'" & dt.Rows(inx).Item("Actual Subcontractor") & "'")
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.PartialInsCableTray
                        If Not IsDBNull(dt.Rows(inx).Item("Closed Date")) Then
                            DB.ExcuteNoneResult("exec AddPartialiCT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "',Null," & dt.Rows(inx).Item("Production_Qnty") & ",'" & Format(CDate(dt.Rows(inx).Item("Closed Date")), "MM/dd/yyyy").ToString & "','" & dt.Rows(inx).Item("Actual Subcontractor") & "'")
                        Else
                            If Not IsDBNull(dt.Rows(inx).Item("Production_Date")) Then
                                DB.ExcuteNoneResult("exec AddPartialICT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Production_Date")), "MM/dd/yyyy").ToString & "'," & dt.Rows(inx).Item("Production_Qnty") & ",Null,'" & dt.Rows(inx).Item("Actual Subcontractor") & "'")
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.Motors
                        If Not IsDBNull(dt.Rows(inx).Item("Installed_date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 71 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("Installed_date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("motor_test_date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 72 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("motor_test_date")), "MM/dd/yyyy") & "')")
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("solo_run_date")) Then
                            DB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date) values ('" & dt.Rows(inx).Item("TAG") & "'," & 73 & ",'" & My.User.Name & "','" & Format(CDate(dt.Rows(inx).Item("solo_run_date")), "MM/dd/yyyy") & "')")
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.MiscItems
                        If Not IsDBNull(dt.Rows(inx).Item("Done_date")) Then
                            If Not IsDBNull(dt.Rows(inx).Item("Quantity")) Then
                                If Not IsDBNull(dt.Rows(inx).Item("Item_Name")) Then
                                    DB.ExcuteNoneResult(String.Format("sp_ItemProductionTotal '{0}','{1}',{2},'{3}','{4}'", dt.Rows(inx).Item("Item_Name"), dt.Rows(inx).Item("Done_date"), dt.Rows(inx).Item("Quantity"), My.User.Name, dt.Rows(inx).Item("Subcontractor")))
                                End If
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case e_DataType.MiscItemsPartial
                        If Not IsDBNull(dt.Rows(inx).Item("Done_date")) Then
                            If Not IsDBNull(dt.Rows(inx).Item("Quantity")) Then
                                If Not IsDBNull(dt.Rows(inx).Item("Item_Name")) Then
                                    DB.ExcuteNoneResult(String.Format("sp_ItemProduction '{0}','{1}',{2},'{3}','{4}'", dt.Rows(inx).Item("Item_Name"), dt.Rows(inx).Item("Done_date"), dt.Rows(inx).Item("Quantity"), My.User.Name, dt.Rows(inx).Item("Subcontractor")))
                                End If
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------
                End Select
            
                Application.DoEvents()
                RaiseEvent ProgressIndex(inx + 1)
            Next
            DB.ExcuteNoneResult("exec UpdateECPro", 0)
            DB.ExcuteNoneResult("exec UpdateICPro", 0)
            DB.ExcuteNoneResult("exec UpdateLCPro", 0)
            DB.ExcuteNoneResult("UPDATE [tblInstruments] SET Final_Installed_Date=[Installation_Date] WHERE [Installation_Date] IS NOT NULL AND QC_Required=0")
            UpdateProgressFromCachTable(OverridesProgress)
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub UpdateEngineeringData(ByRef DataFromExcel As DataTable, ByVal UploadDataType As e_DataType, Optional ByVal FixBrokenTag As Boolean = False)
        Try
            If DataFromExcel.Rows.Count = 0 Then
                RaiseEvent Err("There is No Data to Update")
                Exit Sub
            End If
            Dim sql As String = ""
            Dim inx As Integer, iny As Integer
            Dim TbName As String = ""

            'Vector
            Select Case UploadDataType
                Case e_DataType.Area
                    TbName = "Area"
                Case e_DataType.ElectricalCables
                    TbName = "tblEleCableList"
                Case e_DataType.ElectricalCableTray
                    TbName = "tblEleCableTray"
                Case e_DataType.ElectricalEquipment
                    TbName = "tblElectricalEquipment"
                Case e_DataType.ElectricalJB
                    TbName = "tblEleJunctionBox"
                Case e_DataType.InstrumentCableTray
                    TbName = "tblInsCableTray"
                Case e_DataType.InstrumentEquipment
                    TbName = "tblInsEquipment"
                Case e_DataType.Instruments
                    TbName = "tblInstruments"
                Case e_DataType.InstrumentsCable
                    TbName = "tblInsCableList"
                Case e_DataType.JunctionBox
                    TbName = "JunctionBox"
                Case e_DataType.LightingCables
                    TbName = "tblMSCCable"
                Case e_DataType.LightingFixture
                    TbName = "tblLightingFixture"
                Case e_DataType.LOOPS
                    TbName = "tblInsLoop"
                Case e_DataType.MaterialsArrivals
                    TbName = "tblArrivalMatComp"
                Case e_DataType.Motors
                    TbName = "tblMotor"
                Case e_DataType.Projects
                    TbName = "tblProject"
                Case e_DataType.Sequence
                    TbName = "Sequence"
                Case e_DataType.SubContractor
                    TbName = "SubContractor"
                Case e_DataType.SubSystem
                    TbName = "Subsystem"
                Case e_DataType.Unit
                    TbName = "Unit"
                Case e_DataType.System
                    TbName = "Systems"
                Case e_DataType.EleDrum
                    TbName = "tblDrums"
                Case e_DataType.InsDrum
                    TbName = "tblDrums"
                Case e_DataType.ILD
                    TbName = "tblILD"
                Case e_DataType.Block
                    TbName = "tblBlock"
                Case e_DataType.P6Activity
                    TbName = "tblActIDS"
                Case e_DataType.MiscItems
                    TbName = "tblItems"
            End Select
            '----------------

            'Main -----------------------------------------------------------------------------------------------------
            For inx = 0 To DataFromExcel.Rows.Count - 1
                For iny = 1 To DataFromExcel.Columns.Count - 1
                    If IsDBNull(DataFromExcel.Rows(inx).Item(iny)) Then
                        sql = "update " & TbName & " set [" & DataFromExcel.Columns(iny).ColumnName & "] = " & "null" & " " & _
                           "where [" & DataFromExcel.Columns(0).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(0).ToString & "'"
                    Else
                        If DataFromExcel.Columns(iny).DataType.Name = vbDouble.ToString Or DataFromExcel.Columns(iny).DataType.Name = vbDecimal.ToString Then
                            sql = "update " & TbName & " set [" & DataFromExcel.Columns(iny).ColumnName & "] = " & Val(DataFromExcel.Rows(inx).Item(iny).ToString) & " " & _
                           "where [" & DataFromExcel.Columns(0).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(0).ToString & "'"
                        ElseIf DataFromExcel.Columns(iny).DataType.Name = vbDate.ToString Then
                            sql = "update " & TbName & " set [" & DataFromExcel.Columns(iny).ColumnName & "] = '" & Format(CDate(DataFromExcel.Rows(inx).Item(iny)), "MM/dd/yyyy") & "' " & _
                            "where [" & DataFromExcel.Columns(0).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(0).ToString & "'"
                        ElseIf DataFromExcel.Columns(iny).DataType.Name = "DateTime" Then
                            sql = "update " & TbName & " set [" & DataFromExcel.Columns(iny).ColumnName & "] = '" & Format(CDate(DataFromExcel.Rows(inx).Item(iny)), "MM/dd/yyyy") & "' " & _
                            "where [" & DataFromExcel.Columns(0).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(0).ToString & "'"
                        Else
                            If FixBrokenTag Then
                                sql = "update " & TbName & " set [" & DataFromExcel.Columns(iny).ColumnName & "] = '" & FixBorkeTag(DataFromExcel.Rows(inx).Item(iny).ToString) & "' " & _
                             "where [" & DataFromExcel.Columns(0).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(0).ToString & "'"
                            Else
                                sql = "update " & TbName & " set [" & DataFromExcel.Columns(iny).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(iny).ToString & "' " & _
                            "where [" & DataFromExcel.Columns(0).ColumnName & "] = '" & DataFromExcel.Rows(inx).Item(0).ToString & "'"
                            End If
                        End If
                    End If
                    DB.ExcuteNoneResult(sql)
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
            Next
            '---------------------------------------------------------------------------
            Select Case UploadDataType

                Case e_DataType.SubContractor 'SubContractor
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Lighting Cable Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.SubContractor 'SubContractor
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update SubContractor Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.Area 'Area
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Areas Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.Projects 'Project
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Project Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Handover')")
                    RaiseEvent UploadFinish()
                Case e_DataType.Sequence 'Sequence
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Sequence Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Pre-Com')")
                    RaiseEvent UploadFinish()
                Case e_DataType.Unit 'Unit
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Unit Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Handover')")
                    RaiseEvent UploadFinish()
                Case e_DataType.InTools 'Intool
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update InTool Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.ILD   'ILD
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update ILD Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.ElectricalCableTray    'Electrical Cable Tray
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Electrical Cable Tray Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()

                Case e_DataType.InstrumentCableTray     'Instrument Cable Tray
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Instrument Cable Tray Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.LightingFixture  'Lighting Fixture
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Lighting Fixtures Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.ElectricalJB  'Electrical Junction Box
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Electrical JBs Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.JunctionBox  'Junction Box
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Instruments JBs Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.InstrumentEquipment  'Instrument Equipment
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Instrument Equipment Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.ElectricalEquipment  'Electrical Equipment
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Electrical Equipment Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.InstrumentsCable  'Instruments Cable
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Instrument Cables Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.Instruments  'Instruments
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Instruments Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.Motors  'Motors
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Motors Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.ElectricalCables  'Electrical Cable
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Electrical Cables Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.LOOPS  'Loops
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Loops Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.System  'System
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update System Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                    RaiseEvent UploadFinish()
                Case e_DataType.SubSystem  'Subsystem
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Subsystem Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.EleDrum  'Ele Drums
                    DB.ExcuteNoneResult("update [tblDrums] set length=eng_length where eng_length >0 and Drum_ID not in (select drum_id from tblDrumLog)")
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Electrical Drums Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.InsDrum  'Ins Drums
                    DB.ExcuteNoneResult("update [tblDrums] set length=eng_length where eng_length >0 and Drum_ID not in (select drum_id from tblDrumLog)")
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                          My.User.Name & " Has Update Instrument Drums Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.ILD
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                         My.User.Name & " Has Update ILD Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.Block
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                       My.User.Name & " Has Update Block Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.P6Activity
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                       My.User.Name & " Has Update P6 Activities Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.MiscItems
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                       My.User.Name & " Has Update Misc Items','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
            End Select
            UpdateP6()
            RaiseEvent UploadFinish()
            DB.ExcuteNoneResult("update [tblTMP] set [bad_values]=1 where [tmp_id]=1")
            If _UpdateSlaveDevise = 1 Then UpdateSlaveDevise()
            WatchDogRelease()
            DB.ExcuteNoneResult("update [tblTMP] set [Production_Updated] ='True' where [tmp_id]=1")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UploadToCach(ByRef DataFromExcel As DataTable)
        Try
            If DataFromExcel.Rows.Count = 0 Then
                RaiseEvent Err("There is No Data to Update")
                Exit Sub
            End If
            Dim Data As String = ""
            Dim ColumnName As String = ""
            Dim sql As String = ""
            Dim inx As Integer, iny As Integer

            'Get Column Name
            ColumnName = String.Format("([{0}]", DataFromExcel.Columns(0).ColumnName)
            For iny = 1 To DataFromExcel.Columns.Count - 1
                If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                ColumnName &= String.Format(",[{0}]", DataFromExcel.Columns(iny).ColumnName)
            Next
            ColumnName &= ",update_user)"
            '----------------
            'Get Data
            For inx = 0 To DataFromExcel.Rows.Count - 1
                Data = String.Format("('{0}'", DataFromExcel.Rows(inx).Item(0))
                For iny = 1 To DataFromExcel.Columns.Count - 1
                    If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                    If DataFromExcel.Columns(iny).DataType.Name = vbDouble.ToString Or DataFromExcel.Columns(iny).DataType.Name = vbDecimal.ToString Then
                        Data &= "," & Val(DataFromExcel.Rows(inx).Item(iny).ToString)
                    ElseIf DataFromExcel.Columns(iny).DataType.Name = vbDate.ToString Then
                        Data &= String.Format(",'{0}'", Format(CDate(DataFromExcel.Rows(inx).Item(iny)), "MM/dd/yyyy"))
                    ElseIf DataFromExcel.Columns(iny).DataType.Name = "DateTime" Then
                        Data &= String.Format(",'{0}'", Format(CDate(DataFromExcel.Rows(inx).Item(iny)), "MM/dd/yyyy"))
                    Else
                        Data &= String.Format(",'{0}'", Trim(DataFromExcel.Rows(inx).Item(iny).ToString))
                    End If
                Next
                Data &= String.Format(",'{0}')", My.User.Name)
                Application.DoEvents()

                sql = String.Format("insert into [tbl_Update_MileStone] {0} values {1}", ColumnName, Data)
                DB.ExcuteNoneResult(sql)
                RaiseEvent ProgressDataCount(inx + 1)
            Next
            '------

            RaiseEvent UploadFinish()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Public Sub UploadEngineeringData(ByRef DataFromExcel As DataTable, ByVal UploadDataType As e_DataType, ByVal OverrideDataFlag As e_OverrideUpload, Optional ByVal AddDublicated As e_AddDublicated = e_AddDublicated.No, Optional ByVal FixBrokenTag As Boolean = False)
        Try
            If DataFromExcel.Rows.Count = 0 Then
                RaiseEvent Err("There is No Data to Update")
                Exit Sub
            End If
            Dim Data As String = ""
            Dim ColumnName As String = ""
            Dim sql As String = ""
            Dim inx As Integer, iny As Integer
            Dim TbName As String = ""
            'Vector
            Select Case UploadDataType
                Case e_DataType.Area
                    TbName = "Area"
                Case e_DataType.ElectricalCables
                    TbName = "tblEleCableList"
                Case e_DataType.ElectricalCableTray
                    TbName = "tblEleCableTray"
                Case e_DataType.ElectricalEquipment
                    TbName = "tblElectricalEquipment"
                Case e_DataType.ElectricalJB
                    TbName = "tblEleJunctionBox"
                Case e_DataType.InstrumentCableTray
                    TbName = "tblInsCableTray"
                Case e_DataType.InstrumentEquipment
                    TbName = "tblInsEquipment"
                Case e_DataType.Instruments
                    TbName = "tblInstruments"
                Case e_DataType.InstrumentsCable
                    TbName = "tblInsCableList"
                Case e_DataType.JunctionBox
                    TbName = "JunctionBox"
                Case e_DataType.LightingCables
                    TbName = "tblMSCCable"
                Case e_DataType.LightingFixture
                    TbName = "tblLightingFixture"
                Case e_DataType.LOOPS
                    TbName = "tblInsLoop"
                Case e_DataType.MaterialsArrivals
                    TbName = "tblArrivalMatComp"
                Case e_DataType.Motors
                    TbName = "tblMotor"
                Case e_DataType.Projects
                    TbName = "tblProject"
                Case e_DataType.Sequence
                    TbName = "Sequence"
                Case e_DataType.SubContractor
                    TbName = "SubContractor"
                Case e_DataType.SubSystem
                    TbName = "Subsystem"
                Case e_DataType.Unit
                    TbName = "Unit"
                Case e_DataType.System
                    TbName = "Systems"
                Case e_DataType.EleDrum
                    TbName = "tblDrums"
                Case e_DataType.InsDrum
                    TbName = "tblDrums"
                Case e_DataType.ILD
                    TbName = "tblILD"
                Case e_DataType.Block
                    TbName = "tblBlock"
                Case e_DataType.P6Activity
                    TbName = "tblActIDS"
                Case e_DataType.MiscItems
                    TbName = "tblItems"
            End Select
            '----------------

            'Main -----------------------------------------------------------------------------------------------------
            '================================================================
            If OverrideDataFlag = e_OverrideUpload.OverrideData Then    'Override Existing Data

                Select Case UploadDataType
                    Case e_DataType.EleDrum
                        DB.ExcuteNoneResult(String.Format("delete from {0} where type =1", TbName))
                    Case e_DataType.InsDrum
                        DB.ExcuteNoneResult(String.Format("delete from {0} where type =2", TbName))
                    Case Else
                        DB.ExcuteNoneResult("delete from " & TbName)
                End Select



                'Get Column Name
                ColumnName = String.Format("([{0}]", DataFromExcel.Columns(0).ColumnName)
                For iny = 1 To DataFromExcel.Columns.Count - 1
                    If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                    ColumnName &= String.Format(",[{0}]", DataFromExcel.Columns(iny).ColumnName)
                Next
                Select Case UploadDataType
                    Case e_DataType.EleDrum, e_DataType.InsDrum
                        ColumnName &= ",type)"
                    Case Else
                        ColumnName &= ")"
                End Select

                '----------------

                'Get Data
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If FixBrokenTag Then
                        Data = String.Format("('{0}'", FixBorkeTag(DataFromExcel.Rows(inx).Item(0)))
                    Else
                        Data = String.Format("('{0}'", DataFromExcel.Rows(inx).Item(0))
                    End If

                    For iny = 1 To DataFromExcel.Columns.Count - 1
                        If IsDBNull(DataFromExcel.Rows(inx).Item(iny)) Then
                            Data &= "," & "null"
                        Else
                            If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                            If DataFromExcel.Columns(iny).DataType.Name = vbDouble.ToString Or DataFromExcel.Columns(iny).DataType.Name = vbDecimal.ToString Then
                                Data &= "," & Val(DataFromExcel.Rows(inx).Item(iny).ToString)
                            ElseIf DataFromExcel.Columns(iny).DataType.Name = "DateTime" Then

                                If Trim(DataFromExcel.Rows(inx).Item(iny).ToString) = "" Then
                                    Data &= ",'" & "" & "'"
                                Else
                                    Data &= String.Format(",'{0}'", Format(CDate(DataFromExcel.Rows(inx).Item(iny).ToString), "MM/dd/yyyy"))
                                End If
                            Else
                                If FixBrokenTag Then
                                    Data &= String.Format(",'{0}'", FixBorkeTag(DataFromExcel.Rows(inx).Item(iny)))
                                Else
                                    Data &= String.Format(",'{0}'", DataFromExcel.Rows(inx).Item(iny))
                                End If
                            End If
                        End If
                    Next
                    Select Case UploadDataType
                        Case e_DataType.EleDrum
                            Data &= ",1)"
                        Case e_DataType.InsDrum
                            Data &= ",2)"
                        Case Else
                            Data &= ")"
                    End Select

                    Application.DoEvents()
                    sql = String.Format("insert into {2} {0} values {1}", ColumnName, Data, TbName)
                    DB.ExcuteNoneResult(sql)
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '------

            Else    'NO Override Existing Data

                'Get Column Name
                ColumnName = String.Format("([{0}]", DataFromExcel.Columns(0).ColumnName)
                For iny = 1 To DataFromExcel.Columns.Count - 1
                    If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                    ColumnName &= String.Format(",[{0}]", DataFromExcel.Columns(iny).ColumnName)
                Next
                Select Case UploadDataType
                    Case e_DataType.EleDrum, e_DataType.InsDrum
                        ColumnName &= ",type)"
                    Case Else
                        ColumnName &= ")"
                End Select
                '----------------

                'Get Data
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    'Check if existing in EIKA DB
                    If DB.ExcutResult(String.Format("select [{0}] from {1} where [{2}]='{3}'", DataFromExcel.Columns(0).ColumnName, TbName, DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) <> "" Then
                        If AddDublicated = e_AddDublicated.Yes Then 'Add Dublicated

                            Data = String.Format("('{0}'", DataFromExcel.Rows(inx).Item(0))

                            For iny = 1 To DataFromExcel.Columns.Count - 1
                                If IsDBNull(DataFromExcel.Rows(inx).Item(iny)) Then
                                    Data &= "," & "null"
                                Else
                                    If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                                    If DataFromExcel.Columns(iny).DataType.Name = vbDouble.ToString Or DataFromExcel.Columns(iny).DataType.Name = vbDecimal.ToString Then
                                        Data &= "," & Val(DataFromExcel.Rows(inx).Item(iny).ToString)
                                    ElseIf DataFromExcel.Columns(iny).DataType.Name = "DateTime" Then
                                        If Trim(DataFromExcel.Rows(inx).Item(iny).ToString) = "" Then
                                            Data &= ",'" & "" & "'"
                                        Else
                                            Data &= String.Format(",'{0}'", Format(CDate(DataFromExcel.Rows(inx).Item(iny).ToString), "MM/dd/yyyy"))
                                        End If
                                    Else
                                        If FixBrokenTag Then
                                            Data &= String.Format(",'{0}'", FixBorkeTag(DataFromExcel.Rows(inx).Item(iny)))
                                        Else
                                            Data &= String.Format(",'{0}'", DataFromExcel.Rows(inx).Item(iny))
                                        End If
                                    End If
                                End If
                                Application.DoEvents()
                            Next

                            Select Case UploadDataType
                                Case e_DataType.EleDrum
                                    Data &= ",1)"
                                Case e_DataType.InsDrum
                                    Data &= ",2)"
                                Case Else
                                    Data &= ")"
                            End Select

                            If Data <> "" Then
                                sql = String.Format("insert into {2} {0} values {1}", ColumnName, Data, TbName)
                                DB.ExcuteNoneResult(sql)
                            End If
                        End If
                    Else
                        If FixBrokenTag Then
                            Data = String.Format("('{0}'", FixBorkeTag(DataFromExcel.Rows(inx).Item(0)))
                        Else
                            Data = String.Format("('{0}'", DataFromExcel.Rows(inx).Item(0))
                        End If

                        For iny = 1 To DataFromExcel.Columns.Count - 1
                            If IsDBNull(DataFromExcel.Rows(inx).Item(iny)) Then
                                Data &= "," & "null"
                            Else
                                If DataFromExcel.Columns(iny).ColumnName = "" Then Exit For
                                If DataFromExcel.Columns(iny).DataType.Name = vbDouble.ToString Or DataFromExcel.Columns(iny).DataType.Name = vbDecimal.ToString Then
                                    Data &= "," & Val(DataFromExcel.Rows(inx).Item(iny).ToString)
                                ElseIf DataFromExcel.Columns(iny).DataType.Name = "DateTime" Then
                                    If Trim(DataFromExcel.Rows(inx).Item(iny).ToString) = "" Then
                                        Data &= ",'" & "" & "'"
                                    Else
                                        Data &= String.Format(",'{0}'", Format(CDate(DataFromExcel.Rows(inx).Item(iny).ToString), "MM/dd/yyyy"))
                                    End If
                                Else
                                    Data &= String.Format(",'{0}'", DataFromExcel.Rows(inx).Item(iny))
                                End If
                            End If
                            Application.DoEvents()
                        Next

                        Select Case UploadDataType
                            Case e_DataType.EleDrum
                                Data &= ",1)"
                            Case e_DataType.InsDrum
                                Data &= ",2)"
                            Case Else
                                Data &= ")"
                        End Select

                        If Data <> "" Then
                            sql = String.Format("insert into {2} {0} values {1}", ColumnName, Data, TbName)
                            DB.ExcuteNoneResult(sql)
                        End If
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)

                Next
                '------
            End If
            '====================================================================================
            '---------------------------------------------------------------------------------------------------------------------------------------



            Select Case UploadDataType
                Case e_DataType.LightingCables 'Lighting Cables
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload Lighting Cable Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.SubContractor 'SubContractor
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload SubContractor Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.Area 'area
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload Area Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.Projects 'Project
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload Project Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Handover')")
                Case e_DataType.Unit 'Unit
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload Unit Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Handover')")
                Case e_DataType.Sequence 'Sequence
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload Sequence Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Pre-Com')")
                Case e_DataType.InTools 'Intool
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                          My.User.Name & " Has Upload Intool Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.ElectricalCableTray    'Electrical Cable Tray
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Electrical Cable Tray Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.CacheMaterial    'Cached Material
                    DB.ExcuteNoneResult("UPDATE [tblCacheMatComp] set [arrival_date] = null where [arrival_date] <= '1/1/1900'")
                    DB.ExcuteNoneResult("UPDATE [tblCacheMatComp] set [Forescasted] = null where [Forescasted] <= '1/1/1900'")
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Cached Material Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.InstrumentCableTray    'Instrument Cable Tray
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Instrument Cable Tray Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.LightingFixture    'Lighting Fixture
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Lighting Fixtures Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.ElectricalJB
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Electrical JBs Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.InstrumentEquipment
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Instrument Equipment Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.ElectricalEquipment   'Electrical Equipment
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Electrical Equipment Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.InstrumentsCable   'Instruments Cables
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                My.User.Name & " Has Upload Instrument Cables Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.ElectricalCables    'Electrical Cables
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Electrical Cables Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.Motors    'Motors
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Motors Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.JunctionBox 'Junction Box
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Instruments JBs Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.MaterialsArrivals    'Materials Arrivals
                    DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [arrival_date] = null where [arrival_date]='1/1/1900'")
                    DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [Forescasted] = null where [Forescasted]='1/1/1900'")
                    DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [type] = null where [type]=''")
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Material Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.SubSystem    'Subsystem

                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Subsystem Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.System    'System

                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload System Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.Instruments    'INSTRUMENTS

                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Instruments Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.LOOPS    'lOOPS
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Loop Data','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.EleDrum    'El Drum
                    DB.ExcuteNoneResult("update [tblDrums] set length=eng_length where eng_length >0 and Drum_ID not in (select drum_id from tblDrumLog)")
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                         My.User.Name & " Has Upload Electrical Drum','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.InsDrum    'ins Drum
                    DB.ExcuteNoneResult("update [tblDrums] set length=eng_length where eng_length >0 and Drum_ID not in (select drum_id from tblDrumLog)")
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                         My.User.Name & " Has Upload Instrument Drum','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.ILD    'ILD
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                         My.User.Name & " Has Upload ILDs','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.Block
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                       My.User.Name & " Has Upload Block','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.P6Activity
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                       My.User.Name & " Has Upload P6 Activities','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
                Case e_DataType.MiscItems
                    DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                      My.User.Name & " Has Upload Misc Items','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Engineering')")
            End Select
            DB.ExcuteNoneResult("update [tblTMP] set [bad_values]=1 where [tmp_id]=1")
            WatchDogRelease()
            UpdateP6()
            RaiseEvent UploadFinish()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub


    Public Sub ChcekData(ByRef DataFromExcel As DataTable, ByVal UploadDataType As e_DataType, ByRef Results As String)
        Dim inx As Integer = 0
        Results = ""

        Select Case UploadDataType

            'Area----------------------------------------------------------
            Case e_DataType.Area
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult(String.Format("select [{0}] From Area where [{0}]='{1}'", DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Projects-----------------------------------------------------------
            Case e_DataType.Projects
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult(String.Format("select [{0}] From tblProject where [{0}]='{1}'", DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Sequence-----------------------------------------------------------
            Case e_DataType.Sequence
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult(String.Format("select [{0}] From Sequence where [{0}]='{1}'", DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Intool-----------------------------------------------------------
            Case e_DataType.InTools
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult(String.Format("select [{0}] From tblInTool where [{0}]='{1}'", DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Electrical Tray -----------------------------------------------------------
            Case e_DataType.ElectricalCableTray
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblEleCableTray where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Cache Material -----------------------------------------------------------
            Case e_DataType.CacheMaterial
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblCacheMatComp where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Groups -----------------------------------------------------------
            Case e_DataType.Groups
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblGroups where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Instrument Cable Tray -----------------------------------------------------------
            Case e_DataType.InstrumentCableTray
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblInsCableTray where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Lighting Fixtures -----------------------------------------------------------
            Case e_DataType.LightingFixture
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblLightingFixture where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'P6 Activity-----------------------------------------------------------
            Case e_DataType.P6Activity
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblP6Activity where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Electrical JB-----------------------------------------------------------
            Case e_DataType.ElectricalJB
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblEleJunctionBox where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Instrument Equipment-----------------------------------------------------------
            Case e_DataType.ElectricalEquipment
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblInsEquipment where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================
                'Electrical Equipment-----------------------------------------------------------
            Case e_DataType.ElectricalEquipment
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblElectricalEquipment where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Electrical Cables-----------------------------------------------------------
            Case e_DataType.ElectricalCables
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblelecablelist where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
            '================================================================================

            'Motors-----------------------------------------------------------
            Case e_DataType.Motors
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblMotor where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
            '================================================================================

            'Junction Box-----------------------------------------------------------
            Case e_DataType.JunctionBox
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From junctionbox where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Mat Comp-----------------------------------------------------------
            Case e_DataType.MaterialsArrivals
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult(String.Format("select [{0}] From tblArrivalMatComp where [{1}]='{2}'", DataFromExcel.Columns(0).ColumnName, DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'Instruments Cable-----------------------------------------------------------
            Case e_DataType.InstrumentsCable
                For inx = 0 To DataFromExcel.Rows.Count - 1

                    '********************** Enable this for working on the Original table
                    'If DB.ExcutResult("select " & DataFromExcel.Columns(0).ColumnName & " From tblInsCableList where " & DataFromExcel.Columns(0).ColumnName & "='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                    'Results &= DB.ExcutResult("select " & DataFromExcel.Columns(0).ColumnName & " From tblInsCableList where " & DataFromExcel.Columns(0).ColumnName & "='" & DataFromExcel.Rows(inx).Item(0) & "'") & vbCrLf
                    '*****************************************************************************

                    '********************** Enable this for working on the Edited table
                    If DB.ExcutResult(String.Format("select [{0}] From tblInsCableList where [{1}]='{2}'", DataFromExcel.Columns(0).ColumnName, DataFromExcel.Columns(0).ColumnName, DataFromExcel.Rows(inx).Item(0))) = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                        '*****************************************************************************


                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
            '================================================================================

            'Subsystem-----------------------------------------------------------
            Case e_DataType.SubSystem
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From [Subsystem] where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

                'System-----------------------------------------------------------
            Case e_DataType.System
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From [Systems] where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================
            Case e_DataType.TestPacks
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tbltestpack where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================
            Case e_DataType.Instruments
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From tblInstruments where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================

            Case e_DataType.LOOPS
                For inx = 0 To DataFromExcel.Rows.Count - 1
                    If DB.ExcutResult("select [" & DataFromExcel.Columns(0).ColumnName & "] From [tblInsLoop] where [" & DataFromExcel.Columns(0).ColumnName & "]='" & DataFromExcel.Rows(inx).Item(0) & "'") = "" Then
                        Results &= DataFromExcel.Rows(inx).Item(0) & vbCrLf
                    End If
                    Application.DoEvents()
                    RaiseEvent ProgressDataCount(inx + 1)
                Next
                '================================================================================
        End Select

        RaiseEvent CheckFinish()
    End Sub

    Public Function FixBorkeTag(ByVal Tag As String) As String
        If IsDate(Tag) Then Return Tag
        Dim ss As New EAMS.StringFunctions.StringsFunction
        Return ss.RemoveString(ss.RemoveString(ss.RemoveString(Tag, EAMS.StringFunctions.StringsFunction.enChars.HelpChar), EAMS.StringFunctions.StringsFunction.enChars.LowerChar), EAMS.StringFunctions.StringsFunction.enChars.Space)
    End Function


    Public Sub BuildInsKitRelation()
        Try
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\BuildInsKit.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                DB.ExcuteNoneResult(temp(inx))
            Next
            RaiseEvent InsKitLinked()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Public Sub OverrideMaterial()
        Try
            Dim sql As String = ""
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\Override_Mat.txt")
            sql = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult(sql, 180)
            RaiseEvent OverrideMaterialsUpdated()
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

            DB.ExcuteNoneResult("exec spLMJC")
            DB.ExcuteNoneResult(obj.ReadToEnd, 180)
            obj.Close()
            DB.ExcuteNoneResult(obj3.ReadToEnd, 180)
            obj3.Close()
            If _LoopConsReleasedQCBacklog = 1 Then
                DB.ExcuteNoneResult(obj2.ReadToEnd, 180)
            End If
            obj2.Close()
            DB.ExcuteNoneResult(obj4.ReadToEnd, 180)
            obj4.Close()
            DB.ExcuteNoneResult(obj7.ReadToEnd, 180)
            obj7.Close()
            DB.ExcuteNoneResult(obj6.ReadToEnd, 180)
            obj6.Close()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub UpdateLoopConsFinishedBacklog()
        Try
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopConstrFinishedBL.txt")
            DB.ExcuteNoneResult(obj.ReadToEnd, 180)
            obj.Close()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub UpdateMaterialArrival()
        Try
            DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [arrival_date] = null where [arrival_date]='1/1/1900'")
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\Update_Mat_Arriv.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                DB.ExcuteNoneResult(temp(inx))
            Next
            DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" & _
                       My.User.Name & " Has Loaded Material','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Material')")
            DB.ExcuteNoneResult("update [tblTMP] set [Production_Updated] ='True' where [tmp_id]=1")
            RaiseEvent MaterialsUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub UpdateMaterialForeCast()
        Try
            DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [Forescasted] = null where [Forescasted]='1/1/1900'")
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\Update_Mat_ForeCast.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                If Trim(temp(inx)) <> "" Then DB.ExcuteNoneResult(temp(inx))
            Next
            RaiseEvent ForeCastUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Public Sub UpdatetblInstrumentsTP()
        Try
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateEICA_PCA.txt")
            DB.ExcuteNoneResult(Replace(Replace(obj.ReadToEnd, "EICADBXXXX", DB.DataBaseName), "PCADBXXXX", PCADBName))
            obj.Close()
            RaiseEvent InstrumentsWithTPUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub UpdatetblInstrumentsEQ()
        Try
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateEICA_PCA_EQ.txt")
            DB.ExcuteNoneResult(DB.ExcuteNoneResult(Replace(Replace(obj.ReadToEnd, "EICADBXXXX", DB.DataBaseName), "PCADBXXXX", PCADBName)), 0)
            obj.Close()
            RaiseEvent InstrumentsWithEQUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub


    Public Sub UpdateEICA_With_PCS(ByVal _PCSServer As String, ByVal _PCSDB As String)
        Dim PCSDB As New EAMS.DataBaseTools.SQLServerTools() With {.DataBaseLocation = _PCSServer, .DataBaseName = _PCSDB}
        Dim dt As New DataTable
        dt = DB.ReturnDataTable("")
        Try
            PCSDB.Connect()

        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try


    End Sub
    Public Sub UpdateP6Scope(ByVal PCSDBName As String, ByVal BaseLine As String)
        Try
            'DB.ExcuteNoneResult("UPDATE [tblActIDS] SET EICA_Budget=0,EICA_Done=0")
            Dim temp As String
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\EICAPCSU.dll")
            temp = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult(Replace(Replace(Replace(temp, "PCSXXXX", PCSDBName), "BASEXXXX", BaseLine), "EICAXXXX", DB.DataBaseName))
            '
            Dim dt As New DataTable, done As Double = 0
            dt = DB.ReturnDataTable(Replace(Replace(Replace(My.Resources.PCSDone, "PCSXXX", PCSDBName), "EICAxxx", DB.DataBaseName), "Basexxx", BaseLine))
            For Each r As DataRow In dt.Rows
                done = 0
                For iny As Integer = 0 To dt.Columns.Count - 1
                    If dt.Columns.Item(iny).ColumnName.Length = 10 Then
                        done += r(dt.Columns.Item(iny).ColumnName)
                    End If
                Next
                DB.ExcuteNoneResult(String.Format("update tblActIDS set PCSDone={0} where ActID ='{1}'", done, r("actid")))
            Next
            '
            DB.ExcuteNoneResult("update tblActIDS set PCS_Area =replace(PCS_Area,' ','')")
            DB.ExcuteNoneResult("update tblActIDS set EICA_Area =replace(EICA_Area,' ','')")
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub UpdateP6ScopeSubcontractor(ByVal PCSDBName As String, ByVal BaseLine As String)
        Try
            'DB.ExcuteNoneResult("UPDATE [tblActIDS] SET EICA_Budget=0,EICA_Done=0")
            Dim temp As String
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\EICAPCSU_Sub.dll")
            temp = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult(Replace(Replace(Replace(temp, "PCSXXXX", PCSDBName), "BASEXXXX", BaseLine), "EICAXXXX", DB.DataBaseName))
            '
            Dim dt As New DataTable, done As Double = 0
            dt = DB.ReturnDataTable(Replace(Replace(Replace(My.Resources.PCSDone, "PCSXXX", PCSDBName), "EICAxxx", DB.DataBaseName), "Basexxx", BaseLine))
            For Each r As DataRow In dt.Rows
                done = 0
                For iny As Integer = 0 To dt.Columns.Count - 1
                    If dt.Columns.Item(iny).ColumnName.Length = 10 Then
                        done += r(dt.Columns.Item(iny).ColumnName)
                    End If
                Next
                DB.ExcuteNoneResult(String.Format("update tblActIDS set PCSDone={0} where ActID ='{1}'", done, r("actid")))
            Next
            '
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub
    Public Sub UpdateP6()
        Try
            Dim temp As String
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateP6.txt")
            temp = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult("update tblActIDS set EICA_Budget=0,EICA_Done=0")
            DB.ExcuteNoneResult(temp)
            RaiseEvent InstrumentsWithTPUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub UpdateInsInstallationMissing()
        Try
            Dim temp As String
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateInsInstallationMissing.txt")
            temp = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult(temp)
            RaiseEvent InstrumentsWithTPUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Function OldPlanningForecastDate() As Boolean
        If DB.ExcutResult(My.Resources.OldPlanningForecast) <> "" Then
            Return True
        End If
        Return False
    End Function
    Public Function ReceivedWithNoStatus() As Boolean
        If DB.ExcutResultFromFile(Application.StartupPath & "\sqries\ReceivedNoStatus.txt") <> "" Then
            Return True
        End If
        Return False
    End Function
    Public Function InstalledWithForwardForecast() As Boolean
        If DB.ExcutResultFromFile(Application.StartupPath & "\sqries\InstalledWithForwardForecast.txt") <> "" Then
            Return True
        End If
        Return False
    End Function

    Public Sub FixDataTable()
        Dim q As String = ""
        Dim dtIns As New DataTable
        Dim dtJB As New DataTable
        Dim dtIC As New DataTable
        Dim dtEC As New DataTable
        Dim dtLP As New DataTable
        Dim dtEE As New DataTable
        Dim dtIE As New DataTable
        Dim dtEJ As New DataTable
        Dim dtLF As New DataTable
        Dim dtMAT As New DataTable
        Dim dtInsCT As New DataTable
        Dim dtMotor As New DataTable
        Dim dtMiscCable As New DataTable
        Dim iny As Integer = 0
        Dim inx As Integer = 0

        dtInsCT = DB.ReturnDataTable("select top 1 * from tblInsCableTray")
        dtIns = DB.ReturnDataTable("select top 1 * from tblInstruments")
        dtJB = DB.ReturnDataTable("select top 1 * from Junctionbox")
        dtIC = DB.ReturnDataTable("select top 1 * from tblInsCableList")
        dtEC = DB.ReturnDataTable("select top 1 * from tblEleCableList")
        dtMotor = DB.ReturnDataTable("select top 1 * from tblMotor")
        dtLP = DB.ReturnDataTable("select top 1 * from [tblInsLoop]")
        dtEE = DB.ReturnDataTable("select top 1 * from [tblElectricalEquipment]")
        dtIE = DB.ReturnDataTable("select top 1 * from [tblInsEquipment]")
        dtEJ = DB.ReturnDataTable("select top 1 * from [tblEleJunctionBox]")
        dtMiscCable = DB.ReturnDataTable("select top 1 * from [tblMSCCable]")
        dtLF = DB.ReturnDataTable("select top 1 * from [tblLightingFixture]")
        dtMAT = DB.ReturnDataTable("select top 1 * from [tblArrivalMatComp]")

        RaiseEvent ProgressDataCount(dtMotor.Columns.Count + dtMiscCable.Columns.Count + dtIns.Columns.Count + dtJB.Columns.Count + dtIC.Columns.Count + dtEC.Columns.Count + dtLP.Columns.Count + dtEE.Columns.Count + dtIE.Columns.Count + dtEJ.Columns.Count + dtLF.Columns.Count + dtMAT.Columns.Count + dtInsCT.Columns.Count)



        For inx = 0 To dtMiscCable.Columns.Count - 1  'Misc Cable
            Select Case dtMiscCable.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblMSCCable set [" & dtMiscCable.Columns(inx).ColumnName & "] = null where [" & dtMiscCable.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblMSCCable set [" & dtMiscCable.Columns(inx).ColumnName & "] = null where [" & dtMiscCable.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblMSCCable set [" & dtMiscCable.Columns(inx).ColumnName & "] = null where [" & dtMiscCable.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblMSCCable set [" & dtMiscCable.Columns(inx).ColumnName & "] = null where [" & dtMiscCable.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.LightingCables)

        For inx = 0 To dtMotor.Columns.Count - 1  'Motor
            Select Case dtMotor.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblMotor set [" & dtMotor.Columns(inx).ColumnName & "] = null where [" & dtMotor.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblMotor set [" & dtMotor.Columns(inx).ColumnName & "] = null where [" & dtMotor.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblMotor set [" & dtMotor.Columns(inx).ColumnName & "] = null where [" & dtMotor.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblMotor set [" & dtMotor.Columns(inx).ColumnName & "] = null where [" & dtMotor.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.Motors)

        For inx = 0 To dtInsCT.Columns.Count - 1  'Instrument Cable Tray
            Select Case dtInsCT.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblInsCableTray set [" & dtInsCT.Columns(inx).ColumnName & "] = null where [" & dtInsCT.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsCableTray set [" & dtInsCT.Columns(inx).ColumnName & "] = null where [" & dtInsCT.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsCableTray set [" & dtInsCT.Columns(inx).ColumnName & "] = null where [" & dtInsCT.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblInsCableTray set [" & dtInsCT.Columns(inx).ColumnName & "] = null where [" & dtInsCT.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.InstrumentCableTray)

        For inx = 0 To dtEJ.Columns.Count - 1  'Ins Equipment
            Select Case dtEJ.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblEleJunctionBox set [" & dtEJ.Columns(inx).ColumnName & "] = null where [" & dtEJ.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblEleJunctionBox set [" & dtEJ.Columns(inx).ColumnName & "] = null where [" & dtEJ.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblEleJunctionBox set [" & dtEJ.Columns(inx).ColumnName & "] = null where [" & dtEJ.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblEleJunctionBox set [" & dtEJ.Columns(inx).ColumnName & "] = null where [" & dtEJ.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.ElectricalJB)

        For inx = 0 To dtIE.Columns.Count - 1  'Ins Equipment
            Select Case dtIE.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblInsEquipment set [" & dtIE.Columns(inx).ColumnName & "] = null where [" & dtIE.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsEquipment set [" & dtIE.Columns(inx).ColumnName & "] = null where [" & dtIE.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsEquipment set [" & dtIE.Columns(inx).ColumnName & "] = null where [" & dtIE.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblInsEquipment set [" & dtIE.Columns(inx).ColumnName & "] = null where [" & dtIE.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.InstrumentEquipment)

        For inx = 0 To dtIns.Columns.Count - 1  'tblInstruments
            Select Case dtIns.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblInstruments set [" & dtIns.Columns(inx).ColumnName & "] = null where [" & dtIns.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInstruments set [" & dtIns.Columns(inx).ColumnName & "] = null where [" & dtIns.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInstruments set [" & dtIns.Columns(inx).ColumnName & "] = null where [" & dtIns.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblInstruments set [" & dtIns.Columns(inx).ColumnName & "] = null where [" & dtIns.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.Instruments)

        For inx = 0 To dtJB.Columns.Count - 1  'Junctionbox
            Select Case dtJB.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update Junctionbox set [" & dtJB.Columns(inx).ColumnName & "] = null where [" & dtJB.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update Junctionbox set [" & dtJB.Columns(inx).ColumnName & "] = null where [" & dtJB.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update Junctionbox set [" & dtJB.Columns(inx).ColumnName & "] = null where [" & dtJB.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update Junctionbox set [" & dtJB.Columns(inx).ColumnName & "] = null where [" & dtJB.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.JunctionBox)

        For inx = 0 To dtIC.Columns.Count - 1  'Instruments Cable
            Select Case dtIC.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblInsCableList set [" & dtIC.Columns(inx).ColumnName & "] = null where [" & dtIC.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsCableList set [" & dtIC.Columns(inx).ColumnName & "] = null where [" & dtIC.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsCableList set [" & dtIC.Columns(inx).ColumnName & "] = null where [" & dtIC.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblInsCableList set [" & dtIC.Columns(inx).ColumnName & "] = null where [" & dtIC.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.InstrumentsCable)

        For inx = 0 To dtEC.Columns.Count - 1  'tblEleCableList
            Select Case dtEC.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblEleCableList set [" & dtEC.Columns(inx).ColumnName & "] = null where [" & dtEC.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblEleCableList set [" & dtEC.Columns(inx).ColumnName & "] = null where [" & dtEC.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblEleCableList set [" & dtEC.Columns(inx).ColumnName & "] = null where [" & dtEC.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblEleCableList set [" & dtEC.Columns(inx).ColumnName & "] = null where [" & dtEC.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.ElectricalCables)

        For inx = 0 To dtLP.Columns.Count - 1  'Loops
            Select Case dtLP.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblInsLoop set [" & dtLP.Columns(inx).ColumnName & "] = null where [" & dtLP.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsLoop set [" & dtLP.Columns(inx).ColumnName & "] = null where [" & dtLP.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblInsLoop set [" & dtLP.Columns(inx).ColumnName & "] = null where [" & dtLP.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblInsLoop set [" & dtLP.Columns(inx).ColumnName & "] = null where [" & dtLP.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.LOOPS)

        For inx = 0 To dtEE.Columns.Count - 1  'Electrical Equipment
            Select Case dtEE.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblElectricalEquipment set [" & dtEE.Columns(inx).ColumnName & "] = null where [" & dtEE.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblElectricalEquipment set [" & dtEE.Columns(inx).ColumnName & "] = null where [" & dtEE.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblElectricalEquipment set [" & dtEE.Columns(inx).ColumnName & "] = null where [" & dtEE.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblElectricalEquipment set [" & dtEE.Columns(inx).ColumnName & "] = null where [" & dtEE.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.ElectricalEquipment)

        For inx = 0 To dtLF.Columns.Count - 1  'Lighting Fixtures
            Select Case dtLF.Columns(inx).DataType.FullName
                Case "System.String"
                    q = "update tblLightingFixture set [" & dtLF.Columns(inx).ColumnName & "] = null where [" & dtLF.Columns(inx).ColumnName & "] =' '"
                    DB.ExcuteNoneResult(q)
                    q = "update tblLightingFixture set [" & dtLF.Columns(inx).ColumnName & "] = null where [" & dtLF.Columns(inx).ColumnName & "] =''"
                    DB.ExcuteNoneResult(q)
                    q = "update tblLightingFixture set [" & dtLF.Columns(inx).ColumnName & "] = null where [" & dtLF.Columns(inx).ColumnName & "] ='null'"
                    DB.ExcuteNoneResult(q)
                Case "System.DateTime"
                    q = "update tblLightingFixture set [" & dtLF.Columns(inx).ColumnName & "] = null where [" & dtLF.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.LightingFixture)

        DB.ExcuteNoneResult("delete from tblArrivalMatComp where tag =''")
        DB.ExcuteNoneResult("delete from tblArrivalMatComp where tag ='---'")
        For inx = 0 To dtMAT.Columns.Count - 1  'Materials
            Select Case dtMAT.Columns(inx).DataType.FullName
                Case "System.String"
                    If dtMAT.Columns(inx).ColumnName <> "Description" Then
                        q = "update tblArrivalMatComp set [" & dtMAT.Columns(inx).ColumnName & "] = null where [" & dtMAT.Columns(inx).ColumnName & "] =' '"
                        DB.ExcuteNoneResult(q)
                        q = "update tblArrivalMatComp set [" & dtMAT.Columns(inx).ColumnName & "] = null where [" & dtMAT.Columns(inx).ColumnName & "] =''"
                        DB.ExcuteNoneResult(q)
                        q = "update tblArrivalMatComp set [" & dtMAT.Columns(inx).ColumnName & "] = null where [" & dtMAT.Columns(inx).ColumnName & "] ='null'"
                        DB.ExcuteNoneResult(q)
                    End If
                Case "System.DateTime"
                    q = "update tblArrivalMatComp set [" & dtMAT.Columns(inx).ColumnName & "] = null where [" & dtMAT.Columns(inx).ColumnName & "] <='1/1/2000'"
                    DB.ExcuteNoneResult(q)
            End Select
            iny += 1
            Application.DoEvents()
            RaiseEvent ProgressIndex(iny)
        Next
        RaiseEvent Fixed(e_DataType.MaterialsArrivals)
        DB.ExcuteNoneResult("update [tblTMP] set [bad_values]=0 where [tmp_id]=1")
        FixProgressNoActual()
        RaiseEvent Fixed(e_DataType.NoActualLength)
        RaiseEvent CheckFinish()
    End Sub

    Private Sub CreateAllLoopsView()
        Dim sql As String = "", tmp() As String, inx As Byte = 0
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\CreateAllLoops.txt")
        sql = obj.ReadToEnd
        obj.Close()
        tmp = Split(sql, "go")
        For inx = 0 To tmp.Length - 1
            DB.ExcuteNoneResult(tmp(inx))
        Next
    End Sub


    Public Sub ClearLoopQCComments()
        DB.ExcuteNoneResult("update tblinsloop set TR_Loop_Folder_QC_Release_Remarks = null")
    End Sub

    Public Sub GeneratePLCPackageLoopType()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopPLCPackage.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
    End Sub

    Public Sub UpdateP6WithActualData()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdteP6.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
        RaiseEvent P6Updated()
    End Sub

    Public Function PulledwithNoActualLength() As Boolean
        If DB.ExcutResultFromFile(Application.StartupPath & "\sqries\PulledAndNoActualLength.txt") <> "" Then
            Return True
        End If
        Return False
    End Function

    Public Function PCSMismatch() As Boolean
        If DB.ExcutResultFromFile(Application.StartupPath & "\sqries\PCSCHK.txt") <> "" Then
            Return True
        End If
        Return False
    End Function
    Public Function ProgressNoReceive() As Boolean
        If DB.ExcutResultFromFile(Application.StartupPath & "\sqries\ProgressAndNoReceive.txt") <> "" Then
            Return True
        End If
        Return False
    End Function

    Public Function MissingProduction() As Boolean
        If DB.ExcutResultFromFile(Application.StartupPath & "\sqries\FixMissingProduction.txt") <> "" Then
            Return True
        End If
        Return False
    End Function

    Public Sub FixReceivedNoStatus()
        DB.ExcuteNoneResult("update tblElectricalEquipment set status ='Restricted' where Arrived_Date is not null and Status is null")
        DB.ExcuteNoneResult("update tblInsEquipment set status ='Restricted' where Arrived_Date is not null and Status is null")
    End Sub
    Public Sub FixProgressNoReceive()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\fixProgressAndNoReceive.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
        WatchDogRelease()
        RaiseEvent MaterialsUpdated()
    End Sub

    Public Sub FixProgressNoActual()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\FixPulledAndNoActualLength.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
        WatchDogRelease()
    End Sub

    Public Sub CopyRealProgressToVirtual()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\FixVirtualProgress.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
    End Sub

    Public Sub UpdateLoopDone()
        Try
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateLoopDone.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                DB.ExcuteNoneResult(temp(inx))
            Next
            RaiseEvent LoopsUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub

    Public Sub UpdateTestPackFrom_PCA()
        Dim dt As New DataTable, inx As Integer = 0
        Dim Sql As String = ""
        dt = DB.ReturnDataTable("USE TRPCA Select HTP, readyforPT as TestDate,Flushing as FlushingDate,reinst as ReInstatement from HTP where active=1 USE TREICA")
        RaiseEvent ProgressDataCount(dt.Rows.Count)
        For inx = 0 To dt.Rows.Count - 1
            Sql = "Update tblTestPack set Test_Done='" & dt.Rows(inx).Item("TestDate") & "',Flushing_date='" & dt.Rows(inx).Item("FlushingDate") & "',ReInstatement ='" & dt.Rows(inx).Item("ReInstatement") & "'" & _
                    " where tp_name='" & dt.Rows(inx).Item("HTP") & "'"
            DB.ExcuteNoneResult(Sql)
            Application.DoEvents()
            RaiseEvent ProgressIndex(inx + 1)
        Next
        If _PCAUpdate = -1 Then UpdatetblInstrumentsTP()
        Sql = "update tblTestPack set [Test_Done] = null where [Test_Done] <='1/1/2010'"
        DB.ExcuteNoneResult(Sql)
        Sql = "update tblTestPack set [Flushing_date] = null where [Flushing_date] <='1/1/2010'"
        DB.ExcuteNoneResult(Sql)
        Sql = "update tblTestPack set [ReInstatement] = null where [ReInstatement] <='1/1/2010'"
        DB.ExcuteNoneResult(Sql)
        '
        Sql = "update tblInstruments set [Hidro_test_date] = null where [Hidro_test_date] <='1/1/2010'"
        DB.ExcuteNoneResult(Sql)
        Sql = "update tblInstruments set [flushing_date] = null where [flushing_date] <='1/1/2010'"
        DB.ExcuteNoneResult(Sql)
        Sql = "update tblInstruments set [Final_Installed_Date] = null where [Final_Installed_Date] <='1/1/2010'"
        DB.ExcuteNoneResult(Sql)
        RaiseEvent UpdateProgressComplete()
    End Sub

    Public Sub UpdateVendorInsInstallation_PCA()
        Dim dt As New DataTable, inx As Integer = 0
        Dim Sql As String = ""
        dt = DB.ReturnDataTable("USE TRPCA Select Equipment,ArrivedDate,ErectedDate from equipment where active=1 and PackageNo not like '%Elec%' and PackageNo not like '%Inst%' USE TREICA")
        RaiseEvent ProgressDataCount(dt.Rows.Count)
        For inx = 0 To dt.Rows.Count - 1
            Sql = "Update tblInstruments set Warning='" & "Equipment has been installed" & "'" & _
                    " where Equipment_Name='" & dt.Rows(inx).Item("Equipment") & "' and Furnished_By in ('VENDOR','VENDOR NOT WIRING')"
            DB.ExcuteNoneResult(Sql)
            Application.DoEvents()
            RaiseEvent ProgressIndex(inx + 1)
        Next
        RaiseEvent UpdateProgressComplete()
    End Sub



    Public Sub WatchDogRelease()
        'Dim dt As New DataTable, inx As Integer = 0
        'dt = DB.ReturnDataTable("select * from watch_dog")
        'For inx = 0 To dt.Rows.Count - 1
        'Select Case dt.Rows(inx).Item("tag_type").ToString
        '   Case "Instruments"
        'Select Case dt.Rows(inx).Item("ms").ToString
        '   Case "Received"
        'If DB.ExcutResult("select Received_Date from tblInstruments where instrument_tag='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Calibrated"
        'If DB.ExcutResult("select Calibration_Date from tblInstruments where instrument_tag='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Installed"
        'If DB.ExcutResult("select Installation_Date from tblInstruments where instrument_tag='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Hook Up"
        'If DB.ExcutResult("select HookUp_Date from tblInstruments where instrument_tag='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        'End Select
        '   Case "Instrument Cables"
        'Select Case dt.Rows(inx).Item("ms").ToString
        '   Case "Received"
        'If DB.ExcutResult("select IC_Proc_Arrival_AtSite_Actual from tblInsCableList where ic_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Pulled"
        'If DB.ExcutResult("select IC_Plan_Pulled_Date from tblInsCableList where ic_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Con End 1"
        'If DB.ExcutResult("select IC_Plan_Connected_Date_From from tblInsCableList where ic_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Con End 2"
        'If DB.ExcutResult("select IC_Plan_Connected_Date_TO from tblInsCableList where ic_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        'End Select
        'Case "Electrical Cables"
        'Select Case dt.Rows(inx).Item("ms").ToString
        '   Case "Received"
        'If DB.ExcutResult("select EC_Proc_Arrival_AtSite_Actual from tblEleCableList where ec_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Pulled"
        'If DB.ExcutResult("select EC_Plan_Pulled_Date from tblEleCableList where ec_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        'Case "Con End 1"
        'If DB.ExcutResult("select EC_Plan_Connected_Date_From from tblEleCableList where ec_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Con End 2"
        'If DB.ExcutResult("select EC_Plan_Connected_Date_To from tblEleCableList where ec_id='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        'End Select
        '   Case "Junction Box"
        'Select Case dt.Rows(inx).Item("ms").ToString
        '   Case "Received"
        'If DB.ExcutResult("select JI_ArriveSite from junctionbox where junctionbox='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        '   Case "Installed"
        'If DB.ExcutResult("select JI_Installed from junctionbox where junctionbox='" & dt.Rows(inx).Item("tag").ToString & "'") <> "" Then
        'DB.ExcutResult("update watch_dog set catched=1,catched_date=getdate() where catched =0 and tbl_id=" & dt.Rows(inx).Item("tbl_id"))
        'End If
        'End Select
        'End Select
        'Next
    End Sub

    Public Sub BuildInstrumentRelation()
        Dim lst As New ListBox, tmp() As String, inx As Integer
        DB.Fill(lst, "select instrument_tag from tblInstruments where instrument_tag like '%TI%' or instrument_tag like '%TW%' or instrument_tag like '%LT%' OR instrument_tag like '%PV%' OR instrument_tag like '%PDI%'" & _
                " or instrument_tag like '%TT%' or instrument_tag like '%TIT%' or instrument_tag like '%PI%' or instrument_tag like '%VI%' or instrument_tag like '%VT%'")
        RaiseEvent ProgressDataCount(lst.Items.Count)
        For inx = 0 To lst.Items.Count - 1
            tmp = Split(lst.Items.Item(inx), "-")
            Select Case tmp(1)

                Case "TI"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-TT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-TT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    ElseIf DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-TIT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-TIT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If

                Case "FE"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-FIT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-FIT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "TW"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-TT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-TT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    ElseIf DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-TIT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-TIT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "PDI"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-PI-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-PI-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "PV"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-PY-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-PY-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "TT"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-TE-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-TE-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "TIT"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-TE-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-TE-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "PI"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-PT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-PT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "VI"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-VT-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-VT-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
                Case "VT"
                    If DB.ExcutResult("select instrument_tag from tblInstruments where instrument_tag='" & tmp(0) & "-VE-" & tmp(2) & "'") <> "" Then
                        DB.ExcuteNoneResult("update tblInstruments set Main_Devise='" & tmp(0) & "-VE-" & tmp(2) & "' where instrument_tag ='" & lst.Items.Item(inx) & "'")
                    End If
            End Select
            Application.DoEvents()
            RaiseEvent ProgressIndex(inx + 1)
        Next
        If _UpdateSlaveDevise = 1 Then UpdateSlaveDevise()
        RaiseEvent UpdateProgressComplete()
    End Sub

    Public Sub UpdateQAQCEICA()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\updateqcreleased.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
    End Sub

    Public Sub UpdateInsLoopwithILD()
        Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateInsLoopwithILD.txt")
        Dim Sql As String = obj.ReadToEnd
        obj.Close()
        DB.ExcuteNoneResult(Sql)
    End Sub

    Public Sub DownloadsDgns()
        Try
            Dim lst As New ListBox
            DB.Fill(lst, "select area from area where dgn is not null order by area")
            Dim bf() As Byte
            Dim x As Integer = 0
            Dim ost As System.IO.FileStream

            For x = 0 To lst.Items.Count - 1
                DB.GetImageByte(bf, String.Format("select dgn from area where area ='{0}'", lst.Items.Item(x).ToString))
                ost = New System.IO.FileStream(String.Format("{0}\tmp\hach\{1} {2}.dgn", Application.StartupPath, x, lst.Items.Item(x)), IO.FileMode.Create)
                ost.Write(bf, 0, bf.Length)
                ost.Close()
                Application.DoEvents()
            Next
            RaiseEvent DGNDownloaded()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Function CheckUploadingForProjectUnit(ByRef DT As DataTable) As String
        Dim tmp As String = ""
        For inx As Integer = 0 To DT.Columns.Count - 1
            If DT.Columns(inx).ColumnName.ToLower = "projectid" Then
                Dim dv As New DataView(DT)
                Dim dtTemp As New DataTable
                dtTemp = dv.ToTable(True, "projectid")
                For Each dr As DataRow In dtTemp.Rows
                    If DB.ExcutResult(String.Format("select ProjectID from tblProject WITH (NOLOCK) where ProjectID ='{0}'", dr.Item("ProjectId"))) = "" Then
                        tmp &= String.Format("Unknown Project: {0}{1}", dr.Item("ProjectId"), vbCrLf)
                    End If
                Next
            End If
            If DT.Columns(inx).ColumnName.ToLower = "unit" Then
                Dim dv As New DataView(DT)
                Dim dtTemp As New DataTable
                dtTemp = dv.ToTable(True, "unit")
                For Each dr As DataRow In dtTemp.Rows
                    If DB.ExcutResult(String.Format("select Unit from Unit WITH (NOLOCK) where Unit ='{0}'", dr.Item("Unit"))) = "" Then
                        tmp &= String.Format("Unknown Unit: {0}{1}", dr.Item("Unit"), vbCrLf)
                    End If
                Next
            End If
            If DT.Columns(inx).ColumnName.ToLower = "location" Then
                Dim dv As New DataView(DT)
                Dim dtTemp As New DataTable
                dtTemp = dv.ToTable(True, "location")
                For Each dr As DataRow In dtTemp.Rows
                    If Not IsDBNull(dr.Item("location")) Then
                        If DB.ExcutResult(String.Format("select Area from Area WITH (NOLOCK) where Area ='{0}'", dr.Item("location"))) = "" Then
                            tmp &= String.Format("Unknown Area/Location: {0}{1}", dr.Item("location"), vbCrLf)
                        End If
                    End If
                Next
            End If
            If DT.Columns(inx).ColumnName.ToLower = "area" Then
                Dim dv As New DataView(DT)
                Dim dtTemp As New DataTable
                dtTemp = dv.ToTable(True, "area")
                For Each dr As DataRow In dtTemp.Rows
                    If Not IsDBNull(dr.Item("area")) Then
                        If DB.ExcutResult(String.Format("select Area from Area WITH (NOLOCK) where Area ='{0}'", dr.Item("area"))) = "" Then
                            tmp &= String.Format("Unknown Area/Location: {0}{1}", dr.Item("area"), vbCrLf)
                        End If
                    End If
                Next
            End If
        Next
        Return tmp
    End Function

    Public Sub CleanCableDrum(ByVal Discipline As String)
        Select Case Discipline
            Case "Electrical"
                DB.ExcuteNoneResult("delete * from tblEleCableDrum")
            Case "Instrument"
                DB.ExcuteNoneResult("delete * from tblInsCableDrum")
        End Select
    End Sub
    Public Sub CheckL4(ByRef EICAP6 As DataTable, ByRef DataFromExcel As DataTable, ByVal OutputPath As String, ByRef Results As Text.StringBuilder)
        Dim dr As DataRow()
        For inx As Integer = 0 To DataFromExcel.Rows.Count - 1
            If Not IsDBNull(DataFromExcel.Rows(inx).Item(2)) Then
                dr = EICAP6.Select(String.Format("[ActID]='{0}'", DataFromExcel.Rows(inx).Item(2)))
                If dr.Count <> 0 Then
                    '("ActivityID;Activity Name;Level4 Scope;Level4 Done;EICA Scope;EICA Done")
                    Results.AppendLine(String.Format("{0};{1};{2};{3};{4};{5}", DataFromExcel.Rows(inx).Item(2), DataFromExcel.Rows(inx).Item(3), DataFromExcel.Rows(inx).Item(8), DataFromExcel.Rows(inx).Item(6), dr(0).Item("Scope"), dr(0).Item("Qty Done")))
                End If
            End If
            Application.DoEvents()
            RaiseEvent ProgressIndex(inx + 1)
        Next
    End Sub

    Public Sub ExportReport_Xls(ByVal XlsPath As String, ByVal ReportPath As String, ByRef grd As DataGridView)
        Try
            If grd.RowCount = 0 Then
                RaiseEvent ReportsExported()
                Exit Sub
            End If
            Dim x As New EAMS.OfficeAutomation.Excels
            x.SetRange("A1", grd.Rows.Count + 1, grd.Columns.Count + 1)
            x.SaveBulkDataGrid(grd)
            x.FormateRange(Color.Maroon, Color.White, 9, False, 20, Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter, Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
            x.Save(XlsPath, SheetName)
            x.Close()
            RaiseEvent ReportsExported()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub BuildInsWBS()
        Try
            Dim temp() As String, inx As Integer = 0
            Dim dt As DataTable = DB.ReturnDataTable("select distinct instrument_tag from tblinstruments WITH (NOLOCK) where wbs is null")
            RaiseEvent ProgressDataCount(dt.Rows.Count)
            For inx = 0 To dt.Rows.Count - 1
                temp = Split(dt.Rows(inx).Item(0), "-")
                DB.ExcuteNoneResult(String.Format("update tblinstruments set wbs ='{0}' where instrument_tag ='{1}'", temp(1), dt.Rows(inx).Item(0)))
                Application.DoEvents()
                RaiseEvent ProgressIndex(inx + 1)
            Next
            RaiseEvent InstrumentsUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub CloseEICAWeek()
        UpdateP6()
        DB.ExcuteNoneResult("update [tblActIDS] set [Last_EICABudget]=[EICA_Budget],[Last_EICADone]=[EICA_Done]")
        If DB.ExcutResult("select [validiate_data] from [tblTMP] where [tmp_id]=2") = "" Then
            DB.ExcuteNoneResult("insert into tblTMP (tmp_id,validiate_data) values (2,1)")
        Else
            DB.ExcuteNoneResult("update tblTMP set validiate_data=1 where tmp_id=2")
        End If
    End Sub
End Class