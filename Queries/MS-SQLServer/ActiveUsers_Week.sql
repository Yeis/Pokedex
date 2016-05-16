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


-- CONOCER LOS DIAS EN LOS QUE MAS ACCEDEN A LA APLICACION 
CREATE PROCEDURE GetLoginDays
AS

SELECT DATENAME(DW,fecha) AS Dia , COUNT(UserId) as Cantidad FROM LogData WHERE Tipo = 'Login'
GROUP BY DATENAME(DW,fecha)
GO 


CREATE PROCEDURE GetLoginHours
AS
SELECT DATENAME(HOUR,fecha) AS Hora , COUNT(UserId) FROM LogData WHERE Tipo = 'Login'
GROUP BY DATENAME(HOUR,fecha)
GO

CREATE PROCEDURE GetUserContains @patron varchar(25)
AS

SELECT * FROM Usuario WHERE Username LIKE '%'+@patron+'%'

GO

CREATE PROCEDURE SPByUser @Userid int
AS
SELECT  nombre , fecha ,exec_time FROM LogData WHERE tipo = 'SP' AND UserId = @Userid
GO

--NOT TESTED
CREATE PROCEDURE SPInRange @lowlimit int , @highlimit int 
AS
SELECT nombre , COUNT(nombre) as TimesRunned from LogData 
GROUP BY nombre 
HAVING COUNT(nombre) BETWEEN @lowlimit AND @highlimit

 GO

 CREATE PROCEDURE SPCount 
 AS
 SELECT nombre , COUNT(nombre) as TimesRunned from LogData
 GROUP BY nombre
 GO


 CREATE PROCEDURE SPExecAverage
 AS

 SELECT nombre , AVG(exec_time) FROM LogData
 GROUP BY nombre
GO
EXEC ActiveUsers_Week

EXEC ActiveUsers_Month

EXEC InactiveUsers_Month

EXEC GetLoginDays

EXEC GetLoginHours

EXEC GetUserContains 'e'

EXEC SPByUser 2

EXEC SPInRange 1,3

print DATENAME(DW,GETDATE())