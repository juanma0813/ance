Public Class Representacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getRepresentacion()
        End If

    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                BotonesNuevo()
            Case eBtnFormularios.Editar
                'AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
                EditarRepresentacion()
            Case eBtnFormularios.Guardar
                GuardarRepresentacion()
                'MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Eliminar
                EliminarRepresentacion()

        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub


    Private Sub GuardarRepresentacion()
        Dim Representacion = New Entidades.RepresentacionRequest

        Representacion.Descripcion = TextBox2.Text
        Representacion.Comite = If(RadCheckBox1.Checked.Value, "1", "0")
        Representacion.CT = If(RadCheckBox2.Checked.Value, "1", "0")
        Representacion.Bandera = "1"
        Dim respuesta = ProcesoRepresentacion.createRepresentacion(Representacion)


        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If


    End Sub

    Private Sub EditarRepresentacion()

        Dim Representacion = New Entidades.RepresentacionRequest

        Representacion.ID_Representacion = RadDropDownList1.SelectedValue
        Representacion.Descripcion = TextBox2.Text
        Representacion.Comite = If(RadCheckBox1.Checked.Value, "1", "0")
        Representacion.CT = If(RadCheckBox2.Checked.Value, "1", "0")
        Representacion.Bandera = "2"
        Representacion.Inactivo = "0"

        Dim respuesta = ProcesoRepresentacion.updateRepresentacion(Representacion)


        If respuesta Then

            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If



    End Sub


    Private Sub EliminarRepresentacion()
        Dim Representacion = New Entidades.RepresentacionRequest

        Representacion.ID_Representacion = RadDropDownList1.SelectedValue
        Representacion.Descripcion = RadDropDownList1.SelectedText
        Representacion.Bandera = "3"

        Dim respuesta = ProcesoRepresentacion.deleteRepresentacion(Representacion)

        If respuesta Then

            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If

    End Sub


    Private Sub getRepresentacion()
        Dim listaRepresentaciones As New List(Of Entidades.RepresentacionRequest)
        Dim busqueda As New Entidades.RepresentacionRequest

        busqueda.Bandera = "1"

        RadDropDownList1.Items.Clear()
        listaRepresentaciones = ProcesoRepresentacion.getRepresentacion(busqueda)


        For Each item As Entidades.RepresentacionRequest In listaRepresentaciones
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Descripcion
            item_.Value = item.ID_Representacion
            RadDropDownList1.Items.Add(item_)
        Next



    End Sub

    Protected Sub RadDropDownList1_ItemSelected(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs)
        Dim listaRepresentacion As New List(Of Entidades.RepresentacionRequest)
        Dim busqueda As New Entidades.RepresentacionRequest
        busqueda.Bandera = "1"

        listaRepresentacion = ProcesoRepresentacion.getRepresentacion(busqueda)
        Dim RepresentacionSeleccionado = listaRepresentacion.Find(Function(rep) rep.ID_Representacion = e.Value)
        TextBox2.Text = RepresentacionSeleccionado.Descripcion
        RadCheckBox1.Checked = RepresentacionSeleccionado.Comite
        RadCheckBox2.Checked = RepresentacionSeleccionado.CT

    End Sub

End Class