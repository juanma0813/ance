<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mpFormularios.Master" CodeBehind="PnnTemas.aspx.vb" Inherits="Normanet_app.PnnTemas" %>
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
        
        <div>
       <telerik:RadTabStrip Font-Size="Small" RenderMode="Lightweight" runat="server" ID="RadTabStrip1"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="Silk">
            <Tabs>
                <telerik:RadTab  Text="Programa de Trabajo" Width="100px" Height="10px" ></telerik:RadTab>
                <telerik:RadTab Text="Documento de Trabajo" Width="100px" Height="10px"></telerik:RadTab>
                <telerik:RadTab Text="Anteproyecto" Width="100px" Height="10px" ></telerik:RadTab>
                <telerik:RadTab Text="Proyecto" Width="100px" Height="10px" ></telerik:RadTab>
                <telerik:RadTab Text="Historial PNN" Width="100px" Height="10px" ></telerik:RadTab>
                <telerik:RadTab Text="Avance" Width="100px" Height="10px"></telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1"  SelectedIndex="0" CssClass="outerMultiPage">
            <telerik:RadPageView runat="server" ID="RadPageView1">
               <table style="width: 100%; height:100px;" class="SinBorde">
                  <tr>
                    <td rowspan="18" style="width:200px; height:100%">
                  <telerik:RadGrid RenderMode="Classic" Width="100%" Height="100%" ID="RadGrid2" runat="server" AllowPaging="True" AllowSorting="True"
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
                    <th>
                        <telerik:RadLabel ID="RadLabel1" Text="Referencia:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox1" Width="100%" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel2" Text="Clasificación:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox2" Width="100%" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel3" Text="Numero Tema:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox3" Width="100%" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel4" Text="Tipo de Tema:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList1"  Width="100%" runat="server"></telerik:RadDropDownList>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel5" Text="Título:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <textarea id="TextArea1" cols="20" style="width:100%; height:100%" rows="2"></textarea>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel6" Text="Objetivo:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <textarea id="TextArea2" cols="20" style="width:100%; height:100%"  rows="2"></textarea>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel7" Text="Justificación:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <textarea id="TextArea3" style="width:100%; height:100%" cols="20" rows="2"></textarea>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                        <telerik:RadLabel ID="RadLabel11" Text="Fecha de  Inicio:" runat="server"></telerik:RadLabel>
                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>
                    
                        <telerik:RadLabel ID="RadLabel12" Text="Fecha de Fin:" runat="server"></telerik:RadLabel>
                        <telerik:RadDatePicker ID="RadDatePicker2" runat="server"></telerik:RadDatePicker>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadCheckBox ID="RadCheckBox3" runat="server" Text=""></telerik:RadCheckBox>
                    </th>
                    <td>
                        <telerik:RadLabel ID="RadLabel13" style="width:100%;" Text="Basado en Normas Internacionales:" runat="server"></telerik:RadLabel>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadCheckBox ID="RadCheckBox4" runat="server" Text=""></telerik:RadCheckBox>
                    </th>
                    <td>
                        <telerik:RadLabel ID="RadLabel14"  Text="Armonización de la Norma:" runat="server"></telerik:RadLabel>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel15" Text="Justificación de Armonización:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <textarea id="TextArea4" cols="20" rows="2"></textarea>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel16" Text="Revisión:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList3" runat="server"></telerik:RadDropDownList>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel17" Text="Pertenece:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox4" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                        <textarea id="TextArea5" cols="20" style="width:480px" rows="2"></textarea>
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel18" Text="Responsable:" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox5" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                   <tr>
                       <td colspan="2">
                        <telerik:RadLabel ID="RadLabel19" Text="Proceso Normal:" runat="server"></telerik:RadLabel>
                        <asp:CheckBox runat="server"/>
                    
                        <telerik:RadLabel ID="RadLabel20" Text="Modificación Técnica / Cancelación:" runat="server"></telerik:RadLabel>
                        <asp:CheckBox runat="server"/>
                    </td>
                   </tr>
                </table>
                <br />

                            <!----------------------------------B O T O N E R A--------------------------------------------->
                            <telerik:RadToolBar ID="btnCuentas" Runat="server" Height="32" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
                                <Items>
                                   <telerik:RadToolBarButton Enabled="true" Value="0" ImageUrl="../Imagenes/Botoneras/New.png" Text="Nuevo" ToolTip ="Nuevo"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="2" ImageUrl="../Imagenes/Botoneras/Edit.png" Text="Editar"  ToolTip="Editar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="3" ImageUrl="../Imagenes/Botoneras/redo.png" Text="Deshacer"  ToolTip="Deshacer"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="1" ImageUrl="../Imagenes/Botoneras/save.png" Text="Guardar"  ToolTip="Guardar" ValidationGroup="PersonalInfoGroup"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="9" ImageUrl="../Imagenes/Botoneras/pnn.png" Text="Seguimiento"  ToolTip="Seguimiento"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/level.png" Text="C. Etapa"  ToolTip="C. Etapa"/>
                                     <telerik:RadToolBarButton Enabled="false" Width="50px"></telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton Enabled="true" Value="7" ImageUrl="../Imagenes/Botoneras/delete_32.png" Text=""  ToolTip="Eliminar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/exit.png" Text=""  ToolTip="Salir"/>
                                </Items>
                            </telerik:RadToolBar>
                
            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView2">
                <telerik:RadLabel ID="RadLabel45" Text="Etapa Documento de Trabajo" runat="server"></telerik:RadLabel>
                <table class="SinBorde">
                  <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <telerik:RadLabel ID="RadLabel8" Text="Procedimiento Alternativo" runat="server"></telerik:RadLabel>
                    </td>
                    <td></td>
                    <td>
                       <asp:CheckBox ID="CheckBox2" runat="server" />
                        <telerik:RadLabel ID="RadLabel9" Text="Revisión Editorial" runat="server"></telerik:RadLabel>
                    </td>
                    <td>
                         
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel10" Text="Clasificación" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox6" runat="server"></telerik:RadTextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel21" Text="Título DT" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox7" runat="server"></telerik:RadTextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel22" Text="Fecha de Inicio de desarrollo en NMX" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox8" runat="server"></telerik:RadTextBox>
                    </td>
                    <td></td>
                    <th>
                        <telerik:RadLabel ID="RadLabel23" Text="Fecha de Aprovación de Revisión Editorial" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox9" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                    <tr>
                        <th>
                            <telerik:RadLabel ID="RadLabel46" Text="Responsable" runat="server"></telerik:RadLabel>
                        </th>
                        <td colspan="2">
                             <telerik:RadDropDownList ID="RadDropDownList5" Width="100%" runat="server"></telerik:RadDropDownList>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel24" Text="Adjuntar Documento de Trabajo Final" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                    <td></td>
                    <th>
                        <telerik:RadLabel ID="RadLabel25" Text="Fecha de Carga Documento de Trabajo Final" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadTextBox ID="RadTextBox10" runat="server"></telerik:RadTextBox>
                    </td>
                  </tr>
                  
                </table>    
                <br />
                <telerik:RadLabel ID="RadLabel44" Text="Procedimiento Alternativo" runat="server"></telerik:RadLabel>
                <table style="width: 100%; height:100px;" class="SinBorde">
                
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel35" Text="Responsable Tema" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList4" runat="server"></telerik:RadDropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td></td>
                  </tr>
                    <tr>
                        <th>
                         <telerik:RadLabel ID="RadLabel36" Text="Fecha de Inicio Responsable" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker7" runat="server"></telerik:RadDatePicker>
                    </td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>

                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel37" Text="Fecha de Fin Responsable" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker8" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td></td>
                    <th>
                        <telerik:RadLabel ID="RadLabel38" Text="Adjuntar Minuta de Terminación de Procedimiento Alternativo" runat="server"></telerik:RadLabel>
                    </th>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel39" Text="Fecha de Inicio de emisión de comentarios" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker9" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td></td>
                    <td>
                        <asp:FileUpload ID="FileUpload3" runat="server" />
                    </td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel40" Text="Fecha de Fin de emisión de comentarios" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker10" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel41" Text="Tuvo Comentarios Técnicos" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:RadioButton ID="RadioButton7" runat="server" Text="SI" /><asp:RadioButton ID="RadioButton8" runat="server" Text="NO" />
                    </td>
                    <td></td>
                    <th>
                        <telerik:RadLabel ID="RadLabel42" Text="Aprovado DT" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel43" Text="Tuvo Comentarios Editoriales" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:RadioButton ID="RadioButton11" runat="server" Text="SI" /><asp:RadioButton ID="RadioButton12" runat="server" Text="NO" />
                    </td>
                    <td></td>
                    <td>
                        <asp:RadioButton ID="RadioButton9" runat="server" Text="SI" /><asp:RadioButton ID="RadioButton10" runat="server" Text="NO" />
                    </td>
                    <td></td>
                  </tr>
                </table>
                
                            <!----------------------------------B O T O N E R A--------------------------------------------->
                    <!----------------------------------B O T O N E R A--------------------------------------------->
                            <telerik:RadToolBar ID="RadToolBar1" Runat="server" Height="32" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
                                <Items>
                                   <telerik:RadToolBarButton Enabled="true" Value="0" ImageUrl="../Imagenes/Botoneras/New.png" Text="Nuevo" ToolTip ="Nuevo"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="2" ImageUrl="../Imagenes/Botoneras/Edit.png" Text="Editar"  ToolTip="Editar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="3" ImageUrl="../Imagenes/Botoneras/redo.png" Text="Deshacer"  ToolTip="Deshacer"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="1" ImageUrl="../Imagenes/Botoneras/save.png" Text="Guardar"  ToolTip="Guardar" ValidationGroup="PersonalInfoGroup"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="9" ImageUrl="../Imagenes/Botoneras/pnn.png" Text="Seguimiento"  ToolTip="Seguimiento"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/level.png" Text="C. Etapa"  ToolTip="C. Etapa"/>
                                     <telerik:RadToolBarButton Enabled="false" Width="50px"></telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton Enabled="true" Value="7" ImageUrl="../Imagenes/Botoneras/delete_32.png" Text=""  ToolTip="Eliminar"/>
                                    <telerik:RadToolBarButton Enabled="true" Value="15" ImageUrl="../Imagenes/Botoneras/exit.png" Text=""  ToolTip="Salir"/>
                                </Items>
                            </telerik:RadToolBar>

            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView3">
                tab 3
                <table style="width: 100%; height:100px;" class="SinBorde">
                
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel26" Text="Responsable Tema" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList2" runat="server"></telerik:RadDropDownList>
                    </td>
                    <th>
                         <telerik:RadLabel ID="RadLabel27" Text="Fecha de Inicio Responsable" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker3" runat="server"></telerik:RadDatePicker>
                    </td>
                    <th></th>
                  </tr>

                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel28" Text="Fecha de Fin Responsable" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker4" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td></td>
                    <th>
                        <telerik:RadLabel ID="RadLabel31" Text="Adjuntar Minuta de Terminación de Procedimiento Alternativo" runat="server"></telerik:RadLabel>
                    </th>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel29" Text="Fecha de Inicio de emisión de comentarios" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker5" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td></td>
                    <td>
                        <asp:FileUpload ID="FileUpload2" runat="server" />
                    </td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel30" Text="Fecha de Fin de emisión de comentarios" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker6" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel32" Text="Tuvo Comentarios Técnicos" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="SI" /><asp:RadioButton ID="RadioButton2" runat="server" Text="NO" />
                    </td>
                    <td></td>
                    <th>
                        <telerik:RadLabel ID="RadLabel33" Text="Aprovado DT" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:RadioButton ID="RadioButton3" runat="server" Text="SI" /><asp:RadioButton ID="RadioButton4" runat="server" Text="NO" />
                    </td>
                  </tr>
                  <tr>
                    <th>
                        <telerik:RadLabel ID="RadLabel34" Text="Tuvo Comentarios Editoriales" runat="server"></telerik:RadLabel>
                    </th>
                    <td>
                        <asp:RadioButton ID="RadioButton5" runat="server" Text="SI" /><asp:RadioButton ID="RadioButton6" runat="server" Text="NO" />
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                  </tr>
                </table>
                
                            <!----------------------------------B O T O N E R A--------------------------------------------->
                    <telerik:RadToolBar ID="RadToolBar2" Runat="server" Height="55" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
                        <Items>
                            <telerik:RadToolBarButton Enabled="true" Value="10" ImageUrl="../Imagenes/Botoneras/buscar.png" ToolTip ="Buscar"/>
                            <telerik:RadToolBarButton Enabled="true" Value="11" ImageUrl="../Imagenes/Botoneras/exportar.png" ToolTip="Exportar"/>

                        </Items>
                    </telerik:RadToolBar>

            </telerik:RadPageView>
            <telerik:RadPageView runat="server" ID="RadPageView4">
                tab 4
                <table style="width: 100%; height:100px;" class="SinBorde">
                  
                  
                </table>
                
                            <!----------------------------------B O T O N E R A--------------------------------------------->
                    <telerik:RadToolBar ID="RadToolBar3" Runat="server" Height="55" Width="100%" SkinID="SkinManager" OnClientButtonClicking="clientButtonClicking">  
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