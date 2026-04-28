ALTER TABLE [dbo].[Rqst_Grps_Deleg]
    ADD CONSTRAINT [FK_Rqst_Grps_Deleg_Requests_Groups] FOREIGN KEY ([rqst_grp_id]) REFERENCES [dbo].[Requests_Groups] ([rqst_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

