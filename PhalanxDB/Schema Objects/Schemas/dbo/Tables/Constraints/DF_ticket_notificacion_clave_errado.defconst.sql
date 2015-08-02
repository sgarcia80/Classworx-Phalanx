ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD CONSTRAINT [DF_ticket_notificacion_clave_errado] DEFAULT ((0)) FOR [tnc_errado];

