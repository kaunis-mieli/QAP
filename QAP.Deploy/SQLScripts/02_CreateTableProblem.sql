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
				[Id]			INT			NOT NULL	IDENTITY,
				[Size]			SMALLINT		NOT NULL,
				[Type]			VARCHAR(255)	NOT NULL,
				[MatrixA]		VARBINARY(MAX)	NOT NULL,				
				[MatrixB]		VARBINARY(MAX)	NOT NULl,
				[Hash]			BINARY(20)		NOT NULL,
				[Alias]			VARCHAR(255)	NULL,
				[Title]			NVARCHAR(255)	NULL,
				[Description]	NTEXT			NULL
			)
			
			PRINT '	Table "Problem" has been created'

			--Add Primary Key
			ALTER TABLE [dbo].[Problem] 
				ADD CONSTRAINT PK_ProblemId PRIMARY KEY NONCLUSTERED (Id);

			PRINT '	"PK_ProblemId" PK added to "[dbo].[Problem]"'

			--Create index
			CREATE INDEX IX_ProblemHash	ON [dbo].[Problem] ([Hash]);

			PRINT '	Index "IX_ProblemHash" has been created'
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

