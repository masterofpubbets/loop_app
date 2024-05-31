<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoopFolders
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoopFolders))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.lblInfo = New DevExpress.XtraBars.BarStaticItem()
        Me.rMenuRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuFilter = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderPrinted = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderApproved = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuExportToExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderSubmitToSupportTeam = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderReleased = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderReady = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderSubmitToPrecomm = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderDone = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuAddBlockage = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem16 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuShowBlockage = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem18 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuOpenILD = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.rMenuCopyLoop = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem21 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem22 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderSubmitToQC = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem24 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderReturnFromQC = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuLoopTasks = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderConsComplete = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuShare = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderConsTargetDate = New DevExpress.XtraBars.BarButtonItem()
        Me.rMenuSetFolderFailed = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpConstruction = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpHandover = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rgHandover = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpSupportTeam = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpQC = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rgQC = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpPrecom = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rgPrecomm = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpBlockage = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup7 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
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
        Me.RibbonControl1.CaptionBarItemLinks.Add(Me.lblInfo)
        Me.RibbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(26, 24, 26, 24)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.lblInfo, Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.rMenuRefresh, Me.rMenuFilter, Me.rMenuSetFolderPrinted, Me.rMenuSetFolderApproved, Me.rMenuExportToExcel, Me.BarButtonItem8, Me.BarButtonItem9, Me.rMenuSetFolderSubmitToSupportTeam, Me.rMenuSetFolderReleased, Me.rMenuSetFolderReady, Me.rMenuSetFolderSubmitToPrecomm, Me.rMenuSetFolderDone, Me.rMenuAddBlockage, Me.BarButtonItem16, Me.rMenuShowBlockage, Me.BarButtonItem18, Me.rMenuOpenILD, Me.BarSubItem1, Me.rMenuCopyLoop, Me.BarButtonItem21, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem22, Me.rMenuSetFolderSubmitToQC, Me.BarButtonItem24, Me.rMenuSetFolderReturnFromQC, Me.rMenuLoopTasks, Me.rMenuSetFolderConsComplete, Me.BarButtonItem1, Me.rMenuShare, Me.BarButtonItem2, Me.rMenuSetFolderConsTargetDate, Me.rMenuSetFolderFailed})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonControl1.MaxItemId = 38
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsMenuMinWidth = 283
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1, Me.RibbonPage2, Me.rpConstruction, Me.rpHandover, Me.rpSupportTeam, Me.rpQC, Me.rpPrecom, Me.rpBlockage})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1208, 110)
        '
        'lblInfo
        '
        Me.lblInfo.Caption = "No Info"
        Me.lblInfo.Id = 27
        Me.lblInfo.ImageOptions.Image = CType(resources.GetObject("lblInfo.ImageOptions.Image"), System.Drawing.Image)
        Me.lblInfo.ImageOptions.LargeImage = CType(resources.GetObject("lblInfo.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
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
        'rMenuSetFolderPrinted
        '
        Me.rMenuSetFolderPrinted.Caption = "Set Folder Printed"
        Me.rMenuSetFolderPrinted.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderPrinted.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderPrinted.Id = 5
        Me.rMenuSetFolderPrinted.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderPrinted.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderPrinted.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderPrinted.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderPrinted.Name = "rMenuSetFolderPrinted"
        Me.rMenuSetFolderPrinted.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderApproved
        '
        Me.rMenuSetFolderApproved.Caption = "Set Folder Approved"
        Me.rMenuSetFolderApproved.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderApproved.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderApproved.Id = 6
        Me.rMenuSetFolderApproved.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderApproved.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderApproved.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderApproved.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderApproved.Name = "rMenuSetFolderApproved"
        Me.rMenuSetFolderApproved.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuExportToExcel
        '
        Me.rMenuExportToExcel.Caption = "Export To Excel"
        Me.rMenuExportToExcel.CloseRadialMenuOnItemClick = True
        Me.rMenuExportToExcel.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuExportToExcel.Id = 8
        Me.rMenuExportToExcel.ImageOptions.Image = CType(resources.GetObject("rMenuExportToExcel.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuExportToExcel.ImageOptions.LargeImage = CType(resources.GetObject("rMenuExportToExcel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuExportToExcel.Name = "rMenuExportToExcel"
        Me.rMenuExportToExcel.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Set Folder Released"
        Me.BarButtonItem8.Id = 9
        Me.BarButtonItem8.ImageOptions.Image = CType(resources.GetObject("BarButtonItem8.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem8.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem8.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem8.Name = "BarButtonItem8"
        Me.BarButtonItem8.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "Set Folder Ready"
        Me.BarButtonItem9.Id = 10
        Me.BarButtonItem9.ImageOptions.Image = CType(resources.GetObject("BarButtonItem9.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem9.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem9.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem9.Name = "BarButtonItem9"
        Me.BarButtonItem9.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderSubmitToSupportTeam
        '
        Me.rMenuSetFolderSubmitToSupportTeam.Caption = "Set Submitted To Support Team"
        Me.rMenuSetFolderSubmitToSupportTeam.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderSubmitToSupportTeam.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderSubmitToSupportTeam.Id = 11
        Me.rMenuSetFolderSubmitToSupportTeam.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderSubmitToSupportTeam.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderSubmitToSupportTeam.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderSubmitToSupportTeam.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderSubmitToSupportTeam.Name = "rMenuSetFolderSubmitToSupportTeam"
        Me.rMenuSetFolderSubmitToSupportTeam.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderReleased
        '
        Me.rMenuSetFolderReleased.Caption = "Set Folder QC Released"
        Me.rMenuSetFolderReleased.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderReleased.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderReleased.Id = 12
        Me.rMenuSetFolderReleased.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderReleased.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderReleased.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderReleased.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderReleased.Name = "rMenuSetFolderReleased"
        Me.rMenuSetFolderReleased.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderReady
        '
        Me.rMenuSetFolderReady.Caption = "Set Folder Ready"
        Me.rMenuSetFolderReady.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderReady.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderReady.Id = 13
        Me.rMenuSetFolderReady.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderReady.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderReady.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderReady.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderReady.Name = "rMenuSetFolderReady"
        Me.rMenuSetFolderReady.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderSubmitToPrecomm
        '
        Me.rMenuSetFolderSubmitToPrecomm.Caption = "Set Submitted To Precomm"
        Me.rMenuSetFolderSubmitToPrecomm.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderSubmitToPrecomm.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderSubmitToPrecomm.Id = 14
        Me.rMenuSetFolderSubmitToPrecomm.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderSubmitToPrecomm.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderSubmitToPrecomm.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderSubmitToPrecomm.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderSubmitToPrecomm.Name = "rMenuSetFolderSubmitToPrecomm"
        Me.rMenuSetFolderSubmitToPrecomm.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderDone
        '
        Me.rMenuSetFolderDone.Caption = "Set Loop Done"
        Me.rMenuSetFolderDone.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderDone.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderDone.Id = 15
        Me.rMenuSetFolderDone.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderDone.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderDone.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderDone.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderDone.Name = "rMenuSetFolderDone"
        Me.rMenuSetFolderDone.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuAddBlockage
        '
        Me.rMenuAddBlockage.Caption = "Add Blockage"
        Me.rMenuAddBlockage.CloseRadialMenuOnItemClick = True
        Me.rMenuAddBlockage.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuAddBlockage.Id = 16
        Me.rMenuAddBlockage.ImageOptions.Image = CType(resources.GetObject("rMenuAddBlockage.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuAddBlockage.ImageOptions.LargeImage = CType(resources.GetObject("rMenuAddBlockage.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuAddBlockage.Name = "rMenuAddBlockage"
        Me.rMenuAddBlockage.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem16
        '
        Me.BarButtonItem16.Caption = "Show QR"
        Me.BarButtonItem16.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem16.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem16.Id = 17
        Me.BarButtonItem16.ImageOptions.Image = CType(resources.GetObject("BarButtonItem16.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem16.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem16.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem16.Name = "BarButtonItem16"
        Me.BarButtonItem16.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuShowBlockage
        '
        Me.rMenuShowBlockage.Caption = "Show Blockage"
        Me.rMenuShowBlockage.CloseRadialMenuOnItemClick = True
        Me.rMenuShowBlockage.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuShowBlockage.Id = 18
        Me.rMenuShowBlockage.ImageOptions.Image = CType(resources.GetObject("rMenuShowBlockage.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuShowBlockage.ImageOptions.LargeImage = CType(resources.GetObject("rMenuShowBlockage.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuShowBlockage.Name = "rMenuShowBlockage"
        Me.rMenuShowBlockage.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem18
        '
        Me.BarButtonItem18.Caption = "Undock"
        Me.BarButtonItem18.Id = 19
        Me.BarButtonItem18.ImageOptions.Image = CType(resources.GetObject("BarButtonItem18.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem18.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem18.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem18.Name = "BarButtonItem18"
        Me.BarButtonItem18.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuOpenILD
        '
        Me.rMenuOpenILD.Caption = "Open ILD"
        Me.rMenuOpenILD.CloseRadialMenuOnItemClick = True
        Me.rMenuOpenILD.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuOpenILD.Id = 20
        Me.rMenuOpenILD.ImageOptions.Image = CType(resources.GetObject("rMenuOpenILD.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuOpenILD.ImageOptions.LargeImage = CType(resources.GetObject("rMenuOpenILD.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuOpenILD.Name = "rMenuOpenILD"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Clipboard"
        Me.BarSubItem1.Id = 21
        Me.BarSubItem1.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.rMenuCopyLoop), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem21)})
        Me.BarSubItem1.Name = "BarSubItem1"
        Me.BarSubItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuCopyLoop
        '
        Me.rMenuCopyLoop.Caption = "Copy Loops"
        Me.rMenuCopyLoop.CloseRadialMenuOnItemClick = True
        Me.rMenuCopyLoop.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuCopyLoop.Id = 22
        Me.rMenuCopyLoop.ImageOptions.Image = CType(resources.GetObject("rMenuCopyLoop.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuCopyLoop.ImageOptions.LargeImage = CType(resources.GetObject("rMenuCopyLoop.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuCopyLoop.Name = "rMenuCopyLoop"
        '
        'BarButtonItem21
        '
        Me.BarButtonItem21.Caption = "Copy Subsystems"
        Me.BarButtonItem21.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem21.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem21.Id = 23
        Me.BarButtonItem21.ImageOptions.Image = CType(resources.GetObject("BarButtonItem21.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem21.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem21.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem21.Name = "BarButtonItem21"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Save View"
        Me.BarButtonItem3.Id = 24
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Load View"
        Me.BarButtonItem4.Id = 25
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem22
        '
        Me.BarButtonItem22.Caption = "Print Preview"
        Me.BarButtonItem22.Id = 26
        Me.BarButtonItem22.ImageOptions.Image = CType(resources.GetObject("BarButtonItem22.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem22.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem22.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem22.Name = "BarButtonItem22"
        Me.BarButtonItem22.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderSubmitToQC
        '
        Me.rMenuSetFolderSubmitToQC.Caption = "Set Submitted To QC"
        Me.rMenuSetFolderSubmitToQC.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderSubmitToQC.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderSubmitToQC.Id = 28
        Me.rMenuSetFolderSubmitToQC.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderSubmitToQC.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderSubmitToQC.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderSubmitToQC.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderSubmitToQC.Name = "rMenuSetFolderSubmitToQC"
        '
        'BarButtonItem24
        '
        Me.BarButtonItem24.Caption = "Set Submitted To Precomm"
        Me.BarButtonItem24.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem24.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem24.Id = 29
        Me.BarButtonItem24.ImageOptions.Image = CType(resources.GetObject("BarButtonItem24.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem24.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem24.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem24.Name = "BarButtonItem24"
        '
        'rMenuSetFolderReturnFromQC
        '
        Me.rMenuSetFolderReturnFromQC.Caption = "Set Return From QC"
        Me.rMenuSetFolderReturnFromQC.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderReturnFromQC.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderReturnFromQC.Id = 30
        Me.rMenuSetFolderReturnFromQC.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderReturnFromQC.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderReturnFromQC.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderReturnFromQC.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderReturnFromQC.Name = "rMenuSetFolderReturnFromQC"
        Me.rMenuSetFolderReturnFromQC.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuLoopTasks
        '
        Me.rMenuLoopTasks.Caption = "Loop Tasks"
        Me.rMenuLoopTasks.CloseRadialMenuOnItemClick = True
        Me.rMenuLoopTasks.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuLoopTasks.Id = 31
        Me.rMenuLoopTasks.ImageOptions.Image = CType(resources.GetObject("rMenuLoopTasks.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuLoopTasks.ImageOptions.LargeImage = CType(resources.GetObject("rMenuLoopTasks.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuLoopTasks.Name = "rMenuLoopTasks"
        Me.rMenuLoopTasks.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderConsComplete
        '
        Me.rMenuSetFolderConsComplete.Caption = "Set As Construction Complete"
        Me.rMenuSetFolderConsComplete.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderConsComplete.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderConsComplete.Id = 32
        Me.rMenuSetFolderConsComplete.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderConsComplete.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderConsComplete.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderConsComplete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderConsComplete.Name = "rMenuSetFolderConsComplete"
        Me.rMenuSetFolderConsComplete.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Isolate"
        Me.BarButtonItem1.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem1.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem1.Id = 33
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuShare
        '
        Me.rMenuShare.Caption = "Share"
        Me.rMenuShare.CloseRadialMenuOnItemClick = True
        Me.rMenuShare.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuShare.Id = 34
        Me.rMenuShare.ImageOptions.Image = CType(resources.GetObject("rMenuShare.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuShare.ImageOptions.LargeImage = CType(resources.GetObject("rMenuShare.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuShare.Name = "rMenuShare"
        Me.rMenuShare.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Pending Tasks"
        Me.BarButtonItem2.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem2.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem2.Id = 35
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderConsTargetDate
        '
        Me.rMenuSetFolderConsTargetDate.Caption = "Set Const Target Date"
        Me.rMenuSetFolderConsTargetDate.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderConsTargetDate.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderConsTargetDate.Id = 36
        Me.rMenuSetFolderConsTargetDate.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderConsTargetDate.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderConsTargetDate.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderConsTargetDate.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderConsTargetDate.Name = "rMenuSetFolderConsTargetDate"
        Me.rMenuSetFolderConsTargetDate.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'rMenuSetFolderFailed
        '
        Me.rMenuSetFolderFailed.Caption = "Set Loop Failed"
        Me.rMenuSetFolderFailed.CloseRadialMenuOnItemClick = True
        Me.rMenuSetFolderFailed.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.rMenuSetFolderFailed.Id = 37
        Me.rMenuSetFolderFailed.ImageOptions.Image = CType(resources.GetObject("rMenuSetFolderFailed.ImageOptions.Image"), System.Drawing.Image)
        Me.rMenuSetFolderFailed.ImageOptions.LargeImage = CType(resources.GetObject("rMenuSetFolderFailed.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.rMenuSetFolderFailed.Name = "rMenuSetFolderFailed"
        Me.rMenuSetFolderFailed.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Home"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuRefresh)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuFilter)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuExportToExcel)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuShare)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem16)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuShowBlockage)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuOpenILD)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarSubItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem22)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.rMenuLoopTasks)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Loop Folders Options"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4})
        Me.RibbonPage2.ImageOptions.Image = CType(resources.GetObject("RibbonPage2.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "View"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem18)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "Loops View"
        '
        'rpConstruction
        '
        Me.rpConstruction.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3})
        Me.rpConstruction.ImageOptions.Image = CType(resources.GetObject("rpConstruction.ImageOptions.Image"), System.Drawing.Image)
        Me.rpConstruction.Name = "rpConstruction"
        Me.rpConstruction.Text = "Construction"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.rMenuSetFolderConsComplete)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.rMenuSetFolderConsTargetDate)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Construction"
        '
        'rpHandover
        '
        Me.rpHandover.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rgHandover})
        Me.rpHandover.ImageOptions.Image = CType(resources.GetObject("rpHandover.ImageOptions.Image"), System.Drawing.Image)
        Me.rpHandover.Name = "rpHandover"
        Me.rpHandover.Text = "Handover"
        Me.rpHandover.Visible = False
        '
        'rgHandover
        '
        Me.rgHandover.ItemLinks.Add(Me.rMenuSetFolderApproved)
        Me.rgHandover.Name = "rgHandover"
        Me.rgHandover.Text = "Handover Options"
        '
        'rpSupportTeam
        '
        Me.rpSupportTeam.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup2})
        Me.rpSupportTeam.ImageOptions.Image = CType(resources.GetObject("rpSupportTeam.ImageOptions.Image"), System.Drawing.Image)
        Me.rpSupportTeam.Name = "rpSupportTeam"
        Me.rpSupportTeam.Text = "Support Team"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.rMenuSetFolderPrinted)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.rMenuSetFolderSubmitToQC)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.rMenuSetFolderReturnFromQC)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem24)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Support Team"
        '
        'rpQC
        '
        Me.rpQC.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rgQC})
        Me.rpQC.ImageOptions.Image = CType(resources.GetObject("rpQC.ImageOptions.Image"), System.Drawing.Image)
        Me.rpQC.Name = "rpQC"
        Me.rpQC.Text = "QC"
        Me.rpQC.Visible = False
        '
        'rgQC
        '
        Me.rgQC.ItemLinks.Add(Me.rMenuSetFolderReleased)
        Me.rgQC.ItemLinks.Add(Me.rMenuSetFolderReady)
        Me.rgQC.ItemLinks.Add(Me.rMenuSetFolderSubmitToSupportTeam)
        Me.rgQC.Name = "rgQC"
        Me.rgQC.Text = "QC Options"
        '
        'rpPrecom
        '
        Me.rpPrecom.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rgPrecomm})
        Me.rpPrecom.ImageOptions.Image = CType(resources.GetObject("rpPrecom.ImageOptions.Image"), System.Drawing.Image)
        Me.rpPrecom.Name = "rpPrecom"
        Me.rpPrecom.Text = "Pre Commissioning"
        Me.rpPrecom.Visible = False
        '
        'rgPrecomm
        '
        Me.rgPrecomm.ItemLinks.Add(Me.rMenuSetFolderSubmitToPrecomm)
        Me.rgPrecomm.ItemLinks.Add(Me.rMenuSetFolderDone)
        Me.rgPrecomm.ItemLinks.Add(Me.rMenuSetFolderFailed)
        Me.rgPrecomm.Name = "rgPrecomm"
        Me.rgPrecomm.Text = "Precomm Options"
        '
        'rpBlockage
        '
        Me.rpBlockage.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup7})
        Me.rpBlockage.ImageOptions.Image = CType(resources.GetObject("rpBlockage.ImageOptions.Image"), System.Drawing.Image)
        Me.rpBlockage.Name = "rpBlockage"
        Me.rpBlockage.Text = "Blockages"
        Me.rpBlockage.Visible = False
        '
        'RibbonPageGroup7
        '
        Me.RibbonPageGroup7.ItemLinks.Add(Me.rMenuAddBlockage)
        Me.RibbonPageGroup7.Name = "RibbonPageGroup7"
        Me.RibbonPageGroup7.Text = "Blockages Options"
        '
        'grd
        '
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 110)
        Me.grd.MainView = Me.gv
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(1208, 594)
        Me.grd.TabIndex = 67
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
        Me.gv.Name = "gv"
        Me.gv.OptionsBehavior.Editable = False
        Me.gv.OptionsMenu.ShowConditionalFormattingItem = True
        Me.gv.OptionsSelection.MultiSelect = True
        Me.gv.OptionsView.AutoCalcPreviewLineCount = True
        Me.gv.OptionsView.ColumnAutoWidth = False
        Me.gv.OptionsView.ShowAutoFilterRow = True
        Me.gv.OptionsView.ShowFooter = True
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
        Me.rMenu.InnerRadius = 100
        Me.rMenu.ItemLinks.Add(Me.rMenuFilter)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem1)
        Me.rMenu.ItemLinks.Add(Me.rMenuShare)
        Me.rMenu.ItemLinks.Add(Me.rMenuRefresh)
        Me.rMenu.ItemLinks.Add(Me.rMenuLoopTasks)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem2)
        Me.rMenu.ItemLinks.Add(Me.rMenuOpenILD)
        Me.rMenu.ItemLinks.Add(Me.rMenuCopyLoop)
        Me.rMenu.ItemLinks.Add(Me.rMenuAddBlockage)
        Me.rMenu.ItemLinks.Add(Me.rMenuShowBlockage)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderApproved)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderPrinted)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderReady)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderReleased)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderDone)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderFailed)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderReturnFromQC)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderSubmitToPrecomm)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderSubmitToQC)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderSubmitToSupportTeam)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderConsComplete)
        Me.rMenu.ItemLinks.Add(Me.rMenuSetFolderConsTargetDate)
        Me.rMenu.Name = "rMenu"
        Me.rMenu.Ribbon = Me.RibbonControl1
        '
        'frmLoopFolders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1208, 704)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Image = CType(resources.GetObject("frmLoopFolders.IconOptions.Image"), System.Drawing.Image)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmLoopFolders.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmLoopFolders"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loop Folders"
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
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rMenuRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuFilter As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rMenuSetFolderPrinted As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderApproved As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpHandover As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rgHandover As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rMenuExportToExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents sveFle As SaveFileDialog
    Friend WithEvents rpQC As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rgQC As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rpPrecom As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rgPrecomm As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderSubmitToSupportTeam As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderReleased As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderReady As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderSubmitToPrecomm As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderDone As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuAddBlockage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpBlockage As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup7 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem16 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuShowBlockage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem18 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuOpenILD As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents rMenuCopyLoop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem21 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents BarButtonItem22 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents lblInfo As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents rpSupportTeam As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rMenuSetFolderSubmitToQC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem24 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderReturnFromQC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenu As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents rMenuLoopTasks As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderConsComplete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpConstruction As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuShare As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderConsTargetDate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenuSetFolderFailed As DevExpress.XtraBars.BarButtonItem
End Class
