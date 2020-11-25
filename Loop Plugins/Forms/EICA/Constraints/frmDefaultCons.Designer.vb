<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDefaultCons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDefaultCons))
        Me.lst = New System.Windows.Forms.ListBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'lst
        '
        Me.lst.BackColor = System.Drawing.SystemColors.Control
        Me.lst.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lst.FormattingEnabled = True
        Me.lst.Items.AddRange(New Object() {"On Hold Engineering", "On Hold  Vendor/Missing ILD", "On Hold Main Ctrl Room", "On Hold Construction", "On Hold DELETED", "On Hold Engineering", "On Hold Control Room", "On Hold Third Party", "On Hold Logical Loop", "On Hold Material", "On Hold Missing ILD", "On Hold Missing Sys Cabinet", "On Hold MOC", "On Hold No Power", "On Hold Troubleshooting", "On Hold Utility", "On Hold Vendor"})
        Me.lst.Location = New System.Drawing.Point(12, 12)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(538, 273)
        Me.lst.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 291)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(135, 39)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Copy"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(393, 348)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(157, 57)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "Close"
        '
        'frmDefaultCons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 417)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.lst)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDefaultCons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Default Constraints"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lst As ListBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
