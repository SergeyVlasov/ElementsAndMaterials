DECLARE @TempTable TABLE
(
 id_good INT,
 name_good NVARCHAR(100),
 marking_good NVARCHAR(100),
 id_glasselement INT,
 marking_glasselement NVARCHAR(100),
 name_glasselement NVARCHAR(100)
);

insert into @TempTable
select distinct
	g.idgood,
	g.name,
	g.marking,
	ge.idglasselement,
	ge.marking,
	ge.name
from good g
right join glasselement ge
--on g.marking = ge.marking 
on g.name = ge.name 
where g.name is null
--where ge.marking like '%���������%'
--and g.idgoodgroup = 733


--and ge.typ = 0   -- ������
--and ge.typ = 1   -- �����
--and ge.typ = 2   -- �������
--and ge.typ = 3   -- ������
--and ge.typ = 4   -- �����

and ge.typ = {0}

select marking_glasselement, name_glasselement, id_glasselement from @TempTable