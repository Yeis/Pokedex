USE `pokedex`;
DROP procedure IF EXISTS `CreateAbility`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateAbility`(
	IN Name varchar(50),
    IN Description varchar(100)
)
BEGIN
	insert into Habilidad(Name, Descripcion)values(Name, Description);
END$$

DELIMITER ;

USE `pokedex`;
DROP procedure IF EXISTS `CreateEvolution`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateEvolution` (
	IN PokeID int,
    IN SigID int,
    IN AntID int,
	IN status varchar(299),
    IN Descripcion varchar(300)
)
BEGIN
Insert into Evolucion(
	PokeID,
	AntID,
	SigId,
	status,
	descripcion)
values(
	PokeID,
	AntID,
	SigID,
	status,
	Descripcion);
END$$

DELIMITER ;



USE `pokedex`;
DROP procedure IF EXISTS `CreateGame`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateGame` (
	IN Name varchar(100),
    IN Year datetime,
    IN Generation int,
    IN Region int
)
BEGIN
Insert into Juegos(
	Nombre, 
	Año, 
	Generacion, 
	Region) 
values (
	Name,
	Year,
	Generation, 
	Region);
END$$

DELIMITER ;

USE `pokedex`;
DROP procedure IF EXISTS `CreateGameRelation`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateGameRelation`(
	IN PokeID int,
    IN GameID int
)
BEGIN
	insert into JuegosRelacion(PokemonID, JuegoID)values(PokeID, GameID);
END$$

DELIMITER ;


USE `pokedex`;
DROP procedure IF EXISTS `CreateMove`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateMove` (
	IN Type int,
	IN Name varchar(25),
    IN Accuracy int,
    IN Power int,
    IN PowerPoints int,
    IN Generation int
)
BEGIN
	insert into Moves(
		TpMovID,
		Nombre,
		Accuracy,
		Power, 
		PowerPoints, 
		Generacion)
	values(
		Type,
		Name,
		Accuracy,
		Power, 
		PowerPoints,
		Generation);
END$$

DELIMITER ;



USE `pokedex`;
DROP procedure IF EXISTS `CreateMoveRelation`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateMoveRelation` (
	IN PokeID int,
    IN MoveID int
)
BEGIN
	insert into MovesRelacion(
		PokeID,
        MvID
    )
    values (
		PokeID,
        MoveID
    );
END$$

DELIMITER ;




USE `pokedex`;
DROP procedure IF EXISTS `CreatePokemon`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreatePokemon`(
	IN Nombre varchar(20),
	IN Peso int ,
	IN Altura float ,
	IN Generacion int,
	IN TipoID int ,
	IN TipoID2 int,
	IN HabilidadID int,
	IN HP int,
	IN Attack int,
	IN Defense int,
	IN Speed int,
	IN SplAttack int,
	IN SplDefense int
)
BEGIN
insert into Pokemon(
	Nombre, 
	Peso, 
	Altura, 
	Generacion, 
	TpID, 
	TpID2, 
	HabID) 
values
	(Nombre,
	Peso,
	Altura,
	Generacion,
	TipoID,
	TipoID2,
	HabilidadID
);
insert into Stat(
	PokeID,
	HP,
	Attack,
	Defense,
	Speed,
	SplAttack,
	SplDefense)
values(
	LAST_INSERT_ID(),
	HP,
	Attack,
	Defense,
	Speed,
	SplAttack,
	SplDefense
);

END$$

DELIMITER ;



USE `pokedex`;
DROP procedure IF EXISTS `CreateType`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateType` (
	IN Name varchar(25)
)
BEGIN
	insert into Tipo (Nombre) values (Name);
END$$

DELIMITER ;




USE `pokedex`;
DROP procedure IF EXISTS `CreateTypeRelation`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateTypeRelation` (
	ID int,
	Ventaja varchar(25),
	DetailVentaja varchar(200),
	Debilidad varchar(25),
	DetailDebilidad varchar(200)
)
BEGIN
insert into TipoRelacion (
	TpRelID, 
	Ventaja, 
	DetailVentaja, 
	Debilidad, 
	DetailDebilidad
) 
values (
	ID,
	Ventaja, 
	DetailVentaja, 
	Debilidad, 
	DetailDebilidad
);
END$$

DELIMITER ;


USE `pokedex`;
DROP procedure IF EXISTS `CreateUser`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `CreateUser`(
	IN FirstName varchar(50),
	IN LastName varchar(50),
	IN DOB Datetime,
	IN Username varchar(20),
	IN Password varchar(30),
	IN Email varchar(50)
)
BEGIN
insert into Usuario(
	FirstName,
    LastName,
    DOB,
    Username,
    Password,
    Email,
    Admin
)
values(
	FirstName,
	LastName,
	DOB,
	Username,
	Password,
	Email,
	0);
END$$

DELIMITER ;

USE `pokedex`;
DROP procedure IF EXISTS `GetMoveRelation`;

DELIMITER $$

USE `pokedex`$$
CREATE PROCEDURE `GetMoveRelation`(
	IN PokeID int
)
BEGIN
	select * from Moves m
	inner join MovesRelacion mvrel on MoveID = MvId
	where mvrel.PokeID = @PokeID
END$$

DELIMITER $$

USE `pokedex`$$
CREATE PROCEDURE `GetMoveRelation`(
	IN PokeID int
)
BEGIN
	select * from Moves m
	inner join MovesRelacion mvrel on MoveID = MvId
	where mvrel.PokeID = PokeID;
END$$

DELIMITER $$

USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonByGame`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonByGame` (
	IN GameID int
)
BEGIN
	select * from Juegos J 
	inner join JuegosRelacion on J.JuegoID = JuegosRelacion.GameID
	inner join Pokemon p on p.PokemonID = JuegosRelacion.PokeID
	where J.JuegoID = GameID;
END$$

DELIMITER ;


USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonById`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonById` (
	IN Id int
)
BEGIN
	Select * from Pokemon p
	where p.PokemonID = Id;
END$$

DELIMITER ;


USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonByName`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonByName` (
	IN Name varchar(50)
)
BEGIN
	Select * from Pokemon p
	where p.Nombre = Name;
END$$

DELIMITER ;



USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonDetail`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonDetail` (
	IN Id int
)
BEGIN
	select * from Pokemon p
	inner join Stat s
	on p.PokemonID = s.PokeID
	where p.PokemonID = Id;
END$$

DELIMITER ;



USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonEvolutions`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonEvolutions` (
	IN PokeID int
)
BEGIN
	select * from Evolucion
	where PokeID = PokeID;
END$$

DELIMITER ;

USE `pokedex`;
DROP procedure IF EXISTS `GetTypeRelations`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetTypeRelations` (
	IN Id int
)
BEGIN
	Select * from Tipo
	inner join TipoRelacion 
    on Id = TipoRelacion.TpRelID;
END$$

DELIMITER ;

USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonByType`;

DELIMITER $$
USE `pokedex` $$
CREATE PROCEDURE `GetPokemonByType` (
	IN TID int
)
BEGIN
	select * from Pokemon p 
	where p.TpID = TID OR P.TpID2 = TID;
END$$


USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonByType`;

DELIMITER $$
USE `pokedex`;
CREATE PROCEDURE `GetPokemonByType` (
	INT TID int
)
BEGIN
	select * from Pokemon p 
	where p.TpID = @TID OR P.TpID2 = @TID;
END$$


