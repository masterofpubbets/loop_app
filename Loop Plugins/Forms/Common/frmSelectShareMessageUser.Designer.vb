<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelectShareMessageUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectShareMessageUser))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblActionBy = New System.Windows.Forms.Label()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.RibbonControl1.Size = New System.Drawing.Size(830, 60)
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(746, 93)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(71, 37)
        Me.SimpleButton3.TabIndex = 0
        Me.SimpleButton3.Text = "Select"
        '
        'lblActionBy
        '
        Me.lblActionBy.Location = New System.Drawing.Point(188, 96)
        Me.lblActionBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblActionBy.Name = "lblActionBy"
        Me.lblActionBy.Size = New System.Drawing.Size(536, 32)
        Me.lblActionBy.TabIndex = 20
        Me.lblActionBy.Text = "---"
        Me.lblActionBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(430, 460)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(189, 54)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "Share"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(628, 460)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(189, 54)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "Cancel"
        '
        'txtDescription
        '
        Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescription.Location = New System.Drawing.Point(191, 155)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(626, 252)
        Me.txtDescription.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 155)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Sharing Message:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 104)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Share With:"
        '
        'frmSelectShareMessageUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 527)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.lblActionBy)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmSelectShareMessageUser.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmSelectShareMessageUser"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sharing info"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblActionBy As Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
End Class
