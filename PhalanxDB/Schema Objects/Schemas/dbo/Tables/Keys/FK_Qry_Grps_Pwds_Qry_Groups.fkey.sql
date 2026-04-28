ALTER TABLE [dbo].[Rqst_Grps_Pwds]
    ADD CONSTRAINT [FK_Qry_Grps_Pwds_Qry_Groups] FOREIGN KEY ([rqst_grp_id]) REFERENCES [dbo].[Requests_Groups] ([rqst_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

