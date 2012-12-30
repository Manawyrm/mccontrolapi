Option Strict On
Imports JsonExSerializer
Imports System.Security.Cryptography
Imports System.Text

Public Class Connection
    Public hostname As String
    Public port As Integer
    Public username As String
    Public password As String
    Public salt As String
    Public proxy As System.Net.IWebProxy = Nothing
    Dim urlFormat_call As String = "http://{0}:{1}/api/call?method={2}&args={3}&key={4}"


    Public ser As New Serializer(GetType(ArrayList))
    Public deser As New Serializer(GetType(Dictionary(Of Object, Object)))
    Public Sub New(ByVal hostname_input As String, ByVal port_input As Integer, ByVal username_input As String, ByVal password_input As String, ByVal salt_input As String)
        hostname = hostname_input
        port = port_input
        username = username_input
        password = password_input
        salt = salt_input
        ser.Config.OutputTypeComment = False
        ser.Config.IsCompact = True
        ser.Config.OutputTypeInformation = False
        deser.Config.OutputTypeComment = False
        deser.Config.IsCompact = True

    End Sub

    Function CreateKey(ByVal methodNameOrSourceName As String) As String
        Return sha256(username + methodNameOrSourceName + password + salt)
    End Function

    Function ListenStream(ByVal sourceName As String) As String
        Dim urlFormat_stream As String = "/api/subscribe?source={2}&key={3}&show_previous=false"
        Return String.Format(urlFormat_stream, hostname, port, Uri.EscapeUriString(sourceName), CreateKey(sourceName))
    End Function
    Function CallMethod(ByVal methodName As String, ByVal args As ArrayList) As String
        Dim sb As New StringBuilder
        Dim sw As New System.IO.StringWriter(sb)
        Dim wc As New System.Net.WebClient

        Dim url As String = String.Format(urlFormat_call, hostname, port, Uri.EscapeUriString(methodName), Uri.EscapeUriString(ser.Serialize(args)), CreateKey(methodName))
        wc.Proxy = proxy
        Return wc.DownloadString(url)
    End Function

    Private Function sha256(ByVal input As String) As String
        Dim hash As New SHA256Managed()
        Dim hashed As Byte() = hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Return BitConverter.ToString(hashed).Replace("-", "").ToLower()
    End Function


End Class
