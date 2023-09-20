Public Class frmAddResource
    Private res As New ResourcesMan
    Public IsAdded As Boolean = False
    Private _resId As Integer = 0
    Private resourceUpdated As Boolean = False

    Public Sub New(Optional ByVal ResId As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _resId = ResId
    End Sub
    Public Function IsValidate() As Boolean
        txtName.Text = Trim(txtName.Text)
        txtRemark.Text = Trim(txtRemark.Text)
        If txtName.Text = "" Then
            MsgBox("Please type resource's name!", MsgBoxStyle.Exclamation, Me.Text)
            txtName.Focus()
            Return False
        End If

        If _resId = 0 Then
            If res.IsResourceExists(txtName.Text) Then
                MsgBox("Please choose another resource's name because current name exists!", MsgBoxStyle.Exclamation, Me.Text)
                txtName.Focus()
                Return False
            End If
        Else
            If res.IsResourceExists(txtName.Text, _resId) Then
                MsgBox("Please choose another resource's name because current name exists!", MsgBoxStyle.Exclamation, Me.Text)
                txtName.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub FluentDesignFormContainer1_Resize(sender As Object, e As EventArgs) Handles FluentDesignFormContainer1.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            opnFle.FileName = ""
            opnFle.ShowDialog()
            If opnFle.FileName = "" Then Exit Sub
            lblFile.Text = opnFle.FileName
            resourceUpdated = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If IsValidate() Then
            Dim filePath As String = ""
            If lblFile.Text <> "---" Then filePath = lblFile.Text
            If _resId <> 0 Then
                If res.EditResource(filePath, txtName.Text, txtRemark.Text, _resId, resourceUpdated) Then
                    MsgBox("Resource has been updated.", MsgBoxStyle.Information, Me.Text)
                    IsAdded = True
                    Me.Close()
                End If
            Else
                If res.AddResource(filePath, txtName.Text, txtRemark.Text) Then
                    MsgBox("Resource has been added.", MsgBoxStyle.Information, Me.Text)
                    IsAdded = True
                    Me.Close()
                End If
            End If

        End If
    End Sub

    Private Sub FluentDesignFormContainer1_Click(sender As Object, e As EventArgs) Handles FluentDesignFormContainer1.Click

    End Sub
End Class