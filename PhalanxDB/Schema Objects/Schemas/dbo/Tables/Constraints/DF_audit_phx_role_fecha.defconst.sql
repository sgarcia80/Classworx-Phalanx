ALTER TABLE [dbo].[audit_phx_role]
    ADD CONSTRAINT [DF_audit_phx_role_fecha] DEFAULT (getdate()) FOR [fecha];

