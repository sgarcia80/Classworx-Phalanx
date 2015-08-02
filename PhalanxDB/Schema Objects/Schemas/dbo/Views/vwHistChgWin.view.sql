
CREATE  VIEW dbo.vwHistChgWin
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, 
                      dbo.Win_Domains.nt_name + '\' + dbo.Win_PCs.pc_name + '\' + dbo.Users.username AS Usuario, dbo.hist_change_password.d_change, 
                      dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Win_PCs INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Win_Domains ON dbo.Win_PCs.win_domain_id = dbo.Win_Domains.win_domain_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.hist_change_password ON dbo.Users.user_id = dbo.hist_change_password.user_id

