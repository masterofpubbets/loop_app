<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateEICAWithHCS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateEICAWithHCS))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.ckSubsystem = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ckItemClosed = New DevExpress.XtraEditors.CheckEdit()
        Me.pbarSubsystem = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.pbarItemClosed = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.pbarITRs = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.pBarElements = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.ckITRs = New DevExpress.XtraEditors.CheckEdit()
        Me.ckElements = New DevExpress.XtraEditors.CheckEdit()
        Me.pbarLoopApproved = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.ckLoopApproved = New DevExpress.XtraEditors.CheckEdit()
        Me.picElements = New System.Windows.Forms.PictureBox()
        Me.picITRs = New System.Windows.Forms.PictureBox()
        Me.picSubsystem = New System.Windows.Forms.PictureBox()
        Me.picLoopApproved = New System.Windows.Forms.PictureBox()
        Me.picItemClosed = New System.Windows.Forms.PictureBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.picGroups = New System.Windows.Forms.PictureBox()
        Me.pbarGroups = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.ckGroups = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckSubsystem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckItemClosed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbarSubsystem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbarItemClosed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbarITRs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBarElements.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckITRs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckElements.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbarLoopApproved.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckLoopApproved.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picElements, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picITRs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSubsystem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLoopApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picItemClosed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbarGroups.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckGroups.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(804, 58)
        '
        'ckSubsystem
        '
        Me.ckSubsystem.Location = New System.Drawing.Point(72, 296)
        Me.ckSubsystem.MenuManager = Me.RibbonControl1
        Me.ckSubsystem.Name = "ckSubsystem"
        Me.ckSubsystem.Properties.Caption = "Subsystem"
        Me.ckSubsystem.Size = New System.Drawing.Size(112, 20)
        Me.ckSubsystem.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineColor = System.Drawing.Color.SteelBlue
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(31, 93)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(735, 31)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Update Options"
        '
        'ckItemClosed
        '
        Me.ckItemClosed.Location = New System.Drawing.Point(72, 335)
        Me.ckItemClosed.MenuManager = Me.RibbonControl1
        Me.ckItemClosed.Name = "ckItemClosed"
        Me.ckItemClosed.Properties.Caption = "Items Closed"
        Me.ckItemClosed.Size = New System.Drawing.Size(112, 20)
        Me.ckItemClosed.TabIndex = 5
        '
        'pbarSubsystem
        '
        Me.pbarSubsystem.EditValue = 0
        Me.pbarSubsystem.Location = New System.Drawing.Point(210, 295)
        Me.pbarSubsystem.MenuManager = Me.RibbonControl1
        Me.pbarSubsystem.Name = "pbarSubsystem"
        Me.pbarSubsystem.Size = New System.Drawing.Size(495, 17)
        Me.pbarSubsystem.TabIndex = 5
        Me.pbarSubsystem.Visible = False
        '
        'pbarItemClosed
        '
        Me.pbarItemClosed.EditValue = 0
        Me.pbarItemClosed.Location = New System.Drawing.Point(210, 336)
        Me.pbarItemClosed.MenuManager = Me.RibbonControl1
        Me.pbarItemClosed.Name = "pbarItemClosed"
        Me.pbarItemClosed.Size = New System.Drawing.Size(495, 17)
        Me.pbarItemClosed.TabIndex = 7
        Me.pbarItemClosed.Visible = False
        '
        'pbarITRs
        '
        Me.pbarITRs.EditValue = 0
        Me.pbarITRs.Location = New System.Drawing.Point(210, 180)
        Me.pbarITRs.MenuManager = Me.RibbonControl1
        Me.pbarITRs.Name = "pbarITRs"
        Me.pbarITRs.Size = New System.Drawing.Size(495, 17)
        Me.pbarITRs.TabIndex = 11
        Me.pbarITRs.Visible = False
        '
        'pBarElements
        '
        Me.pBarElements.EditValue = 0
        Me.pBarElements.Location = New System.Drawing.Point(210, 141)
        Me.pBarElements.MenuManager = Me.RibbonControl1
        Me.pBarElements.Name = "pBarElements"
        Me.pBarElements.Size = New System.Drawing.Size(495, 17)
        Me.pBarElements.TabIndex = 10
        Me.pBarElements.Visible = False
        '
        'ckITRs
        '
        Me.ckITRs.Location = New System.Drawing.Point(72, 179)
        Me.ckITRs.MenuManager = Me.RibbonControl1
        Me.ckITRs.Name = "ckITRs"
        Me.ckITRs.Properties.Caption = "ITRs"
        Me.ckITRs.Size = New System.Drawing.Size(112, 20)
        Me.ckITRs.TabIndex = 1
        '
        'ckElements
        '
        Me.ckElements.Location = New System.Drawing.Point(72, 142)
        Me.ckElements.MenuManager = Me.RibbonControl1
        Me.ckElements.Name = "ckElements"
        Me.ckElements.Properties.Caption = "Elements"
        Me.ckElements.Size = New System.Drawing.Size(112, 20)
        Me.ckElements.TabIndex = 0
        '
        'pbarLoopApproved
        '
        Me.pbarLoopApproved.EditValue = 0
        Me.pbarLoopApproved.Location = New System.Drawing.Point(210, 258)
        Me.pbarLoopApproved.MenuManager = Me.RibbonControl1
        Me.pbarLoopApproved.Name = "pbarLoopApproved"
        Me.pbarLoopApproved.Size = New System.Drawing.Size(495, 17)
        Me.pbarLoopApproved.TabIndex = 13
        Me.pbarLoopApproved.Visible = False
        '
        'ckLoopApproved
        '
        Me.ckLoopApproved.Location = New System.Drawing.Point(72, 257)
        Me.ckLoopApproved.MenuManager = Me.RibbonControl1
        Me.ckLoopApproved.Name = "ckLoopApproved"
        Me.ckLoopApproved.Properties.Caption = "Loop Approved"
        Me.ckLoopApproved.Size = New System.Drawing.Size(112, 20)
        Me.ckLoopApproved.TabIndex = 3
        '
        'picElements
        '
        Me.picElements.Image = Global.EEICA.My.Resources.Resources.ok_svgrepo_com
        Me.picElements.Location = New System.Drawing.Point(45, 141)
        Me.picElements.Name = "picElements"
        Me.picElements.Size = New System.Drawing.Size(20, 20)
        Me.picElements.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picElements.TabIndex = 21
        Me.picElements.TabStop = False
        Me.picElements.Visible = False
        '
        'picITRs
        '
        Me.picITRs.Image = Global.EEICA.My.Resources.Resources.ok_svgrepo_com
        Me.picITRs.Location = New System.Drawing.Point(45, 179)
        Me.picITRs.Name = "picITRs"
        Me.picITRs.Size = New System.Drawing.Size(20, 20)
        Me.picITRs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picITRs.TabIndex = 23
        Me.picITRs.TabStop = False
        Me.picITRs.Visible = False
        '
        'picSubsystem
        '
        Me.picSubsystem.Image = Global.EEICA.My.Resources.Resources.ok_svgrepo_com
        Me.picSubsystem.Location = New System.Drawing.Point(45, 295)
        Me.picSubsystem.Name = "picSubsystem"
        Me.picSubsystem.Size = New System.Drawing.Size(20, 20)
        Me.picSubsystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSubsystem.TabIndex = 25
        Me.picSubsystem.TabStop = False
        Me.picSubsystem.Visible = False
        '
        'picLoopApproved
        '
        Me.picLoopApproved.Image = Global.EEICA.My.Resources.Resources.ok_svgrepo_com
        Me.picLoopApproved.Location = New System.Drawing.Point(45, 257)
        Me.picLoopApproved.Name = "picLoopApproved"
        Me.picLoopApproved.Size = New System.Drawing.Size(20, 20)
        Me.picLoopApproved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLoopApproved.TabIndex = 24
        Me.picLoopApproved.TabStop = False
        Me.picLoopApproved.Visible = False
        '
        'picItemClosed
        '
        Me.picItemClosed.Image = Global.EEICA.My.Resources.Resources.ok_svgrepo_com
        Me.picItemClosed.Location = New System.Drawing.Point(45, 335)
        Me.picItemClosed.Name = "picItemClosed"
        Me.picItemClosed.Size = New System.Drawing.Size(20, 20)
        Me.picItemClosed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picItemClosed.TabIndex = 26
        Me.picItemClosed.TabStop = False
        Me.picItemClosed.Visible = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(603, 640)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton1.TabIndex = 10
        Me.SimpleButton1.Text = "Cancel"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(408, 640)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton2.TabIndex = 9
        Me.SimpleButton2.Text = "Start"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(213, 640)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton3.TabIndex = 8
        Me.SimpleButton3.Text = "HCS Connection Settings"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(45, 383)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(91, 28)
        Me.SimpleButton4.TabIndex = 6
        Me.SimpleButton4.Text = "Select All"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.Location = New System.Drawing.Point(142, 383)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(91, 28)
        Me.SimpleButton5.TabIndex = 7
        Me.SimpleButton5.Text = "Select None"
        '
        'picGroups
        '
        Me.picGroups.Image = Global.EEICA.My.Resources.Resources.ok_svgrepo_com
        Me.picGroups.Location = New System.Drawing.Point(45, 219)
        Me.picGroups.Name = "picGroups"
        Me.picGroups.Size = New System.Drawing.Size(20, 20)
        Me.picGroups.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picGroups.TabIndex = 36
        Me.picGroups.TabStop = False
        Me.picGroups.Visible = False
        '
        'pbarGroups
        '
        Me.pbarGroups.EditValue = 0
        Me.pbarGroups.Location = New System.Drawing.Point(210, 220)
        Me.pbarGroups.MenuManager = Me.RibbonControl1
        Me.pbarGroups.Name = "pbarGroups"
        Me.pbarGroups.Size = New System.Drawing.Size(495, 17)
        Me.pbarGroups.TabIndex = 35
        Me.pbarGroups.Visible = False
        '
        'ckGroups
        '
        Me.ckGroups.Location = New System.Drawing.Point(72, 219)
        Me.ckGroups.MenuManager = Me.RibbonControl1
        Me.ckGroups.Name = "ckGroups"
        Me.ckGroups.Properties.Caption = "Groups"
        Me.ckGroups.Size = New System.Drawing.Size(112, 20)
        Me.ckGroups.TabIndex = 2
        '
        'frmUpdateEICAWithHCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 701)
        Me.ControlBox = False
        Me.Controls.Add(Me.picGroups)
        Me.Controls.Add(Me.pbarGroups)
        Me.Controls.Add(Me.ckGroups)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.picItemClosed)
        Me.Controls.Add(Me.picSubsystem)
        Me.Controls.Add(Me.picLoopApproved)
        Me.Controls.Add(Me.picITRs)
        Me.Controls.Add(Me.picElements)
        Me.Controls.Add(Me.pbarLoopApproved)
        Me.Controls.Add(Me.ckLoopApproved)
        Me.Controls.Add(Me.pbarITRs)
        Me.Controls.Add(Me.pBarElements)
        Me.Controls.Add(Me.ckITRs)
        Me.Controls.Add(Me.ckElements)
        Me.Controls.Add(Me.pbarItemClosed)
        Me.Controls.Add(Me.pbarSubsystem)
        Me.Controls.Add(Me.ckItemClosed)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.ckSubsystem)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmUpdateEICAWithHCS.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmUpdateEICAWithHCS"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update EICA With HCS"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckSubsystem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckItemClosed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbarSubsystem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbarItemClosed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbarITRs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBarElements.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckITRs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckElements.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbarLoopApproved.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckLoopApproved.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picElements, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picITRs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSubsystem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLoopApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picItemClosed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbarGroups.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckGroups.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents ckSubsystem As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ckItemClosed As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pbarSubsystem As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents pbarItemClosed As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents pbarITRs As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents pBarElements As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents ckITRs As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckElements As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pbarLoopApproved As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents ckLoopApproved As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents picElements As PictureBox
    Friend WithEvents picITRs As PictureBox
    Friend WithEvents picSubsystem As PictureBox
    Friend WithEvents picLoopApproved As PictureBox
    Friend WithEvents picItemClosed As PictureBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picGroups As PictureBox
    Friend WithEvents pbarGroups As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents ckGroups As DevExpress.XtraEditors.CheckEdit
End Class
