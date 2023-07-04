Public Class frmSetQCReleased
    Public isSelected As Boolean = False
    Public selectedDate As Date
    Public selectedRFI As String = ""
    Public isCleared As Boolean = False
    Private cutDate As New CutoffDate
    Private withConstraint As Boolean = True


    Public Sub New(Optional ByVal HasCutoffConstraint = True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        withConstraint = HasCutoffConstraint
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        isSelected = False
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If withConstraint Then
            selectedDate = dte.Value
            Dim ctDate As Date = cutDate.CurrentCutoffDate
            Dim firstdate As New Date(selectedDate.Year, selectedDate.Month, selectedDate.Day, 0, 0, 0)
            Dim seconddate As New Date(ctDate.Year, ctDate.Month, ctDate.Day, 0, 0, 0)

            If DateDiff(DateInterval.Day, DateAdd(DateInterval.Day, -6, seconddate), firstdate) < 0 Then
                MsgBox("Please Select Date Within the Current Week!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If DateDiff(DateInterval.Day, firstdate, seconddate) < 0 Then
                MsgBox("Please Select Date Within the Current Week!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
        End If
        selectedDate = dte.Value
        selectedRFI = txtRFI.Text
        isSelected = True
        Me.Close()
    End Sub

    Private Sub frmSelectDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.Refresh()
        Me.Refresh()
        Me.WindowState = FormWindowState.Normal
        lblCuttoffDate.Text = "Current Cutoff Date: " & Format(cutDate.CurrentCutoffDate, "dddd, dd-MMMM-yyyy")
        If withConstraint Then
            lblInfo1.Visible = True
        Else
            lblInfo1.Visible = False
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        isSelected = True
        isCleared = True
        Me.Close()
    End Sub
    Private Sub frmSetQCReleased_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub dte_ValueChanged(sender As Object, e As EventArgs) Handles dte.ValueChanged

    End Sub
End Class