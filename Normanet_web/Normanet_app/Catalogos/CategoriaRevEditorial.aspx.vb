Public Class CategoriaRevEditorial
    Inherits System.Web.UI.Page
    Dim listaTiposRevision As New List(Of Entidades.TiposRevRequest)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getTiposRevEdit()
    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                BotonesNuevo()
            Case eBtnFormularios.Editar
                updateTipoRevision()
                'AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                'addTipoRevision()
                MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Eliminar
                deleteTipoRevision()
            Case eBtnFormularios.Salir
                SalirPagina()


        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub

    Private Sub getTiposRevEdit()
        Dim entidad As New Entidades.TiposRevRequest

        entidad.Bandera = "1"

        listaTiposRevision = ProcesoTiposRevEdit.getTiposRevision(entidad)


        For Each item As Entidades.TiposRevRequest In listaTiposRevision
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Nombre_Revision
            item_.Value = item.Id_tipo_Rev
            RadDropDownList1.Items.Add(item_)
        Next

    End Sub

    Private Sub addTipoRevision()
        Dim entidad As New Entidades.TiposRevRequest
        Dim respuesta As Boolean
        entidad.Bandera = "1"
        entidad.Nombre_Revision = TextBox2.Text

        respuesta = ProcesoTiposRevEdit.add_update_delete_TiposRevision(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias de Revisión Editorial ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al guardar", "..:: Categorias de Revisión Editorial ::..")
        End If
    End Sub
    Private Sub updateTipoRevision()
        Dim entidad As New Entidades.TiposRevRequest
        Dim respuesta As Boolean
        entidad.Bandera = "3"
        entidad.Nombre_Revision = TextBox2.Text
        entidad.Id_tipo_Rev = RadDropDownList1.SelectedValue

        respuesta = ProcesoTiposRevEdit.add_update_delete_TiposRevision(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias de Revisión Editorial ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al actualizar", "..:: Categorias de Revisión Editorial ::..")
        End If
    End Sub
    Private Sub deleteTipoRevision()
        Dim entidad As New Entidades.TiposRevRequest
        Dim respuesta As Boolean
        entidad.Bandera = "4"
        entidad.Nombre_Revision = TextBox2.Text
        entidad.Id_tipo_Rev = RadDropDownList1.SelectedValue
        entidad.Inactivo = "1"

        respuesta = ProcesoTiposRevEdit.add_update_delete_TiposRevision(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias de Revisión Editorial ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al eliminar", "..:: Categorias de Revisión Editorial ::..")
        End If
    End Sub

    Protected Sub RadDropDownList1_ItemSelected(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs)

        Dim TipoSeleccionado = listaTiposRevision.Find(Function(tipo) tipo.Id_tipo_Rev = e.Value)
        TextBox2.Text = TipoSeleccionado.Nombre_Revision

    End Sub

    Private Sub Recargar()
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Private Sub SalirPagina()
        ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "window.close();", True)
    End Sub

    Protected Sub cmdAceptar_Click(sender As Object, e As ImageClickEventArgs) Handles cmdAceptar.Click
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, Guid.NewGuid.ToString, "$('#pnlConfirm').dialog('close');", True)
        Recargar()
    End Sub

    Protected Sub cmdCancelar_Click(sender As Object, e As ImageClickEventArgs) Handles cmdCancelar.Click
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, Guid.NewGuid.ToString, "$('#pnlConfirm').dialog('close');", True)
    End Sub

End Class