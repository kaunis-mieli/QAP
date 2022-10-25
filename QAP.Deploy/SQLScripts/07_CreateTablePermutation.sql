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
				[SessionAlgorithmVariationId] INT	NOT NULL,
				[Iteration]			INT				NOT NULL,
				[Trial]				TINYINT			NOT NULL,
				[CreatedAt]			DATETIME		NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_PermutationId]		PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_Permutation_SessionAlgorithmVariation] FOREIGN KEY ([SessionAlgorithmVariationId])
					REFERENCES [dbo].[SessionAlgorithmVariation] ([Id])
			);
			
			PRINT '	Table "Permutation" has been created'


			--Alter table
			ALTER TABLE [dbo].[SessionAlgorithmVariation]
				ADD PermutationId BIGINT NULL,
				CONSTRAINT [FK_SessionAlgorithmVariation_Permutation] FOREIGN KEY ([PermutationId])
					REFERENCES [dbo].[Permutation] ([Id]);

			--Alter table
			ALTER TABLE [dbo].[ProblemInstance]
				ADD PermutationId BIGINT NULL,
				CONSTRAINT [FK_ProblemInstance_Permutation] FOREIGN KEY ([PermutationId])
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

