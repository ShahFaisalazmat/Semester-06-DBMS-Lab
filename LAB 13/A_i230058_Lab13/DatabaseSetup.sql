USE LibraryDB;
GO

-- Check existing columns
SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Books';
GO

-- Check existing data
SELECT * FROM Books;
GO