
/****** Object:  View dbo.vwPhxUsersRqstDelGroups    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwPhxUsersRqstDelGroups
AS
SELECT     dbo.Rqst_Grps_Deleg.delrqst_grp_delg_id, dbo.Rqst_Grps_Deleg.rqst_grp_id, dbo.Requests_Groups.rqst_grp_name, 
                      dbo.Rqst_Grps_Deleg.win_group_id, dbo.Rqst_Grps_Deleg.auth1_usr_id, dbo.Rqst_Grps_Deleg.auth2_usr_id, dbo.Phx_Users_Groups.phx_user_id, 
                      dbo.Phx_Users.username, dbo.Phx_Users.fullname
FROM         dbo.Phx_Users INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Phx_Users.phx_user_id = dbo.Phx_Users_Groups.phx_user_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Phx_Users_Groups.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Rqst_Grps_Deleg ON dbo.Requests_Groups.rqst_grp_id = dbo.Rqst_Grps_Deleg.rqst_grp_id
WHERE     (dbo.Phx_Users.delete_date IS NULL)

