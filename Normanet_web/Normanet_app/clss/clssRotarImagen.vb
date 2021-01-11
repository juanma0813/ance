Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging.ImageFormat
Imports System.IO

Public Class clssRotarImagen
    Implements IDisposable

    Public Property RutaImagenOrig As String
    Public Property RutaImagenDest As String
    Public Property NomImagenDest As String
    Public Property img As Image
    Private Property objArchTemp As New clssArchTemp
    Public Property PatronLimpiar As String = "*.jpg"
    Public Property uException As Exception
    Public Property bError As Boolean
    Public Property ImgFormat As ImageFormat
    Public Property ImgEncoder As Encoder
    Public Property LevelQuality As Int32
    Public Property sKeyWebConfigRutaDocTemp As String = "RutaDocsTemporal"
    Public Property RutaCompletaImgDest As String


    Private _sCarpTempTrabajo As String = ""
    Public Property sCarpTempTrabajo() As String
        Get
            Return _sCarpTempTrabajo
        End Get
        Set(ByVal value As String)
            objArchTemp.RutaDirDocTemp = Path.Combine(DesEncriptarKeyWebConfig(sKeyWebConfigRutaDocTemp), value)
            RutaImagenDest = Path.Combine(DesEncriptarKeyWebConfig(sKeyWebConfigRutaDocTemp), value)
            _sCarpTempTrabajo = value
        End Set
    End Property


    Sub New()
        objArchTemp.RutaDirDocTemp = Path.Combine(DesEncriptarKeyWebConfig(sKeyWebConfigRutaDocTemp), sCarpTempTrabajo)
        RutaImagenDest = Path.Combine(DesEncriptarKeyWebConfig(sKeyWebConfigRutaDocTemp), sCarpTempTrabajo)
        ImgEncoder = Encoder.Quality
        LevelQuality = 75L
        ImgFormat = ImageFormat.Jpeg
    End Sub

    Sub CalcularNomArchDest()

        Try
            bError = False
            Dim ArchImgInfo As New FileInfo(RutaImagenOrig)

            objArchTemp.NomDocOriginal = ArchImgInfo.Name
            objArchTemp.CalcularNomDocTemp()

            NomImagenDest = objArchTemp.NomDocTemp.Name
        Catch ex As Exception
            bError = True
            uException = ex
        End Try

    End Sub

    Sub RotarImagen()
        Try

            If Not Directory.Exists(RutaImagenDest) Then
                Directory.CreateDirectory(RutaImagenDest)
            End If

            Dim myImageCodecInfo As ImageCodecInfo
            Dim myEncoderParameter As EncoderParameter
            Dim myEncoderParameters As EncoderParameters

            bError = False
            img = System.Drawing.Image.FromFile(RutaImagenOrig)

            img.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipXY)


            myEncoderParameters = New EncoderParameters(1)
            myImageCodecInfo = GetEncoderInfo(ImgFormat)

            ' Save the bitmap as a JPEG file with quality level 75.
            myEncoderParameter = New EncoderParameter(ImgEncoder, CType(LevelQuality, Int32))
            myEncoderParameters.Param(0) = myEncoderParameter

            RutaCompletaImgDest = Path.Combine(RutaImagenDest, NomImagenDest)
            img.Save(RutaCompletaImgDest, myImageCodecInfo, myEncoderParameters)

            img.Dispose()
        Catch ex As Exception
            bError = True
            uException = ex
        End Try
    End Sub

    Private Shared Function GetEncoderInfo(ByVal format As ImageFormat) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        j = 0
        While j < encoders.Length
            If encoders(j).FormatID = format.Guid Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function 'GetEncoderInfo

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
