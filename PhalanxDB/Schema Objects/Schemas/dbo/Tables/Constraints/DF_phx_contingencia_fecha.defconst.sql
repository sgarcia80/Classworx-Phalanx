ALTER TABLE [dbo].[phx_contingencia]
    ADD CONSTRAINT [DF_phx_contingencia_fecha] DEFAULT (getdate()) FOR [fecha];

