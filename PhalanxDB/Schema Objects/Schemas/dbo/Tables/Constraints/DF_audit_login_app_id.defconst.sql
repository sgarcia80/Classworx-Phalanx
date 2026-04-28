ALTER TABLE [dbo].[audit_login]
    ADD CONSTRAINT [DF_audit_login_app_id] DEFAULT ((1)) FOR [app_id];

