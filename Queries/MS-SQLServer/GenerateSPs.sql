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

