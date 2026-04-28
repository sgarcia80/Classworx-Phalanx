CREATE VIEW [dbo].[vwHistChgCD]
AS
SELECT     dbo.hist_change_password.hist_chg_pwd_id AS Id, dbo.Users.user_id AS Folio, 
                      dbo.Communication_Device_Types.cm_dv_type_name + '\' + dbo.Communication_Devices.cm_dv_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.hist_change_password.d_change, dbo.Users.user_type_id, dbo.hist_change_password.phx_user_id, dbo.hist_change_password.password
FROM         dbo.Communication_Devices INNER JOIN
                      dbo.Communication_Device_Types ON dbo.Communication_Devices.cm_dv_type_id = dbo.Communication_Device_Types.cm_dv_type_id INNER JOIN
                      dbo.Communication_Device_Users ON dbo.Communication_Devices.cm_dv_id = dbo.Communication_Device_Users.cm_dv_id INNER JOIN
                      dbo.hist_change_password INNER JOIN
                      dbo.Users ON dbo.hist_change_password.user_id = dbo.Users.user_id ON dbo.Communication_Device_Users.user_id = dbo.Users.user_id

