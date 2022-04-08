Imports System.Net
Imports System.Web.Http

Namespace Controllers
    <RoutePrefix("api")>
    Public Class LoginController
        Inherits ApiController
        <HttpPost>
        <Route("Login")>
        Public Function Login(<FromBody()> Usuario As ML.User) As IHttpActionResult
            Dim result As ML.Result = New ML.Result
            result = BL.Usuario.Login(Usuario)
            If result.Correct Then
                Return Content(HttpStatusCode.OK, result)
            Else
                Return Content(HttpStatusCode.NotFound, result)
            End If
        End Function

    End Class
End Namespace