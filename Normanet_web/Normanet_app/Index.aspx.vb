Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        CuentaRegresivaSesion(Me.Page, Session)
    End Sub

    Protected Sub rbbRibbon_ButtonClick(sender As Object, e As Telerik.Web.UI.RibbonBarButtonClickEventArgs) Handles rbbRibbon.ButtonClick
        Menu(e.Button.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnPrincipal.Comite
                OpenWindow("Catalogos/Comite.aspx", "..:: Comité ::..", 700, 370)
            Case eBtnPrincipal.Cargos
                OpenWindow("Catalogos/Cargos.aspx", "..::  Cargos ::..", 700, 325)
            Case eBtnPrincipal.Categorias
                OpenWindow("Catalogos/Categorias.aspx", "..:: Categorias ::..", 700, 130)
            Case eBtnPrincipal.Categorias_Revision_Editorial
                OpenWindow("Catalogos/CategoriaRevEditorial.aspx", "..:: Categorias de Revisión Editorial ::..", 700, 130)
            Case eBtnPrincipal.Directorio
                OpenWindow("Catalogos/Directorio.aspx", "..:: Directorio ::..", 900, 600)
            Case eBtnPrincipal.Nombramientos
                OpenWindow("Catalogos/Nombramientos.aspx", "..:: Nombramientos ::..", 1200, 500)
            Case eBtnPrincipal.Puntos_Revisión_Editoria
                OpenWindow("Catalogos/PuntosRevEditorial.aspx", "..:: Puntos de Revisión Editorial ::..", 700, 400)
            Case eBtnPrincipal.Remitentes
                OpenWindow("Catalogos/Remitente.aspx", "..:: Remitentes ::..", 700, 500)
            Case eBtnPrincipal.ReporteAsistencia
                OpenWindow("Catalogos/ReporteAsistencia.aspx", "..:: Reporte Asistencia ::..", 700, 500)
            Case eBtnPrincipal.Representacion
                OpenWindow("Catalogos/Representacion.aspx", "..:: Representación ::..", 700, 280)
            Case eBtnPrincipal.Sectores
                OpenWindow("Catalogos/Sectores.aspx", "..:: Sectores ::..", 700, 200)
            Case eBtnPrincipal.TitularesSuplentes
                OpenWindow("Catalogos/TitularesSuplentes.aspx", "..:: Sectores ::..", 700, 270)
            Case eBtnPrincipal.PNN
                OpenWindow("Procesos/pnn.aspx", "..:: Plan Nacional de Normalización ::..", 700, 380)
            Case eBtnPrincipal.PNNTemas
                OpenWindow("Procesos/PnnTemas.aspx", "..:: PNN Temas ::..", 700, 700)
            Case eBtnPrincipal.TraspasoTemasPlanes
                OpenWindow("Procesos/TraspasoTemaPlanes.aspx", "..:: Traspaso Temas Planes ::..", 700, 450)
            Case eBtnPrincipal.CatalogoNormas
                OpenWindow("Procesos/CatalogoNormas.aspx", "..:: Traspaso Temas Planes ::..", 900, 700)

        End Select
    End Sub

    Public Sub OpenWindow(sPagina As String, sTitulo As String, Width As Integer, Height As Integer)
        ScriptManager.RegisterClientScriptBlock(udpCBJquery, Me.GetType, Guid.NewGuid.ToString, "OpenWindow('" & sPagina & "','" & sTitulo & "'," & Width & "," & Height & ");", True)
    End Sub

End Class