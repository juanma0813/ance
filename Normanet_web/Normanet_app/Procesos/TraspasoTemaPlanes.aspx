<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mpFormularios.Master" CodeBehind="TraspasoTemaPlanes.aspx.vb" Inherits="Normanet_app.TraspasoTemaPlanes" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="cphJs" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphCss" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAreaTrabajo" runat="server">
    <telerik:RadAjaxLoadingPanel ID="ralLoad" runat="server" SkinID="SkinManager"></telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="ramManajer" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnCuentas">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnCuentas" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <telerik:RadAjaxPanel ID="rapContenedor" runat="server" Width="100%" LoadingPanelID="ralLoad">


        <!-- ------------------------------C O N T E N I D O------------------------------------------->
        <br />
        <div>
            <table style="width: 100%; height:100px;" class="SinBorde">
                  <tr>
                    <td rowspan="12">
                        <asp:TextBox ID="TextBox6" runat="server" Width="98%" placeholder="Buscar..." ></asp:TextBox>
                         <telerik:RadTreeView RenderMode="Classic" ID="RadTreeView1" runat="server"  Width="100%" Height="100%">
                            <Nodes>
                                <telerik:RadTreeNode runat="server" Text="Zanzibar" AllowDrag="false">
                                    <Nodes>
                                        <telerik:RadTreeNode runat="server" Text="Weekend Package" AllowDrop="false" Value="1999">
                                        </telerik:RadTreeNode>
                                        <telerik:RadTreeNode runat="server" Text="1 Week Package" AllowDrop="false" Value="2999">
                                        </telerik:RadTreeNode>
                                        <telerik:RadTreeNode runat="server" Text="2 Week Package" AllowDrop="false" Value="3999">
                                        </telerik:RadTreeNode>
                                    </Nodes>
                                </telerik:RadTreeNode>
                            </Nodes>
                        </telerik:RadTreeView>
                    </td>
                    <th colspan="2">
                        <telerik:RadLabel ID="RadLabel1" Text="Plan Origen" runat="server"></telerik:RadLabel>
                    </th>
                    <td rowspan="12">
                        <asp:TextBox ID="TextBox1" runat="server" Width="98%" placeholder="Buscar..." ></asp:TextBox>
                         <telerik:RadTreeView RenderMode="Classic" ID="RadTreeView2" runat="server"  Width="100%" Height="100%">
                            <Nodes>
                                <telerik:RadTreeNode runat="server" Text="Zanzibar" AllowDrag="false">
                                    <Nodes>
                                        <telerik:RadTreeNode runat="server" Text="Weekend Package" AllowDrop="false" Value="1999">
                                        </telerik:RadTreeNode>
                                        <telerik:RadTreeNode runat="server" Text="1 Week Package" AllowDrop="false" Value="2999">
                                        </telerik:RadTreeNode>
                                        <telerik:RadTreeNode runat="server" Text="2 Week Package" AllowDrop="false" Value="3999">
                                        </telerik:RadTreeNode>
                                    </Nodes>
                                </telerik:RadTreeNode>
                            </Nodes>
                        </telerik:RadTreeView>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel3" Text="Clasificación:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox1" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel4" Text="Número de Tema:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox2" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel5" Text="Tipo de Tema:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox3" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel6" Text="Fecha de Inicio:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox4" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel7" Text="Fecha de Fin:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox5" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th colspan="2">
                        <telerik:RadLabel ID="RadLabel2" Text="Plan Destino" runat="server"></telerik:RadLabel>
                    </th>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel8" Text="PNN Destino:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox6" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel9" Text="Número de Tema:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox7" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                   <th>
                        <telerik:RadLabel ID="RadLabel10" Text="Tipo de Tema:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList1" runat="server"></telerik:RadDropDownList>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel11" Text="Fecha de Inicio:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel12" Text="Fecha de Fin:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker2" runat="server"></telerik:RadDatePicker>
                    </td>
                  </tr>
                </table>
        </div>
        <br />
        <!----------------------------------B O T O N E R A--------------------------------------------->
        <telerik:RadToolBar ID="btnCuentas" Runat="server" Height="32" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
            <Items>
                <telerik:RadToolBarButton Enabled="true" Value="12" ImageUrl="../Imagenes/Botoneras/traspaso.png" Text="Traspasar" ToolTip ="Traspasar"/>
                <telerik:RadToolBarButton Enabled="true" Value="3" ImageUrl="../Imagenes/Botoneras/redo.png" Text="Deshacer" ToolTip="Deshacer"/>
                <telerik:RadToolBarButton Enabled="true" Value="1" ImageUrl="../Imagenes/Botoneras/save.png" Text="Guardar" ToolTip="Guardar" ValidationGroup="PersonalInfoGroup"/>
                <telerik:RadToolBarButton Enabled="false" Width="50px"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton Enabled="true" Value="6" ImageUrl="../Imagenes/Botoneras/inhabilitar.png" Text="Inhactivar" ToolTip="Inhactivar"/>
                <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/exit.png" Text="Salir" ToolTip="Salir"/>
                
                
            </Items>
        </telerik:RadToolBar>
        <!-- ------------------------------------F I N------------------------------------------------->
        <telerik:RadCodeBlock ID="block" runat="server">
             <script type="text/javascript">
                 function clientButtonClicking(sender, args) {
                     var toolBar = sender;
                     var button = args.get_item();

                     if (typeof (Page_ClientValidate) == 'function') { Page_ClientValidate(); }

                     switch (button.get_value()) {
                         case "1":
                             if (!Page_IsValid) {
                                 CallClientShow();
                             }
                             break;
                     }
                 }

                 function CallClientShow() {
                     var notification = $find("<%=notCampos.ClientID%>");
                    notification.show();
                 }
             </script>
        </telerik:RadCodeBlock>
        <div id="Validadores">
        <%--      <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" ErrorMessage="Nombre" Display="None" ValidationGroup="PersonalInfoGroup" />
          <asp:RequiredFieldValidator runat="server" ID="rfvEmpresa" ControlToValidate="txtEmpresa" ErrorMessage="Empresa" Display="None" ValidationGroup="PersonalInfoGroup" />
            <asp:RequiredFieldValidator runat="server" ID="rfvCorreo" ControlToValidate="txtCorreo" ErrorMessage="Correo" Display="None" ValidationGroup="PersonalInfoGroup" />--%>
        </div>
        <telerik:RadNotification ID="notCampos" runat="server" Animation="Fade" ContentIcon="warning" EnableRoundedCorners="True" EnableShadow="True" Position="Center" SkinID="SkinManager" Title="Problemas con campos" TitleIcon="warning" Width="261px" AutoCloseDelay="6000">
            <ContentTemplate>
                <asp:ValidationSummary ID="vsCampos" runat="server" DisplayMode="BulletList" Font-Bold="true" ForeColor="#0066FF" HeaderText="<div style='text-align:center;'>El o los siguientes campo(s) son requeridos</div>" ValidationGroup="PersonalInfoGroup" />
            </ContentTemplate>
        </telerik:RadNotification>
        <br />
    </telerik:RadAjaxPanel>

    <div id="pnlConfirm" class="pnlConfirm" style="display: none;">
        <div class='wnContenedor' style="text-align: center;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblMensaje" runat="server" Text="" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:ImageButton ID="cmdAceptar" runat="server" ImageUrl="~/Imagenes/Formularios/Check.png" ToolTip="Aceptar" />
                    <asp:ImageButton ID="cmdCancelar" runat="server" ImageUrl="~/Imagenes/Formularios/Cancel.png" ToolTip="Cancelar" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>  

</asp:Content>

