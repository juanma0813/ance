
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




End Class
