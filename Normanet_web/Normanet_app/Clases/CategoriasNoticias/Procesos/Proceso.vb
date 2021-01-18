
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class ProcesoCategorias

#Region "CATEGORIA_NOTICIAS"
    Public Shared Function getCategoriaNoticias(ByVal Categoria As Entidades.CategoriasNotiRequest) As List(Of Entidades.CategoriasNotiRequest)

        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "categoriasnoti/get"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"


            Dim obj = JsonConvert.SerializeObject(Categoria)

            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Return JsonConvert.DeserializeObject(Of List(Of Entidades.CategoriasNotiRequest))(reader.ReadToEnd())
            End Using

        Catch ex As WebException
            Return New List(Of Entidades.CategoriasNotiRequest)
        End Try
    End Function

    Public Shared Function add_update_delete_CategoriaNoticias(ByVal Categoria As Entidades.CategoriasNotiRequest)

        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "categoriasnoti/"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"

            If (Categoria.Bandera = "1") Then
                request.Method = "POST"
            ElseIf (Categoria.Bandera = "2") Then
                request.Method = "PUT"
            ElseIf (Categoria.Bandera = "3") Then
                request.Method = "DELETE"
            End If

            Dim obj = JsonConvert.SerializeObject(Categoria)

            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            If response.StatusCode = HttpStatusCode.OK Then
                Return True
            Else
                Return False
            End If

        Catch ex As WebException
            Return New List(Of Entidades.CategoriasNotiRequest)
        End Try
    End Function
#End Region

End Class
