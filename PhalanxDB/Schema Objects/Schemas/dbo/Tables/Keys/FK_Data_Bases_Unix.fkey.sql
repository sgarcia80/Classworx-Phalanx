ALTER TABLE [dbo].[Data_Bases]
    ADD CONSTRAINT [FK_Data_Bases_Unix] FOREIGN KEY ([unx_id]) REFERENCES [dbo].[Unix] ([unx_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

