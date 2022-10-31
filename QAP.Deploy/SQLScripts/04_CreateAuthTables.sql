USE [QAP]
GO

BEGIN
	BEGIN TRY  
		BEGIN TRANSACTION

		--User table creation
		PRINT 'User'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'User' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [auth].[User] (
				[Id]			INT				NOT NULL	IDENTITY,
				[Alias]			VARCHAR(255)	NOT NULL,
				[FullName]		NVARCHAR(255)	NOT NULL,
				[Email]			VARCHAR(255)	NOT NULL,
				[Hash]			TEXT			NOT	NULL,
				[Timestamp]		DATETIME		NOT NULL DEFAULT GETDATE(),
				CONSTRAINT [PK_UserId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [UQ_UserAlias] UNIQUE ([Alias]),
				CONSTRAINT [UQ_UserEmail] UNIQUE ([Email]),
			);
			
			PRINT '	Table "User" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "User" already exists'
		END

		--User login table creation
		PRINT 'UserLogin'
		IF NOT EXISTS (SELECT * FROM sysobjects WHERE [Name] = 'UserLogin' AND xtype='U')
		BEGIN
			--Create table
			CREATE TABLE [auth].[UserLogin] (
				[Id]			INT				NOT NULL	IDENTITY,
				[UserId]		INT				NOT NULL,
				[Token]			TEXT			NOT NULL,
				[UserAgent]		TEXT			NOT NULL,
				[ValidUntil]	DATETIME		NOT NULL,
				[Enabled]		BIT				NOT NULL,
				[Timestamp]		DATETIME		NOT NULL	DEFAULT GETDATE(),
				CONSTRAINT [PK_UserLoginId] PRIMARY KEY NONCLUSTERED ([Id]),
				CONSTRAINT [FK_UserLogin_User] FOREIGN KEY ([UserId])
					REFERENCES [auth].[User] ([Id])
			);
			
			PRINT '	Table "UserLogin" has been created'
		END
		ELSE
		BEGIN
			PRINT '	Table "UserLogin" already exists'
		END

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE()
	END CATCH
END;