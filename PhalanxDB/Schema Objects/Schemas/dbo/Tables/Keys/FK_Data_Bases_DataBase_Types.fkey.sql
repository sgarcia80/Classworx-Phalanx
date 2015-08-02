ALTER TABLE [dbo].[Data_Bases]
    ADD CONSTRAINT [FK_Data_Bases_DataBase_Types] FOREIGN KEY ([db_type_id]) REFERENCES [dbo].[Database_Types] ([db_type_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

