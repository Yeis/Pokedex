create database Pokedex;

create table Pokemon(
	PokemonID int primary key Auto_increment not null,
	Nombre varchar(20) not null,
	Peso int not null,
	Altura float not null,
	Generacion int not null,
	TipoID int not null,
	TipoID2 int,
	HabilidadID int
);

create table Stat(
	StatID int primary key Auto_increment not null,
	PokemonID int not null,
	HP int,
	Attack int,
	Defense int,
	Speed int,
	SplAttack int,
	SplDefense int
);

create table Juegos(
	JuegoID int  primary key Auto_increment not null,
	Nombre varchar(100),
	Año datetime,
	Generacion varchar(10),
	Region varchar(25)
);

create table Tipo(
	TipoID int primary key Auto_increment,
	Nombre varchar(25)

);

create table Moves(
	MoveID int primary key Auto_increment,
	TipoID int,
	Nombre varchar(25),
	Accuracy int,
	Power int,
	PowerPoints int,
	Generacion int
);

create table JuegosRelacion(
	PokemonID int,
	JuegoID int
);

create table TipoRelacion(
	TipoID int,
	Ventaja varchar(25),
	DetailVentaja varchar(1000),
	Debilidad varchar(25),
	DetailDebilidad varchar(1000)
);

create table Evolucion(
	EvolucionID int primary key Auto_increment,
	PokemonID int not null,
	AntID int,
	SigId int,
	statu varchar(1000),
	descripcion varchar(1000)
);

create table Habilidad(
	HabilidadID int primary key Auto_increment,
	Name varchar(15),
	Descripcion varchar(200)
);

create table MovesRelacion(
	PokemonID int, 
	MoveID int
);

create table Usuario(
	UserID int primary key Auto_increment,
	FirstName varchar(50),
	LastName varchar(50),
	DOB Datetime,
	Username varchar(20) ,
	Password varchar(30) ,
	Email varchar(50),
	Admin int
);