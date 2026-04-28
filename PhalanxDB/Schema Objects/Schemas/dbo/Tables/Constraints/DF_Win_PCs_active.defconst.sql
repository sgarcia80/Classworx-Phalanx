ALTER TABLE [dbo].[Win_PCs]
    ADD CONSTRAINT [DF_Win_PCs_active] DEFAULT (1) FOR [active];

