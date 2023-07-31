DECLARE @marking_glasselement NVARCHAR(100)
set @marking_glasselement = (select marking from glasselement where idglasselement = {1})

select 
	idgood as id_glasselement,
	marking as marking_glasselement,
	name as name_glasselement
from good
where marking like '%' + @marking_glasselement + '%'

--{0}
