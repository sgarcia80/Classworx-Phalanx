CREATE VIEW dbo.vwPermisoPerfil
AS
SELECT     dbo.phx_privilege_role.phx_priv_role_id AS Id, dbo.Phx_Roles.phx_role_id AS RoleId, dbo.Phx_Roles.role_name AS RoleName, 
                      dbo.phx_privilege.phx_privilege_id AS PrivilegeId, dbo.phx_privilege.phx_privilege_name AS PrivilegeName
FROM         dbo.Phx_Roles INNER JOIN
                      dbo.phx_privilege_role ON dbo.Phx_Roles.phx_role_id = dbo.phx_privilege_role.phx_role_id INNER JOIN
                      dbo.phx_privilege ON dbo.phx_privilege_role.phx_privilege_id = dbo.phx_privilege.phx_privilege_id
