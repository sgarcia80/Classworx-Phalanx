
/****** Object:  Trigger dbo.pwdlocktype_chg    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE TRIGGER pwdlocktype_chg ON [dbo].[Users_Passwords] 
AFTER UPDATE
AS

set nocount on
IF NOT UPDATE(pwd_lock_type_id)
return

declare @pwd_id as int
select @pwd_id = user_password_id from inserted
IF EXISTS (SELECT 1 FROM INSERTED WHERE PWD_LOCK_TYPE_ID IS NOT NULL)
BEGIN
UPDATE Users_Passwords SET D_LOCK_PWD = getdate() where user_password_id = @pwd_id
END
ELSE
BEGIN
UPDATE Users_Passwords SET D_LOCK_PWD = NULL where user_password_id = @pwd_id
END


set nocount off
