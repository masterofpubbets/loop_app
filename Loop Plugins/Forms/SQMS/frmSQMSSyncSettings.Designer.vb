<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSQMSSyncSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSQMSSyncSettings))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLoopTestApproved = New System.Windows.Forms.TextBox()
        Me.txtFinalClean = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMotorSoloRunApproved = New System.Windows.Forms.TextBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLoopTestScope = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLoopFolderTaskFilter = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMotorSoloRunScope = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSoloRunTaskFilter = New System.Windows.Forms.TextBox()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.TabNavigationPage2 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.TabNavigationPage3 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBoxupTaskFilter = New System.Windows.Forms.TextBox()
        Me.txtBoxUpScope = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabNavigationPage4 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBoxupApproved = New System.Windows.Forms.TextBox()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPage1.SuspendLayout()
        Me.TabNavigationPage2.SuspendLayout()
        Me.TabNavigationPage3.SuspendLayout()
        Me.TabNavigationPage4.SuspendLayout()
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
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(22, 161)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 24)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Loop Test Approved:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoopTestApproved
        '
        Me.txtLoopTestApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopTestApproved.Location = New System.Drawing.Point(164, 165)
        Me.txtLoopTestApproved.Multiline = True
        Me.txtLoopTestApproved.Name = "txtLoopTestApproved"
        Me.txtLoopTestApproved.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLoopTestApproved.Size = New System.Drawing.Size(520, 121)
        Me.txtLoopTestApproved.TabIndex = 1
        '
        'txtFinalClean
        '
        Me.txtFinalClean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFinalClean.Location = New System.Drawing.Point(164, 38)
        Me.txtFinalClean.Multiline = True
        Me.txtFinalClean.Name = "txtFinalClean"
        Me.txtFinalClean.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFinalClean.Size = New System.Drawing.Size(520, 121)
        Me.txtFinalClean.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(22, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 24)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Final Clean:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(22, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(136, 24)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Solo Run Approved:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMotorSoloRunApproved
        '
        Me.txtMotorSoloRunApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotorSoloRunApproved.Location = New System.Drawing.Point(164, 165)
        Me.txtMotorSoloRunApproved.Multiline = True
        Me.txtMotorSoloRunApproved.Name = "txtMotorSoloRunApproved"
        Me.txtMotorSoloRunApproved.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotorSoloRunApproved.Size = New System.Drawing.Size(520, 121)
        Me.txtMotorSoloRunApproved.TabIndex = 1
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(804, 639)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton2.TabIndex = 0
        Me.SimpleButton2.Text = "Save"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(999, 639)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(189, 49)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "Close"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(22, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 24)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Loop Test Scope:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoopTestScope
        '
        Me.txtLoopTestScope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopTestScope.Location = New System.Drawing.Point(164, 38)
        Me.txtLoopTestScope.Multiline = True
        Me.txtLoopTestScope.Name = "txtLoopTestScope"
        Me.txtLoopTestScope.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLoopTestScope.Size = New System.Drawing.Size(520, 121)
        Me.txtLoopTestScope.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(22, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 24)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Loop Tasks Filter:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLoopFolderTaskFilter
        '
        Me.txtLoopFolderTaskFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLoopFolderTaskFilter.Location = New System.Drawing.Point(164, 292)
        Me.txtLoopFolderTaskFilter.Multiline = True
        Me.txtLoopFolderTaskFilter.Name = "txtLoopFolderTaskFilter"
        Me.txtLoopFolderTaskFilter.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLoopFolderTaskFilter.Size = New System.Drawing.Size(520, 121)
        Me.txtLoopFolderTaskFilter.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(22, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 24)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Solo Run Scope:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMotorSoloRunScope
        '
        Me.txtMotorSoloRunScope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMotorSoloRunScope.Location = New System.Drawing.Point(164, 38)
        Me.txtMotorSoloRunScope.Multiline = True
        Me.txtMotorSoloRunScope.Name = "txtMotorSoloRunScope"
        Me.txtMotorSoloRunScope.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMotorSoloRunScope.Size = New System.Drawing.Size(520, 121)
        Me.txtMotorSoloRunScope.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom
        Me.LabelControl1.LineVisible = True
        Me.LabelControl1.Location = New System.Drawing.Point(15, 76)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(1173, 42)
        Me.LabelControl1.TabIndex = 48
        Me.LabelControl1.Text = "SQMS Tasks Filtration"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 24)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Solo Run Task Filter:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSoloRunTaskFilter
        '
        Me.txtSoloRunTaskFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSoloRunTaskFilter.Location = New System.Drawing.Point(164, 292)
        Me.txtSoloRunTaskFilter.Multiline = True
        Me.txtSoloRunTaskFilter.Name = "txtSoloRunTaskFilter"
        Me.txtSoloRunTaskFilter.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSoloRunTaskFilter.Size = New System.Drawing.Size(520, 121)
        Me.txtSoloRunTaskFilter.TabIndex = 2
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage2)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage3)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage4)
        Me.TabPane1.Location = New System.Drawing.Point(42, 124)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1, Me.TabNavigationPage2, Me.TabNavigationPage3, Me.TabNavigationPage4})
        Me.TabPane1.RegularSize = New System.Drawing.Size(1146, 461)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        Me.TabPane1.Size = New System.Drawing.Size(1146, 461)
        Me.TabPane1.TabIndex = 1
        Me.TabPane1.Text = "TabPane1"
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.Caption = "Loop Test"
        Me.TabNavigationPage1.Controls.Add(Me.Label4)
        Me.TabNavigationPage1.Controls.Add(Me.txtLoopFolderTaskFilter)
        Me.TabNavigationPage1.Controls.Add(Me.Label10)
        Me.TabNavigationPage1.Controls.Add(Me.Label5)
        Me.TabNavigationPage1.Controls.Add(Me.txtLoopTestApproved)
        Me.TabNavigationPage1.Controls.Add(Me.txtLoopTestScope)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(1146, 428)
        '
        'TabNavigationPage2
        '
        Me.TabNavigationPage2.Caption = "Solo Run"
        Me.TabNavigationPage2.Controls.Add(Me.Label3)
        Me.TabNavigationPage2.Controls.Add(Me.Label1)
        Me.TabNavigationPage2.Controls.Add(Me.txtSoloRunTaskFilter)
        Me.TabNavigationPage2.Controls.Add(Me.txtMotorSoloRunScope)
        Me.TabNavigationPage2.Controls.Add(Me.txtMotorSoloRunApproved)
        Me.TabNavigationPage2.Controls.Add(Me.Label7)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.Size = New System.Drawing.Size(1146, 428)
        '
        'TabNavigationPage3
        '
        Me.TabNavigationPage3.Caption = "Boxup"
        Me.TabNavigationPage3.Controls.Add(Me.Label8)
        Me.TabNavigationPage3.Controls.Add(Me.txtBoxupApproved)
        Me.TabNavigationPage3.Controls.Add(Me.Label6)
        Me.TabNavigationPage3.Controls.Add(Me.txtBoxupTaskFilter)
        Me.TabNavigationPage3.Controls.Add(Me.txtBoxUpScope)
        Me.TabNavigationPage3.Controls.Add(Me.Label2)
        Me.TabNavigationPage3.Name = "TabNavigationPage3"
        Me.TabNavigationPage3.Size = New System.Drawing.Size(1146, 428)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(22, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 24)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Boxup Task Filter:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxupTaskFilter
        '
        Me.txtBoxupTaskFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxupTaskFilter.Location = New System.Drawing.Point(164, 292)
        Me.txtBoxupTaskFilter.Multiline = True
        Me.txtBoxupTaskFilter.Name = "txtBoxupTaskFilter"
        Me.txtBoxupTaskFilter.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBoxupTaskFilter.Size = New System.Drawing.Size(520, 121)
        Me.txtBoxupTaskFilter.TabIndex = 2
        '
        'txtBoxUpScope
        '
        Me.txtBoxUpScope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxUpScope.Location = New System.Drawing.Point(164, 38)
        Me.txtBoxUpScope.Multiline = True
        Me.txtBoxUpScope.Name = "txtBoxUpScope"
        Me.txtBoxUpScope.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBoxUpScope.Size = New System.Drawing.Size(520, 121)
        Me.txtBoxUpScope.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(22, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 24)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Box Up Scope:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabNavigationPage4
        '
        Me.TabNavigationPage4.Caption = "Global"
        Me.TabNavigationPage4.Controls.Add(Me.Label9)
        Me.TabNavigationPage4.Controls.Add(Me.txtFinalClean)
        Me.TabNavigationPage4.Name = "TabNavigationPage4"
        Me.TabNavigationPage4.Size = New System.Drawing.Size(1146, 434)
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(139, 24)
        Me.Label8.TabIndex = 55
        Me.Label8.Text = "Boxup Approved:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBoxupApproved
        '
        Me.txtBoxupApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxupApproved.Location = New System.Drawing.Point(164, 165)
        Me.txtBoxupApproved.Multiline = True
        Me.txtBoxupApproved.Name = "txtBoxupApproved"
        Me.txtBoxupApproved.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBoxupApproved.Size = New System.Drawing.Size(520, 121)
        Me.txtBoxupApproved.TabIndex = 1
        '
        'frmSQMSSyncSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabPane1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.LargeImage = CType(resources.GetObject("frmSQMSSyncSettings.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "frmSQMSSyncSettings"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQMS Sync Settings"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPage1.ResumeLayout(False)
        Me.TabNavigationPage1.PerformLayout()
        Me.TabNavigationPage2.ResumeLayout(False)
        Me.TabNavigationPage2.PerformLayout()
        Me.TabNavigationPage3.ResumeLayout(False)
        Me.TabNavigationPage3.PerformLayout()
        Me.TabNavigationPage4.ResumeLayout(False)
        Me.TabNavigationPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents Label10 As Label
    Friend WithEvents txtLoopTestApproved As TextBox
    Friend WithEvents txtFinalClean As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMotorSoloRunApproved As TextBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLoopTestScope As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLoopFolderTaskFilter As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMotorSoloRunScope As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSoloRunTaskFilter As TextBox
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage3 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage4 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents txtBoxUpScope As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBoxupTaskFilter As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBoxupApproved As TextBox
End Class
