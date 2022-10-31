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
			CREATE TABLE [const].[State] (
				[Id]			INT				NOT NULL IDENTITY,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT				NULL,
				[Description]	NTEXT				NULL,
				CONSTRAINT [PK_StateId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_StateAlias] UNIQUE ([Alias])
			);

			PRINT '	Table "State" has been created';

			INSERT INTO [const].[State] ([Alias]) VALUES
				('init'),		--1
				('queued'),		--2
				('running'),	--3
				('paused'),		--4
				('crashed'),	--5
				('canceled'),	--6
				('finished');	--7		

			PRINT '	Values inserted into "State" table'

			--Create table
			CREATE TABLE [dbo].[Multiverse] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Alias]			VARCHAR(255)		NULL,
				[Title]			NTEXT				NULL,
				[Description]	NTEXT				NULL,
				[UserId]		INT				NOT NULL,
				[Timestamp]		DATETIME		NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_MultiverseId] PRIMARY KEY NONCLUSTERED ([Id]),
				INDEX IX_MultiverseAlias NONCLUSTERED ([Alias]),
				CONSTRAINT [FK_Multiverse_User] FOREIGN KEY ([UserId])
					REFERENCES [auth].[User] ([Id])
			);

			PRINT '	Table "Multiverse" has been created';


			--Create table
			CREATE TABLE [dbo].[Session] (
				[Id]						INT		NOT NULL	IDENTITY,
				[MultiverseId]				INT		NOT NULL,
				[ProblemInstanceId]			INT		NOT NULL,
				CONSTRAINT [PK_SessionId]	PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_Session_Multiverse] FOREIGN KEY ([MultiverseId])
					REFERENCES [dbo].[Multiverse] ([Id]),
				CONSTRAINT [FK_Session_ProblemInstance] FOREIGN KEY ([ProblemInstanceId])
					REFERENCES [dbo].[ProblemInstance] ([Id])
			);
			
			PRINT '	Table "Session" has been created'


			--Create table
			CREATE TABLE [dbo].[SessionAlgorithmVariation] (	-- unique job :)
				[Id]						INT		NOT NULL	IDENTITY,
				[SessionId]					INT		NOT NULL,
				[AlgorithmVariationId]		INT		NOT NULL,
				[StateId]					INT		NOT NULL,
				[ConfigurationId]			INT			NULL,
				[Seed]						BIGINT		NULL
				CONSTRAINT [PK_SessionAlgorithmVariationId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_Session] FOREIGN KEY ([SessionId])
					REFERENCES [dbo].[Session] ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_AlgorithmVariation] FOREIGN KEY ([AlgorithmVariationId])
					REFERENCES [dbo].[AlgorithmVariation] ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_Configuration] FOREIGN KEY ([ConfigurationId])
					REFERENCES [dbo].[Configuration] ([Id]),
				CONSTRAINT [FK_SessionAlgorithmVariation_State]	FOREIGN KEY ([StateId])
					REFERENCES [const].[State] ([Id])
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

