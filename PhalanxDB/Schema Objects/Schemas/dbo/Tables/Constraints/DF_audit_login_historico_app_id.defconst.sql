ALTER TABLE [dbo].[audit_login_historico]
    ADD CONSTRAINT [DF_audit_login_historico_app_id] DEFAULT ((1)) FOR [app_id];

