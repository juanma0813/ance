Imports System.Reflection
Imports Telerik.Web.UI

Public Class Nombramientos
    Inherits System.Web.UI.Page

    Dim listaNombramiento As New List(Of Entidades.NombramientoTabla)
    Dim listaRemitentes As New List(Of Entidades.RemitentesRequest)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            getNombramientos()
            getRemitentes()
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
                EditarNombramiento()
                'AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                GuardarNombramiento()
                'MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Niveles
                AddWindow(Me.Page, "Catalogos/NivelCargo.aspx", "..:: Nivel Cargo ::..", 400, 400, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Eliminar
                EliminarNombramiento()


        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub


    Private Sub GuardarNombramiento()
        Dim Nombramiento = New Entidades.NombramientoRequest

        Nombramiento.Folio = TextBox1.Text
        Nombramiento.FechaIngreso = RadDatePicker1.SelectedDate
        Nombramiento.IdRemitente = RadDropDownList1.SelectedValue
        Nombramiento.Nombramiento = TextBox2.Text
        Nombramiento.FechaRespuestaMaxima = RadDatePicker2.SelectedDate.Value
        Nombramiento.FechaRespuestaVencimiento = RadDatePicker3.SelectedDate.Value
        Nombramiento.RequiereRespuesta = If(RadCheckBox1.Checked.Value, "1", "0")
        Nombramiento.FechaRespuestaReal = RadDatePicker4.SelectedDate.Value
        Nombramiento.Activo = "1"
        Nombramiento.Bandera = "i1"


        Dim respuesta = ProcesoNombramiento.createNombramiento(Nombramiento)


        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")

        End If



    End Sub

    Private Sub EditarNombramiento()
        Dim Nombramiento = New Entidades.NombramientoRequest
        Nombramiento.IdNombramiento = TextBox3.Text
        Nombramiento.Folio = TextBox1.Text
        Nombramiento.FechaIngreso = RadDatePicker1.SelectedDate
        Nombramiento.IdRemitente = RadDropDownList1.SelectedValue
        Nombramiento.Nombramiento = TextBox2.Text
        Nombramiento.FechaRespuestaMaxima = RadDatePicker2.SelectedDate
        Nombramiento.FechaRespuestaVencimiento = RadDatePicker3.SelectedDate
        Nombramiento.RequiereRespuesta = If(RadCheckBox1.Checked.Value, "1", "0")
        Nombramiento.FechaRespuestaReal = RadDatePicker4.SelectedDate
        Nombramiento.Activo = "1"
        Nombramiento.Bandera = "u2"


        Dim respuesta = ProcesoNombramiento.updateNombramiento(Nombramiento)


        If respuesta Then

            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If



    End Sub

    Private Sub EliminarNombramiento()
        Dim Nombramiento = New Entidades.NombramientoRequest

        Nombramiento.IdNombramiento = TextBox3.Text
        Nombramiento.Folio = TextBox1.Text
        Nombramiento.FechaIngreso = RadDatePicker1.SelectedDate
        Nombramiento.IdRemitente = RadDropDownList1.SelectedValue
        Nombramiento.Nombramiento = TextBox2.Text
        Nombramiento.FechaRespuestaMaxima = RadDatePicker2.SelectedDate
        Nombramiento.FechaRespuestaVencimiento = RadDatePicker3.SelectedDate
        Nombramiento.RequiereRespuesta = If(RadCheckBox1.Checked.Value, "1", "0")
        Nombramiento.FechaRespuestaReal = RadDatePicker4.SelectedDate
        Nombramiento.Activo = "0"
        Nombramiento.Bandera = "u4"

        Dim respuesta = ProcesoNombramiento.deleteNombramiento(Nombramiento)

        If respuesta Then

            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If

    End Sub

    Private Sub getNombramiento(ByVal IdNombramiento As String)
        Dim busqueda As New Entidades.NombramientoRequest
        Dim Nombramiento As New List(Of Entidades.NombramientoRequest)
        busqueda.IdNombramiento = IdNombramiento
        busqueda.Bandera = "s1"
        Nombramiento = ProcesoNombramiento.getNombramiento(busqueda)
        TextBox3.Text = Nombramiento(0).IdNombramiento
        TextBox1.Text = Nombramiento(0).Folio
        If Nombramiento(0).FechaIngreso IsNot Nothing Then
            RadDatePicker1.SelectedDate = CType(Nombramiento(0).FechaIngreso, Date)
        End If

        If Nombramiento(0).FechaRespuestaMaxima IsNot Nothing Then
            RadDatePicker2.SelectedDate = CType(Nombramiento(0).FechaRespuestaMaxima, Date)
        End If

        If Nombramiento(0).FechaRespuestaVencimiento IsNot Nothing Then
            RadDatePicker3.SelectedDate = CType(Nombramiento(0).FechaRespuestaVencimiento, Date)
        End If

        If Nombramiento(0).IdRemitente IsNot Nothing Then
            RadDropDownList1.SelectedValue = Nombramiento(0).IdRemitente
        End If

        TextBox2.Text = Nombramiento(0).Nombramiento


        RadCheckBox1.Checked = Nombramiento(0).RequiereRespuesta


        If Nombramiento(0).IdRemitente IsNot Nothing Then
            RadDatePicker4.SelectedDate = Nombramiento(0).FechaRespuestaReal
        End If

    End Sub

    Private Sub getNombramientos()
        Dim busqueda As New Entidades.NombramientoRequest
        busqueda.Bandera = "s2"
        listaNombramiento = ProcesoNombramiento.getNombramientos(busqueda)

        RadGrid2.MasterTableView.DataSource = listaNombramiento
        RadGrid2.DataBind()

    End Sub

    Private Sub getRemitentes()
        Dim busqueda As New Entidades.RemitentesRequest
        busqueda.Bandera = "s3"
        listaRemitentes = ProcesoRemitentes.getRemitente(busqueda)

        For Each item As Entidades.RemitentesRequest In listaRemitentes
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Nombre
            item_.Value = item.IdRemitente
            RadDropDownList1.Items.Add(item_)
        Next

    End Sub



    Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs)
        Dim Seleccionado = ""
        If e.CommandName = "RowClick" Then
            Dim strTxt As String = String.Empty

            If TypeOf e.Item Is GridDataItem AndAlso e.Item.Selected Then
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

                For Each col As GridColumn In RadGrid2.MasterTableView.RenderColumns

                    If col.UniqueName = "IdNombramiento" Then
                        Seleccionado = (dataItem(col.UniqueName).Text)
                        getNombramiento(Seleccionado)
                    End If
                Next



            End If
        End If

        
    End Sub
End Class