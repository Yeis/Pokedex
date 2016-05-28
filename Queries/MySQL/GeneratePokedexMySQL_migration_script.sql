-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: Pokedex
-- Source Schemata: Pokedex
-- Created: Mon May 23 18:21:15 2016
-- Workbench Version: 6.3.6
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema Pokedex
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `Pokedex` ;
CREATE SCHEMA IF NOT EXISTS `Pokedex` ;

-- ----------------------------------------------------------------------------
-- Table Pokedex.Pokemon
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Pokemon` (
  `PokemonID` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  `Peso` INT NOT NULL,
  `Altura` DOUBLE NOT NULL,
  `Generacion` INT NOT NULL,
  `TpID` INT NOT NULL,
  `TpID2` INT NULL,
  `HabID` INT NULL,
  `pathImg` VARCHAR(500) NULL,
  PRIMARY KEY (`PokemonID`),
  INDEX `PK_Name` (`Nombre` ASC));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Stat
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Stat` (
  `StatID` INT NOT NULL AUTO_INCREMENT,
  `PokeID` INT NOT NULL,
  `HP` INT NULL,
  `Attack` INT NULL,
  `Defense` INT NULL,
  `Speed` INT NULL,
  `SplAttack` INT NULL,
  `SplDefense` INT NULL,
  PRIMARY KEY (`StatID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Juegos
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Juegos` (
  `JuegoID` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(100) NULL,
  `Año` DATETIME(6) NULL,
  `Generacion` VARCHAR(10) NULL,
  `Region` VARCHAR(25) NULL,
  PRIMARY KEY (`JuegoID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Tipo
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Tipo` (
  `TipoID` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(25) NULL,
  PRIMARY KEY (`TipoID`),
  INDEX `PK_TiypeName` (`Nombre` ASC));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Moves
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Moves` (
  `MoveID` INT NOT NULL AUTO_INCREMENT,
  `TpMovID` INT NULL,
  `Nombre` VARCHAR(25) NULL,
  `Accuracy` INT NULL,
  `Power` INT NULL,
  `PowerPoints` INT NULL,
  `Generacion` INT NULL,
  PRIMARY KEY (`MoveID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.JuegosRelacion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`JuegosRelacion` (
  `JuegoRelID` INT NOT NULL AUTO_INCREMENT,
  `PokeID` INT NULL,
  `GameID` INT NULL,
  PRIMARY KEY (`JuegoRelID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.TipoRelacion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`TipoRelacion` (
  `TpRelID` INT NOT NULL AUTO_INCREMENT,
  `Ventaja` VARCHAR(25) NULL,
  `DetailVentaja` LONGTEXT NULL,
  `Debilidad` VARCHAR(25) NULL,
  `DetailDebilidad` LONGTEXT NULL,
  PRIMARY KEY (`TpRelID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Evolucion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Evolucion` (
  `EvolucionID` INT NOT NULL AUTO_INCREMENT,
  `PokeID` INT NOT NULL,
  `AntID` INT NULL,
  `SigId` INT NULL,
  `status` LONGTEXT NULL,
  `descripcion` LONGTEXT NULL,
  PRIMARY KEY (`EvolucionID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Habilidad
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Habilidad` (
  `HabilidadID` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(15) NULL,
  `Descripcion` VARCHAR(200) NULL,
  PRIMARY KEY (`HabilidadID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.MovesRelacion
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`MovesRelacion` (
  `MovRelID` INT NOT NULL AUTO_INCREMENT,
  `PokeID` INT NULL,
  `MvID` INT NULL,
  PRIMARY KEY (`MovRelID`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.Usuario
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`Usuario` (
  `UserId` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(100) NULL,
  `Apellido` VARCHAR(100) NULL,
  `email` VARCHAR(100) NULL,
  `DoB` DATETIME(6) NULL,
  `Username` VARCHAR(100) NULL,
  `Password` VARCHAR(25) NULL,
  `Admin` INT NULL,
  PRIMARY KEY (`UserId`));

-- ----------------------------------------------------------------------------
-- Table Pokedex.LogData
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `Pokedex`.`LogData` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NULL,
  `tipo` VARCHAR(50) NULL,
  `fecha` DATETIME(6) NULL,
  `exec_time` INT NULL,
  `UserId` INT NULL,
  PRIMARY KEY (`id`));
SET FOREIGN_KEY_CHECKS = 1;
