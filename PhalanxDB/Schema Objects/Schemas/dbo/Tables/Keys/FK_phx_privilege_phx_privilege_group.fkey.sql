ALTER TABLE [dbo].[phx_privilege]
    ADD CONSTRAINT [FK_phx_privilege_phx_privilege_group] FOREIGN KEY ([phx_prv_grp_id]) REFERENCES [dbo].[phx_privilege_group] ([phx_prv_grp_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

