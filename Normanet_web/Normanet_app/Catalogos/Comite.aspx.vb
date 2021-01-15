Public Class Comite
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                BotonesNuevo()
            Case eBtnFormularios.Editar
                AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar
                MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)


        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub

    Private Sub AddComite()
        Dim comunicaciones As New Normanet_Comunicaciones.Comites.Comites
        Dim addComite_post_put_Parameter As New Normanet_Entidades.Comites.addComite_post_put_Parameter

        addComite_post_put_Parameter.Bandera = RadCheckBox1.Value
        addComite_post_put_Parameter.Comite = txtNombre.Text
        addComite_post_put_Parameter.Descripcion = TextBox4.Text
        addComite_post_put_Parameter.Responsable = DropDownList1.Text
        addComite_post_put_Parameter.Inactivo = ""
        addComite_post_put_Parameter.Objetivo = ""
        addComite_post_put_Parameter.CT = TextBox1.Text
        addComite_post_put_Parameter.SC = TextBox2.Text
        addComite_post_put_Parameter.GT = TextBox3.Text
        addComite_post_put_Parameter.Comite = TextBox1.Text

        Dim addComite = comunicaciones.addComite_post(addComite_post_put_Parameter)
        Dim resultado = addComite

    End Sub
End Class