Imports System.Net
Imports System.IO
Imports System.Text

Public Class http
    Shared Function HttpPost(URL As String, PostData As String) As String
        Dim request As HttpWebRequest = WebRequest.Create(URL)
        request.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        If (CType(response, HttpWebResponse).StatusCode = HttpStatusCode.OK) Then
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()
            Return responseFromServer
        Else
            Return ""
        End If
    End Function
    Shared Function HttpGet(URL As String) As String
        Dim request As WebRequest = WebRequest.Create(URL)
        request.Credentials = CredentialCache.DefaultCredentials
        Dim response As WebResponse = request.GetResponse()
        If CType(response, HttpWebResponse).StatusCode = HttpStatusCode.OK Then
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            response.Close()
            Return responseFromServer
        Else
            Return ""
        End If
    End Function
End Class