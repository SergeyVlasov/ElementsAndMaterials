
select distinct
	ge.idglasselement as id_glasselement,
	ge.marking as marking_glasselement,
	ge.name as name_glasselement
from good g
right join glasselement ge
on g.marking = '{0}' + ge.marking + '{1}'
where g.name is null
--and ge.name = '{2}'
and ge.typ = {3}
and g.deleted is null

--and ge.typ = 0   -- стекло
--and ge.typ = 1   -- рамка
--and ge.typ = 2   -- шпроссы
--and ge.typ = 3   -- пленки
--and ge.typ = 4   -- ленты



