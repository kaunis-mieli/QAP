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
				Id			BIGINT			NOT NULL	IDENTITY,
				Size		SMALLINT		NOT NULL,
				Fitness		REAL			NOT NULL,
				Permutation	VARBINARY(MAX)	NOT NULL,
				ProblemId	INT				NOT NULL,
			)
			
			PRINT '	Table "Solution" has been created'

			--Add Primary Key
			ALTER TABLE [dbo].[Solution] 
				ADD CONSTRAINT PK_SolutionId PRIMARY KEY NONCLUSTERED (Id);

			PRINT '	"PK_SolutionId" PK added to "[dbo].[Solution]"'

			--Create Foreign Key to [Problem]
			ALTER TABLE [dbo].[Solution] 
				ADD CONSTRAINT FK_Solution_Problem FOREIGN KEY (ProblemId)
				REFERENCES [dbo].[Problem] (Id)
				ON DELETE CASCADE
				ON UPDATE CASCADE;

			PRINT '	"FK_Solution_Problem" Foreign Key added to "[dbo].[Solution]"'

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

