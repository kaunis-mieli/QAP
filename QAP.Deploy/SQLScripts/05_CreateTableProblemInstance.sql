USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--ProblemInstance table creation
		PRINT 'ProblemInstance'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'ProblemInstance' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [dbo].[ProblemInstance] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Size]			INT				NOT NULL,
				[MatrixA]		VARBINARY(MAX)	NOT NULL,
				[MatrixB]		VARBINARY(MAX)	NOT NULl,
				[Hash]			BINARY(32)		NOT NULL,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT			NULL,
				[Description]	NTEXT			NULL,
				[InitialBestKnownCost] BIGINT	NULL,
				[UserId]		INT				NULL,
				[Timestamp]		DATETIME		NOT NULL DEFAULT GETDATE(),
				CONSTRAINT [PK_ProblemInstanceId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_ProblemInstanceHash] UNIQUE ([Hash]),
				CONSTRAINT [UQ_ProblemInstanceAlias] UNIQUE ([Alias]),
				CONSTRAINT [FK_ProblemInstance_User] FOREIGN KEY ([UserId])
					REFERENCES [auth].[User] ([Id])
			);
			
			PRINT '	Table "ProblemInstance" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "ProblemInstance" already exists'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

