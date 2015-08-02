ALTER TABLE [dbo].[Unix_users]
    ADD CONSTRAINT [FK_Unix_users_Unix] FOREIGN KEY ([unx_id]) REFERENCES [dbo].[Unix] ([unx_id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

