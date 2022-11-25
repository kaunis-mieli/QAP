USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--Algorithm table creation
		PRINT 'Algorithm'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'Algorithm' AND xtype='U')
		BEGIN

			--Create table Algorithm
			CREATE TABLE [const].[Algorithm] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT				NULL,
				[Description]	NTEXT				NULL,
				CONSTRAINT [PK_AlgorithmId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_AlgorithmAlias] UNIQUE ([Alias])
			);
			
			PRINT '	Table "Algorithm" has been created'

			INSERT INTO [const].[Algorithm] ([Alias], [Title], [Description]) VALUES
			('ClassicLocalSearchAlgorithm', 'Classical Local Search Algorithm', 'Classical Local Search Algorithm'),
			('GeneticAlgorithm', 'Genetic Algorithm', 'Genetic Algorithm is based on Darwinism evolutionary.');

			PRINT '	Algorithm values inserted'


			--Create table AlgorithmVersion
			CREATE TABLE [dbo].[AlgorithmVersion] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Version]		INT				NOT NULL,
				[AlgorithmId]	INT				NOT NULL,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT				NULL,
				[Description]	NTEXT				NULL,
				[DefaultConfiguration]	NTEXT		NULL,
				[UserId]		INT					NULL,
				CONSTRAINT [PK_AlgorithmVersionId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_AlgorithmVersionAlgorithmIdVersionAlias] UNIQUE ([AlgorithmId], [Version], [Alias]),
				CONSTRAINT [FK_AlgorithmVersion_Algorithm] FOREIGN KEY ([AlgorithmId])
					REFERENCES [const].[Algorithm] ([Id]),
				CONSTRAINT [FK_AlgorithmVersion_User] FOREIGN KEY ([UserId])
					REFERENCES [auth].[User] ([Id])
			);
			
			PRINT '	Table "AlgorithmVersion" has been created'

			INSERT INTO [dbo].[AlgorithmVersion] ([Version], [AlgorithmId], [Alias], [Title]) VALUES
			(1, 1, 'v0.0.1', 'Classical Local Search v0.0.1'),
			(1, 2, 'v0.0.1', 'Genetic Algorithm v0.0.1');

			PRINT '	AlgorithmVersion values inserted'
		END
		ELSE
		BEGIN
			PRINT '	Table "Algorithm" already exists'
		END

		COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

