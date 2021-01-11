Public Class clssSendMail
    Inherits clsSendMail.AnceSystem.clssSendMail
    Public ListCamposXML As New List(Of clssCamposXML)

    Sub New()
        MyBase.New("cnSendMail")
        PerfilSQL = ConfigurationManager.AppSettings("PerfilSQLMail")
    End Sub


    Public Function CrearParamXML() As String
        Dim sXml As String = ""
        Dim sEncoding As String


        sEncoding = "<?xml version=""1.0"" encoding=""iso-8859-1""?>"


        For Each item As clssCamposXML In ListCamposXML
            sXml = sXml & item.Campo & "=""" & item.Valor & """ "
        Next
        sXml = "<campo Id=""0"" " & sXml & "/>"


        If sXml <> "" Then
            sXml = "<campos>" & sXml & "</campos>"
            sXml = sEncoding & sXml
        End If

        Return sXml

    End Function

    Class clssCamposXML
        Public Property Campo As String
        Public Property Valor As String
    End Class

End Class
