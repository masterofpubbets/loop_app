<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHCSConnectionSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHCSConnectionSettings))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.txtDBLocation = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDBName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtElementsQuery = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTasksQuery = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLoopApprovedQuery = New System.Windows.Forms.TextBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCLosedItemsQuery = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGroupsQuery = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUpdateSubsystemQuery = New System.Windows.Forms.TextBox()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 1
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1200, 58)
        '
        'txtDBLocation
        '
        Me.txtDBLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBLocation.Location = New System.Drawing.Point(143, 112)
        Me.txtDBLocation.Name = "txtDBLocation"
        Me.txtDBLocation.Size = New System.Drawing.Size(388, 21)
        Me.txtDBLocation.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DB Location:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(602, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "DB Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDBName
        '
        Me.txtDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBName.Location = New System.Drawing.Point(719, 112)
        Me.txtDBName.Name = "txtDBName"
        Me.txtDBName.Size = New System.Drawing.Size(452, 21)
        Me.txtDBName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Elements Query:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtElementsQuery
        '
        Me.txtElementsQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElementsQuery.Location = New System.Drawing.Point(143, 149)
        Me.txtElementsQuery.Multiline = True
        Me.txtElementsQuery.Name = "txtElementsQuery"
        Me.txtElementsQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtElementsQuery.Size = New System.Drawing.Size(404, 149)
        Me.txtElementsQuery.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(602, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Tasks Query:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTasksQuery
        '
        Me.txtTasksQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasksQuery.Location = New System.Drawing.Point(719, 148)
        Me.txtTasksQuery.Multiline = True
        Me.txtTasksQuery.Name = "txtTasksQuery"
        Me.txtTasksQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTasksQuery.Size = New System.Drawing.Size(469, 150)
        Me.txtTasksQuery.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 429)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 24)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Loop Approved Query:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoopApprovedQuery
        '
        Me.txtLoopApprovedQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopApprovedQuery.Location = New System.Drawing.Point(143, 429)
        Me.txtLoopApprovedQuery.Multiline = True
        Me.txtLoopApprovedQuery.Name = "txtLoopApprovedQuery"
        Me.txtLoopApprovedQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLoopApprovedQuery.Size = New System.Drawing.Size(404, 172)
        Me.txtLoopApprovedQuery.TabIndex = 6
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(804, 639)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton2.TabIndex = 8
        Me.SimpleButton2.Text = "Save"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(999, 639)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton1.TabIndex = 9
        Me.SimpleButton1.Text = "Cancel"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(602, 300)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 24)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Closed Items Query:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCLosedItemsQuery
        '
        Me.txtCLosedItemsQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCLosedItemsQuery.Location = New System.Drawing.Point(719, 304)
        Me.txtCLosedItemsQuery.Multiline = True
        Me.txtCLosedItemsQuery.Name = "txtCLosedItemsQuery"
        Me.txtCLosedItemsQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCLosedItemsQuery.Size = New System.Drawing.Size(469, 115)
        Me.txtCLosedItemsQuery.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 304)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 24)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Groups Query:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGroupsQuery
        '
        Me.txtGroupsQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGroupsQuery.Location = New System.Drawing.Point(143, 304)
        Me.txtGroupsQuery.Multiline = True
        Me.txtGroupsQuery.Name = "txtGroupsQuery"
        Me.txtGroupsQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGroupsQuery.Size = New System.Drawing.Size(404, 119)
        Me.txtGroupsQuery.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(602, 425)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 24)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Update Subsystem Query"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUpdateSubsystemQuery
        '
        Me.txtUpdateSubsystemQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUpdateSubsystemQuery.Location = New System.Drawing.Point(719, 425)
        Me.txtUpdateSubsystemQuery.Multiline = True
        Me.txtUpdateSubsystemQuery.Name = "txtUpdateSubsystemQuery"
        Me.txtUpdateSubsystemQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtUpdateSubsystemQuery.Size = New System.Drawing.Size(469, 168)
        Me.txtUpdateSubsystemQuery.TabIndex = 7
        '
        'frmHCSConnectionSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtUpdateSubsystemQuery)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtGroupsQuery)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCLosedItemsQuery)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLoopApprovedQuery)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTasksQuery)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtElementsQuery)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDBName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDBLocation)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmHCSConnectionSettings.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmHCSConnectionSettings"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HCS Connection Settings"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents txtDBLocation As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtElementsQuery As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTasksQuery As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLoopApprovedQuery As TextBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCLosedItemsQuery As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtGroupsQuery As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtUpdateSubsystemQuery As TextBox
End Class
