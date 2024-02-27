<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNotifications
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotifications))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.grd = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.barBtnExport = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.CaptionBarItemLinks.Add(Me.barBtnExport)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.barBtnExport})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(800, 60)
        '
        'grd
        '
        Me.grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grd.Location = New System.Drawing.Point(0, 60)
        Me.grd.MainView = Me.gv
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(800, 390)
        Me.grd.TabIndex = 68
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
        'barBtnExport
        '
        Me.barBtnExport.Caption = "Export"
        Me.barBtnExport.Id = 2
        Me.barBtnExport.ImageOptions.Image = CType(resources.GetObject("barBtnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnExport.ImageOptions.LargeImage = CType(resources.GetObject("barBtnExport.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnExport.Name = "barBtnExport"
        '
        'frmNotifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmNotifications.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmNotifications"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notifications"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents barBtnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents grd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
End Class
