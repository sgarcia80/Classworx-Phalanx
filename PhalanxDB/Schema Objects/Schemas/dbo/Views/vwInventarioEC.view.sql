CREATE VIEW [dbo].[vwInventarioEC]
AS
SELECT     dbo.Users.user_id AS Folio, dbo.User_Types.user_type_desc AS Ambiente, 
                      dbo.Communication_Device_Types.cm_dv_type_name + '\' + dbo.Communication_Devices.cm_dv_name + '\' + dbo.Users.username AS Usuario, 
                      dbo.Users.active_user AS Activo, dbo.Users.user_critical AS Critico
FROM         dbo.Communication_Device_Types INNER JOIN
                      dbo.Communication_Devices ON dbo.Communication_Device_Types.cm_dv_type_id = dbo.Communication_Devices.cm_dv_type_id INNER JOIN
                      dbo.Communication_Device_Users ON dbo.Communication_Devices.cm_dv_id = dbo.Communication_Device_Users.cm_dv_id INNER JOIN
                      dbo.Users INNER JOIN
                      dbo.User_Types ON dbo.Users.user_type_id = dbo.User_Types.user_type_id ON dbo.Communication_Device_Users.user_id = dbo.Users.user_id

