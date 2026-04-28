CREATE VIEW dbo.vwInventarioApp
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, dbo.Applications.app_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Applications_Users ON dbo.Users.user_id = dbo.Applications_Users.user_id INNER JOIN
                      dbo.Applications ON dbo.Applications_Users.app_id = dbo.Applications.app_id
