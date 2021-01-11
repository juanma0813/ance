Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class clssConverArchImgAByte
    Implements IDisposable

    Public Property bError As Boolean
    Public Property byteImg As Byte()
    Public Property uException As Exception
    Public Property BmpResize As Bitmap


    Function ConvertReSizeArchImgAByte(RutaArchImagen As String, Width As Integer, Height As Integer, FormatoImagen As ImageFormat) As Byte()
        bError = False
        Try
            If File.Exists(RutaArchImagen) Then
                Dim fs As New FileStream(RutaArchImagen, FileMode.Open)
                Dim bmpSource As New Bitmap(fs)
                Dim bmDest As New Drawing.Bitmap(Width, Height, Drawing.Imaging.PixelFormat.Format32bppArgb)

                Dim grap As Drawing.Graphics = Drawing.Graphics.FromImage(bmDest)
                grap.Clear(Drawing.Color.White)


                Dim nSourceAspectRatio = bmpSource.Width / bmpSource.Height
                Dim nDestAspectRatio = bmDest.Width / bmDest.Height

                Dim NewX = 0
                Dim NewY = 0
                Dim NewWidth = bmDest.Width
                Dim NewHeight = bmDest.Height

                If nDestAspectRatio = nSourceAspectRatio Then
                    'same ratio
                ElseIf nDestAspectRatio > nSourceAspectRatio Then
                    'Source is taller
                    NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
                    NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
                Else
                    'Source is wider
                    NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
                    NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
                End If

                Using grDest = Drawing.Graphics.FromImage(bmDest)
                    With grDest
                        .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                        .InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                        .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.HighQuality
                        .SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
                        .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceOver

                        .DrawImage(bmpSource, NewX, NewY, NewWidth, NewHeight)
                    End With
                End Using


                'BmpResize = New Bitmap(bmp, New Size(Width, Height))

                Using ms As New MemoryStream
                    bmDest.Save(ms, FormatoImagen)
                    byteImg = ms.ToArray
                    Return ms.ToArray
                End Using
            End If
            Return Nothing
        Catch ex As Exception
            bError = True
            uException = ex
            Elmah.ErrorSignal.FromCurrentContext().Raise(ex)
            Return Nothing
        End Try
    End Function


    Function ConvertArchImgAByte(RutaArchImagen As String) As Byte()
        bError = False
        Try


            Dim fImg As FileInfo
            Dim i As Integer = 0

            fImg = New FileInfo(RutaArchImagen)

            If File.Exists(RutaArchImagen) Then
                Dim fs As New FileStream(RutaArchImagen, FileMode.Open)
                Dim br As New BinaryReader(fs)
                Dim imgbyte As Byte() = New Byte(fs.Length + 1) {}

                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)))

                br.Close()
                fs.Close()

                byteImg = imgbyte

                Return imgbyte

            End If


            Return Nothing
        Catch ex As Exception
            bError = True
            uException = ex
            Elmah.ErrorSignal.FromCurrentContext().Raise(ex)
            Return Nothing
        End Try

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
