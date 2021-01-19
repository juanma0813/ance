Public Class Sectores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            getSector()
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
                EditarSector()
            Case eBtnFormularios.Guardar
                GuardarSector()
                'MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
            Case eBtnFormularios.Deshacer
                lblMensaje.Text = "�Estas seguro de eliminar los datos?"
                MsgJqueryConfirm(Me.Page, "pnlConfirm", "..:: Demo ::..", UpdatePanel3.ClientID)
            Case eBtnFormularios.Desactivar
                EliminarSector()

        End Select
    End Sub

    Private Sub BotonesNuevo()
        Activar(btnCuentas.Items(eBtnFormularios.Guardar), btnCuentas.Items(eBtnFormularios.Deshacer))
        inactivar(btnCuentas.Items(eBtnFormularios.Nuevo), btnCuentas.Items(eBtnFormularios.Editar))
    End Sub

    Private Sub GuardarSector()
        Dim Sector = New Entidades.SectoresRequest

        Sector.Descripcion = TextBox2.Text
        Sector.Bandera = "1"
        Dim respuesta = ProcesoSectores.createSector(Sector)


        If respuesta Then
            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If


    End Sub

    Private Sub EditarSector()

        Dim Sector = New Entidades.SectoresRequest

        Sector.ID_Sector = RadDropDownList1.SelectedValue
        Sector.Descripcion = TextBox2.Text
        Sector.Inactivo = "0"
        Sector.Bandera = 2

        Dim respuesta = ProcesoSectores.updateSector(Sector)


        If respuesta Then

            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If

    End Sub



    Private Sub EliminarSector()
        Dim Sector = New Entidades.SectoresRequest

        Sector.ID_Sector = RadDropDownList1.SelectedValue
        Sector.Descripcion = RadDropDownList1.SelectedText
        Sector.Bandera = 3

        Dim respuesta = ProcesoSectores.deleteSector(Sector)

        If respuesta Then

            MsgJquery(UpdatePanel2, "Accion guardada correctamente", "..:: Borrame ::..")
        End If

    End Sub


    Private Sub getSector()
        Dim listaSectores As New List(Of Entidades.SectoresRequest)
        Dim busqueda As New Entidades.SectoresRequest

        busqueda.Bandera = "1"

        RadDropDownList1.Items.Clear()
        listaSectores = ProcesoSectores.getSector(busqueda)


        For Each item As Entidades.SectoresRequest In listaSectores
            Dim item_ As New Telerik.Web.UI.DropDownListItem()
            item_.Text = item.Descripcion
            item_.Value = item.ID_Sector
            RadDropDownList1.Items.Add(item_)
        Next

    End Sub

    Protected Sub RadDropDownList1_ItemSelected(sender As Object, e As Telerik.Web.UI.DropDownListEventArgs)
        Dim listaSectores As New List(Of Entidades.SectoresRequest)
        Dim busqueda As New Entidades.SectoresRequest
        busqueda.Bandera = "1"

        listaSectores = ProcesoSectores.getSector(busqueda)
        Dim SectorSeleccionado = listaSectores.Find(Function(sector) sector.ID_Sector = e.Value)
        TextBox2.Text = SectorSeleccionado.Descripcion

    End Sub

End Class