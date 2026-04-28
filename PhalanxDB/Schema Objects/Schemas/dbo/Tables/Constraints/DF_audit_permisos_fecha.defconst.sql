ALTER TABLE [dbo].[audit_permisos]
    ADD CONSTRAINT [DF_audit_permisos_fecha] DEFAULT (getdate()) FOR [fecha];

