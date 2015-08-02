ALTER TABLE [dbo].[audit_login_historico]
    ADD CONSTRAINT [DF_audit_login_historico_fecha] DEFAULT (getdate()) FOR [fecha];

