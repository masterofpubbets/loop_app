﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrays
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrays))
        Dim SplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem10 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem11 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem12 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem13 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem14 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpProduction = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpEngineering = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.grd = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.sveFle = New System.Windows.Forms.SaveFileDialog()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(26, 24, 26, 24)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarButtonItem5, Me.BarButtonItem6, Me.BarButtonItem7, Me.BarButtonItem8, Me.BarButtonItem9, Me.BarButtonItem10, Me.BarSubItem1, Me.BarButtonItem11, Me.BarButtonItem12, Me.BarButtonItem13, Me.BarButtonItem14})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonControl1.MaxItemId = 16
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsMenuMinWidth = 283
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage2, Me.RibbonPage1, Me.rpEngineering, Me.RibbonPage3})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1216, 110)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Refresh"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Filter"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
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
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Copy Selected Tags"
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.ImageOptions.Image = CType(resources.GetObject("BarButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        Me.BarButtonItem4.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem5
        '
        Me.BarButtonItem5.Caption = "Set Partial Qnty Done"
        Me.BarButtonItem5.Id = 5
        Me.BarButtonItem5.ImageOptions.Image = CType(resources.GetObject("BarButtonItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem5.Name = "BarButtonItem5"
        Me.BarButtonItem5.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem6
        '
        Me.BarButtonItem6.Caption = "Set Whole Tray As Done"
        Me.BarButtonItem6.Id = 6
        Me.BarButtonItem6.ImageOptions.Image = CType(resources.GetObject("BarButtonItem6.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem6.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem6.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem6.Name = "BarButtonItem6"
        Me.BarButtonItem6.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem7
        '
        Me.BarButtonItem7.Caption = "Set Cummlative % Done"
        Me.BarButtonItem7.Id = 7
        Me.BarButtonItem7.ImageOptions.Image = CType(resources.GetObject("BarButtonItem7.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem7.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem7.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem7.Name = "BarButtonItem7"
        Me.BarButtonItem7.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Caption = "Save View"
        Me.BarButtonItem8.Id = 8
        Me.BarButtonItem8.ImageOptions.Image = CType(resources.GetObject("BarButtonItem8.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem8.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem8.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem8.Name = "BarButtonItem8"
        '
        'BarButtonItem9
        '
        Me.BarButtonItem9.Caption = "Load View"
        Me.BarButtonItem9.Id = 9
        Me.BarButtonItem9.ImageOptions.Image = CType(resources.GetObject("BarButtonItem9.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem9.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem9.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'BarButtonItem10
        '
        Me.BarButtonItem10.Caption = "Undock"
        Me.BarButtonItem10.Id = 10
        Me.BarButtonItem10.ImageOptions.Image = CType(resources.GetObject("BarButtonItem10.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem10.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem10.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem10.Name = "BarButtonItem10"
        Me.BarButtonItem10.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "Resources"
        Me.BarSubItem1.Id = 11
        Me.BarSubItem1.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem11), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem12)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarButtonItem11
        '
        Me.BarButtonItem11.Caption = "Assign"
        Me.BarButtonItem11.Id = 12
        Me.BarButtonItem11.ImageOptions.Image = CType(resources.GetObject("BarButtonItem11.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem11.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem11.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem11.Name = "BarButtonItem11"
        '
        'BarButtonItem12
        '
        Me.BarButtonItem12.Caption = "Clear"
        Me.BarButtonItem12.Id = 13
        Me.BarButtonItem12.ImageOptions.Image = CType(resources.GetObject("BarButtonItem12.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem12.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem12.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem12.Name = "BarButtonItem12"
        '
        'BarButtonItem13
        '
        Me.BarButtonItem13.Caption = "Show Resources"
        Me.BarButtonItem13.Id = 14
        Me.BarButtonItem13.ImageOptions.Image = CType(resources.GetObject("BarButtonItem13.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem13.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem13.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem13.Name = "BarButtonItem13"
        Me.BarButtonItem13.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem14
        '
        Me.BarButtonItem14.Caption = "Print Preview"
        Me.BarButtonItem14.Id = 15
        Me.BarButtonItem14.ImageOptions.Image = CType(resources.GetObject("BarButtonItem14.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem14.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem14.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem14.Name = "BarButtonItem14"
        Me.BarButtonItem14.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup4})
        Me.RibbonPage2.ImageOptions.Image = CType(resources.GetObject("RibbonPage2.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "Home"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem3)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem13)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.BarButtonItem14)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "Tray Options"
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
        Me.rpProduction.ItemLinks.Add(Me.BarButtonItem5)
        Me.rpProduction.ItemLinks.Add(Me.BarButtonItem7)
        Me.rpProduction.ItemLinks.Add(Me.BarButtonItem6)
        Me.rpProduction.Name = "rpProduction"
        Me.rpProduction.Text = "Production"
        '
        'rpEngineering
        '
        Me.rpEngineering.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3})
        Me.rpEngineering.ImageOptions.Image = CType(resources.GetObject("rpEngineering.ImageOptions.Image"), System.Drawing.Image)
        Me.rpEngineering.Name = "rpEngineering"
        Me.rpEngineering.Text = "Engineering"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.BarSubItem1)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Engineering"
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
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem10)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem8)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem9)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Tray View"
        '
        'grd
        '
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 110)
        Me.grd.MainView = Me.gv
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(1216, 458)
        Me.grd.TabIndex = 69
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
        Me.gv.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Length", Nothing, """Scope: {0}"""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total Qnty", Nothing, """Done: {0}""", "")})
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
        'SplashScreenManager
        '
        SplashScreenManager.ClosingDelay = 500
        '
        'frmTrays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1216, 568)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Image = Global.EEICA.My.Resources.Resources.trays32
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmTrays"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trays"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents sveFle As SaveFileDialog
    Friend WithEvents rpProduction As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem10 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem11 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem12 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpEngineering As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem13 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem14 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class
