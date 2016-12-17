ALTER TABLE [dbo].[LogEntries] DROP COLUMN Id
ALTER TABLE [dbo].[LogEntries] ADD Id INT IDENTITY(1,1)

DELETE FROM LogEntries

select * from [dbo].[LogEntries]