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
 SELECT top 1 * FROM
    (SELECT OBJECT_NAME(s2.objectid) AS ProcName,
        MAX(execution_count) AS execution_count,s2.objectid,
        MAX(last_execution_time) AS last_execution_time
FROM sys.dm_exec_query_stats AS s1
CROSS APPLY sys.dm_exec_sql_text(sql_handle) AS s2
GROUP BY OBJECT_NAME(s2.objectid),s2.objectid) x
WHERE OBJECTPROPERTYEX(x.objectid,'IsProcedure') = 1
AND EXISTS (SELECT 1 FROM sys.procedures s
            WHERE s.is_ms_shipped = 0
            AND s.name = x.ProcName )
ORDER BY execution_count DESC

SELECT TOP 1* FROM(SELECT OBJECT_NAME(s2.objectid) AS ProcName,
        MAX(execution_count) AS execution_count,s2.objectid,
        MAX(last_execution_time) AS last_execution_time
FROM sys.dm_exec_query_stats AS s1
CROSS APPLY sys.dm_exec_sql_text(sql_handle) AS s2
GROUP BY OBJECT_NAME(s2.objectid),s2.objectid) x
WHERE OBJECTPROPERTYEX(x.objectid,'IsProcedure') = 1
AND EXISTS (SELECT 1 FROM sys.procedures s
            WHERE s.is_ms_shipped = 0
            AND s.name = x.ProcName )
          
ORDER BY execution_count DESC 
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

-- SP (10)
CREATE PROCEDURE SP_NoEjecutados
AS
SELECT DB_NAME() AS Database_Name, sc.name AS Schema_Name, p.name AS SP_Name
FROM sys.procedures AS p
INNER JOIN sys.schemas AS sc
  ON p.[schema_id] = sc.[schema_id]
LEFT OUTER JOIN sys.dm_exec_procedure_stats AS st
  ON p.[object_id] = st.[object_id]
WHERE st.[object_id] IS NULL
ORDER BY p.name
GO


