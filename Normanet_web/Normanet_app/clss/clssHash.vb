Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class clssHash
    Implements IDisposable

    Public Property RutaArchivo As String
    Public Property CodigoHashBytesArray As Byte()

    Function GenerarCodigoHashArchivo() As Byte()
        Dim ArchStream As New FileStream(RutaArchivo, FileMode.Open)
        Dim AlgoritmoHash As New SHA512Managed

        CodigoHashBytesArray = AlgoritmoHash.ComputeHash(ArchStream)

        AlgoritmoHash.Clear()

        ArchStream.Close()
        Return CodigoHashBytesArray
    End Function

    Function CompararCodigoHash(CodHash01 As Byte(), CodHash02 As Byte()) As Boolean

        If String.Compare(BitConverter.ToString(CodHash01, 0), BitConverter.ToString(CodHash02, 0)) <> 0 Then
            Return False
        Else
            Return True
        End If

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
