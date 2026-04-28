CREATE TABLE [dbo].[audit_permisos] (
    [audit_permisos_id]    INT           IDENTITY (1, 1) NOT NULL,
    [recurso]              VARCHAR (50)  NOT NULL,
    [fecha]                DATETIME      NOT NULL,
    [terminal_abm]         VARCHAR (150) NOT NULL,
    [id_usuario_abm]       INT           NOT NULL,
    [username_abm]         VARCHAR (100) NOT NULL,
    [fullname_abm]         VARCHAR (150) NOT NULL,
    [id_rol]               INT           NOT NULL,
    [rol]                  VARCHAR (200) NOT NULL,
    [accion]               VARCHAR (50)  NOT NULL,
    [accion_satisfactoria] BIT           NOT NULL,
    [id_usuario]           INT           NOT NULL,
    [username]             VARCHAR (50)  NOT NULL,
    [fullname]             VARCHAR (100) NOT NULL
);

