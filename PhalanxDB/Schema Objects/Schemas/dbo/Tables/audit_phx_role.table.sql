CREATE TABLE [dbo].[audit_phx_role] (
    [audit_phx_role_id]    INT           IDENTITY (1, 1) NOT NULL,
    [phx_role_id]          INT           NOT NULL,
    [rolename]             VARCHAR (200) NOT NULL,
    [terminal_abm]         VARCHAR (150) NOT NULL,
    [id_usuario_abm]       INT           NOT NULL,
    [username_abm]         VARCHAR (100) NOT NULL,
    [fullname_abm]         VARCHAR (150) NOT NULL,
    [operacion]            VARCHAR (50)  NOT NULL,
    [accion_satisfactoria] BIT           NOT NULL,
    [fecha]                DATETIME      NOT NULL
);

