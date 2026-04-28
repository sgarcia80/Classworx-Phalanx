CREATE TABLE [dbo].[Requests_Groups] (
    [rqst_grp_id]     INT          IDENTITY (1, 1) NOT NULL,
    [rqst_grp_name]   VARCHAR (50) COLLATE Latin1_General_CI_AS NOT NULL,
    [rqst_grp_active] BIT          NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Los query groups son los grupos de usuarios que se relacionan con la consulta de passwords', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests_Groups';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Nombre del grupo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests_Groups', @level2type = N'COLUMN', @level2name = N'rqst_grp_name';

