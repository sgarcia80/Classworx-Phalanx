
CREATE  VIEW dbo.vwHistChgUnix
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.Unix.unx_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Users INNER JOIN
                      dbo.Unix_users ON dbo.Users.user_id = dbo.Unix_users.user_id INNER JOIN
                      dbo.Unix ON dbo.Unix_users.unx_id = dbo.Unix.unx_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id

