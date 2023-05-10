
--select distinct
	--ge.idglasselement as id_glasselement,
	--ge.marking as marking_glasselement,
	--ge.name as name_glasselement
--from good g
--right join glasselement ge
--on g.name = ge.name + ' закалка'
--or g.name = ge.name + ' шлифовка'
--or g.name = ge.name + ' полировка'
--where g.name is null
--and ge.typ = 0   -- стекло
--and ge.typ = 1   -- рамка
--and ge.typ = 2   -- шпроссы
--and ge.typ = 3   -- пленки
--and ge.typ = 4   -- ленты
--and ge.typ = {0}
--and ge.name = '{1}'

--DECLARE @NameMaterial VARCHAR(99)
--SET @NameMaterial='{1}'

DECLARE @GETYPE int;
SET @GETYPE = {0};

DECLARE @TempTable_zakalka TABLE
(
 id_good INT,
 name_good NVARCHAR(100),
 marking_good NVARCHAR(100)
);

DECLARE @TempTable_polirovka TABLE
(
 id_good INT,
 name_good NVARCHAR(100),
 marking_good NVARCHAR(100)
);

DECLARE @TempTable_shlifovka TABLE
(
 id_good INT,
 name_good NVARCHAR(100),
 marking_good NVARCHAR(100)
);

insert into @TempTable_zakalka
select distinct
	ge.idglasselement as id_glasselement,
	ge.marking as marking_glasselement,
	ge.name as name_glasselement
	--g.name
from good g
right join glasselement ge
on g.name = ge.name + ' закалка'
--or g.name = ge.name + ' шлифовка'
--or g.name = ge.name + ' полировка'
where g.name is null
and ge.typ = @GETYPE
--and ge.name = 'Стекло 4 мм M1'


insert into @TempTable_polirovka
select distinct
	ge.idglasselement as id_glasselement,
	ge.marking as marking_glasselement,
	ge.name as name_glasselement
	--g.name
from good g
right join glasselement ge
--on g.name = ge.name + ' закалка'
--on g.name = ge.name + ' шлифовка'
on g.name = ge.name + ' полировка'
where g.name is null
and ge.typ = @GETYPE
--and ge.name = 'Стекло 4 мм M1'


insert into @TempTable_shlifovka
select distinct
	ge.idglasselement as id_glasselement,
	ge.marking as marking_glasselement,
	ge.name as name_glasselement
	--g.name
from good g
right join glasselement ge
--on g.name = ge.name + ' закалка'
on g.name = ge.name + ' шлифовка'
--or g.name = ge.name + ' полировка'
where g.name is null
and ge.typ = @GETYPE
--and ge.name = 'Стекло 4 мм M1'


SELECT *
  FROM (select * from @TempTable_zakalka
		union
		select * from @TempTable_shlifovka
		union 
		select * from @TempTable_polirovka
       ) AS U
where U.marking_good = '{1}'

