Imports System.IO

Public Class clssArchTemp
    Implements IDisposable

    Public Property RutaDirDocTemp As String
    Public Property NomDocOriginal As String
    Public Property NomDocTemp As FileInfo
    Public Property opPatronBusq As SearchOption = SearchOption.TopDirectoryOnly

    Sub New()

    End Sub

    Sub CalcularNomDocTemp()
        Dim NomDocOriginalAux As New FileInfo(NomDocOriginal)




        NomDocTemp = New FileInfo(Path.GetTempFileName().Replace(".tmp", NomDocOriginalAux.Extension))

        If Not Directory.Exists(RutaDirDocTemp) Then
            Directory.CreateDirectory(RutaDirDocTemp)
        End If

        _RutaArchDocTempCalc = Path.Combine(RutaDirDocTemp, NomDocTemp.Name)
    End Sub


    Private _RutaArchDocTempCalc As String
    Public ReadOnly Property RutaArchDocTempCalc() As String
        Get
            Return _RutaArchDocTempCalc
        End Get
    End Property


    ''' <summary>
    ''' Establece el plazo en dias, en los que los archivos deberan ser eliminados
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DiasPlazoLimpiar As Integer = 1

    Public Property PatronBusqArchivoLimpiar As String = "*.pdf"

    Sub LimpiarDirectorioTemp()

        Try

            Dim objDir As New DirectoryInfo(RutaDirDocTemp)
            Dim objArch() As IO.FileSystemInfo
            Dim FechaArch As Date
            Dim Patrones() As String


            Patrones = Split(PatronBusqArchivoLimpiar, "|")

            For Each spatron As String In Patrones
                objArch = objDir.GetFiles(spatron, opPatronBusq)

                For Each fArch In objArch
                    FechaArch = fArch.CreationTime

                    If FechaArch.AddDays(DiasPlazoLimpiar) < Now Then
                        Try
                            fArch.Delete()
                        Catch ex As Exception

                        End Try
                    End If
                Next


            Next

            Dim FechDir As Date

            For Each objSubDir In objDir.GetDirectories("*.*", SearchOption.AllDirectories)
                FechDir = objSubDir.CreationTime

                If FechDir.AddDays(DiasPlazoLimpiar) < Now Then
                    If objSubDir.GetFiles.Length = 0 Then
                        Try
                            objSubDir.Delete()
                        Catch ex As Exception

                        End Try
                    End If


                End If

            Next

            ''Elimina los archivos temporales propios del sistema operativo
            objDir = New DirectoryInfo(Path.GetTempPath)
            objArch = objDir.GetFiles("*.tmp", opPatronBusq)

            For Each fArch In objArch
                FechaArch = fArch.CreationTime

                If FechaArch.AddDays(DiasPlazoLimpiar) < Now Then
                    Try
                        fArch.Delete()
                    Catch ex As Exception

                    End Try
                End If
            Next

        Catch ex As Exception

        End Try

    End Sub


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
