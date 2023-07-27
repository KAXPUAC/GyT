Imports System.Net.Http
Imports System.Security.Authentication

Module Module1
    Sub Main()
        Dim url As String = "https://betamq.galileo.edu/gyt/api/pruebaconexion"
        ' Datos que deseas enviar en el cuerpo de la solicitud (si es necesario)
        Dim postData As New Dictionary(Of String, String)()
        ' Codificar los datos para el cuerpo de la solicitud (si es necesario)
        Dim content As New FormUrlEncodedContent(postData)
        ' Crear un objeto HttpClient usando el HttpClientHandler configurado
        Dim handler As New HttpClientHandler()
        handler.SslProtocols = SslProtocols.Tls12
        ' Crear un objeto HttpClient
        Using httpClient As New HttpClient(handler)
            ' Configurar los encabezados
            httpClient.DefaultRequestHeaders.Add("key1", "value1")
            httpClient.DefaultRequestHeaders.Add("key2", "value2")
            Try
                ' Hacer la solicitud POST a la URL con los datos en el cuerpo
                Dim response As HttpResponseMessage = httpClient.PostAsync(url, content).Result
                ' Comprobar si la respuesta fue exitosa
                If response.IsSuccessStatusCode Then
                    ' Leer el contenido de la respuesta como string
                    Dim contenido As String = response.Content.ReadAsStringAsync().Result
                    Console.WriteLine("Respuesta del servidor:")
                    Console.WriteLine(contenido)
                Else
                    Console.WriteLine("Error en la solicitud: " & response.ReasonPhrase)
                End If
            Catch ex As Exception
                Console.WriteLine("Error en la solicitud: " & ex.Message)
            End Try
        End Using
        Console.WriteLine("Presiona cualquier tecla para salir...")
        Console.ReadKey()
    End Sub
End Module
