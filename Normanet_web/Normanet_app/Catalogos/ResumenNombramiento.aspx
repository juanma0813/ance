﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mpFormularios.Master" CodeBehind="ResumenNombramiento.aspx.vb" Inherits="Normanet_app.ResumenNombramiento" %>
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
                    <th>
                        <telerik:RadLabel ID="RadLabel7" Text="Folio:" runat="server"></telerik:RadLabel>
                    </th>
                    <td style="text-align:left">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
              </tr>
                <tr>
                <th>
                    <telerik:RadLabel ID="RadLabel2" Text="Fecha Real Envío:" runat="server"></telerik:RadLabel>
                </th>
                <td style="text-align:left">
                    <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                </td>
              </tr>
              <tr>
                <th>
                    <telerik:RadLabel ID="RadLabel1" Text="Fecha Vencimiento:" runat="server"></telerik:RadLabel>
                </th>
                <td style="text-align:left">
                    <telerik:RadDatePicker ID="RadDatePicker2" runat="server"></telerik:RadDatePicker>
                </td>
              </tr>
            </table>
        </div>
        <!----------------------------------B O T O N E R A--------------------------------------------->
        <telerik:RadToolBar ID="btnCuentas" Runat="server" Height="32" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
            <Items>
               <telerik:RadToolBarButton Enabled="true" Value="0" ImageUrl="../Imagenes/Botoneras/New.png" ToolTip ="Nuevo"/>
                <telerik:RadToolBarButton Enabled="true" Value="2" ImageUrl="../Imagenes/Botoneras/Edit.png" ToolTip="Editar"/>
                <telerik:RadToolBarButton Enabled="true" Value="3" ImageUrl="../Imagenes/Botoneras/redo.png" ToolTip="Deshacer"/>
                <telerik:RadToolBarButton Enabled="true" Value="1" ImageUrl="../Imagenes/Botoneras/save.png" ToolTip="Guardar" ValidationGroup="PersonalInfoGroup"/>
                <telerik:RadToolBarButton Enabled="true" Value="5" ImageUrl="../Imagenes/Botoneras/level.png" ToolTip="Niveles"/>
                <telerik:RadToolBarButton Enabled="false" Width="50px"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/exit.png" ToolTip="Salir"/>
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
                    <asp:ImageButton ID="cmdAceptar" runat="server" ImageUrl="../Imagenes/Formularios/Check.png" ToolTip="Aceptar" />
                    <asp:ImageButton ID="cmdCancelar" runat="server" ImageUrl="../Imagenes/Formularios/Cancel.png" ToolTip="Cancelar" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>  


</asp:Content>