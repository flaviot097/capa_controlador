Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Runtime.Remoting.Metadata
Imports System.Xml
Public Class ConsultarTodos

    Public Function GetTodos() As List(Of Usuario)

        Dim stringCadenaUsuarios As String
        Dim lista As New List(Of Usuario)()


        Dim urlServicio As String = "https://localhost:44337/servicioweb.asmx"
        Dim soapAction As String = "http://servicioweb.com/miServicio/CrearConsulta"

        Dim XmlParametrosconsulta As String = "<?xml version=""1.0"" encoding=""utf-8""?>
                                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                                               xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                                               xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                                  <soap:Body>
                                    <CrearConsulta xmlns=""http://servicioweb.com/miServicio"" />
                                  </soap:Body>
                                </soap:Envelope>"

        Dim consulta As HttpWebRequest = CType(WebRequest.Create(urlServicio), HttpWebRequest)
        consulta.Method = "POST"
        consulta.ContentType = "text/xml; charset=utf-8"
        consulta.Headers.Add("SOAPAction", soapAction)


        Dim byteData As Byte() = Encoding.UTF8.GetBytes(XmlParametrosconsulta)
        consulta.ContentLength = byteData.Length

        Using streamConsulta As Stream = consulta.GetRequestStream()
            streamConsulta.Write(byteData, 0, byteData.Length)
        End Using

        Dim respuesta As HttpWebResponse = CType(consulta.GetResponse(), HttpWebResponse)

        Using respuestaDecodificada As New StreamReader(respuesta.GetResponseStream)
            'lee todo el contenido del flujo de respuesta y devuelve el contenido como una cadena (String)
            stringCadenaUsuarios = respuestaDecodificada.ReadToEnd()
        End Using


        ' Si quiero crear y devolver una lista de objetos Usuario ejecuto este fragmento de codigo

        Dim xmlRespuesta As XDocument = XDocument.Parse(stringCadenaUsuarios)

        For Each elementoXmlUsuerio As XElement In xmlRespuesta.Descendants("Usuario")
            Dim usuarios As New Usuario() With {
            .IdUsuario = Convert.ToInt32(elementoXmlUsuerio.Element("ID").Value),
            .Nombre = elementoXmlUsuerio.Element("Nombre_de_usuario").Value,
            .ContrasenaUsuario = elementoXmlUsuerio.Element("Contraseña").Value}
            lista.Add(usuarios)
        Next

        Return lista

    End Function
End Class
