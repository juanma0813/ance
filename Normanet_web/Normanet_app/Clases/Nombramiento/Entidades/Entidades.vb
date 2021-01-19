
Namespace Entidades
#Region "NOMBRAMIENTO"
    Public Class NombramientoRequest
        Public Property IdNombramiento As String
        Public Property Folio As String
        Public Property FechaIngreso As Date?
        Public Property IdRemitente As String
        Public Property Nombramiento As String
        Public Property FechaRespuestaMaxima As Date?
        Public Property FechaRespuestaVencimiento As Date?
        Public Property RequiereRespuesta As String
        Public Property FechaRespuestaReal As Date?
        Public Property Activo As String
        Public Property Bandera As String
    End Class
    Public Class NombramientoTabla
        Public Property IdNombramiento As String
        Public Property Folio As String
        Public Property FechaIngreso As String
        Public Property IdRemitente As String
        Public Property Nombramiento As String
        Public Property FechaRespuestaMaxima As String
        Public Property FechaRespuestaVencimiento As String
        Public Property RequiereRespuesta As String
        Public Property FechaRespuestaReal As String
        Public Property CorreoRemitente As String
        Public Property EmpresaRemitente As String
    End Class

#End Region

End Namespace