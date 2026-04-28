ALTER TABLE [dbo].[ticket_notificacion_clave]
    ADD CONSTRAINT [FK_ticket_notificacion_clave_aplicacion_notificacion_clave] FOREIGN KEY ([tnc_app_id]) REFERENCES [dbo].[aplicacion_notificacion_clave] ([anc_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

