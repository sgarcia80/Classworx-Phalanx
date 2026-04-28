
/****** Object:  View dbo.vwCtrlGlobalWinGrps    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwCtrlGlobalWinGrps
AS
SELECT     dbo.Win_Domains.win_domain_id, dbo.Win_Domains.nt_name, dbo.Win_Groups.win_group_id, dbo.Win_Groups.nt_group_name, 
                      dbo.Rqst_Grps_Deleg.delrqst_grp_delg_id, dbo.Requests_Groups.rqst_grp_id, dbo.Requests_Groups.rqst_grp_name, 
                      dbo.Phx_Users_Groups.phx_usr_grp_id, Phx_Users_1.phx_user_id, Phx_Users_1.username AS phx_username, 
                      Phx_Users_1.user_domain AS phx_user_domain, Phx_Users_1.phx_user_id AS phx_authuser_id, Phx_Users_1.username AS phx_authusername, 
                      Phx_Users_1.user_domain AS phx_authuser_domain
FROM         dbo.Win_Groups INNER JOIN
                      dbo.Win_Domains INNER JOIN
                      dbo.Global_Win_Groups ON dbo.Win_Domains.win_domain_id = dbo.Global_Win_Groups.win_domain_id ON 
                      dbo.Win_Groups.win_group_id = dbo.Global_Win_Groups.win_group_id INNER JOIN
                      dbo.Requests_Groups INNER JOIN
                      dbo.Rqst_Grps_Deleg ON dbo.Requests_Groups.rqst_grp_id = dbo.Rqst_Grps_Deleg.rqst_grp_id INNER JOIN
                      dbo.Phx_Users Phx_Users_1 ON dbo.Rqst_Grps_Deleg.auth1_usr_id = Phx_Users_1.phx_user_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users Phx_Users_2 ON dbo.Phx_Users_Groups.phx_user_id = Phx_Users_2.phx_user_id ON 
                      dbo.Global_Win_Groups.win_group_id = dbo.Rqst_Grps_Deleg.win_group_id

