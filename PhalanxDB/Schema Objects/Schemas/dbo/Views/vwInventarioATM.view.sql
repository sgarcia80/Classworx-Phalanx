





CREATE VIEW [dbo].[vwInventarioATM]
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.ATMs_Users.ATM_name + '\' + dbo.Users.username COLLATE DATABASE_DEFAULT AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico
FROM         dbo.ATMs_Users INNER JOIN
                      dbo.Users ON dbo.ATMs_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id
WHERE     (dbo.Users.user_type_id = 7)

