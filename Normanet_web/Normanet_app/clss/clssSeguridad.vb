Imports clsSistemasGruposModulos.AnceSystem
Imports System.Net
Imports System.Web.HttpRequest
Imports System.Web.HttpContext

Namespace AnceSystems

    Public Class clssSesion
        Inherits System.Web.UI.Page

        Public Property Usuario As String
        Public Property IdArea As String
        Public Property IdGrupo As String


        Private _VarSesion

        Public Property VarSesion As String
            Get
                Return _VarSesion
            End Get
            Set(ByVal value As String)
                Dim Sesion() As String

                Sesion = Split(value, "|")
                If Sesion.Length = 3 Then
                    Usuario = Sesion(0).ToString
                    IdArea = Sesion(1).ToString
                    IdGrupo = Sesion(2).ToString
                    _VarSesion = value
                End If

            End Set
        End Property
    End Class
    Public Class clssValidaAcceso
        Implements IDisposable

        Property sSession As String
        ''' <summary>
        ''' Valida que el usuario actual tenga los permisos de acceso a un modulo en especifico
        ''' </summary>
        ''' <param name="objSesion">Recibe una variable de sesion donde se alamacenera el dato del usuario al que se le permite el acceso</param>
        ''' <param name="objSessionParams">Recibe una variable de sesion donde se alamacenara los datos de IP y HOSTNAME</param>
        ''' <param name="objRequest">Se necesita el objeto Request desde donde se invoca el metodo</param>
        ''' <param name="Pagina">Se necesita el objeto Page de la pagina desde donde se invoca el metodo</param>
        ''' <param name="sIdSistema">Se puede especificar el Id sistema para determinar el acceso, si no se especifica este valor lo toma del Web.Config (IdSistema)</param>
        ''' <remarks></remarks>
        Public Shared Sub ValidaAcceso(ByRef objSesion As Object, ByRef objSessionParams As Object, objRequest As HttpRequest, Pagina As Page, Optional ByVal sIdSistema As String = "")
            Dim Userstring As String = ""
            Dim bRespuesta As Boolean = False
            REM Dim objname As IPHostEntry
            Dim sIdUsuario As String

            sIdUsuario = objRequest.ServerVariables("AUTH_USER")
            objSessionParams = objRequest.ServerVariables("REMOTE_ADDR").ToString

            If sIdSistema = "" Then
                sIdSistema = ConfigurationManager.AppSettings("IdSistema").ToString
            End If

#If DEBUG Then
            sIdUsuario = "jalopez" 'quitar
#Else
            REM sIdUsuario = "jalopez" 'quitar
#End If

            Try
                Userstring = LimpiaUsr(sIdUsuario)
                REM objname = Dns.GetHostEntry(objSessionParams)
                Using ValAcc As New clssSistemasGruposModulos("cnComun")
                    If ValAcc.ValidaAcceso(sIdSistema, Userstring, Pagina.AppRelativeVirtualPath.Replace(Pagina.AppRelativeTemplateSourceDirectory, "")) Then
                        Userstring = Userstring
                        bRespuesta = True
                    Else
                        Userstring = ""
                        bRespuesta = False
                    End If

                    If ValAcc.bError Then
                        MsgJquery(Pagina, ValAcc.uException.Message, "Err")
                    End If

                End Using
                objSesion = Userstring

                REM objSessionParams = objSessionParams & "|" & objname.HostName

                If bRespuesta = False Then
                    Pagina.Response.Redirect(ConfigurationManager.AppSettings("PaginaRestringida"), False)
                End If

            Catch ex As Exception

                objSesion = Userstring
                objSessionParams = objSessionParams & "|" & "Sin HostName"

                Elmah.ErrorSignal.FromCurrentContext().Raise(ex)
                Pagina.Response.Redirect(ConfigurationManager.AppSettings("PaginaRestringida"), False)
            End Try

        End Sub
        Shared Function LimpiaUsr(ByVal ssUsr As String) As String
            Dim sUsr As String
            ssUsr = ssUsr.ToLower
            sUsr = Trim(Replace(ssUsr, "ancemx\", ""))
            sUsr = Replace(sUsr, "anceapd\", "")
            sUsr = Replace(sUsr, "ancegdl\", "")
            sUsr = Replace(sUsr, "@gdl.ance.org.mx", "")
            sUsr = Replace(sUsr, "@apd.ance.org.mx", "")
            sUsr = Replace(sUsr, "@ance.org.mx", "")
            Return sUsr
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
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region


    End Class

End Namespace