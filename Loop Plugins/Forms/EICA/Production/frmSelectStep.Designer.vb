<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectStep
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectStep))
        Me.lblItem = New DevExpress.XtraEditors.LabelControl()
        Me.gpEleCable = New System.Windows.Forms.GroupBox()
        Me.ckEleCableTested = New System.Windows.Forms.CheckBox()
        Me.ckEleCableGland2End = New System.Windows.Forms.CheckBox()
        Me.ckEleCableGland1End = New System.Windows.Forms.CheckBox()
        Me.ckEleCableCon2End = New System.Windows.Forms.CheckBox()
        Me.ckEleCableCon1End = New System.Windows.Forms.CheckBox()
        Me.ckEleCablePulled = New System.Windows.Forms.CheckBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.gpEleEq = New System.Windows.Forms.GroupBox()
        Me.ckEleEqInstalled = New System.Windows.Forms.CheckBox()
        Me.gbInsEq = New System.Windows.Forms.GroupBox()
        Me.ckInsEqInstalled = New System.Windows.Forms.CheckBox()
        Me.gbInsJB = New System.Windows.Forms.GroupBox()
        Me.ckInsJBInstalled = New System.Windows.Forms.CheckBox()
        Me.gbIns = New System.Windows.Forms.GroupBox()
        Me.ckInsHookedup = New System.Windows.Forms.CheckBox()
        Me.ckInsInstalled = New System.Windows.Forms.CheckBox()
        Me.ckInsCalibrated = New System.Windows.Forms.CheckBox()
        Me.gbInsCable = New System.Windows.Forms.GroupBox()
        Me.ckInsCableTested = New System.Windows.Forms.CheckBox()
        Me.ckInsCableGland2End = New System.Windows.Forms.CheckBox()
        Me.ckInsCableGland1End = New System.Windows.Forms.CheckBox()
        Me.ckInsCableCon2End = New System.Windows.Forms.CheckBox()
        Me.ckInsCableCon1End = New System.Windows.Forms.CheckBox()
        Me.ckInsCablePulled = New System.Windows.Forms.CheckBox()
        Me.gbEleJB = New System.Windows.Forms.GroupBox()
        Me.ckEleJBInstalled = New System.Windows.Forms.CheckBox()
        Me.gpEleCable.SuspendLayout()
        Me.gpEleEq.SuspendLayout()
        Me.gbInsEq.SuspendLayout()
        Me.gbInsJB.SuspendLayout()
        Me.gbIns.SuspendLayout()
        Me.gbInsCable.SuspendLayout()
        Me.gbEleJB.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblItem
        '
        Me.lblItem.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.lblItem.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblItem.Appearance.Options.UseFont = True
        Me.lblItem.Appearance.Options.UseForeColor = True
        Me.lblItem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblItem.LineColor = System.Drawing.Color.SteelBlue
        Me.lblItem.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.lblItem.LineVisible = True
        Me.lblItem.Location = New System.Drawing.Point(12, 12)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(364, 39)
        Me.lblItem.TabIndex = 1
        Me.lblItem.Text = "Item:"
        '
        'gpEleCable
        '
        Me.gpEleCable.Controls.Add(Me.ckEleCableTested)
        Me.gpEleCable.Controls.Add(Me.ckEleCableGland2End)
        Me.gpEleCable.Controls.Add(Me.ckEleCableGland1End)
        Me.gpEleCable.Controls.Add(Me.ckEleCableCon2End)
        Me.gpEleCable.Controls.Add(Me.ckEleCableCon1End)
        Me.gpEleCable.Controls.Add(Me.ckEleCablePulled)
        Me.gpEleCable.Location = New System.Drawing.Point(25, 113)
        Me.gpEleCable.Name = "gpEleCable"
        Me.gpEleCable.Size = New System.Drawing.Size(302, 275)
        Me.gpEleCable.TabIndex = 2
        Me.gpEleCable.TabStop = False
        Me.gpEleCable.Text = "Electrical Cable Steps"
        Me.gpEleCable.Visible = False
        '
        'ckEleCableTested
        '
        Me.ckEleCableTested.AutoSize = True
        Me.ckEleCableTested.Location = New System.Drawing.Point(25, 231)
        Me.ckEleCableTested.Name = "ckEleCableTested"
        Me.ckEleCableTested.Size = New System.Drawing.Size(135, 17)
        Me.ckEleCableTested.TabIndex = 5
        Me.ckEleCableTested.Text = "Electrical Cable Tested"
        Me.ckEleCableTested.UseVisualStyleBackColor = True
        '
        'ckEleCableGland2End
        '
        Me.ckEleCableGland2End.AutoSize = True
        Me.ckEleCableGland2End.Location = New System.Drawing.Point(25, 192)
        Me.ckEleCableGland2End.Name = "ckEleCableGland2End"
        Me.ckEleCableGland2End.Size = New System.Drawing.Size(174, 17)
        Me.ckEleCableGland2End.TabIndex = 4
        Me.ckEleCableGland2End.Text = "Electrical Cable Gland (To) End"
        Me.ckEleCableGland2End.UseVisualStyleBackColor = True
        '
        'ckEleCableGland1End
        '
        Me.ckEleCableGland1End.AutoSize = True
        Me.ckEleCableGland1End.Location = New System.Drawing.Point(25, 153)
        Me.ckEleCableGland1End.Name = "ckEleCableGland1End"
        Me.ckEleCableGland1End.Size = New System.Drawing.Size(184, 17)
        Me.ckEleCableGland1End.TabIndex = 3
        Me.ckEleCableGland1End.Text = "Electrical Cable Gland (From) End"
        Me.ckEleCableGland1End.UseVisualStyleBackColor = True
        '
        'ckEleCableCon2End
        '
        Me.ckEleCableCon2End.AutoSize = True
        Me.ckEleCableCon2End.Location = New System.Drawing.Point(25, 114)
        Me.ckEleCableCon2End.Name = "ckEleCableCon2End"
        Me.ckEleCableCon2End.Size = New System.Drawing.Size(186, 17)
        Me.ckEleCableCon2End.TabIndex = 2
        Me.ckEleCableCon2End.Text = "Electrical Cable Connect (To) End"
        Me.ckEleCableCon2End.UseVisualStyleBackColor = True
        '
        'ckEleCableCon1End
        '
        Me.ckEleCableCon1End.AutoSize = True
        Me.ckEleCableCon1End.Location = New System.Drawing.Point(25, 75)
        Me.ckEleCableCon1End.Name = "ckEleCableCon1End"
        Me.ckEleCableCon1End.Size = New System.Drawing.Size(196, 17)
        Me.ckEleCableCon1End.TabIndex = 1
        Me.ckEleCableCon1End.Text = "Electrical Cable Connect (From) End"
        Me.ckEleCableCon1End.UseVisualStyleBackColor = True
        '
        'ckEleCablePulled
        '
        Me.ckEleCablePulled.AutoSize = True
        Me.ckEleCablePulled.Location = New System.Drawing.Point(25, 36)
        Me.ckEleCablePulled.Name = "ckEleCablePulled"
        Me.ckEleCablePulled.Size = New System.Drawing.Size(131, 17)
        Me.ckEleCablePulled.TabIndex = 0
        Me.ckEleCablePulled.Text = "Electrical Cable Pulled"
        Me.ckEleCablePulled.UseVisualStyleBackColor = True
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineColor = System.Drawing.Color.DimGray
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(25, 68)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(302, 39)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Steps to Close"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(89, 424)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(148, 42)
        Me.SimpleButton3.TabIndex = 8
        Me.SimpleButton3.Text = "Update"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(243, 424)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(148, 42)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = "Cancel"
        '
        'gpEleEq
        '
        Me.gpEleEq.Controls.Add(Me.ckEleEqInstalled)
        Me.gpEleEq.Location = New System.Drawing.Point(25, 113)
        Me.gpEleEq.Name = "gpEleEq"
        Me.gpEleEq.Size = New System.Drawing.Size(302, 86)
        Me.gpEleEq.TabIndex = 9
        Me.gpEleEq.TabStop = False
        Me.gpEleEq.Text = "Electrical Equipment Steps"
        Me.gpEleEq.Visible = False
        '
        'ckEleEqInstalled
        '
        Me.ckEleEqInstalled.AutoSize = True
        Me.ckEleEqInstalled.Location = New System.Drawing.Point(25, 36)
        Me.ckEleEqInstalled.Name = "ckEleEqInstalled"
        Me.ckEleEqInstalled.Size = New System.Drawing.Size(164, 17)
        Me.ckEleEqInstalled.TabIndex = 0
        Me.ckEleEqInstalled.Text = "Electrical Equipment Installed"
        Me.ckEleEqInstalled.UseVisualStyleBackColor = True
        '
        'gbInsEq
        '
        Me.gbInsEq.Controls.Add(Me.ckInsEqInstalled)
        Me.gbInsEq.Location = New System.Drawing.Point(25, 113)
        Me.gbInsEq.Name = "gbInsEq"
        Me.gbInsEq.Size = New System.Drawing.Size(302, 86)
        Me.gbInsEq.TabIndex = 10
        Me.gbInsEq.TabStop = False
        Me.gbInsEq.Text = "Instrumentation Equipment Steps"
        Me.gbInsEq.Visible = False
        '
        'ckInsEqInstalled
        '
        Me.ckInsEqInstalled.AutoSize = True
        Me.ckInsEqInstalled.Location = New System.Drawing.Point(25, 36)
        Me.ckInsEqInstalled.Name = "ckInsEqInstalled"
        Me.ckInsEqInstalled.Size = New System.Drawing.Size(98, 17)
        Me.ckInsEqInstalled.TabIndex = 0
        Me.ckInsEqInstalled.Text = "Ins Eq Installed"
        Me.ckInsEqInstalled.UseVisualStyleBackColor = True
        '
        'gbInsJB
        '
        Me.gbInsJB.Controls.Add(Me.ckInsJBInstalled)
        Me.gbInsJB.Location = New System.Drawing.Point(25, 113)
        Me.gbInsJB.Name = "gbInsJB"
        Me.gbInsJB.Size = New System.Drawing.Size(302, 77)
        Me.gbInsJB.TabIndex = 11
        Me.gbInsJB.TabStop = False
        Me.gbInsJB.Text = "Instrumentation JB Steps"
        Me.gbInsJB.Visible = False
        '
        'ckInsJBInstalled
        '
        Me.ckInsJBInstalled.AutoSize = True
        Me.ckInsJBInstalled.Location = New System.Drawing.Point(25, 36)
        Me.ckInsJBInstalled.Name = "ckInsJBInstalled"
        Me.ckInsJBInstalled.Size = New System.Drawing.Size(97, 17)
        Me.ckInsJBInstalled.TabIndex = 0
        Me.ckInsJBInstalled.Text = "Ins JB Installed"
        Me.ckInsJBInstalled.UseVisualStyleBackColor = True
        '
        'gbIns
        '
        Me.gbIns.Controls.Add(Me.ckInsHookedup)
        Me.gbIns.Controls.Add(Me.ckInsInstalled)
        Me.gbIns.Controls.Add(Me.ckInsCalibrated)
        Me.gbIns.Location = New System.Drawing.Point(25, 113)
        Me.gbIns.Name = "gbIns"
        Me.gbIns.Size = New System.Drawing.Size(302, 164)
        Me.gbIns.TabIndex = 12
        Me.gbIns.TabStop = False
        Me.gbIns.Text = "Instruments Steps"
        Me.gbIns.Visible = False
        '
        'ckInsHookedup
        '
        Me.ckInsHookedup.AutoSize = True
        Me.ckInsHookedup.Location = New System.Drawing.Point(25, 114)
        Me.ckInsHookedup.Name = "ckInsHookedup"
        Me.ckInsHookedup.Size = New System.Drawing.Size(133, 17)
        Me.ckInsHookedup.TabIndex = 2
        Me.ckInsHookedup.Text = "Instrument Hooked Up"
        Me.ckInsHookedup.UseVisualStyleBackColor = True
        '
        'ckInsInstalled
        '
        Me.ckInsInstalled.AutoSize = True
        Me.ckInsInstalled.Location = New System.Drawing.Point(25, 75)
        Me.ckInsInstalled.Name = "ckInsInstalled"
        Me.ckInsInstalled.Size = New System.Drawing.Size(117, 17)
        Me.ckInsInstalled.TabIndex = 1
        Me.ckInsInstalled.Text = "Instrument Installed"
        Me.ckInsInstalled.UseVisualStyleBackColor = True
        '
        'ckInsCalibrated
        '
        Me.ckInsCalibrated.AutoSize = True
        Me.ckInsCalibrated.Location = New System.Drawing.Point(25, 36)
        Me.ckInsCalibrated.Name = "ckInsCalibrated"
        Me.ckInsCalibrated.Size = New System.Drawing.Size(125, 17)
        Me.ckInsCalibrated.TabIndex = 0
        Me.ckInsCalibrated.Text = "Instrument Calibrated"
        Me.ckInsCalibrated.UseVisualStyleBackColor = True
        '
        'gbInsCable
        '
        Me.gbInsCable.Controls.Add(Me.ckInsCableTested)
        Me.gbInsCable.Controls.Add(Me.ckInsCableGland2End)
        Me.gbInsCable.Controls.Add(Me.ckInsCableGland1End)
        Me.gbInsCable.Controls.Add(Me.ckInsCableCon2End)
        Me.gbInsCable.Controls.Add(Me.ckInsCableCon1End)
        Me.gbInsCable.Controls.Add(Me.ckInsCablePulled)
        Me.gbInsCable.Location = New System.Drawing.Point(25, 113)
        Me.gbInsCable.Name = "gbInsCable"
        Me.gbInsCable.Size = New System.Drawing.Size(302, 275)
        Me.gbInsCable.TabIndex = 13
        Me.gbInsCable.TabStop = False
        Me.gbInsCable.Text = "Instrument Cable Steps"
        Me.gbInsCable.Visible = False
        '
        'ckInsCableTested
        '
        Me.ckInsCableTested.AutoSize = True
        Me.ckInsCableTested.Location = New System.Drawing.Point(25, 231)
        Me.ckInsCableTested.Name = "ckInsCableTested"
        Me.ckInsCableTested.Size = New System.Drawing.Size(141, 17)
        Me.ckInsCableTested.TabIndex = 5
        Me.ckInsCableTested.Text = "Instrument Cable Tested"
        Me.ckInsCableTested.UseVisualStyleBackColor = True
        '
        'ckInsCableGland2End
        '
        Me.ckInsCableGland2End.AutoSize = True
        Me.ckInsCableGland2End.Location = New System.Drawing.Point(25, 192)
        Me.ckInsCableGland2End.Name = "ckInsCableGland2End"
        Me.ckInsCableGland2End.Size = New System.Drawing.Size(180, 17)
        Me.ckInsCableGland2End.TabIndex = 4
        Me.ckInsCableGland2End.Text = "Instrument Cable Gland (To) End"
        Me.ckInsCableGland2End.UseVisualStyleBackColor = True
        '
        'ckInsCableGland1End
        '
        Me.ckInsCableGland1End.AutoSize = True
        Me.ckInsCableGland1End.Location = New System.Drawing.Point(25, 153)
        Me.ckInsCableGland1End.Name = "ckInsCableGland1End"
        Me.ckInsCableGland1End.Size = New System.Drawing.Size(190, 17)
        Me.ckInsCableGland1End.TabIndex = 3
        Me.ckInsCableGland1End.Text = "Instrument Cable Gland (From) End"
        Me.ckInsCableGland1End.UseVisualStyleBackColor = True
        '
        'ckInsCableCon2End
        '
        Me.ckInsCableCon2End.AutoSize = True
        Me.ckInsCableCon2End.Location = New System.Drawing.Point(25, 114)
        Me.ckInsCableCon2End.Name = "ckInsCableCon2End"
        Me.ckInsCableCon2End.Size = New System.Drawing.Size(192, 17)
        Me.ckInsCableCon2End.TabIndex = 2
        Me.ckInsCableCon2End.Text = "Instrument Cable Connect (To) End"
        Me.ckInsCableCon2End.UseVisualStyleBackColor = True
        '
        'ckInsCableCon1End
        '
        Me.ckInsCableCon1End.AutoSize = True
        Me.ckInsCableCon1End.Location = New System.Drawing.Point(25, 75)
        Me.ckInsCableCon1End.Name = "ckInsCableCon1End"
        Me.ckInsCableCon1End.Size = New System.Drawing.Size(202, 17)
        Me.ckInsCableCon1End.TabIndex = 1
        Me.ckInsCableCon1End.Text = "Instrument Cable Connect (From) End"
        Me.ckInsCableCon1End.UseVisualStyleBackColor = True
        '
        'ckInsCablePulled
        '
        Me.ckInsCablePulled.AutoSize = True
        Me.ckInsCablePulled.Location = New System.Drawing.Point(25, 36)
        Me.ckInsCablePulled.Name = "ckInsCablePulled"
        Me.ckInsCablePulled.Size = New System.Drawing.Size(137, 17)
        Me.ckInsCablePulled.TabIndex = 0
        Me.ckInsCablePulled.Text = "Instrument Cable Pulled"
        Me.ckInsCablePulled.UseVisualStyleBackColor = True
        '
        'gbEleJB
        '
        Me.gbEleJB.Controls.Add(Me.ckEleJBInstalled)
        Me.gbEleJB.Location = New System.Drawing.Point(25, 113)
        Me.gbEleJB.Name = "gbEleJB"
        Me.gbEleJB.Size = New System.Drawing.Size(302, 86)
        Me.gbEleJB.TabIndex = 14
        Me.gbEleJB.TabStop = False
        Me.gbEleJB.Text = "Electrical JB Steps"
        Me.gbEleJB.Visible = False
        '
        'ckEleJBInstalled
        '
        Me.ckEleJBInstalled.AutoSize = True
        Me.ckEleJBInstalled.Location = New System.Drawing.Point(25, 36)
        Me.ckEleJBInstalled.Name = "ckEleJBInstalled"
        Me.ckEleJBInstalled.Size = New System.Drawing.Size(126, 17)
        Me.ckEleJBInstalled.TabIndex = 0
        Me.ckEleJBInstalled.Text = "Electrical JB Installed"
        Me.ckEleJBInstalled.UseVisualStyleBackColor = True
        '
        'frmSelectStep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 478)
        Me.ControlBox = False
        Me.Controls.Add(Me.gpEleEq)
        Me.Controls.Add(Me.gbEleJB)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.lblItem)
        Me.Controls.Add(Me.gbInsCable)
        Me.Controls.Add(Me.gbIns)
        Me.Controls.Add(Me.gbInsJB)
        Me.Controls.Add(Me.gbInsEq)
        Me.Controls.Add(Me.gpEleCable)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelectStep"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.gpEleCable.ResumeLayout(False)
        Me.gpEleCable.PerformLayout()
        Me.gpEleEq.ResumeLayout(False)
        Me.gpEleEq.PerformLayout()
        Me.gbInsEq.ResumeLayout(False)
        Me.gbInsEq.PerformLayout()
        Me.gbInsJB.ResumeLayout(False)
        Me.gbInsJB.PerformLayout()
        Me.gbIns.ResumeLayout(False)
        Me.gbIns.PerformLayout()
        Me.gbInsCable.ResumeLayout(False)
        Me.gbInsCable.PerformLayout()
        Me.gbEleJB.ResumeLayout(False)
        Me.gbEleJB.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblItem As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gpEleCable As GroupBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ckEleCablePulled As CheckBox
    Friend WithEvents ckEleCableTested As CheckBox
    Friend WithEvents ckEleCableGland2End As CheckBox
    Friend WithEvents ckEleCableGland1End As CheckBox
    Friend WithEvents ckEleCableCon2End As CheckBox
    Friend WithEvents ckEleCableCon1End As CheckBox
    Friend WithEvents gpEleEq As GroupBox
    Friend WithEvents ckEleEqInstalled As CheckBox
    Friend WithEvents gbInsEq As GroupBox
    Friend WithEvents ckInsEqInstalled As CheckBox
    Friend WithEvents gbInsJB As GroupBox
    Friend WithEvents ckInsJBInstalled As CheckBox
    Friend WithEvents gbIns As GroupBox
    Friend WithEvents ckInsHookedup As CheckBox
    Friend WithEvents ckInsInstalled As CheckBox
    Friend WithEvents ckInsCalibrated As CheckBox
    Friend WithEvents gbInsCable As GroupBox
    Friend WithEvents gbEleJB As GroupBox
    Friend WithEvents ckEleJBInstalled As CheckBox
    Friend WithEvents ckInsCableTested As CheckBox
    Friend WithEvents ckInsCableGland2End As CheckBox
    Friend WithEvents ckInsCableGland1End As CheckBox
    Friend WithEvents ckInsCableCon2End As CheckBox
    Friend WithEvents ckInsCableCon1End As CheckBox
    Friend WithEvents ckInsCablePulled As CheckBox
End Class
