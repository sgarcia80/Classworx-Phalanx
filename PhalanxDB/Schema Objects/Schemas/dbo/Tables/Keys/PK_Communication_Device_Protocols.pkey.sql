ALTER TABLE [dbo].[Communication_Device_Protocols]
    ADD CONSTRAINT [PK_Communication_Device_Protocols] PRIMARY KEY CLUSTERED ([cm_dv_protocol_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

