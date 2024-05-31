Public Class frmNotificationsMaping
    Public Property MapName As String
    Public Property MapFilter As String

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmNotificationsMaping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmNotificationsMaping_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub OpenMapping()
        Try
            Select Case MapName
                Case "Loop Folder"
                    Dim frmLoop As New frmLoopFolders
                    frmLoop._filter = Me.MapFilter
                    frmLoop._filterColumn = "Loop Name"
                    frmLoop.Show()
                Case "Cable"
                    Dim frmCable As New frmCables(True)
                    frmCable._filter = Me.MapFilter
                    frmCable._filterColumn = "Tag"
                    frmCable.Show()
                Case "Solo Run"
                    Dim frmSolorun As New frmBoxupFolders
                    frmSolorun._filter = Me.MapFilter
                    frmSolorun._filterColumn = "Folder Name"
                    frmSolorun.Show()
                Case "Equipment"
                    Dim frmEq As New frmEquipment
                    frmEq._filter = Me.MapFilter
                    frmEq._filterColumn = "Tag"
                    frmEq.Show()
            End Select
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        OpenMapping()
    End Sub
End Class