ALTER TABLE [dbo].[Data_Bases]
    ADD CONSTRAINT [DF_Data_Bases_active] DEFAULT (1) FOR [active];

