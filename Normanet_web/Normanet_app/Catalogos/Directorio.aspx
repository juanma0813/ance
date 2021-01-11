<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mpFormularios.Master" CodeBehind="Directorio.aspx.vb" Inherits="Normanet_app.Directorio" %>
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
                    <telerik:RadTabStrip RenderMode="Lightweight" runat="server" ID="RadTabStrip1"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk">
            <Tabs>
                <telerik:RadTab Text="Directorio" Width="100px" Height="15px"></telerik:RadTab>
                <telerik:RadTab Text="Registros Directorio, Proximos y Vencidos" Width="300px" Height="15px"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1"  SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">
               <table style="width: 100%; height:100px;" class="SinBorde">
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel1" Text="Email" runat="server"></telerik:RadLabel>
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox1" Width="100%" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel2" Text="Nombre" runat="server"></telerik:RadLabel>
                    </th>
                    <td colspan="3">
                        <telerik:RadDropDownList ID="RadDropDownList1"  Width="100%"  runat="server"></telerik:RadDropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel3"  Text="Empresa" runat="server"></telerik:RadLabel>
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox2"  Width="100%" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        <telerik:RadLabel ID="RadLabel7" Text="Clave" runat="server"></telerik:RadLabel>
                    </th>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel4" Text="Domicilio" runat="server"></telerik:RadLabel>
                    </th>
                    <td colspan="3">
                        <asp:TextBox ID="TextBox3" Width="100%" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" Width="100%" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel5" Text="Teéfono" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        <telerik:RadLabel ID="RadLabel6" Text="Password" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td colspan="7">
                        <telerik:RadGrid RenderMode="Classic" Width="100%" Height="300px" ID="RadGrid2" runat="server" AllowPaging="True" AllowSorting="True"
                     AllowFilteringByColumn="True"
                     CellSpacing="0" GridLines="None">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                        <ColumnGroups>
                            <telerik:GridColumnGroup Name="GeneralInformation" HeaderText="Cargo"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="SpecificInformation" HeaderText="Comité"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="CT"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="SC"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="GT"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Sector"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Representación"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Consecutivo"
                                HeaderStyle-HorizontalAlign="Center" />
                        </ColumnGroups>
                        </MasterTableView>
                    </telerik:RadGrid>


                    </td>
                    
                  </tr>
                </table>

                            <!----------------------------------B O T O N E R A--------------------------------------------->
                            <telerik:RadToolBar ID="btnCuentas" Runat="server" Height="32" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
                                <Items>
                                   <telerik:RadToolBarButton Enabled="true" Value="0" ImageUrl="../Imagenes/Botoneras/New.png" Text="Nuevo" ToolTip ="Nuevo"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="2" ImageUrl="../Imagenes/Botoneras/Edit.png" Text="Editar"  ToolTip="Editar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="3" ImageUrl="../Imagenes/Botoneras/redo.png" Text="Deshacer"  ToolTip="Deshacer"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="1" ImageUrl="../Imagenes/Botoneras/save.png" Text="Guardar"  ToolTip="Guardar" ValidationGroup="PersonalInfoGroup"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="9" ImageUrl="../Imagenes/Botoneras/cargos.png" Text="Cargos"  ToolTip="Cargos"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/enabled.png" Text="Activar"  ToolTip="Activar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/Password.png" Text="Password"  ToolTip="Password"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/catalogos.png" Text="Resumen"  ToolTip="Resumen"/>
                                     <telerik:RadToolBarButton Enabled="false" Width="50px"></telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton Enabled="true" Value="7" ImageUrl="../Imagenes/Botoneras/delete_32.png" Text=""  ToolTip="Eliminar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/exit.png" Text=""  ToolTip="Salir"/>
                                </Items>
                            </telerik:RadToolBar>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView2">
                <table style="width: 100%; height:100px;" class="SinBorde">
                  <tr>
                    <td>
                        <telerik:RadLabel ID="RadLabel8" Text="Por Comite" runat="server"></telerik:RadLabel>
                    </td>
                    <th>
                        <telerik:RadCheckBox ID="RadCheckBox1" runat="server" Text=""></telerik:RadCheckBox>
                    </th>
                    <td>
                        <telerik:RadLabel ID="RadLabel9" Text="Comite:" runat="server"></telerik:RadLabel>   
                    </td>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList2" runat="server"></telerik:RadDropDownList>
                    </td>
                    <td></td>
                  </tr>
                  <tr>
                    <td>
                        <telerik:RadLabel ID="RadLabel10" Text="Proximos y Vencidos" runat="server"></telerik:RadLabel>
                    </td>
                    <th>
                        <telerik:RadCheckBox ID="RadCheckBox2" runat="server" Text=""></telerik:RadCheckBox>
                    </th>
                    <td>
                        <asp:RadioButton ID="RadioButton1" Text="Vencidos" runat="server" />
                        
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButton2" Text="Proximos" runat="server" />
                    </td>
                    <td></td>
                  </tr>
                  <tr>
                    <td colspan="5">
                         <telerik:RadGrid RenderMode="Classic" Width="100%" Height="300px" ID="RadGrid1" runat="server" AllowPaging="True" AllowSorting="True"
                     AllowFilteringByColumn="True"
                     CellSpacing="0" GridLines="None">
                    <GroupingSettings CaseSensitive="false" />
                    <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                        <ColumnGroups>
                            <telerik:GridColumnGroup Name="GeneralInformation" HeaderText="Nombre"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="SpecificInformation" HeaderText="Empresa"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Cargo"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Clave"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="password"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Pertenece"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Vigencia Inicio"
                                HeaderStyle-HorizontalAlign="Center" />
                            <telerik:GridColumnGroup Name="BookingInformation" HeaderText="Vigencia Final"
                                HeaderStyle-HorizontalAlign="Center" />
                        </ColumnGroups>
                        </MasterTableView>
                    </telerik:RadGrid>
                    </td>
                  </tr>
                  
                </table>
                
                            <!----------------------------------B O T O N E R A--------------------------------------------->
                    <telerik:RadToolBar ID="RadToolBar1" Runat="server" Height="55" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
                        <Items>
                            <telerik:RadToolBarButton Enabled="true" Value="10" ImageUrl="../Imagenes/Botoneras/buscar.png" ToolTip ="Buscar"/>
                            <telerik:RadToolBarButton Enabled="true" Value="11" ImageUrl="../Imagenes/Botoneras/exportar.png" ToolTip="Exportar"/>

                        </Items>
                    </telerik:RadToolBar>

            </telerik:RadPageView>
            
        </telerik:RadMultiPage>
        </div>

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