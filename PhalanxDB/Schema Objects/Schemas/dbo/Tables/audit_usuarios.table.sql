CREATE TABLE [dbo].[audit_usuarios] (
    [aud_usr_id]            INT           IDENTITY (1, 1) NOT NULL,
    [recurso]               VARCHAR (50)  NOT NULL,
    [id_usuario]            INT           NOT NULL,
    [username]              VARCHAR (50)  NOT NULL,
    [fullname]              VARCHAR (100) NOT NULL,
    [fecha]                 DATETIME      NOT NULL,
    [operacion]             VARCHAR (50)  NOT NULL,
    [id_usuario_abm]        INT           NOT NULL,
    [username_abm]          VARCHAR (50)  NOT NULL,
    [fullname_abm]          VARCHAR (100) NOT NULL,
    [terminal_abm]          VARCHAR (150) NOT NULL,
    [accion_satisfactoria]  BIT           NOT NULL,
    [audit_phx_user_id_old] INT           NULL,
    [audit_phx_user_id_new] INT           NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Indica si es A(alta) B(baja) o M(modificacion)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'audit_usuarios', @level2type = N'COLUMN', @level2name = N'operacion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Terminal desde donde se hace el ABM', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'audit_usuarios', @level2type = N'COLUMN', @level2name = N'terminal_abm';

