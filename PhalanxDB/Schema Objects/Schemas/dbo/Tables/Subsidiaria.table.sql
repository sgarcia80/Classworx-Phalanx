CREATE TABLE [dbo].[Subsidiaria] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [codigo]   VARCHAR (10) NOT NULL,
    [nombre]   VARCHAR (40) NOT NULL,
    [email_01] VARCHAR (50) NULL,
    [email_02] VARCHAR (50) NULL
);

