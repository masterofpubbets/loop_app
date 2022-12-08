<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadHCSData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUploadHCSData))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemTrackBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.lblNoErr = New DevExpress.XtraBars.BarStaticItem()
        Me.lblErr = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.np = New DevExpress.XtraBars.Navigation.NavigationPane()
        Me.npElements = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtEleSheet = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblEle = New System.Windows.Forms.Label()
        Me.ckEle = New System.Windows.Forms.CheckBox()
        Me.npGroups = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtGroupSheet = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.ckGroup = New System.Windows.Forms.CheckBox()
        Me.npItems = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtItemsSheet = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.ckItems = New System.Windows.Forms.CheckBox()
        Me.npPunchs = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtPunchSheet = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPunch = New System.Windows.Forms.Label()
        Me.ckPunch = New System.Windows.Forms.CheckBox()
        Me.npSystems = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtSystemSheet = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSystem = New System.Windows.Forms.Label()
        Me.ckSystem = New System.Windows.Forms.CheckBox()
        Me.npSubsystems = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtSubsystemSheet = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSubsystem = New System.Windows.Forms.Label()
        Me.ckSubsystem = New System.Windows.Forms.CheckBox()
        Me.npTasks = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.txtTaskSheet = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTask = New System.Windows.Forms.Label()
        Me.ckTask = New System.Windows.Forms.CheckBox()
        Me.lblProcessStatus = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTables = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.np, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.np.SuspendLayout()
        Me.npElements.SuspendLayout()
        Me.npGroups.SuspendLayout()
        Me.npItems.SuspendLayout()
        Me.npPunchs.SuspendLayout()
        Me.npSystems.SuspendLayout()
        Me.npSubsystems.SuspendLayout()
        Me.npTasks.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarEditItem1, Me.lblNoErr, Me.lblErr})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.PageHeaderItemLinks.Add(Me.lblNoErr)
        Me.RibbonControl1.PageHeaderItemLinks.Add(Me.lblErr)
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTrackBar1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.Size = New System.Drawing.Size(1188, 102)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Start"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarEditItem1
        '
        Me.BarEditItem1.Caption = "Batch Size"
        Me.BarEditItem1.Edit = Me.RepositoryItemTrackBar1
        Me.BarEditItem1.EditWidth = 500
        Me.BarEditItem1.Id = 2
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'RepositoryItemTrackBar1
        '
        Me.RepositoryItemTrackBar1.LabelAppearance.Options.UseTextOptions = True
        Me.RepositoryItemTrackBar1.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RepositoryItemTrackBar1.Maximum = 20000
        Me.RepositoryItemTrackBar1.Minimum = 500
        Me.RepositoryItemTrackBar1.Name = "RepositoryItemTrackBar1"
        Me.RepositoryItemTrackBar1.ShowLabels = True
        Me.RepositoryItemTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'lblNoErr
        '
        Me.lblNoErr.Caption = "No Error"
        Me.lblNoErr.Id = 3
        Me.lblNoErr.ImageOptions.Image = CType(resources.GetObject("lblNoErr.ImageOptions.Image"), System.Drawing.Image)
        Me.lblNoErr.ImageOptions.LargeImage = CType(resources.GetObject("lblNoErr.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.lblNoErr.Name = "lblNoErr"
        Me.lblNoErr.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'lblErr
        '
        Me.lblErr.Caption = "Error"
        Me.lblErr.Id = 4
        Me.lblErr.Name = "lblErr"
        Me.lblErr.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.lblErr.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "HCS Restoring"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarEditItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "HCS Restoring"
        '
        'opnFle
        '
        Me.opnFle.Filter = "Excel 2016 File|*.xlsx|Excel Binary Files|*.xlsb"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 102)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.np)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblProcessStatus)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblTables)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1188, 467)
        Me.SplitContainer1.SplitterDistance = 814
        Me.SplitContainer1.TabIndex = 1
        '
        'np
        '
        Me.np.AppearanceButton.Normal.ForeColor = System.Drawing.Color.Gray
        Me.np.AppearanceButton.Normal.Options.UseForeColor = True
        Me.np.Controls.Add(Me.npElements)
        Me.np.Controls.Add(Me.npGroups)
        Me.np.Controls.Add(Me.npItems)
        Me.np.Controls.Add(Me.npPunchs)
        Me.np.Controls.Add(Me.npSystems)
        Me.np.Controls.Add(Me.npSubsystems)
        Me.np.Controls.Add(Me.npTasks)
        Me.np.Dock = System.Windows.Forms.DockStyle.Fill
        Me.np.Location = New System.Drawing.Point(0, 0)
        Me.np.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.np.Name = "np"
        Me.np.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.np.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.npElements, Me.npGroups, Me.npItems, Me.npPunchs, Me.npSystems, Me.npSubsystems, Me.npTasks})
        Me.np.RegularSize = New System.Drawing.Size(812, 465)
        Me.np.SelectedPage = Me.npGroups
        Me.np.Size = New System.Drawing.Size(812, 465)
        Me.np.TabIndex = 2
        '
        'npElements
        '
        Me.npElements.Caption = "Elements"
        Me.npElements.Controls.Add(Me.txtEleSheet)
        Me.npElements.Controls.Add(Me.Label2)
        Me.npElements.Controls.Add(Me.SimpleButton1)
        Me.npElements.Controls.Add(Me.lblEle)
        Me.npElements.Controls.Add(Me.ckEle)
        Me.npElements.ImageOptions.Image = CType(resources.GetObject("npElements.ImageOptions.Image"), System.Drawing.Image)
        Me.npElements.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npElements.Name = "npElements"
        Me.npElements.Size = New System.Drawing.Size(674, 395)
        '
        'txtEleSheet
        '
        Me.txtEleSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEleSheet.Location = New System.Drawing.Point(119, 321)
        Me.txtEleSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEleSheet.Name = "txtEleSheet"
        Me.txtEleSheet.Size = New System.Drawing.Size(503, 23)
        Me.txtEleSheet.TabIndex = 7
        Me.txtEleSheet.Text = "Sheet1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(33, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Sheet Name:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(36, 70)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Select Excel FIle"
        '
        'lblEle
        '
        Me.lblEle.Location = New System.Drawing.Point(33, 127)
        Me.lblEle.Name = "lblEle"
        Me.lblEle.Size = New System.Drawing.Size(595, 169)
        Me.lblEle.TabIndex = 4
        Me.lblEle.Text = "Select Excel FIle:"
        '
        'ckEle
        '
        Me.ckEle.AutoSize = True
        Me.ckEle.Location = New System.Drawing.Point(21, 22)
        Me.ckEle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckEle.Name = "ckEle"
        Me.ckEle.Size = New System.Drawing.Size(77, 21)
        Me.ckEle.TabIndex = 3
        Me.ckEle.Text = "Restore"
        Me.ckEle.UseVisualStyleBackColor = True
        '
        'npGroups
        '
        Me.npGroups.Caption = "Groups"
        Me.npGroups.Controls.Add(Me.txtGroupSheet)
        Me.npGroups.Controls.Add(Me.Label3)
        Me.npGroups.Controls.Add(Me.SimpleButton2)
        Me.npGroups.Controls.Add(Me.lblGroup)
        Me.npGroups.Controls.Add(Me.ckGroup)
        Me.npGroups.ImageOptions.Image = CType(resources.GetObject("npGroups.ImageOptions.Image"), System.Drawing.Image)
        Me.npGroups.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npGroups.Name = "npGroups"
        Me.npGroups.Size = New System.Drawing.Size(674, 395)
        '
        'txtGroupSheet
        '
        Me.txtGroupSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGroupSheet.Location = New System.Drawing.Point(119, 320)
        Me.txtGroupSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGroupSheet.Name = "txtGroupSheet"
        Me.txtGroupSheet.Size = New System.Drawing.Size(506, 23)
        Me.txtGroupSheet.TabIndex = 9
        Me.txtGroupSheet.Text = "Sheet1"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(33, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 25)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Sheet Name:"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(36, 74)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Select Excel FIle"
        '
        'lblGroup
        '
        Me.lblGroup.Location = New System.Drawing.Point(33, 130)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(595, 169)
        Me.lblGroup.TabIndex = 4
        Me.lblGroup.Text = "Select Excel FIle:"
        '
        'ckGroup
        '
        Me.ckGroup.AutoSize = True
        Me.ckGroup.Location = New System.Drawing.Point(21, 26)
        Me.ckGroup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckGroup.Name = "ckGroup"
        Me.ckGroup.Size = New System.Drawing.Size(77, 21)
        Me.ckGroup.TabIndex = 3
        Me.ckGroup.Text = "Restore"
        Me.ckGroup.UseVisualStyleBackColor = True
        '
        'npItems
        '
        Me.npItems.Caption = "Items"
        Me.npItems.Controls.Add(Me.txtItemsSheet)
        Me.npItems.Controls.Add(Me.Label4)
        Me.npItems.Controls.Add(Me.SimpleButton3)
        Me.npItems.Controls.Add(Me.lblItems)
        Me.npItems.Controls.Add(Me.ckItems)
        Me.npItems.ImageOptions.Image = CType(resources.GetObject("npItems.ImageOptions.Image"), System.Drawing.Image)
        Me.npItems.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npItems.Name = "npItems"
        Me.npItems.Size = New System.Drawing.Size(674, 395)
        '
        'txtItemsSheet
        '
        Me.txtItemsSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemsSheet.Location = New System.Drawing.Point(119, 307)
        Me.txtItemsSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtItemsSheet.Name = "txtItemsSheet"
        Me.txtItemsSheet.Size = New System.Drawing.Size(513, 23)
        Me.txtItemsSheet.TabIndex = 9
        Me.txtItemsSheet.Text = "Sheet1"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(33, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 25)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sheet Name:"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(36, 74)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton3.TabIndex = 5
        Me.SimpleButton3.Text = "Select Excel FIle"
        '
        'lblItems
        '
        Me.lblItems.Location = New System.Drawing.Point(33, 130)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(595, 169)
        Me.lblItems.TabIndex = 4
        Me.lblItems.Text = "Select Excel FIle:"
        '
        'ckItems
        '
        Me.ckItems.AutoSize = True
        Me.ckItems.Location = New System.Drawing.Point(21, 26)
        Me.ckItems.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckItems.Name = "ckItems"
        Me.ckItems.Size = New System.Drawing.Size(77, 21)
        Me.ckItems.TabIndex = 3
        Me.ckItems.Text = "Restore"
        Me.ckItems.UseVisualStyleBackColor = True
        '
        'npPunchs
        '
        Me.npPunchs.Caption = "Punchs"
        Me.npPunchs.Controls.Add(Me.txtPunchSheet)
        Me.npPunchs.Controls.Add(Me.Label5)
        Me.npPunchs.Controls.Add(Me.SimpleButton4)
        Me.npPunchs.Controls.Add(Me.lblPunch)
        Me.npPunchs.Controls.Add(Me.ckPunch)
        Me.npPunchs.ImageOptions.Image = CType(resources.GetObject("npPunchs.ImageOptions.Image"), System.Drawing.Image)
        Me.npPunchs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npPunchs.Name = "npPunchs"
        Me.npPunchs.Size = New System.Drawing.Size(674, 395)
        '
        'txtPunchSheet
        '
        Me.txtPunchSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPunchSheet.Location = New System.Drawing.Point(119, 341)
        Me.txtPunchSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPunchSheet.Name = "txtPunchSheet"
        Me.txtPunchSheet.Size = New System.Drawing.Size(509, 23)
        Me.txtPunchSheet.TabIndex = 9
        Me.txtPunchSheet.Text = "Sheet1"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(33, 344)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sheet Name:"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(36, 80)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton4.TabIndex = 5
        Me.SimpleButton4.Text = "Select Excel FIle"
        '
        'lblPunch
        '
        Me.lblPunch.Location = New System.Drawing.Point(33, 137)
        Me.lblPunch.Name = "lblPunch"
        Me.lblPunch.Size = New System.Drawing.Size(595, 169)
        Me.lblPunch.TabIndex = 4
        Me.lblPunch.Text = "Select Excel FIle:"
        '
        'ckPunch
        '
        Me.ckPunch.AutoSize = True
        Me.ckPunch.Location = New System.Drawing.Point(21, 32)
        Me.ckPunch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckPunch.Name = "ckPunch"
        Me.ckPunch.Size = New System.Drawing.Size(77, 21)
        Me.ckPunch.TabIndex = 3
        Me.ckPunch.Text = "Restore"
        Me.ckPunch.UseVisualStyleBackColor = True
        '
        'npSystems
        '
        Me.npSystems.Caption = "Systems"
        Me.npSystems.Controls.Add(Me.txtSystemSheet)
        Me.npSystems.Controls.Add(Me.Label6)
        Me.npSystems.Controls.Add(Me.SimpleButton5)
        Me.npSystems.Controls.Add(Me.lblSystem)
        Me.npSystems.Controls.Add(Me.ckSystem)
        Me.npSystems.ImageOptions.Image = CType(resources.GetObject("npSystems.ImageOptions.Image"), System.Drawing.Image)
        Me.npSystems.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npSystems.Name = "npSystems"
        Me.npSystems.Size = New System.Drawing.Size(674, 395)
        '
        'txtSystemSheet
        '
        Me.txtSystemSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSystemSheet.Location = New System.Drawing.Point(119, 325)
        Me.txtSystemSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSystemSheet.Name = "txtSystemSheet"
        Me.txtSystemSheet.Size = New System.Drawing.Size(504, 23)
        Me.txtSystemSheet.TabIndex = 9
        Me.txtSystemSheet.Text = "Sheet1"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(33, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 25)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Sheet Name:"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.Location = New System.Drawing.Point(36, 76)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton5.TabIndex = 5
        Me.SimpleButton5.Text = "Select Excel FIle"
        '
        'lblSystem
        '
        Me.lblSystem.Location = New System.Drawing.Point(33, 133)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(595, 169)
        Me.lblSystem.TabIndex = 4
        Me.lblSystem.Text = "Select Excel FIle:"
        '
        'ckSystem
        '
        Me.ckSystem.AutoSize = True
        Me.ckSystem.Location = New System.Drawing.Point(21, 28)
        Me.ckSystem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckSystem.Name = "ckSystem"
        Me.ckSystem.Size = New System.Drawing.Size(77, 21)
        Me.ckSystem.TabIndex = 3
        Me.ckSystem.Text = "Restore"
        Me.ckSystem.UseVisualStyleBackColor = True
        '
        'npSubsystems
        '
        Me.npSubsystems.Caption = "Subsystems"
        Me.npSubsystems.Controls.Add(Me.txtSubsystemSheet)
        Me.npSubsystems.Controls.Add(Me.Label7)
        Me.npSubsystems.Controls.Add(Me.SimpleButton6)
        Me.npSubsystems.Controls.Add(Me.lblSubsystem)
        Me.npSubsystems.Controls.Add(Me.ckSubsystem)
        Me.npSubsystems.ImageOptions.Image = CType(resources.GetObject("npSubsystems.ImageOptions.Image"), System.Drawing.Image)
        Me.npSubsystems.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npSubsystems.Name = "npSubsystems"
        Me.npSubsystems.Size = New System.Drawing.Size(674, 395)
        '
        'txtSubsystemSheet
        '
        Me.txtSubsystemSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubsystemSheet.Location = New System.Drawing.Point(119, 309)
        Me.txtSubsystemSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSubsystemSheet.Name = "txtSubsystemSheet"
        Me.txtSubsystemSheet.Size = New System.Drawing.Size(505, 23)
        Me.txtSubsystemSheet.TabIndex = 9
        Me.txtSubsystemSheet.Text = "Sheet1"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(33, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 25)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Sheet Name:"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.ImageOptions.Image = CType(resources.GetObject("SimpleButton6.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton6.Location = New System.Drawing.Point(36, 78)
        Me.SimpleButton6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton6.TabIndex = 5
        Me.SimpleButton6.Text = "Select Excel FIle"
        '
        'lblSubsystem
        '
        Me.lblSubsystem.Location = New System.Drawing.Point(33, 134)
        Me.lblSubsystem.Name = "lblSubsystem"
        Me.lblSubsystem.Size = New System.Drawing.Size(595, 169)
        Me.lblSubsystem.TabIndex = 4
        Me.lblSubsystem.Text = "Select Excel FIle:"
        '
        'ckSubsystem
        '
        Me.ckSubsystem.AutoSize = True
        Me.ckSubsystem.Location = New System.Drawing.Point(21, 30)
        Me.ckSubsystem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckSubsystem.Name = "ckSubsystem"
        Me.ckSubsystem.Size = New System.Drawing.Size(77, 21)
        Me.ckSubsystem.TabIndex = 3
        Me.ckSubsystem.Text = "Restore"
        Me.ckSubsystem.UseVisualStyleBackColor = True
        '
        'npTasks
        '
        Me.npTasks.Caption = "Tasks"
        Me.npTasks.Controls.Add(Me.txtTaskSheet)
        Me.npTasks.Controls.Add(Me.Label8)
        Me.npTasks.Controls.Add(Me.SimpleButton7)
        Me.npTasks.Controls.Add(Me.lblTask)
        Me.npTasks.Controls.Add(Me.ckTask)
        Me.npTasks.ImageOptions.Image = CType(resources.GetObject("npTasks.ImageOptions.Image"), System.Drawing.Image)
        Me.npTasks.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.npTasks.Name = "npTasks"
        Me.npTasks.Size = New System.Drawing.Size(674, 395)
        '
        'txtTaskSheet
        '
        Me.txtTaskSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaskSheet.Location = New System.Drawing.Point(119, 311)
        Me.txtTaskSheet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTaskSheet.Name = "txtTaskSheet"
        Me.txtTaskSheet.Size = New System.Drawing.Size(509, 23)
        Me.txtTaskSheet.TabIndex = 9
        Me.txtTaskSheet.Text = "Sheet1"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(33, 315)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 25)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Sheet Name:"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.ImageOptions.Image = CType(resources.GetObject("SimpleButton7.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton7.Location = New System.Drawing.Point(36, 81)
        Me.SimpleButton7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(170, 50)
        Me.SimpleButton7.TabIndex = 5
        Me.SimpleButton7.Text = "Select Excel FIle"
        '
        'lblTask
        '
        Me.lblTask.Location = New System.Drawing.Point(33, 138)
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(595, 169)
        Me.lblTask.TabIndex = 4
        Me.lblTask.Text = "Select Excel FIle:"
        '
        'ckTask
        '
        Me.ckTask.AutoSize = True
        Me.ckTask.Location = New System.Drawing.Point(21, 33)
        Me.ckTask.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ckTask.Name = "ckTask"
        Me.ckTask.Size = New System.Drawing.Size(77, 21)
        Me.ckTask.TabIndex = 3
        Me.ckTask.Text = "Restore"
        Me.ckTask.UseVisualStyleBackColor = True
        '
        'lblProcessStatus
        '
        Me.lblProcessStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProcessStatus.ForeColor = System.Drawing.Color.Black
        Me.lblProcessStatus.Location = New System.Drawing.Point(50, 302)
        Me.lblProcessStatus.Name = "lblProcessStatus"
        Me.lblProcessStatus.Size = New System.Drawing.Size(287, 143)
        Me.lblProcessStatus.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label9.Location = New System.Drawing.Point(10, 270)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 17)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Process Status"
        '
        'lblTables
        '
        Me.lblTables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTables.ForeColor = System.Drawing.Color.Black
        Me.lblTables.Location = New System.Drawing.Point(50, 47)
        Me.lblTables.Name = "lblTables"
        Me.lblTables.Size = New System.Drawing.Size(287, 177)
        Me.lblTables.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline)
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Tables To Restore"
        '
        'frmUploadHCSData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1188, 569)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmUploadHCSData.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmUploadHCSData"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload HCS Data"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.np, System.ComponentModel.ISupportInitialize).EndInit()
        Me.np.ResumeLayout(False)
        Me.npElements.ResumeLayout(False)
        Me.npElements.PerformLayout()
        Me.npGroups.ResumeLayout(False)
        Me.npGroups.PerformLayout()
        Me.npItems.ResumeLayout(False)
        Me.npItems.PerformLayout()
        Me.npPunchs.ResumeLayout(False)
        Me.npPunchs.PerformLayout()
        Me.npSystems.ResumeLayout(False)
        Me.npSystems.PerformLayout()
        Me.npSubsystems.ResumeLayout(False)
        Me.npSubsystems.PerformLayout()
        Me.npTasks.ResumeLayout(False)
        Me.npTasks.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemTrackBar1 As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents np As DevExpress.XtraBars.Navigation.NavigationPane
    Friend WithEvents npElements As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtEleSheet As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblEle As Label
    Friend WithEvents ckEle As CheckBox
    Friend WithEvents npGroups As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtGroupSheet As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblGroup As Label
    Friend WithEvents ckGroup As CheckBox
    Friend WithEvents npItems As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtItemsSheet As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblItems As Label
    Friend WithEvents ckItems As CheckBox
    Friend WithEvents npPunchs As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtPunchSheet As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPunch As Label
    Friend WithEvents ckPunch As CheckBox
    Friend WithEvents npSystems As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtSystemSheet As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSystem As Label
    Friend WithEvents ckSystem As CheckBox
    Friend WithEvents npSubsystems As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtSubsystemSheet As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSubsystem As Label
    Friend WithEvents ckSubsystem As CheckBox
    Friend WithEvents npTasks As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents txtTaskSheet As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTask As Label
    Friend WithEvents ckTask As CheckBox
    Friend WithEvents lblProcessStatus As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTables As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNoErr As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lblErr As DevExpress.XtraBars.BarStaticItem
End Class
