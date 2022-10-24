USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--SessionAlgorithm table creation
		PRINT 'SessionAlgorithm'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'SessionAlgorithm' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [dbo].[SessionAlgorithm] (
				[Id]			INT		NOT NULL	IDENTITY,
				[SessionId]		INT		NOT NULL,
				[AlgorithmId]	SMALLINT NOT NULL,
				[Info]			NTEXT		NULL,
				[CreatedAt]		DATETIME NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_SessionAlgorithmId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_SessionAlgorithm_Session] FOREIGN KEY ([SessionId])
					REFERENCES [dbo].[Session] ([Id])
					ON DELETE CASCADE
					ON UPDATE CASCADE,
				CONSTRAINT [FK_SessionAlgorithm_Algorithm] FOREIGN KEY ([AlgorithmId])
					REFERENCES [const].[Algorithm] ([Id])
					ON DELETE CASCADE
					ON UPDATE CASCADE
			);
			
			PRINT '	Table "SessionAlgorithm" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "SessionAlgorithm" already exists'
		END

		COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;

