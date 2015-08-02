ALTER TABLE [dbo].[Phx_Log]
    ADD CONSTRAINT [DF__Phx_Log__dbuser__1C873BEC] DEFAULT (user_name()) FOR [dbuser];

