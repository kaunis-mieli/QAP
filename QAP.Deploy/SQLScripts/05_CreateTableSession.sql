USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--Session table creation
		PRINT 'Session'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'Session' AND xtype='U')
		BEGIN

			--Create table
			CREATE TABLE [dbo].[Multiverse] (
				[Id]			INT		NOT NULL	IDENTITY,
				[Alias]			VARCHAR		NULL,
				[Title]			NTEXT		NULL,
				[Description]	NTEXT		NULL,
				[CreatedAt]		DATETIME NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_MultiverseId] PRIMARY KEY NONCLUSTERED ([Id]),
				INDEX IX_MultiverseAlias NONCLUSTERED ([Alias])
			);

			PRINT '	Table "Multiverse" has been created'


			--Create table
			CREATE TABLE [dbo].[Session] (
				[Id]			INT		NOT NULL	IDENTITY,
				[MultiverseId]	INT		NOT NULL,
				[ProblemInstanceId]		INT		NOT NULL,
				CONSTRAINT [PK_SessionId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_Session_Multiverse] FOREIGN KEY ([MultiverseId])
					REFERENCES [dbo].[Multiverse] ([Id]),
				CONSTRAINT [FK_Session_ProblemInstance] FOREIGN KEY ([ProblemInstanceId])
					REFERENCES [dbo].[ProblemInstance] ([Id])
			);
			
			PRINT '	Table "Session" has been created'


			--Create table
			CREATE TABLE [dbo].[SessionAlgorithmVariation] (
				[Id]						INT		NOT NULL	IDENTITY,
				[SessionId]					INT		NOT NULL,
				[AlgorithmVariationId]		INT		NOT NULL,
				[ConfigurationId]			INT			NULL,
				CONSTRAINT [PK_SessionAlgorithmVariationId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_Session] FOREIGN KEY ([SessionId])
					REFERENCES [dbo].[Session] ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_AlgorithmVariation] FOREIGN KEY ([AlgorithmVariationId])
					REFERENCES [dbo].[AlgorithmVariation] ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_Configuration] FOREIGN KEY ([ConfigurationId])
					REFERENCES [dbo].[Configuration] ([Id]),
				
			);
			
			PRINT '	Table "SessionAlgorithmVariation" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "Session" already exists'
		END

		COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

