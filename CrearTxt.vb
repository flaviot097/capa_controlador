Imports System.IO

Public Class CrearTxt
    Sub Main()
        ' Escribir en un archivo
        Dim filePath As String = "C:\archivo.txt"
        'en la funcion FileStream recibe la ruta ,la funciones de crear y la de escribir
        Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes("Hola, mundo!")
            fs.Write(data, 0, data.Length)
        End Using

        ' Leer del archivo                FileStream recibe la ruta la funcion de abrir el archivo y de lerlo
        Using fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer = fs.Read(buffer, 0, buffer.Length)
            Dim contenido As String = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead)
            Console.WriteLine(contenido)
        End Using
    End Sub
End Class
