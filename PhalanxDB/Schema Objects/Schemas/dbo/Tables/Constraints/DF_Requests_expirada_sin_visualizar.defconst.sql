ALTER TABLE [dbo].[Requests]
    ADD CONSTRAINT [DF_Requests_expirada_sin_visualizar] DEFAULT ((0)) FOR [expirada_sin_visualizar];

