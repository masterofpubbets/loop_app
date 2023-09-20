<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmItemResource
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemResource))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.grd = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblItem = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAssign = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(952, 58)
        '
        'grd
        '
        Me.grd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grd.Location = New System.Drawing.Point(12, 138)
        Me.grd.MainView = Me.gv
        Me.grd.Name = "grd"
        Me.grd.Size = New System.Drawing.Size(928, 393)
        Me.grd.TabIndex = 72
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
        'lblItem
        '
        Me.lblItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblItem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblItem.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.lblItem.LineVisible = True
        Me.lblItem.Location = New System.Drawing.Point(12, 77)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(478, 39)
        Me.lblItem.TabIndex = 73
        Me.lblItem.Text = "LabelControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(799, 565)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(141, 48)
        Me.SimpleButton1.TabIndex = 75
        Me.SimpleButton1.Text = "Close"
        '
        'btnAssign
        '
        Me.btnAssign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAssign.ImageOptions.Image = CType(resources.GetObject("btnAssign.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAssign.Location = New System.Drawing.Point(358, 565)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(141, 48)
        Me.btnAssign.TabIndex = 79
        Me.btnAssign.Text = "Assign"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(652, 565)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(141, 48)
        Me.SimpleButton3.TabIndex = 78
        Me.SimpleButton3.Text = "Show Resource"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(505, 565)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(141, 48)
        Me.btnDelete.TabIndex = 80
        Me.btnDelete.Text = "Unassign"
        '
        'frmItemResource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 625)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.grd)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmItemResource.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmItemResource"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Resource"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents grd As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblItem As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAssign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
End Class
