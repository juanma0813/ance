Imports Telerik.Web.UI


Public Class clssMensaje
    Public Property Titulo As String
    Public Property Mensaje As String
    Public Property Icono As eImgMessage = eImgMessage.Information
    Public Property Ancho As Integer = 340
    Public Property Alto As Integer = 180
    Public Property UdpFireEvent As UpdatePanel

    Public Enum eImgMessage
        Information = 0
        [Error] = 1
        Question = 2
        [Nothing] = 3
        Alert = 4
        Exitoso = 5
    End Enum

    Public Function IconosMessage(Icono As eImgMessage) As String
        Dim UrlIcono As String = ""
        Select Case Icono
            Case eImgMessage.Information
                UrlIcono = "Imagenes/Mensajes/Information.png"
            Case eImgMessage.Error
                UrlIcono = "Imagenes/Mensajes/Error.png"
            Case eImgMessage.Question
                UrlIcono = "Imagenes/Mensajes/Question.png"
            Case eImgMessage.Alert
                UrlIcono = "Imagenes/Mensajes/Alert.png"
            Case eImgMessage.Nothing
                UrlIcono = ""
            Case eImgMessage.Exitoso
                UrlIcono = "Imagenes/Mensajes/Check-02.png"
        End Select
        Return UrlIcono
    End Function
End Class




