<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEICALogin
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
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, Nothing, True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEICALogin))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDB = New System.Windows.Forms.TextBox()
        Me.txtConn = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.opnFile = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager
        '
        SplashScreenManager.ClosingDelay = 500
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(54, 268)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 226)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "User:"
        '
        'txtPass
        '
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Location = New System.Drawing.Point(116, 265)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(46)
        Me.txtPass.Size = New System.Drawing.Size(528, 21)
        Me.txtPass.TabIndex = 4
        '
        'txtUser
        '
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Location = New System.Drawing.Point(116, 223)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(528, 21)
        Me.txtUser.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 182)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Database:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 140)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Server:"
        '
        'txtDB
        '
        Me.txtDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDB.Location = New System.Drawing.Point(116, 179)
        Me.txtDB.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(528, 21)
        Me.txtDB.TabIndex = 2
        '
        'txtConn
        '
        Me.txtConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConn.Location = New System.Drawing.Point(116, 137)
        Me.txtConn.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConn.Name = "txtConn"
        Me.txtConn.Size = New System.Drawing.Size(528, 21)
        Me.txtConn.TabIndex = 1
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.EEICA.My.Resources.Resources.EEICA_Logo
        Me.PictureBox3.Location = New System.Drawing.Point(13, 316)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(110, 95)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 28
        Me.PictureBox3.TabStop = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(341, 360)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(149, 51)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Login"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(496, 360)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(149, 51)
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "Exit"
        '
        'opnFile
        '
        Me.opnFile.Title = "Select login details"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Options.UseTextOptions = True
        Me.SimpleButton3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SimpleButton3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(582, 98)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(62, 33)
        Me.SimpleButton3.TabIndex = 0
        Me.SimpleButton3.Text = "..."
        Me.SimpleButton3.ToolTipTitle = "Load Details from File"
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(659, 60)
        '
        'frmEICALogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile
        Me.BackgroundImageStore = Global.EEICA.My.Resources.Resources.LoginbackgroundTrans2
        Me.ClientSize = New System.Drawing.Size(659, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.txtConn)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmEICALogin.IconOptions.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmEICALogin"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EEICA Login"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDB As TextBox
    Friend WithEvents txtConn As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents opnFile As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
End Class
