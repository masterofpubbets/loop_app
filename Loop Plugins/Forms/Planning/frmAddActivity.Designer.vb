<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddActivity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddActivity))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtActId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbEICAArea = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPCSBudget = New DevExpress.XtraEditors.TextEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkKeyQnty = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dteStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtActName = New System.Windows.Forms.TextBox()
        Me.txtPCSArea = New System.Windows.Forms.TextBox()
        Me.txtSubcon = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFamily = New System.Windows.Forms.TextBox()
        Me.txtEICABudget = New DevExpress.XtraEditors.TextEdit()
        Me.txtPackage = New System.Windows.Forms.TextBox()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.txtResourceId = New System.Windows.Forms.TextBox()
        Me.txtResourceName = New System.Windows.Forms.TextBox()
        Me.txtUOM = New System.Windows.Forms.TextBox()
        Me.txtWPS = New System.Windows.Forms.TextBox()
        Me.txtTeam = New System.Windows.Forms.TextBox()
        Me.dteEndDate = New System.Windows.Forms.DateTimePicker()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPCSBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEICABudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Size = New System.Drawing.Size(1011, 60)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Activity ID:"
        '
        'txtActId
        '
        Me.txtActId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActId.Location = New System.Drawing.Point(154, 134)
        Me.txtActId.Name = "txtActId"
        Me.txtActId.Size = New System.Drawing.Size(312, 21)
        Me.txtActId.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Activity Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PCS Area:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(563, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "EICA Area:"
        '
        'cmbEICAArea
        '
        Me.cmbEICAArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEICAArea.FormattingEnabled = True
        Me.cmbEICAArea.Location = New System.Drawing.Point(653, 134)
        Me.cmbEICAArea.Name = "cmbEICAArea"
        Me.cmbEICAArea.Size = New System.Drawing.Size(312, 21)
        Me.cmbEICAArea.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Subcontractor:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 238)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "PCS Budget:"
        '
        'txtPCSBudget
        '
        Me.txtPCSBudget.Location = New System.Drawing.Point(154, 235)
        Me.txtPCSBudget.MenuManager = Me.RibbonControl1
        Me.txtPCSBudget.Name = "txtPCSBudget"
        Me.txtPCSBudget.Properties.EditFormat.FormatString = "n"
        Me.txtPCSBudget.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPCSBudget.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtPCSBudget.Properties.NullText = "0"
        Me.txtPCSBudget.Properties.ValidateOnEnterKey = True
        Me.txtPCSBudget.Size = New System.Drawing.Size(312, 20)
        Me.txtPCSBudget.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(563, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "EICA Budget:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 274)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Package:"
        '
        'chkKeyQnty
        '
        Me.chkKeyQnty.AutoSize = True
        Me.chkKeyQnty.Checked = True
        Me.chkKeyQnty.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKeyQnty.Location = New System.Drawing.Point(653, 384)
        Me.chkKeyQnty.Name = "chkKeyQnty"
        Me.chkKeyQnty.Size = New System.Drawing.Size(71, 17)
        Me.chkKeyQnty.TabIndex = 17
        Me.chkKeyQnty.Text = "Key Qnty"
        Me.chkKeyQnty.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(52, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "WPS:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(52, 310)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Resource Id:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(563, 311)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Resource Name:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(563, 275)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Location:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(563, 350)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Team:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(52, 383)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "Start Date:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(52, 415)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "End Date:"
        '
        'dteStartDate
        '
        Me.dteStartDate.Location = New System.Drawing.Point(154, 379)
        Me.dteStartDate.Name = "dteStartDate"
        Me.dteStartDate.Size = New System.Drawing.Size(312, 21)
        Me.dteStartDate.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(563, 240)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "UOM:"
        '
        'txtActName
        '
        Me.txtActName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActName.Location = New System.Drawing.Point(154, 95)
        Me.txtActName.Name = "txtActName"
        Me.txtActName.Size = New System.Drawing.Size(497, 21)
        Me.txtActName.TabIndex = 0
        '
        'txtPCSArea
        '
        Me.txtPCSArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPCSArea.Location = New System.Drawing.Point(154, 167)
        Me.txtPCSArea.Name = "txtPCSArea"
        Me.txtPCSArea.Size = New System.Drawing.Size(312, 21)
        Me.txtPCSArea.TabIndex = 2
        '
        'txtSubcon
        '
        Me.txtSubcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubcon.Location = New System.Drawing.Point(154, 200)
        Me.txtSubcon.Name = "txtSubcon"
        Me.txtSubcon.Size = New System.Drawing.Size(312, 21)
        Me.txtSubcon.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(563, 170)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "Family:"
        '
        'txtFamily
        '
        Me.txtFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFamily.Location = New System.Drawing.Point(653, 167)
        Me.txtFamily.Name = "txtFamily"
        Me.txtFamily.Size = New System.Drawing.Size(312, 21)
        Me.txtFamily.TabIndex = 11
        '
        'txtEICABudget
        '
        Me.txtEICABudget.Location = New System.Drawing.Point(653, 202)
        Me.txtEICABudget.MenuManager = Me.RibbonControl1
        Me.txtEICABudget.Name = "txtEICABudget"
        Me.txtEICABudget.Properties.EditFormat.FormatString = "n"
        Me.txtEICABudget.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtEICABudget.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtEICABudget.Properties.NullText = "0"
        Me.txtEICABudget.Properties.ValidateOnEnterKey = True
        Me.txtEICABudget.Size = New System.Drawing.Size(312, 20)
        Me.txtEICABudget.TabIndex = 12
        '
        'txtPackage
        '
        Me.txtPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPackage.Location = New System.Drawing.Point(154, 271)
        Me.txtPackage.Name = "txtPackage"
        Me.txtPackage.Size = New System.Drawing.Size(312, 21)
        Me.txtPackage.TabIndex = 5
        '
        'txtLocation
        '
        Me.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocation.Location = New System.Drawing.Point(653, 272)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(312, 21)
        Me.txtLocation.TabIndex = 14
        '
        'txtResourceId
        '
        Me.txtResourceId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResourceId.Location = New System.Drawing.Point(154, 306)
        Me.txtResourceId.Name = "txtResourceId"
        Me.txtResourceId.Size = New System.Drawing.Size(312, 21)
        Me.txtResourceId.TabIndex = 6
        '
        'txtResourceName
        '
        Me.txtResourceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResourceName.Location = New System.Drawing.Point(653, 308)
        Me.txtResourceName.Name = "txtResourceName"
        Me.txtResourceName.Size = New System.Drawing.Size(312, 21)
        Me.txtResourceName.TabIndex = 15
        '
        'txtUOM
        '
        Me.txtUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUOM.Location = New System.Drawing.Point(653, 236)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.Size = New System.Drawing.Size(312, 21)
        Me.txtUOM.TabIndex = 13
        '
        'txtWPS
        '
        Me.txtWPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWPS.Location = New System.Drawing.Point(154, 342)
        Me.txtWPS.Name = "txtWPS"
        Me.txtWPS.Size = New System.Drawing.Size(312, 21)
        Me.txtWPS.TabIndex = 7
        '
        'txtTeam
        '
        Me.txtTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeam.Location = New System.Drawing.Point(653, 345)
        Me.txtTeam.Name = "txtTeam"
        Me.txtTeam.Size = New System.Drawing.Size(312, 21)
        Me.txtTeam.TabIndex = 16
        '
        'dteEndDate
        '
        Me.dteEndDate.Location = New System.Drawing.Point(154, 412)
        Me.dteEndDate.Name = "dteEndDate"
        Me.dteEndDate.Size = New System.Drawing.Size(312, 21)
        Me.dteEndDate.TabIndex = 9
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(849, 554)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(150, 56)
        Me.SimpleButton1.TabIndex = 19
        Me.SimpleButton1.Text = "Cancel"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(693, 554)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(150, 56)
        Me.SimpleButton2.TabIndex = 18
        Me.SimpleButton2.Text = "Add"
        '
        'frmAddActivity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 622)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.dteEndDate)
        Me.Controls.Add(Me.txtTeam)
        Me.Controls.Add(Me.txtWPS)
        Me.Controls.Add(Me.txtUOM)
        Me.Controls.Add(Me.txtResourceName)
        Me.Controls.Add(Me.txtResourceId)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.txtPackage)
        Me.Controls.Add(Me.txtEICABudget)
        Me.Controls.Add(Me.txtFamily)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtSubcon)
        Me.Controls.Add(Me.txtPCSArea)
        Me.Controls.Add(Me.txtActName)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dteStartDate)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkKeyQnty)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPCSBudget)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbEICAArea)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtActId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmAddActivity.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmAddActivity"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add New Activity"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPCSBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEICABudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents Label1 As Label
    Friend WithEvents txtActId As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbEICAArea As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPCSBudget As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents chkKeyQnty As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents dteStartDate As DateTimePicker
    Friend WithEvents Label18 As Label
    Friend WithEvents txtActName As TextBox
    Friend WithEvents txtPCSArea As TextBox
    Friend WithEvents txtSubcon As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtFamily As TextBox
    Friend WithEvents txtEICABudget As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPackage As TextBox
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents txtResourceId As TextBox
    Friend WithEvents txtResourceName As TextBox
    Friend WithEvents txtUOM As TextBox
    Friend WithEvents txtWPS As TextBox
    Friend WithEvents txtTeam As TextBox
    Friend WithEvents dteEndDate As DateTimePicker
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
