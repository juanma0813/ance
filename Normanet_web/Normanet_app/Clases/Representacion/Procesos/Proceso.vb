
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class ProcesoRepresentacion

#Region "REPRESENTACION"
    Public Shared Function getRepresentacion(ByVal Sector As Entidades.RepresentacionRequest) As List(Of Entidades.RepresentacionRequest)

        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/representacion/consulta"
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
                Return JsonConvert.DeserializeObject(Of List(Of Entidades.RepresentacionRequest))(reader.ReadToEnd())
            End Using


        Catch ex As WebException
            Return New List(Of Entidades.RepresentacionRequest)
        End Try
    End Function

    Public Shared Function createRepresentacion(ByVal Sector As Entidades.RepresentacionRequest)
        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/representacion"
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
            Return New List(Of Entidades.RepresentacionRequest)
        End Try
    End Function
    Public Shared Function updateRepresentacion(ByVal Sector As Entidades.RepresentacionRequest)
        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/representacion"
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
            Return New List(Of Entidades.RepresentacionRequest)
        End Try
    End Function

    Public Shared Function deleteRepresentacion(ByVal Sector As Entidades.RepresentacionRequest)
        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/representacion"
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
            Return New List(Of Entidades.RepresentacionRequest)
        End Try
    End Function
#End Region



End Class
