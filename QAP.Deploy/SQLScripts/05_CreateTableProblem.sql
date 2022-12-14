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
				[Hash]			BINARY(20)		NOT NULL,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT			NULL,
				[Description]	NTEXT			NULL,
				[InitialBestKnownCost] BIGINT	NULL,
				[UserId]		INT				NULL,
				[Timestamp]		DATETIME		NOT NULL DEFAULT GETDATE(),
				CONSTRAINT [PK_ProblemId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_ProblemHash] UNIQUE ([Hash]),
				CONSTRAINT [UQ_ProblemAlias] UNIQUE ([Alias]),
				CONSTRAINT [FK_Problem_User] FOREIGN KEY ([UserId])
					REFERENCES [auth].[User] ([Id])
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

