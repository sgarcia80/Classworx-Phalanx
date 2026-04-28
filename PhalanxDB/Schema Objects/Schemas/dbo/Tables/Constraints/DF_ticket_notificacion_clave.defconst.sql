ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD CONSTRAINT [DF_ticket_notificacion_clave] DEFAULT (getdate()) FOR [tnc_fecha];

