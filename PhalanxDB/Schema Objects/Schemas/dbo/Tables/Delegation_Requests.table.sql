CREATE TABLE [dbo].[Delegation_Requests] (
    [request_id]   INT NOT NULL,
    [win_group_id] INT NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Grupos de usuarios habilitados para delegación de permisos con sus restricciones', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Delegation_Requests';

