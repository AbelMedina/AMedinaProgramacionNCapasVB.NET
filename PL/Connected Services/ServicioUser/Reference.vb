﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace ServicioUser
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="Result", [Namespace]:="http://schemas.datacontract.org/2004/07/SL_WCF"),  _
     System.SerializableAttribute(),  _
     System.Runtime.Serialization.KnownTypeAttribute(GetType(ML.User)),  _
     System.Runtime.Serialization.KnownTypeAttribute(GetType(System.Exception)),  _
     System.Runtime.Serialization.KnownTypeAttribute(GetType(Object()))>  _
    Partial Public Class Result
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private CorrectField As Boolean
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private ErrorMessageField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private ExField As System.Exception
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private ObjField As Object
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private ObjsField() As Object
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Correct() As Boolean
            Get
                Return Me.CorrectField
            End Get
            Set
                If (Me.CorrectField.Equals(value) <> true) Then
                    Me.CorrectField = value
                    Me.RaisePropertyChanged("Correct")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property ErrorMessage() As String
            Get
                Return Me.ErrorMessageField
            End Get
            Set
                If (Object.ReferenceEquals(Me.ErrorMessageField, value) <> true) Then
                    Me.ErrorMessageField = value
                    Me.RaisePropertyChanged("ErrorMessage")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Ex() As System.Exception
            Get
                Return Me.ExField
            End Get
            Set
                If (Object.ReferenceEquals(Me.ExField, value) <> true) Then
                    Me.ExField = value
                    Me.RaisePropertyChanged("Ex")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Obj() As Object
            Get
                Return Me.ObjField
            End Get
            Set
                If (Object.ReferenceEquals(Me.ObjField, value) <> true) Then
                    Me.ObjField = value
                    Me.RaisePropertyChanged("Obj")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Objs() As Object()
            Get
                Return Me.ObjsField
            End Get
            Set
                If (Object.ReferenceEquals(Me.ObjsField, value) <> true) Then
                    Me.ObjsField = value
                    Me.RaisePropertyChanged("Objs")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ServicioUser.IServicioUsuario")>  _
    Public Interface IServicioUsuario
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/GetAll", ReplyAction:="http://tempuri.org/IServicioUsuario/GetAllResponse")>  _
        Function GetAll() As ServicioUser.Result
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/GetAll", ReplyAction:="http://tempuri.org/IServicioUsuario/GetAllResponse")>  _
        Function GetAllAsync() As System.Threading.Tasks.Task(Of ServicioUser.Result)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/GetById", ReplyAction:="http://tempuri.org/IServicioUsuario/GetByIdResponse")>  _
        Function GetById(ByVal IdUsuario As Integer) As ServicioUser.Result
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/GetById", ReplyAction:="http://tempuri.org/IServicioUsuario/GetByIdResponse")>  _
        Function GetByIdAsync(ByVal IdUsuario As Integer) As System.Threading.Tasks.Task(Of ServicioUser.Result)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/Add", ReplyAction:="http://tempuri.org/IServicioUsuario/AddResponse"),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(ServicioUser.Result)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(System.Exception)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(Object()))>  _
        Function Add(ByVal Usuario As ML.User) As ServicioUser.Result
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/Add", ReplyAction:="http://tempuri.org/IServicioUsuario/AddResponse")>  _
        Function AddAsync(ByVal Usuario As ML.User) As System.Threading.Tasks.Task(Of ServicioUser.Result)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/Update", ReplyAction:="http://tempuri.org/IServicioUsuario/UpdateResponse"),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(ServicioUser.Result)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(System.Exception)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(Object()))>  _
        Function Update(ByVal Usuario As ML.User) As ServicioUser.Result
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/Update", ReplyAction:="http://tempuri.org/IServicioUsuario/UpdateResponse")>  _
        Function UpdateAsync(ByVal Usuario As ML.User) As System.Threading.Tasks.Task(Of ServicioUser.Result)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/Delete", ReplyAction:="http://tempuri.org/IServicioUsuario/DeleteResponse")>  _
        Function Delete(ByVal IdUsuario As Integer) As ServicioUser.Result
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IServicioUsuario/Delete", ReplyAction:="http://tempuri.org/IServicioUsuario/DeleteResponse")>  _
        Function DeleteAsync(ByVal IdUsuario As Integer) As System.Threading.Tasks.Task(Of ServicioUser.Result)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IServicioUsuarioChannel
        Inherits ServicioUser.IServicioUsuario, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class ServicioUsuarioClient
        Inherits System.ServiceModel.ClientBase(Of ServicioUser.IServicioUsuario)
        Implements ServicioUser.IServicioUsuario
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetAll() As ServicioUser.Result Implements ServicioUser.IServicioUsuario.GetAll
            Return MyBase.Channel.GetAll
        End Function
        
        Public Function GetAllAsync() As System.Threading.Tasks.Task(Of ServicioUser.Result) Implements ServicioUser.IServicioUsuario.GetAllAsync
            Return MyBase.Channel.GetAllAsync
        End Function
        
        Public Function GetById(ByVal IdUsuario As Integer) As ServicioUser.Result Implements ServicioUser.IServicioUsuario.GetById
            Return MyBase.Channel.GetById(IdUsuario)
        End Function
        
        Public Function GetByIdAsync(ByVal IdUsuario As Integer) As System.Threading.Tasks.Task(Of ServicioUser.Result) Implements ServicioUser.IServicioUsuario.GetByIdAsync
            Return MyBase.Channel.GetByIdAsync(IdUsuario)
        End Function
        
        Public Function Add(ByVal Usuario As ML.User) As ServicioUser.Result Implements ServicioUser.IServicioUsuario.Add
            Return MyBase.Channel.Add(Usuario)
        End Function
        
        Public Function AddAsync(ByVal Usuario As ML.User) As System.Threading.Tasks.Task(Of ServicioUser.Result) Implements ServicioUser.IServicioUsuario.AddAsync
            Return MyBase.Channel.AddAsync(Usuario)
        End Function
        
        Public Function Update(ByVal Usuario As ML.User) As ServicioUser.Result Implements ServicioUser.IServicioUsuario.Update
            Return MyBase.Channel.Update(Usuario)
        End Function
        
        Public Function UpdateAsync(ByVal Usuario As ML.User) As System.Threading.Tasks.Task(Of ServicioUser.Result) Implements ServicioUser.IServicioUsuario.UpdateAsync
            Return MyBase.Channel.UpdateAsync(Usuario)
        End Function
        
        Public Function Delete(ByVal IdUsuario As Integer) As ServicioUser.Result Implements ServicioUser.IServicioUsuario.Delete
            Return MyBase.Channel.Delete(IdUsuario)
        End Function
        
        Public Function DeleteAsync(ByVal IdUsuario As Integer) As System.Threading.Tasks.Task(Of ServicioUser.Result) Implements ServicioUser.IServicioUsuario.DeleteAsync
            Return MyBase.Channel.DeleteAsync(IdUsuario)
        End Function
    End Class
End Namespace
