Imports System.IO
Imports System.Net
Imports System.Xml

Public Class Controlador_Consulta_post
    Public Function CrearUsuario(nombre As String, contrasena As String) As String

        Try
            'url de WebService
            Dim urlServico As String = "https://localhost:44337/servicioweb.asmx"

            'URL accion de WebService de crear usuario 
            Dim soapAction As String = "http://servicioweb.com/miServicio/crearUsuario"

            'xml a enviar con la peticion
            Dim xmlRequest As String = $"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                                                       xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                                                       xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                                          <soap:Body>
                                            <crearUsuario xmlns=""http://servicioweb.com/miServicio"">
                                              <nombre>{nombre}</nombre>
                                              <contrasena>{contrasena}</contrasena>
                                            </crearUsuario>
                                          </soap:Body>
                                        </soap:Envelope>"

            'creo un petecion a mi web service y defino el metodo , tipo de contenido ,etc (Escribo el encabezado)
            Dim request As HttpWebRequest = CType(WebRequest.Create(urlServico), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "text/xml; charset=utf-8"
            request.Headers.Add("SOAPAction", soapAction)

            ' Escribir el cuerpo de la solicitud
            Dim byteData As Byte() = Encoding.UTF8.GetBytes(xmlRequest)
            request.ContentLength = byteData.Length

            'Using requestStream As Stream = request.GetRequestStream()
            'requestStream.Write(byteData, 0, byteData.Length)
            'End Using

            'Obtengo un flujo para escribir el cuerpo de la solicitud HTTP
            Dim requestStream As Stream = Nothing
            'preparo la consulta 
            requestStream = request.GetRequestStream()
            'inserto la consulta escrita y hago la peticion
            requestStream.Write(byteData, 0, byteData.Length)


            ' Leer la respuesta
            Dim response As WebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                Return reader.ReadToEnd()
            End Using

        Catch ex As Exception
            Dim mensaje = "error al crear usuario. ERROR:" & ex.Message
            Return mensaje
        End Try
    End Function
End Class
