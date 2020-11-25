Public Class Production
    Public Event ProgressIndex(ByVal cnt As Integer)
    Public Event ProgressDataCount(ByVal cnt As Integer)
    Public Event Err(ByVal errmsg As String)
    Private dtP6 As New DataTable
    Private dtP6After As New DataTable
    Public Event ProductionUpdated()
    Private ex As New EAMS.MSOffice.Excel, dt As New DataTable
    Public Event HCSRestoreStatus(ByVal s As String)
    Public Event EICAItemsUpdated()


    Public Sub New()
        AddHandler ex.Err, AddressOf OnErr
    End Sub

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
    End Enum

    Private Sub OnErr(ByVal msg As String)
        RaiseEvent Err(msg)
    End Sub

    Public Sub ProcessLocalBufferProduction(ByRef tv As TreeView)
        tv.Nodes.Clear()
        tv.Nodes.Add("Local Buffer", "Local Buffer", 8, 8)
        tv.ExpandAll()
        Application.DoEvents()
        '04
        tv.Nodes(0).Nodes.Add("Clone Production To EICA", "Clone Production To EICA", 7, 7)
        tv.Nodes(0).Nodes(0).Nodes.Add("Clonning", "Clonning...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        CopyProductionToEICA()
        tv.Nodes(0).Nodes(0).Nodes(0).Text = "Clone Finished"
        tv.Nodes(0).Nodes(0).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '05
        tv.Nodes(0).Nodes.Add("Update EICA", "Update EICA", 0, 0)
        tv.Nodes(0).Nodes(1).Nodes.Add("Updating...", "Updating...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        CleanProTable()
        UpdateEICAPartial()
        UpdateEICA()
        tv.Nodes(0).Nodes(1).Nodes(0).Text = "Updating Finished"
        tv.Nodes(0).Nodes(1).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '06
        tv.Nodes(0).Nodes.Add("Update Activities Status", "Update Activities Status", 0, 0)
        tv.Nodes(0).Nodes(2).Nodes.Add("Updating...", "Updating...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        UpdateP6()
        tv.Nodes(0).Nodes(2).Nodes(0).Text = "Updating Finished"
        tv.Nodes(0).Nodes(2).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '07
        tv.Nodes(0).Nodes.Add("Snapshot Activities Status", "Snapshot Activities Status", 0, 0)
        tv.Nodes(0).Nodes(3).Nodes.Add("Snapshot...", "Snapshot...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        dtP6After = DB.ReturnDataTable("select * from tblActIDS")
        tv.Nodes(0).Nodes(3).Nodes(0).Text = "Snapshot Finished"
        tv.Nodes(0).Nodes(3).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '08 Compare old P6 with new P6
        '------------------------------
        RaiseEvent ProductionUpdated()
    End Sub
    Public Sub StartProduction(ByRef tv As TreeView, ByVal ProDate As Date)
        tv.Nodes.Clear()
        tv.ExpandAll()
        tv.Nodes.Add("0", Format(ProDate, "dddd dd-MMMM-yyyy"), 0, 0)
        tv.ExpandAll()
        Application.DoEvents()
        '01
        tv.Nodes(0).Nodes.Add("1", "Clean Production Tables", 0, 0)
        tv.ExpandAll()
        Application.DoEvents()
        CleanProductionBuffer()
        tv.Nodes(0).Nodes(0).ImageIndex = 2
        Application.DoEvents()
        '02
        tv.Nodes(0).Nodes.Add("2", "Clone EICA Activities Status", 0, 0)
        tv.ExpandAll()
        Application.DoEvents()
        P6Snapshot()
        tv.Nodes(0).Nodes(1).ImageIndex = 2
        Application.DoEvents()
        '03
        'Dim dtSub As New DataTable
        Dim StepCol As New Collection
        StepCol.Add("Folder Preparation")
        StepCol.Add("QC Release")
        StepCol.Add("HCS Folder Ready")
        StepCol.Add("Submitted To Precom")
        StepCol.Add("Loop Done")
        StepCol.Add("Submitted For Certificate")
        StepCol.Add("Final Approval")

        Dim dtItem As New DataTable
        Dim dtfiles As New DataTable

        tv.Nodes(0).Nodes.Add("3", "Import Production File", 0, 0)
        tv.ExpandAll()

        For inStep As Integer = 0 To StepCol.Count - 1
            tv.Nodes(0).Nodes(2).Nodes.Add(StepCol.Item(inStep), StepCol.Item(inStep), 4, 4)
            tv.ExpandAll()
            Application.DoEvents()
            '-----Item
            'dtItem = AccDB.ReturnDataTable(String.Format("select distinct item from v_items where subcontractor ='{0}'", dtSub.Rows(inStep).Item("subcontractor")))
            For inItem As Integer = 0 To dtItem.Rows.Count - 1
                tv.Nodes(0).Nodes(2).Nodes(inStep).Nodes.Add(dtItem.Rows(inItem).Item("item"), dtItem.Rows(inItem).Item("item"), 5, 5)
                tv.ExpandAll()
                Application.DoEvents()
                '---------------Files
                ' dtfiles = AccDB.ReturnDataTable(String.Format("select * from v_items where subcontractor ='{0}' and item ='{1}'", dtSub.Rows(inStep).Item("subcontractor"), dtItem.Rows(inItem).Item("item")))
                For inFile As Integer = 0 To dtfiles.Rows.Count - 1
                    If IO.File.Exists(dtfiles.Rows(inFile).Item("filepath")) Then
                        tv.Nodes(0).Nodes(2).Nodes(inStep).Nodes(inItem).Nodes.Add(dtfiles.Rows(inFile).Item("sheetname"), dtfiles.Rows(inFile).Item("sheetname") & " ...", 3, 3)
                        tv.ExpandAll()
                        Application.DoEvents()
                        UpdateProductionFromNativeFiles(dtfiles.Rows(inFile).Item("filepath"), dtfiles.Rows(inFile).Item("item"), dtfiles.Rows(inFile).Item("sheetname"), tv.Nodes(0).Nodes(2).Nodes(inStep).Nodes(inItem).Nodes.Item(dtfiles.Rows(inFile).Item("sheetname")), ProDate, dtfiles.Rows(inFile).Item("subcontractor"))
                        'Reg Log
                        AccDB.ExcuteNoneResult(String.Format("insert into tblprolog (Log_Date,Item,FilePath,Sub_ID) values ('{0}','{1}','{2}',{3}", ProDate, dtfiles.Rows(inFile).Item("item"), dtfiles.Rows(inFile).Item("FilePath"), dtfiles.Rows(inFile).Item("sub_id")) & ")")
                        '-------------------------------
                    End If
                Next
                '------------------------------------------
            Next
            '---------------------------------------------
        Next

        '04
        tv.Nodes(0).Nodes.Add("Clone Production To EICA", "Clone Production To EICA", 7, 7)
        tv.Nodes(0).Nodes(3).Nodes.Add("Clonning", "Clonning...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        CopyProductionToEICA()
        tv.Nodes(0).Nodes(3).Nodes(0).Text = "Clone Finished"
        tv.Nodes(0).Nodes(3).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '05
        tv.Nodes(0).Nodes.Add("Update EICA", "Update EICA", 0, 0)
        tv.Nodes(0).Nodes(4).Nodes.Add("Updating...", "Updating...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        CleanProTable
        UpdateEICAPartial()
        UpdateEICA()
        tv.Nodes(0).Nodes(4).Nodes(0).Text = "Updating Finished"
        tv.Nodes(0).Nodes(4).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '06
        tv.Nodes(0).Nodes.Add("Update Activities Status", "Update Activities Status", 0, 0)
        tv.Nodes(0).Nodes(5).Nodes.Add("Updating...", "Updating...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        UpdateP6()
        tv.Nodes(0).Nodes(5).Nodes(0).Text = "Updating Finished"
        tv.Nodes(0).Nodes(5).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '07
        tv.Nodes(0).Nodes.Add("Snapshot Activities Status", "Snapshot Activities Status", 0, 0)
        tv.Nodes(0).Nodes(6).Nodes.Add("Snapshot...", "Snapshot...", 3, 3)
        tv.ExpandAll()
        Application.DoEvents()
        dtP6After = DB.ReturnDataTable("select * from tblActIDS")
        tv.Nodes(0).Nodes(6).Nodes(0).Text = "Snapshot Finished"
        tv.Nodes(0).Nodes(6).Nodes(0).ImageIndex = 2
        Application.DoEvents()

        '08 Compare old P6 with new P6
        '------------------------------

        RaiseEvent ProductionUpdated()
    End Sub

    Private Sub UpdateEICA()
        Dim temp() As String = Split(Replace(My.Resources.UpdateEICA, "userxxx", String.Format("'{0}'", My.User.Name),,, CompareMethod.Text), "GO")
        For inx As Integer = 0 To temp.Length - 1
            DB.ExcuteNoneResult(temp(inx), 500)
        Next
    End Sub
    Private sub CleanProTable
        DB.ExcuteNoneResult(replace(My.Resources.CleanProTable,"userxxx",My.User.Name,,,CompareMethod.Text))
        DB.ExcuteNoneResult("delete from [tbl_Update_MileStone] where update_err='To Remove'")
    End sub
    Public Sub UpdateP6()
        Try
            Dim temp As String
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\UpdateP6.txt")
            temp = obj.ReadToEnd
            obj.Close()
            DB.ExcuteNoneResult("update tblActIDS set EICA_Budget=0,EICA_Done=0")
            DB.ExcuteNoneResult(temp, 500)
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub P6Snapshot()
        UpdateP6()
        dtP6 = DB.ReturnDataTable("select * from tblActIDS")
    End Sub
    Public Sub CleanProductionBuffer()
        AccDB.ExcuteNoneResult(String.Format("delete from tbl_Update_MileStone WHERE update_user ='{0}'", My.User.Name))
        DB.ExcuteNoneResult(String.Format("delete from tbl_Update_MileStone WHERE update_user ='{0}'", My.User.Name))
    End Sub
    Public Sub UpdateProductionFromNativeFiles(ByVal filePath As String, ByVal DataType As String, ByVal SheetName As String, ByRef FleNode As TreeNode, ByVal ProDate As Date, ByVal Subcon As String)
        Try
            Dim inx As Integer = 0
            dt = New DataTable
            dt = ex.GetSheetData(filePath, SheetName, "Tag is Not null")
            RaiseEvent ProgressDataCount(dt.Rows.Count)
            Application.DoEvents()
            For inx = 0 To dt.Rows.Count - 1
                Select Case DataType
                    Case "ElectricalEquipment"
                        If Not IsDBNull(dt.Rows(inx).Item("Installed_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Installed_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 111 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_QC_Released")) Then
                            If IsDate(dt.Rows(inx).Item("TR_QC_Released")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 114 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "ElectricalCables"
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Plan_Pulled_Date")) Then
                            If IsDate(dt.Rows(inx).Item("ec_Plan_Pulled_Date")) Then
                                If Not IsDBNull(dt.Rows(inx).Item("PercentageDone")) Then
                                    AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,ms_1,ms_2,ms_3,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 11 & ",'" & dt.Rows(inx).Item("ec_Plan_Real_Qty_Pulled") & "','" & dt.Rows(inx).Item("EC_ActualDrum") & "'," & dt.Rows(inx).Item("PercentageDone") & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                                End If
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Cable_Gland_From")) Then
                            If IsDate(dt.Rows(inx).Item("ec_Cable_Gland_From")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 16 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Cable_Gland_To")) Then
                            If IsDate(dt.Rows(inx).Item("ec_Cable_Gland_To")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 17 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Plan_Connected_Date_From")) Then
                            If IsDate(dt.Rows(inx).Item("ec_Plan_Connected_Date_From")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 12 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Plan_Connected_Date_To")) Then
                            If IsDate(dt.Rows(inx).Item("ec_Plan_Connected_Date_To")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 13 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("ec_Megger")) Then
                            If IsDate(dt.Rows(inx).Item("ec_Megger")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 14 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("tr_qc_released")) Then
                            If IsDate(dt.Rows(inx).Item("tr_qc_released")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 15 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')", 0)
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "ElectricalJB"
                        If Not IsDBNull(dt.Rows(inx).Item("JE_Installed")) Then
                            If IsDate(dt.Rows(inx).Item("JE_Installed")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 112 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "ElectricalCableTray"
                        If Not IsDBNull(dt.Rows(inx).Item("EL_Tray_Installed_date")) Then
                            If IsDate(dt.Rows(inx).Item("EL_Tray_Installed_date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 81 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "MiscCables"
                        If Not IsDBNull(dt.Rows(inx).Item("Pulling_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Pulling_Date")) Then
                                If Not IsDBNull(dt.Rows(inx).Item("PercentageDone")) Then
                                    AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_1,ms_2,ms_3,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 101 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & dt.Rows(inx).Item("Pulled_Length") & "','" & dt.Rows(inx).Item("Actual_Drum") & "'," & dt.Rows(inx).Item("PercentageDone") & ",'" & Subcon & "')")
                                End If
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Glanding_FROM_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Glanding_FROM_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 102 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Connection_From_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Connection_From_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 103 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("QCReleased_Date")) Then
                            If IsDate(dt.Rows(inx).Item("QCReleased_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 104 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "LightingFixture"
                        If Not IsDBNull(dt.Rows(inx).Item("LF_Installed")) Then
                            If IsDate(dt.Rows(inx).Item("LF_Installed")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 113 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "Instruments"
                        If Not IsDBNull(dt.Rows(inx).Item("Calibration_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Calibration_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 22 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Installation_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Installation_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 21 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("HookUp_Date")) Then
                            If IsDate(dt.Rows(inx).Item("HookUp_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 23 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Final_Installed_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Final_Installed_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 24 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Calibration_QC_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Calibration_QC_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 25 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Hookup_QC_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Hookup_QC_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 26 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "InstrumentsCable"
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Plan_Pulled_Date")) Then
                            If IsDate(dt.Rows(inx).Item("IC_Plan_Pulled_Date")) Then
                                If Not IsDBNull(dt.Rows(inx).Item("PercentageDone")) Then
                                    AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,ms_1,ms_2,ms_3,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 31 & ",'" & dt.Rows(inx).Item("IC_Plan_Real_Qty_Pulled") & "','" & dt.Rows(inx).Item("iC_ActualDrum") & "'," & dt.Rows(inx).Item("PercentageDone") & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                                End If
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Cable_Gland_From")) Then
                            If IsDate(dt.Rows(inx).Item("IC_Cable_Gland_From")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 35 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Cable_Gland_To")) Then
                            If IsDate(dt.Rows(inx).Item("IC_Cable_Gland_To")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 36 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Plan_Connected_Date_From")) Then
                            If IsDate(dt.Rows(inx).Item("IC_Plan_Connected_Date_From")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 32 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Plan_Connected_Date_To")) Then
                            If IsDate(dt.Rows(inx).Item("IC_Plan_Connected_Date_To")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,MS_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 33 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("IC_Megger")) Then
                            If IsDate(dt.Rows(inx).Item("IC_Megger")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 34 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_QC_Released")) Then
                            If IsDate(dt.Rows(inx).Item("TR_QC_Released")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 37 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "JunctionBox"
                        If Not IsDBNull(dt.Rows(inx).Item("JI_Installed")) Then
                            If IsDate(dt.Rows(inx).Item("JI_Installed")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 61 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("JI_Frame_Installed")) Then
                            If IsDate(dt.Rows(inx).Item("JI_Frame_Installed")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 62 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("JI_TRQC")) Then
                            If IsDate(dt.Rows(inx).Item("JI_TRQC")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 63 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "InstrumentEquipment"
                        If Not IsDBNull(dt.Rows(inx).Item("Installed_Date")) Then
                            If IsDate(dt.Rows(inx).Item("Installed_Date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 211 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_QC_Released")) Then
                            If IsDate(dt.Rows(inx).Item("TR_QC_Released")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 212 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "PartialEleCableTray"
                        If Not IsDBNull(dt.Rows(inx).Item("Closed Date")) Then
                            If IsDate(dt.Rows(inx).Item("Closed Date")) Then
                                DB.ExcuteNoneResult("exec AddPartialECT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "' ,Null," & dt.Rows(inx).Item("Production_Qnty") & ",'" & Format(CDate(ProDate), "MM/dd/yyyy").ToString & "','" & Subcon & "'")
                            End If
                        Else
                            If Not IsDBNull(dt.Rows(inx).Item("Production_Date")) Then
                                If IsDate(dt.Rows(inx).Item("Production_Date")) Then
                                    AccDB.ExcuteNoneResult("exec AddPartialECT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "'," & dt.Rows(inx).Item("Production_Qnty") & ",Null,'" & Subcon & "'")
                                End If
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "PartialInsCableTray"
                        If Not IsDBNull(dt.Rows(inx).Item("Closed Date")) Then
                            If IsDate(dt.Rows(inx).Item("Closed Date")) Then
                                DB.ExcuteNoneResult("exec AddPartialiCT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "',Null," & dt.Rows(inx).Item("Production_Qnty") & ",'" & Format(CDate(ProDate), "MM/dd/yyyy").ToString & "','" & Subcon & "'")
                            End If
                        Else
                            If Not IsDBNull(dt.Rows(inx).Item("Production_Date")) Then
                                If IsDate(dt.Rows(inx).Item("Production_Date")) Then
                                    AccDB.ExcuteNoneResult("exec AddPartialICT '" & dt.Rows(inx).Item("TAG") & "','" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy").ToString & "'," & dt.Rows(inx).Item("Production_Qnty") & ",Null,'" & Subcon & "'")
                                End If
                            End If
                        End If
                    '---------------------------------------------------------------------------------------------------
                    Case "Motors"
                        If Not IsDBNull(dt.Rows(inx).Item("Installed_date")) Then
                            If IsDate(dt.Rows(inx).Item("Installed_date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 71 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("motor_test_date")) Then
                            If IsDate(dt.Rows(inx).Item("motor_test_date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 72 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("solo_run_date")) Then
                            If IsDate(dt.Rows(inx).Item("solo_run_date")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("TAG") & "'," & 73 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------
                    Case "Loops"
                        If Not IsDBNull(dt.Rows(inx).Item("Folder_Preparation")) Then
                            If IsDate(dt.Rows(inx).Item("Folder_Preparation")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 96 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("L_Constr_Release")) Then
                            If IsDate(dt.Rows(inx).Item("L_Constr_Release")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 90 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("TR_Loop_Folder_QC_Release")) Then
                            If IsDate(dt.Rows(inx).Item("TR_Loop_Folder_QC_Release")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 92 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Punch_To_SubContractor")) Then
                            If IsDate(dt.Rows(inx).Item("Punch_To_SubContractor")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 93 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("SubContractor_To_Cons")) Then
                            If IsDate(dt.Rows(inx).Item("SubContractor_To_Cons")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 94 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Loops_Client_QC_Release")) Then
                            If IsDate(dt.Rows(inx).Item("Loops_Client_QC_Release")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 95 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("HCS_Folder_Ready")) Then
                            If IsDate(dt.Rows(inx).Item("HCS_Folder_Ready")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 97 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("HCS_Submitted_To_Client")) Then
                            If IsDate(dt.Rows(inx).Item("HCS_Submitted_To_Client")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 99 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Client_Reject")) Then
                            If IsDate(dt.Rows(inx).Item("Client_Reject")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 917 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Folder_Client_Approved")) Then
                            If IsDate(dt.Rows(inx).Item("Folder_Client_Approved")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 910 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Submitted_to_Precom")) Then
                            If IsDate(dt.Rows(inx).Item("Submitted_to_Precom")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 911 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Precom_Reject")) Then
                            If IsDate(dt.Rows(inx).Item("Precom_Reject")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 915 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Submitted_To_Client_Precom")) Then
                            If IsDate(dt.Rows(inx).Item("Submitted_To_Client_Precom")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 912 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Client_Precom_Reject")) Then
                            If IsDate(dt.Rows(inx).Item("Client_Precom_Reject")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 916 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Client_Precom_Approved")) Then
                            If IsDate(dt.Rows(inx).Item("Client_Precom_Approved")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 913 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("L_Done")) Then
                            If IsDate(dt.Rows(inx).Item("L_Done")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 91 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("Submitted_For_Certificate")) Then
                            If IsDate(dt.Rows(inx).Item("Submitted_For_Certificate")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 914 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        If Not IsDBNull(dt.Rows(inx).Item("L_FinalApproval")) Then
                            If IsDate(dt.Rows(inx).Item("L_FinalApproval")) Then
                                AccDB.ExcuteNoneResult("insert into tbl_Update_MileStone (tag,item_type,update_user,update_date,ms_4) values ('" & dt.Rows(inx).Item("Tag") & "'," & 98 & ",'" & My.User.Name & "','" & Format(CDate(ProDate), "MM/dd/yyyy") & "','" & Subcon & "')")
                            End If
                        End If
                        '---------------------------------------------------------------------------------------------------
                End Select
                FleNode.Text = String.Format("Importing: {0} / {1}", inx + 1, dt.Rows.Count)
                Application.DoEvents()
            Next
            FleNode.ImageIndex = 2
            Application.DoEvents()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Sub CopyProductionToEICA()
        DB.Close()
        DB.Connect()
        DB.ExcuteNoneResult(String.Format("delete from tbl_Update_MileStone WHERE update_user ='{0}'", My.User.Name))
        Dim DT As New DataTable
        DT = AccDB.ReturnDataTable("SELECT [item_type],[tag],[ms_1],[ms_2],[ms_3],[update_user],[update_date],[update_err],[reported_by],[ms_4] FROM [tbl_Update_MileStone]")
        Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
            bcp.DestinationTableName = "tbl_Update_MileStone"
            bcp.BatchSize = 5000
            bcp.ColumnMappings.Clear()
            bcp.ColumnMappings.Add("item_type", "item_type")
            bcp.ColumnMappings.Add("tag", "tag")
            bcp.ColumnMappings.Add("ms_1", "ms_1")
            bcp.ColumnMappings.Add("ms_2", "ms_2")
            bcp.ColumnMappings.Add("ms_3", "ms_3")
            bcp.ColumnMappings.Add("update_user", "update_user")
            bcp.ColumnMappings.Add("update_date", "update_date")
            bcp.ColumnMappings.Add("update_err", "update_err")
            bcp.ColumnMappings.Add("reported_by", "reported_by")
            bcp.ColumnMappings.Add("ms_4", "ms_4")
            bcp.WriteToServer(DT)
        End Using
    End Sub
    Public Sub CopyMaterialToEICA(ByRef dt As DataTable)
        DB.Close()
        DB.Connect()
        DB.ExcuteNoneResult(String.Format("delete from tblArrivalMatComp"))

        Using bcp As New SqlClient.SqlBulkCopy((DB.DBConnection))
            bcp.DestinationTableName = "tblArrivalMatComp"
            bcp.BatchSize = 20000
            bcp.ColumnMappings.Clear()
            bcp.ColumnMappings.Add("TAG", "TAG")
            bcp.ColumnMappings.Add("Vendor", "Vendor")
            bcp.ColumnMappings.Add("PO_Date", "PO_Date")
            bcp.ColumnMappings.Add("PO", "PO")
            bcp.ColumnMappings.Add("Forescasted", "Forescasted")
            bcp.ColumnMappings.Add("Arrival_Date", "Arrival_Date")
            bcp.ColumnMappings.Add("Qnty", "Qnty")
            bcp.ColumnMappings.Add("Qnty_Unit", "Qnty_Unit")
            bcp.ColumnMappings.Add("Description", "Description")
            bcp.WriteToServer(DT)
        End Using

        UpdateEICAMaterialForeCast()
        UpdateMaterialArrival()
    End Sub

    Private Sub UpdateEICAPartial()
        DB.Close()
        DB.Connect()
        DB.ExcuteNoneResult("exec UpdateECPro", 0)
        DB.ExcuteNoneResult("exec UpdateICPro", 0)
        DB.ExcuteNoneResult("exec UpdateLCPro", 0)
        DB.ExcuteNoneResult("UPDATE [tblInstruments] SET Final_Installed_Date=[Installation_Date] WHERE [Installation_Date] IS NOT NULL AND QC_Required=0")
    End Sub

    Public Sub UpdateHCSReleased()
        'DB.ExcuteNoneResult(My.Resources.UpdateECReleased, 0)
        'DB.ExcuteNoneResult(My.Resources.UpdateICReleased, 0)
        'DB.ExcuteNoneResult(My.Resources.UpdateInsReleased, 0)
        'DB.ExcuteNoneResult(My.Resources.UpdateEJBReleased, 0)
        'DB.ExcuteNoneResult(My.Resources.UpdateJBReleased, 0)
        'DB.ExcuteNoneResult(My.Resources.UpdateInsReleasedHCS)
        'DB.ExcuteNoneResult(My.Resources.UpdateInsEQReleased)
        'DB.ExcuteNoneResult(My.Resources.UpdateEEQReleased)
    End Sub
    Public Sub UpdateEICAItemsWithHCSSubsystem()
        Try
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemFixture, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemIns, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemIEQ, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemIC, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemEJB, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemEEQ, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemEC, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemInsJB, 0)
            'DB.ExcuteNoneResult(My.Resources.UpdateSubsystemMotor, 0)
            RaiseEvent EICAItemsUpdated()
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Private Sub UpdateEICAMaterialForeCast()
        Try
            DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [Forescasted] = null where [Forescasted]='1/1/1900'")
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\Update_Mat_ForeCast.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                If Trim(temp(inx)) <> "" Then DB.ExcuteNoneResult(temp(inx))
            Next
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try

    End Sub
    Private Sub UpdateMaterialArrival()
        Try
            DB.ExcuteNoneResult("UPDATE [tblArrivalMatComp] set [arrival_date] = null where [arrival_date]='1/1/1900'")
            Dim temp() As String, inx As Integer = 0
            Dim obj As New System.IO.StreamReader(Application.StartupPath & "\sqries\Update_Mat_Arriv.txt")
            temp = Split(obj.ReadToEnd, "go", , CompareMethod.Text)
            obj.Close()
            For inx = 0 To temp.Count - 1
                DB.ExcuteNoneResult(temp(inx))
            Next
            DB.ExcuteNoneResult("insert into [tblTasks] ([task_name],[task_date],[is_done],[task_type]) values ('" &
                       My.User.Name & " Has Loaded Material','" & Format(Now, "MM/dd/yyyy HH:mm") & "','True','Material')")
            DB.ExcuteNoneResult("update [tblTMP] set [Production_Updated] ='True' where [tmp_id]=1")
        Catch ex As Exception
            RaiseEvent Err(ex.Message)
        End Try
    End Sub

    Public Function AddTempItem(ByVal item_name As String, ByVal item_type As String, ByVal productionstep As String) As Boolean
        Try
            DB.ExcuteNoneResult(String.Format("insert into [tblTempItem] (item_name,item_type,reported_by,reported_date,production_step) values ('{0}','{1}','{2}','{3}','{4}')", item_name, item_type, My.User.Name, Format(Now, "MM/dd/yyyy"), productionstep))
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

End Class
