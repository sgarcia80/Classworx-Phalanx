ALTER TABLE [dbo].[Applications]
    ADD CONSTRAINT [DF_Applications_desactiva_pwd_cierre] DEFAULT ((0)) FOR [desactiva_pwd_cierre];

