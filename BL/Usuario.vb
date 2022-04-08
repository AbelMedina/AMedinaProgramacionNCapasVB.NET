Imports System.Data.SqlClient

Public Class Usuario
    Shared Function Login(Usuario As ML.User) As ML.Result
        Dim Result As ML.Result = New ML.Result
        Try
            Using resource As DL.LoginEntities = New DL.LoginEntities
                Dim Query = resource.UsuarioLogin(Usuario.UserName.ToString(), Usuario.Password.ToString()).FirstOrDefault()
                If Query IsNot Nothing Then
                    Result.Correct = True
                Else
                    Result.Correct = False
                End If
            End Using
        Catch ex As Exception
            Result.Correct = False
            Result.ErrorMessage = ex.Message
            Result.Ex = ex
        End Try
        Return Result
    End Function

    Shared Function GetAll() As ML.Result
        Dim result As ML.Result = New ML.Result
        Try
            Using context As SqlConnection = New SqlConnection(DL.Conexion.GetConexion())
                Dim query As String = "UsuarioGetAll"
                Using cmd As SqlCommand = New SqlCommand
                    cmd.CommandText = query
                    cmd.Connection = context
                    cmd.CommandType = CommandType.StoredProcedure
                    Using da As SqlDataAdapter = New SqlDataAdapter(cmd)
                        Dim tableUsuario As DataTable = New DataTable
                        da.Fill(tableUsuario)
                        cmd.Connection.Open()
                        If tableUsuario.Rows.Count > 0 Then
                            result.Objs = New List(Of Object)
                            For Each row As DataRow In tableUsuario.Rows
                                Dim usuario As ML.User = New ML.User
                                usuario.IdUsuario = Integer.Parse(row(0).ToString)
                                usuario.UserName = row(1).ToString
                                usuario.Nombre = row(2).ToString
                                usuario.ApellidoPaterno = row(3).ToString
                                usuario.ApellidoMaterno = row(4).ToString
                                'usuario.Foto = row(5)
                                If row(5) Is DBNull.Value Then
                                    usuario.Foto = Nothing
                                Else
                                    usuario.Foto = DirectCast(row(5), Byte())
                                End If
                                'usuario.Foto = DirectCast(row(5), Byte())

                                usuario.Password = row(6).ToString
                                result.Objs.Add(usuario)
                            Next
                            result.Correct = True
                        Else
                            result.Correct = False
                            result.ErrorMessage = "No existen registros en la tabla de usuario"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            result.Correct = False
            result.ErrorMessage = ex.Message
            result.Ex = ex
        End Try
        Return result
    End Function

    Shared Function GetById(IdUsuario As Integer) As ML.Result
        Dim result As ML.Result = New ML.Result
        Try
            Using context As SqlConnection = New SqlConnection(DL.Conexion.GetConexion())
                Dim query As String = "UsuarioGetById"
                Using cmd As SqlCommand = New SqlCommand
                    cmd.CommandText = query
                    cmd.Connection = context
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim collection() As SqlParameter = New SqlParameter() _
                        {
                        New SqlParameter("@IdUsuario", SqlDbType.Int) With {.Value = IdUsuario}
                        }
                    cmd.Parameters.AddRange(collection)
                    Using da As SqlDataAdapter = New SqlDataAdapter(cmd)
                        Dim tableUsuario As DataTable = New DataTable
                        da.Fill(tableUsuario)
                        cmd.Connection.Open()
                        If tableUsuario.Rows.Count > 0 Then
                            result.Obj = New List(Of Object)
                            Dim row As DataRow = tableUsuario.Rows(0)
                            Dim usuario As ML.User = New ML.User
                            usuario.IdUsuario = Integer.Parse(row(0).ToString)
                            usuario.UserName = row(1).ToString
                            usuario.Nombre = row(2).ToString
                            usuario.ApellidoMaterno = row(3).ToString
                            usuario.ApellidoPaterno = row(4).ToString
                            'usuario.Foto = row(5)
                            If row(5) Is DBNull.Value Then
                                usuario.Foto = Nothing
                            Else
                                usuario.Foto = DirectCast(row(5), Byte())
                            End If
                            'usuario.Foto = DirectCast(row(5), Byte())
                            usuario.Password = row(6).ToString
                            result.Obj = usuario
                            result.Correct = True
                        Else
                            result.Correct = False
                            result.ErrorMessage = "No se encontraron registros en la tabla Usuario"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            result.Correct = False
            result.ErrorMessage = ex.Message
            result.Ex = ex
        End Try
        Return result
    End Function

    Shared Function Add(Usuario As ML.User) As ML.Result
        Dim result As ML.Result = New ML.Result
        Try
            Using context As SqlConnection = New SqlConnection(DL.Conexion.GetConexion())
                Dim query As String = "UsuarioAdd"
                Using cmd As SqlCommand = New SqlCommand
                    cmd.CommandText = query
                    cmd.Connection = context
                    cmd.CommandType = CommandType.StoredProcedure
                    'Dim collection() As SqlParameter = New SqlParameter() _
                    '    {
                    '    New SqlParameter("@UserName", SqlDbType.VarChar) With {.Value = Usuario.UserName},
                    '    New SqlParameter("@Nombre", SqlDbType.VarChar) With {.Value = Usuario.Nombre},
                    '    New SqlParameter("@ApellidoPaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoPaterno},
                    '    New SqlParameter("@ApellidoMaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoMaterno},
                    '    New SqlParameter("@Foto", SqlDbType.VarBinary) With {.Value = DBNull.Value},
                    '    New SqlParameter("@Password", SqlDbType.VarChar) With {.Value = Usuario.Password}
                    '    }
                    Dim collection(5) As SqlParameter
                    collection(0) = New SqlParameter("@Username", SqlDbType.VarChar) With {.Value = Usuario.UserName}
                    collection(1) = New SqlParameter("@Nombre", SqlDbType.VarChar) With {.Value = Usuario.Nombre}
                    collection(2) = New SqlParameter("@ApellidoPaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoPaterno}
                    collection(3) = New SqlParameter("@ApellidoMaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoMaterno}
                    If Usuario.Foto Is Nothing Then
                        collection(4) = New SqlParameter("@Foto", SqlDbType.VarBinary) With {.Value = DBNull.Value}
                    Else
                        collection(4) = New SqlParameter("@Foto", SqlDbType.VarBinary) With {.Value = Usuario.Foto}
                    End If
                    collection(5) = New SqlParameter("@Password", SqlDbType.VarChar) With {.Value = Usuario.Password}

                    cmd.Parameters.AddRange(collection)
                    cmd.Connection.Open()
                    Dim RowsAffected As Integer = cmd.ExecuteNonQuery()
                    If RowsAffected > 0 Then
                        result.Correct = True
                    Else
                        result.Correct = False
                        result.ErrorMessage = "Ha ocurrido un error al ingresar al usuario"
                    End If
                End Using
            End Using
        Catch ex As Exception
            result.Correct = False
            result.ErrorMessage = ex.Message
            result.Ex = ex
        End Try
        Return result
    End Function

    Shared Function Update(Usuario As ML.User) As ML.Result
        Dim result As ML.Result = New ML.Result
        Try
            Using context As SqlConnection = New SqlConnection(DL.Conexion.GetConexion())
                Dim query As String = "UsuarioUpdate"
                Using cmd As SqlCommand = New SqlCommand
                    cmd.CommandText = query
                    cmd.Connection = context
                    cmd.CommandType = CommandType.StoredProcedure
                    'Dim collection() As SqlParameter = New SqlParameter() _
                    '    {
                    '    New SqlParameter("@IdUsuario", SqlDbType.Int) With {.Value = Usuario.IdUsuario},
                    '    New SqlParameter("@UserName", SqlDbType.VarChar) With {.Value = Usuario.UserName},
                    '    New SqlParameter("@Nombre", SqlDbType.VarChar) With {.Value = Usuario.Nombre},
                    '    New SqlParameter("@ApellidoPaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoPaterno},
                    '    New SqlParameter("@ApellidoMaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoMaterno},
                    '    New SqlParameter("@Foto", SqlDbType.VarBinary) With {.Value = Usuario.Foto},
                    '    New SqlParameter("@Password", SqlDbType.VarChar) With {.Value = Usuario.Password}
                    '    }
                    Dim collection(6) As SqlParameter
                    collection(0) = New SqlParameter("@IdUsuario", SqlDbType.Int) With {.Value = Usuario.IdUsuario}
                    collection(1) = New SqlParameter("@UserName", SqlDbType.VarChar) With {.Value = Usuario.UserName}
                    collection(2) = New SqlParameter("@Nombre", SqlDbType.VarChar) With {.Value = Usuario.Nombre}
                    collection(3) = New SqlParameter("@ApellidoPaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoPaterno}
                    collection(4) = New SqlParameter("@ApellidoMaterno", SqlDbType.VarChar) With {.Value = Usuario.ApellidoMaterno}
                    If Usuario.Foto Is Nothing Then
                        collection(5) = New SqlParameter("@Foto", SqlDbType.VarBinary) With {.Value = DBNull.Value}
                    Else
                        collection(5) = New SqlParameter("@Foto", SqlDbType.VarBinary) With {.Value = Usuario.Foto}
                    End If
                    collection(6) = New SqlParameter("@Password", SqlDbType.VarChar) With {.Value = Usuario.Password}
                    cmd.Parameters.AddRange(collection)
                    cmd.Connection.Open()
                    Dim RowsAffected As Integer = cmd.ExecuteNonQuery()
                    If RowsAffected > 0 Then
                        result.Correct = True
                    Else
                        result.Correct = False
                        result.ErrorMessage = "Ha ocurrido un error al actualizar al usuario"
                    End If
                End Using
            End Using
        Catch ex As Exception
            result.Correct = False
            result.ErrorMessage = ex.Message
            result.Ex = ex
        End Try
        Return result
    End Function

    Shared Function Delete(IdUsuario As Integer) As ML.Result
        Dim result As ML.Result = New ML.Result
        Try
            Using context As SqlConnection = New SqlConnection(DL.Conexion.GetConexion())
                Dim query As String = "UsuarioDelete"
                Using cmd As SqlCommand = New SqlCommand
                    cmd.CommandText = query
                    cmd.Connection = context
                    cmd.CommandType = CommandType.StoredProcedure
                    Dim collection() As SqlParameter = New SqlParameter() _
                        {
                        New SqlParameter("@IdUsuario", SqlDbType.Int) With {.Value = IdUsuario}
                        }
                    cmd.Parameters.AddRange(collection)
                    cmd.Connection.Open()
                    Dim RowsAffected As Integer = cmd.ExecuteNonQuery()
                    If RowsAffected > 0 Then
                        result.Correct = True
                    Else
                        result.Correct = False
                        result.ErrorMessage = "Ha ocurrido un error al eliminar al usuario"
                    End If
                End Using
            End Using
        Catch ex As Exception
            result.Correct = False
            result.ErrorMessage = ex.Message
            result.Ex = ex
        End Try
        Return result
    End Function

End Class
