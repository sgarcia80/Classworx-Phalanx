
CREATE PROCEDURE dbo.DepurarAuditLogin
	@Fecha DATETIME
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION

	DECLARE @FechaBorrado DATETIME

	set @FechaBorrado = GETDATE()

	INSERT INTO 
		audit_login_historico (aud_login_id, fecha, terminal, id_usuario, username, fullname, evento_login_id, app_id, fecha_borrado)
	SELECT 
		aud_login_id, fecha, terminal, id_usuario, username, fullname, evento_login_id, app_id, @FechaBorrado
	FROM
		audit_login
	WHERE
		fecha <= @Fecha
	
	DELETE FROM
		audit_login
	WHERE
		fecha <= @Fecha

	COMMIT TRANSACTION

	SELECT 1 resultado
END

