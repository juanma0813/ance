REM Clase en VB creada automaticamente by ..:: ANCE ::.. .Clase creada el: 09/09/2013 Version 3.3
Imports System.Text.RegularExpressions.Match
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports Telerik.Web.UI
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Drawing
Imports System.IO

Module General

    Public Sub inactivar(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.enabled = False
        Next

    End Sub

    Public Sub Activar(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.enabled = True
        Next
    End Sub

    Public Sub Visibles(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.visible = True
        Next

    End Sub

    Public Sub Invisibles(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.visible = False
        Next
    End Sub

    Public Sub Limpiar(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.Text = ""
        Next
    End Sub

    Public Sub Lectura(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.ReadOnly = True
        Next
    End Sub

    Public Sub Escritura(ByVal ParamArray obj() As Object)
        For Each objetos In obj
            objetos.ReadOnly = False
        Next
    End Sub

    Public Sub MsgJquery(obj As Object, Mensaje As String, Titulo As String)
        Mensaje = Mensaje.Replace("'", "").Replace("""", "").Replace(vbCrlf, "")
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType, Guid.NewGuid.ToString, "$('<div><br /><div style=""text-align:center;"">" & Mensaje & "</div></div>').dialog({title:'" & Titulo & "',zIndex:'4001',autoOpen:true,modal:true,buttons: {'Aceptar': function() {$( this ).dialog('close');}}});", True)
    End Sub

    ''' <summary>
    ''' Metodo para abrir una nueva vantana con el Plug window
    ''' </summary>
    ''' <param name="Pagina">obj:Page</param>
    ''' <param name="sPagina">P�gina que se desea abrir</param>
    ''' <param name="sTitulo">Titulo de la ventana</param>
    ''' <param name="Width">Ancho de la ventana</param>
    ''' <param name="Height">Alto de la ventana</param>
    ''' <param name="esPrincipal">Si es principal indica que es ventana de index, de lo contrario se entiende que desea abrir una ventana desde otra ventana</param>
    ''' <remarks></remarks>
    Public Sub AddWindow(Pagina As Object, sPagina As String, sTitulo As String, Width As Integer, Height As Integer, esPrincipal As Boolean)
        Dim sScript As String = IIf(esPrincipal = True, "Dialogo", "parent.Dialogo")
        ScriptManager.RegisterStartupScript(Pagina, Pagina.GetType(), "key", sScript + "('" & sPagina & "','" & sTitulo & "'," & Width & "," & Height & ");", True)
    End Sub

    Public Sub CuentaRegresivaSesion(obj As Object, Session As Object, Optional mdi As Boolean = True)

        Dim sTiempoSesion As String = (Session.Timeout * 60) - 30
        Dim sMostrarContadorFaltando As String = System.Configuration.ConfigurationManager.AppSettings("MostrarCuentaRegresiva").ToString
        Dim sPagRedireccionar As String = System.Configuration.ConfigurationManager.AppSettings("TerminoSession").ToString
        Dim js As String
        REM js = "parent.$('#divMsgSesion').remove(); $('#divCuentaRegresiva').remove(); CrearContador(" & sTiempoSesion & ",'" & sPagRedireccionar & "'," & sMostrarContadorFaltando & "," & mdi.ToString.ToLower & ");"
        js = "CrearContador(" & sTiempoSesion & ",'" & sPagRedireccionar & "'," & sMostrarContadorFaltando & "," & mdi.ToString.ToLower & ");"
        ScriptManager.RegisterStartupScript(obj, obj.GetType, "TerminarSesion", js, True)

    End Sub

    ''' <summary>
    ''' Es requerido Contar con un div que contenga una label para el tecto (previamente asignado y los botones con su respectivo handler
    ''' </summary>
    ''' <param name="obj">Objeto en el que se inclusta el js</param>
    ''' <param name="Selector">id o clase del panel confirm (sin #)</param>
    ''' <param name="Titulo">titulo de la ventana</param>
    ''' <param name="Botones">botones que contiene el panel confirm</param>
    ''' <remarks></remarks>
    Public Sub MsgJqueryConfirm(obj As Object, Selector As String, Titulo As String, ParamArray Botones() As String)
        Dim sScript As String = String.Format("{0} openConfirm('{1}','{2}',{3})", FormarArreglo(Botones), Selector, Titulo, "btns")
        ScriptManager.RegisterClientScriptBlock(obj, obj.GetType, Guid.NewGuid.ToString, sScript, True)
    End Sub

    Private Function FormarArreglo(Botones As String()) As String
        Dim sArray As String = "var btns=["
        For Each Boton In Botones
            sArray += "'#" & Boton & "',"
        Next
        sArray = Mid(sArray, 1, Len(sArray) - 1) & "];"

        Return sArray
    End Function

    ''' <summary>
    ''' Funcion que valida campos en blanco, deben de contener por lo menos una letra
    ''' </summary>
    ''' <param name="obj">Campos de texto que se desean validar </param>
    ''' <returns>Regresa un arreglo de los objetos que no pasaron la prueba</returns>
    ''' <remarks></remarks>
    Public Function validarCampos(ByVal ParamArray obj() As Object) As Array
        Dim exReg As String = "[a-zA-Z]"
        Dim arrObj(0) As String
        Dim ciclo = 0

        For Each objetos In obj
            If Not Regex.IsMatch(objetos.text, exReg) Then
                ReDim arrObj(ciclo)
                arrObj(ciclo) = objetos.name
                ciclo += 1
            End If
        Next

        Return arrObj
    End Function

    ''' <summary>
    ''' Permite encontrar el nombre de un archivo en un path :. c:\documentos\docto.xls. 
    ''' </summary>
    ''' <param name="sArchivoRuta">Ruta donde se encuentra el archivo</param>
    ''' <returns>Regresa un arreglo de longitud 2 donde contiene el nombre del archivo (0) y su extencion (1)</returns>
    ''' <remarks></remarks>
    Public Function RutaArchCadena(ByVal sArchivoRuta As String) As Array
        Dim iIndice As Integer
        Dim sNombreArTem As String = ""
        Dim aText() As String
        Dim sExt As String

        'nombre archivo
        For iIndice = Len(sArchivoRuta) To 1 Step -1
            If Mid(sArchivoRuta, iIndice, 1) = "\" Then
                sNombreArTem = Mid(sArchivoRuta, iIndice + 1)
                iIndice = 1
            End If
        Next iIndice
        'para sacar la extencion del archivo

        aText = Split(sNombreArTem, ".")
        sExt = aText(UBound(aText))

        ReDim aText(1)
        aText(0) = sNombreArTem.Replace("." & sExt, "")
        aText(1) = "." & sExt

        Return aText
    End Function

    ''' <summary>
    ''' Permite registrar los errores en la base de datos, enviar correos de error, y en archivo axd
    ''' </summary>
    ''' <param name="ex">Es la excepcion que se genera por lo regular en un Catch</param>
    ''' <remarks></remarks>
    Public Sub RegistrarError(ex As Exception)
        Elmah.ErrorSignal.FromCurrentContext().Raise(ex)
    End Sub

    ''' <summary>
    ''' Asigna la CultureInfo para los objetos con propiedad de Culture
    ''' Aplica idioma de etiquetas y tags si cuenta si cuenta con App_GlobalResources
    ''' </summary>
    ''' <param name="obj">Arrego de objetos para asignar CultureInfo</param>
    ''' <remarks></remarks>
    Public Sub AsignaCulturaInfo(ByVal ParamArray obj() As Object)
        Try
            Dim cuiCU As New CultureInfo(CultureInfo.CurrentCulture.Name)
            For Each objetos In obj
                objetos.Culture = cuiCU
            Next
        Catch ex As Exception
            RegistrarError(ex)
        End Try
    End Sub

    Public Sub AsignaLocalizacionWindowManager(ByVal ParamArray obj() As RadWindowManager)
        Try
            For Each objetos In obj
                objetos.Localization.Cancel = Resources.RadWindowManager.Main.Cancel
                objetos.Localization.Close = Resources.RadWindowManager.Main.Close
                objetos.Localization.Maximize = Resources.RadWindowManager.Main.Maximize
                objetos.Localization.Minimize = Resources.RadWindowManager.Main.Minimize
                objetos.Localization.No = Resources.RadWindowManager.Main.No
                objetos.Localization.OK = Resources.RadWindowManager.Main.OK
                objetos.Localization.PinOff = Resources.RadWindowManager.Main.PinOff
                objetos.Localization.PinOn = Resources.RadWindowManager.Main.PinOn
                objetos.Localization.Reload = Resources.RadWindowManager.Main.Reload
                objetos.Localization.Restore = Resources.RadWindowManager.Main.Restore
            Next
        Catch ex As Exception
            RegistrarError(ex)
        End Try
    End Sub


    REM COMPLEMENTOS JALOPEZ

#Region "COMPLEMENTOS_JALOPEZ"
    Sub LLenarRCbo(rcbo As RadComboBox, sCampoId As String, sCampoDesc As String, dt As DataTable, Optional SelValDefault As String = "")
        rcbo.DataTextField = sCampoDesc
        rcbo.DataValueField = sCampoId
        rcbo.DataSource = dt
        rcbo.DataBind()
        rcbo.SelectedIndex = rcbo.FindItemIndexByValue(SelValDefault)
    End Sub

    Public Sub OpenWindow(udpCBJquery As Object, objPage As Object, sPagina As String, sTitulo As String, Width As Integer, Height As Integer)
        ScriptManager.RegisterClientScriptBlock(udpCBJquery, objPage.GetType, Guid.NewGuid.ToString, "OpenWindow('" & sPagina & "','" & sTitulo & "'," & Width & "," & Height & ");", True)
    End Sub

    Public Sub OpenWindowURL(udpCBJquery As Object, objPage As Object, sURL As String, rWinVentana As String, sTitulo As String, Width As Integer, Height As Integer)
        ScriptManager.RegisterClientScriptBlock(udpCBJquery, objPage.GetType, Guid.NewGuid.ToString, "OpenWindowURL('" & sURL & "','" & rWinVentana & "','" & sTitulo & "'," & Width & "," & Height & ");", True)
    End Sub

    Public Sub CloseWindow(udpCBJquery As Object, objPage As Object, sPagina As String)
        ScriptManager.RegisterClientScriptBlock(udpCBJquery, objPage.GetType, Guid.NewGuid.ToString, "CloseWindow('" & sPagina & "');", True)
    End Sub

    Function MostrarMsgErrorClase(objClase As Object, objPage As Object, Titulo As String, Optional ErrPersonalizado As String = "") As Boolean
        If objClase.bError Then

#If DEBUG Then
            MsgJquery(objPage, objClase.uException.Message, Titulo)
#Else
            MsgJquery(objPage, ErrPersonalizado, Titulo)
#End If

            Elmah.ErrorSignal.FromCurrentContext().Raise(objClase.uException)
            Return True
        End If
        Return False
    End Function

    Sub MostrarMsgErrorTryCatch(objPage As Object, sMsgErrorPersonalizado As String, sTitulo As String, objError As Object)
#If DEBUG Then
        MsgJquery(objPage, objError.Message, sTitulo)
#Else
        MsgJquery(objPage, sMsgErrorPersonalizado, sTitulo)
#End If
        Elmah.ErrorSignal.FromCurrentContext().Raise(objError)
    End Sub

    REM JLA Agregar estas funciones en la proxima actualizacion del proyecto 18/09/2014
    Sub SelRcbo(rcbo As RadComboBox, Valor As Object)
        rcbo.SelectedIndex = rcbo.FindItemIndexByValue(Valor)
    End Sub

    Sub LimpiarSelRCbo(rcbo As RadComboBox, Optional bQuitarElem As Boolean = False)
        rcbo.Text = ""
        rcbo.ClearSelection()
        If bQuitarElem Then rcbo.Items.Clear()
    End Sub

    Sub MostrarWebReportePDFSeguro(sRutaDocPdf As String, sIdUsuario As String, Pagina As Object, Optional bProtegido As Boolean = True, Optional bPermisoImpre As Boolean = True, Optional bConvertPDF As Boolean = False, Optional bMarcaAgua As Boolean = False, Optional sConfigMarcaAgua As String = "", Optional bMostrarAuto As Boolean = True, Optional sAliasDocto As String = "")
        Dim js As String
        Dim objLinkDocSec As New clssLinkDocSeguro

        With objLinkDocSec
            .sSesion = sIdUsuario
            .sRutaFisica = sRutaDocPdf
            .sAliasDocto = sAliasDocto
            .bConvertPDF = bConvertPDF
            .bProtegido = bProtegido
            .bMarcaAgua = bMarcaAgua
            .bPermisoImpre = bPermisoImpre
            .sConfigMarcaAgua = sConfigMarcaAgua
            .CifrarUrl()

            If bMostrarAuto Then
                js = "$(function(){ window.open('" & .sUrl & "'); });"
                ScriptManager.RegisterClientScriptBlock(Pagina.Page, Pagina.GetType, "MostrarPDF", js, True)
            End If

        End With

        objLinkDocSec = Nothing
    End Sub

    Function DesEncriptarKeyWebConfig(key As String) As String
        Using objDe As New clsAnceDe.AnceSystems.clsDesencriptar
            Return objDe.DesEncriptarCadena(ConfigurationManager.AppSettings(key).Replace("°°", "&").Replace("°-°", "<").Replace("|-|", ">"))
        End Using
    End Function

    REM SUBCLASES
    '20150109
    Function ObtIdsSelecGrid(rgrd As RadGrid, listNomIds As List(Of String), Optional bQuitarEncabXml As Boolean = False) As String
        Dim sXml As String = ""
        Dim sAttrXML As String = ""

        If Not bQuitarEncabXml Then
            sXml = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & "  encoding=" & Chr(34) & "utf-8" & Chr(34) & " ?>"
        End If

        sXml &= "<Datos>"
        For Each item As GridDataItem In rgrd.SelectedItems

            sAttrXML = ""
            For Each iList As String In listNomIds
                sAttrXML &= iList & "=" & Chr(34) & item.GetDataKeyValue(iList) & Chr(34) & " "
            Next

            sXml &= "<Registro " & sAttrXML & " />"

        Next
        sXml &= "</Datos>"

        Return sXml
    End Function

    '20150115
    Sub AgregarItemRadComboBox(rcbo As RadComboBox, sId As String, sText As String)

        Dim item As New RadComboBoxItem
        item.Text = sText
        item.Value = sId
        rcbo.Items.Add(item)

    End Sub

    Enum eTipoValorValidar
        Numerico = 1
        Cadena = 2
        Bytes = 3
    End Enum

    ''' <summary>
    ''' Valida que el campo ingresado no sea nullo para asegurar que se retorne un campo valido
    ''' </summary>
    ''' <param name="Campo"></param>
    ''' <param name="enuTipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ValidaCampoNulo(ByVal Campo As Object, ByVal enuTipo As eTipoValorValidar) As Object

        Select Case enuTipo
            Case eTipoValorValidar.Cadena
                Return IIf(IsDBNull(Campo), "", Campo)
            Case eTipoValorValidar.Numerico
                Return IIf(IsDBNull(Campo), 0, Campo)
            Case eTipoValorValidar.Bytes
                Return IIf(IsDBNull(Campo), Nothing, Campo)
        End Select

        Return ""

    End Function


    ''' <summary>
    ''' Realiza la solicitud de actualizacion de un panel a otro
    ''' </summary>
    ''' <param name="rapPanelOrigen"></param>
    ''' <param name="rapPanelActualizar"></param>
    ''' <remarks></remarks>
    Sub ActualizarRadAjaxPanel(rapPanelOrigen As RadAjaxPanel, rapPanelActualizar As RadAjaxPanel)
        rapPanelOrigen.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest();", rapPanelActualizar.ClientID))
    End Sub
    ''' <summary>
    ''' Refresca el contenido de un RadAjaxPanel
    ''' </summary>
    ''' <param name="Pagina"></param>
    ''' <param name="rapPanel"></param>
    ''' <remarks></remarks>
    Sub ActualizarRadAjaxPanel(Pagina As Page, rapPanel As RadAjaxPanel)
        Dim js As String
        js = String.Format("$find('{0}').ajaxRequest();", rapPanel.ClientID)
        ScriptManager.RegisterClientScriptBlock(Pagina, Pagina.GetType, "ActualizarPanel", js, True)
    End Sub
    ''' <summary>
    ''' Configura los controles RadAsyncUpload para definir sus limites permitidos segun la configuracion del WebConfig
    ''' </summary>
    ''' <param name="raup">Control RadAsyncUpload a configurar </param>
    ''' <param name="MaxCantArchPerm">Maximo Cantidad de Archivos que se permiten adjuntar</param>
    ''' <param name="NomConfigExtenPermitidas">Nombre de configuracion del WebConfig que define las extensiones permitidas</param>
    ''' <remarks></remarks>
    Sub ConfigurarControlAsyncUpLoad(raup As RadAsyncUpload, MaxCantArchPerm As Integer, Optional NomConfigExtenPermitidas As String = "ExtensionesArchivosGral")

        Dim sExtenciones As String = ConfigurationManager.AppSettings(NomConfigExtenPermitidas)
        sExtenciones = sExtenciones.ToLower & "," & sExtenciones.ToUpper

        raup.AllowedFileExtensions = Split(sExtenciones, ",")
        raup.MaxFileSize = ConfigurationManager.AppSettings("MaxTamanioArchivo")
        raup.MaxFileInputsCount = MaxCantArchPerm
    End Sub


    '''20150415
    ''' <summary>
    ''' Convierte una lista de LINQ a DataTable
    ''' </summary>
    ''' <param name="parIList">Lista de LINQ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LinqToDataTable(ByVal parIList As System.Collections.IEnumerable) As System.Data.DataTable
        Dim ret As New System.Data.DataTable()
        Try
            Dim ppi As System.Reflection.PropertyInfo() = Nothing
            If parIList Is Nothing Then Return ret
            For Each itm In parIList
                If ppi Is Nothing Then
                    ppi = DirectCast(itm.[GetType](), System.Type).GetProperties()
                    For Each pi As System.Reflection.PropertyInfo In ppi
                        Dim colType As System.Type = pi.PropertyType
                        If (colType.IsGenericType) AndAlso
                           (colType.GetGenericTypeDefinition() Is GetType(System.Nullable(Of ))) Then colType = colType.GetGenericArguments()(0)
                        ret.Columns.Add(New System.Data.DataColumn(pi.Name, colType))
                    Next
                End If
                Dim dr As System.Data.DataRow = ret.NewRow
                For Each pi As System.Reflection.PropertyInfo In ppi
                    dr(pi.Name) = If(pi.GetValue(itm, Nothing) Is Nothing, DBNull.Value, pi.GetValue(itm, Nothing))
                Next
                ret.Rows.Add(dr)
            Next
            For Each c As System.Data.DataColumn In ret.Columns
                c.ColumnName = c.ColumnName.Replace("_", " ")
            Next
        Catch ex As Exception
            ret = New System.Data.DataTable()
            Throw ex
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' Oculta el control loading panel que se encuentre reflejado sobre un control dado.
    ''' </summary>
    ''' <param name="udpCBJquery">Updatepanel sobre el cual se escribira el codigo de javascript</param>
    ''' <param name="objPage">El objeto pagina sobre el cual se este trabajando</param>
    ''' <param name="sIDLoadingPanel">El id del control de Telerik Loading Panel</param>
    ''' <param name="sIDControlReflejar">El id del control sobre el cual se refleja el Loading Panel</param>
    ''' <remarks></remarks>
    Sub HideLoadingPanel(udpCBJquery As Object, objPage As Object, sIDLoadingPanel As String, sIDControlReflejar As String)
        Dim js As String
        js = "var loadingPanel; "
        js &= "loadingPanel = $find('" & sIDLoadingPanel & "');"
        js &= "loadingPanel.hide('" & sIDControlReflejar & "');"

        ScriptManager.RegisterClientScriptBlock(udpCBJquery, objPage.GetType, Guid.NewGuid.ToString, js, True)
    End Sub


#End Region


    'Sub ExportarDataTableExcel(dt As DataTable, NombreArchivoExcel As String, sUsuario As String, webPage As Page)
    '    Dim objDes As New clsAnceDe.AnceSystems.clsDesencriptar
    '    Dim sRutaXLS As String = objDes.DesEncriptarCadena(ConfigurationManager.AppSettings("RutaConsultasExport").Replace("°°", "&"))
    '    Dim ep As New ExcelPackage
    '    Dim ew As ExcelWorksheet
    '    Dim numCol As Integer

    '    Try


    '        Using objArchivoTem As New clssArchTemp
    '            objArchivoTem.DiasPlazoLimpiar = 1
    '            objArchivoTem.PatronBusqArchivoLimpiar = ".xlsx"
    '            objArchivoTem.RutaDirDocTemp = sRutaXLS
    '            objArchivoTem.LimpiarDirectorioTemp()
    '        End Using

    '        If Not Directory.Exists(sRutaXLS) Then
    '            Directory.CreateDirectory(sRutaXLS)
    '        End If

    '        NombreArchivoExcel &= "_" & sUsuario & "_" & Format(Now, "dd_MM_yyyy_hhmmss")
    '        sRutaXLS = objDes.DesEncriptarCadena(ConfigurationManager.AppSettings("RutaConsultasExport").Replace("°°", "&")) & "\" & NombreArchivoExcel & ".xlsx"

    '        ep.Workbook.Worksheets.Add("DatosExportados")
    '        ew = ep.Workbook.Worksheets(1)

    '        numCol = dt.Columns.Count

    '        ew.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
    '        ew.Row(1).Style.Font.Bold = True
    '        ew.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid
    '        ew.Row(1).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(230, 230, 230))
    '        ew.Cells("A1").LoadFromDataTable(dt, True)

    '        ep.SaveAs(New FileInfo(sRutaXLS))

    '        Using objDoctoSeguro As New clssLinkDocSeguro
    '            objDoctoSeguro.bConvertPDF = False
    '            objDoctoSeguro.sAliasDocto = NombreArchivoExcel
    '            objDoctoSeguro.sRutaFisica = sRutaXLS
    '            objDoctoSeguro.sSesion = sUsuario
    '            objDoctoSeguro.CifrarUrl()
    '            ScriptManager.RegisterClientScriptBlock(webPage, webPage.GetType(), Guid.NewGuid.ToString, objDoctoSeguro.sScriptAbrirDoc, False)
    '        End Using

    '    Catch ex As Exception

    '        RegistrarError(ex)
    '        MsgJquery(webPage, "Problemas al exportar la consulta solicitada, favor de intentar nuevamente.", "..:: Exportación de consulta no disponible ::..")

    '    End Try

    'End Sub



    Public Function EliminaExtensionNombreDocto(sNombreDocto As String) As String
        Dim sRespuesta As String = ""
        Try
            If Not sNombreDocto Is Nothing Then
                sRespuesta = sNombreDocto.Replace("." & sNombreDocto.Split(".")(sNombreDocto.Split(".").Length - 1), "")
            End If
        Catch ex As Exception
            RegistrarError(ex)
        End Try
        Return sRespuesta
    End Function
#Region "RadMsgBox" 'jalopez 20161013


    Public Sub RadMsgBox(radWinManager As RadWindowManager, Mensaje As clssMensaje)
        Mensaje.Mensaje = Mensaje.Mensaje.Replace("'", "")
        Mensaje.Alto = CalcularAlto(Mensaje.Alto, Mensaje.Mensaje)
        radWinManager.RadAlert(Mensaje.Mensaje, Mensaje.Ancho, Mensaje.Alto, Mensaje.Titulo, Nothing, Mensaje.IconosMessage(Mensaje.Icono))
    End Sub


    Public Sub RadMsgBox(radWinManager As RadWindowManager, Mensaje As clssMensaje, objExeption As Exception)

        Dim sMensaje As String = Mensaje.Mensaje

#If DEBUG Then
        sMensaje = objExeption.Message
#End If
        Mensaje.Alto = CalcularAlto(Mensaje.Alto, sMensaje)
        RegistrarError(objExeption)

        sMensaje = sMensaje.Replace("'", "")
        radWinManager.RadAlert(Mensaje.Mensaje, Mensaje.Ancho, Mensaje.Alto, Mensaje.Titulo, Nothing, Mensaje.IconosMessage(Mensaje.Icono))
    End Sub

    Public Sub RadMsgBox(radWinManager As RadWindowManager, Msg As String, Titulo As String, Icono As clssMensaje.eImgMessage, objExeption As Exception)
        Dim objMsg As New clssMensaje

        objMsg.Mensaje = Msg
        objMsg.Titulo = Titulo
        objMsg.Icono = Icono


#If DEBUG Then
        objMsg.Mensaje = Replace(objExeption.Message, "'", "").Replace("""", "")
#End If

        objMsg.Alto = CalcularAlto(objMsg.Alto, objMsg.Mensaje)
        RegistrarError(objExeption)

        objMsg.Mensaje = objMsg.Mensaje.Replace("'", "").Replace(vbCrLf, "")
        radWinManager.RadAlert(objMsg.Mensaje, objMsg.Ancho, objMsg.Alto, objMsg.Titulo, Nothing, objMsg.IconosMessage(objMsg.Icono))
    End Sub

    Public Sub RadMsgBox(radWinManager As RadWindowManager, Msg As String, Titulo As String, Icono As clssMensaje.eImgMessage)
        Dim objMsg As New clssMensaje

        objMsg.Mensaje = Msg
        objMsg.Titulo = Titulo
        objMsg.Icono = Icono


        objMsg.Alto = CalcularAlto(objMsg.Alto, objMsg.Mensaje)
        radWinManager.RadAlert(objMsg.Mensaje, objMsg.Ancho, objMsg.Alto, objMsg.Titulo, Nothing, objMsg.IconosMessage(objMsg.Icono))
    End Sub


    Public Sub RadMsgBoxConfirm(radWinManager As RadWindowManager, Msg As String, Titulo As String, sFuncionEjecutar As String, oCaller As Object, Icono As clssMensaje.eImgMessage)
        Dim objMsg As New clssMensaje

        objMsg.Mensaje = Msg
        objMsg.Titulo = Titulo
        objMsg.Icono = Icono

        objMsg.Alto = CalcularAlto(objMsg.Alto, objMsg.Mensaje)
        AsignaLocalizacionWindowManager(radWinManager)
        radWinManager.RadConfirm(objMsg.Mensaje, sFuncionEjecutar, objMsg.Ancho, objMsg.Alto, oCaller, objMsg.Titulo, objMsg.IconosMessage(objMsg.Icono))
    End Sub

    Public Sub RadMsgBoxWinParent(Obj As Object, Msg As String, Titulo As String, Icono As clssMensaje.eImgMessage, Optional objException As Exception = Nothing)
        Dim js As String
        Dim sIcono As String = ""

        Select Case Icono
            Case clssMensaje.eImgMessage.Alert
                sIcono = "Warnning"
            Case clssMensaje.eImgMessage.Information
                sIcono = "Info"
            Case clssMensaje.eImgMessage.Question
                sIcono = "Question"
            Case clssMensaje.eImgMessage.Error
                sIcono = "Error"
            Case clssMensaje.eImgMessage.Nothing
                sIcono = ""
        End Select

        If Not objException Is Nothing Then
            RegistrarError(objException)

#If DEBUG Then
            Msg = objException.Message
#End If

        End If

        Msg = Msg.Replace("'", "").Replace("""", "").Replace(vbCrLf, "")

        js = "window.parent.RadMsgBox('" & Msg & "','" & Titulo & "','" & sIcono & "');"

        ScriptManager.RegisterClientScriptBlock(Obj, Obj.GetType, Guid.NewGuid.ToString, js, True)

    End Sub


    Public Sub bsMsgBox(Obj As Object, Msg As String, Titulo As String, Icono As clssMensaje.eImgMessage, Optional objException As Exception = Nothing)
        Dim js As String
        Dim sIcono As String = ""

        Select Case Icono
            Case clssMensaje.eImgMessage.Alert
                sIcono = "Warnning"
            Case clssMensaje.eImgMessage.Information
                sIcono = "Info"
            Case clssMensaje.eImgMessage.Question
                sIcono = "Question"
            Case clssMensaje.eImgMessage.Error
                sIcono = "Error"
            Case clssMensaje.eImgMessage.Nothing
                sIcono = ""
        End Select

        If Not objException Is Nothing Then
            RegistrarError(objException)

#If DEBUG Then
            Msg = objException.Message
#End If

        End If

        Msg = Msg.Replace("'", "").Replace("""", "").Replace(vbCrLf, "")

        js = "$(document).ready(function(){ bsMsgBox('" & Msg & "','" & Titulo & "','" & sIcono & "')});"

        ScriptManager.RegisterClientScriptBlock(Obj, Obj.GetType, Guid.NewGuid.ToString, js, True)

    End Sub



    Private Function CalcularAlto(Alto As Integer, Mensaje As String) As Integer
        If Mensaje.Length > 70 Then
            REM cada  35 aumentar 17 px siempre y cuando se respete lo ancho del mensaje
            Alto = Alto + ((Mensaje.Length - 70) / 35 + 1) * 17
        End If

        Return Alto
    End Function

    Public Sub CerrarVentanasAlert(radWinManager As RadWindowManager)
        radWinManager.Windows.Clear()
    End Sub

#End Region

End Module
