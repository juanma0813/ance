/*
Autor: Ing. Efrén David Tello Villalobos
Fecha: 04/03/2013

Hace importaciones de los JS que necesita jquery para funcionar, Originalmente se contenian en la masterPage
ahora se contienen en un solo archivo llamado jQueryFrameWork.js haciendo referencia a la ruta de jqueryFrameWork

Notas: En caso de requerir de una version actualizada de frameWork de Jqeury solo es necesario 
1. Tener el frameWork Completo
2. Redireccionar las librerias principalment la seccion de "Core"
*/

//------------------------------------------------------Estilos------------------------------------------------------
document.write('<link rel="stylesheet" type="text/css" href="https://www.ance.org.mx/jquery/1_10_3/JqueryFramework/themes/Cupertino/jquery.ui.all.css" />');
//-----------------------------------------------------------------------------------------------------------------------------------------

// Importaciones del Core de Jquery
document.write('<script src="https://www.ance.org.mx/jquery/1_10_3/JqueryFramework/js/jquery-1.9.1.js" type="text/javascript"></script>');
document.write('<script src="https://www.ance.org.mx/jquery/1_10_3/JqueryFramework/js/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>');

//------------------------------------------------------Referencia a Plugins Internos------------------------------------------------------

	//Vista compatibilidad
    document.write('<script src="https://www.ance.org.mx/jquery/Plugins/VistaCompatibilidad/jsDetectarVistaComp.js" type="text/javascript"></script>');

    //Dialog
    document.write('<script src="https://www.ance.org.mx/jquery/1_9_2/jQueryFramework/js/ui/jquery.ui.dialog.js" type="text/javascript"></script>');

    //window
    document.write('<script src="https://www.ance.org.mx/jquery/1_9_2/jQueryFramework/js/ui/jquery.ui.window.js" type="text/javascript"></script>');
    document.write('<link rel="stylesheet" type="text/css" href="https://www.ance.org.mx/jquery/1_10_3/JqueryFramework/themes/Cupertino/jquery.ui.window.css" />');

    //Cuenta regresiva
    document.write('<script src="https://www.ance.org.mx/jquery/Plugins/CuentaRegresiva/jquery.CuentaRegresiva.js" type="text/javascript"></script>');
//-----------------------------------------------------------------------------------------------------------------------------------------


