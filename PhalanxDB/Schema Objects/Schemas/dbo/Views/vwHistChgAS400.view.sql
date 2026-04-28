
CREATE VIEW dbo.vwHistChgAS400
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.AS400.as_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.AS400 INNER JOIN
                      dbo.AS400_users ON dbo.AS400.as_id = dbo.AS400_users.as_id INNER JOIN
                      dbo.hist_change_password INNER JOIN
                      dbo.Users ON dbo.hist_change_password.user_id = dbo.Users.user_id ON dbo.AS400_users.user_id = dbo.Users.user_id

