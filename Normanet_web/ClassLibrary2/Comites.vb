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
