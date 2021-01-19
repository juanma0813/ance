
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class ProcesoSectores

#Region "SECTORES"
    Public Shared Function getSector(ByVal Sector As Entidades.SectoresRequest) As List(Of Entidades.SectoresRequest)

        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/sectores/consulta"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"


            Dim obj = JsonConvert.SerializeObject(Sector)

            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Return JsonConvert.DeserializeObject(Of List(Of Entidades.SectoresRequest))(reader.ReadToEnd())
            End Using


        Catch ex As WebException
            Return New List(Of Entidades.SectoresRequest)
        End Try
    End Function

    Public Shared Function createSector(ByVal Sector As Entidades.SectoresRequest)
        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/sectores"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"

            Dim obj = JsonConvert.SerializeObject(Sector)

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
            Return New List(Of Entidades.SectoresRequest)
        End Try
    End Function
    Public Shared Function updateSector(ByVal Sector As Entidades.SectoresRequest)
        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/sectores"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "PUT"

            Dim obj = JsonConvert.SerializeObject(Sector)

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
            Return New List(Of Entidades.SectoresRequest)
        End Try
    End Function

    Public Shared Function deleteSector(ByVal Sector As Entidades.SectoresRequest)
        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/sectores"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "DELETE"

            Dim obj = JsonConvert.SerializeObject(Sector)

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
            Return New List(Of Entidades.SectoresRequest)
        End Try
    End Function
#End Region



End Class
