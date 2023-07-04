<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdateFolderSteps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateFolderSteps))
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.lblErr = New DevExpress.XtraBars.BarStaticItem()
        Me.lblNoErr = New DevExpress.XtraBars.BarStaticItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.sc = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.tre = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Folder Steps"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Update Folder Steps"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Update"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.lblErr, Me.lblNoErr})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl1.MaxItemId = 4
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.PageHeaderItemLinks.Add(Me.lblErr)
        Me.RibbonControl1.PageHeaderItemLinks.Add(Me.lblNoErr)
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.Size = New System.Drawing.Size(1198, 125)
        '
        'lblErr
        '
        Me.lblErr.Caption = "Error"
        Me.lblErr.Id = 2
        Me.lblErr.ImageOptions.Image = CType(resources.GetObject("lblErr.ImageOptions.Image"), System.Drawing.Image)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.lblErr.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        Me.lblErr.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        '
        'lblNoErr
        '
        Me.lblNoErr.Caption = "No Error"
        Me.lblNoErr.Id = 3
        Me.lblNoErr.ImageOptions.Image = CType(resources.GetObject("lblNoErr.ImageOptions.Image"), System.Drawing.Image)
        Me.lblNoErr.Name = "lblNoErr"
        Me.lblNoErr.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.lblNoErr.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 125)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.sc)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tre)
        Me.SplitContainer1.Size = New System.Drawing.Size(1198, 574)
        Me.SplitContainer1.SplitterDistance = 791
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 3
        '
        'sc
        '
        Me.sc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sc.Location = New System.Drawing.Point(0, 0)
        Me.sc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.sc.MenuManager = Me.RibbonControl1
        Me.sc.Name = "sc"
        Me.sc.Options.Behavior.Worksheet.Delete = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled
        Me.sc.Options.Behavior.Worksheet.Hide = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled
        Me.sc.Options.Behavior.Worksheet.Insert = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled
        Me.sc.Options.Behavior.Worksheet.Rename = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled
        Me.sc.Options.Behavior.Worksheet.TabColor = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled
        Me.sc.Options.Behavior.Worksheet.Unhide = DevExpress.XtraSpreadsheet.DocumentCapability.Disabled
        Me.sc.Options.Culture = New System.Globalization.CultureInfo("en-US")
        Me.sc.Size = New System.Drawing.Size(791, 574)
        Me.sc.TabIndex = 2
        Me.sc.Text = "SpreadsheetControl1"
        '
        'tre
        '
        Me.tre.BackColor = System.Drawing.Color.Gainsboro
        Me.tre.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tre.ImageIndex = 0
        Me.tre.ImageList = Me.ImageList1
        Me.tre.Location = New System.Drawing.Point(0, 0)
        Me.tre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tre.Name = "tre"
        Me.tre.SelectedImageIndex = 0
        Me.tre.Size = New System.Drawing.Size(402, 574)
        Me.tre.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ldfomkquxhasgowfrlss.png")
        Me.ImageList1.Images.SetKeyName(1, "MarkW.png")
        Me.ImageList1.Images.SetKeyName(2, "MarkR.png")
        Me.ImageList1.Images.SetKeyName(3, "toolsyellowicon.png")
        Me.ImageList1.Images.SetKeyName(4, "provider.png")
        Me.ImageList1.Images.SetKeyName(5, "catalog.png")
        Me.ImageList1.Images.SetKeyName(6, "d19dc4eb.png")
        Me.ImageList1.Images.SetKeyName(7, "CLONECD2.png")
        Me.ImageList1.Images.SetKeyName(8, "Gloss PNGDiscreet_3ds_max.png")
        Me.ImageList1.Images.SetKeyName(9, "provider.png")
        Me.ImageList1.Images.SetKeyName(10, "EXCEL97.png")
        Me.ImageList1.Images.SetKeyName(11, "book_education_literature_textbook_flat_icon-512.png")
        Me.ImageList1.Images.SetKeyName(12, "multifunction_printer.png")
        Me.ImageList1.Images.SetKeyName(13, "hands.jpg")
        Me.ImageList1.Images.SetKeyName(14, "Life_Cycle_Loop.png")
        Me.ImageList1.Images.SetKeyName(15, "verification.png")
        Me.ImageList1.Images.SetKeyName(16, "access_control.png")
        Me.ImageList1.Images.SetKeyName(17, "ldfomkquxhasgowfrlss.png")
        '
        'frmUpdateFolderSteps
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1198, 699)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("frmUpdateFolderSteps.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmUpdateFolderSteps"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Folder Steps"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents sc As DevExpress.XtraSpreadsheet.SpreadsheetControl
    Friend WithEvents lblErr As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents lblNoErr As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents tre As TreeView
    Friend WithEvents ImageList1 As ImageList
End Class
