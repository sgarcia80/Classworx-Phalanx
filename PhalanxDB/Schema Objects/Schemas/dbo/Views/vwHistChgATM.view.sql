
CREATE VIEW [dbo].[vwHistChgATM]
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.ATMs_Users.ATM_name + '\' + dbo.Users.username COLLATE DATABASE_DEFAULT AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Users INNER JOIN
                      dbo.ATMs_Users ON dbo.Users.user_id = dbo.ATMs_Users.user_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id
WHERE     (dbo.Users.user_type_id = 7)

