
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/22/2016 22:00:34
-- Generated from EDMX file: C:\Users\Ruth\Documents\Cetys\SEXTO\BASE DE DATOS\PROYECTO FINAL\PROYECTO\PokedexFinalProject\PokedexFinalProject\PokedexEntitiesSQLServer.edmx
-- --------------------------------------------------
CREATE DATABASE [Pokedex]
SET QUOTED_IDENTIFIER OFF;
GO
USE [Pokedex];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LogData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogData];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Evolucion]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Evolucion];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Habilidad]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Habilidad];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Juegos]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Juegos];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Moves]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Moves];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Pokemon]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Pokemon];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Stat]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Stat];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Tipo]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Tipo];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[Usuario];
GO
IF OBJECT_ID(N'[PokedexModelStoreContainer].[GetAllPokemon]', 'U') IS NOT NULL
    DROP TABLE [PokedexModelStoreContainer].[GetAllPokemon];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LogDatas'
CREATE TABLE [dbo].[LogDatas] (
    [id] int  NOT NULL,
    [nombre] varchar(100)  NULL,
    [tipo] varchar(50)  NULL,
    [fecha] datetime  NULL,
    [exec_time] int  NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Evolucions'
CREATE TABLE [dbo].[Evolucions] (
    [EvolucionID] int IDENTITY(1,1) NOT NULL,
    [PokemonID] int  NOT NULL,
    [AntID] int  NULL,
    [SigId] int  NULL,
    [status] varchar(max)  NULL,
    [descripcion] varchar(max)  NULL
);
GO

-- Creating table 'Habilidads'
CREATE TABLE [dbo].[Habilidads] (
    [HabilidadID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(15)  NULL,
    [Descripcion] varchar(200)  NULL
);
GO

-- Creating table 'Juegos'
CREATE TABLE [dbo].[Juegos] (
    [JuegoID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(100)  NULL,
    [Año] datetime  NULL,
    [Generacion] varchar(10)  NULL,
    [Region] varchar(25)  NULL
);
GO

-- Creating table 'Moves'
CREATE TABLE [dbo].[Moves] (
    [MoveID] int IDENTITY(1,1) NOT NULL,
    [TipoID] int  NULL,
    [Nombre] varchar(25)  NULL,
    [Accuracy] int  NULL,
    [Power] int  NULL,
    [PowerPoints] int  NULL,
    [Generacion] int  NULL
);
GO

-- Creating table 'Pokemons'
CREATE TABLE [dbo].[Pokemons] (
    [PokemonID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(20)  NOT NULL,
    [Peso] int  NOT NULL,
    [Altura] float  NOT NULL,
    [Generacion] int  NOT NULL,
    [TipoID] int  NOT NULL,
    [TipoID2] int  NULL,
    [HabilidadID] int  NULL,
    [pathImg] varchar(500)  NULL
);
GO

-- Creating table 'Stats'
CREATE TABLE [dbo].[Stats] (
    [StatID] int IDENTITY(1,1) NOT NULL,
    [PokemonID] int  NOT NULL,
    [HP] int  NULL,
    [Attack] int  NULL,
    [Defense] int  NULL,
    [Speed] int  NULL,
    [SplAttack] int  NULL,
    [SplDefense] int  NULL
);
GO

-- Creating table 'Tipoes'
CREATE TABLE [dbo].[Tipoes] (
    [TipoID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(25)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [FirstName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [DOB] datetime  NULL,
    [Username] varchar(20)  NOT NULL,
    [Password] varchar(30)  NOT NULL,
    [Email] varchar(50)  NULL,
    [Admin] int  NULL
);
GO

-- Creating table 'GetAllPokemons'
CREATE TABLE [dbo].[GetAllPokemons] (
    [PokemonID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(20)  NOT NULL,
    [Peso] int  NOT NULL,
    [Altura] float  NOT NULL,
    [Generacion] int  NOT NULL,
    [TipoID] int  NOT NULL,
    [TipoID2] int  NULL,
    [HabilidadID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'LogDatas'
ALTER TABLE [dbo].[LogDatas]
ADD CONSTRAINT [PK_LogDatas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [EvolucionID], [PokemonID] in table 'Evolucions'
ALTER TABLE [dbo].[Evolucions]
ADD CONSTRAINT [PK_Evolucions]
    PRIMARY KEY CLUSTERED ([EvolucionID], [PokemonID] ASC);
GO

-- Creating primary key on [HabilidadID] in table 'Habilidads'
ALTER TABLE [dbo].[Habilidads]
ADD CONSTRAINT [PK_Habilidads]
    PRIMARY KEY CLUSTERED ([HabilidadID] ASC);
GO

-- Creating primary key on [JuegoID] in table 'Juegos'
ALTER TABLE [dbo].[Juegos]
ADD CONSTRAINT [PK_Juegos]
    PRIMARY KEY CLUSTERED ([JuegoID] ASC);
GO

-- Creating primary key on [MoveID] in table 'Moves'
ALTER TABLE [dbo].[Moves]
ADD CONSTRAINT [PK_Moves]
    PRIMARY KEY CLUSTERED ([MoveID] ASC);
GO

-- Creating primary key on [PokemonID], [Nombre], [Peso], [Altura], [Generacion], [TipoID] in table 'Pokemons'
ALTER TABLE [dbo].[Pokemons]
ADD CONSTRAINT [PK_Pokemons]
    PRIMARY KEY CLUSTERED ([PokemonID], [Nombre], [Peso], [Altura], [Generacion], [TipoID] ASC);
GO

-- Creating primary key on [StatID], [PokemonID] in table 'Stats'
ALTER TABLE [dbo].[Stats]
ADD CONSTRAINT [PK_Stats]
    PRIMARY KEY CLUSTERED ([StatID], [PokemonID] ASC);
GO

-- Creating primary key on [TipoID] in table 'Tipoes'
ALTER TABLE [dbo].[Tipoes]
ADD CONSTRAINT [PK_Tipoes]
    PRIMARY KEY CLUSTERED ([TipoID] ASC);
GO

-- Creating primary key on [UserID], [Username], [Password] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([UserID], [Username], [Password] ASC);
GO

-- Creating primary key on [PokemonID], [Nombre], [Peso], [Altura], [Generacion], [TipoID] in table 'GetAllPokemons'
ALTER TABLE [dbo].[GetAllPokemons]
ADD CONSTRAINT [PK_GetAllPokemons]
    PRIMARY KEY CLUSTERED ([PokemonID], [Nombre], [Peso], [Altura], [Generacion], [TipoID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------