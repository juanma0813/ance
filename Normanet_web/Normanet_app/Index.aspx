<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Normanet_app.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..:: Normanet Web ::..</title>
    <link href="css/cssGeneral.css" rel="stylesheet" />
    <link href="css/cssCuentaRegresiva.css" rel="stylesheet" />
    <link href="js/plugins/jquery.bubbleinfo/css/cssBubbleInfo.css" rel="stylesheet" />
    <link href="js/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/cssIndex.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../js/jQueryFrameWork.js"></script>
    <script language="javascript" type="text/javascript" src="../js/bootstrap/js/bootstrap.min.js"></script>
    <script language="javascript" type="text/javascript" src="../js/plugins/jquery.bubbleinfo/jquery.bubbleinfo.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Index.js"></script>
    <script language="javascript" type="text/javascript" src="../js/jsGeneral.js"></script>
</head>
   <body onload="nobackbutton(); ComprobarBrowserSV();">
       <form id="form1" runat="server">
           <telerik:RadScriptManager Runat="server"></telerik:RadScriptManager>
           <telerik:RadSkinManager ID="SkinManager" runat="server" Skin="Office2010Blue"></telerik:RadSkinManager>
           <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecoratedControls="All" EnableRoundedCorners="False" SkinID="SkinManager" />
           <telerik:RadAjaxLoadingPanel ID="ralpLoad" runat="server" SkinID="SkinManager"></telerik:RadAjaxLoadingPanel>
           <telerik:RadPersistenceManager ID="RadPersistenceManager1" runat="server">
               <PersistenceSettings>
                   <telerik:PersistenceSetting ControlID="rapMDI" />
               </PersistenceSettings>
           </telerik:RadPersistenceManager>

           <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
               <AjaxSettings>
                   <telerik:AjaxSetting AjaxControlID="rbbRibbon">
                       <UpdatedControls>
                           <telerik:AjaxUpdatedControl ControlID="rbbRibbon" />
                           <telerik:AjaxUpdatedControl ControlID="rapMDI" LoadingPanelID="ralpLoad" />
                       </UpdatedControls> 
                   </telerik:AjaxSetting>
               </AjaxSettings>
           </telerik:RadAjaxManager>
           <div class="canvas">
               <telerik:RadToolBar ID="rtbTitulo" runat="server" Width="100%" style="text-align:center;" BorderStyle="None" BorderWidth="0px" SkinID="SkinManager">
                   <Items>
                       <telerik:RadToolBarButton>
                           <ItemTemplate>
                               <asp:Label ID="lblTitulo" runat="server" Text="..:: Normanet ::.." Font-Bold="True"></asp:Label>
                           </ItemTemplate>
                       </telerik:RadToolBarButton>
                   </Items>
               </telerik:RadToolBar>
               <telerik:RadRibbonBar ID="rbbRibbon" runat="server" SkinID="SkinManager" Width="100%" EnableMinimizing="True" EnableQuickAccessToolbar="False" RenderInactiveContextualTabGroups="False" SelectedTabIndex="0"
                   OnButtonClick="rbbRibbon_ButtonClick" >
                   <Tabs>
                      <telerik:RibbonBarTab ID="RibbonBarTab1" runat="server" Text="Catálogos">
                         <telerik:RibbonBarGroup ID="RibbonBarGroup1" runat="server" Text="Clipboard">
                            <Items>
                               <telerik:RibbonBarButton Size="Medium" Text=" Comites" ImageUrl="Imagenes/Botoneras/Catalogos2.png"  Value="1" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Cargos" ImageUrl="Imagenes/Botoneras/Catalogos2.png"  Value="2" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Categorias" ImageUrl="Imagenes/Botoneras/Catalogos2.png"  Value="3" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Categorias de Revisión Editorial" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="4" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Puntos de Revisión Editorial" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="5" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Representación" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="6" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Sectores" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="7" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Directorio" ImageUrl="Imagenes/Botoneras/Catalogos2.png"  Value="8" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Remitentes" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="9" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Nombramientos" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="10" />
                               <telerik:RibbonBarButton Size="Medium" Text=" Reporte Asistencia" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="11" />
                                <telerik:RibbonBarButton Size="Medium" Text=" Titulares y Suplentes" ImageUrl="Imagenes/Botoneras/Catalogos2.png" Value="12" />
                            </Items>
                         </telerik:RibbonBarGroup>
                      </telerik:RibbonBarTab>
                      <telerik:RibbonBarTab ID="RibbonBarTab2" runat="server" Text="Procesos">
                         <telerik:RibbonBarGroup ID="RibbonBarGroup11" runat="server" Text="Illustrations">
                            <Items>
                                <telerik:RibbonBarMenu Size="Medium" Text="Admon PNN" ImageUrl="Imagenes/Botoneras/pnn.png">
                                    <Items>
                                        <telerik:RibbonBarMenuItem Text="PNN" ImageUrl="Imagenes/Botoneras/pnn.png">
                                        </telerik:RibbonBarMenuItem>
                                        <telerik:RibbonBarMenuItem Text="PNN Temas" ImageUrl="Imagenes/Botoneras/pnn.png">
                                        </telerik:RibbonBarMenuItem>
                                        <telerik:RibbonBarMenuItem Text="Traspaso Temas Planes" ImageUrl="Imagenes/Botoneras/pnn.png">
                                        </telerik:RibbonBarMenuItem>
                                    </Items>
                                </telerik:RibbonBarMenu>
                                <telerik:RibbonBarButton Size="Medium" Text="PNN" ImageUrl="Imagenes/Botoneras/pnn.png" Value="13" />
                                <telerik:RibbonBarButton Size="Medium" Text="PNN Temas" ImageUrl="Imagenes/Botoneras/pnn.png" Value="14" />
                                <telerik:RibbonBarButton Size="Medium" Text="Traspaso Temas Planes" ImageUrl="Imagenes/Botoneras/pnn.png" Value="15" />
                               <telerik:RibbonBarButton Size="Medium" Text="Avance Temas" ImageUrl="Imagenes/Botoneras/pnn.png" Value="9" />
                               <telerik:RibbonBarButton Size="Medium" Text="Catálogo de Normas" ImageUrl="Imagenes/Botoneras/pnn.png" Value="20" />
                               <telerik:RibbonBarButton Size="Medium" Text="Comentarios" ImageUrl="Imagenes/Botoneras/pnn.png" Value="11" />
                               <telerik:RibbonBarButton Size="Medium" Text="Noticias" ImageUrl="Imagenes/Botoneras/pnn.png" Value="12" />
                                <telerik:RibbonBarButton Size="Medium" Text="Sesiones" ImageUrl="Imagenes/Botoneras/pnn.png" Value="12" />
                                <telerik:RibbonBarButton Size="Medium" Text="Gestión de Documentos" ImageUrl="Imagenes/Botoneras/pnn.png" Value="12" />
                            </Items>
                         </telerik:RibbonBarGroup>
                      </telerik:RibbonBarTab>
                   </Tabs>

                   <KeyboardNavigationSettings CommandKey="Alt"></KeyboardNavigationSettings>
               </telerik:RadRibbonBar>
               <div id="Sesion"></div>
               <div id="UsrSesion" class="UsrSesion" >
                   <asp:HiddenField ID="hidUsuario" runat="server" />
                   <asp:HiddenField ID="hidInicializarNotificaciones" runat="server" />
                   <asp:Panel ID="pnlUsuario" runat="server" CssClass="IconUsuario" Visible="true" Width="400px" Height="20px" style="padding-right:20px;">
                         <nav class="navbar navbar-right" >
                          <div class="container-fluid">
                            <div>
                              <ul class="nav navbar-nav">
                                <li>
                                    <a  id="dropdownMenuNotif" class="dropdown-toggle count-info" data-toggle="dropdown" aria-expanded="false" style="padding:3px 8px 3px 8px;">
                                        <img alt="" id="imgNotif" src="Imagenes/Formularios/Bell.png" />
                                        <span id="NotifTotal" class="label label-danger label-as-badge" style="font-size:10px; font-weight:bold;"></span>
                                    </a>
                                     <ul id="NotificacionesUsuario" class="dropdown-menu alert-dropdown list-group" style="width:250px;" aria-labelledby="dropdownMenuNotif">
                                     </ul>
                                </li> 
                                <li class="dropdown">
                                    <div class="Bubble" style="padding:3px 8px 3px 8px;">
                                        <div style="width: 16px;">
                                            <img alt="" src="Imagenes/Formularios/Employee.png" />
                                        </div>
                                        <div style="width: 300px; text-align: center; display: none;">
                                            <asp:Label ID="lblUsuario" runat="server" Text="" Font-Bold="true" Font-Size="11px">
                                            </asp:Label>
                                        </div>
                                    </div>
                                </li>
                              </ul>
                            </div>
                          </div>
                        </nav>

                    </asp:Panel>                   
                </div>

           </div>
           <div id="AreaRestringida">
               <div id="LogoAnce"></div>
           </div>
           <telerik:RadWindowManager runat="server" RestrictionZoneID="AreaRestringida" ID="rdWndMngPrincipal" EnableShadow="true"  
                ShowOnTopWhenMaximized="false" ShowContentDuringLoad="false"  SkinID="SkinManager"
                EnableEmbeddedScripts="true" VisibleStatusbar="false" VisibleTitlebar="true" RenderMode="Classic" />

           <telerik:RadCodeBlock ID="CodeBlock" runat="server">
              <script type="text/javascript">
                  function OpenWindow(URL, Titulo, Width, Height) {
                     Left = ($("#AreaRestringida").width() / 2) - (Width/2);

                     var wnd = window.radopen(URL, null, Width, Height, Left, 50);
                     wnd.set_title(Titulo);

                     return false;
                 }
              </script>
           </telerik:RadCodeBlock>
           <asp:UpdatePanel ID="udpCBJquery" runat="server"></asp:UpdatePanel>
           
       </form>
   </body>
</html>
