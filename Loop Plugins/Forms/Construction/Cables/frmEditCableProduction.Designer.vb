<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditCableProduction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditCableProduction))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.lblTag = New DevExpress.XtraEditors.LabelControl()
        Me.txtMark1From = New DevExpress.XtraEditors.CalcEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMark1To = New DevExpress.XtraEditors.CalcEdit()
        Me.txtPercentage = New DevExpress.XtraEditors.CalcEdit()
        Me.lblOtherPercentage = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dteEdit = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtActualDrum = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMark1From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMark1To.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RibbonControl1.Size = New System.Drawing.Size(739, 60)
        '
        'lblTag
        '
        Me.lblTag.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTag.Appearance.Options.UseForeColor = True
        Me.lblTag.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTag.LineColor = System.Drawing.Color.DodgerBlue
        Me.lblTag.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.lblTag.LineVisible = True
        Me.lblTag.Location = New System.Drawing.Point(12, 86)
        Me.lblTag.Name = "lblTag"
        Me.lblTag.Size = New System.Drawing.Size(676, 43)
        Me.lblTag.TabIndex = 0
        Me.lblTag.Text = "LabelControl1"
        '
        'txtMark1From
        '
        Me.txtMark1From.Location = New System.Drawing.Point(212, 267)
        Me.txtMark1From.MenuManager = Me.RibbonControl1
        Me.txtMark1From.Name = "txtMark1From"
        Me.txtMark1From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtMark1From.Size = New System.Drawing.Size(118, 20)
        Me.txtMark1From.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Percentage:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Total Other Percentage:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 270)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mark 1 From:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineColor = System.Drawing.Color.Gray
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Top
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(79, 204)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(251, 28)
        Me.LabelControl1.TabIndex = 7
        Me.LabelControl1.Text = "Total:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mark 1 To:"
        '
        'txtMark1To
        '
        Me.txtMark1To.Location = New System.Drawing.Point(212, 307)
        Me.txtMark1To.MenuManager = Me.RibbonControl1
        Me.txtMark1To.Name = "txtMark1To"
        Me.txtMark1To.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtMark1To.Size = New System.Drawing.Size(118, 20)
        Me.txtMark1To.TabIndex = 4
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(208, 148)
        Me.txtPercentage.MenuManager = Me.RibbonControl1
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPercentage.Properties.MaskSettings.Set("mask", "P")
        Me.txtPercentage.Size = New System.Drawing.Size(122, 20)
        Me.txtPercentage.TabIndex = 0
        '
        'lblOtherPercentage
        '
        Me.lblOtherPercentage.Location = New System.Drawing.Point(209, 186)
        Me.lblOtherPercentage.Name = "lblOtherPercentage"
        Me.lblOtherPercentage.Size = New System.Drawing.Size(121, 14)
        Me.lblOtherPercentage.TabIndex = 1
        Me.lblOtherPercentage.Text = "0.0"
        Me.lblOtherPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.Location = New System.Drawing.Point(209, 212)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(121, 14)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.Text = "0.0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(209, 389)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(227, 16)
        Me.lblDate.TabIndex = 13
        Me.lblDate.Text = "Date:"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dteEdit
        '
        Me.dteEdit.EditValue = Nothing
        Me.dteEdit.Location = New System.Drawing.Point(451, 387)
        Me.dteEdit.MenuManager = Me.RibbonControl1
        Me.dteEdit.Name = "dteEdit"
        Me.dteEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent
        Me.dteEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.dteEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[False]
        Me.dteEdit.Size = New System.Drawing.Size(94, 20)
        Me.dteEdit.TabIndex = 6
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(551, 462)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(176, 54)
        Me.SimpleButton1.TabIndex = 8
        Me.SimpleButton1.Text = "Cancel"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(369, 462)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(176, 54)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = "Update"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(79, 353)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Actual Drum:"
        '
        'txtActualDrum
        '
        Me.txtActualDrum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualDrum.Location = New System.Drawing.Point(212, 350)
        Me.txtActualDrum.Name = "txtActualDrum"
        Me.txtActualDrum.Size = New System.Drawing.Size(333, 21)
        Me.txtActualDrum.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(79, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Date:"
        '
        'frmEditCableProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtActualDrum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.dteEdit)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblOtherPercentage)
        Me.Controls.Add(Me.txtPercentage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMark1To)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMark1From)
        Me.Controls.Add(Me.lblTag)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmEditCableProduction.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmEditCableProduction"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Cable Production"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMark1From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMark1To.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents lblTag As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMark1From As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMark1To As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents txtPercentage As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents lblOtherPercentage As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents dteEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As Label
    Friend WithEvents txtActualDrum As TextBox
    Friend WithEvents Label6 As Label
End Class
