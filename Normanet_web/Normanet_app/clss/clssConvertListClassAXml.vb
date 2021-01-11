Imports System.Xml.Serialization
Imports System.Xml
Imports System.IO

Public Class clssConvertListClassAXml
    Public Property sXml As String
    Public Property List As Object
    Public Property TipoLista As Type
    Public Property sRootAttribute As String
    Public Property sEncode As String


    Sub New()
        sEncode = "ISO-8859-1"
    End Sub

    Function ConvertListAXml() As String
        Dim xmlSeri As New XmlSerializer(TipoLista, New XmlRootAttribute(sRootAttribute))
        Dim names As New XmlSerializerNamespaces
        Dim Encod = Encoding.GetEncoding(sEncode)
        names.Add("", "")
        Dim xmlsetting As New XmlWriterSettings With {.Indent = True, .OmitXmlDeclaration = False, .Encoding = Encod}

        Using stream As New MemoryStream

            Using xmlwrt As XmlWriter = XmlWriter.Create(stream, xmlsetting)
                xmlSeri.Serialize(xmlwrt, List, names)
                'sXml = stream.ToString
            End Using

            sXml = Encod.GetString(stream.ToArray())

        End Using

        Return sXml
    End Function

End Class
