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
	PokemonID,
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
		TipoID,
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
		PokemonID,
        MoveID
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
	TipoID, 
	TipoID2, 
	HabilidadID) 
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
	PokemonID,
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
	TipoID, 
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

CALL CreateUser('Hernan', 'Medina', '1995-06-05', 'Alexyz656', 'test', 'HASUD@BDIFG.COM');


USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonByGame`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonByGame` (
	IN GameID int
)
BEGIN
	select * from Juegos J 
	inner join JuegosRelacion on J.JuegoID = JuegosRelacion.JuegoID
	inner join Pokemon p on p.PokemonID = JuegosRelacion.PokemonID
	where J.JuegoID = GameID;
END$$

DELIMITER ;


USE `pokedex`;
DROP procedure IF EXISTS `GetPokemonById`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetPokemonById` (
	IN PokeID int
)
BEGIN
	Select * from Pokemon p
	where p.PokemonID = PokeID;
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
	IN PokeID int
)
BEGIN
	select * from Pokemon p
	inner join Stat s
	on p.PokemonID = s.PokemonID
	where p.PokemonID = PokeID;
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
	where PokemonID = PokeID;
END$$

DELIMITER ;

USE `pokedex`;
DROP procedure IF EXISTS `GetTypeRelations`;

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetTypeRelations` (
	IN TypeID int
)
BEGIN
	Select * from Tipo
	inner join TipoRelacion 
    on TypeID = TipoRelacion.TipoID;
END$$

DELIMITER ;


#QUERIES DEL YEIS 




#1
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetSPByHour`(
	IN 	date1 DATETIME,
    IN date2 DATETIME
)
BEGIN
Select * from LogData 
Where LogData.tipo = 'SP' and  DatePart(HOUR,fecha) between date1 and date2;
END$$


 -- 10 SP que no han sido usados 
CREATE PROCEDURE UnusedSP 
AS
SELECT SPECIFIC_NAME as Name 
  FROM Pokedex.information_schema.routines 
 WHERE SPECIFIC_NAME   NOT IN 
 (SELECT DISTINCT nombre FROM LogData WHERE tipo = 'SP')
GO



#9
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `SPInRange`(
	IN 	lowlimit INT,
    IN highlimit INT
)
BEGIN
SELECT nombre , COUNT(nombre) as TimesRunned from LogData 
GROUP BY nombre 
HAVING COUNT(nombre) BETWEEN lowlimit AND highlimit ;
END$$

#10
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `UnusedSP`()
BEGIN
SELECT SPECIFIC_NAME as Name 
  FROM information_schema.ROUTINES
 WHERE SPECIFIC_NAME   NOT IN 
 (SELECT DISTINCT nombre FROM LogData WHERE tipo = 'SP');
END$$



# 11.1
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `SPExecAverage`()
BEGIN
 SELECT nombre , AVG(exec_time) as AVG_ExecTime FROM LogData
 WHERE tipo = 'SP'
 GROUP BY nombre;
END$$

#11.2
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `SPCount`()
BEGIN
 SELECT nombre , COUNT(nombre) as TimesRunned from LogData
  WHERE tipo = 'SP'
 GROUP BY nombre;
END$$




# 12.1
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `ActiveUsers_Week`()
BEGIN
DECLARE currentdate DATETIME;
DECLARE lastweek DATETIME;

SET currentdate = NOW();
SET lastweek =  DATE_ADD(currentdate, INTERVAL -7 DAY);

SELECT * FROM Usuario WHERE UserId IN 
(SELECT DISTINCT UserId FROM LogData WHERE Tipo = 'Login' AND fecha BETWEEN lastweek AND currentdate );
END$$

#12.2
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `ActiveUsers_Month`()
BEGIN
DECLARE currentdate DATETIME ; 
DECLARE lastmonth DATETIME;
SET currentdate = NOW();
SET lastmonth =  DATE_ADD(currentdate, INTERVAL -1 MONTH);

SELECT * FROM Usuario WHERE UserId IN 
(SELECT DISTINCT UserId FROM LogData WHERE Tipo = 'Login' AND fecha BETWEEN lastmonth AND currentdate );
END$$

# 12.3
DELIMITER $$
CREATE PROCEDURE `InactiveUsers_Month`()
BEGIN
DECLARE curdate DATETIME;
DECLARE lastmonth DATETIME;
SET curdate = NOW();
SET lastmonth =  DATE_ADD(curdate, INTERVAL -1 MONTH);

SELECT * FROM Usuario WHERE UserId NOT IN 
(SELECT DISTINCT UserId FROM LogData WHERE Tipo = 'Login' AND fecha BETWEEN lastmonth AND curdate );
END$$

#12.4
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetLoginDays`()
BEGIN 
SELECT DAYNAME(fecha) AS Dia , COUNT(UserId) as Cantidad FROM LogData
 WHERE Tipo = 'Login'
 GROUP BY DAYNAME(fecha);
END$$

#12.5
DELIMITER $$
CREATE PROCEDURE `GetLoginHours`()
BEGIN 
SELECT EXTRACT(HOUR FROM fecha) AS Hora , COUNT(UserId) as Cantidad FROM LogData
 WHERE Tipo = 'Login'
 GROUP BY EXTRACT(HOUR FROM fecha);
END$$

#12.6
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `SPByUser`(
	IN Userid INT
)
BEGIN
SELECT nombre, fecha ,exec_time FROM LogData WHERE tipo = 'SP' AND UserId = Userid;
END$$

#12.7
DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetUserSubtotals`()
BEGIN

SELECT	IFNULL(Username,'Subtotal') as nombre , Admin   , COUNT(Admin) as Cantidad  FROM Usuario
GROUP BY   Admin ,    Username WITH ROLLUP ;  
END$$
#13

DELIMITER $$
USE `pokedex`$$
CREATE PROCEDURE `GetUserContains`(
	IN patron VARCHAR(25)
)
BEGIN
SELECT * FROM Usuario WHERE Username LIKE CONCAT('%',patron,'%');
END$$








#FIN DE QUERIES DEL YEIS 






