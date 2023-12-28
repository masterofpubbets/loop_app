<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUser))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtJob = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ckLoopApproved = New System.Windows.Forms.CheckBox()
        Me.ckFolderBlockage = New System.Windows.Forms.CheckBox()
        Me.ckLoopDone = New System.Windows.Forms.CheckBox()
        Me.ckSubmittedToPrecomm = New System.Windows.Forms.CheckBox()
        Me.ckQCFolderReady = New System.Windows.Forms.CheckBox()
        Me.ckQCReleased = New System.Windows.Forms.CheckBox()
        Me.ckFolderPrepared = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pic = New System.Windows.Forms.PictureBox()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.opnFile = New System.Windows.Forms.OpenFileDialog()
        Me.txtTRUserName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ckcmbUserType = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckcmbUserType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(26, 24, 26, 24)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsMenuMinWidth = 283
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(654, 60)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User Name:"
        '
        'txtUserName
        '
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.Location = New System.Drawing.Point(126, 93)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(480, 21)
        Me.txtUserName.TabIndex = 0
        '
        'txtPass
        '
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Location = New System.Drawing.Point(126, 127)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(480, 21)
        Me.txtPass.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Pass:"
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(126, 160)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(480, 21)
        Me.txtName.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Full Name:"
        '
        'txtEmail
        '
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Location = New System.Drawing.Point(126, 193)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(480, 21)
        Me.txtEmail.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Email:"
        '
        'txtJob
        '
        Me.txtJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJob.Location = New System.Drawing.Point(126, 293)
        Me.txtJob.Name = "txtJob"
        Me.txtJob.Size = New System.Drawing.Size(480, 21)
        Me.txtJob.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Job:"
        '
        'txtDepartment
        '
        Me.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartment.Location = New System.Drawing.Point(126, 260)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(480, 21)
        Me.txtDepartment.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Department:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "User Type:"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(298, 635)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(170, 54)
        Me.SimpleButton2.TabIndex = 11
        Me.SimpleButton2.Text = "Add"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(474, 635)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(170, 54)
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckLoopApproved)
        Me.GroupBox1.Controls.Add(Me.ckFolderBlockage)
        Me.GroupBox1.Controls.Add(Me.ckLoopDone)
        Me.GroupBox1.Controls.Add(Me.ckSubmittedToPrecomm)
        Me.GroupBox1.Controls.Add(Me.ckQCFolderReady)
        Me.GroupBox1.Controls.Add(Me.ckQCReleased)
        Me.GroupBox1.Controls.Add(Me.ckFolderPrepared)
        Me.GroupBox1.Location = New System.Drawing.Point(126, 501)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(518, 119)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Loop Folders Notifications"
        '
        'ckLoopApproved
        '
        Me.ckLoopApproved.AutoSize = True
        Me.ckLoopApproved.Location = New System.Drawing.Point(357, 74)
        Me.ckLoopApproved.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckLoopApproved.Name = "ckLoopApproved"
        Me.ckLoopApproved.Size = New System.Drawing.Size(99, 17)
        Me.ckLoopApproved.TabIndex = 6
        Me.ckLoopApproved.Text = "Loop Approved"
        Me.ckLoopApproved.UseVisualStyleBackColor = True
        '
        'ckFolderBlockage
        '
        Me.ckFolderBlockage.AutoSize = True
        Me.ckFolderBlockage.Location = New System.Drawing.Point(357, 37)
        Me.ckFolderBlockage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckFolderBlockage.Name = "ckFolderBlockage"
        Me.ckFolderBlockage.Size = New System.Drawing.Size(101, 17)
        Me.ckFolderBlockage.TabIndex = 3
        Me.ckFolderBlockage.Text = "Folder Blockage"
        Me.ckFolderBlockage.UseVisualStyleBackColor = True
        '
        'ckLoopDone
        '
        Me.ckLoopDone.AutoSize = True
        Me.ckLoopDone.Location = New System.Drawing.Point(240, 74)
        Me.ckLoopDone.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckLoopDone.Name = "ckLoopDone"
        Me.ckLoopDone.Size = New System.Drawing.Size(77, 17)
        Me.ckLoopDone.TabIndex = 5
        Me.ckLoopDone.Text = "Loop Done"
        Me.ckLoopDone.UseVisualStyleBackColor = True
        '
        'ckSubmittedToPrecomm
        '
        Me.ckSubmittedToPrecomm.AutoSize = True
        Me.ckSubmittedToPrecomm.Location = New System.Drawing.Point(16, 74)
        Me.ckSubmittedToPrecomm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckSubmittedToPrecomm.Name = "ckSubmittedToPrecomm"
        Me.ckSubmittedToPrecomm.Size = New System.Drawing.Size(174, 17)
        Me.ckSubmittedToPrecomm.TabIndex = 4
        Me.ckSubmittedToPrecomm.Text = "Folder Submitted To Pre-Comm"
        Me.ckSubmittedToPrecomm.UseVisualStyleBackColor = True
        '
        'ckQCFolderReady
        '
        Me.ckQCFolderReady.AutoSize = True
        Me.ckQCFolderReady.Location = New System.Drawing.Point(240, 37)
        Me.ckQCFolderReady.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckQCFolderReady.Name = "ckQCFolderReady"
        Me.ckQCFolderReady.Size = New System.Drawing.Size(108, 17)
        Me.ckQCFolderReady.TabIndex = 2
        Me.ckQCFolderReady.Text = "QC Folder Ready"
        Me.ckQCFolderReady.UseVisualStyleBackColor = True
        '
        'ckQCReleased
        '
        Me.ckQCReleased.AutoSize = True
        Me.ckQCReleased.Location = New System.Drawing.Point(129, 37)
        Me.ckQCReleased.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckQCReleased.Name = "ckQCReleased"
        Me.ckQCReleased.Size = New System.Drawing.Size(88, 17)
        Me.ckQCReleased.TabIndex = 1
        Me.ckQCReleased.Text = "QC Released"
        Me.ckQCReleased.UseVisualStyleBackColor = True
        '
        'ckFolderPrepared
        '
        Me.ckFolderPrepared.AutoSize = True
        Me.ckFolderPrepared.Location = New System.Drawing.Point(16, 37)
        Me.ckFolderPrepared.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ckFolderPrepared.Name = "ckFolderPrepared"
        Me.ckFolderPrepared.Size = New System.Drawing.Size(103, 17)
        Me.ckFolderPrepared.TabIndex = 0
        Me.ckFolderPrepared.Text = "Folder Prepared"
        Me.ckFolderPrepared.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 366)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Photo:"
        '
        'pic
        '
        Me.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pic.Location = New System.Drawing.Point(126, 366)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(108, 130)
        Me.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic.TabIndex = 22
        Me.pic.TabStop = False
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(240, 366)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(71, 28)
        Me.SimpleButton3.TabIndex = 8
        Me.SimpleButton3.Text = "Select"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(240, 400)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(71, 28)
        Me.SimpleButton4.TabIndex = 9
        Me.SimpleButton4.Text = "Clear"
        '
        'opnFile
        '
        Me.opnFile.Filter = "JPG|*.jpg|PNG|*.png|JPEG|*.jpeg"
        '
        'txtTRUserName
        '
        Me.txtTRUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTRUserName.Location = New System.Drawing.Point(126, 327)
        Me.txtTRUserName.Name = "txtTRUserName"
        Me.txtTRUserName.Size = New System.Drawing.Size(480, 21)
        Me.txtTRUserName.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(41, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "TR User Name:"
        '
        'ckcmbUserType
        '
        Me.ckcmbUserType.EditValue = ""
        Me.ckcmbUserType.Location = New System.Drawing.Point(126, 225)
        Me.ckcmbUserType.MenuManager = Me.RibbonControl1
        Me.ckcmbUserType.Name = "ckcmbUserType"
        Me.ckcmbUserType.Properties.AllowMultiSelect = True
        Me.ckcmbUserType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ckcmbUserType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.CheckedListBoxItem() {New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Admin", "", "Admin"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Handover", "", "Handover"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Support Team", "", "Support Team"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("QC", "", "QC"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Construction", "", "Construction"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Precomm", "", "Precomm"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Production", "", "Production"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Planning", "", "Planning"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("ReadOnly", "", "ReadOnly"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("Loop Admin", "", "Loop Admin")})
        Me.ckcmbUserType.Properties.SortOrder = System.Windows.Forms.SortOrder.Ascending
        Me.ckcmbUserType.Size = New System.Drawing.Size(480, 20)
        Me.ckcmbUserType.TabIndex = 4
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 699)
        Me.Controls.Add(Me.ckcmbUserType)
        Me.Controls.Add(Me.txtTRUserName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.pic)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txtJob)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmAddUser.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmAddUser"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create User"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckcmbUserType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtJob As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ckLoopDone As CheckBox
    Friend WithEvents ckSubmittedToPrecomm As CheckBox
    Friend WithEvents ckQCFolderReady As CheckBox
    Friend WithEvents ckQCReleased As CheckBox
    Friend WithEvents ckFolderPrepared As CheckBox
    Friend WithEvents ckFolderBlockage As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents pic As PictureBox
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents opnFile As OpenFileDialog
    Friend WithEvents txtTRUserName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ckcmbUserType As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents ckLoopApproved As CheckBox
End Class
