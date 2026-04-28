

CREATE VIEW [dbo].[vwPwdUnixRqstGrp]
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id AS ID, dbo.Users.user_id AS Folio, dbo.User_Types.user_type_id AS IDAmbiente, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Unix.unx_server_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico, 
                      dbo.Requests_Groups.rqst_grp_id AS IDGrupo, dbo.Requests_Groups.rqst_grp_name AS Grupo, 
                      dbo.Requests_Groups.rqst_grp_active AS GrupoActivo
FROM         dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id INNER JOIN
                      dbo.Unix_users ON dbo.Users.user_id = dbo.Unix_users.user_id INNER JOIN
                      dbo.Unix ON dbo.Unix_users.unx_id = dbo.Unix.unx_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id

