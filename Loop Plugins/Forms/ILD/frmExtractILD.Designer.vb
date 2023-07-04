<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtractILD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtractILD))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.fld = New System.Windows.Forms.FolderBrowserDialog()
        Me.opnFle = New System.Windows.Forms.OpenFileDialog()
        Me.sveFle = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLoopName = New Loop_App.EAMS.Graphical.TextBoxFocusColor()
        Me.txtSep = New Loop_App.EAMS.Graphical.TextBoxFocusColor()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSPath = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDD = New System.Windows.Forms.Label()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.lblVal = New System.Windows.Forms.Label()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.BarButtonItem2})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal
        Me.RibbonControl1.Size = New System.Drawing.Size(1198, 112)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Start Process"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Validate Items Files"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = CType((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Import ILD"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'opnFle
        '
        Me.opnFle.Filter = "All Files|*.*"
        '
        'sveFle
        '
        Me.sveFle.Filter = "Excel File|*.xlsx"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtLoopName)
        Me.GroupBox2.Controls.Add(Me.txtSep)
        Me.GroupBox2.Controls.Add(Me.SimpleButton1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblSPath)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Orange
        Me.GroupBox2.Location = New System.Drawing.Point(12, 160)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(1175, 246)
        Me.GroupBox2.TabIndex = 85
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ILD Source File Settings"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(861, 165)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 26)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Case Sensitive"
        '
        'txtLoopName
        '
        Me.txtLoopName.BackColor = System.Drawing.Color.White
        Me.txtLoopName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopName.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtLoopName.Location = New System.Drawing.Point(127, 191)
        Me.txtLoopName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLoopName.Name = "txtLoopName"
        Me.txtLoopName.Size = New System.Drawing.Size(717, 26)
        Me.txtLoopName.TabIndex = 8
        '
        'txtSep
        '
        Me.txtSep.BackColor = System.Drawing.Color.White
        Me.txtSep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSep.FocusColor = System.Drawing.Color.Cornsilk
        Me.txtSep.Location = New System.Drawing.Point(127, 149)
        Me.txtSep.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSep.Name = "txtSep"
        Me.txtSep.Size = New System.Drawing.Size(717, 26)
        Me.txtSep.TabIndex = 7
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(975, 63)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(145, 38)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Select ILD File"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 192)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 26)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Loop Name:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 150)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Separator:"
        '
        'lblSPath
        '
        Me.lblSPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSPath.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblSPath.Location = New System.Drawing.Point(6, 64)
        Me.lblSPath.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblSPath.Name = "lblSPath"
        Me.lblSPath.Size = New System.Drawing.Size(1000, 36)
        Me.lblSPath.TabIndex = 2
        Me.lblSPath.Text = "..."
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select the ILD Text File"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.SimpleButton2)
        Me.GroupBox3.Controls.Add(Me.lblDD)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Orange
        Me.GroupBox3.Location = New System.Drawing.Point(12, 435)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(1173, 79)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Distination Folder"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(975, 27)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(145, 38)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = "Select"
        '
        'lblDD
        '
        Me.lblDD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDD.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblDD.Location = New System.Drawing.Point(6, 28)
        Me.lblDD.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblDD.Name = "lblDD"
        Me.lblDD.Size = New System.Drawing.Size(998, 36)
        Me.lblDD.TabIndex = 2
        Me.lblDD.Text = "..."
        '
        'lblOp
        '
        Me.lblOp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOp.ForeColor = System.Drawing.Color.Gold
        Me.lblOp.Location = New System.Drawing.Point(12, 532)
        Me.lblOp.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(1175, 44)
        Me.lblOp.TabIndex = 89
        Me.lblOp.Text = "Proccessing ILD"
        Me.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblOp.Visible = False
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.SaddleBrown
        Me.lblCount.Location = New System.Drawing.Point(12, 594)
        Me.lblCount.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(1175, 45)
        Me.lblCount.TabIndex = 88
        Me.lblCount.Text = "00"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCount.Visible = False
        '
        'lblVal
        '
        Me.lblVal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVal.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblVal.Location = New System.Drawing.Point(-6, 779)
        Me.lblVal.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblVal.Name = "lblVal"
        Me.lblVal.Size = New System.Drawing.Size(1204, 92)
        Me.lblVal.TabIndex = 91
        Me.lblVal.Text = "Please Wait Validate ILD Items Files....."
        Me.lblVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblVal.Visible = False
        '
        'frmExtractILD
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1198, 699)
        Me.Controls.Add(Me.lblVal)
        Me.Controls.Add(Me.lblOp)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("frmExtractILD.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmExtractILD"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extract ILD from File"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents fld As FolderBrowserDialog
    Friend WithEvents opnFle As OpenFileDialog
    Friend WithEvents sveFle As SaveFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSPath As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLoopName As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents txtSep As EAMS.Graphical.TextBoxFocusColor
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblDD As Label
    Friend WithEvents lblOp As Label
    Friend WithEvents lblCount As Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
    Friend WithEvents lblVal As Label
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
End Class
