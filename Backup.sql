USE PAGAW_DB;

CREATE PROCEDURE backupdb
AS
BEGIN
	BACKUP DATABASE PAGAW_DB TO  DISK ='C:\FullBackupPAGAW\PAGAW.bak' WITH FORMAT;
END

exec backupdb;
drop procedure backupdb;