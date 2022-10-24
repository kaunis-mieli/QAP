USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--Problem table creation
		PRINT 'Problem'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'Problem' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [dbo].[Problem] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Size]			INT				NOT NULL,
				[MatrixA]		VARBINARY(MAX)	NOT NULL,
				[MatrixB]		VARBINARY(MAX)	NOT NULl,
				[Hash]			BINARY(32)		NOT NULL,
				[CreatedAt]		DATETIME		NOT NULL DEFAULT GETDATE(),
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT			NULL,
				[Description]	NTEXT			NULL,
				[InitialBestKnownCost] BIGINT	NULL,
				[AllTimeBestKnownCost] BIGINT	NULL,
				CONSTRAINT [PK_ProblemId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_ProblemHash] UNIQUE ([Hash]),
				CONSTRAINT [UQ_ProblemAlias] UNIQUE ([Alias])
			);
			
			PRINT '	Table "Problem" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "Problem" already exists'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

