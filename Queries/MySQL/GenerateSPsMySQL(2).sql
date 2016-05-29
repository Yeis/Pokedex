-- SP (2)

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ConexionesActivas`()
BEGIN
SELECT DB, USER, HOST, STATE FROM information_schema.PROCESSLIST;
END

-- SP (3)
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_Lista_Tablas`()
BEGIN

SELECT TABLE_NAME, TABLE_ROWS AS 'Numero de Registros'
FROM `information_schema`.`tables` 
WHERE `table_schema` = 'pokedex'
ORDER BY TABLE_ROWS DESC;
END

-- SP (4)
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ListaColumnas`(Tabla nvarchar(50))
BEGIN
SELECT TABLE_NAME, COLUMN_NAME
  FROM INFORMATION_SCHEMA.COLUMNS
  WHERE table_name = Tabla
  AND table_schema = 'pokedex';
END

-- SP (5)
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ListaIndices`()
BEGIN
SELECT DATABASE() AS Database_Name,
    s.INDEX_SCHEMA,
    t.TABLE_NAME,
    s.INDEX_NAME,
    s.INDEX_TYPE
FROM INFORMATION_SCHEMA.STATISTICS s
JOIN  INFORMATION_SCHEMA.TABLE_CONSTRAINTS t ON t.TABLE_SCHEMA=s.TABLE_SCHEMA AND t.TABLE_NAME=s.TABLE_NAME
WHERE  s.TABLE_SCHEMA = DATABASE()
ORDER BY t.TABLE_NAME, s.INDEX_TYPE;
END

-- SP (6)
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ListaViews`()
BEGIN
SHOW FULL TABLES IN pokedex WHERE TABLE_TYPE LIKE 'VIEW';
END

-- SP (7)
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_InfoSP`()
BEGIN
SELECT nombre, COUNT(nombre) AS TimesRunned, s.created
FROM LogData l
JOIN mysql.proc s on l.nombre = s.name
ORDER BY COUNT(nombre) ASC;
END

-- SP (8) 
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_InfoSP`()
BEGIN
SELECT nombre, COUNT(nombre) AS TimesRunned, s.created
FROM LogData l
JOIN mysql.proc s on l.nombre = s.name
ORDER BY COUNT(nombre) ASC;
END

-- SP (10)

CREATE DEFINER=`root`@`localhost` PROCEDURE `UnusedSP`()
BEGIN
SELECT nombre, COUNT(nombre) AS TimesRunned
FROM LogData
WHERE COUNT(Nombre) = 0
GROUP BY nombre;
END
