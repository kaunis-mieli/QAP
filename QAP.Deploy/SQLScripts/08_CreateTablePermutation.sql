USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--Permutation table creation
		PRINT 'Permutation'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'Permutation' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [dbo].[Permutation] (
				[Id]				BIGINT			NOT NULL	IDENTITY,
				[Cost]				BIGINT			NOT NULL,
				[Value]				VARBINARY(MAX)	NOT NULL,
				[SessionAlgorithmVersionId] INT	NOT NULL,
				[Iteration]			INT				NOT NULL,
				[Member]			INT					NULL,
				[Timestamp]			DATETIME		NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_PermutationId]		PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_Permutation_SessionAlgorithmVersion] FOREIGN KEY ([SessionAlgorithmVersionId])
					REFERENCES [dbo].[SessionAlgorithmVersion] ([Id])
			);
			
			PRINT '	Table "Permutation" has been created'

			--Alter table. Best permutation in SessionAlgorithm scope.
			ALTER TABLE [dbo].[SessionAlgorithmVersion]
				ADD PermutationId BIGINT NULL,
				CONSTRAINT [FK_SessionAlgorithmVersion_Permutation] FOREIGN KEY ([PermutationId])
					REFERENCES [dbo].[Permutation] ([Id]);

			--Alter table. Best permutation in whole problem scope.
			ALTER TABLE [dbo].[Problem]
				ADD PermutationId BIGINT NULL,
				CONSTRAINT [FK_Problem_Permutation] FOREIGN KEY ([PermutationId])
					REFERENCES [dbo].[Permutation] ([Id]);
		END
		ELSE
		BEGIN
			PRINT '	Table "Permutation" already exists'
		END
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

