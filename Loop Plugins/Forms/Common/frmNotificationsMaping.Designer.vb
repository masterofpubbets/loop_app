<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNotificationsMaping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotificationsMaping))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.lblFrom = New DevExpress.XtraEditors.LabelControl()
        Me.lblDes = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblHeader = New DevExpress.XtraEditors.LabelControl()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(802, 60)
        '
        'lblFrom
        '
        Me.lblFrom.Location = New System.Drawing.Point(27, 103)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(24, 13)
        Me.lblFrom.TabIndex = 71
        Me.lblFrom.Text = "From"
        '
        'lblDes
        '
        Me.lblDes.Location = New System.Drawing.Point(27, 141)
        Me.lblDes.Name = "lblDes"
        Me.lblDes.Size = New System.Drawing.Size(23, 13)
        Me.lblDes.TabIndex = 72
        Me.lblDes.Text = "Desc"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(662, 308)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(128, 44)
        Me.SimpleButton1.TabIndex = 73
        Me.SimpleButton1.Text = "Ignore"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(528, 308)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(128, 44)
        Me.SimpleButton2.TabIndex = 74
        Me.SimpleButton2.Text = "Show"
        '
        'lblHeader
        '
        Me.lblHeader.Location = New System.Drawing.Point(27, 122)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(23, 13)
        Me.lblHeader.TabIndex = 76
        Me.lblHeader.Text = "Desc"
        '
        'frmNotificationsMaping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.lblDes)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmNotificationsMaping.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmNotificationsMaping"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notifications"
        Me.TopMost = True
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents lblFrom As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblDes As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblHeader As DevExpress.XtraEditors.LabelControl
End Class
