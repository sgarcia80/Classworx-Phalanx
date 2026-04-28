CREATE VIEW dbo.vwPerfilUsuario
AS
SELECT     dbo.Phx_Roles_Users.phx_role_usr_id AS Id, dbo.Phx_Users.phx_user_id AS UserId, dbo.Phx_Users.user_domain AS UserDomain, 
                      dbo.Phx_Users.username AS UserName, dbo.Phx_Users.fullname AS FullName, dbo.Phx_Roles.phx_role_id AS RoleId, 
                      dbo.Phx_Roles.role_name AS RoleName
FROM         dbo.Phx_Users INNER JOIN
                      dbo.Phx_Roles_Users ON dbo.Phx_Users.phx_user_id = dbo.Phx_Roles_Users.phx_user_id INNER JOIN
                      dbo.Phx_Roles ON dbo.Phx_Roles_Users.phx_role_id = dbo.Phx_Roles.phx_role_id
WHERE     (dbo.Phx_Users.active = 1)
