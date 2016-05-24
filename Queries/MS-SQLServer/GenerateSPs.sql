USE [Pokedex]
GO

/****** Object:  StoredProcedure [dbo].[CreateAbility]    Script Date: 5/18/2016 1:01:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure CreateAbility
@Name varchar(15),
@Description varchar(20)
as
insert into Habilidad(Name, Descripcion)values(@Name, @Description)
GO



Create procedure CreateEvolution
@PokeID int,
@AntID int,
@SigID int,
@status varchar(max),
@descripcion varchar(max)
AS

Insert into Evolucion(
	PokemonID,
	AntID,
	SigId,
	status,
	descripcion)
values(
	@PokeID,
	@AntID,
	@SigID,
	@status,
	@descripcion)
GO



Create procedure CreateGame
@Name varchar(100),
@Year datetime,
@Generation varchar(10),
@Region varchar(25)
as
Insert into Juegos(
	Nombre, 
	Año, 
	Generacion, 
	Region) 
values (
	@Name,
	@Year,
	@Generation, 
	@Region)
GO



Create Procedure CreateGameRelation
@PokeID int,
@GameID int
as
insert into JuegosRelacion(PokemonID, JuegoID)values(@PokeID, @GameID)
GO


create procedure CreateMove
 @Type int,
 @Name varchar(25),
 @Accuracy int,
 @Power int,
 @PowerPoints int,
 @Generation int
 as
 insert into Moves(
	TipoID,
	Nombre,
	Accuracy,
	Power, 
	PowerPoints, 
	Generacion)
values(
	@Type,
	@Name,
	@Accuracy,
	@Power, 
	@PowerPoints,
	@Generation)
GO


Create Procedure CreateMoveRelation
@PokeID int,
@MoveID int
as
insert into MovesRelacion(
	PokemonID, 
	MoveID)
values(
	@PokeID, 
	@MoveID)
GO



CREATE PROCEDURE CreatePokemon
	@Nombre varchar(20),
	@Peso int ,
	@Altura float ,
	@Generacion int,
	@TipoID int ,
	@TipoID2 int,
	@HabilidadID int,
	@HP int,
	@Attack int,
	@Defense int,
	@Speed int,
	@SplAttack int,
	@SplDefense int
AS
insert into Pokemon(
	Nombre, 
	Peso, 
	Altura, 
	Generacion, 
	TipoID, 
	TipoID2, 
	HabilidadID) 
values
	(@Nombre,
	@Peso,
	@Altura,
	@Generacion,
	@TipoID,
	@TipoID2,
	@HabilidadID)
insert into Stat(
	PokemonID,
	HP,
	Attack,
	Defense,
	Speed,
	SplAttack,
	SplDefense)
values(
	@@IDENTITY,
	@HP,
	@Attack,
	@Defense,
	@Speed,
	@SplAttack,
	@SplDefense
)


GO



Create procedure CreateType
@Name varchar(25)
as 
insert into Tipo (Nombre) values (@Name)
GO



Create procedure CreateTypeRelation
@ID int,
@Ventaja varchar(25),
@DetailVentaja varchar(max),
@Debilidad varchar(25),
@DetailDebilidad varchar(max)
as 
insert into TipoRelacion (
	TipoID, 
	Ventaja, 
	DetailVentaja, 
	Debilidad, 
	DetailDebilidad) 
values (
	@ID,
	@Ventaja, 
	@DetailVentaja, 
	@Debilidad, 
	@DetailDebilidad)


GO



CREATE procedure CreateUser
	@FirstName varchar(50),
	@LastName varchar(50),
	@DOB Datetime,
	@Username varchar(20),
	@Password varchar(30),
	@Email varchar(50)
as 
insert into Usuario values(
	@FirstName,
	@LastName,
	@DOB,
	@Username,
	@Password,
	@Email,
	0)
GO



CREATE Procedure GetPokemonByGame
@GameID int
as
select * from Juegos J 
inner join JuegosRelacion on J.JuegoID = JuegosRelacion.JuegoID
inner join Pokemon p on p.PokemonID = JuegosRelacion.PokemonID
where J.JuegoID = @GameID
GO



Create procedure GetPokemonById
@Id int
as
Select * from Pokemon p
where p.PokemonID = @Id
GO



Create procedure GetPokemonByName
@Name varchar(50)
as
Select * from Pokemon p
where p.Nombre = @Name
GO


CREATE Procedure GetPokemonDetail
@Id int
as
select * from Pokemon p
inner join Stat s
on p.PokemonID = s.PokemonID
where p.PokemonID = @Id
GO



Create Procedure GetPokemonEvolutions
@PokeID int
as
select * from Evolucion
where PokemonID = @PokeID
GO


Create procedure GetTypeRelations
@Id int
as 
Select * from Tipo
inner join TipoRelacion on @Id = TipoRelacion.TipoID
GO

-- STATISTICS 

--1  sp in range by hour 
CREATE Procedure GetSPByHour
@date1 int,
@date2 int
as
Select * from LogData 
Where LogData.tipo = 'SP' and  DatePart(HOUR,fecha) between @date1 and @date2
GO
-- SP (2)

CREATE PROCEDURE SP_ConexionesActivas
AS
SELECT DB_NAME(dbid) as Database_Name, loginame,hostname,  status, program_name, login_time
FROM sys.sysprocesses
WHERE dbid > 0
AND DB_NAME(dbid) = 'Pokedex'
GO

-- SP (3)

CREATE PROCEDURE SP_Lista_Tablas
AS
SELECT DISTINCT T.name AS Table_Name, P.[ROWS] AS "Numero de registros"
FROM SYS.tables T 
INNER JOIN Sys.partitions P ON T.object_id = p.object_id
ORDER BY [Numero de registros]DESC
GO

-- SP (4)

 CREATE PROCEDURE SP_ListaColumnas @Tabla nvarchar(50)
 AS
 SELECT TABLE_NAME, COLUMN_NAME
 FROM Pokedex.INFORMATION_SCHEMA.COLUMNS
 WHERE TABLE_NAME = @Tabla
 GO
 -- SP (5)
 
 CREATE PROCEDURE SP_ListaIndices
 AS
 SELECT DB_NAME() AS Database_Name,
 sc.name AS Schema_Name,
 obj.name AS Table_Name,
 ind.name AS Index_Name,
 ind.type_desc AS Index_Type
 FROM sys.indexes ind
 INNER JOIN sys.objects obj ON ind.object_id = obj.object_id
 INNER JOIN sys.schemas sc ON obj.schema_id = sc.schema_id
 WHERE ind.name IS NOT NULL
 AND obj.type = 'U'
 ORDER BY obj.name, ind.type
 GO
 
 --SP (6)
 CREATE PROCEDURE SP_ListaViews
 AS
 SELECT name AS View_Name, create_date
 FROM sys.views
 GO



 --SP (7)

CREATE PROCEDURE SP_InfoSp
AS
SELECT  nombre , count(nombre) FROM LogData
WHERE tipo = 'SP'
GROUP BY nombre
ORDER BY count(nombre) DESC

GO
 
--SP (8)
CREATE PROCEDURE SP_Lista_Mil_Registros
AS
SELECT DISTINCT T.name, P.[ROWS] AS "Numero de registros"
FROM SYS.tables T 
INNER JOIN Sys.partitions P ON T.object_id = p.object_id
WHERE P.[rows] > 1000
ORDER BY [Numero de registros]DESC
GO




--9 lista de sp ejecutados en un rango entre 100 a 250 
CREATE PROCEDURE SPInRange @lowlimit int , @highlimit int 
AS
SELECT nombre , COUNT(nombre) as TimesRunned from LogData 
GROUP BY nombre 
HAVING COUNT(nombre) BETWEEN @lowlimit AND @highlimit

 GO


 -- 10 SP que no han sido usados 
CREATE PROCEDURE UnusedSP 
AS
SELECT SPECIFIC_NAME as Name 
  FROM Pokedex.information_schema.routines 
 WHERE SPECIFIC_NAME   NOT IN 
 (SELECT DISTINCT nombre FROM LogData WHERE tipo = 'SP')
GO


-- 11.1  Promedio 
CREATE PROCEDURE SPExecAverage
 AS

 SELECT nombre , AVG(exec_time) as AVG_ExecTime FROM LogData
 WHERE tipo = 'SP'
 GROUP BY nombre
GO


--11.2  Cantidad de ejecuciones 
 CREATE PROCEDURE SPCount 
 AS
 SELECT nombre , COUNT(nombre) as TimesRunned from LogData
  WHERE tipo = 'SP'
 GROUP BY nombre
 GO


 -- 12.1 Usuarios activos por semana
 CREATE PROCEDURE ActiveUsers_Week 
AS

DECLARE @curdate DATETIME
DECLARE @lastweek DATETIME 
SET @curdate = GETDATE()
SET @lastweek = DATEADD(DAY,-7,@curdate)
PRINT 'SEARCHING BETWEEN ' 
PRINT @curdate
PRINT 'AND'
PRINT @lastweek
SELECT * FROM Usuario WHERE UserId  IN 
(SELECT DISTINCT UserId FROM LogData WHERE Tipo = 'Login' and fecha BETWEEN @lastweek AND @curdate )


GO
 --12.2 Usuarios activos por mes 
 
CREATE PROCEDURE ActiveUsers_Month  
AS

DECLARE @curdate DATETIME
DECLARE @lastmonth DATETIME 
SET @curdate = GETDATE()
SET @lastmonth = DATEADD(MONTH,-1,@curdate)
PRINT 'SEARCHING BETWEEN ' 
PRINT @curdate
PRINT 'AND'
PRINT @lastmonth
SELECT * FROM Usuario WHERE UserId  IN 
(SELECT DISTINCT UserId FROM LogData WHERE Tipo = 'Login' and fecha BETWEEN @lastmonth AND @curdate )


GO
 -- 12.3 Usuarios inactivos en el ultimo mes 
CREATE PROCEDURE InactiveUsers_Month
AS
DECLARE @curdate DATETIME
DECLARE @lastmonth DATETIME 
SET @curdate = GETDATE()
SET @lastmonth = DATEADD(MONTH,-1,@curdate)
PRINT 'SEARCHING BETWEEN ' 
PRINT @curdate
PRINT 'AND'
PRINT @lastmonth
SELECT * FROM Usuario WHERE UserId NOT IN 
(SELECT DISTINCT UserId FROM LogData WHERE Tipo = 'Login' and fecha BETWEEN @lastmonth AND @curdate )
GO
 --12.4 dias en los que mas se acceden la aplicacion
 CREATE PROCEDURE GetLoginDays
AS

SELECT DATENAME(DW,fecha) AS Dia , COUNT(UserId) as Cantidad FROM LogData WHERE Tipo = 'Login'
GROUP BY DATENAME(DW,fecha)
GO 

--12.5 horas en las que mas acceden a la applicacion

CREATE PROCEDURE GetLoginHours
AS
SELECT DATENAME(HOUR,fecha) AS Hora , COUNT(UserId) as Cantidad FROM LogData WHERE Tipo = 'Login'
GROUP BY DATENAME(HOUR,fecha)
GO

--12.6 lista de SP ejecutados por usuario 
CREATE PROCEDURE SPByUser @Userid int
AS
SELECT  nombre , fecha ,exec_time FROM LogData WHERE tipo = 'SP' AND UserId = @Userid
GO


--12.7 lista de usuarios por rol con subtotales 
CREATE PROCEDURE GetUserSubtotals
AS

SELECT	ISNULL(Username,'Subtotal') as nombre , Admin   , COUNT(Admin) as Cantidad  FROM Usuario
GROUP BY   Admin ,    Username WITH ROLLUP   


GO



 -- 13 Busqueda de Usuarios por Contains 
 CREATE PROCEDURE GetUserContains @patron varchar(25)
AS

SELECT * FROM Usuario WHERE Username LIKE '%'+@patron+'%'

GO


--Create Procedure GetSPByHour
--@date1 datetime,
--@date2 datetime
--as
--Select * from LogData 
--Where LogData.tipo = 'SP' and LogData.fecha between @date1 and @date2