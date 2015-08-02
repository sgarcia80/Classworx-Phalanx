CREATE TABLE [dbo].[Passwords_Requests] (
    [request_id]       INT NOT NULL,
    [user_password_id] INT NOT NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = 'Password consultado', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Passwords_Requests', @level2type = N'COLUMN', @level2name = N'user_password_id';

