Imports System.Net
Imports System.Web.Http

Namespace Controllers
    <RoutePrefix("api/User")>
    Public Class UserController
        Inherits ApiController

        <HttpGet>
        <Route("GetAll")>
        Public Function GetAll() As IHttpActionResult
            Dim result As ML.Result = New ML.Result
            result = BL.Usuario.GetAll()
            If result.Correct Then
                Return Content(HttpStatusCode.OK, result)
            Else
                Return Content(HttpStatusCode.NotFound, result)
            End If
        End Function

        <HttpGet>
        <Route("GetById/{IdUsuario}")>
        Public Function GetById(IdUsuario As Integer) As IHttpActionResult
            Dim result As ML.Result = New ML.Result
            result = BL.Usuario.GetById(IdUsuario)
            If result.Correct Then
                Return Content(HttpStatusCode.OK, result)
            Else
                Return Content(HttpStatusCode.NotFound, result)
            End If
        End Function

        <HttpDelete>
        <Route("Delete/{IdUsuario}")>
        Public Function Delete(IdUsuario As Integer) As IHttpActionResult
            Dim result As ML.Result = New ML.Result
            result = BL.Usuario.Delete(IdUsuario)
            If result.Correct Then
                Return Content(HttpStatusCode.OK, result)
            Else
                Return Content(HttpStatusCode.BadRequest, result)
            End If
        End Function

        <HttpPost>
        <Route("Add")>
        Public Function Add(<FromBody()> Usuario As ML.User)
            Dim result As ML.Result = New ML.Result
            result = BL.Usuario.Add(Usuario)
            If result.Correct Then
                Return Content(HttpStatusCode.OK, result)
            Else
                Return Content(HttpStatusCode.BadRequest, result)
            End If
        End Function

        <HttpPut>
        <Route("Update/{IdUsuario}")>
        Public Function Update(IdUsuario As Integer, <FromBody()> Usuario As ML.User)
            Dim result As ML.Result = New ML.Result
            Usuario.IdUsuario = IdUsuario
            result = BL.Usuario.Update(Usuario)
            If result.Correct Then
                Return Content(HttpStatusCode.OK, result)
            Else
                Return Content(HttpStatusCode.BadRequest, result)
            End If
        End Function
    End Class
End Namespace