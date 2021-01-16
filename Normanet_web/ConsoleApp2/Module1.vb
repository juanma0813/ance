Imports System.Configuration
Imports Newtonsoft.Json

Module Module1

    Sub Main()
        Dim getComites As List(Of Entidades.getComites) = getComites_Get("CT 14", "SC 14 A")
        Console.ReadLine()

    End Sub

    Public Function getComites_Get(ByVal ID_CT As String, ByVal ID_SC As String) As List(Of Entidades.getComites)
        Dim value As String = ConfigurationManager.AppSettings("EndpointBase") & "/comitetecnico/CONANCE/" & ID_CT & "/" + ID_SC
        Dim request As String = value
        Dim webClient As New System.Net.WebClient
        webClient.Headers.Add("token", ConfigurationManager.AppSettings("Token"))
        webClient.Headers.Add("Cookie", ConfigurationManager.AppSettings("Cookie"))
        Dim result As String = webClient.DownloadString(request)
        Return JsonConvert.DeserializeObject(Of List(Of Entidades.getComites))(result)
    End Function



End Module


Namespace Entidades
    Public Class getComites
        Public Property ID_Comite As String
        Public Property ID_CT As String
        Public Property ID_SC As String
        Public Property ID_Grupo As String
        Public Property Descripcion As String
        Public Property Objetivo As String
        Public Property Responsable As String
    End Class
    Public Class getComitesDescripcion
        Public Property ID_Comite As String
        Public Property ID_CT As String
        Public Property ID_SC As String
        Public Property ID_Grupo As String
        Public Property Descripcion As String
        Public Property Objetivo As String
        Public Property Responsable As String
        Public Property Inactivo As Boolean
    End Class
    Public Class GetDeleteComitesDescripcion_Parameter
        Public Property Bandera As String
        Public Property Comite As String
        Public Property CT As String
        Public Property SC As String
        Public Property GT As String
    End Class
    Public Class addComite_post_put_Parameter
        Public Property Bandera As String
        Public Property Comite As String
        Public Property Descripcion As String
        Public Property Responsable As String
        Public Property Inactivo As String
        Public Property Objetivo As String
        Public Property CT As String
        Public Property SC As String
        Public Property GT As String
    End Class
End Namespace
