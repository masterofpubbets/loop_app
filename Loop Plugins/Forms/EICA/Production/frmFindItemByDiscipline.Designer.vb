<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFindItemByDiscipline
    Inherits System.Windows.Forms.Form

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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineColor = System.Drawing.Color.SteelBlue
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(453, 39)
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
        Me.GroupBox1.Location = New System.Drawing.Point(30, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 74)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Discipline"
        '
        'rInsEq
        '
        Me.rInsEq.AutoSize = True
        Me.rInsEq.Location = New System.Drawing.Point(516, 32)
        Me.rInsEq.Name = "rInsEq"
        Me.rInsEq.Size = New System.Drawing.Size(95, 17)
        Me.rInsEq.TabIndex = 6
        Me.rInsEq.Text = "Ins. Equipment"
        Me.rInsEq.UseVisualStyleBackColor = True
        '
        'rEleJB
        '
        Me.rEleJB.AutoSize = True
        Me.rEleJB.Location = New System.Drawing.Point(231, 32)
        Me.rEleJB.Name = "rEleJB"
        Me.rEleJB.Size = New System.Drawing.Size(58, 17)
        Me.rEleJB.TabIndex = 2
        Me.rEleJB.Text = "Ele. JB"
        Me.rEleJB.UseVisualStyleBackColor = True
        '
        'rInsJB
        '
        Me.rInsJB.AutoSize = True
        Me.rInsJB.Location = New System.Drawing.Point(453, 32)
        Me.rInsJB.Name = "rInsJB"
        Me.rInsJB.Size = New System.Drawing.Size(57, 17)
        Me.rInsJB.TabIndex = 5
        Me.rInsJB.Text = "Ins. JB"
        Me.rInsJB.UseVisualStyleBackColor = True
        '
        'rIns
        '
        Me.rIns.AutoSize = True
        Me.rIns.Location = New System.Drawing.Point(373, 32)
        Me.rIns.Name = "rIns"
        Me.rIns.Size = New System.Drawing.Size(74, 17)
        Me.rIns.TabIndex = 4
        Me.rIns.Text = "Instrument"
        Me.rIns.UseVisualStyleBackColor = True
        '
        'rInsCable
        '
        Me.rInsCable.AutoSize = True
        Me.rInsCable.Location = New System.Drawing.Point(295, 32)
        Me.rInsCable.Name = "rInsCable"
        Me.rInsCable.Size = New System.Drawing.Size(72, 17)
        Me.rInsCable.TabIndex = 3
        Me.rInsCable.Text = "Ins. Cable"
        Me.rInsCable.UseVisualStyleBackColor = True
        '
        'rEleEq
        '
        Me.rEleEq.AutoSize = True
        Me.rEleEq.Location = New System.Drawing.Point(129, 32)
        Me.rEleEq.Name = "rEleEq"
        Me.rEleEq.Size = New System.Drawing.Size(96, 17)
        Me.rEleEq.TabIndex = 1
        Me.rEleEq.Text = "Ele. Equipment"
        Me.rEleEq.UseVisualStyleBackColor = True
        '
        'rEleCable
        '
        Me.rEleCable.AutoSize = True
        Me.rEleCable.Checked = True
        Me.rEleCable.Location = New System.Drawing.Point(50, 32)
        Me.rEleCable.Name = "rEleCable"
        Me.rEleCable.Size = New System.Drawing.Size(73, 17)
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
        Me.GroupBox2.Location = New System.Drawing.Point(30, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(664, 126)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Tag"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(499, 74)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(148, 42)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Find"
        '
        'ckLive
        '
        Me.ckLive.AutoSize = True
        Me.ckLive.Location = New System.Drawing.Point(16, 55)
        Me.ckLive.Name = "ckLive"
        Me.ckLive.Size = New System.Drawing.Size(83, 17)
        Me.ckLive.TabIndex = 1
        Me.ckLive.Text = "Live Search"
        Me.ckLive.UseVisualStyleBackColor = True
        '
        'txt
        '
        Me.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt.Location = New System.Drawing.Point(16, 29)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(631, 20)
        Me.txt.TabIndex = 0
        '
        'lst
        '
        Me.lst.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lst.FormattingEnabled = True
        Me.lst.Location = New System.Drawing.Point(16, 21)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(631, 286)
        Me.lst.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lst)
        Me.GroupBox3.Location = New System.Drawing.Point(30, 269)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(664, 333)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Results"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(563, 608)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(148, 42)
        Me.SimpleButton2.TabIndex = 5
        Me.SimpleButton2.Text = "Cancel"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(409, 608)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(148, 42)
        Me.SimpleButton3.TabIndex = 6
        Me.SimpleButton3.Text = "Select"
        '
        'frmFindItemByDiscipline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 662)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFindItemByDiscipline"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

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
End Class
