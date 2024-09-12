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
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE,
    activa BIT NOT NULL,
    tipo_subscripcion_id INT NOT NULL, 
    FOREIGN KEY (tipo_subscripcion_id) REFERENCES TipoSubscripcion(id) 
);

CREATE TABLE TipoSubscripcion (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(50) NOT NULL 
);

CREATE TABLE Contenido
(
    id INT PRIMARY KEY IDENTITY,
    titulo NVARCHAR(255) NOT NULL,
    genero NVARCHAR(100),
    tipo_subscripcion_id INT,
    FOREIGN KEY (tipo_subscripcion_id) REFERENCES TipoSubscripcion(id)
);
*/

/* STORE PROCEDURE */
/*
USE [SistemaStreaming]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Suscribir_Usuario]
    @usuarioID INT,
    @subscripcionID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET subscripcion_id = @subscripcionID
    WHERE id = @usuarioID;
    
    UPDATE Subscripcion
    SET activa = 1
    WHERE id = @subscripcionID;
END
*/


/*
USE [SistemaStreaming]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Cancelar_Suscripcion]
    @usuarioID INT
AS
BEGIN
    	SET NOCOUNT ON;

           UPDATE Subscripcion
    SET activa = 0
    WHERE id = (SELECT subscripcion_id FROM Usuario WHERE id = @usuarioID);
END


USE [SistemaStreaming]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Es_Suscripcion_Activa]
    @usuarioID INT
AS
BEGIN
    SET NOCOUNT ON;
			SELECT COUNT (*) from Subscripcion WHERE id = (SELECT subscripcion_id 
                                        FROM Usuario 
                                        WHERE id = @usuarioID
										and activa = 1) 
END
 */