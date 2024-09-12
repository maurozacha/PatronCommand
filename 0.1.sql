/* TABLAS */

/* 
CREATE TABLE Usuario (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    nom_usuario NVARCHAR(50) NOT NULL,
    mail NVARCHAR(100) NOT NULL,
    edad INT NOT NULL,
    subscripcion_id INT, 
    FOREIGN KEY (subscripcion_id) REFERENCES Subscripcion(Id) 
);

CREATE TABLE Subscripcion (
    id INT PRIMARY KEY IDENTITY(1,1),
    activa BIT NOT NULL,
    tipo_subscripcion_id INT NOT NULL, 
    FOREIGN KEY (tipo_subscripcion_id) REFERENCES TipoSubscripcion(id) 
);

CREATE TABLE TipoSubscripcion (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL 
);

*/

/* STORE PROCEDURE */
/*

CREATE PROCEDURE [dbo].[Obtener_TiposSubscripcion]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id, nombre
    FROM TipoSubscripcion;
END
GO

USE [SistemaStreaming]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [SistemaStreaming]
GO
/****** Object:  StoredProcedure [dbo].[Suscribir_Usuario]    Script Date: 12/9/2024 7:34:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Suscribir_Usuario]
   @nombre NVARCHAR(255),
    @nomUsuario NVARCHAR(255),
    @mail NVARCHAR(255),
    @edad INT,
    @subscripcionID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar el nuevo usuario con la suscripción
    INSERT INTO Usuario (nombre, nom_usuario, mail, edad, subscripcion_id)
    VALUES (@nombre, @nomUsuario, @mail, @edad, @subscripcionID);
END
GO
*/


/*
ALTER PROCEDURE [dbo].[Cancelar_Suscripcion]
    @usuarioID INT,
    @subscripcionID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Subscripcion
    SET activa = 0
    WHERE id = @subscripcionID
    AND id IN (SELECT subscripcion_id FROM Usuario WHERE id = @usuarioID);
END

USE [SistemaStreaming]
GO
/****** Object:  StoredProcedure [dbo].[Obtener_Usuarios_Suscripciones]    Script Date: 12/9/2024 8:24:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Obtener_Usuarios_Suscripciones]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.id AS UsuarioID,
        u.nom_usuario AS NombreUsuario,
        u.nombre AS NombreCompleto,
        u.mail AS Correo,
        u.edad AS Edad,
        s.id AS SubscripcionID,
        s.activa AS SubscripcionActiva,
        ts.nombre AS TipoSubscripcion
    FROM 
        Usuario u
    INNER JOIN 
        Subscripcion s ON u.subscripcion_id = s.id
    INNER JOIN 
        TipoSubscripcion ts ON s.tipo_subscripcion_id = ts.id
	WHERE s.activa = 1;
END;

CREATE PROCEDURE [dbo].[Usuario_Por_Nombre]
    @nombre NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id, nombre, nom_usuario, mail, edad
    FROM Usuario
    WHERE nom_usuario = @nombre;
END
GO

CREATE PROCEDURE [dbo].[Subscripcion_Por_Tipo]
    @tipo NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        S.id, 
        S.activa, 
        TS.nombre AS tipoSubscripcion
    FROM 
        Subscripcion S
    INNER JOIN 
        TipoSubscripcion TS ON S.tipo_subscripcion_id = TS.id
    WHERE 
        TS.nombre = @tipo;
END
GO

 */