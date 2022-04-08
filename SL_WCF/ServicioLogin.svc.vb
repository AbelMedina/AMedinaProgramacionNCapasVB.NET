' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "ServicioLogin" en el código, en svc y en el archivo de configuración a la vez.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioLogin.svc o ServicioLogin.svc.vb en el Explorador de soluciones e inicie la depuración.
Public Class ServicioLogin
    Implements IServicioLogin

    Public Function Login(Usuario As ML.User) As SL_WCF.Result Implements IServicioLogin.Login
        Dim result As ML.Result = New ML.Result
        result = BL.Usuario.Login(Usuario)
        Return New Result With {.Correct = result.Correct, .ErrorMessage = result.ErrorMessage, .Ex = result.Ex, .Obj = result.Obj, .Objs = result.Objs}
    End Function

End Class
