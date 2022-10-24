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
			CREATE TABLE [const].[Algorithm] (
				[Id]			SMALLINT		NOT NULL	IDENTITY,
				[Alias]			VARCHAR(255)	NOT NULL,
				[Title]			NTEXT			NULL,
				[Description]	NTEXT			NULL,
				CONSTRAINT [PK_AlgorithmId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_AlgorithmAlias] UNIQUE ([Alias])
			);
			
			PRINT '	Table "Algorithm" has been created'

			INSERT INTO [const].[Algorithm] ([Alias], [Title], [Description]) VALUES
			('ClassicLocalSearchAlgorithm', 'Classical Local Search Algorithm', 'Classical Local Search Algorithm');

			PRINT '	Values inserted'
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

