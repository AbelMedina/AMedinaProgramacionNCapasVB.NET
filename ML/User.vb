Imports System.ComponentModel.DataAnnotations
Public Class User
    Public Property IdUsuario As Integer
    <Required(ErrorMessage:="Se requiere el Username")>
    Public Property UserName As String
    '<Required(ErrorMessage:="Se requiere el Nombre")>
    Public Property Nombre As String
    '<Required(ErrorMessage:="Se requiere el Apellido Paterno")>
    Public Property ApellidoPaterno As String
    '<Required(ErrorMessage:="Se requiere el Apellido Materno")>
    Public Property ApellidoMaterno As String
    Public Property Foto As Byte()
    <Required(ErrorMessage:="Se requiere la Contraseña")>
    Public Property Password As String
    Public Property Users As List(Of Object)
End Class
