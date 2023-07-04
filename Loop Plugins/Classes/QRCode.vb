Imports QRCoder

Public Class QRCode

    Public Overloads Function GenerateQRCode(ByVal code As String) As Image
        Dim qr As New QRCoder.QRCodeGenerator
        Dim qd As QRCodeData
        Dim qImage As New BitmapByteQRCode
        qd = qr.CreateQrCode(code, QRCodeGenerator.ECCLevel.M, True, True, QRCodeGenerator.EciMode.Utf8)
        qImage.SetQRCodeData(qd)
        Dim myimage As Image
        Dim ms As New System.IO.MemoryStream(qImage.GetGraphic(20))
        myimage = System.Drawing.Image.FromStream(ms)
        Return myimage
    End Function
    Public Overloads Function GenerateQRCode(ByVal code As String, ByVal key As String) As String
        Dim qr As New QRCoder.QRCodeGenerator
        Dim qd As QRCodeData
        Dim qImage As New BitmapByteQRCode
        qd = qr.CreateQrCode(code, QRCodeGenerator.ECCLevel.M, True, True, QRCodeGenerator.EciMode.Utf8)
        qImage.SetQRCodeData(qd)
        Dim myimage As Image
        Dim ms As New System.IO.MemoryStream(qImage.GetGraphic(20))
        myimage = System.Drawing.Image.FromStream(ms)
        Dim imgPath As String = Application.StartupPath & "\tmp\" & key & ".jpg"
        myimage.Save(imgPath, Imaging.ImageFormat.Jpeg)
        Return imgPath
    End Function
End Class
