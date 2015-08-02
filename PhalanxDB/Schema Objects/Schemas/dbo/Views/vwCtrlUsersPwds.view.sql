
/****** Object:  View dbo.vwCtrlUsersPwds    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE VIEW dbo.vwCtrlUsersPwds
AS
SELECT     dbo.Win_Domains.win_domain_id, dbo.Win_Domains.nt_name, dbo.Win_PCs.win_pc_id, dbo.Win_PCs.pc_name, dbo.Win_Local_Users.user_id, 
                      dbo.Users.username, dbo.Users.active_user, dbo.Users_Passwords.user_password_id, dbo.Users_Passwords.password, 
                      dbo.Users_Passwords.static_pwd, dbo.Users_Passwords.d_next_change, dbo.Users_Passwords.d_last_change, dbo.Users_Passwords.change_freq, 
                      dbo.Users_Passwords.change_freq_unit, dbo.Users_Passwords.d_next_chk, dbo.Users_Passwords.d_last_chk, dbo.Users_Passwords.chk_freq, 
                      dbo.Users_Passwords.chk_freq_unit, dbo.Rqst_Grps_Pwds.pwdrqst_grp_pwd_id, dbo.Requests_Groups.rqst_grp_id, 
                      dbo.Requests_Groups.rqst_grp_name, dbo.Phx_Users_Groups.phx_usr_grp_id, dbo.Phx_Users.phx_user_id, 
                      dbo.Phx_Users.username AS phxuser_username, dbo.Phx_Users.fullname AS phxuser_fullname, dbo.Phx_Users.user_domain AS phxuser_domain, 
                      dbo.Rqst_Grps_Pwds.auth1_usr_id, Phx_Users_Auth.username AS auth_username, Phx_Users_Auth.fullname AS auth_fullname, 
                      Phx_Users_Auth.user_domain AS auth_domain
FROM         dbo.Win_Domains INNER JOIN
                      dbo.Win_PCs ON dbo.Win_Domains.win_domain_id = dbo.Win_PCs.win_domain_id INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.Users_Passwords ON dbo.Users.user_password_id = dbo.Users_Passwords.user_password_id INNER JOIN
                      dbo.Rqst_Grps_Pwds ON dbo.Users_Passwords.user_password_id = dbo.Rqst_Grps_Pwds.user_password_id INNER JOIN
                      dbo.Requests_Groups ON dbo.Rqst_Grps_Pwds.rqst_grp_id = dbo.Requests_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users_Groups ON dbo.Requests_Groups.rqst_grp_id = dbo.Phx_Users_Groups.rqst_grp_id INNER JOIN
                      dbo.Phx_Users ON dbo.Phx_Users_Groups.phx_user_id = dbo.Phx_Users.phx_user_id INNER JOIN
                      dbo.Phx_Users Phx_Users_Auth ON dbo.Rqst_Grps_Pwds.auth1_usr_id = Phx_Users_Auth.phx_user_id

