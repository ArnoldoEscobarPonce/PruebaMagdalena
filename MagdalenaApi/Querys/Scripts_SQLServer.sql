USE MASTER
GO

IF NOT  EXISTS (SELECT 1 FROM sys.databases WHERE name = N'MagdalenaDB')
	CREATE DATABASE MagdalenaDB
GO

USE MagdalenaDB
GO
IF OBJECT_ID('dbo.Actividad', 'U') IS NULL
BEGIN
	--DROP TABLE dbo.Actividad
	CREATE TABLE dbo.Actividad(
		Id INT PRIMARY KEY,
		Descripcion VARCHAR(555) NOT NULL,
		FechaInicio DATE,
		FechaEnProceso DATE,	
		FechaFinalizacion DATE,
		TareasRealizadas VARCHAR(999)
	)
END
GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Crear
	@Descripcion varchar(555),
	@FechaInicio date
AS
BEGIN
	DECLARE @Index INT = (SELECT ISNULL(MAX(Id),0)+1 FROM Actividad)
	
	INSERT INTO dbo.Actividad (Id, Descripcion, FechaInicio) 
	VALUES (@Index, @Descripcion, @FechaInicio)

END

GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Marcar_En_Proceso
	@Id int
AS
BEGIN
	UPDATE Actividad
	SET FechaEnProceso = GETDATE()
	WHERE Id = @Id
END

GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Marcar_Finalizada
	@Id int,
	@TareasRealizadas varchar(999)
AS
BEGIN
	UPDATE Actividad
	SET FechaFinalizacion = GETDATE(),
		TareasRealizadas = @TareasRealizadas
	WHERE Id = @Id
END

GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Listar
	@Id int = NULL
AS
BEGIN
	SELECT 	Id,
			Descripcion,
			FechaInicio,
			FechaEnProceso,
			FechaFinalizacion,
			TareasRealizadas
	FROM Actividad
	WHERE Id = ISNULL(@Id, Id)

END

GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Listar_Creadas
	@Id int = NULL
AS
BEGIN
	SELECT 	Id,
			Descripcion,
			FechaInicio,
			FechaEnProceso,
			FechaFinalizacion,
			TareasRealizadas
	FROM Actividad
	WHERE Id = ISNULL(@Id, Id)
	AND FechaEnProceso IS NULL
	AND FechaFinalizacion IS NULL
END

GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Listar_En_Proceso
	@Id int = NULL
AS
BEGIN
	SELECT 	Id,
			Descripcion,
			FechaInicio,
			FechaEnProceso,
			FechaFinalizacion,
			TareasRealizadas
	FROM Actividad
	WHERE Id = ISNULL(@Id, Id)
	AND FechaEnProceso IS NOT NULL
	AND FechaFinalizacion IS NULL
END

GO

CREATE OR ALTER PROCEDURE Sp_Actividad_Listar_Finalizadas
	@Id int = NULL
AS
BEGIN
	SELECT 	Id,
			Descripcion,
			FechaInicio,
			FechaEnProceso,
			FechaFinalizacion,
			TareasRealizadas
	FROM Actividad
	WHERE Id = ISNULL(@Id, Id)
	AND FechaFinalizacion IS NOT NULL
END

GO