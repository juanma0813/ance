Imports Telerik.Web.UI

Public Class Directorio
    Inherits System.Web.UI.Page
    Dim listaDirectorio As New List(Of Entidades.DirectorioRequest)
    Dim listaComites As New List(Of Entidades.getComites)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getDirectorios()
            getComites()
        Else

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
                EditarDirectorio()
            Case eBtnFormularios.Cargos
                AddWindow(Me.Page, "Catalogos/DirectorioCargos.aspx", "..:: Cargos ::..", 700, 550, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                GuardarDirectorio()
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Niveles
                AddWindow(Me.Page, "Catalogos/NivelCargo.aspx", "..:: Nivel Cargo ::..", 400, 400, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Eliminar
                EliminarDirectorio()

        End Select
    End Sub

    Private Sub BotonesNuevo()

        ' No lo esta haciendo 
        NombreDir.Visible = False
        RadDropDownList1.Enabled = False
        '


        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))

        ' No lo esta haciendo 
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Private Sub GuardarDirectorio()
        Dim Dir = New Entidades.DirectorioRequest

        Dir.Nombre = NombreDir.Text
        Dim sGUID As String = System.Guid.NewGuid.ToString()
        Dir.ID_Directorio = CrearID(12)
        Dir.Empresa = TextBox2.Text
        Dir.Domicilio = TextBox3.Text
        Dir.Telefono = TextBox4.Text
        Dir.Fax = TextBox6.Text
        Dir.Mail = TextBox1.Text
        Dir.Password = TextBox5.Text
        Dir.Bandera = "i1"


        Dim respuesta = ProcesoDirectorio.createDirectorio(Dir)


        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            LimpiarFormulario()
        End If



    End Sub

    Private Sub EditarDirectorio()
        Dim Dir = New Entidades.DirectorioRequest
        Dir.ID_Directorio = RadDropDownList1.SelectedItem.Value
        Dir.Nombre = RadDropDownList1.SelectedItem.Text
        Dir.Empresa = TextBox2.Text
        Dir.Domicilio = TextBox3.Text
        Dir.Telefono = TextBox4.Text
        Dir.Fax = TextBox6.Text
        Dir.Mail = TextBox1.Text
        Dir.Password = TextBox5.Text
        Dir.Bandera = "u1"


        Dim respuesta = ProcesoDirectorio.updateDirectorio(Dir)


        If respuesta Then
            LimpiarFormulario()
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If



    End Sub

    Private Sub EliminarDirectorio()
        Dim Dir = New Entidades.DirectorioRequest
        Dir.ID_Directorio = RadDropDownList1.SelectedItem.Value
        Dir.Nombre = RadDropDownList1.SelectedItem.Text
        Dir.Empresa = TextBox2.Text
        Dir.Domicilio = TextBox3.Text
        Dir.Telefono = TextBox4.Text
        Dir.Fax = TextBox6.Text
        Dir.Mail = TextBox1.Text
        Dir.Password = TextBox5.Text
        Dir.Bandera = "d1"

        Dim respuesta = ProcesoDirectorio.deleteDirectorio(Dir)

        If respuesta Then
            LimpiarFormulario()
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If

    End Sub


    Private Sub getDirectorios()
        Dim busqueda As New Entidades.DirectorioRequest

        busqueda.Mail = ""
        busqueda.Password = ""
        busqueda.Bandera = "s1"

        listaDirectorio = ProcesoDirectorio.getDirectorio(busqueda)


        For Each item As Entidades.DirectorioRequest In listaDirectorio
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Nombre
            item_.Value = item.ID_Directorio
            RadDropDownList1.Items.Add(item_)
        Next

        RadGrid2.MasterTableView.DataSource = listaDirectorio
        RadGrid2.DataBind()



    End Sub

    Private Sub getDirectorio(ByVal Directorio As String)
        Dim listaDirectorio As New List(Of Entidades.DirectorioRequest)
        Dim busqueda As New Entidades.DirectorioRequest
        busqueda.Bandera = "s1"
        listaDirectorio = ProcesoDirectorio.getDirectorio(busqueda)


        Dim DirSeleccionado = listaDirectorio.Find(Function(dir) dir.ID_Directorio = Directorio)
        TextBox1.Text = DirSeleccionado.Mail
        TextBox2.Text = DirSeleccionado.Empresa
        TextBox3.Text = DirSeleccionado.Domicilio
        TextBox4.Text = DirSeleccionado.Telefono
        TextBox5.Text = DirSeleccionado.Password
        TextBox6.Text = DirSeleccionado.Fax
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

    Private Sub getComites()

        Dim lst As New List(Of Entidades.getComites)
        lst = Proceso.getComites_Get("CT 14", "SC 14 A")


        RadDropDownList2.Items.Clear()
        listaComites = Proceso.getComites_Get("CT 14", "SC 14 A")

        For Each item As Entidades.getComites In listaComites
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Descripcion
            item_.Value = item.ID_Comite
            RadDropDownList2.Items.Add(item_)
        Next

    End Sub


    Public Function CrearID(longitud As Integer) As String
        Dim caracteres As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim res As New StringBuilder()
        Dim rnd As New Random()
        While 0 < System.Math.Max(System.Threading.Interlocked.Decrement(longitud), longitud + 1)
            res.Append(caracteres(rnd.[Next](caracteres.Length)))
        End While
        Return res.ToString()
    End Function

    Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs)
        Dim Seleccionado = ""
        If e.CommandName = "RowClick" Then
            Dim strTxt As String = String.Empty

            If TypeOf e.Item Is GridDataItem AndAlso e.Item.Selected Then
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

                For Each col As GridColumn In RadGrid2.MasterTableView.RenderColumns

                    If col.UniqueName = "ID_Directorio" Then
                        Seleccionado = (dataItem(col.UniqueName).Text)
                        getDirectorio(Seleccionado)
                    End If
                Next
            End If
        End If


    End Sub
End Class