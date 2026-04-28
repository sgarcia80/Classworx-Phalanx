ALTER TABLE [dbo].[Phx_Users]
    ADD CONSTRAINT [DF_Phx_Users_creation_date] DEFAULT (getdate()) FOR [creation_date];

