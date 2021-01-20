Imports System.Drawing
Imports Newtonsoft.Json
Imports Telerik.Web.UI

Public Class Comite
    Inherits System.Web.UI.Page
    Public Property Cont As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (DropDownList1.Items.Count <= 0) Then
            AddNodes()
        End If

    End Sub

    Protected Sub btnCuentas_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles btnCuentas.ButtonClick
        Menu(e.Item.Value)
    End Sub

    Private Sub Menu(btnValue As Integer)
        Select Case btnValue
            Case eBtnFormularios.Nuevo
                inactivar(btnCuentas.Items(eBtnFormularios.Deshacer), btnCuentas.Items(eBtnFormularios.Editar))



            Case eBtnFormularios.Editar
                AddWindow(Me.Page, "Test.aspx", "..:: Test ::.. - DemoMenuBaseMultiVentanas", 700, 550, False)
                ScriptManager.RegisterStartupScript(Me.Page, Page.GetType, Guid.NewGuid.ToString, "", True)
            Case eBtnFormularios.Guardar

                inactivar(btnCuentas.Items(eBtnFormularios.Deshacer), btnCuentas.Items(eBtnFormularios.Editar))
                Dim Param As Entidades.addComite_post_put_Parameter = New Entidades.addComite_post_put_Parameter
                Param.Comite = txtNombre.Text
                Param.Bandera = "4"
                Param.CT = txtcomitecnico.Text
                Param.Descripcion = txtdescripcion.Text
                Param.GT = txtgrupo.Text
                If (RadCheckBox1.Checked) Then
                    Param.Inactivo = 1
                Else
                    Param.Inactivo = 0
                End If

                Param.Objetivo = txtobjetivo.Text
                Param.Responsable = DropDownList1.SelectedValue
                Param.SC = txtsubcomite.Text
                Proceso.POSTComiteDetalle(Param)
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



    Private Sub AddNodes()

        If (RadTreeView1.Nodes.Count <= 0) Then

            Dim lst As New List(Of Entidades.getComites)
            lst = Proceso.getComites_Get()


            For Each item As Entidades.getComites In lst
                Dim Node1 As New RadTreeNode(item.ID_Comite)
                Node1.Text = item.ID_Comite & " - " & item.ID_CT
                Node1.Value = JsonConvert.SerializeObject(item)
                RadTreeView1.Nodes.Add(Node1)
            Next

        End If





        Cont += 1
    End Sub

    Protected Sub RadTreeView1_NodeClick(sender As Object, e As RadTreeNodeEventArgs)
        Dim comite As New Entidades.getComites
        Dim comiteParameter As New Entidades.GetDeleteComitesDescripcion_Parameter
        Dim comiteDetalle As New List(Of Entidades.getComitesDescripcion)
        Dim empleados As New List(Of Entidades.Empleados)


        comite = JsonConvert.DeserializeObject(Of Entidades.getComites)(RadTreeView1.SelectedNode.Value)
        comiteParameter.Bandera = "4"
        comiteParameter.Comite = comite.ID_Comite
        comiteParameter.CT = comite.ID_CT
        comiteParameter.GT = comite.ID_Grupo
        comiteParameter.SC = comite.ID_SC
        comiteDetalle = Proceso.getComiteDetalle(comiteParameter)

        txtNombre.Text = comiteDetalle.First().ID_Comite
        txtcomitecnico.Text = comiteDetalle.First().ID_CT
        txtsubcomite.Text = comiteDetalle.First().ID_SC
        txtgrupo.Text = comiteDetalle.First().ID_Grupo
        txtdescripcion.Text = comiteDetalle.First().Descripcion
        txtobjetivo.Text = comiteDetalle.First().Objetivo
        RadCheckBox1.Checked = comiteDetalle.First().Inactivo

        Dim Emp_ As Entidades.EmpleadoRequest
        Emp_ = New Entidades.EmpleadoRequest

        Emp_.Bandera = "1"
        Emp_.ID_Usuario = ""
        Emp_.ID_Area = ""
        Emp_.Id_Sistema = ""



        empleados = Proceso.getEmpleado(Emp_)

        Dim tmp As ListItem
        tmp = New ListItem

        tmp.Value = ""
        tmp.Text = "Seleccione ..."

        DropDownList1.Items.Add(tmp)

        For Each item As Entidades.Empleados In empleados
            Dim ItemList As ListItem
            ItemList = New ListItem

            ItemList.Value = item.IdUsuario
            ItemList.Text = item.Nombre
            DropDownList1.Items.Add(ItemList)
        Next

        Dim contador As String
        contador = empleados.Where(Function(x) x.IdUsuario = comiteDetalle.First().Responsable).Select(Function(y) y.IdUsuario).First
        DropDownList1.SelectedValue = contador

    End Sub

    Protected Sub TextBox6_TextChanged(sender As Object, e As EventArgs)
        Dim lst As New List(Of Entidades.getComites)
        lst = Proceso.getComites_Get()
        If (TextBox6.Text <> "") Then
            lst = lst.Where(Function(x) x.ID_Comite.Contains(TextBox6.Text.ToUpper()) Or x.ID_CT.Contains(TextBox6.Text.ToUpper())).ToList()


        End If

        RadTreeView1.Nodes.Clear()

        For Each item As Entidades.getComites In lst
            Dim Node1 As New RadTreeNode(item.ID_Comite)
            Node1.Text = item.ID_Comite & " - " & item.ID_CT
            Node1.Value = JsonConvert.SerializeObject(item)
            RadTreeView1.Nodes.Add(Node1)
        Next
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim lst As New List(Of Entidades.getComites)
        lst = Proceso.getComites_Get()
        If (TextBox6.Text <> "") Then
            lst = lst.Where(Function(x) x.ID_Comite.Contains(TextBox6.Text.ToUpper()) Or x.ID_CT.Contains(TextBox6.Text.ToUpper())).ToList()


        End If

        RadTreeView1.Nodes.Clear()

        For Each item As Entidades.getComites In lst
            Dim Node1 As New RadTreeNode(item.ID_Comite)
            Node1.Text = item.ID_Comite & " - " & item.ID_CT
            Node1.Value = JsonConvert.SerializeObject(item)
            RadTreeView1.Nodes.Add(Node1)
        Next
    End Sub


End Class