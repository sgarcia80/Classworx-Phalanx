ALTER TABLE [dbo].[Users_Passwords]
    ADD CONSTRAINT [FK_Users_Passwords_Pwd_Lock_types] FOREIGN KEY ([pwd_lock_type_id]) REFERENCES [dbo].[Pwd_Lock_types] ([pwd_lock_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

