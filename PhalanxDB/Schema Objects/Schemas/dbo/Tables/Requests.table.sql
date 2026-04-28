CREATE TABLE [dbo].[Requests] (
    [request_id]              INT           IDENTITY (1, 1) NOT NULL,
    [rqst_user_id]            INT           NOT NULL,
    [request_date]            DATETIME      NOT NULL,
    [auth1_usr_id]            INT           NULL,
    [auth1_date]              DATETIME      NULL,
    [auth2_usr_id]            INT           NULL,
    [auth2_date]              DATETIME      NULL,
    [rqst_state_id]           INT           NOT NULL,
    [hours_requested]         INT           NULL,
    [unit_requested]          VARCHAR (1)   COLLATE Latin1_General_CI_AS NULL,
    [hours_given]             INT           NULL,
    [unit_given]              VARCHAR (1)   COLLATE Latin1_General_CI_AS NULL,
    [request_desc]            VARCHAR (500) COLLATE Latin1_General_CI_AS NULL,
    [auth_desc]               VARCHAR (500) COLLATE Latin1_General_CI_AS NULL,
    [expiration_date]         DATETIME      NULL,
    [return_date]             DATETIME      NULL,
    [return_note]             VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [return_usr_id]           INT           NULL,
    [close_date]              DATETIME      NULL,
    [close_note]              VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [close_usr_id]            INT           NULL,
    [expirada_sin_visualizar] BIT           NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Se almacenan todas las consultas de passwords y delegación de permisos hechos por los usuarios', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario que realizó la consulta', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'rqst_user_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Fecha en que se hizo la solicitud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'request_date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario Autorizador 1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth1_usr_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que el autorizador 1 autorizó', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth1_date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Usuario Autorizador 2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth2_usr_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'fecha en que el autorizador 2 autorizó', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth2_date';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Estado en que se encuentra la solicitud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'rqst_state_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'cantidad de horas solicitadas', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'hours_requested';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'h = horas    d = dias   - Unidad de tiempo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'unit_requested';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Cantidad de horas concedidas', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'hours_given';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'h = horas    d = dias   - Unidad de tiempo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'unit_given';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Descripción de la solicitud', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'request_desc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Motivo del rechazo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'auth_desc';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Usuario que devuelve la contraseña. Si es igual al rqst_user_id la devuelve el mismo solicitante', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Requests', @level2type = N'COLUMN', @level2name = N'return_usr_id';

