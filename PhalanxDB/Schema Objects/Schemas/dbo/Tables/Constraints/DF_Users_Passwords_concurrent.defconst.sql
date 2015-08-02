ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF_Users_Passwords_concurrent] DEFAULT (0) FOR [concurrent];

