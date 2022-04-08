Imports System.Web.Mvc
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports System.Configuration
Imports System.Net.Http
Imports System.Net.Http.Headers

Namespace Controllers
    Public Class UserController
        Inherits Controller
        '---------------------------------------------Normal
        ' GET: User
        '<HttpGet>
        'Function GetAll() As ActionResult
        '    Dim usuario As ML.User = New ML.User
        '    Dim result As ML.Result = New ML.Result
        '    result = BL.Usuario.GetAll()
        '    If result.Correct Then
        '        usuario.Users = result.Objs
        '    Else
        '        ViewBag.Mensaje = "Ha ocurrido un error al consultar los usuarios"
        '        Return PartialView("Modal")
        '    End If
        '    Return View(usuario)
        'End Function

        '---------------------------------------------WEB API
        'Public Async Function GetAll() As Task(Of ActionResult)
        '    Dim Usuario As ML.User = New ML.User
        '    'Inicializar Lista
        '    Usuario.Users = New List(Of Object)()
        '    Dim UrlBase As String
        '    UrlBase = ConfigurationManager.AppSettings("WebApi").ToString()
        '    Using Cliente As HttpClient = New HttpClient()
        '        Cliente.BaseAddress = New Uri(UrlBase)
        '        Cliente.DefaultRequestHeaders.Clear()
        '        Cliente.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        '        Dim respuesta As HttpResponseMessage = Await Cliente.GetAsync("User/GetAll")
        '        If respuesta.IsSuccessStatusCode Then
        '            Dim readTask = respuesta.Content.ReadAsStringAsync().Result
        '            Dim resultJson As ML.Result = JsonConvert.DeserializeObject(Of ML.Result)(readTask)
        '            For Each resultItem In resultJson.Objs
        '                Dim ResultItemList As ML.User = JsonConvert.DeserializeObject(Of ML.User)(resultItem.ToString())
        '                Usuario.Users.Add(ResultItemList)
        '            Next

        '        End If
        '        Return View(Usuario)
        '    End Using

        'End Function

        '---------------------------------------------WCF
        <HttpGet>
        Function GetAll() As ActionResult
            Dim servicioUser As ServicioUser.ServicioUsuarioClient = New ServicioUser.ServicioUsuarioClient()
            Dim result = servicioUser.GetAll()
            Dim usuario As ML.User = New ML.User
            If result.Correct Then
                usuario.Users = result.Objs.ToList()
            Else
                ViewBag.Mensaje = "Ha ocurrido un error al consultar los usuarios"
                Return PartialView("Modal")
            End If
            Return View(usuario)
        End Function

        '---------------------------------------------Normal
        '<HttpGet>
        'Function Form(IdUsuario As Integer?) As ActionResult
        '    Dim Usuario As ML.User = New ML.User
        '    If IdUsuario Is Nothing Then
        '        Return View(Usuario)
        '    Else
        '        Dim result As ML.Result = BL.Usuario.GetById(IdUsuario.Value)
        '        If result.Correct Then
        '            Usuario = DirectCast(result.Obj, ML.User)
        '            Return View(Usuario)
        '        End If
        '    End If
        '    Return View()
        'End Function

        '---------------------------------------------WEB API
        '<HttpGet>
        'Public Function Form(IdUsuario As Integer?) As ActionResult
        '    Dim Usuario As ML.User = New ML.User
        '    Dim UrlBase As String
        '    UrlBase = ConfigurationManager.AppSettings("WebApi").ToString()
        '    If IdUsuario Is Nothing Then
        '        Return View(Usuario)
        '    Else
        '        Dim result As ML.Result = New ML.Result
        '        Try
        '            Using client As HttpClient = New HttpClient()
        '                client.BaseAddress = New Uri(UrlBase)
        '                Dim responseTask = client.GetAsync("User/GetById/" & IdUsuario)
        '                responseTask.Wait()
        '                Dim resultAPI = responseTask.Result
        '                If resultAPI.IsSuccessStatusCode Then
        '                    Dim readTask = resultAPI.Content.ReadAsAsync(Of ML.Result)()
        '                    readTask.Wait()
        '                    Dim resultItemList As ML.User = New ML.User
        '                    resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ML.User)(readTask.Result.Obj.ToString())
        '                    result.Obj = resultItemList
        '                    result.Correct = True
        '                    If result.Correct Then
        '                        Usuario = DirectCast(result.Obj, ML.User)
        '                        Return View(Usuario)
        '                    Else
        '                        ViewBag.Mensaje = "Ha Ocurrido un error " & result.ErrorMessage
        '                        Return PartialView("Modal")
        '                    End If
        '                End If

        '            End Using
        '        Catch ex As Exception
        '            ViewBag.Mensaje = "Ha Ocurrido un Error " + result.ErrorMessage
        '            Return PartialView("Modal")
        '        End Try
        '    End If
        '    Return View()
        'End Function

        '---------------------------------------------WCF
        <HttpGet>
        Function Form(IdUsuario As Integer?) As ActionResult
            Dim servicioUser As ServicioUser.ServicioUsuarioClient = New ServicioUser.ServicioUsuarioClient()
            Dim Usuario As ML.User = New ML.User
            If IdUsuario Is Nothing Then
                Return View(Usuario)
            Else
                Dim result = servicioUser.GetById(IdUsuario)
                If result.Correct Then
                    Usuario = DirectCast(result.Obj, ML.User)
                    Return View(Usuario)
                End If
            End If
            Return View()
        End Function


        '---------------------------------------------Normal
        '<HttpPost>
        'Function Form(Usuario As ML.User) As ActionResult
        '    Dim result As ML.Result = New ML.Result
        '    Dim File As HttpPostedFileBase = Request.Files("UserFoto")
        '    If File.ContentLength > 0 Then
        '        Usuario.Foto = ConvertToBytes(File)
        '    ElseIf File Is Nothing Then
        '        Usuario.Foto = Nothing
        '    Else
        '        ViewBag.Mensaje = "Error en la foto del usuario"
        '    End If
        '    If Usuario.IdUsuario = 0 Then
        '        result = BL.Usuario.Add(Usuario)
        '        If result.Correct Then
        '            ViewBag.Mensaje = "Se ha agregado correctamente al usuario"
        '        Else
        '            ViewBag.Mensaje = "Ha ocurrido un error al agregar al usuario"
        '        End If
        '    Else
        '        result = BL.Usuario.Update(Usuario)
        '        If result.Correct Then
        '            ViewBag.Mensaje = "Se ha actualizado correctamente al usuario"
        '        Else
        '            ViewBag.Mensaje = "Ha ocurrido un erro al actualizar al usuario"
        '        End If
        '    End If
        '    Return PartialView("Modal")
        'End Function



        '---------------------------------------------WEB API
        '<HttpPost>
        'Public Function Form(Usuario As ML.User) As ActionResult
        '    Dim UrlBase As String
        '    UrlBase = ConfigurationManager.AppSettings("WebApi").ToString()
        '    Dim result As ML.Result = New ML.Result
        '    Dim File As HttpPostedFileBase = Request.Files("UserFoto")
        '    If File.ContentLength > 0 Then
        '        Usuario.Foto = ConvertToBytes(File)
        '    ElseIf File Is Nothing Then
        '        Usuario.Foto = Nothing
        '    Else
        '        ViewBag.Mensaje = "Error en la foto del usuario"
        '    End If
        '    If Usuario.IdUsuario = 0 Then
        '        Using client As HttpClient = New HttpClient()
        '            client.BaseAddress = New Uri(UrlBase)
        '            Dim postTask = client.PostAsJsonAsync(Of ML.User)("User/Add/", Usuario)
        '            postTask.Wait()
        '            Dim resultPost = postTask.Result
        '            If resultPost.IsSuccessStatusCode Then
        '                ViewBag.Mensaje = "Se ha agregado correctamente al usuario"
        '                'Return PartialView("Modal")
        '            Else
        '                ViewBag.Mensaje = "Ha ocurrido un error al actualizar al usuario " & result.ErrorMessage
        '            End If
        '        End Using
        '    Else
        '        Using client As HttpClient = New HttpClient()
        '            client.BaseAddress = New Uri(UrlBase)
        '            Dim postTask = client.PutAsJsonAsync(Of ML.User)("User/Update/" & Usuario.IdUsuario, Usuario)
        '            postTask.Wait()
        '            Dim resultPost = postTask.Result
        '            If resultPost.IsSuccessStatusCode Then
        '                ViewBag.Mensaje = "Se ha actualizado correctamente al usuario"
        '            Else
        '                ViewBag.Mensaje = "Ha ocurrido un error al actualizar al usuario " & result.ErrorMessage
        '            End If
        '        End Using
        '    End If
        '    Return PartialView("Modal")
        'End Function
        '---------------------------------------------WCF
        <HttpPost>
        Function Form(Usuario As ML.User) As ActionResult
            Dim servicioUser As ServicioUser.ServicioUsuarioClient = New ServicioUser.ServicioUsuarioClient()
            Dim File As HttpPostedFileBase = Request.Files("UserFoto")
            If File.ContentLength > 0 Then
                Usuario.Foto = ConvertToBytes(File)
            ElseIf File Is Nothing Then
                Usuario.Foto = Nothing
            Else
                ViewBag.Mensaje = "Error en la foto del usuario"
            End If
            If Usuario.IdUsuario = 0 Then
                Dim result = servicioUser.Add(Usuario)
                If result.Correct Then
                    ViewBag.Mensaje = "Se ha agregado correctamente al usuario"
                Else
                    ViewBag.Mensaje = "Ha ocurrido un error al agregar al usuario " & result.ErrorMessage
                End If
            Else
                Dim result = servicioUser.Update(Usuario)
                If result.Correct Then
                    ViewBag.Mensaje = "Se ha actualizado correctamente al usuario"
                Else
                    ViewBag.Mensaje = "Ha ocurrido un error al actualizar al usuario " & result.ErrorMessage
                End If
            End If
            Return PartialView("Modal")
        End Function




        '---------------------------------------------Normal
        '<HttpGet>
        'Function Delete(IdUsuario As Integer) As ActionResult
        '    Dim Result As ML.Result = New ML.Result
        '    Result = BL.Usuario.Delete(IdUsuario)
        '    If Result.Correct Then
        '        ViewBag.Mensaje = "Se ha eliminado correctamente al usuario"
        '    Else
        '        ViewBag.Mensaje = "Ha ocurrido un error al eliminar al usuario " + Result.ErrorMessage
        '    End If
        '    Return PartialView("Modal")
        'End Function
        '---------------------------------------------WEB API
        '<HttpGet>
        'Public Function Delete(IdUsuario As Integer) As ActionResult
        '    Dim UrlBase As String
        '    UrlBase = ConfigurationManager.AppSettings("WebApi").ToString()
        '    Dim ResultUser As ML.Result = New ML.Result
        '    Using client As HttpClient = New HttpClient
        '        client.BaseAddress = New Uri(UrlBase)
        '        Dim postTask = client.DeleteAsync("User/Delete/" & IdUsuario)
        '        postTask.Wait()
        '        Dim result = postTask.Result
        '        If result.IsSuccessStatusCode Then
        '            ViewBag.Mensaje = "Se ha eliminado correctamente al usuario"
        '        Else
        '            ViewBag.Mensaje = "Ha ocurrido un error al eliminar al usuario " & result.ReasonPhrase()
        '        End If
        '    End Using
        '    Return PartialView("Modal")
        'End Function
        '---------------------------------------------WCF
        <HttpGet>
        Function Delete(IdUsuario As Integer) As ActionResult
            Dim servicioUser As ServicioUser.ServicioUsuarioClient = New ServicioUser.ServicioUsuarioClient()
            Dim result = servicioUser.Delete(IdUsuario)
            If result.Correct Then
                ViewBag.Mensaje = "Se ha eliminado correctamente al usuario"
            Else
                ViewBag.Mensaje = "Ha ocurrido un error al eliminar al usuario  " & result.ErrorMessage
            End If
            Return PartialView("Modal")
        End Function




        Public Function ConvertToBytes(Imagen As HttpPostedFileBase) As Byte()
            Dim data As Byte() = Nothing
            Dim reader As System.IO.BinaryReader = New System.IO.BinaryReader(Imagen.InputStream)
            data = reader.ReadBytes(CInt(Imagen.ContentLength))
            Return data
        End Function

    End Class

End Namespace