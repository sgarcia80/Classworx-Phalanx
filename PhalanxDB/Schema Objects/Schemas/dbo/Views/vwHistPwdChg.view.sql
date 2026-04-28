CREATE VIEW [dbo].[vwHistPwdChg]
AS
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgApp
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgUnix
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgDB
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgWin
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgAS400
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         vwHistChgCD
UNION
SELECT     Id, Folio, Usuario COLLATE DATABASE_DEFAULT as Usuario, d_change, user_type_id, phx_user_id, password
FROM         dbo.vwHistChgATM


