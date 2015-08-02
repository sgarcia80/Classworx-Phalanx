
CREATE  VIEW dbo.vwHistChgDB
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, 
                      dbo.Database_Types.db_type_name + '\' + dbo.Data_Bases.db_name + '\' + dbo.Users.username AS Usuario, dbo.hist_change_password.d_change, 
                      dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Database_Types INNER JOIN
                      dbo.Data_Bases ON dbo.Database_Types.db_type_id = dbo.Data_Bases.db_type_id INNER JOIN
                      dbo.Databases_Users ON dbo.Data_Bases.db_id = dbo.Databases_Users.db_id INNER JOIN
                      dbo.Users ON dbo.Databases_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id

