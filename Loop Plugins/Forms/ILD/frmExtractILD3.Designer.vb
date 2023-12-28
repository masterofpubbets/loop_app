<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtractILD3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtractILD3))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSheetEnd = New EEICA.EAMS.Graphical.TextBoxFocusColor()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDesc3 = New EEICA.EAMS.Graphical.TextBoxFocusColor()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDesc2 = New EEICA.EAMS.Graphical.TextBoxFocusColor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesc1 = New EEICA.EAMS.Graphical.TextBoxFocusColor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLoopName = New EEICA.EAMS.Graphical.TextBoxFocusColor()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSPath = New System.Windows.Forms.Label()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.rtxt = New System.Windows.Forms.RichTextBox()
        Me.opnFile = New System.Windows.Forms.OpenFileDialog()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 2
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.Size = New System.Drawing.Size(1198, 108)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Start"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.ImageOptions.Image = CType(resources.GetObject("RibbonPage1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "ILD"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ImageOptions.Image = CType(resources.GetObject("RibbonPageGroup1.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "ILD Options"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 108)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblOp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtxt)
        Me.SplitContainer1.Size = New System.Drawing.Size(1198, 591)
        Me.SplitContainer1.SplitterDistance = 525
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 2
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(21, 506)
        Me.lblCount.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(460, 41)
        Me.lblCount.TabIndex = 91
        Me.lblCount.Text = "00"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCount.Visible = False
        '
        'lblOp
        '
        Me.lblOp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOp.ForeColor = System.Drawing.Color.DimGray
        Me.lblOp.Location = New System.Drawing.Point(24, 433)
        Me.lblOp.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(456, 73)
        Me.lblOp.TabIndex = 90
        Me.lblOp.Text = "Proccessing ILD"
        Me.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOp.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtSheetEnd)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtDesc3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtDesc2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtDesc1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtLoopName)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(14, 205)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(492, 183)
        Me.Panel2.TabIndex = 9
        '
        'txtSheetEnd
        '
        Me.txtSheetEnd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSheetEnd.BackColor = System.Drawing.Color.White
        Me.txtSheetEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSheetEnd.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtSheetEnd.Location = New System.Drawing.Point(110, 114)
        Me.txtSheetEnd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSheetEnd.Name = "txtSheetEnd"
        Me.txtSheetEnd.Size = New System.Drawing.Size(355, 21)
        Me.txtSheetEnd.TabIndex = 22
        Me.txtSheetEnd.Text = "Sheet"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(12, 114)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 21)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Sheet End:"
        '
        'txtDesc3
        '
        Me.txtDesc3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc3.BackColor = System.Drawing.Color.White
        Me.txtDesc3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesc3.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtDesc3.Location = New System.Drawing.Point(110, 89)
        Me.txtDesc3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDesc3.Name = "txtDesc3"
        Me.txtDesc3.Size = New System.Drawing.Size(355, 21)
        Me.txtDesc3.TabIndex = 20
        Me.txtDesc3.Text = "Dwg No:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 21)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Description 3:"
        '
        'txtDesc2
        '
        Me.txtDesc2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc2.BackColor = System.Drawing.Color.White
        Me.txtDesc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesc2.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtDesc2.Location = New System.Drawing.Point(110, 64)
        Me.txtDesc2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDesc2.Name = "txtDesc2"
        Me.txtDesc2.Size = New System.Drawing.Size(355, 21)
        Me.txtDesc2.TabIndex = 18
        Me.txtDesc2.Text = "SYSTEM"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 64)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 21)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Description 2:"
        '
        'txtDesc1
        '
        Me.txtDesc1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc1.BackColor = System.Drawing.Color.White
        Me.txtDesc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesc1.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtDesc1.Location = New System.Drawing.Point(110, 38)
        Me.txtDesc1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDesc1.Name = "txtDesc1"
        Me.txtDesc1.Size = New System.Drawing.Size(355, 21)
        Me.txtDesc1.TabIndex = 16
        Me.txtDesc1.Text = "LOCATION"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 21)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Description 1:"
        '
        'txtLoopName
        '
        Me.txtLoopName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoopName.BackColor = System.Drawing.Color.White
        Me.txtLoopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopName.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtLoopName.Location = New System.Drawing.Point(110, 12)
        Me.txtLoopName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLoopName.Name = "txtLoopName"
        Me.txtLoopName.Size = New System.Drawing.Size(355, 21)
        Me.txtLoopName.TabIndex = 10
        Me.txtLoopName.Text = "INSTRUMENT LOOP DIAGRAM"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 26)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Loop Name:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblSPath)
        Me.Panel1.Controls.Add(Me.SimpleButton1)
        Me.Panel1.Location = New System.Drawing.Point(14, 21)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(492, 162)
        Me.Panel1.TabIndex = 0
        '
        'lblSPath
        '
        Me.lblSPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPath.ForeColor = System.Drawing.Color.DimGray
        Me.lblSPath.Location = New System.Drawing.Point(12, 79)
        Me.lblSPath.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblSPath.Name = "lblSPath"
        Me.lblSPath.Size = New System.Drawing.Size(460, 68)
        Me.lblSPath.TabIndex = 8
        Me.lblSPath.Text = "..."
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(15, 16)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(181, 46)
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "Select ILD  File"
        '
        'rtxt
        '
        Me.rtxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxt.Location = New System.Drawing.Point(0, 0)
        Me.rtxt.Name = "rtxt"
        Me.rtxt.Size = New System.Drawing.Size(666, 589)
        Me.rtxt.TabIndex = 0
        Me.rtxt.Text = ""
        '
        'frmExtractILD3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 699)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmExtractILD3.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmExtractILD3"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extract ILD from Plain Text"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblCount As Label
    Friend WithEvents lblOp As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtDesc1 As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLoopName As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblSPath As Label
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents opnFile As OpenFileDialog
    Friend WithEvents rtxt As RichTextBox
    Friend WithEvents txtDesc2 As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDesc3 As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSheetEnd As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents Label5 As Label
End Class
