﻿USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION
		IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'const'))
		BEGIN
			EXEC ('CREATE SCHEMA [const] AUTHORIZATION [dbo]')
			COMMIT TRANSACTION;
			PRINT 'Schema "const" has been created'
		END
		ELSE
		BEGIN
			PRINT 'Schema "const" already exists'
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;