Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IServicioLogin" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface IServicioLogin

    <OperationContract()>
    Function Login(Usuario As ML.User) As SL_WCF.Result

End Interface
