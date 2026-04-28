ALTER TABLE [dbo].[Unix]
    ADD CONSTRAINT [DF_Unix_active] DEFAULT (1) FOR [active];

