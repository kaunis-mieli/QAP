USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--Solution table creation
		PRINT 'Solution'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'Solution' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [dbo].[Solution] (
				[Id]			BIGINT			NOT NULL	IDENTITY,
				[Cost]			BIGINT			NOT NULL,
				[Permutation]	VARBINARY(MAX)		NULL,
				[ProblemId]		INT				NOT NULL,
				[CreatedAt]		DATETIME		NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_SolutionId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_Solution_Problem] FOREIGN KEY ([ProblemId])
					REFERENCES [dbo].[Problem] ([Id])
					ON DELETE CASCADE
					ON UPDATE CASCADE
			);
			
			PRINT '	Table "Solution" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "Solution" already exists'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

