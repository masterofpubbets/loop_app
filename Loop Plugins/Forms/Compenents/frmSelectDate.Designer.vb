<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectDate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectDate))
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.dte = New DevExpress.XtraEditors.DateEdit()
        Me.lblDate = New DevExpress.XtraEditors.LabelControl()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        CType(Me.dte.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(505, 203)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(219, 70)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Save Date"
        '
        'dte
        '
        Me.dte.EditValue = Nothing
        Me.dte.Location = New System.Drawing.Point(25, 100)
        Me.dte.Margin = New System.Windows.Forms.Padding(4)
        Me.dte.Name = "dte"
        Me.dte.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dte.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dte.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.dte.Size = New System.Drawing.Size(456, 22)
        Me.dte.TabIndex = 2
        '
        'lblDate
        '
        Me.lblDate.Appearance.Options.UseTextOptions = True
        Me.lblDate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDate.LineColor = System.Drawing.Color.Blue
        Me.lblDate.LineLocation = DevExpress.XtraEditors.LineLocation.Top
        Me.lblDate.LineVisible = True
        Me.lblDate.Location = New System.Drawing.Point(25, 130)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(4)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(456, 52)
        Me.lblDate.TabIndex = 4
        Me.lblDate.Text = "Select Date:"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(740, 75)
        '
        'frmSelectDate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(740, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.dte)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSelectDate.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSelectDate"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.dte.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dte As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblDate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
End Class
