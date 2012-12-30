Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Threading

Public Class ChatStream
    Dim con As Connection
    Public Sub New(ByVal connection As Connection)
        con = connection
    End Sub
    Dim listening As Boolean = False
    Dim sr As System.IO.StreamReader
    Dim sw As System.IO.StreamWriter
    Dim readthread As New System.Threading.Thread(AddressOf DataReader)
    Private _context As SynchronizationContext

    Public Sub StartListening()
        If listening = False Then
            Dim tcpcl As New System.Net.Sockets.TcpClient(con.hostname, con.port + 1)

            sw = New StreamWriter(tcpcl.GetStream())
            sw.WriteLine(con.ListenStream("chat"))
            sw.Flush()

            sr = New StreamReader(tcpcl.GetStream())
            listening = True
            _context = SynchronizationContext.Current
            If _context Is Nothing Then
                _context = New SynchronizationContext()
            End If
            readthread.IsBackground = True
            readthread.Start()
        End If

    End Sub
    Dim msg As ChatMessage
    Public Sub DataReader()
        While (True)
            Dim chatresponseobj As System.Collections.Hashtable = con.deser.Deserialize(sr.ReadLine())("success")
            Dim message As New ChatMessage()
            message.Player = chatresponseobj("player")
            message.Time = chatresponseobj("time")
            message.Message = chatresponseobj("message")
            msg = message
            _context.Post(New SendOrPostCallback(AddressOf ThreadSafeDataReader), Nothing)
        End While
    End Sub
    Public Sub ThreadSafeDataReader()
        RaiseEvent ChatMessageReceived(msg)
    End Sub

    Public Event ChatMessageReceived(ByVal message As ChatMessage)


End Class
Public Class ChatMessage
    Public Player As String
    Public Time As Integer
    Public Message As String
End Class