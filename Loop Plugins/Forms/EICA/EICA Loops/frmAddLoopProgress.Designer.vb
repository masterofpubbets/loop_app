<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddLoopProgress
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
        Dim DockingContainer2 As DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer = New DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddLoopProgress))
        Me.DocumentGroup1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(Me.components)
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.TabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.ckOverride = New System.Windows.Forms.CheckBox()
        Me.pBar = New DevExpress.XtraEditors.ProgressBarControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Document1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(Me.components)
        Me.DockPanel2_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DockPanel2 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBarControl2 = New DevExpress.XtraEditors.ProgressBarControl()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        CType(Me.DocumentGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Document1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel2_Container.SuspendLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel2.SuspendLayout()
        CType(Me.ProgressBarControl2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'DocumentManager1
        '
        Me.DocumentManager1.ContainerControl = Me
        Me.DocumentManager1.View = Me.TabbedView1
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView1})
        '
        'TabbedView1
        '
        Me.TabbedView1.DocumentGroups.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup() {Me.DocumentGroup1})
        DockingContainer2.Element = Me.DocumentGroup1
        Me.TabbedView1.RootContainer.Nodes.AddRange(New DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer() {DockingContainer2})
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(999, 58)
        '
        'ckOverride
        '
        Me.ckOverride.AutoSize = True
        Me.ckOverride.Location = New System.Drawing.Point(659, 80)
        Me.ckOverride.Margin = New System.Windows.Forms.Padding(4)
        Me.ckOverride.Name = "ckOverride"
        Me.ckOverride.Size = New System.Drawing.Size(145, 17)
        Me.ckOverride.TabIndex = 7
        Me.ckOverride.Text = "Overwrite Existing Loops"
        Me.ckOverride.UseVisualStyleBackColor = True
        '
        'pBar
        '
        Me.pBar.Location = New System.Drawing.Point(10, 4)
        Me.pBar.Margin = New System.Windows.Forms.Padding(4)
        Me.pBar.Name = "pBar"
        Me.pBar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pBar.Properties.ShowTitle = True
        Me.pBar.Properties.StartColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pBar.Size = New System.Drawing.Size(1178, 23)
        Me.pBar.TabIndex = 6
        Me.pBar.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(812, 61)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(184, 53)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Save New Loops"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(700, 61)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(184, 53)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "Back"
        '
        'Document1
        '
        Me.Document1.Caption = "New Loops"
        Me.Document1.ControlName = "DockPanel2"
        Me.Document1.FloatLocation = New System.Drawing.Point(1920, 0)
        Me.Document1.FloatSize = New System.Drawing.Size(200, 200)
        '
        'DockPanel2_Container
        '
        Me.DockPanel2_Container.Controls.Add(Me.CheckBox1)
        Me.DockPanel2_Container.Controls.Add(Me.ProgressBarControl1)
        Me.DockPanel2_Container.Controls.Add(Me.SimpleButton3)
        Me.DockPanel2_Container.Controls.Add(Me.SimpleButton4)
        Me.DockPanel2_Container.Controls.Add(Me.GridControl2)
        Me.DockPanel2_Container.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel2_Container.Name = "DockPanel2_Container"
        Me.DockPanel2_Container.Size = New System.Drawing.Size(1268, 638)
        Me.DockPanel2_Container.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(694, 340)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(142, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "Overwrite Existing Loops"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Location = New System.Drawing.Point(45, 264)
        Me.ProgressBarControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.ProgressBarControl1.Properties.ShowTitle = True
        Me.ProgressBarControl1.Properties.StartColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ProgressBarControl1.Size = New System.Drawing.Size(1178, 23)
        Me.ProgressBarControl1.TabIndex = 11
        Me.ProgressBarControl1.Visible = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(847, 321)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(184, 53)
        Me.SimpleButton3.TabIndex = 10
        Me.SimpleButton3.Text = "Save New Loops"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(1039, 321)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(184, 53)
        Me.SimpleButton4.TabIndex = 9
        Me.SimpleButton4.Text = "Back"
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(30, 36)
        Me.GridControl2.MainView = Me.GridView3
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1137, 389)
        Me.GridControl2.TabIndex = 8
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Maroon
        Me.GridView3.Appearance.GroupFooter.Options.UseForeColor = True
        Me.GridView3.AppearancePrint.Preview.ForeColor = System.Drawing.Color.Black
        Me.GridView3.AppearancePrint.Preview.Options.UseForeColor = True
        Me.GridView3.GridControl = Me.GridControl2
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm
        Me.GridView3.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.GridView3.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView3.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted
        Me.GridView3.OptionsFind.AlwaysVisible = True
        Me.GridView3.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GridView3.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView3.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView3.OptionsPrint.EnableAppearanceEvenRow = True
        Me.GridView3.OptionsPrint.EnableAppearanceOddRow = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView3.OptionsView.EnableAppearanceOddRow = True
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        Me.GridView3.OptionsView.ShowGroupedColumns = True
        '
        'DockPanel2
        '
        Me.DockPanel2.Controls.Add(Me.DockPanel2_Container)
        Me.DockPanel2.DockedAsTabbedDocument = True
        Me.DockPanel2.FloatLocation = New System.Drawing.Point(1920, 0)
        Me.DockPanel2.ID = New System.Guid("8df3bb84-d904-4cbe-b33f-26fb91cc05e6")
        Me.DockPanel2.Name = "DockPanel2"
        Me.DockPanel2.OriginalSize = New System.Drawing.Size(200, 200)
        Me.DockPanel2.Text = "New Loops"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.ImageOptions.Image = CType(resources.GetObject("SimpleButton6.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton6.Location = New System.Drawing.Point(1088, 659)
        Me.SimpleButton6.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(173, 53)
        Me.SimpleButton6.TabIndex = 14
        Me.SimpleButton6.Text = "Back"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.Location = New System.Drawing.Point(896, 659)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(173, 53)
        Me.SimpleButton5.TabIndex = 15
        Me.SimpleButton5.Text = "Save New Loops"
        '
        'ProgressBarControl2
        '
        Me.ProgressBarControl2.Location = New System.Drawing.Point(12, 672)
        Me.ProgressBarControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBarControl2.Name = "ProgressBarControl2"
        Me.ProgressBarControl2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.ProgressBarControl2.Properties.ShowTitle = True
        Me.ProgressBarControl2.Properties.StartColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ProgressBarControl2.Size = New System.Drawing.Size(696, 23)
        Me.ProgressBarControl2.TabIndex = 16
        Me.ProgressBarControl2.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(743, 678)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(145, 17)
        Me.CheckBox2.TabIndex = 17
        Me.CheckBox2.Text = "Overwrite Existing Loops"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'frmAddLoopProgress
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(999, 697)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.ProgressBarControl2)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.SimpleButton6)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("frmAddLoopProgress.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAddLoopProgress"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAddLoopProgress"
        CType(Me.DocumentGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Document1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel2_Container.ResumeLayout(False)
        Me.DockPanel2_Container.PerformLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel2.ResumeLayout(False)
        CType(Me.ProgressBarControl2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents ckOverride As CheckBox
    Friend WithEvents pBar As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DocumentGroup1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup
    Friend WithEvents Document1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.Document
    Friend WithEvents DockPanel2_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DockPanel2 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents ProgressBarControl2 As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
End Class
