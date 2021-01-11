Imports System.Xml.Serialization
Imports System.Text
Imports System.IO


Public Class clssDatosLigaXML
    Implements IDisposable


    Public Property objParam As Object
    Public Property sXml As String
    Public Property sNomParamQry As String = "dat"
    Public Property sLiga As String
    Public Property bValido As Boolean
    Public Property sdat As String

    Function SerializarXML() As String
        Dim objxml As New XmlSerializer(objParam.GetType())
        Dim xstream As New StringWriter

        objxml.Serialize(xstream, objParam)
        sXml = xstream.GetStringBuilder.ToString
        Return sXml
    End Function

    Sub DeserializarXML()
        Dim objxml As New XmlSerializer(objParam.GetType())

        If sXml <> "" Then
            objParam = objxml.Deserialize(New StringReader(sXml))
        End If
    End Sub

    Public Function GeneraLigaEncript(sPaginaWeb As String) As String
        Dim sResp As String
        Using objBox As New clsBoxing.Maple.clsBoxing
            Dim sKey As String = ConfigurationManager.AppSettings("RAC1").ToString().Replace("°°", "&").Replace("°-°", "<").Replace("|-|", ">")
            Using ObjDe As New clsAnceDe.AnceSystems.clsDesencriptar
                sKey = ObjDe.DesEncriptarCadena(sKey)
            End Using


            sdat = objBox.Boxing(sKey, sXml)

            sResp = sPaginaWeb & "?" & sNomParamQry & "=" & sdat.Replace("+", " ")
            sLiga = sResp
        End Using

        Return sResp
    End Function


    Public Function DesEncriptarDatos(ByVal sDato As String) As String
        Dim sDatos As String = ""

        Try
            Using objUnBoxin As New clsBoxing.Maple.clsUnBoxing
                Using objDe As New clsAnceDe.AnceSystems.clsDesencriptar
                    Dim sKey As String
                    sKey = (objDe.DesEncriptarCadena(ConfigurationManager.AppSettings("RAC2").ToString().Replace("°°", "&").Replace("°-°", "<").Replace("|-|", ">")))
                    sDatos = objUnBoxin.UnBoxing(sKey, sDato.Replace(" ", "+"))
                End Using
            End Using

            Return sDatos

        Catch ex As Exception
            RegistrarError(ex)
            Return ""
        End Try

    End Function


    Public Sub DescifrarLiga(sDato As String, ByRef objClassParamDest As Object)
        bValido = False

        Try
            objParam = objClassParamDest
            sXml = DesEncriptarDatos(sDato)

            If sXml <> "" Then
                DeserializarXML()
                objClassParamDest = objParam
                bValido = True
            Else
                objClassParamDest = Nothing
                bValido = False
            End If

        Catch ex As Exception
            objClassParamDest = Nothing
            bValido = False
            RegistrarError(ex)
        End Try

    End Sub


    Function ZipString(Valor As String) As String
        Dim byteArray As Byte() = New Byte(Valor.Length) {}
        Dim indexBA As Integer = 0


        For Each item As Char In Valor.ToCharArray()

            indexBA += 1
            byteArray(indexBA) = CByte(AscW(item))

        Next

        'Prepare for compress
        Dim ms As New System.IO.MemoryStream()
        Dim sw As New System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress)

        'Compress
        sw.Write(byteArray, 0, byteArray.Length)
        'Close, DO NOT FLUSH cause bytes will go missing...
        sw.Close()

        'Transform byte[] zip data to string
        byteArray = ms.ToArray()
        Dim sB As New System.Text.StringBuilder(byteArray.Length)
        For Each item As Byte In byteArray
            sB.Append(ChrW(item))
        Next
        ms.Close()
        sw.Dispose()
        ms.Dispose()
        Return sB.ToString()

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
