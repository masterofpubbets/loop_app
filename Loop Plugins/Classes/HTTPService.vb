Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Text

Public Class HTTPService

#Region "Internal"
    Private Function GetFileShortName(ByVal FilePath As String) As String
        Dim temp() As String = Split(FilePath, "\")
        If temp.Count > 0 Then
            Return temp(temp.Count - 1)
        End If
        Return ""
    End Function
#End Region
#Region "Methods"
    Public Sub RenameFTPFile(ByVal FTPPath As String, ByVal CurrentFileName As String, ByVal NewFileName As String, FTPUser As String, FTPPassword As String)
        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(String.Format("{0}/{1}", FTPPath, CurrentFileName)), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential(FTPUser, FTPPassword)
            request.Method = System.Net.WebRequestMethods.Ftp.Rename
            request.RenameTo = NewFileName
            request.GetResponse()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub DeleteFTPFile(ByVal FTPPath As String, ByVal FileName As String, FTPUser As String, FTPPassword As String)
        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(String.Format("{0}/{1}", FTPPath, FileName)), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential(FTPUser, FTPPassword)
            request.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            request.GetResponse()
        Catch ex As Exception
        End Try
    End Sub
    Public Function UploadToFTP(ByVal FilePath As String, ByVal FTPPath As String, FTPUser As String, FTPPassword As String) As Boolean
        Try
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(String.Format("{0}/{1}", FTPPath, GetFileShortName(FilePath))), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential(FTPUser, FTPPassword)
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            Dim file() As Byte = System.IO.File.ReadAllBytes(FilePath)
            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function DownloadFromFTP(ByVal Downloadpath As String, ByVal FTPPath As String, ByVal FTPUser As String, ByVal FTPPassword As String) As Boolean
        Dim request As New WebClient() With {.Credentials = New NetworkCredential(FTPUser, FTPPassword)}
        Dim bytes() As Byte = request.DownloadData(FTPPath)
        Try
            Dim DownloadStream As FileStream = IO.File.Create(Downloadpath)
            DownloadStream.Write(bytes, 0, bytes.Length)
            DownloadStream.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function httpGet(ByVal URL As String) As String
        Try
            Dim strData As String
            Dim dataStream As Stream
            Dim reader As StreamReader
            Dim request As WebRequest
            Dim response As WebResponse
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            request = WebRequest.Create(URL)
            response = request.GetResponse()
            dataStream = response.GetResponseStream()
            reader = New StreamReader(dataStream)
            strData = reader.ReadToEnd()
            Return strData
            reader.Close()
            response.Close()
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
    Public Overloads Function httpPost(ByVal dictData As Dictionary(Of String, String), ByRef result As Newtonsoft.Json.Linq.JObject, ByVal url As String, Optional ByVal token As String = "") As Boolean
        Dim webClient As New WebClient()
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte

        Try
            webClient.Headers("content-type") = "application/json"
            webClient.Headers.Add("Access-Control-Allow-Origin", "*")
            webClient.Headers.Add("Access-Control-Allow-Headers", "X-API-KEY, x-auth-token, Origin, X-Requested-With, Content-Type, Accept, Authorization, Access-Control-Request-Method, PARAM_HEADER")
            webClient.Headers.Add("Access-Control-Allow-Credentials", "true")
            webClient.Headers.Add("Access-Control-Expose-Headers", "x-auth-token")

            If token <> "" Then
                webClient.Headers.Add("x-auth-token", token)
            End If

            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
            resByte = webClient.UploadData(url, "post", reqString)
            resString = Encoding.Default.GetString(resByte)
            result = JsonConvert.DeserializeObject(resString)
            webClient.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Overloads Function httpPost(ByVal dictData As Dictionary(Of String, String), ByRef result As String, ByVal url As String, Optional ByVal token As String = "") As Boolean
        Dim webClient As New WebClient()
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte

        Try
            webClient.Headers("content-type") = "application/json"
            webClient.Headers.Add("Access-Control-Allow-Origin", "*")
            webClient.Headers.Add("Access-Control-Allow-Headers", "X-API-KEY, x-auth-token, Origin, X-Requested-With, Content-Type, Accept, Authorization, Access-Control-Request-Method, PARAM_HEADER")
            webClient.Headers.Add("Access-Control-Allow-Credentials", "true")
            webClient.Headers.Add("Access-Control-Expose-Headers", "x-auth-token")

            If token <> "" Then
                webClient.Headers.Add("x-auth-token", token)
            End If

            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
            resByte = webClient.UploadData(url, "post", reqString)
            resString = Encoding.Default.GetString(resByte)
            result = resString
            webClient.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function GetImageFromURL(ByVal url As String) As Image
        Dim retVal As Image = Nothing
        Try
            If Not String.IsNullOrWhiteSpace(url) Then
                Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(url.Trim)

                Using request As System.Net.WebResponse = req.GetResponse
                    Using stream As System.IO.Stream = request.GetResponseStream
                        retVal = New Bitmap(System.Drawing.Image.FromStream(stream))
                    End Using
                End Using
            End If
        Catch ex As Exception
            '' MessageBox.Show(String.Format("An error occurred:{0}{0}{1}",
            '                               vbCrLf, ex.Message),
            '                               "Exception Thrown",
            '                               MessageBoxButtons.OK,
            '                               MessageBoxIcon.Warning)
        End Try
        Return retVal

    End Function
#End Region


End Class
