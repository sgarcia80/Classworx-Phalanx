/****** Object:  Trigger dbo.AddWinGroupToDelegRqstGrpDemo    Script Date: 05/11/2007 09:39:33 a.m. ******/
CREATE TRIGGER AddWinGroupToDelegRqstGrpDemo ON dbo.Win_Groups 
FOR INSERT
AS
begin
declare @AuthUserId as varchar(100)
select @AuthUserId = conf_value from demo_conf where conf_code = 'AUTHDELEGRQSTID'
if @AuthUserId is not null AND @AuthUserId <> ''
begin
declare @RqstgrpId as int
declare CURRqstGrps cursor for
select rqst_grp_id from dbo.Requests_Groups open CURRqstGrps
-- Avanzamos un registro y cargamos en las variables los valores encontrados en el primer registro
fetch next from CURRqstGrps
into @RqstgrpId
while @@fetch_status = 0
begin
-- busca passwords no asociados al grupo
declare @WinGroupId as int

declare CURWinGrpGrps cursor for
select win_group_id from Win_Groups wg
where not exists (select 1 from Rqst_Grps_Deleg rgd 
where rgd.rqst_grp_id = @RqstgrpId and wg.win_group_id = rgd.win_group_id)

open CURWinGrpGrps
fetch next from CURWinGrpGrps
into @WinGroupId
while @@fetch_status = 0
begin

INSERT INTO Rqst_Grps_Deleg
([rqst_grp_id], [win_group_id], [auth1_usr_id], [auth2_usr_id])
VALUES
(@RqstgrpId, @WinGroupId, @AuthUserId, null)

fetch next from CURWinGrpGrps
into @WinGroupId
end 
-- cerramos el cursor
close CURWinGrpGrps
deallocate CURWinGrpGrps 

-- termina cursor CURPwdGrps


-- Avanza otro registro
fetch next from CURRqstGrps
into @RqstgrpId
end 
-- cerramos el cursor
close CURRqstGrps
deallocate CURRqstGrps 

--rollback
end

end
