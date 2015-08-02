
CREATE PROCEDURE dbo.DepurarChangePasswordLog
	@Fecha DATETIME
AS
BEGIN
	SET NOCOUNT ON

	BEGIN TRANSACTION

	DECLARE @FechaBorrado DATETIME

	set @FechaBorrado = GETDATE()

	INSERT INTO 
		hist_change_password_historico (hist_chg_pwd_id, [user_id], phx_user_id, d_change, [password], fecha_borrado)
	SELECT 
		hist_chg_pwd_id, [user_id], phx_user_id, d_change, [password], @FechaBorrado
	FROM
		hist_change_password
	WHERE
		d_change <= @Fecha
	
	DELETE FROM
		hist_change_password
	WHERE
		d_change <= @Fecha

	COMMIT TRANSACTION

	SELECT 1 resultado
END

