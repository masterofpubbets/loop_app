<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoopConstraints2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoopConstraints2))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup5 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        Me.sveFle = New System.Windows.Forms.SaveFileDialog()
        Me.grd = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rMenu = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem3, Me.BarButtonItem6, Me.BarSubItem1, Me.BarButtonItem7, Me.BarButtonItem8, Me.BarSubItem2, Me.BarButtonItem9})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl1.MaxItemId = 19
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1200, 110)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Refresh"
        Me.BarButtonItem1.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem1.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Filter"
        Me.BarButtonItem4.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem4.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem4.Id = 8
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Export To Excel"
        Me.BarButtonItem5.Id = 9
        Me.BarButtonItem5.ImageOptions.Image = CType(resources.GetObject("BarButtonItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Close Blockage"
        Me.BarButtonItem3.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem3.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem3.Id = 11
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "Re-Assign Responsible"
        Me.BarButtonItem6.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem6.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem6.Id = 12
        Me.BarButtonItem6.ImageOptions.Image = CType(resources.GetObject("BarButtonItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem6.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem6.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem6.Name = "BarButtonItem6"
        Me.BarButtonItem6.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Comments"
        Me.BarSubItem1.Id = 14
        Me.BarSubItem1.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem7), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem8)})
        Me.BarSubItem1.Name = "BarSubItem1"
        Me.BarSubItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "Add"
        Me.BarButtonItem7.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem7.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem7.Id = 15
        Me.BarButtonItem7.ImageOptions.Image = CType(resources.GetObject("BarButtonItem7.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem7.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem7.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Delete"
        Me.BarButtonItem8.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem8.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem8.Id = 16
        Me.BarButtonItem8.ImageOptions.Image = CType(resources.GetObject("BarButtonItem8.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem8.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem8.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem8.Name = "BarButtonItem8"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "Clipboard"
        Me.BarSubItem2.Id = 17
        Me.BarSubItem2.ImageOptions.Image = CType(resources.GetObject("BarSubItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem9)})
        Me.BarSubItem2.Name = "BarSubItem2"
        Me.BarSubItem2.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "Copy Folder Tag"
        Me.BarButtonItem9.CloseRadialMenuOnItemClick = True
        Me.BarButtonItem9.CloseSubMenuOnClickMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem9.Id = 18
        Me.BarButtonItem9.ImageOptions.Image = CType(resources.GetObject("BarButtonItem9.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem9.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem9.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4, Me.RibbonPageGroup5})
        Me.RibbonPage2.ImageOptions.Image = CType(resources.GetObject("RibbonPage2.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Home"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem5)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarSubItem2)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "File Options"
        '
        'RibbonPageGroup5
        '
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BarButtonItem6)
        Me.RibbonPageGroup5.ItemLinks.Add(Me.BarSubItem1)
        Me.RibbonPageGroup5.Name = "RibbonPageGroup5"
        Me.RibbonPageGroup5.Text = "Blockages Options"
        '
        'opnFle
        '
        Me.opnFle.Filter = "Excel Workbook 2010|*.xlsx|Excel Workbook 2003|*.xls"
        '
        'sveFle
        '
        Me.sveFle.Filter = "Excel File|*.xlsx"
        '
        'grd
        '
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grd.Location = New System.Drawing.Point(0, 110)
        Me.grd.MainView = Me.gv
        Me.grd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.grd.MenuManager = Me.RibbonControl1
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(1200, 590)
        Me.grd.TabIndex = 8
        Me.grd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv})
        '
        'gv
        '
        Me.gv.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gray
        Me.gv.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Gray
        Me.gv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.gv.Appearance.FocusedCell.Options.UseBackColor = True
        Me.gv.Appearance.FocusedCell.Options.UseForeColor = True
        Me.gv.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gray
        Me.gv.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Gray
        Me.gv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White
        Me.gv.Appearance.FocusedRow.Options.UseBackColor = True
        Me.gv.Appearance.FocusedRow.Options.UseForeColor = True
        Me.gv.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Maroon
        Me.gv.Appearance.GroupFooter.Options.UseForeColor = True
        Me.gv.Appearance.SelectedRow.BackColor = System.Drawing.Color.Gray
        Me.gv.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Gray
        Me.gv.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.gv.Appearance.SelectedRow.Options.UseBackColor = True
        Me.gv.Appearance.SelectedRow.Options.UseForeColor = True
        Me.gv.AppearancePrint.Preview.ForeColor = System.Drawing.Color.Black
        Me.gv.AppearancePrint.Preview.Options.UseForeColor = True
        Me.gv.DetailHeight = 431
        Me.gv.GridControl = Me.grd
        Me.gv.Name = "gv"
        Me.gv.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsBehavior.Editable = False
        Me.gv.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm
        Me.gv.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gv.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted
        Me.gv.OptionsFind.AlwaysVisible = True
        Me.gv.OptionsMenu.ShowConditionalFormattingItem = True
        Me.gv.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.gv.OptionsPrint.AllowMultilineHeaders = True
        Me.gv.OptionsPrint.EnableAppearanceEvenRow = True
        Me.gv.OptionsPrint.EnableAppearanceOddRow = True
        Me.gv.OptionsSelection.MultiSelect = True
        Me.gv.OptionsView.ShowAutoFilterRow = True
        Me.gv.OptionsView.ShowFooter = True
        Me.gv.OptionsView.ShowGroupedColumns = True
        '
        'rMenu
        '
        Me.rMenu.AutoExpand = True
        Me.rMenu.Glyph = CType(resources.GetObject("rMenu.Glyph"), System.Drawing.Image)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem3)
        Me.rMenu.ItemLinks.Add(Me.BarSubItem1)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem4)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem6)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem1)
        Me.rMenu.ItemLinks.Add(Me.BarButtonItem9)
        Me.rMenu.Name = "rMenu"
        Me.rMenu.Ribbon = Me.RibbonControl1
        '
        'frmLoopConstraints2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Image = CType(resources.GetObject("frmLoopConstraints2.IconOptions.Image"), System.Drawing.Image)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmLoopConstraints2.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLoopConstraints2"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loops Blockages"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents sveFle As SaveFileDialog
    Friend WithEvents grd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup5 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rMenu As DevExpress.XtraBars.Ribbon.RadialMenu
End Class
