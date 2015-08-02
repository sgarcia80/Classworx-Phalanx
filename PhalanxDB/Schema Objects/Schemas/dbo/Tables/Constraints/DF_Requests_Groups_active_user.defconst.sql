ALTER TABLE [dbo].[Requests_Groups]
    ADD CONSTRAINT [DF_Requests_Groups_active_user] DEFAULT ((1)) FOR [rqst_grp_active];

