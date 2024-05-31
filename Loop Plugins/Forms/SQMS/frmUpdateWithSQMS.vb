Imports DevExpress.XtraSplashScreen

Public Class frmUpdateWithSQMS
    Const SHEETNAME = "Tasks"
    Private sheet As New DevExpressUserSpreadSheet
    Private sqms As New SQMSTransaction
    Private opnedHandle As IOverlaySplashScreenHandle

    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub prepareSheets()
        sheet.renameActiveSheet(SS, SHEETNAME)
    End Sub

    Private Sub frmUpdateWithSQMS_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim frm As New frmSQMSSyncSettings
        frm.ShowDialog(Me)
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            Dim done As String = ""
            If MsgBox("Do you want to update EICA With SQMS Tasks?", MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
            ShowProgressPanel()
            Application.DoEvents()
            prepareSheets()
            Dim dt As New DataTable
            dt = sheet.convertActiveSheetToDatatable(SS, SHEETNAME)
            If IsNothing(dt) Then
                MsgBox("Nothing to update!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If dt.Rows.Count = 0 Then
                MsgBox("Nothing to update!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If sqms.UploadTasksToEICA(dt) Then

                sqms.CleanningTempTables()

                'Update EICA Solo Run Scope
                If sqms.UpdateEICAMotorsWithHCS Then
                Else
                    done = "EICA Solo Run Scope Did NOT Updated"
                End If
                '------------------------

                'Update EICA Loop Scope
                If sqms.UpdateEICALoopsWithHCS Then
                Else
                    done &= "EICA Loop Scope Did NOT Updated"
                End If
                '------------------------

                'Update EICA Boxup Scope
                If sqms.UpdateEICABoxupWithHCS Then
                Else
                    done = "EICA Boxup Scope Did NOT Updated"
                End If
                '------------------------

                'Update LOOP QC Released to EICA
                If sqms.UpdateLoopQCReleasedFromSQMS Then
                Else
                    done &= "SQMS For Loops QC Released Did NOT Updated"
                End If
                '------------------------

                'Update LOOP Approved
                If sqms.UpdateLoopQSMSApproved Then
                Else
                    done &= "SQMS For Loops Approved Did NOT Updated"
                End If
                '------------------------

                'Update Solo Run Approved
                If sqms.UpdateSoloRunQSMSApproved Then
                Else
                    done &= "SQMS For Solo Run Approved Did NOT Updated"
                End If
                '------------------------

                'Update Solo Run QC Released to EICA
                If sqms.UpdateSoloRunQCReleasedFromSQMS Then
                Else
                    done &= vbCrLf & "SQMS For Solo Run QC Released Did NOT Updated"
                End If
                '------------------------

                'Update Box Up QC Released to EICA
                If sqms.UpdateBoxupQCReleasedFromSQMS Then
                Else
                    done &= "SQMS For Box Up QC Released Did NOT Updated"
                End If
                '------------------------

                'Update Box Up Approved
                If sqms.UpdateBoxupQSMSApproved Then
                Else
                    done &= "SQMS For Boxup Approved Did NOT Updated"
                End If
                '------------------------

                'Cash Loop SQMS Tasks
                If sqms.CashLoopSQMSTasks Then
                Else
                    done &= vbCrLf & "Loops Cashed Tasks Did NOT Updated"
                End If
                '------------------------

                'Cash Solo Run SQMS Tasks
                If sqms.CashSoloRunSQMSTasks Then
                Else
                    done &= vbCrLf & "Solo Run Cashed Tasks Did NOT Updated"
                End If
                '------------------------

                'Cash Box up SQMS Tasks
                If sqms.CashBoxupSQMSTasks Then
                Else
                    done &= vbCrLf & "Box Up Cashed Tasks Did NOT Updated"
                End If
                '------------------------

                'Update Subsystem
                If sqms.UPDATEICASubsystemWITHSQMS Then
                Else
                    done &= vbCrLf & "Subsystem Not Updated"
                End If
                '------------------------


                CloseProgressPanel(opnedHandle)

                If done = "" Then
                    MsgBox("EICA Updated With SQMS Tasks", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox(done, MsgBoxStyle.Critical, Me.Text)
                End If

            End If

        Catch ex As Exception
            CloseProgressPanel(opnedHandle)
        End Try
        CloseProgressPanel(opnedHandle)
    End Sub

End Class