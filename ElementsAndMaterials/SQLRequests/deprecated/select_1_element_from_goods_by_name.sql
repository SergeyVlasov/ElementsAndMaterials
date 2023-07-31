select 
	idgood as id_glasselement,
	marking as marking_glasselement,
	name as name_glasselement
from good g
where name like '%{1}%'
--{0}
