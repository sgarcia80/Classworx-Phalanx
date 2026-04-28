ALTER TABLE [dbo].[followup_request_group_default]
    ADD CONSTRAINT [IX_followup_request_group_default] UNIQUE NONCLUSTERED ([user_type_id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];

