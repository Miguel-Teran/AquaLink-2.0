SP_HELPTEXT INS_Comentario

--Procedimiento de Insertar
CREATE PROCEDURE Ins_Comentario
	@Clave INT,
	@Usuario INT,
	@Reporte INT,
	@Descripcion VARCHAR(100)
AS
	SET NOCOUNT ON

	INSERT INTO Comentario(Com_IdUsu, Com_IdRep,Com_Descripcion )
	VALUES (@Usuario, @Reporte, @Descripcion)

	PRINT 'El comentario '+CAST(@Clave AS VARCHAR (5))+ 'se insertó exitosamente'

--Procedimeinto de Actualizar
CREATE PROCEDURE Act_Comentario
	@Clave INT,
	@Usuario INT,
	@Reporte INT,
	@Descripcion VARCHAR(200)
AS
	UPDATE Comentario SET
	Com_IdUsu = @Usuario,
	Com_IdRep = @Reporte,
	Com_Descripcion = @Descripcion
	WHERE Com_Id = @Clave

	PRINT 'El  comentario '+CAST(@Clave AS VARCHAR(5))+' se actualizó exitosamente'

--Procedimiento de Buscar
CREATE PROCEDURE Bus_Comentario
	@Clave INT
AS
	SELECT * FROM Comentario
	WHERE Com_Id = @Clave

--Procedimiento de Eliminar
CREATE PROCEDURE Del_Comentario
	@Clave INT
AS
	DECLARE @Existe INT
	SET @Existe = 0
	IF exists (SELECT * FROM Comentario WHERE Com_Id = @Clave)
	BEGIN
		SET @Existe = 1
		DELETE FROM Comentario
		WHERE Com_Id = @Clave
	END

	IF @Existe = 1
	BEGIN
		PRINT 'El comentario '+CAST(@Clave AS VARCHAR (5))+' se eliminó exitosamente'
	END
	ELSE
	BEGIN
		PRINT 'El comentario '+CAST(@Clave AS VARCHAR (5))+' no existe, por lo cual no se eliminó'
	END

--Procedimiento de Listar
CREATE PROCEDURE Listar_Comentario
	@Descripcion VARCHAR (200)
AS
	SELECT * FROM Comentario WHERE Com_Descripcion LIKE '%'+@Descripcion+'%'