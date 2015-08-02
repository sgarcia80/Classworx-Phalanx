ALTER TABLE [dbo].[Win_Domain_Controllers]
    ADD CONSTRAINT [FK_Win_Domain_Controllers_Win_Domain_Users] FOREIGN KEY ([impersonate_user_id]) REFERENCES [dbo].[Win_Domain_Users] ([user_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

