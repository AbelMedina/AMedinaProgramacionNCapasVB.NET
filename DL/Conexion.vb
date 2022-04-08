Imports System.Configuration
Imports System.Data.SqlClient

Public Class Conexion
    Shared Function GetConexion() As String
        'Dim conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("LoginAMedina").ConnectionString)
        'Return conexion.ToString
        Dim conexion As String
        conexion = ConfigurationManager.ConnectionStrings("LoginAMedina").ConnectionString
        Return conexion
    End Function

End Class
