

CREATE VIEW [dbo].[vwPwdRqstGrp]
AS
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdAppRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdAS400RqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdATMRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdDBRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdECRqstGrp
UNION
SELECT     ID, Folio, IDAmbiente, Ambiente, Usuario COLLATE DATABASE_DEFAULT AS Usuario, Activo, Critico, IDGrupo, Grupo, GrupoActivo
FROM         dbo.vwPwdUnixRqstGrp AS vwPwdWinRqstGrp

