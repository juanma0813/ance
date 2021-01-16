Imports System.Configuration
Imports Newtonsoft.Json
Imports RestSharp
Namespace Proceso
    Public Class Comites
        Public Shared Function getComites_Get(ByVal ID_CT As String, ByVal ID_SC As String) As List(Of EntidadesNormanet.Entidades.getComites)
            Dim value As String = System.Configuration.ConfigurationManager.AppSettings("EndpointBase")
            Dim client = New RestClient(value & "/comitetecnico/CONANCE/" & ID_CT & "/" + ID_SC)
            client.Timeout = -1
            Dim request = New RestRequest(Method.[GET])
            request.AddHeader("token", "ANC3202!")
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8")
            Dim response As IRestResponse = client.Execute(request)
            Dim Response_ As List(Of EntidadesNormanet.Entidades.getComites) = JsonConvert.DeserializeObject(Of List(Of EntidadesNormanet.Entidades.getComites))(response.Content)
            Return Response_
        End Function
        Public Shared Function getComitesDescripcion_Get(ByVal _Parameter As EntidadesNormanet.Entidades.GetDeleteComitesDescripcion_Parameter) As List(Of EntidadesNormanet.Entidades.getComitesDescripcion)
            Dim value As String = System.Configuration.ConfigurationManager.AppSettings("EndpointBase") & "comitetecnico/descripcion"
            Dim client = New RestClient(value)
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            request.AddHeader("token", "ANC3202!")
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8")
            Dim h As String = JsonConvert.SerializeObject(_Parameter)
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            Dim Response_ As List(Of EntidadesNormanet.Entidades.getComitesDescripcion) = JsonConvert.DeserializeObject(Of List(Of EntidadesNormanet.Entidades.getComitesDescripcion))(response.Content)
            Return Response_
        End Function
        Public Shared Function addComite_post(ByVal _Parameter As EntidadesNormanet.Entidades.addComite_post_put_Parameter) As String
            Dim value As String = System.Configuration.ConfigurationManager.AppSettings("EndpointBase")
            Dim client = New RestClient(value & "comitetecnico")
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            request.AddHeader("token", "ANC3202!")
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8")
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            Return response.StatusCode.ToString()
        End Function
        Public Shared Function addComite_put(ByVal _Parameter As EntidadesNormanet.Entidades.addComite_post_put_Parameter) As String
            Dim value As String = System.Configuration.ConfigurationManager.AppSettings("EndpointBase")
            Dim client = New RestClient(value & "comitetecnico")
            client.Timeout = -1
            Dim request = New RestRequest(Method.PUT)
            request.AddHeader("token", "ANC3202!")
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8")
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            Return response.StatusCode.ToString()
        End Function
        Public Function addComite_delete(ByVal _Parameter As EntidadesNormanet.Entidades.GetDeleteComitesDescripcion_Parameter) As String
            Dim value As String = System.Configuration.ConfigurationManager.AppSettings("EndpointBase")
            Dim client = New RestClient(value & "comitetecnico")
            client.Timeout = -1
            Dim request = New RestRequest(Method.DELETE)
            request.AddHeader("token", "ANC3202!")
            request.AddHeader("Content-Type", "application/json")
            request.AddHeader("Cookie", "ARRAffinity=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8; ARRAffinitySameSite=8f8ac6c076f7a9e2132f2eea1ff0fc61836fde1fef8c5525da0e81359003c9e8")
            request.AddParameter("application/json", JsonConvert.SerializeObject(_Parameter), ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            Return response.StatusCode.ToString()
        End Function
    End Class
End Namespace
