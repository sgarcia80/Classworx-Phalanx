ALTER TABLE [dbo].[phx_version]
    ADD CONSTRAINT [DF_phx_version_implementation_date] DEFAULT (getdate()) FOR [implementation_date];

