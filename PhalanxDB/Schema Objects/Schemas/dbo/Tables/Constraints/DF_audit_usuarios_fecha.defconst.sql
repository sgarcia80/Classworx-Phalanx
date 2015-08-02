ALTER TABLE [dbo].[audit_usuarios]
    ADD CONSTRAINT [DF_audit_usuarios_fecha] DEFAULT (getdate()) FOR [fecha];

