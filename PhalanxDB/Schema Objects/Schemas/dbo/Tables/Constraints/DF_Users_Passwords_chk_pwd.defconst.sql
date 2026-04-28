ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF_Users_Passwords_chk_pwd] DEFAULT (0) FOR [chk_pwd];

