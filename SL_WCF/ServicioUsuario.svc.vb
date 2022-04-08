' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "ServicioUsuario" en el código, en svc y en el archivo de configuración a la vez.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioUsuario.svc o ServicioUsuario.svc.vb en el Explorador de soluciones e inicie la depuración.
Public Class ServicioUsuario
    Implements IServicioUsuario

    Public Function GetAll() As SL_WCF.Result Implements IServicioUsuario.GetAll
        Dim result As ML.Result = New ML.Result
        result = BL.Usuario.GetAll()
        Return New Result With {.Correct = result.Correct, .ErrorMessage = result.ErrorMessage, .Ex = result.Ex, .Obj = result.Obj, .Objs = result.Objs}
    End Function

    Public Function GetById(IdUsuario As Integer) As SL_WCF.Result Implements IServicioUsuario.GetById
        Dim result As ML.Result = New ML.Result
        result = BL.Usuario.GetById(IdUsuario)
        Return New Result With {.Correct = result.Correct, .ErrorMessage = result.ErrorMessage, .Ex = result.Ex, .Obj = result.Obj, .Objs = result.Objs}
    End Function

    Public Function Add(Usuario As ML.User) As SL_WCF.Result Implements IServicioUsuario.Add
        Dim result As ML.Result = New ML.Result
        result = BL.Usuario.Add(Usuario)
        Return New Result With {.Correct = result.Correct, .ErrorMessage = result.ErrorMessage, .Ex = result.Ex, .Obj = result.Obj, .Objs = result.Objs}
    End Function

    Public Function Update(Usuario As ML.User) As SL_WCF.Result Implements IServicioUsuario.Update
        Dim result As ML.Result = New ML.Result
        result = BL.Usuario.Update(Usuario)
        Return New Result With {.Correct = result.Correct, .ErrorMessage = result.ErrorMessage, .Ex = result.Ex, .Obj = result.Obj, .Objs = result.Objs}
    End Function

    Public Function Delete(IdUsuario As Integer) As SL_WCF.Result Implements IServicioUsuario.Delete
        Dim result As ML.Result = New ML.Result
        result = BL.Usuario.Delete(IdUsuario)
        Return New Result With {.Correct = result.Correct, .ErrorMessage = result.ErrorMessage, .Ex = result.Ex, .Obj = result.Obj, .Objs = result.Objs}
    End Function

End Class
