ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [DF_Phx_Users_active] DEFAULT (1) FOR [active];

