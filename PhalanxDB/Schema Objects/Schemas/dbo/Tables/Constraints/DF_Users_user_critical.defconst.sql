ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [DF_Users_user_critical] DEFAULT (0) FOR [user_critical];

