CREATE TABLE [dbo].[audit_ticket_notificacion] (
    [atn_id]     INT      IDENTITY (1, 1) NOT NULL,
    [atn_fecha]  DATETIME NOT NULL,
    [atn_tnc_id] INT      NOT NULL
);

