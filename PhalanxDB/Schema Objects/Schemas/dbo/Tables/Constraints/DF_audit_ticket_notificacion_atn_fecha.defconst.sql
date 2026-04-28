ALTER TABLE [dbo].[audit_ticket_notificacion]
    ADD CONSTRAINT [DF_audit_ticket_notificacion_atn_fecha] DEFAULT (getdate()) FOR [atn_fecha];

