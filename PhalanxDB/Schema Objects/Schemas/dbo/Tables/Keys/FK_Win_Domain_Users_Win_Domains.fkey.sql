ALTER TABLE [dbo].[Win_Domain_Users]
    ADD CONSTRAINT [FK_Win_Domain_Users_Win_Domains] FOREIGN KEY ([win_domain_id]) REFERENCES [dbo].[Win_Domains] ([win_domain_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

