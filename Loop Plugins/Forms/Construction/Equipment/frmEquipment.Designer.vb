<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEquipment
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEquipment))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.rMenuRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuChangeActId = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.rMenuAssignActId = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuAssignActIdWithArea = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuClearActId = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetProduction = New DevExpress.XtraBars.BarSubItem()
        Me.rMenuSetAsInstalled = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetQCReleased = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem14 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem15 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuChangeTeam = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem17 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem4 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem18 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem19 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem20 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem5 = New DevExpress.XtraBars.BarSubItem()
        Me.rMenuCopyTag = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuIsolate = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuShare = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup6 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpProduction = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpEngineering = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpPlanning = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpQC = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grd = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sveFle = New System.Windows.Forms.SaveFileDialog()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        Me.rMenu = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager
        '
        SplashScreenManager.ClosingDelay = 500
        '
        'RibbonControl1
        '
        Me.RibbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(26, 24, 26, 24)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.rMenuRefresh, Me.rMenuFilter, Me.BarButtonItem3, Me.BarButtonItem5, Me.BarButtonItem6, Me.BarButtonItem7, Me.BarButtonItem8, Me.rMenuChangeActId, Me.BarSubItem2, Me.rMenuAssignActId, Me.rMenuAssignActIdWithArea, Me.rMenuClearActId, Me.rMenuSetProduction, Me.rMenuSetAsInstalled, Me.rMenuSetQCReleased, Me.BarButtonItem14, Me.BarButtonItem15, Me.rMenuChangeTeam, Me.BarButtonItem17, Me.BarSubItem4, Me.BarButtonItem18, Me.BarButtonItem19, Me.BarButtonItem20, Me.BarSubItem5, Me.rMenuCopyTag, Me.rMenuIsolate, Me.rMenuShare})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonControl1.MaxItemId = 30
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsMenuMinWidth = 283
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2, Me.RibbonPage3, Me.RibbonPage1, Me.rpEngineering, Me.rpPlanning, Me.rpQC})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1027, 110)
        '
        'rMenuRefresh
        '
        Me.rMenuRefresh.Caption = "Refresh"
        Me.rMenuRefresh.CloseRadialMenuOnItemClick = True
        Me.rMenuRefresh.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuRefresh.Id = 1
        Me.rMenuRefresh.ImageOptions.Image = CType(resources.GetObject("rMenuRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuRefresh.ImageOptions.LargeImage = CType(resources.GetObject("rMenuRefresh.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuRefresh.Name = "rMenuRefresh"
        Me.rMenuRefresh.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuFilter
        '
        Me.rMenuFilter.Caption = "Filter"
        Me.rMenuFilter.CloseRadialMenuOnItemClick = True
        Me.rMenuFilter.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuFilter.Id = 2
        Me.rMenuFilter.ImageOptions.Image = CType(resources.GetObject("rMenuFilter.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuFilter.ImageOptions.LargeImage = CType(resources.GetObject("rMenuFilter.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuFilter.Name = "rMenuFilter"
        Me.rMenuFilter.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Export To Excel"
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Set As Done"
        Me.BarButtonItem5.Id = 5
        Me.BarButtonItem5.ImageOptions.Image = CType(resources.GetObject("BarButtonItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "Save View"
        Me.BarButtonItem6.Id = 6
        Me.BarButtonItem6.ImageOptions.Image = CType(resources.GetObject("BarButtonItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem6.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem6.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem6.Name = "BarButtonItem6"
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "Load View"
        Me.BarButtonItem7.Id = 7
        Me.BarButtonItem7.ImageOptions.Image = CType(resources.GetObject("BarButtonItem7.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem7.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem7.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Undock"
        Me.BarButtonItem8.Id = 8
        Me.BarButtonItem8.ImageOptions.Image = CType(resources.GetObject("BarButtonItem8.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem8.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem8.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem8.Name = "BarButtonItem8"
        Me.BarButtonItem8.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuChangeActId
        '
        Me.rMenuChangeActId.Caption = "Assign Activity ID"
        Me.rMenuChangeActId.Id = 9
        Me.rMenuChangeActId.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuChangeActId.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuChangeActId.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem2)})
        Me.rMenuChangeActId.Name = "rMenuChangeActId"
        Me.rMenuChangeActId.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "Installation"
        Me.BarSubItem2.Id = 10
        Me.BarSubItem2.ImageOptions.Image = CType(resources.GetObject("BarSubItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.rMenuAssignActId), New DevExpress.XtraBars.LinkPersistInfo(Me.rMenuAssignActIdWithArea), New DevExpress.XtraBars.LinkPersistInfo(Me.rMenuClearActId)})
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'rMenuAssignActId
        '
        Me.rMenuAssignActId.Caption = "Assign ActId"
        Me.rMenuAssignActId.CausesValidation = True
        Me.rMenuAssignActId.CloseRadialMenuOnItemClick = True
        Me.rMenuAssignActId.Id = 11
        Me.rMenuAssignActId.ImageOptions.Image = CType(resources.GetObject("BarButtonItem9.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuAssignActId.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem9.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuAssignActId.Name = "rMenuAssignActId"
        '
        'rMenuAssignActIdWithArea
        '
        Me.rMenuAssignActIdWithArea.Caption = "Assign ActId With Area"
        Me.rMenuAssignActIdWithArea.CausesValidation = True
        Me.rMenuAssignActIdWithArea.CloseRadialMenuOnItemClick = True
        Me.rMenuAssignActIdWithArea.Id = 12
        Me.rMenuAssignActIdWithArea.ImageOptions.Image = CType(resources.GetObject("BarButtonItem10.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuAssignActIdWithArea.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem10.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuAssignActIdWithArea.Name = "rMenuAssignActIdWithArea"
        '
        'rMenuClearActId
        '
        Me.rMenuClearActId.Caption = "Clear ActId"
        Me.rMenuClearActId.CausesValidation = True
        Me.rMenuClearActId.CloseRadialMenuOnItemClick = True
        Me.rMenuClearActId.Id = 13
        Me.rMenuClearActId.ImageOptions.Image = CType(resources.GetObject("BarButtonItem11.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuClearActId.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem11.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuClearActId.Name = "rMenuClearActId"
        '
        'rMenuSetProduction
        '
        Me.rMenuSetProduction.Caption = "Set Production"
        Me.rMenuSetProduction.Id = 14
        Me.rMenuSetProduction.ImageOptions.Image = CType(resources.GetObject("BarSubItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetProduction.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetProduction.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.rMenuSetAsInstalled)})
        Me.rMenuSetProduction.Name = "rMenuSetProduction"
        Me.rMenuSetProduction.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetAsInstalled
        '
        Me.rMenuSetAsInstalled.Caption = "Set As Installed"
        Me.rMenuSetAsInstalled.CausesValidation = True
        Me.rMenuSetAsInstalled.CloseRadialMenuOnItemClick = True
        Me.rMenuSetAsInstalled.Id = 15
        Me.rMenuSetAsInstalled.ImageOptions.Image = CType(resources.GetObject("BarButtonItem12.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetAsInstalled.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem12.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetAsInstalled.Name = "rMenuSetAsInstalled"
        '
        'rMenuSetQCReleased
        '
        Me.rMenuSetQCReleased.Caption = "Set As QC Released"
        Me.rMenuSetQCReleased.CloseRadialMenuOnItemClick = True
        Me.rMenuSetQCReleased.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetQCReleased.Id = 16
        Me.rMenuSetQCReleased.ImageOptions.Image = CType(resources.GetObject("BarButtonItem13.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetQCReleased.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem13.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetQCReleased.Name = "rMenuSetQCReleased"
        Me.rMenuSetQCReleased.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem14
        '
        Me.BarButtonItem14.Caption = "Show RFI"
        Me.BarButtonItem14.Id = 17
        Me.BarButtonItem14.ImageOptions.Image = CType(resources.GetObject("BarButtonItem14.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem14.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem14.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem14.Name = "BarButtonItem14"
        '
        'BarButtonItem15
        '
        Me.BarButtonItem15.Caption = "Show RFI"
        Me.BarButtonItem15.Id = 18
        Me.BarButtonItem15.ImageOptions.Image = CType(resources.GetObject("BarButtonItem15.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem15.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem15.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem15.Name = "BarButtonItem15"
        '
        'rMenuChangeTeam
        '
        Me.rMenuChangeTeam.Caption = "Change Team"
        Me.rMenuChangeTeam.CausesValidation = True
        Me.rMenuChangeTeam.CloseRadialMenuOnItemClick = True
        Me.rMenuChangeTeam.Id = 19
        Me.rMenuChangeTeam.ImageOptions.Image = CType(resources.GetObject("BarButtonItem16.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuChangeTeam.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem16.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuChangeTeam.Name = "rMenuChangeTeam"
        Me.rMenuChangeTeam.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem17
        '
        Me.BarButtonItem17.Caption = "Show Resources"
        Me.BarButtonItem17.Id = 20
        Me.BarButtonItem17.ImageOptions.Image = CType(resources.GetObject("BarButtonItem17.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem17.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem17.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem17.Name = "BarButtonItem17"
        Me.BarButtonItem17.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarSubItem4
        '
        Me.BarSubItem4.Caption = "Resources"
        Me.BarSubItem4.Id = 21
        Me.BarSubItem4.ImageOptions.Image = CType(resources.GetObject("BarSubItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem18), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem19)})
        Me.BarSubItem4.Name = "BarSubItem4"
        '
        'BarButtonItem18
        '
        Me.BarButtonItem18.Caption = "Assign"
        Me.BarButtonItem18.Id = 22
        Me.BarButtonItem18.ImageOptions.Image = CType(resources.GetObject("BarButtonItem18.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem18.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem18.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem18.Name = "BarButtonItem18"
        '
        'BarButtonItem19
        '
        Me.BarButtonItem19.Caption = "Clear"
        Me.BarButtonItem19.Id = 23
        Me.BarButtonItem19.ImageOptions.Image = CType(resources.GetObject("BarButtonItem19.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem19.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem19.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem19.Name = "BarButtonItem19"
        '
        'BarButtonItem20
        '
        Me.BarButtonItem20.Caption = "Print Preview"
        Me.BarButtonItem20.Id = 24
        Me.BarButtonItem20.ImageOptions.Image = CType(resources.GetObject("BarButtonItem20.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem20.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem20.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem20.Name = "BarButtonItem20"
        Me.BarButtonItem20.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarSubItem5
        '
        Me.BarSubItem5.Caption = "Clipboard"
        Me.BarSubItem5.Id = 26
        Me.BarSubItem5.ImageOptions.Image = CType(resources.GetObject("BarSubItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem5.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.rMenuCopyTag)})
        Me.BarSubItem5.Name = "BarSubItem5"
        Me.BarSubItem5.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuCopyTag
        '
        Me.rMenuCopyTag.Caption = "Copy Tags"
        Me.rMenuCopyTag.CloseRadialMenuOnItemClick = True
        Me.rMenuCopyTag.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuCopyTag.Id = 27
        Me.rMenuCopyTag.ImageOptions.Image = CType(resources.GetObject("rMenuCopyTag.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuCopyTag.ImageOptions.LargeImage = CType(resources.GetObject("rMenuCopyTag.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuCopyTag.Name = "rMenuCopyTag"
        '
        'rMenuIsolate
        '
        Me.rMenuIsolate.Caption = "Isolate"
        Me.rMenuIsolate.CloseRadialMenuOnItemClick = True
        Me.rMenuIsolate.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuIsolate.Id = 28
        Me.rMenuIsolate.ImageOptions.Image = CType(resources.GetObject("rMenuIsolate.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuIsolate.ImageOptions.LargeImage = CType(resources.GetObject("rMenuIsolate.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuIsolate.Name = "rMenuIsolate"
        Me.rMenuIsolate.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuShare
        '
        Me.rMenuShare.Caption = "Share"
        Me.rMenuShare.CloseRadialMenuOnItemClick = True
        Me.rMenuShare.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuShare.Id = 29
        Me.rMenuShare.ImageOptions.Image = CType(resources.GetObject("rMenuShare.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuShare.ImageOptions.LargeImage = CType(resources.GetObject("rMenuShare.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuShare.Name = "rMenuShare"
        Me.rMenuShare.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup6})
        Me.RibbonPage2.ImageOptions.Image = CType(resources.GetObject("RibbonPage2.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Home"
        '
        'RibbonPageGroup6
        '
        Me.RibbonPageGroup6.ItemLinks.Add(Me.rMenuRefresh)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.rMenuFilter)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.rMenuIsolate)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.rMenuShare)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BarSubItem5)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BarButtonItem15)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BarButtonItem17)
        Me.RibbonPageGroup6.ItemLinks.Add(Me.BarButtonItem20)
        Me.RibbonPageGroup6.Name = "RibbonPageGroup6"
        Me.RibbonPageGroup6.Text = "Equipment Options"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpProduction})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Construction"
        '
        'rpProduction
        '
        Me.rpProduction.ItemLinks.Add(Me.rMenuSetProduction)
        Me.rpProduction.Name = "rpProduction"
        Me.rpProduction.Text = "Production"
        '
        'rpEngineering
        '
        Me.rpEngineering.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup5})
        Me.rpEngineering.ImageOptions.Image = CType(resources.GetObject("rpEngineering.ImageOptions.Image"), System.Drawing.Image)
        Me.rpEngineering.Name = "rpEngineering"
        Me.rpEngineering.Text = "Engineering"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BarSubItem4)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "RibbonPageGroup5"
        '
        'rpPlanning
        '
        Me.rpPlanning.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.rpPlanning.ImageOptions.Image = Global.EEICA.My.Resources.Resources.icons8_work_321
        Me.rpPlanning.Name = "rpPlanning"
        Me.rpPlanning.Text = "Planning"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.rMenuChangeActId)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.rMenuChangeTeam)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "RibbonPageGroup2"
        '
        'rpQC
        '
        Me.rpQC.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4})
        Me.rpQC.ImageOptions.Image = CType(resources.GetObject("rpQC.ImageOptions.Image"), System.Drawing.Image)
        Me.rpQC.Name = "rpQC"
        Me.rpQC.Text = "QC"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.rMenuSetQCReleased)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "QC Options"
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage3.ImageOptions.Image = CType(resources.GetObject("RibbonPage3.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "View"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem8)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem6)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem7)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Equipment View"
        '
        'grd
        '
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 110)
        Me.grd.MainView = Me.gv
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(1027, 458)
        Me.grd.TabIndex = 70
        Me.grd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv})
        '
        'gv
        '
        Me.gv.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.gv.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.gv.Appearance.EvenRow.Options.UseBackColor = True
        Me.gv.Appearance.EvenRow.Options.UseForeColor = True
        Me.gv.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gold
        Me.gv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.gv.Appearance.FocusedCell.Options.UseBackColor = True
        Me.gv.Appearance.FocusedCell.Options.UseForeColor = True
        Me.gv.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gold
        Me.gv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.gv.Appearance.FocusedRow.Options.UseBackColor = True
        Me.gv.Appearance.FocusedRow.Options.UseForeColor = True
        Me.gv.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.gv.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.gv.Appearance.OddRow.Options.UseBackColor = True
        Me.gv.Appearance.OddRow.Options.UseForeColor = True
        Me.gv.Appearance.SelectedRow.BackColor = System.Drawing.Color.Gold
        Me.gv.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.gv.Appearance.SelectedRow.Options.UseBackColor = True
        Me.gv.Appearance.SelectedRow.Options.UseForeColor = True
        Me.gv.GridControl = Me.grd
        Me.gv.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IfInstalled", Nothing, """Done: {0}""")})
        Me.gv.Name = "gv"
        Me.gv.OptionsBehavior.Editable = False
        Me.gv.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gv.OptionsMenu.ShowConditionalFormattingItem = True
        Me.gv.OptionsSelection.MultiSelect = True
        Me.gv.OptionsView.AutoCalcPreviewLineCount = True
        Me.gv.OptionsView.ColumnAutoWidth = False
        Me.gv.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gv.OptionsView.ShowAutoFilterRow = True
        Me.gv.OptionsView.ShowFooter = True
        Me.gv.OptionsView.ShowGroupedColumns = True
        Me.gv.OptionsView.ShowGroupPanelColumnsAsSingleRow = True
        '
        'sveFle
        '
        Me.sveFle.Filter = "Excel File|*.xlsx"
        '
        'opnFle
        '
        Me.opnFle.Filter = "View Files|*.xml"
        '
        'rMenu
        '
        Me.rMenu.AutoExpand = True
        Me.rMenu.Glyph = CType(resources.GetObject("rMenu.Glyph"), System.Drawing.Image)
        Me.rMenu.ItemLinks.Add(Me.rMenuFilter)
        Me.rMenu.ItemLinks.Add(Me.rMenuIsolate)
        Me.rMenu.ItemLinks.Add(Me.rMenuShare)
        Me.rMenu.ItemLinks.Add(Me.rMenuRefresh)
        Me.rMenu.ItemLinks.Add(Me.rMenuCopyTag)
        Me.rMenu.ItemLinks.Add(Me.rMenuChangeActId)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetProduction)
        Me.rMenu.ItemLinks.Add(Me.rMenuChangeTeam)
        Me.rMenu.Name = "rMenu"
        Me.rMenu.Ribbon = Me.RibbonControl1
        '
        'frmEquipment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 568)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Image = Global.EEICA.My.Resources.Resources.equipment32
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmEquipment"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equipment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rMenuRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sveFle As SaveFileDialog
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpProduction As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpPlanning As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rMenuChangeActId As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents rMenuAssignActId As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuAssignActIdWithArea As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuClearActId As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetProduction As DevExpress.XtraBars.BarSubItem
    Friend WithEvents rMenuSetAsInstalled As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpQC As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rMenuSetQCReleased As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem14 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem15 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuChangeTeam As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem17 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpEngineering As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarSubItem4 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem18 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem19 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup6 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem20 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarSubItem5 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents rMenuCopyTag As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuIsolate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuShare As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenu As DevExpress.XtraBars.Ribbon.RadialMenu
End Class
