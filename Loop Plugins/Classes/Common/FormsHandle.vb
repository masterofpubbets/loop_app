Public Class FormsHandle

    Public Sub New(formHandle As IntPtr, formId As String)
        Me.Id = formId
        Me.Handle = formHandle
    End Sub

    Public Property Handle As IntPtr
    Public Id As String
End Class
