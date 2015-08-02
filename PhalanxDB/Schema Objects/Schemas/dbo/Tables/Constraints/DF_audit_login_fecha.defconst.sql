ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [DF_audit_login_fecha] DEFAULT (getdate()) FOR [fecha];

