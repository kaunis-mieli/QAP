USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--Algorithm table creation
		PRINT 'Algorithm'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'Algorithm' AND xtype='U')
		BEGIN
			
			--Create table
			CREATE TABLE [dbo].[Configuration] (
				[Id]			INT		NOT NULL	IDENTITY,
				[Value]			NTEXT	NOT NULL,
				CONSTRAINT [PK_ConfigurationId] PRIMARY KEY NONCLUSTERED ([Id]),
			);

			PRINT '	Table "Configuration" has been created'


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
			CREATE TABLE [const].[AlgorithmVersion] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Version]		INT				NOT NULL,
				[AlgorithmId]	INT				NOT NULL,
				[Title]			NTEXT				NULL,
				[Description]	NTEXT				NULL,
				CONSTRAINT [PK_AlgorithmVersionId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_AlgorithmVersionAliasAndAlgorithmId] UNIQUE ([Alias], [AlgorithmId]),
				CONSTRAINT [UQ_AlgorithmVersionAlgorithmIdAndVersion] UNIQUE ([AlgorithmId], [Version]),
				CONSTRAINT [FK_AlgorithmVersion_Algorithm] FOREIGN KEY ([AlgorithmId])
					REFERENCES [const].[Algorithm] ([Id])
			);
			
			PRINT '	Table "AlgorithmVersion" has been created'

			INSERT INTO [const].[AlgorithmVersion] ([Alias], [Version], [AlgorithmId], [Title]) VALUES
			('0_1', 1, 1, 'Classical Local Search v0.1'),
			('0_1', 1, 2, 'Genetic Algorithm v0.1');

			PRINT '	AlgorithmVersion values inserted'


			--Create table AlgorithmVariation
			CREATE TABLE [dbo].[AlgorithmVariation] (
				[Id]					INT		NOT NULL	IDENTITY,
				[AlgorithmVersionId]	INT		NOT NULL,
				[ConfigurationId]		INT			NULL,
				[UserId]				INT			NULL,
				CONSTRAINT [PK_AlgorithmVariationId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_AlgorithmVariation_AlgorithmVersion] FOREIGN KEY ([AlgorithmVersionId])
					REFERENCES [const].[AlgorithmVersion] ([Id]),
				CONSTRAINT [FK_AlgorithmVariation_Configuration] FOREIGN KEY ([ConfigurationId])
					REFERENCES [dbo].[Configuration] ([Id]),
				CONSTRAINT [FK_AlgorithmVariation_User] FOREIGN KEY ([UserId])
					REFERENCES [auth].[User] ([Id])
			);

			INSERT INTO [dbo].[AlgorithmVariation] ([AlgorithmVersionId]) VALUES
			(1),
			(2);

			PRINT '	AlgorithmVersion values inserted'
			
			PRINT '	Table "AlgorithmVariation" has been created'
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

