Public Class Cargos
    Inherits System.Web.UI.Page
    'Dim listaCargos As New List(Of Entidades.CargosRequest)
    'Dim listaDependencia As New List(Of Entidades.CargosRequest)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getCargos()
    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                BotonesNuevo()
            Case eBtnFormularios.Editar
                EditarCargo("2")
                'AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                GuardarCargo()
                'MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Niveles
                AddWindow(Me.Page, "Catalogos/NivelCargo.aspx", "..:: Nivel Cargo ::..", 400, 600, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Activar
                EditarCargo("3")



        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub

    Private Sub BotonesEditar()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub


    Private Sub GuardarCargo()
        Dim Cargo = New Entidades.CargosRequest

        Cargo.Descripcion = TextBox2.Text
        Cargo.Comite = If(RadCheckBox1.Checked.Value, "1", "0")
        Cargo.CT = If(RadCheckBox2.Checked.Value, "1", "0")
        Cargo.SC = If(RadCheckBox3.Checked.Value, "1", "0")
        Cargo.GT = If(RadCheckBox3.Checked.Value, "1", "0")

        Cargo.Dependencia = RadDropDownList2.SelectedItem.Value
        Cargo.Bandera = "1"
        Cargo.xml = ""
        Cargo.Inactivo = If(RadCheckBox4.Checked, "1", "0")

        Dim respuesta = ProcesoCargos.createCargo(Cargo)

        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            'LimpiarFormulario()
        End If

    End Sub

    Private Sub EditarCargo(opc As String)
        Dim Cargo = New Entidades.CargosRequest

        Cargo.ID_Cargo = RadDropDownList1.SelectedValue
        Cargo.Descripcion = TextBox2.Text
        Cargo.Comite = If(RadCheckBox1.Checked.Value, "1", "0")
        Cargo.CT = If(RadCheckBox2.Checked.Value, "1", "0")
        Cargo.SC = If(RadCheckBox3.Checked.Value, "1", "0")
        Cargo.GT = If(RadCheckBox3.Checked.Value, "1", "0")

        Cargo.Dependencia = RadDropDownList2.SelectedValue
        Cargo.Bandera = opc
        Cargo.xml = ""
        Cargo.Inactivo = If(RadCheckBox4.Checked, "1", "0")


        Dim respuesta = ProcesoCargos.updateCargo(Cargo)

        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            'LimpiarFormulario()
        End If
    End Sub
    Private Sub EliminarCargo()
        Dim Cargo = New Entidades.CargosRequest

        Cargo.ID_Cargo = RadDropDownList1.SelectedValue
        Cargo.Descripcion = TextBox2.Text
        Cargo.Comite = If(RadCheckBox1.Checked.Value, "1", "0")
        Cargo.CT = If(RadCheckBox2.Checked.Value, "1", "0")
        Cargo.SC = If(RadCheckBox3.Checked.Value, "1", "0")
        Cargo.GT = If(RadCheckBox3.Checked.Value, "1", "0")

        Cargo.Dependencia = RadDropDownList2.SelectedValue
        Cargo.Bandera = "3"
        Cargo.xml = ""
        Cargo.Inactivo = If(RadCheckBox4.Checked, "1", "0")



        Dim respuesta = ProcesoCargos.createCargo(Cargo)

        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            'LimpiarFormulario()
        End If
    End Sub


    Private Sub getCargos()
        Dim busqueda As New Entidades.CargosRequest
        Dim listaCargos As New List(Of Entidades.CargosRequest)
        busqueda.Bandera = "2"

        RadDropDownList1.Items.Clear()
        RadDropDownList2.Items.Clear()

        listaCargos = ProcesoCargos.getCargo(busqueda)

        For Each item As Entidades.CargosRequest In listaCargos
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Descripcion
            item_.Value = item.ID_Cargo
            RadDropDownList1.Items.Add(item_)

            Dim item_2 As New Telerik.Web.UI.DropDownListItem()
            item_2.Text = item.Descripcion
            item_2.Value = item.ID_Cargo
            RadDropDownList2.Items.Add(item_2)
        Next

    End Sub

    Protected Sub RadDropDownList1_ItemSelected(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs)
        Dim listaCargos As New List(Of Entidades.CargosRequest)
        Dim busqueda As New Entidades.CargosRequest
        busqueda.Bandera = "2"

        listaCargos = ProcesoCargos.getCargo(busqueda)
        Dim CargoSeleccionado = listaCargos.Find(Function(cargo) cargo.ID_Cargo = e.Value)
        TextBox2.Text = CargoSeleccionado.Descripcion
        RadCheckBox1.Checked = CargoSeleccionado.Comite
        RadCheckBox2.Checked = CargoSeleccionado.CT
        RadCheckBox3.Checked = CargoSeleccionado.SC
        RadCheckBox4.Checked = CargoSeleccionado.Inactivo
        RadDropDownList2.SelectedValue = CargoSeleccionado.Dependencia
    End Sub
End Class