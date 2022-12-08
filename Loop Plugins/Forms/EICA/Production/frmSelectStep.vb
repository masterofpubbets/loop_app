Public Class frmSelectStep
    Public colSteps As New Collection
    Private _ItemType As en_item_type

    Public Enum en_item_type
        EleCable = 1
        InsCable = 2
        EleEq = 3
        InsEq = 4
        EleJB = 5
        InsJB = 6
        Instrument = 7
    End Enum

    Public Sub New(ByVal ItemType As en_item_type)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _ItemType = ItemType
        Select Case ItemType
            Case en_item_type.EleCable
                gpEleCable.Visible = True
            Case en_item_type.EleEq
                gpEleEq.Visible = True
            Case en_item_type.EleJB
                gbEleJB.Visible = True
            Case en_item_type.InsCable
                gbInsCable.Visible = True
            Case en_item_type.InsEq
                gbInsEq.Visible = True
            Case en_item_type.InsJB
                gbInsJB.Visible = True
            Case en_item_type.Instrument
                gbIns.Visible = True
        End Select
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        colSteps.Clear()
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        colSteps.Clear()
        Select Case _ItemType
            Case en_item_type.EleCable
                If Not CheckEleCable() Then
                    MsgBox("You have to select at least 1 step for electrical cable to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
            Case en_item_type.EleEq
                If Not CheckEleEq() Then
                    MsgBox("You have to select at least 1 step for electrical equipment to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
            Case en_item_type.EleJB
                If Not CheckEleJB() Then
                    MsgBox("You have to select at least 1 step for electrical jb to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
            Case en_item_type.InsCable
                If Not CheckInsCable() Then
                    MsgBox("You have to select at least 1 step for instrument cable to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
            Case en_item_type.InsEq
                If Not CheckInsEq() Then
                    MsgBox("You have to select at least 1 step for instrument equipment to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
            Case en_item_type.InsJB
                If Not CheckInsJB() Then
                    MsgBox("You have to select at least 1 step for instrument jb to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
            Case en_item_type.Instrument
                If Not CheckIns() Then
                    MsgBox("You have to select at least 1 step for instrument to update", MsgBoxStyle.Exclamation, "Item Production")
                    Exit Sub
                End If
        End Select
        Me.Close()
    End Sub

    Private Function CheckEleCable() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gpEleCable.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function
    Private Function CheckEleEq() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gpEleEq.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function
    Private Function CheckEleJB() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gbEleJB.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function
    Private Function CheckInsCable() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gbInsCable.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function
    Private Function CheckInsJB() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gbInsJB.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function
    Private Function CheckInsEq() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gbInsEq.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function
    Private Function CheckIns() As Boolean
        Dim ck As Boolean = False
        For Each c As CheckBox In gbIns.Controls
            If c.Checked = True Then
                colSteps.Add(c.Text)
                ck = True
            End If
        Next
        Return ck
    End Function

End Class