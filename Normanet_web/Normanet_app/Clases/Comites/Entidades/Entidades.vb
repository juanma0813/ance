
Namespace Entidades

#Region "COMITE"
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

#End Region


#Region "DIRECTORIO"
    Public Class getDirectorio
        Public Property ID_Directorio As String
        Public Property Nombre As String
        Public Property Empresa As String
        Public Property Domicilio As String
        Public Property Telefono As String
        Public Property Fax As String
        Public Property Mail As String
        Public Property Password As String
        Public Property IdDirectorioStatus As Integer

    End Class

    Public Class getDirectorio_Request
        Public Property ID_Directorio As String
        Public Property Mail As String
        Public Property Password As String
        Public Property Bandera As String
    End Class

    Public Class DirectorioRequest
        Public Property ID_Directorio As String
        Public Property Nombre As String
        Public Property Empresa As String
        Public Property Domicilio As String
        Public Property Telefono As String
        Public Property Fax As String
        Public Property Mail As String
        Public Property Password As String
        Public Property Bandera As String
    End Class

#End Region

#Region "CARGOS"
    Public Class Cargos
        Public Property Bandera As String
        Public Property xml As String
        Public Property Descripcion As String
        Public Property ID_Cargo As String
        Public Property Comite As String
        Public Property CT As String
        Public Property SC As String
        Public Property GT As String
        Public Property Dependencia As String
    End Class

#End Region

#Region "NOTICIAS"
    'Public Class CategoriasNotiRequest
    '    Public Property Descripcion As String
    '    Public Property Bandera As String
    '    Public Property Id_Categoria As String
    'End Class

#End Region

#Region "TIPOSREVISION"
    Public Class TiposRevRequest
        Public Property Id_tipo_Rev As String
        Public Property Nombre_Revision As String
        Public Property Contenido As String
        Public Property Bandera As String
        Public Property Inactivo As String
    End Class

#End Region

#Region "ESTATUSREVISION"
    Public Class EstatusRevRequest
        Public Property Id_Status_Rev As String
        Public Property Descripcion As String
        Public Property Color As String
        Public Property Bandera As String
    End Class

#End Region

#Region "INCISOSREVISION"
    Public Class IncisoRevRequest
        Public Property Id_Inciso_Rev As String
        Public Property Id_tipo_Rev As String
        Public Property Id_Status_Rev As String
        Public Property Requisito As String
        Public Property Descripcion As String
        Public Property Inactivo As String
        Public Property Bandera As String
    End Class

#End Region

#Region "SECTORES"
    Public Class SectoresRequest
        Public Property ID_Sector As String
        Public Property Descripcion As String
        Public Property Bandera As String
        Public Property Inactivo As String
    End Class

#End Region
#Region "REPRESENTACION"
    Public Class RepresentacionRequest
        Public Property ID_Representacion As String
        Public Property Descripcion As String
        Public Property Comite As String
        Public Property CT As String
        Public Property Bandera As String
    End Class

#End Region
#Region "REMITENTES"
    Public Class RemitentesRequest
        Public Property IdRemitente As String
        Public Property Nombre As String
        Public Property Empresa As String
        Public Property Puesto As String
        Public Property Email As String
        Public Property EmailAlterno As String
        Public Property FechaAlta As String
        Public Property Activo As String
        Public Property Bandera As String
    End Class

#End Region
#Region "NOMBRAMIENTO"
    Public Class NombramientoRequest
        Public Property IdNombramiento As String
        Public Property Folio As String
        Public Property FechaIngreso As String
        Public Property IdRemitente As String
        Public Property Nombramiento As String
        Public Property FechaRespuestaMaxima As String
        Public Property FechaRespuestaVencimiento As String
        Public Property RequiereRespuesta As String
        Public Property FechaRespuestaReal As String
        Public Property Activo As String
        Public Property Bandera As String
    End Class

#End Region
#Region "EMPLEADOS"
    Public Class EmpleadoRequest
        Public Property Bandera As String
        Public Property ID_Usuario As String
        Public Property ID_Area As String
        Public Property Id_Sistema As String
    End Class

#End Region
End Namespace