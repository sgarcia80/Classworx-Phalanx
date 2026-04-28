
CREATE VIEW [dbo].[vwInventario]
AS
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioApp
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioUnix
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioDB
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioWin
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioAS400
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         vwInventarioEC
UNION
SELECT     Folio, Ambiente, Usuario COLLATE DATABASE_DEFAULT as Usuario, Activo, Critico
FROM         dbo.vwInventarioATM


