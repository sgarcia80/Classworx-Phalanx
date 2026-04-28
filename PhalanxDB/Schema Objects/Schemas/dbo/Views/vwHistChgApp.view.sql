
CREATE  VIEW dbo.vwHistChgApp
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, dbo.Applications.app_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Users INNER JOIN
                      dbo.Applications_Users ON dbo.Users.user_id = dbo.Applications_Users.user_id INNER JOIN
                      dbo.Applications ON dbo.Applications_Users.app_id = dbo.Applications.app_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id

