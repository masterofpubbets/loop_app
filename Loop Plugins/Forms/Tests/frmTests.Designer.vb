<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTests
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
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GRD = New DevExpress.XtraGrid.GridControl()
        Me.gv = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(867, 36)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(138, 49)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'GRD
        '
        Me.GRD.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GRD.Location = New System.Drawing.Point(12, 118)
        Me.GRD.MainView = Me.gv
        Me.GRD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GRD.Name = "GRD"
        Me.GRD.Size = New System.Drawing.Size(993, 523)
        Me.GRD.TabIndex = 9
        Me.GRD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gv})
        '
        'gv
        '
        Me.gv.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Maroon
        Me.gv.Appearance.GroupFooter.Options.UseForeColor = True
        Me.gv.AppearancePrint.Preview.ForeColor = System.Drawing.Color.Black
        Me.gv.AppearancePrint.Preview.Options.UseForeColor = True
        Me.gv.DetailHeight = 431
        Me.gv.GridControl = Me.GRD
        Me.gv.Name = "gv"
        Me.gv.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsBehavior.Editable = False
        Me.gv.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm
        Me.gv.OptionsBehavior.SummariesIgnoreNullValues = True
        Me.gv.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.[True]
        Me.gv.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted
        Me.gv.OptionsFind.AlwaysVisible = True
        Me.gv.OptionsMenu.ShowConditionalFormattingItem = True
        Me.gv.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.gv.OptionsPrint.AllowMultilineHeaders = True
        Me.gv.OptionsPrint.EnableAppearanceEvenRow = True
        Me.gv.OptionsPrint.EnableAppearanceOddRow = True
        Me.gv.OptionsSelection.MultiSelect = True
        Me.gv.OptionsView.ColumnAutoWidth = False
        Me.gv.OptionsView.EnableAppearanceEvenRow = True
        Me.gv.OptionsView.EnableAppearanceOddRow = True
        Me.gv.OptionsView.ShowAutoFilterRow = True
        Me.gv.OptionsView.ShowFooter = True
        Me.gv.OptionsView.ShowGroupedColumns = True
        '
        'frmTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 654)
        Me.Controls.Add(Me.GRD)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Name = "frmTests"
        Me.Text = "frmTests"
        CType(Me.GRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GRD As DevExpress.XtraGrid.GridControl
    Friend WithEvents gv As DevExpress.XtraGrid.Views.Grid.GridView
End Class
