Imports System.Threading
Imports System.Globalization

Class clssLinkDocSeguro
    Implements IDisposable

    Public sUrl As String
    Public sRutaFisica As String
    Public sSesion As String
    Public sScriptAbrirDoc As String
    Public bConvertPDF As Boolean = False
    Public bMarcaAgua As Boolean = False
    Public bPermisoImpre As Boolean = False
    Public bProtegido As Boolean = False
    Public sConfigMarcaAgua As String = ""
    Public sAliasDocto As String = ""


    Sub CifrarUrl()
        Dim objBox As New clsBoxing.Maple.clsBoxing
        Dim objDe As New clsAnceDe.AnceSystems.clsDesencriptar
        Dim sKey As String
        Dim sPrf As String
        Dim sPase As String
        Dim sConfig As String


        sKey = (objDe.DesEncriptarCadena(ConfigurationManager.AppSettings("RAC1").ToString().Replace("°°", "&").Replace("°-°", "<").Replace("|-|", ">")))
        sPrf = (objDe.DesEncriptarCadena(ConfigurationManager.AppSettings("Prl").ToString().Replace("°°", "&").Replace("°-°", "<").Replace("|-|", ">")))
        sUrl = (objDe.DesEncriptarCadena(ConfigurationManager.AppSettings("BaseDescarga").ToString().Replace("°°", "&").Replace("°-°", "<").Replace("|-|", ">")))

        sPase = objBox.Boxing(sKey, CrearCadena(ConfigurationManager.AppSettings("IdSistema").ToString(), sPrf))
        sConfig = objBox.Boxing(sKey, CrearConfig(sSesion, sRutaFisica))

        sUrl = sUrl & "?PRL=" & sPase & "&CNF=" & sConfig

        sScriptAbrirDoc = "<script>$(function () {window.open('" & sUrl & "')});</script>"

        objBox = Nothing
        objDe = Nothing
    End Sub

    Private Function CrearCadena(ByVal sSistema As Integer, ByVal sCad As String) As String
        Thread.CurrentThread.CurrentCulture = New CultureInfo("es-MX")
        Dim sXML As String

        sXML = "<?xml version='1.0' encoding='utf-8'?>" & _
                "<Datos IdSistema='" & sSistema & "'>" & _
                    "<Perfil>" & _
                        sCad & _
                    "</Perfil>" & _
                    "<FechaHora>" & _
                         Now.ToString & _
                    "</FechaHora>" & _
                "</Datos>"

        Return sXML

    End Function

    ''' <summary>
    ''' Configuracion especifica para abrir un documento
    ''' </summary>
    ''' <param name="sUsr">Id de Usuario actual</param>
    ''' <param name="sRuta">Ruta del documento que se desea abrir</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CrearConfig(ByVal sUsr As String, ByVal sRuta As String) As String

        Dim sXML As String

        sUsr = sUsr.Replace("&", "&amp;")

        sXML = "<Config><Datos Session='{0}' CovertPDF='{1}' MarcaAgua='{2}' PermisoImpre='{3}' Protegido='{4}' RutaOrigen='{5}' ConfigMarcaAgua='{6}' AliasDocto='{7}' /></Config>"
        sXML = sXML.Replace("{0}", sUsr)
        sXML = sXML.Replace("{1}", IIf(bConvertPDF, "True", "False"))
        sXML = sXML.Replace("{2}", IIf(bMarcaAgua, "True", "False"))
        sXML = sXML.Replace("{3}", IIf(bPermisoImpre, "True", "False"))
        sXML = sXML.Replace("{4}", IIf(bProtegido, "True", "False"))
        sXML = sXML.Replace("{5}", sRuta)
        sXML = sXML.Replace("{6}", sConfigMarcaAgua)
        sXML = sXML.Replace("{7}", sAliasDocto.Trim)

        Return sXML

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
