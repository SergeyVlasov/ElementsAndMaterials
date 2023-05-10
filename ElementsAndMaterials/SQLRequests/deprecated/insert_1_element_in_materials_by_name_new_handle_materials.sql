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
and ge.name = "{4}"
--where ge.marking like '%раскладка%'
--and g.idgoodgroup = 733

--and ge.typ = 0   -- стекло
--and ge.typ = 1   -- рамка
--and ge.typ = 2   -- шпроссы
--and ge.typ = 3   -- пленки
--and ge.typ = 4   -- ленты

and ge.typ = {0}


declare @id int
EXEC gen_id_ex 'gen_good', 1, @id out
select @id

update @TempTable
set marking_glasselement = '{2}' + marking_glasselement + '{4}'

update @TempTable
set name_glasselement = name_glasselement + ' {5}'

insert into [dbo].[good] ( [idgood], [idgoodgroup], [name], [marking])
select @id, {1}, name_glasselement, marking_glasselement from @TempTable tt
where tt.id_glasselement = {3}

-- select сделать 