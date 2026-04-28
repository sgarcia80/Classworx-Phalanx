ALTER TABLE [dbo].[Phx_Users_Groups]
    ADD CONSTRAINT [FK_Phx_Users_Groups_Qry_Groups] FOREIGN KEY ([rqst_grp_id]) REFERENCES [dbo].[Requests_Groups] ([rqst_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

