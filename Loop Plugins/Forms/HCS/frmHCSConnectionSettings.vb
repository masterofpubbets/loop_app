Public Class frmHCSConnectionSettings
    Private hcs As New HCSTransactions

    Private Sub GetData()
        txtDBLocation.Text = hcs.HCSDBBLocation
        txtDBName.Text = hcs.HCSDBBName
        txtElementsQuery.Text = hcs.HCSElementQuery
        txtTasksQuery.Text = hcs.HCSTasksQuery
        txtLoopApprovedQuery.Text = hcs.HCSLoopApprovedQuery
        txtCLosedItemsQuery.Text = hcs.HCSClosedItemsQuery
        txtGroupsQuery.Text = hcs.HCSGroupsQuery
        txtUpdateSubsystemQuery.Text = hcs.HCSUpdateSubsystemQuery
    End Sub
    Private Function IsValide() As Boolean
        If Trim(txtDBLocation.Text) = "" Then
            MsgBox("HCS DB Location cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtDBLocation.Focus()
            Return False
        End If
        If Trim(txtDBName.Text) = "" Then
            MsgBox("HCS DB Name cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtDBName.Focus()
            Return False
        End If
        If Trim(txtElementsQuery.Text) = "" Then
            MsgBox("Elements Query cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtElementsQuery.Focus()
            Return False
        End If
        If Trim(txtTasksQuery.Text) = "" Then
            MsgBox("Tasks Query cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtTasksQuery.Focus()
            Return False
        End If
        If Trim(txtGroupsQuery.Text) = "" Then
            MsgBox("Groups Query cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtGroupsQuery.Focus()
            Return False
        End If
        If Trim(txtLoopApprovedQuery.Text) = "" Then
            MsgBox("Loop Approved Query cannot be null!", MsgBoxStyle.Exclamation, Me.Text)
            txtLoopApprovedQuery.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub frmHCSConnectionSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmHCSConnectionSettings_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If MsgBox("Do you want to update HCS Connection settings?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
        If IsValide() Then
            hcs.HCSDBBLocation = txtDBLocation.Text
            hcs.HCSDBBName = txtDBName.Text
            hcs.HCSElementQuery = txtElementsQuery.Text
            hcs.HCSTasksQuery = txtTasksQuery.Text
            hcs.HCSLoopApprovedQuery = txtLoopApprovedQuery.Text
            hcs.HCSClosedItemsQuery = txtCLosedItemsQuery.Text
            hcs.HCSGroupsQuery = txtGroupsQuery.Text
            hcs.HCSUpdateSubsystemQuery = txtUpdateSubsystemQuery.Text
            MsgBox("Settings Saved.", MsgBoxStyle.Information, Me.Text)
        End If
    End Sub
End Class