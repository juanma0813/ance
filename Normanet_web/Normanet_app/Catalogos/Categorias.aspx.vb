Public Class Categorias
    Inherits System.Web.UI.Page
    Dim listaCategorias As New List(Of Entidades.CategoriasNotiRequest)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getCategoriasNoticias()
    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                BotonesNuevo()
            Case eBtnFormularios.Editar
                updateCategoriasNoticias()
                'AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                addCategoriasNoticias()
                'MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Eliminar
                deleteCategoriasNoticias()
            Case eBtnFormularios.Salir

        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub

    Private Sub getCategoriasNoticias()
        Dim busqueda As New Entidades.CategoriasNotiRequest

        busqueda.Bandera = "1"
        busqueda.Descripcion = ""
        busqueda.Id_Categoria = ""

        listaCategorias = ProcesoCategorias.getCategoriaNoticias(busqueda)


        For Each item As Entidades.CategoriasNotiRequest In listaCategorias
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Descripcion
            item_.Value = item.Id_Categoria
            RadDropDownList1.Items.Add(item_)
        Next

    End Sub

    Private Sub addCategoriasNoticias()
        Dim entidad As New Entidades.CategoriasNotiRequest
        Dim respuesta As Boolean
        entidad.Bandera = "1"
        entidad.Descripcion = TextBox2.Text
        entidad.Id_Categoria = ""

        respuesta = ProcesoCategorias.add_update_delete_CategoriaNoticias(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al guardar", "..:: Categorias ::..")
        End If
    End Sub
    Private Sub updateCategoriasNoticias()
        Dim entidad As New Entidades.CategoriasNotiRequest
        Dim respuesta As Boolean
        entidad.Bandera = "2"
        entidad.Descripcion = TextBox2.Text
        entidad.Id_Categoria = RadDropDownList1.SelectedValue

        respuesta = ProcesoCategorias.add_update_delete_CategoriaNoticias(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al actualizar", "..:: Categorias ::..")
        End If
    End Sub
    Private Sub deleteCategoriasNoticias()
        Dim entidad As New Entidades.CategoriasNotiRequest
        Dim respuesta As Boolean
        entidad.Bandera = "3"
        entidad.Descripcion = TextBox2.Text
        entidad.Id_Categoria = RadDropDownList1.SelectedValue

        respuesta = ProcesoCategorias.add_update_delete_CategoriaNoticias(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al eliminar", "..:: Categorias ::..")
        End If
    End Sub

    Protected Sub RadDropDownList1_ItemSelected(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs)

        Dim CatSeleccionado = listaCategorias.Find(Function(cat) cat.Id_Categoria = e.Value)
        TextBox2.Text = CatSeleccionado.Descripcion

    End Sub

End Class