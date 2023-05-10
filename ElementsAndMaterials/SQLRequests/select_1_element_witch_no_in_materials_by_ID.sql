select distinct
	ge.idglasselement as id_glasselement,
	ge.marking as marking_glasselement,
	ge.name as name_glasselement
from good g
right join glasselement ge 
on g.name = ge.name 
where g.name is null
and ge.idglasselement = {1}
--{0}
