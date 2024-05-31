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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFinalClean = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSoloRunApprovedQuery = New System.Windows.Forms.TextBox()
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
        Me.RibbonControl1.Size = New System.Drawing.Size(1200, 60)
        '
        'txtDBLocation
        '
        Me.txtDBLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDBLocation.Location = New System.Drawing.Point(152, 112)
        Me.txtDBLocation.Name = "txtDBLocation"
        Me.txtDBLocation.Size = New System.Drawing.Size(388, 21)
        Me.txtDBLocation.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 24)
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
        Me.txtDBName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Elements Query:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtElementsQuery
        '
        Me.txtElementsQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElementsQuery.Location = New System.Drawing.Point(152, 149)
        Me.txtElementsQuery.Multiline = True
        Me.txtElementsQuery.Name = "txtElementsQuery"
        Me.txtElementsQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtElementsQuery.Size = New System.Drawing.Size(404, 121)
        Me.txtElementsQuery.TabIndex = 1
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
        Me.txtTasksQuery.Size = New System.Drawing.Size(469, 122)
        Me.txtTasksQuery.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 385)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 24)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Loop Approved Query:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoopApprovedQuery
        '
        Me.txtLoopApprovedQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopApprovedQuery.Location = New System.Drawing.Point(152, 385)
        Me.txtLoopApprovedQuery.Multiline = True
        Me.txtLoopApprovedQuery.Name = "txtLoopApprovedQuery"
        Me.txtLoopApprovedQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLoopApprovedQuery.Size = New System.Drawing.Size(404, 99)
        Me.txtLoopApprovedQuery.TabIndex = 3
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(804, 639)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton2.TabIndex = 10
        Me.SimpleButton2.Text = "Save"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(999, 639)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton1.TabIndex = 11
        Me.SimpleButton1.Text = "Close"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(602, 282)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 24)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Closed Items Query:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCLosedItemsQuery
        '
        Me.txtCLosedItemsQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCLosedItemsQuery.Location = New System.Drawing.Point(719, 282)
        Me.txtCLosedItemsQuery.Multiline = True
        Me.txtCLosedItemsQuery.Name = "txtCLosedItemsQuery"
        Me.txtCLosedItemsQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCLosedItemsQuery.Size = New System.Drawing.Size(469, 87)
        Me.txtCLosedItemsQuery.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(12, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 24)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Groups Query:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGroupsQuery
        '
        Me.txtGroupsQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGroupsQuery.Location = New System.Drawing.Point(152, 282)
        Me.txtGroupsQuery.Multiline = True
        Me.txtGroupsQuery.Name = "txtGroupsQuery"
        Me.txtGroupsQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGroupsQuery.Size = New System.Drawing.Size(404, 91)
        Me.txtGroupsQuery.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(602, 381)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 24)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Update Subsystem Query"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUpdateSubsystemQuery
        '
        Me.txtUpdateSubsystemQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUpdateSubsystemQuery.Location = New System.Drawing.Point(719, 381)
        Me.txtUpdateSubsystemQuery.Multiline = True
        Me.txtUpdateSubsystemQuery.Name = "txtUpdateSubsystemQuery"
        Me.txtUpdateSubsystemQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtUpdateSubsystemQuery.Size = New System.Drawing.Size(469, 103)
        Me.txtUpdateSubsystemQuery.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(602, 496)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 24)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Final Clean:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFinalClean
        '
        Me.txtFinalClean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFinalClean.Location = New System.Drawing.Point(719, 496)
        Me.txtFinalClean.Multiline = True
        Me.txtFinalClean.Name = "txtFinalClean"
        Me.txtFinalClean.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFinalClean.Size = New System.Drawing.Size(469, 99)
        Me.txtFinalClean.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(12, 496)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 24)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "SoloRun Approved Query:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSoloRunApprovedQuery
        '
        Me.txtSoloRunApprovedQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSoloRunApprovedQuery.Location = New System.Drawing.Point(152, 496)
        Me.txtSoloRunApprovedQuery.Multiline = True
        Me.txtSoloRunApprovedQuery.Name = "txtSoloRunApprovedQuery"
        Me.txtSoloRunApprovedQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSoloRunApprovedQuery.Size = New System.Drawing.Size(404, 99)
        Me.txtSoloRunApprovedQuery.TabIndex = 4
        '
        'frmHCSConnectionSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSoloRunApprovedQuery)
        Me.Controls.Add(Me.txtFinalClean)
        Me.Controls.Add(Me.Label9)
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
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFinalClean As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSoloRunApprovedQuery As TextBox
End Class
