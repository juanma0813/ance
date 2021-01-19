
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class ProcesoTiposRevEdit



#Region "TIPOS_REVISION_EDITORIAL"
    Public Shared Function getTiposRevision(ByVal TipoRevEdit As Entidades.TiposRevRequest) As List(Of Entidades.TiposRevRequest)

        Try
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "tiposrev/get"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"
            request.Method = "POST"


            Dim obj = JsonConvert.SerializeObject(TipoRevEdit)

            Using Stream As StreamWriter = New StreamWriter(request.GetRequestStream())
                Stream.Write(obj)
            End Using

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Using reader As StreamReader = New StreamReader(response.GetResponseStream)
                Return JsonConvert.DeserializeObject(Of List(Of Entidades.TiposRevRequest))(reader.ReadToEnd())
            End Using


        Catch ex As WebException
            Return New List(Of Entidades.TiposRevRequest)
        End Try
    End Function

    Public Shared Function add_update_delete_TiposRevision(ByVal TipoRevEdit As Entidades.TiposRevRequest)

        Try

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls

            Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "tiposrev/"
            Dim request As HttpWebRequest = CType(WebRequest.Create(value), HttpWebRequest)
            request.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            request.Headers.Add("token", ConfigurationManager.AppSettings("token"))
            request.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
            request.ContentType = "application/json"

            If (TipoRevEdit.Bandera = "1") Then
                request.Method = "POST"
            ElseIf (TipoRevEdit.Bandera = "3") Then
                request.Method = "PUT"
            ElseIf (TipoRevEdit.Bandera = "5") Then
                request.Method = "DELETE"
            End If

            Dim obj = JsonConvert.SerializeObject(TipoRevEdit)

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
            Return New Entidades.TiposRevRequest
        End Try
    End Function
#End Region



End Class
