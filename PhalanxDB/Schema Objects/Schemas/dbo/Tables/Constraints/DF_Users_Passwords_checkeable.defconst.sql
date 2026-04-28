ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [DF_Users_Passwords_checkeable] DEFAULT ((1)) FOR [checkeable];

