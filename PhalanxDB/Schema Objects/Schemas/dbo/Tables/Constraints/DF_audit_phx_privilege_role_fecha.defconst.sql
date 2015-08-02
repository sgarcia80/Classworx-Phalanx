ALTER TABLE [dbo].[audit_phx_privilege_role]
    ADD CONSTRAINT [DF_audit_phx_privilege_role_fecha] DEFAULT (getdate()) FOR [fecha];

