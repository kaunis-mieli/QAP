IF NOT EXISTS (SELECT 1 FROM sys. databases WHERE name = N'QAP') 
BEGIN
	CREATE DATABASE [QAP]
	COLLATE Lithuanian_CI_AS;
	PRINT 'Database QAP created'
END
ELSE
BEGIN
	PRINT 'Database QAP already exists'
END