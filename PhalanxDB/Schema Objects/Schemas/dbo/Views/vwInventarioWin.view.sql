CREATE VIEW dbo.vwInventarioWin
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Win_Domains.nt_name + '\' + dbo.Win_PCs.pc_name + '\' + dbo.Users.username AS Usuario, dbo.Users.active_user AS Activo, 
                      dbo.Users.user_critical AS Critico
FROM         dbo.Win_PCs INNER JOIN
                      dbo.Win_Local_Users ON dbo.Win_PCs.win_pc_id = dbo.Win_Local_Users.win_pc_id INNER JOIN
                      dbo.Win_Domains ON dbo.Win_PCs.win_domain_id = dbo.Win_Domains.win_domain_id INNER JOIN
                      dbo.Users ON dbo.Win_Local_Users.user_id = dbo.Users.user_id INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id
