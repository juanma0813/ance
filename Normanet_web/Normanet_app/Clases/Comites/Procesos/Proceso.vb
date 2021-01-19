
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Proceso

    Public Shared Function getComites_Get() As List(Of Entidades.getComites)
        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

        Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/comitetecnico"
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

    Public Shared Function getComiteDetalle(ByVal Comite As Entidades.GetDeleteComitesDescripcion_Parameter) As List(Of Entidades.getComitesDescripcion)
        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/comitetecnico/descripcion"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"
            Dim obj = JsonConvert.SerializeObject(Comite)
            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Dim cc As String
                cc = reader.ReadToEnd()
                Return JsonConvert.DeserializeObject(Of List(Of Entidades.getComitesDescripcion))(cc)
            End Using
        Catch ex As WebException
            Return New List(Of Entidades.getComitesDescripcion)
        End Try
    End Function

    Public Shared Function getEmpleado(ByVal Comite As Entidades.EmpleadoRequest) As List(Of Entidades.Empleados)
        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "empleados"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"
            Dim obj = JsonConvert.SerializeObject(Comite)
            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Dim cadena As String
                cadena = reader.ReadToEnd()
                Dim array As List(Of Entidades.Empleados)
                array = New List(Of Entidades.Empleados)

                array = JsonConvert.DeserializeObject(Of List(Of Entidades.Empleados))(cadena)
                Return array
            End Using
        Catch ex As WebException
            Return New List(Of Entidades.Empleados)
        End Try
    End Function


    Public Shared Function POSTComiteDetalle(ByVal Comite As Entidades.addComite_post_put_Parameter) As String
        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/comitetecnico"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"
            Dim obj = JsonConvert.SerializeObject(Comite)
            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Dim cc As String
                cc = reader.ReadToEnd()
                Return JsonConvert.DeserializeObject(Of String)(cc)
            End Using
        Catch ex As WebException
            Return ex.Message.ToString()
        End Try
    End Function



    Public Shared Function PUTComiteDetalle(ByVal Comite As Entidades.addComite_post_put_Parameter) As String
        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/comitetecnico"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "PUT"
            Dim obj = JsonConvert.SerializeObject(Comite)
            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Dim cc As String
                cc = reader.ReadToEnd()
                Return JsonConvert.DeserializeObject(Of String)(cc)
            End Using
        Catch ex As WebException
            Return ex.Message.ToString()
        End Try
    End Function
End Class
