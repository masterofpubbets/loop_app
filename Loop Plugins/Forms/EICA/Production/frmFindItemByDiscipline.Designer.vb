<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFindItemByDiscipline
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFindItemByDiscipline))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rInsEq = New System.Windows.Forms.RadioButton()
        Me.rEleJB = New System.Windows.Forms.RadioButton()
        Me.rInsJB = New System.Windows.Forms.RadioButton()
        Me.rIns = New System.Windows.Forms.RadioButton()
        Me.rInsCable = New System.Windows.Forms.RadioButton()
        Me.rEleEq = New System.Windows.Forms.RadioButton()
        Me.rEleCable = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ckLive = New System.Windows.Forms.CheckBox()
        Me.txt = New System.Windows.Forms.TextBox()
        Me.lst = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Gold
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineColor = System.Drawing.Color.Gold
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(40, 86)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(604, 48)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Find Item By Discipline"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rInsEq)
        Me.GroupBox1.Controls.Add(Me.rEleJB)
        Me.GroupBox1.Controls.Add(Me.rInsJB)
        Me.GroupBox1.Controls.Add(Me.rIns)
        Me.GroupBox1.Controls.Add(Me.rInsCable)
        Me.GroupBox1.Controls.Add(Me.rEleEq)
        Me.GroupBox1.Controls.Add(Me.rEleCable)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 142)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(885, 91)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Discipline"
        '
        'rInsEq
        '
        Me.rInsEq.AutoSize = True
        Me.rInsEq.Location = New System.Drawing.Point(688, 39)
        Me.rInsEq.Margin = New System.Windows.Forms.Padding(4)
        Me.rInsEq.Name = "rInsEq"
        Me.rInsEq.Size = New System.Drawing.Size(121, 21)
        Me.rInsEq.TabIndex = 6
        Me.rInsEq.Text = "Ins. Equipment"
        Me.rInsEq.UseVisualStyleBackColor = True
        '
        'rEleJB
        '
        Me.rEleJB.AutoSize = True
        Me.rEleJB.Location = New System.Drawing.Point(308, 39)
        Me.rEleJB.Margin = New System.Windows.Forms.Padding(4)
        Me.rEleJB.Name = "rEleJB"
        Me.rEleJB.Size = New System.Drawing.Size(68, 21)
        Me.rEleJB.TabIndex = 2
        Me.rEleJB.Text = "Ele. JB"
        Me.rEleJB.UseVisualStyleBackColor = True
        '
        'rInsJB
        '
        Me.rInsJB.AutoSize = True
        Me.rInsJB.Location = New System.Drawing.Point(604, 39)
        Me.rInsJB.Margin = New System.Windows.Forms.Padding(4)
        Me.rInsJB.Name = "rInsJB"
        Me.rInsJB.Size = New System.Drawing.Size(69, 21)
        Me.rInsJB.TabIndex = 5
        Me.rInsJB.Text = "Ins. JB"
        Me.rInsJB.UseVisualStyleBackColor = True
        '
        'rIns
        '
        Me.rIns.AutoSize = True
        Me.rIns.Location = New System.Drawing.Point(497, 39)
        Me.rIns.Margin = New System.Windows.Forms.Padding(4)
        Me.rIns.Name = "rIns"
        Me.rIns.Size = New System.Drawing.Size(97, 21)
        Me.rIns.TabIndex = 4
        Me.rIns.Text = "Instrument"
        Me.rIns.UseVisualStyleBackColor = True
        '
        'rInsCable
        '
        Me.rInsCable.AutoSize = True
        Me.rInsCable.Location = New System.Drawing.Point(393, 39)
        Me.rInsCable.Margin = New System.Windows.Forms.Padding(4)
        Me.rInsCable.Name = "rInsCable"
        Me.rInsCable.Size = New System.Drawing.Size(88, 21)
        Me.rInsCable.TabIndex = 3
        Me.rInsCable.Text = "Ins. Cable"
        Me.rInsCable.UseVisualStyleBackColor = True
        '
        'rEleEq
        '
        Me.rEleEq.AutoSize = True
        Me.rEleEq.Location = New System.Drawing.Point(172, 39)
        Me.rEleEq.Margin = New System.Windows.Forms.Padding(4)
        Me.rEleEq.Name = "rEleEq"
        Me.rEleEq.Size = New System.Drawing.Size(120, 21)
        Me.rEleEq.TabIndex = 1
        Me.rEleEq.Text = "Ele. Equipment"
        Me.rEleEq.UseVisualStyleBackColor = True
        '
        'rEleCable
        '
        Me.rEleCable.AutoSize = True
        Me.rEleCable.Checked = True
        Me.rEleCable.Location = New System.Drawing.Point(67, 39)
        Me.rEleCable.Margin = New System.Windows.Forms.Padding(4)
        Me.rEleCable.Name = "rEleCable"
        Me.rEleCable.Size = New System.Drawing.Size(87, 21)
        Me.rEleCable.TabIndex = 0
        Me.rEleCable.TabStop = True
        Me.rEleCable.Text = "Ele. Cable"
        Me.rEleCable.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SimpleButton1)
        Me.GroupBox2.Controls.Add(Me.ckLive)
        Me.GroupBox2.Controls.Add(Me.txt)
        Me.GroupBox2.Location = New System.Drawing.Point(40, 241)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(885, 155)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Tag"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(665, 91)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(197, 52)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Find"
        '
        'ckLive
        '
        Me.ckLive.AutoSize = True
        Me.ckLive.Location = New System.Drawing.Point(21, 68)
        Me.ckLive.Margin = New System.Windows.Forms.Padding(4)
        Me.ckLive.Name = "ckLive"
        Me.ckLive.Size = New System.Drawing.Size(100, 21)
        Me.ckLive.TabIndex = 1
        Me.ckLive.Text = "Live Search"
        Me.ckLive.UseVisualStyleBackColor = True
        '
        'txt
        '
        Me.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt.Location = New System.Drawing.Point(21, 36)
        Me.txt.Margin = New System.Windows.Forms.Padding(4)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(841, 23)
        Me.txt.TabIndex = 0
        '
        'lst
        '
        Me.lst.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lst.FormattingEnabled = True
        Me.lst.ItemHeight = 16
        Me.lst.Location = New System.Drawing.Point(21, 26)
        Me.lst.Margin = New System.Windows.Forms.Padding(4)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(841, 288)
        Me.lst.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lst)
        Me.GroupBox3.Location = New System.Drawing.Point(40, 403)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(885, 338)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Results"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(751, 748)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(197, 52)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Cancel"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(545, 748)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(197, 52)
        Me.SimpleButton3.TabIndex = 6
        Me.SimpleButton3.Text = "Select"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(964, 75)
        '
        'frmFindItemByDiscipline
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(964, 815)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmFindItemByDiscipline.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmFindItemByDiscipline"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rEleJB As RadioButton
    Friend WithEvents rInsJB As RadioButton
    Friend WithEvents rIns As RadioButton
    Friend WithEvents rInsCable As RadioButton
    Friend WithEvents rEleEq As RadioButton
    Friend WithEvents rEleCable As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckLive As CheckBox
    Friend WithEvents txt As TextBox
    Friend WithEvents lst As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents rInsEq As RadioButton
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
End Class
