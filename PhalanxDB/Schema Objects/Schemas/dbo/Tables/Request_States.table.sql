CREATE TABLE [dbo].[Request_States] (
    [rqst_state_id]   INT           NOT NULL,
    [rqst_state_desc] VARCHAR (100) COLLATE Latin1_General_CI_AS NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estados de las solicitudes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Request_States';

