Public Class frmSelectDateConstraint
    Public isSelected As Boolean = False
    Public selectedDate As Date
    Public isCleared As Boolean = False
    Private cutDate As New CutoffDate
    Private withConstraint As Boolean = True


    Public Sub New(Optional ByVal HasCutoffConstraint = True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        withCOnstraint = HasCutoffConstraint
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        isSelected = False
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If withCOnstraint Then
            Dim ctDate As Date = cutDate.CurrentCutoffDate
            selectedDate = dte.Value
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
            isSelected = True
        Else
            selectedDate = dte.Value
            isSelected = True
        End If
        Me.Close()
    End Sub

    Private Sub frmSelectDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmMain.Refresh()
        Me.Refresh()
        Me.WindowState = FormWindowState.Normal
        lblCuttoffDate.Text = "Current Cutoff Date: " & Format(cutDate.CurrentCutoffDate, "dddd, dd-MMMM-yyyy")
        If withCOnstraint Then
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

    Private Sub frmSelectDateConstraint_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If MsgBox("Do you want to select today date: " & Format(Now, "dddd dd-MMMM-yyyy"), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        selectedDate = Now
        isSelected = True
        Me.Close()
    End Sub
End Class