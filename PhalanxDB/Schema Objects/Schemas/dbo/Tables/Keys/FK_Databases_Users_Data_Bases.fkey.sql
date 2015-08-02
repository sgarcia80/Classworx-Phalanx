ALTER TABLE [dbo].[Databases_Users]
    ADD CONSTRAINT [FK_Databases_Users_Data_Bases] FOREIGN KEY ([db_id]) REFERENCES [dbo].[Data_Bases] ([db_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

