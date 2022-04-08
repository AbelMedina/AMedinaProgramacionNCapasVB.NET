Imports System.ServiceModel

' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IServicioUsuario" en el código y en el archivo de configuración a la vez.
<ServiceContract()>
Public Interface IServicioUsuario

    <OperationContract()>
    <ServiceKnownType(GetType(ML.User))>
    Function GetAll() As SL_WCF.Result
    <OperationContract>
    <ServiceKnownType(GetType(ML.User))>
    Function GetById(IdUsuario As Integer) As SL_WCF.Result
    <OperationContract>
    Function Add(Usuario As ML.User) As SL_WCF.Result
    <OperationContract>
    Function Update(Usuario As ML.User) As SL_WCF.Result
    <OperationContract>
    Function Delete(IdUsuario As Integer) As SL_WCF.Result

End Interface
