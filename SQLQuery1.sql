CREATE DATABASE Login
USE Login

CREATE TABLE Usuarios(
IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
UserName VARCHAR(50),
Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50),
Foto VARBINARY(MAX),
Password VARCHAR(50))



INSERT INTO Usuarios VALUES ('AMedina','Abel','Medina','Rivera',NULL,'@bcd1234')
GO

CREATE PROCEDURE UsuarioLogin
@UserName VARCHAR(50),
@Password VARCHAR(50)
AS
SELECT UserName
FROM Usuarios
WHERE UserName = @UserName AND Password = @Password
GO

CREATE PROCEDURE UsuarioGetAll
AS
SELECT IdUsuario
      ,UserName
      ,Nombre
      ,ApellidoPaterno
      ,ApellidoMaterno
      ,Foto
      ,Password
  FROM Usuarios
GO

CREATE PROCEDURE UsuarioGetById
@IdUsuario INT
AS
SELECT IdUsuario
      ,UserName
      ,Nombre
      ,ApellidoPaterno
      ,ApellidoMaterno
      ,Foto
      ,Password
  FROM Usuarios
  WHERE IdUsuario = @IdUsuario
GO

CREATE PROCEDURE UsuarioAdd
@UserName varchar(50),
@Nombre varchar(50),
@ApellidoPaterno varchar(50),
@ApellidoMaterno varchar(50),
@Foto varbinary(max),
@Password varchar(50)
AS
INSERT INTO Usuarios
           (UserName
           ,Nombre
           ,ApellidoPaterno
           ,ApellidoMaterno
           ,Foto
           ,Password)
     VALUES
           (@UserName
           ,@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno
           ,@Foto
           ,@Password)
GO

CREATE PROCEDURE UsuarioUpdate
@IdUsuario INT,
@UserName varchar(50),
@Nombre varchar(50),
@ApellidoPaterno varchar(50),
@ApellidoMaterno varchar(50),
@Foto varbinary(max),
@Password varchar(50)
AS
UPDATE Usuarios SET
UserName = @UserName,
Nombre = @Nombre,
ApellidoPaterno = @ApellidoPaterno,
ApellidoMaterno = @ApellidoPaterno,
Foto = @Foto,
Password = @Password
WHERE IdUsuario = @IdUsuario
GO

CREATE PROCEDURE UsuarioDelete
@IdUsuario INT
AS
DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario

