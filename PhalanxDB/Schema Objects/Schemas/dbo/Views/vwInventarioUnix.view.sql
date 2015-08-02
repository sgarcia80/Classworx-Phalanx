CREATE VIEW dbo.vwInventarioUnix
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, dbo.Unix.unx_server_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Unix_users ON dbo.Users.user_id = dbo.Unix_users.user_id INNER JOIN
                      dbo.Unix ON dbo.Unix_users.unx_id = dbo.Unix.unx_id
