Imports mccontrolapi.Functions
Public Class frmMain

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ConsoleListener.StartListening()
        ChatListener.StartListening()
        ' MsgBox(mccontrolapi.Functions.getBinaryFileBase64("plugins/JSONAPI/config.yml", mccon))
    End Sub
    Dim WithEvents ConsoleListener As New mccontrolapi.ConsoleStream(mccon)
    Dim WithEvents ChatListener As New mccontrolapi.ChatStream(mccon)
    Private Sub ConsoleListener_ConsoleMessageReceived(ByVal message As mccontrolapi.ConsoleMessage) Handles ConsoleListener.ConsoleMessageReceived
        TextBox1.Text += message.Line + vbNewLine
    End Sub
    Private Sub ChatListener_ChatMessageReceived(ByVal message As mccontrolapi.ChatMessage) Handles ChatListener.ChatMessageReceived
        TextBox1.Text += message.Message + vbNewLine
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
