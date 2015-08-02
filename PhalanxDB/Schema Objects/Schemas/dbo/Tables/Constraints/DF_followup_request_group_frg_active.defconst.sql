ALTER TABLE [dbo].[followup_request_group]
    ADD CONSTRAINT [DF_followup_request_group_frg_active] DEFAULT ((1)) FOR [frg_active];

