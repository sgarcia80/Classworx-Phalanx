ALTER TABLE [dbo].[Win_PCs]
    ADD CONSTRAINT [DF_Win_PCs_checkable] DEFAULT ((1)) FOR [checkable];

