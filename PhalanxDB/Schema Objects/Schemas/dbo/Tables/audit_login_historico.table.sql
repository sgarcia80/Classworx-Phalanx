CREATE TABLE [dbo].[audit_login_historico] (
    [aud_login_id]    INT           NOT NULL,
    [fecha]           DATETIME      NOT NULL,
    [terminal]        VARCHAR (150) NOT NULL,
    [id_usuario]      INT           NULL,
    [username]        VARCHAR (50)  NOT NULL,
    [fullname]        VARCHAR (100) NULL,
    [evento_login_id] INT           NOT NULL,
    [app_id]          INT           NOT NULL,
    [fecha_borrado]   DATETIME      NULL
);

