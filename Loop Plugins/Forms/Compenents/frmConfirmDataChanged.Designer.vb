<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfirmDataChanged
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmDataChanged))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.grdPred = New DevExpress.XtraGrid.GridControl()
        Me.gvPred = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPred, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPred, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1200, 60)
        '
        'grdPred
        '
        Me.grdPred.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPred.Location = New System.Drawing.Point(12, 64)
        Me.grdPred.MainView = Me.gvPred
        Me.grdPred.Name = "grdPred"
        Me.grdPred.Size = New System.Drawing.Size(1174, 539)
        Me.grdPred.TabIndex = 72
        Me.grdPred.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvPred})
        '
        'gvPred
        '
        Me.gvPred.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.gvPred.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.gvPred.Appearance.EvenRow.Options.UseBackColor = True
        Me.gvPred.Appearance.EvenRow.Options.UseForeColor = True
        Me.gvPred.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gold
        Me.gvPred.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black
        Me.gvPred.Appearance.FocusedCell.Options.UseBackColor = True
        Me.gvPred.Appearance.FocusedCell.Options.UseForeColor = True
        Me.gvPred.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gold
        Me.gvPred.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.gvPred.Appearance.FocusedRow.Options.UseBackColor = True
        Me.gvPred.Appearance.FocusedRow.Options.UseForeColor = True
        Me.gvPred.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.gvPred.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.gvPred.Appearance.OddRow.Options.UseBackColor = True
        Me.gvPred.Appearance.OddRow.Options.UseForeColor = True
        Me.gvPred.Appearance.SelectedRow.BackColor = System.Drawing.Color.Gold
        Me.gvPred.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.gvPred.Appearance.SelectedRow.Options.UseBackColor = True
        Me.gvPred.Appearance.SelectedRow.Options.UseForeColor = True
        Me.gvPred.GridControl = Me.grdPred
        Me.gvPred.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Length", Nothing, """Scope: {0}"""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Pulled Lm", Nothing, """Pulled: {0}""")})
        Me.gvPred.Name = "gvPred"
        Me.gvPred.OptionsBehavior.Editable = False
        Me.gvPred.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gvPred.OptionsCustomization.AllowRowSizing = True
        Me.gvPred.OptionsMenu.ShowConditionalFormattingItem = True
        Me.gvPred.OptionsSelection.MultiSelect = True
        Me.gvPred.OptionsView.AutoCalcPreviewLineCount = True
        Me.gvPred.OptionsView.ColumnAutoWidth = False
        Me.gvPred.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gvPred.OptionsView.ShowAutoFilterRow = True
        Me.gvPred.OptionsView.ShowFooter = True
        Me.gvPred.OptionsView.ShowGroupedColumns = True
        Me.gvPred.OptionsView.ShowGroupPanelColumnsAsSingleRow = True
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(756, 648)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(140, 40)
        Me.SimpleButton3.TabIndex = 76
        Me.SimpleButton3.Text = "Apply Changes"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(902, 648)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(140, 40)
        Me.SimpleButton2.TabIndex = 75
        Me.SimpleButton2.Text = "Discard Changes"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(1048, 648)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(140, 40)
        Me.SimpleButton1.TabIndex = 78
        Me.SimpleButton1.Text = "Cancel"
        '
        'frmConfirmDataChanged
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.grdPred)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmConfirmDataChanged.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmConfirmDataChanged"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConfirmDataChanged"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPred, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPred, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents grdPred As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvPred As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
