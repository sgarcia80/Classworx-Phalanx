
/****** Object:  View dbo.vwPhxUsersRqstPwdGroups    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwPhxUsersRqstPwdGroups
AS
SELECT     dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id, dbo.Rqst_Grps_Pwds.rqst_grp_id, dbo.Requests_Groups.rqst_grp_name, 
                      dbo.Rqst_Grps_Pwds.user_password_id, dbo.Rqst_Grps_Pwds.auth1_usr_id, dbo.Rqst_Grps_Pwds.auth2_usr_id, 
                      dbo.Phx_Users_Groups.phx_user_id, dbo.Phx_Users.username, dbo.Phx_Users.fullname
FROM         dbo.Rqst_Grps_Pwds INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users ON dbo.Phx_Users_Groups.phx_user_id = dbo.Phx_Users.phx_user_id
WHERE     (dbo.Phx_Users.delete_date IS NULL)

