CREATE TABLE [dbo].[Win_Local_Users] (
    [user_id]   INT NOT NULL,
    [win_pc_id] INT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Subtipo de Users. Es para usuario Locales de una PC', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Win_Local_Users';

