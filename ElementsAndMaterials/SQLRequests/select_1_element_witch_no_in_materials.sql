select distinct
	ge.name name_glasselement,
	ge.idglasselement id_glasselement,
	ge.marking marking_glasselement
from good g
right join glasselement ge 
on g.name = ge.name 
where g.name is null
and ge.name = '{1}'
--{0}
