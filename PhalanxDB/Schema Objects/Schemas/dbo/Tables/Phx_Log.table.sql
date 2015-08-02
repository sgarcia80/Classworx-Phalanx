CREATE TABLE [dbo].[Phx_Log] (
    [phx_log_id]    INT           IDENTITY (1, 1) NOT NULL,
    [dbuser]        VARCHAR (50)  COLLATE Latin1_General_CI_AS NOT NULL,
    [creation_date] DATETIME      NOT NULL,
    [Application]   VARCHAR (70)  COLLATE Latin1_General_CI_AS NULL,
    [log_type]      CHAR (1)      COLLATE Latin1_General_CI_AS NOT NULL,
    [Code]          INT           NULL,
    [source]        VARCHAR (200) COLLATE Latin1_General_CI_AS NULL,
    [description]   VARCHAR (500) COLLATE Latin1_General_CI_AS NULL,
    [computer]      VARCHAR (50)  COLLATE Latin1_General_CI_AS NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Tabla para log del sistema', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'tipo de log: W: warning - E: error - I: information - A: audit', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log', @level2type = N'COLUMN', @level2name = N'log_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'codigo de error', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log', @level2type = N'COLUMN', @level2name = N'Code';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'origen del log (funcion, programa, etc)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Phx_Log', @level2type = N'COLUMN', @level2name = N'source';

