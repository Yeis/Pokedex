USE [Pokedex]
GO
/****** Object:  StoredProcedure [dbo].[get_PokemonID]    Script Date: 5/8/2016 2:49:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[get_PokemonID] @id int , @user int
as

DECLARE @EndTime datetime
DECLARE @StartTime datetime 
SET @StartTime=GETDATE() 

-- Write Your Query
SELECT * FROM Pokemon where @id  = PokemonID



SET @EndTime=GETDATE()

--This will return execution time of your query--
--select * from Pokedex.sys.dm_exec_procedure_stats

INSERT INTO LogData(nombre,tipo,fecha,tiempo,UserId)
VALUES('get_Pokemon','SP',GETDATE(), DATEDIFF(MCS,@StartTime,@EndTime) ,@user )