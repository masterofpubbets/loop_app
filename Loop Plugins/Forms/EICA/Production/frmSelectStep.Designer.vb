<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectStep
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
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.gpEleCable.SuspendLayout()
        Me.gpEleEq.SuspendLayout()
        Me.gbInsEq.SuspendLayout()
        Me.gbInsJB.SuspendLayout()
        Me.gbIns.SuspendLayout()
        Me.gbInsCable.SuspendLayout()
        Me.gbEleJB.SuspendLayout()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblItem
        '
        Me.lblItem.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.lblItem.Appearance.ForeColor = System.Drawing.Color.White
        Me.lblItem.Appearance.Options.UseFont = True
        Me.lblItem.Appearance.Options.UseForeColor = True
        Me.lblItem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblItem.LineColor = System.Drawing.Color.White
        Me.lblItem.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.lblItem.LineVisible = True
        Me.lblItem.Location = New System.Drawing.Point(13, 96)
        Me.lblItem.Margin = New System.Windows.Forms.Padding(4)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(485, 48)
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
        Me.gpEleCable.Location = New System.Drawing.Point(57, 207)
        Me.gpEleCable.Margin = New System.Windows.Forms.Padding(4)
        Me.gpEleCable.Name = "gpEleCable"
        Me.gpEleCable.Padding = New System.Windows.Forms.Padding(4)
        Me.gpEleCable.Size = New System.Drawing.Size(403, 338)
        Me.gpEleCable.TabIndex = 2
        Me.gpEleCable.TabStop = False
        Me.gpEleCable.Text = "Electrical Cable Steps"
        Me.gpEleCable.Visible = False
        '
        'ckEleCableTested
        '
        Me.ckEleCableTested.AutoSize = True
        Me.ckEleCableTested.Location = New System.Drawing.Point(33, 284)
        Me.ckEleCableTested.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleCableTested.Name = "ckEleCableTested"
        Me.ckEleCableTested.Size = New System.Drawing.Size(164, 21)
        Me.ckEleCableTested.TabIndex = 5
        Me.ckEleCableTested.Text = "Electrical Cable Tested"
        Me.ckEleCableTested.UseVisualStyleBackColor = True
        '
        'ckEleCableGland2End
        '
        Me.ckEleCableGland2End.AutoSize = True
        Me.ckEleCableGland2End.Location = New System.Drawing.Point(33, 236)
        Me.ckEleCableGland2End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleCableGland2End.Name = "ckEleCableGland2End"
        Me.ckEleCableGland2End.Size = New System.Drawing.Size(215, 21)
        Me.ckEleCableGland2End.TabIndex = 4
        Me.ckEleCableGland2End.Text = "Electrical Cable Gland (To) End"
        Me.ckEleCableGland2End.UseVisualStyleBackColor = True
        '
        'ckEleCableGland1End
        '
        Me.ckEleCableGland1End.AutoSize = True
        Me.ckEleCableGland1End.Location = New System.Drawing.Point(33, 188)
        Me.ckEleCableGland1End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleCableGland1End.Name = "ckEleCableGland1End"
        Me.ckEleCableGland1End.Size = New System.Drawing.Size(231, 21)
        Me.ckEleCableGland1End.TabIndex = 3
        Me.ckEleCableGland1End.Text = "Electrical Cable Gland (From) End"
        Me.ckEleCableGland1End.UseVisualStyleBackColor = True
        '
        'ckEleCableCon2End
        '
        Me.ckEleCableCon2End.AutoSize = True
        Me.ckEleCableCon2End.Location = New System.Drawing.Point(33, 140)
        Me.ckEleCableCon2End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleCableCon2End.Name = "ckEleCableCon2End"
        Me.ckEleCableCon2End.Size = New System.Drawing.Size(233, 21)
        Me.ckEleCableCon2End.TabIndex = 2
        Me.ckEleCableCon2End.Text = "Electrical Cable Connect (To) End"
        Me.ckEleCableCon2End.UseVisualStyleBackColor = True
        '
        'ckEleCableCon1End
        '
        Me.ckEleCableCon1End.AutoSize = True
        Me.ckEleCableCon1End.Location = New System.Drawing.Point(33, 92)
        Me.ckEleCableCon1End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleCableCon1End.Name = "ckEleCableCon1End"
        Me.ckEleCableCon1End.Size = New System.Drawing.Size(249, 21)
        Me.ckEleCableCon1End.TabIndex = 1
        Me.ckEleCableCon1End.Text = "Electrical Cable Connect (From) End"
        Me.ckEleCableCon1End.UseVisualStyleBackColor = True
        '
        'ckEleCablePulled
        '
        Me.ckEleCablePulled.AutoSize = True
        Me.ckEleCablePulled.Location = New System.Drawing.Point(33, 44)
        Me.ckEleCablePulled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleCablePulled.Name = "ckEleCablePulled"
        Me.ckEleCablePulled.Size = New System.Drawing.Size(158, 21)
        Me.ckEleCablePulled.TabIndex = 0
        Me.ckEleCablePulled.Text = "Electrical Cable Pulled"
        Me.ckEleCablePulled.UseVisualStyleBackColor = True
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Gold
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineColor = System.Drawing.Color.Gold
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(57, 152)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(403, 48)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Steps to Close"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(163, 597)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(197, 52)
        Me.SimpleButton3.TabIndex = 8
        Me.SimpleButton3.Text = "Update"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(368, 597)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(197, 52)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = "Cancel"
        '
        'gpEleEq
        '
        Me.gpEleEq.Controls.Add(Me.ckEleEqInstalled)
        Me.gpEleEq.Location = New System.Drawing.Point(57, 207)
        Me.gpEleEq.Margin = New System.Windows.Forms.Padding(4)
        Me.gpEleEq.Name = "gpEleEq"
        Me.gpEleEq.Padding = New System.Windows.Forms.Padding(4)
        Me.gpEleEq.Size = New System.Drawing.Size(403, 98)
        Me.gpEleEq.TabIndex = 9
        Me.gpEleEq.TabStop = False
        Me.gpEleEq.Text = "Electrical Equipment Steps"
        Me.gpEleEq.Visible = False
        '
        'ckEleEqInstalled
        '
        Me.ckEleEqInstalled.AutoSize = True
        Me.ckEleEqInstalled.Location = New System.Drawing.Point(33, 44)
        Me.ckEleEqInstalled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleEqInstalled.Name = "ckEleEqInstalled"
        Me.ckEleEqInstalled.Size = New System.Drawing.Size(205, 21)
        Me.ckEleEqInstalled.TabIndex = 0
        Me.ckEleEqInstalled.Text = "Electrical Equipment Installed"
        Me.ckEleEqInstalled.UseVisualStyleBackColor = True
        '
        'gbInsEq
        '
        Me.gbInsEq.Controls.Add(Me.ckInsEqInstalled)
        Me.gbInsEq.Location = New System.Drawing.Point(57, 207)
        Me.gbInsEq.Margin = New System.Windows.Forms.Padding(4)
        Me.gbInsEq.Name = "gbInsEq"
        Me.gbInsEq.Padding = New System.Windows.Forms.Padding(4)
        Me.gbInsEq.Size = New System.Drawing.Size(403, 106)
        Me.gbInsEq.TabIndex = 10
        Me.gbInsEq.TabStop = False
        Me.gbInsEq.Text = "Instrumentation Equipment Steps"
        Me.gbInsEq.Visible = False
        '
        'ckInsEqInstalled
        '
        Me.ckInsEqInstalled.AutoSize = True
        Me.ckInsEqInstalled.Location = New System.Drawing.Point(33, 44)
        Me.ckInsEqInstalled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsEqInstalled.Name = "ckInsEqInstalled"
        Me.ckInsEqInstalled.Size = New System.Drawing.Size(121, 21)
        Me.ckInsEqInstalled.TabIndex = 0
        Me.ckInsEqInstalled.Text = "Ins Eq Installed"
        Me.ckInsEqInstalled.UseVisualStyleBackColor = True
        '
        'gbInsJB
        '
        Me.gbInsJB.Controls.Add(Me.ckInsJBInstalled)
        Me.gbInsJB.Location = New System.Drawing.Point(57, 207)
        Me.gbInsJB.Margin = New System.Windows.Forms.Padding(4)
        Me.gbInsJB.Name = "gbInsJB"
        Me.gbInsJB.Padding = New System.Windows.Forms.Padding(4)
        Me.gbInsJB.Size = New System.Drawing.Size(403, 95)
        Me.gbInsJB.TabIndex = 11
        Me.gbInsJB.TabStop = False
        Me.gbInsJB.Text = "Instrumentation JB Steps"
        Me.gbInsJB.Visible = False
        '
        'ckInsJBInstalled
        '
        Me.ckInsJBInstalled.AutoSize = True
        Me.ckInsJBInstalled.Location = New System.Drawing.Point(33, 44)
        Me.ckInsJBInstalled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsJBInstalled.Name = "ckInsJBInstalled"
        Me.ckInsJBInstalled.Size = New System.Drawing.Size(119, 21)
        Me.ckInsJBInstalled.TabIndex = 0
        Me.ckInsJBInstalled.Text = "Ins JB Installed"
        Me.ckInsJBInstalled.UseVisualStyleBackColor = True
        '
        'gbIns
        '
        Me.gbIns.Controls.Add(Me.ckInsHookedup)
        Me.gbIns.Controls.Add(Me.ckInsInstalled)
        Me.gbIns.Controls.Add(Me.ckInsCalibrated)
        Me.gbIns.Location = New System.Drawing.Point(57, 207)
        Me.gbIns.Margin = New System.Windows.Forms.Padding(4)
        Me.gbIns.Name = "gbIns"
        Me.gbIns.Padding = New System.Windows.Forms.Padding(4)
        Me.gbIns.Size = New System.Drawing.Size(403, 202)
        Me.gbIns.TabIndex = 12
        Me.gbIns.TabStop = False
        Me.gbIns.Text = "Instruments Steps"
        Me.gbIns.Visible = False
        '
        'ckInsHookedup
        '
        Me.ckInsHookedup.AutoSize = True
        Me.ckInsHookedup.Location = New System.Drawing.Point(33, 140)
        Me.ckInsHookedup.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsHookedup.Name = "ckInsHookedup"
        Me.ckInsHookedup.Size = New System.Drawing.Size(170, 21)
        Me.ckInsHookedup.TabIndex = 2
        Me.ckInsHookedup.Text = "Instrument Hooked Up"
        Me.ckInsHookedup.UseVisualStyleBackColor = True
        '
        'ckInsInstalled
        '
        Me.ckInsInstalled.AutoSize = True
        Me.ckInsInstalled.Location = New System.Drawing.Point(33, 92)
        Me.ckInsInstalled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsInstalled.Name = "ckInsInstalled"
        Me.ckInsInstalled.Size = New System.Drawing.Size(151, 21)
        Me.ckInsInstalled.TabIndex = 1
        Me.ckInsInstalled.Text = "Instrument Installed"
        Me.ckInsInstalled.UseVisualStyleBackColor = True
        '
        'ckInsCalibrated
        '
        Me.ckInsCalibrated.AutoSize = True
        Me.ckInsCalibrated.Location = New System.Drawing.Point(33, 44)
        Me.ckInsCalibrated.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCalibrated.Name = "ckInsCalibrated"
        Me.ckInsCalibrated.Size = New System.Drawing.Size(162, 21)
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
        Me.gbInsCable.Location = New System.Drawing.Point(57, 207)
        Me.gbInsCable.Margin = New System.Windows.Forms.Padding(4)
        Me.gbInsCable.Name = "gbInsCable"
        Me.gbInsCable.Padding = New System.Windows.Forms.Padding(4)
        Me.gbInsCable.Size = New System.Drawing.Size(403, 338)
        Me.gbInsCable.TabIndex = 13
        Me.gbInsCable.TabStop = False
        Me.gbInsCable.Text = "Instrument Cable Steps"
        Me.gbInsCable.Visible = False
        '
        'ckInsCableTested
        '
        Me.ckInsCableTested.AutoSize = True
        Me.ckInsCableTested.Location = New System.Drawing.Point(33, 284)
        Me.ckInsCableTested.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCableTested.Name = "ckInsCableTested"
        Me.ckInsCableTested.Size = New System.Drawing.Size(180, 21)
        Me.ckInsCableTested.TabIndex = 5
        Me.ckInsCableTested.Text = "Instrument Cable Tested"
        Me.ckInsCableTested.UseVisualStyleBackColor = True
        '
        'ckInsCableGland2End
        '
        Me.ckInsCableGland2End.AutoSize = True
        Me.ckInsCableGland2End.Location = New System.Drawing.Point(33, 236)
        Me.ckInsCableGland2End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCableGland2End.Name = "ckInsCableGland2End"
        Me.ckInsCableGland2End.Size = New System.Drawing.Size(231, 21)
        Me.ckInsCableGland2End.TabIndex = 4
        Me.ckInsCableGland2End.Text = "Instrument Cable Gland (To) End"
        Me.ckInsCableGland2End.UseVisualStyleBackColor = True
        '
        'ckInsCableGland1End
        '
        Me.ckInsCableGland1End.AutoSize = True
        Me.ckInsCableGland1End.Location = New System.Drawing.Point(33, 188)
        Me.ckInsCableGland1End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCableGland1End.Name = "ckInsCableGland1End"
        Me.ckInsCableGland1End.Size = New System.Drawing.Size(247, 21)
        Me.ckInsCableGland1End.TabIndex = 3
        Me.ckInsCableGland1End.Text = "Instrument Cable Gland (From) End"
        Me.ckInsCableGland1End.UseVisualStyleBackColor = True
        '
        'ckInsCableCon2End
        '
        Me.ckInsCableCon2End.AutoSize = True
        Me.ckInsCableCon2End.Location = New System.Drawing.Point(33, 140)
        Me.ckInsCableCon2End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCableCon2End.Name = "ckInsCableCon2End"
        Me.ckInsCableCon2End.Size = New System.Drawing.Size(249, 21)
        Me.ckInsCableCon2End.TabIndex = 2
        Me.ckInsCableCon2End.Text = "Instrument Cable Connect (To) End"
        Me.ckInsCableCon2End.UseVisualStyleBackColor = True
        '
        'ckInsCableCon1End
        '
        Me.ckInsCableCon1End.AutoSize = True
        Me.ckInsCableCon1End.Location = New System.Drawing.Point(33, 92)
        Me.ckInsCableCon1End.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCableCon1End.Name = "ckInsCableCon1End"
        Me.ckInsCableCon1End.Size = New System.Drawing.Size(265, 21)
        Me.ckInsCableCon1End.TabIndex = 1
        Me.ckInsCableCon1End.Text = "Instrument Cable Connect (From) End"
        Me.ckInsCableCon1End.UseVisualStyleBackColor = True
        '
        'ckInsCablePulled
        '
        Me.ckInsCablePulled.AutoSize = True
        Me.ckInsCablePulled.Location = New System.Drawing.Point(33, 44)
        Me.ckInsCablePulled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckInsCablePulled.Name = "ckInsCablePulled"
        Me.ckInsCablePulled.Size = New System.Drawing.Size(174, 21)
        Me.ckInsCablePulled.TabIndex = 0
        Me.ckInsCablePulled.Text = "Instrument Cable Pulled"
        Me.ckInsCablePulled.UseVisualStyleBackColor = True
        '
        'gbEleJB
        '
        Me.gbEleJB.Controls.Add(Me.ckEleJBInstalled)
        Me.gbEleJB.Location = New System.Drawing.Point(57, 207)
        Me.gbEleJB.Margin = New System.Windows.Forms.Padding(4)
        Me.gbEleJB.Name = "gbEleJB"
        Me.gbEleJB.Padding = New System.Windows.Forms.Padding(4)
        Me.gbEleJB.Size = New System.Drawing.Size(403, 106)
        Me.gbEleJB.TabIndex = 14
        Me.gbEleJB.TabStop = False
        Me.gbEleJB.Text = "Electrical JB Steps"
        Me.gbEleJB.Visible = False
        '
        'ckEleJBInstalled
        '
        Me.ckEleJBInstalled.AutoSize = True
        Me.ckEleJBInstalled.Location = New System.Drawing.Point(33, 44)
        Me.ckEleJBInstalled.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEleJBInstalled.Name = "ckEleJBInstalled"
        Me.ckEleJBInstalled.Size = New System.Drawing.Size(153, 21)
        Me.ckEleJBInstalled.TabIndex = 0
        Me.ckEleJBInstalled.Text = "Electrical JB Installed"
        Me.ckEleJBInstalled.UseVisualStyleBackColor = True
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(578, 75)
        '
        'frmSelectStep
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(578, 662)
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
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSelectStep.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSelectStep"
        Me.Ribbon = Me.RibbonControl1
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
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
End Class
