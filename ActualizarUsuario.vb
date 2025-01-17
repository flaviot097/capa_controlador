Imports System.IO
Imports System.Net
Imports System.Xml

Public Class ActualizarUsuario
    Public Function actualizaPorId(id As Integer, nombre As String, contrasena As String) As String

        Dim urlServico As String = "https://localhost:44337/servicioweb.asmx"
        Dim soapAccion As String = "http://servicioweb.com/miServicio/ActualizarUsuario"

        Dim xmlRequest As String = $"<?xml version=""1.0"" encoding=""utf-8""?>
                                        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                                                       xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                                                       xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                                          <soap:Body>
                                            <ActualizarUsuario xmlns=""http://servicioweb.com/miServicio"">
                                              <id>{id}</id>
                                              <nombre>{nombre}</nombre>
                                              <contrasena>{contrasena}</contrasena>
                                            </ActualizarUsuario>
                                          </soap:Body>
                                        </soap:Envelope>"

        Dim solisitud As HttpWebRequest = CType(WebRequest.Create(urlServico), HttpWebRequest)

        solisitud.Method = "POST"
        solisitud.ContentType = "text/xml; charset=utf-8"
        solisitud.Headers.Add("SOAPAction", soapAccion)

        Dim pasarByte As Byte() = Encoding.UTF8.GetBytes(xmlRequest)
        solisitud.ContentLength = pasarByte.Length

        Using stream As Stream = solisitud.GetRequestStream()
            stream.Write(pasarByte, 0, pasarByte.Length)
        End Using

        Dim respuesta As WebResponse = solisitud.GetResponse()
        Using streamRespuesta As Stream = respuesta.GetResponseStream()

            Dim documentoXml As New XmlDocument()
            documentoXml.Load(streamRespuesta)

            Dim nodoXmlRespuesta As XmlNodeList = documentoXml.GetElementsByTagName("Resultado_de_actualiazar") 'documentoXml.SelectSingleNode("Resultado_de_actualiazar")
            For Each respuestaPeticion As XmlNode In nodoXmlRespuesta

                If respuestaPeticion IsNot Nothing Then
                    Return respuestaPeticion.InnerText
                End If
            Next


        End Using


    End Function
End Class
