ALTER TABLE [dbo].[Applications_Users]
    ADD CONSTRAINT [FK_Applications_Users_Applications] FOREIGN KEY ([app_id]) REFERENCES [dbo].[Applications] ([app_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

