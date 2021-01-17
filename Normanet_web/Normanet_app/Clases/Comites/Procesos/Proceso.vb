
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Proceso

    Public Shared Function getComites_Get(ByVal ID_CT As String, ByVal ID_SC As String) As List(Of Entidades.getComites)
        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

        Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/comitetecnico/CONANCE/" & ID_CT & "/" + ID_SC
        Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
        request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
        request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
        request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
        request.Method = "GET"



        Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using stream As Stream = response.GetResponseStream()

                Using reader As StreamReader = New StreamReader(stream)

                    Return JsonConvert.DeserializeObject(Of List(Of Entidades.getComites))(reader.ReadToEnd())
                End Using
            End Using
        End Using
    End Function

#Region "DIRECTORIO"
    Public Shared Function getDirectorio_Get(ByVal Directorio As Entidades.DirectorioRequest) As List(Of Entidades.DirectorioRequest)

        Try


            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "directorio/consulta"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"


            Dim obj = JsonConvert.SerializeObject(Directorio)

            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Return JsonConvert.DeserializeObject(Of List(Of Entidades.DirectorioRequest))(reader.ReadToEnd())
            End Using


        Catch ex As WebException
            Return New List(Of Entidades.DirectorioRequest)
        End Try
    End Function
#End Region



End Class
