Imports System.Net.Http
Imports System.Web.Mvc
Imports System.Configuration

Namespace Controllers
    Public Class LoginController
        Inherits Controller

        ' GET: Login
        <HttpGet>
        Function Login() As ActionResult
            Return View()
        End Function
        '---------------------------------------------Normal
        '<HttpPost()>
        'Function Login(Usuario As ML.User) As ActionResult
        '    Dim ValidarUsuario As ML.User = New ML.User
        '    If ModelState.IsValid Then
        '        Dim result As ML.Result = New ML.Result
        '        result = BL.Usuario.Login(Usuario)
        '        If result.Correct Then
        '            Return RedirectToAction("Index", "Home")
        '        Else
        '            ViewBag.Mensaje = "Credenciales Incorrectas " + result.ErrorMessage
        '            Return PartialView("Modal")
        '        End If
        '    End If
        '    Return View(ValidarUsuario)
        'End Function
        ''---------------------------------------------WCF
        '<HttpPost>
        'Public Function Login(Usuario As ML.User) As ActionResult
        '    Dim UrlBase As String
        '    UrlBase = ConfigurationManager.AppSettings("WebApi").ToString()
        '    Dim ValidarUsuario As ML.User = New ML.User
        '    If ModelState.IsValid Then
        '        Dim result As ML.Result = New ML.Result
        '        Using cliente As HttpClient = New HttpClient()
        '            cliente.BaseAddress = New Uri(UrlBase)
        '            Dim postTask = cliente.PostAsJsonAsync(Of ML.User)("Login", Usuario)
        '            postTask.Wait()
        '            Dim resultPost = postTask.Result
        '            If resultPost.IsSuccessStatusCode Then
        '                Return RedirectToAction("Index", "Home")
        '            Else
        '                ViewBag.Mensaje = "Credenciales Incorrectas " + result.ErrorMessage
        '                Return PartialView("Modal")
        '            End If
        '        End Using
        '    End If
        '    Return View(ValidarUsuario)
        'End Function
        <HttpPost>
        Function Login(Usuario As ML.User) As ActionResult
            Dim servicioLogin As ServicioLogin.ServicioLoginClient = New PL.ServicioLogin.ServicioLoginClient()
            Dim ValidarUsuario As ML.User = New ML.User
            If ModelState.IsValid Then
                Dim result = servicioLogin.Login(Usuario)
                If result.Correct Then
                    Return RedirectToAction("Index", "Home")
                Else
                    ViewBag.Mensaje = "Credenciales Incorrectas " + result.ErrorMessage
                    Return PartialView("Modal")
                End If
            End If
            Return View(ValidarUsuario)
        End Function
    End Class
End Namespace