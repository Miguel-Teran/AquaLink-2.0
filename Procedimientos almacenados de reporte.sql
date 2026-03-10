SP_HELPTEXT INS_Reporte

--Procedimiento de Insertar
CREATE PROCEDURE Ins_Reporte
	@Descripcion VARCHAR(200),
	@Fecha DATE,
	@Latitud DECIMAL (18,10),
	@Longitud DECIMAL (18,10),
	@Usuario INT
AS

	SET NOCOUNT ON

	INSERT INTO Reporte (Rep_Descripción, Rep_Fecha, Rep_Lat, Rep_Lon, Rep_IdUsu)
	VALUES (@Descripcion, @Fecha, @Latitud, @Longitud, @Usuario)

	PRINT 'El reporte se insertó exitosamente'

--Procedimeinto de Actualizar
CREATE PROCEDURE Act_Reporte
	@Clave INT,
	@Descripcion VARCHAR(200),
	@Fecha DATE,
	@Latitud DECIMAL (18,10),
	@Longitud DECIMAL (18,10)
AS
	UPDATE Reporte SET
	Rep_Descripción = @Descripcion,
	Rep_Fecha = @Fecha,
	Rep_Lat = @Latitud,
	Rep_Lon = @Longitud
	
	WHERE Rep_Id = @Clave

	PRINT 'El  reporte '+CAST(@Clave AS VARCHAR(5))+' se actualizó exitosamente'

--Procedimiento de Buscar
CREATE PROCEDURE Bus_Reporte
	@Clave INT
AS
	SELECT * FROM Reporte
	WHERE Rep_Id = @Clave

--Procedimiento de Eliminar
CREATE PROCEDURE Del_Reporte
	@Clave INT
AS
	DECLARE @Existe INT
	SET @Existe = 0
	IF exists (SELECT * FROM Reporte WHERE Rep_Id = @Clave)
	BEGIN
		SET @Existe = 1
		DELETE FROM Reporte
		WHERE Rep_Id = @Clave
	END

	IF @Existe = 1
	BEGIN
		PRINT 'El reporte '+CAST(@Clave AS VARCHAR (5))+' se eliminó exitosamente'
	END
	ELSE
	BEGIN
		PRINT 'El reporte '+CAST(@Clave AS VARCHAR (5))+' no existe, por lo cual no se eliminó'
	END

--Procedimiento de Listar
CREATE PROCEDURE Listar_Reporte
	@Descripcion VARCHAR (200)
AS
	SELECT * FROM Reporte WHERE Rep_Descripción LIKE '%'+@Descripcion+'%'