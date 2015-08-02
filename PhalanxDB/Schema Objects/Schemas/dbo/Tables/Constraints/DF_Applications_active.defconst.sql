ALTER TABLE [dbo].[Applications]
    ADD CONSTRAINT [DF_Applications_active] DEFAULT (1) FOR [active];

