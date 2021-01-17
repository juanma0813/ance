Public Class Directorio
    Inherits System.Web.UI.Page
    Dim listaDirectorio As New List(Of Entidades.DirectorioRequest)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getDirectorios()
    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                BotonesNuevo()
            Case eBtnFormularios.Cargos
                AddWindow(Me.Page, "Catalogos/DirectorioCargos.aspx", "..:: Cargos ::..", 700, 550, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Niveles
                AddWindow(Me.Page, "Catalogos/NivelCargo.aspx", "..:: Nivel Cargo ::..", 400, 400, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)

        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub


    Private Sub getDirectorios()
        'Dim lst As New List(Of Entidades.DirectorioRequest)
        Dim busqueda As New Entidades.DirectorioRequest

        busqueda.ID_Directorio = "ECCR"
        busqueda.Mail = ""
        busqueda.Password = ""
        busqueda.Bandera = "s1"

        listaDirectorio = Proceso.getDirectorio_Get(busqueda)


        For Each item As Entidades.DirectorioRequest In listaDirectorio
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Nombre
            item_.Value = item.ID_Directorio
            RadDropDownList1.Items.Add(item_)
        Next



    End Sub

    Protected Sub RadDropDownList1_ItemSelected(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs)

        Dim DirSeleccionado = listaDirectorio.Find(Function(dir) dir.ID_Directorio = e.Value)
        TextBox1.Text = DirSeleccionado.Mail
        TextBox2.Text = DirSeleccionado.Empresa
        TextBox3.Text = DirSeleccionado.Domicilio
        TextBox4.Text = DirSeleccionado.Telefono
        TextBox5.Text = DirSeleccionado.Password
        TextBox6.Text = DirSeleccionado.Fax



    End Sub
End Class