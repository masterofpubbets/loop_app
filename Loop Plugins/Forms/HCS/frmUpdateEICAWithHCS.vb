Public Class frmUpdateEICAWithHCS
    Private hcs As New HCSTransactions

    Private Sub InitiateProcedure()
        For Each con As Control In Me.Controls
            If TypeOf con Is PictureBox Then
                con.Visible = False
            End If
            If TypeOf con Is DevExpress.XtraEditors.MarqueeProgressBarControl Then
                con.Visible = False
            End If
        Next
    End Sub
    Private Sub frmUpdateEICAWithHCS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmUpdateEICAWithHCS_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        InitiateProcedure()
        Try
            If ckElements.Checked Then
                pBarElements.Visible = True
                Application.DoEvents()
                If hcs.DownloadHCSElements Then
                    picElements.Visible = True
                    pBarElements.Visible = False
                End If
            End If

            If ckITRs.Checked Then
                pbarITRs.Visible = True
                Application.DoEvents()
                If hcs.DownloadHCSITRs Then
                    picITRs.Visible = True
                    pbarITRs.Visible = False
                End If
            End If

            If ckGroups.Checked Then
                pbarGroups.Visible = True
                Application.DoEvents()
                If hcs.DownloadHCSGroups Then
                    picGroups.Visible = True
                    pbarGroups.Visible = False
                End If
            End If

            If ckLoopApproved.Checked Then
                pbarLoopApproved.Visible = True
                Application.DoEvents()
                If hcs.DownloadLoopApproved Then
                    If hcs.DownloadSoloRunApproved Then
                        picLoopApproved.Visible = True
                        pbarLoopApproved.Visible = False
                    End If
                End If
            End If

            If ckLoopsData.Checked Then
                pbarLoopsData.Visible = True
                Application.DoEvents()
                If hcs.UpdateEICALoopsWithHCS Then
                    picLoopsData.Visible = True
                    pbarLoopsData.Visible = False
                End If
            End If

            If ckMotorsData.Checked Then
                pbarMotorsData.Visible = True
                Application.DoEvents()
                If hcs.UpdateEICAMotorsWithHCS Then
                    picMotorsData.Visible = True
                    pbarMotorsData.Visible = False
                End If
            End If

            If ckSubsystem.Checked Then
                pbarSubsystem.Visible = True
                Application.DoEvents()
                If hcs.UpdateEICAItemsSubsystemFromHCS Then
                    picSubsystem.Visible = True
                    pbarSubsystem.Visible = False
                End If
            End If

            If ckFinalClean.Checked Then
                pbarFinalClean.Visible = True
                Application.DoEvents()
                If hcs.ApplyFinalClean Then
                    picFinalClean.Visible = True
                    pbarFinalClean.Visible = False
                End If
            End If


            If hcs.UpdateLoopQCReleasedFromHCS Then
            End If

            If hcs.UpdateMotorsQCReleasedFromHCS Then
            End If

            MsgBox("Update with HCS has finished.", MsgBoxStyle.Information, Me.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim frm As New frmHCSConnectionSettings
        frm.ShowDialog(Me)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        ckElements.Checked = True
        ckITRs.Checked = True
        ckGroups.Checked = True
        ckLoopApproved.Checked = True
        ckSubsystem.Checked = True
        ckItemClosed.Checked = True
        ckLoopsData.Checked = True
        ckMotorsData.Checked = True
        ckFinalClean.Checked = True
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        ckElements.Checked = False
        ckITRs.Checked = False
        ckGroups.Checked = False
        ckLoopApproved.Checked = False
        ckSubsystem.Checked = False
        ckItemClosed.Checked = False
        ckLoopsData.Checked = False
        ckMotorsData.Checked = False
        ckFinalClean.Checked = False
    End Sub
End Class