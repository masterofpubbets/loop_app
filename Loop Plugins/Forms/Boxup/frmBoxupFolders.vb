Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class frmBoxupFolders
    Private fd As New BoxupSteps
    Public _filter As String = ""
    Public _filterColumn As String = ""
    Private colWidth As Collection
    Private focusedRowHandler As Integer = -1
    Private grdView As New GridViews
    Private fs As New FileSystem

    Private StandardRulesAdded As Boolean = False
    Private opnedHandle As IOverlaySplashScreenHandle
    Private lf As New Boxups
    Private WithEvents cloud As UpdateCloud
    Private pe As New PublicErrors
    Private appSet As New AppSettings

    Private Sub ShowRadialMenu()
        ' Display Radial Menu
        If rMenu Is Nothing Then
            Return
        End If
        Dim pt As Point = Me.Location
        pt.Offset(Me.Width \ 2, Me.Height \ 2)
        rMenu.ShowPopup(pt)
    End Sub
    Private Sub CloudUpdatedEvent() Handles cloud.CloudUpdated
        lblInfo.Caption = "Cloud Updated and Mail has been Send."
        cloud.Cancel()
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        opnedHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return opnedHandle
    End Function

    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub

    Private Sub GetHCSTasks()
        Try
            Dim gNames As New List(Of String)
            For Each row_handle As Integer In gv.GetSelectedRows
                gNames.Add(gv.GetDataRow(row_handle).Item("Folder Name"))
            Next
            If gNames.Count > 0 Then
                Dim frm As New frmDataResult("", frmDataResult.en_ResultType.ItemTasks, lf.HCSTasks(gNames))
                frm.Show()
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub GetHCSPendingTasks()
        Try
            Dim gNames As New List(Of String)
            For Each row_handle As Integer In gv.GetSelectedRows
                gNames.Add(gv.GetDataRow(row_handle).Item("Folder Name"))
            Next
            If gNames.Count > 0 Then
                Dim frm As New frmDataResult("", frmDataResult.en_ResultType.ItemTasks, lf.HCSPendingTasks(gNames))
                frm.Show()
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateConstructionComplete()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Construction Complete?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then

                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("ConstrRelease", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                       gv.GetDataRow(row_handle).Item("Folder Name"),
                       gv.GetDataRow(row_handle).Item("Area"),
                       IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                       frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 frm.selectedDate,    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001"    'Return From QC
                                ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERCONSRELEASE
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERCONSRELEASE

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopPrinted()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Folder Printed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then

                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("FolderPreparation", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                       gv.GetDataRow(row_handle).Item("Folder Name"),
                       gv.GetDataRow(row_handle).Item("Area"),
                       IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                       frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 frm.selectedDate,    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001"    'Return From QC
                                ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPPRINTED
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPPRINTED

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopQCReleased()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as QC Released?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("QCRelease", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 frm.selectedDate,    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001"    'Return From QC
                                ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPQCRELEASED
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPQCRELEASED

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopFolderReady()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Folder Ready?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("FolderReady", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 frm.selectedDate,    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001"    'Return From QC
                            ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERREADY
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERREADY

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopSubmittedToPrecomm()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Submitted to Precomm?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("SubmittedToPrecom", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 frm.selectedDate,    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001"    'Return From QC
                            ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERSUBMITTEDTPPRECOMM
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERSUBMITTEDTPPRECOMM

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopDone()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Folder Done?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("Done", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 frm.selectedDate, 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001"    'Return From QC
                                ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERDONE
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERDONE

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopApproved()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Folder Approved?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("FinalApproval", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 frm.selectedDate, 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 ""
                    ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERAPPROVED
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERAPPROVED

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopSubmitToQC()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Submit to QC?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("SubmitToQC", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 frm.selectedDate, 'Submit to QC
                                 ""
                    ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDESUBMITTOQC
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDESUBMITTOQC

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateLoopReturnFromQC()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Return from QC to Support Team?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDateConstraint
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.isSelected Then
                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("ReturnFromQC", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                        gv.GetDataRow(row_handle).Item("Folder Name"),
                        gv.GetDataRow(row_handle).Item("Area"),
                        IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                        frm.selectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "1/1/0001", 'Submit to QC
                                 frm.selectedDate 'Return from QC
                    ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERRETURNFROMQC
                If frm.isCleared Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERRETURNFROMQC

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateConstructionTargetDate()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Construction Target Date?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDate
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.IsSelect Then

                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("ConsTargetDate", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                       gv.GetDataRow(row_handle).Item("Folder Name"),
                       gv.GetDataRow(row_handle).Item("Area"),
                       IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                       frm.SelectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001",    'Return From QC
                                 "",
                                 0,
                                 "",
                                 "",
                                 frm.SelectedDate,    'Cons Target Date
                                 "1/1/0001"    'Failed Date
                                ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERCONSTARGET
                If frm.IsClear Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERCONSTARGET

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub UpdateFailedtDate()
        Try

            If MsgBox(String.Format("Do You Want To Set All {0}{1} Selected as Failed?", vbCrLf, gv.GetSelectedRows.Count), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim frm As New frmSelectDate
            Dim solo As New Boxups
            frm.ShowDialog(Me)
            If frm.IsSelect Then

                Dim dt As New DataTable
                dt.TableName = "FolderData"
                dt.Columns.Add("Tag", Type.GetType("System.String"))
                dt.Columns.Add("Area", Type.GetType("System.String"))
                dt.Columns.Add("Description", Type.GetType("System.String"))
                dt.Columns.Add("FailedDate", Type.GetType("System.DateTime"))

                For Each row_handle As Integer In gv.GetSelectedRows
                    dt.Rows.Add(
                       gv.GetDataRow(row_handle).Item("Folder Name"),
                       gv.GetDataRow(row_handle).Item("Area"),
                       IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Description")), "", gv.GetDataRow(row_handle).Item("Description")),
                       frm.SelectedDate
                    )
                    solo.Add(New Solorun(
                                 gv.GetDataRow(row_handle).Item("Folder Name"),
                                 "1/1/0001",
                                 "1/1/0001",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'FolderPrinted
                                 "1/1/0001",    'Cons Complete
                                 "1/1/0001",    'QC Released
                                 "1/1/0001",    'Folder Ready
                                 "1/1/0001",    'Submit to precomm
                                 "1/1/0001", 'done
                                 "1/1/0001", 'Final approved
                                 IIf(IsDBNull(gv.GetDataRow(row_handle).Item("Area")), "", gv.GetDataRow(row_handle).Item("Area")),
                                 "",
                                 "",
                                 "",
                                 "1/1/0001",    'Submit to QC,
                                 "1/1/0001",    'Return From QC
                                 "",
                                 0,
                                 "",
                                 "",
                                 "1/1/0001",    'Cons Target Date
                                 frm.SelectedDate    'Failed Date
                                ))
                Next

                Dim updateType As Enumerations.UpdateType = Enumerations.UpdateType.UPDATELOOPFOLDERFAILED
                If frm.IsClear Then updateType = Enumerations.UpdateType.CLEARLOOPFOLDERFAILED

                Dim opKey As String = lf.UploadTempProgress(updateType, dt)
                If opKey <> "" Then
                    Dim dtResult As New DataTable
                    If lf.UpdateData(opKey, dtResult) Then
                        Dim frm2 As New frmDataResult(opKey, frmDataResult.en_ResultType.LoopFolders, dtResult)
                        frm2.ShowDialog(Me)
                        lf.DeleteTempData(opKey)
                    End If
                    If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
                    getData()
                Else
                    MsgBox("Something is wrong. Nothing to update.", MsgBoxStyle.Exclamation, Me.Text)
                End If
            End If

        Catch ex As Exception
            pe.RaiseUnknownError(ex.Message)
        End Try
    End Sub
    Private Sub CheckAuth()
        rpHandover.Visible = False
        rpQC.Visible = False
        rpPrecom.Visible = False
        rpSupportTeam.Visible = False
        rpConstruction.Visible = False
        rMenuSetFolderApproved.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderPrinted.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderReady.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderReleased.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderDone.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderReturnFromQC.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderSubmitToPrecomm.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderSubmitToSupportTeam.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderSubmitToQC.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderConsComplete.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderConsTargetDate.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        rMenuSetFolderFailed.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing

        If InStr(Users.userType, "admin", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
            rpQC.Visible = True
            rpPrecom.Visible = True
            rpBlockage.Visible = True
            rpConstruction.Visible = True
            rMenuSetFolderApproved.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderPrinted.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderReady.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderReleased.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderDone.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderReturnFromQC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToPrecomm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToSupportTeam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToQC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderConsComplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderConsTargetDate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderFailed.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If InStr(Users.userType, "handover", CompareMethod.Text) > 0 Then
            rpHandover.Visible = True
            rpBlockage.Visible = True
            rMenuSetFolderApproved.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If InStr(Users.userType, "qc", CompareMethod.Text) > 0 Then
            rpQC.Visible = True
            rpBlockage.Visible = True
            rMenuSetFolderReady.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderReleased.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToSupportTeam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToQC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If InStr(Users.userType, "precomm", CompareMethod.Text) > 0 Then
            rpPrecom.Visible = True
            rpBlockage.Visible = True
            rMenuSetFolderDone.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToPrecomm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderFailed.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If InStr(Users.userType, "support team", CompareMethod.Text) > 0 Then
            rpSupportTeam.Visible = True
            rpBlockage.Visible = True
            rMenuSetFolderPrinted.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderReturnFromQC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToPrecomm.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToSupportTeam.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderSubmitToQC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If InStr(Users.userType, "construction", CompareMethod.Text) > 0 Then
            rpConstruction.Visible = True
            rpBlockage.Visible = True
            rMenuSetFolderConsComplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            rMenuSetFolderConsTargetDate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
    End Sub
    Private Sub formatColumnsWidth()
        Try
            If IsNothing(colWidth) Then
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = 100
                Next
            Else
                gv.FocusedRowHandle = focusedRowHandler
                For inx As Integer = 1 To gv.Columns.Count
                    gv.Columns.Item(inx - 1).Width = colWidth.Item(inx)
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub saveColumnsWidth()
        Try
            If gv.RowCount <> 0 Then
                focusedRowHandler = gv.FocusedRowHandle

                If IsNothing(colWidth) Then
                    colWidth = New Collection
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                Else
                    colWidth.Clear()
                    For inx As Integer = 0 To gv.Columns.Count - 1
                        colWidth.Add(gv.Columns.Item(inx).Width)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ConditionalFormat()
        If Not StandardRulesAdded Then
            'Done Rule
            Dim gridFormatRule As New GridFormatRule()
            Dim formatConditionRuleExpression As New FormatConditionRuleExpression()
            gridFormatRule.ApplyToRow = True
            formatConditionRuleExpression.PredefinedName = "Green Fill"
            formatConditionRuleExpression.Expression = "[Done] IS NOT NULL"
            gridFormatRule.Rule = formatConditionRuleExpression
            gv.FormatRules.Add(gridFormatRule)

            'Blockage Rule
            Dim gridFormatRule2 As New GridFormatRule()
            Dim formatConditionRuleExpression2 As New FormatConditionRuleExpression()
            gridFormatRule2.ApplyToRow = True
            formatConditionRuleExpression2.PredefinedName = "Red Fill"
            formatConditionRuleExpression2.Expression = "[Has Blockage] = 'Yes'"
            gridFormatRule2.Rule = formatConditionRuleExpression2
            gv.FormatRules.Add(gridFormatRule2)
            StandardRulesAdded = True
        End If
    End Sub
    Private Sub getData()
        saveColumnsWidth()
        grd.DataSource = fd.getSteps
        formatColumnsWidth()

        If gv.Columns.Count = 0 Then Exit Sub


        gv.Columns("QC Released").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)
        gv.Columns("Folder Ready QC").AppearanceCell.BackColor = Color.FromArgb(194, 241, 194)

        gv.Columns("Done").AppearanceCell.BackColor = Color.FromArgb(87, 204, 153)
        gv.Columns("Done").AppearanceCell.ForeColor = Color.White
        gv.Columns("Final Approval").AppearanceCell.BackColor = Color.FromArgb(87, 204, 153)
        gv.Columns("Final Approval").AppearanceCell.ForeColor = Color.White

        gv.Columns("Submitted To QC").AppearanceCell.BackColor = Color.FromArgb(56, 163, 165)
        gv.Columns("Submitted To QC").AppearanceCell.ForeColor = Color.White

        gv.Columns("Return From QC").AppearanceCell.BackColor = Color.FromArgb(56, 163, 165)
        gv.Columns("Return From QC").AppearanceCell.ForeColor = Color.White

        gv.Columns("Submitted To Precomm").AppearanceCell.BackColor = Color.FromArgb(56, 163, 165)
        gv.Columns("Submitted To Precomm").AppearanceCell.ForeColor = Color.White

        gv.Columns("Folder Printed").AppearanceCell.BackColor = Color.FromArgb(56, 163, 165)
        gv.Columns("Folder Printed").AppearanceCell.ForeColor = Color.White

        gv.Columns("Cons Complete").AppearanceCell.BackColor = Color.FromArgb(199, 249, 204)
        gv.Columns("Failed Date").AppearanceCell.BackColor = Color.FromArgb(255, 229, 236)
        gv.Columns("Construction Target Date").AppearanceCell.BackColor = Color.FromArgb(0, 150, 199)
        gv.Columns("Construction Target Date").AppearanceCell.ForeColor = Color.AntiqueWhite

        gv.Columns("ProUUID").Visible = False
        gv.Columns("Id").Visible = False
        gv.Columns("Project").Visible = False

        gv.OptionsSelection.MultiSelect = True

        ConditionalFormat()

        Try
            If _filter <> "" Then
                gv.Columns(_filterColumn).FilterInfo = New ColumnFilterInfo(_filter)
            End If
        Catch ex As Exception

        End Try

        gv.BestFitColumns(True)

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuFilter.ItemClick
        Dim frm As New frmFilter
        frm.Text = "Folders Filter"
        For inx As Integer = 0 To gv.Columns.Count - 1
            frm.cmbSearchIn.Items.Add(gv.Columns.Item(inx).FieldName)
        Next
        frm.ShowDialog(Me)
        If Not frm.isCancel Then
            Dim bc As String = ""
            If Not frm.Exact Then bc = "%"
            Dim _filter As String = ""
            For inx As Integer = 1 To frm.searchValues.Count
                If inx <> 1 Then
                    _filter &= String.Format("OR [{0}] LIKE '{2}{1}{2}'", frm.searchField, frm.searchValues.Item(inx), bc)
                Else
                    _filter = String.Format("[{0}] LIKE '{2}{1}{2}'", frm.searchField, frm.searchValues.Item(inx), bc)
                End If
            Next
            gv.Columns(frm.searchField).FilterInfo = New ColumnFilterInfo(_filter)
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuRefresh.ItemClick
        ShowProgressPanel()
        getData()
        CloseProgressPanel(opnedHandle)
    End Sub

    Private Sub frmHCSSetSteps_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckAuth()
        getData()
        Try
            If _filter <> "" Then
                If IO.File.Exists(GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, "")) Then
                    grdView.ApplyViewLayout(gv, GetSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, ""))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderPrinted.ItemClick
        UpdateLoopPrinted()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderApproved.ItemClick
        UpdateLoopApproved()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuExportToExcel.ItemClick
        Try
            sveFle.FileName = ""
            sveFle.Filter = "XLSX Files|*.xlsx"
            sveFle.ShowDialog()
            If sveFle.FileName = "" Then Exit Sub
            grd.ExportToXlsx(sveFle.FileName)
            Process.Start(sveFle.FileName)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderReleased.ItemClick
        UpdateLoopQCReleased()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderReady.ItemClick
        UpdateLoopFolderReady()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderSubmitToSupportTeam.ItemClick, rMenuSetFolderSubmitToPrecomm.ItemClick
        UpdateLoopSubmittedToPrecomm()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderDone.ItemClick
        UpdateLoopDone()
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuAddBlockage.ItemClick
        Dim frm As New frmAddConsEntry
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim desc As String = ""
            For Each row_handle As Integer In gv.GetSelectedRows
                If IsDBNull(gv.GetDataRow(row_handle).Item("Description")) Then
                    desc = ""
                Else
                    desc = gv.GetDataRow(row_handle).Item("Description")
                End If
                ''add blockage here
                If fd.addBlockage(frm.catName, gv.GetDataRow(row_handle).Item("Id"), gv.GetDataRow(row_handle).Item("Folder Name"), desc, gv.GetDataRow(row_handle).Item("Area"), frm.description, Users.userFullName, Users.mail, Users.id, frm.selectedUserName, frm.selectedUserMail, frm.selectedUserId, gv.GetDataRow(row_handle).Item("Folder Status")) Then
                End If

            Next
            If MsgBox(String.Format("Folders Have Been Updated {0} Do You Want To Refresh ?", vbCrLf), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.No Then Exit Sub
            getData()
        End If
    End Sub

    Private Sub gv_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles gv.RowCellStyle
        If e.Column.FieldName = "Has Blockage" Then
            If e.CellValue = "Yes" Then
                e.Appearance.BackColor = Color.LightPink
            End If
        End If
    End Sub

    Private Sub gv_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles gv.CustomDrawCell
        If e.Column.FieldName = "FolderPriority" Then
            If Not IsDBNull(e.CellValue) Then
                If e.CellValue < 20 Then
                    e.Cache.FillEllipse(Convert.ToSingle(e.Bounds.X + e.Bounds.Height / 2), e.Bounds.Y + 3, e.Bounds.Height - 5, e.Bounds.Height - 5, Color.Red)
                    'e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                    e.Appearance.DrawString(e.Cache, e.DisplayText, e.Bounds)
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        For Each row_handle As Integer In gv.GetSelectedRows
            Dim frm As New frmQRCodeViewer
            frm.lbl.Text = "Folder: " & gv.GetDataRow(row_handle).Item("Folder Name")
            'frm.pic.Image = lpAPI.GenerateQRCode(gv.GetDataRow(row_handle).Item("Folder Name"))
            frm.Show()
        Next
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuShowBlockage.ItemClick
        Dim inx As Integer = 0
        Dim filter As String = ""
        For Each row_handle As Integer In gv.GetSelectedRows
            If inx = 0 Then
                filter = "[Folder Name] LIKE '" & gv.GetDataRow(row_handle).Item("Folder Name") & "'"
            Else
                filter &= " OR [Folder Name] LIKE '" & gv.GetDataRow(row_handle).Item("Folder Name") & "'"
            End If
            inx += 1
        Next
        Dim frm As New frmSoloRunConstraints With {
            ._filterColumn = "Folder Name",
        ._filter = filter
        }
        frm.Show()
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Me.MdiParent = Nothing
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuOpenILD.ItemClick
        Try
            Dim pdfs As List(Of String)
            Dim pdfsFName As New List(Of String)

            Dim row_handle As Integer = gv.GetSelectedRows(0)
            If row_handle < 0 Then Exit Sub
            pdfs = fs.FindFile(gv.GetDataRow(row_handle).Item("Folder Name") & "*", SharedFolder, pdfsFName)
            If IsNothing(pdfs) Then
                MsgBox("No PDF associated to this Folder!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If pdfs.Count = 0 Then
                MsgBox("No PDF associated to this Folder!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            If IO.File.Exists(pdfs.Item(0)) Then
                Dim frm As New frmPdf() With {.PDFPath = pdfs.Item(0), .Text = gv.GetDataRow(row_handle).Item("Folder Name")}
                frm.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuCopyLoop.ItemClick
        grdView.CopySelectedItems(gv, "Folder Name")
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        grdView.CopySelectedItems(gv, "Subsystem")
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        sveFle.Filter = "Views File|*.xml"
        sveFle.FileName = ""
        sveFle.ShowDialog()
        If sveFle.FileName <> "" Then
            If grdView.SaveViewLayout(gv, sveFle.FileName) Then
                MsgBox("View Has Been Saved", MsgBoxStyle.Information, Me.Text)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, sveFle.FileName)
            End If
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        opnFle.FileName = ""
        opnFle.ShowDialog()
        Try
            If opnFle.FileName <> "" Then
                'grdView.setViewFromFile(gv, opnFle.FileName)
                grdView.ApplyViewLayout(gv, opnFle.FileName)
                SaveSetting("TR", "LOOPAPP", "VIEW_WINDOW_" & Me.Text, opnFle.FileName)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        grd.ShowPrintPreview()
    End Sub
    Private Sub frmHCSSetSteps_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        frmMain.MdiChildClosed(Me.Text)
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderSubmitToQC.ItemClick
        UpdateLoopSubmitToQC()
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderReturnFromQC.ItemClick
        UpdateLoopReturnFromQC()
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        UpdateLoopSubmittedToPrecomm()
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuLoopTasks.ItemClick
        GetHCSTasks()
    End Sub

    Private Sub grd_KeyDown(sender As Object, e As KeyEventArgs) Handles grd.KeyDown
        Select Case e.KeyCode
            Case Keys.Space
                ShowRadialMenu()
        End Select
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _filter As String = ""
        Dim inx As Integer = 0
        For Each row_handle As Integer In gv.GetSelectedRows
            If inx = 0 Then
                _filter = "[Folder Name] LIKE '" & gv.GetDataRow(row_handle).Item("Folder Name") & "'"
            Else
                _filter &= " OR [Folder Name] LIKE '" & gv.GetDataRow(row_handle).Item("Folder Name") & "'"
            End If
            inx += 1
        Next
        gv.Columns("Folder Name").FilterInfo = New ColumnFilterInfo(_filter)
    End Sub

    Private Sub rMenuSetFolderConsComplete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderConsComplete.ItemClick
        UpdateConstructionComplete()
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuShare.ItemClick
        Dim frm As New frmSelectShareMessageUser
        frm.ShowDialog(Me)
        If frm.isSelected Then
            Dim _filter As String = ""
            Dim inx As Integer = 0
            For Each row_handle As Integer In gv.GetSelectedRows
                If inx = 0 Then
                    _filter = "[Folder Name] LIKE '" & gv.GetDataRow(row_handle).Item("Folder Name") & "'"
                Else
                    _filter &= " OR [Folder Name] LIKE '" & gv.GetDataRow(row_handle).Item("Folder Name") & "'"
                End If
                inx += 1
            Next
            Notifications.PushMappedNotification(Users.userFullName, frm.selectedUserId, "Solo Run", frm.description, Replace(_filter, "'", "''",,, CompareMethod.Text))

        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderConsTargetDate.ItemClick
        UpdateConstructionTargetDate()
    End Sub

    Private Sub rMenuSetFolderFailed_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSetFolderFailed.ItemClick
        UpdateFailedtDate()
    End Sub

    Private Sub rMenuSoloRunPendingTasks_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rMenuSoloRunPendingTasks.ItemClick
        GetHCSPendingTasks()
    End Sub
End Class