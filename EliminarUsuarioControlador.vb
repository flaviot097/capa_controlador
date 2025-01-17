Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Web.Services

Public Class EliminarUsuarioControlador
    Public Sub EliminarUsuarioPorId(usuarioID As Integer)
        Dim urlServicio As String = "https://localhost:44337/servicioweb.asmx"
        Dim urlAccionService = "http://servicioweb.com/miServicio/EliminarUsuario"

        Dim cabeceraXML As String = "<?xml version=""1.0"" encoding=""utf-8""?>
                             <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                                            xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                                            xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                               <soap:Body>
                                 <EliminarUsuario xmlns=""http://servicioweb.com/miServicio"">
                                   <id>" & usuarioID.ToString() & "</id>
                                 </EliminarUsuario>
                               </soap:Body>
                             </soap:Envelope>"

        Dim consulta As HttpWebRequest = CType(WebRequest.Create(urlServicio), HttpWebRequest)
        consulta.Method = "POST"
        consulta.ContentType = "text/xml; charset=utf-8"
        consulta.Headers.Add("SOAPAction", urlAccionService)

        Dim data As Byte() = Encoding.UTF8.GetBytes(cabeceraXML)
        consulta.ContentLength = data.Length

        Using streamConsulta As Stream = consulta.GetRequestStream()
            streamConsulta.Write(data, 0, data.Length)
        End Using

        'respuesta
        Dim respouesta As HttpWebResponse = CType(consulta.GetResponse(), HttpWebResponse)

        'Using streamRespuesta As New StreamReader(respouesta.GetResponseStream())
        '    Dim resultado As String = streamRespuesta.ReadToEnd()
        'End Using

    End Sub
End Class
