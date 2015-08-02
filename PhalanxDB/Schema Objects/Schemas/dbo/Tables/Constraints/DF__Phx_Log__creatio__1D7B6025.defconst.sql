ALTER TABLE [dbo].[Phx_Log]
    ADD CONSTRAINT [DF__Phx_Log__creatio__1D7B6025] DEFAULT (getdate()) FOR [creation_date];

