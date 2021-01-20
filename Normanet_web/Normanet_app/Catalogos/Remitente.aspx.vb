Imports System.Reflection
Imports Telerik.Web.UI
Public Class Remitente
    Inherits System.Web.UI.Page
    Dim listaRemitentes As New List(Of Entidades.RemitentesRequest)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'getRemitentes()
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
                updateRemitente()
                'AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                addRemitente()
                'MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Resumen
                'AddWindow(Me.Page, "Catalogos/ResumenNombramiento.aspx", "..:: Resumen Nombramiento ::..", 700, 250, False
                '          )
                'ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Eliminar
                deleteRemitente()
            Case eBtnFormularios.Salir
                SalirPagina()

        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub
    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim entidad As New Entidades.RemitentesRequest
        entidad.Bandera = "s3"
        listaRemitentes = ProcesoRemitentes.getRemitente(entidad)

        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("IdRemitente")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("Empresa")
        dt.Columns.Add("Puesto")
        dt.Columns.Add("Email")
        dt.Columns.Add("Email alterno")
        For Each item As Entidades.RemitentesRequest In listaRemitentes
            dt.Rows.Add(item.IdRemitente, item.Nombre, item.Empresa, item.Puesto, item.Email, item.EmailAlterno)
        Next

        RadGrid1.DataSource = dt
    End Sub
    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs)
        Dim Seleccionado = ""
        If e.CommandName = "RowClick" Then
            Dim strTxt As String = String.Empty

            If TypeOf e.Item Is GridDataItem AndAlso e.Item.Selected Then
                Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

                For Each col As GridColumn In RadGrid1.MasterTableView.RenderColumns

                    If col.UniqueName = "IdRemitente" Then
                        Seleccionado = (dataItem(col.UniqueName).Text)
                        getRemitente(Seleccionado)
                    End If
                Next



            End If
        End If

    End Sub

    Private Sub getRemitente(ByVal IdRemitente As String)
        Dim entidad As New Entidades.RemitentesRequest
        Dim Remitente As New List(Of Entidades.RemitentesRequest)
        entidad.IdRemitente = IdRemitente
        entidad.Bandera = "s1"
        Remitente = ProcesoRemitentes.getRemitente(entidad)
        TextBox1.Text = Remitente(0).Nombre
        TextBox2.Text = Remitente(0).Empresa
        TextBox3.Text = Remitente(0).Puesto
        TextBox4.Text = Remitente(0).Email
        TextBox5.Text = Remitente(0).EmailAlterno
        TextBox6.Text = Remitente(0).IdRemitente
    End Sub

    Private Sub addRemitente()
        Dim entidad As New Entidades.RemitentesRequest
        Dim respuesta As Boolean
        entidad.Bandera = "i1"
        entidad.Nombre = TextBox1.Text
        entidad.Empresa = TextBox2.Text
        entidad.Puesto = TextBox3.Text
        entidad.Email = TextBox4.Text
        entidad.EmailAlterno = TextBox5.Text
        entidad.FechaAlta = Date.Now.ToString
        entidad.Activo = "1"


        respuesta = ProcesoRemitentes.createRemitente(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias de Revisión Editorial ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al guardar", "..:: Categorias de Revisión Editorial ::..")
        End If
    End Sub
    Private Sub updateRemitente()
        Dim entidad As New Entidades.RemitentesRequest
        Dim respuesta As Boolean
        entidad.Bandera = "u2"
        entidad.IdRemitente = TextBox6.Text
        entidad.Nombre = TextBox1.Text
        entidad.Empresa = TextBox2.Text
        entidad.Puesto = TextBox3.Text
        entidad.Email = TextBox4.Text
        entidad.EmailAlterno = TextBox5.Text
        entidad.FechaAlta = Date.Now

        respuesta = ProcesoRemitentes.updateRemitente(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias de Revisión Editorial ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al actualizar", "..:: Categorias de Revisión Editorial ::..")
        End If
    End Sub
    Private Sub deleteRemitente()
        Dim entidad As New Entidades.RemitentesRequest
        Dim respuesta As Boolean
        entidad.Bandera = "d1"
        entidad.IdRemitente = TextBox6.Text
        entidad.Nombre = TextBox1.Text
        entidad.Empresa = TextBox2.Text
        entidad.Puesto = TextBox3.Text
        entidad.Email = TextBox4.Text
        entidad.EmailAlterno = TextBox5.Text

        respuesta = ProcesoRemitentes.deleteRemitente(entidad)
        If (respuesta = True) Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Categorias de Revisión Editorial ::..")
        Else
            MsgJquery(UpdatePanel2, "Error al eliminar", "..:: Categorias de Revisión Editorial ::..")
        End If
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