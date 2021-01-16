Module Module1

    Sub Main()
        Dim getComites As List(Of EntidadesNormanet.Entidades.getComites) = ProcesosNormanet.Proceso.Comites.getComites_Get("CT 14", "SC 14 A")

        'Dim getDelete As EntidadesNormanet.Entidades.GetDeleteComitesDescripcion_Parameter = New EntidadesNormanet.Entidades.GetDeleteComitesDescripcion_Parameter()
        'getDelete.Bandera = "4"
        'getDelete.Comite = "CONANCE 2"
        'getDelete.CT = "CT 14"
        'getDelete.GT = "GT 14 TEST"
        'getDelete.SC = "SC 14 A"
        'Dim getComitesDescripcion As List(Of EntidadesNormanet.Entidades.getComitesDescripcion) = ProcesosNormanet.Proceso.Comites.getComitesDescripcion_Get(getDelete)

        'Dim addComite_post_put_Parameter As EntidadesNormanet.Entidades.addComite_post_put_Parameter = New EntidadesNormanet.Entidades.addComite_post_put_Parameter()
        'addComite_post_put_Parameter.Bandera = "4"
        'addComite_post_put_Parameter.Comite = "CONANCE 22"
        'addComite_post_put_Parameter.Descripcion = "Prueba 22"
        'addComite_post_put_Parameter.Responsable = "mamota2"
        'addComite_post_put_Parameter.Inactivo = "0"
        'addComite_post_put_Parameter.Objetivo = "NA"
        'addComite_post_put_Parameter.CT = "CT 14"
        'addComite_post_put_Parameter.SC = "SC 14 A"
        'addComite_post_put_Parameter.GT = "GT 14 TEST"
        'Dim Estatus As String = ProcesosNormanet.Proceso.Comites.addComite_post(addComite_post_put_Parameter)

        'Dim addComite_post_put_Parameter As EntidadesNormanet.Entidades.addComite_post_put_Parameter = New EntidadesNormanet.Entidades.addComite_post_put_Parameter()
        'addComite_post_put_Parameter.Bandera = "4"
        'addComite_post_put_Parameter.Comite = "CONANCE 22"
        'addComite_post_put_Parameter.Descripcion = "Prueba 22"
        'addComite_post_put_Parameter.Responsable = "mamota2"
        'addComite_post_put_Parameter.Inactivo = "0"
        'addComite_post_put_Parameter.Objetivo = "NA"
        'addComite_post_put_Parameter.CT = "CT 14"
        'addComite_post_put_Parameter.SC = "SC 14 A"
        'addComite_post_put_Parameter.GT = "GT 14 TEST"
        'Dim Estatus As String = ProcesosNormanet.Proceso.Comites.addComite_put(addComite_post_put_Parameter)
        Console.WriteLine()
    End Sub

End Module
