ALTER TABLE [dbo].[Global_Win_Groups]
    ADD CONSTRAINT [FK_Global_Win_Groups_Win_Domains] FOREIGN KEY ([win_domain_id]) REFERENCES [dbo].[Win_Domains] ([win_domain_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

