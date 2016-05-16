ALTER table Pokemon(
	PokemonID int Identity(1,1) not null primary key,
	Nombre varchar(20) not null,
	Peso int not null,
	Altura float not null,
	Generacion int not null,
	TipoID int not null,
	TipoID2 int,
	HabilidadID int
)

ALTER table Stat(
	StatID int Identity(1,1) not null  PRIMARY KEY,
	PokemonID int not null,
	HP int,
	Attack int,
	Defense int,
	Speed int,
	SplAttack int,
	SplDefense int
)

ALTER table Juegos(
	JuegoID int  PRIMARY KEY,
	Nombre varchar(100),
	Año datetime,
	Generacion varchar(10),
	Region varchar(25)
)

ALTER table Tipo(
	TipoID int identity(1,1)  PRIMARY KEY, 
	Nombre varchar(25),
	Generacion varchar(10)
)

ALTER table Moves(
	MoveID int identity(1,1)  PRIMARY KEY,
	TipoID int,
	Nombre varchar(25),
	Accuracy int,
	Power int,
	PowerPoints int,
	Generacion int
)

ALTER table JuegosRelacion(
	JuegoRelID  int PRIMARY KEY,
	PokemonID int,
	JuegoID int
)

ALTER table TipoRelacion(
	TipoID int  PRIMARY KEY,
	Ventaja varchar(25),
	DetailVentaja varchar(max),
	Debilidad varchar(25),
	DetailDebilidad varchar(max)
)

ALTER table Evolucion(
	EvolucionID int identity(1,1)  PRIMARY KEY,
	PokemonID int not null,
	AntID int,
	SigId int,
	status varchar(max),
	descripcion varchar(max)
)

ALTER table Habilidad(
	HabilidadID int Identity(1,1)  PRIMARY KEY,
	Name varchar(15),
	Descripcion varchar(200)
)

ALTER table MovesRelacion(
	MovRelID int PRIMARY KEY ,
	PokemonID int, 
	MoveID int
)
ALTER table Usuario
(
	UserId int  PRIMARY KEY,
	Nombre varchar(100) ,
	Apellido varchar(100),
	email varchar(100),
	DoB datetime,
	Username varchar(100),
	Password varchar(25),
	Privileges varchar(20)
)
CREATE table LogData
(
	id int  PRIMARY KEY,
	Tnombre varchar(100),
	tipo  varchar(50),
	fecha datetime,
	exec_time int null,
	UserId  int null 

)
ALTER TABLE LogData ALTER 
