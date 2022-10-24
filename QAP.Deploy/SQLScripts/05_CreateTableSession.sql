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
			CREATE TABLE [dbo].[Session] (
				[Id]			INT		NOT NULL	IDENTITY,
				[ProblemId]		INT		NOT NULL,
				[CreatedAt]		DATETIME NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_SessionId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_Session_Problem] FOREIGN KEY ([ProblemId])
					REFERENCES [dbo].[Problem] ([Id])
					ON DELETE CASCADE
					ON UPDATE CASCADE
			);
			
			PRINT '	Table "Session" has been created'
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

