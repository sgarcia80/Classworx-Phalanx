CREATE VIEW dbo.vwInventarioAS400
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, dbo.AS400.as_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.AS400_users ON dbo.Users.user_id = dbo.AS400_users.user_id INNER JOIN
                      dbo.AS400 ON dbo.AS400_users.as_id = dbo.AS400.as_id
