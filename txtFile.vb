Imports Microsoft.SqlServer
Imports System.IO.Directory
Imports System.IO.Path
Public Class txtFile

    'funcion que recibe un archivo de crea un archivo en el servidor
    Public Function GuardarArchivo(fileUpload As HttpPostedFile) As String
            Try
                If fileUpload IsNot Nothing AndAlso fileUpload.ContentLength > 0 Then
                ' Ruta de almacenamiento
                Dim savePath As String = HttpContext.Current.Server.MapPath("~/archivosCarpeta/")

                ' Verifica si la carpeta existe, si no, la crea
                If Not Exists(savePath) Then
                    CreateDirectory(savePath)
                End If

                ' Nombre del archivo  con GerFileName se consulata el nombre original de el archivo
                Dim fileName As String = GetFileName(fileUpload.FileName)

                ' Ruta completa           se crea la ruta donde se guardara el archivo
                Dim fullPath As String = Combine(savePath, fileName)

                ' Guarda el archivo          se recoge el archivo y se guarda en la ruta especificada
                fileUpload.SaveAs(fullPath)

                    ' Retorna éxito
                    Return "Archivo subido correctamente a: " & fullPath
                Else
                    Return "No se seleccionó un archivo válido."
                End If
            Catch ex As Exception
                Return "Error al subir el archivo: " & ex.Message
            End Try
        End Function


    'Protected Function CrearTxt(archivo)
    '    ' Verifica si se seleccionó un archivo

    '    Try
    '        ' Carpeta donde se guardará el archivo
    '        Dim savePath As String = Server.MapPath("~/subidas/")

    '        ' Verifica si la carpeta existe, si no, la crea
    '        If Not System.IO.Directory.Exists(savePath) Then
    '            System.IO.Directory.CreateDirectory(savePath)
    '        End If

    '        ' Nombre del archivo
    '        Dim fileName As String = System.IO.Path.GetFileName(archivo.FileName)

    '        ' Ruta completa del archivo
    '        Dim fullPath As String = System.IO.Path.Combine(savePath, fileName)

    '        ' Guarda el archivo en la ruta especificada
    '        archivo.SaveAs(fullPath)

    '        ' Mensaje de éxito
    '        archivo.Text = "Archivo subido correctamente: " & fileName
    '    Catch ex As Exception
    '        ' Mensaje de error

    '    End Try
    'End Function

End Class
