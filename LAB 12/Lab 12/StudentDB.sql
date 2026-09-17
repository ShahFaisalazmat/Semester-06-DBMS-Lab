-- ============================================================
-- Lab 12: Connection of C# Application Forms with SQL Server
-- SQL Script: StudentDB Setup
-- ============================================================

-- Step 1: Create the Database
CREATE DATABASE StudentDB;
GO

-- Step 2: Use the Database
USE StudentDB;
GO

-- Step 3: Create the Students Table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Name      VARCHAR(100) NOT NULL,
    Course    VARCHAR(100) NOT NULL,
    Email     VARCHAR(150) NOT NULL
);
GO

-- Step 4: Insert Realistic Sample Records
INSERT INTO Students (Name, Course, Email)
VALUES
    ('Ali Hassan',     'Bachelor of Software Engineering', 'ali.hassan@nu.edu.pk'),
    ('Sara Ahmed',     'Bachelor of Computer Science',     'sara.ahmed@nu.edu.pk'),
    ('Usman Tariq',    'Bachelor of Data Science',         'usman.tariq@nu.edu.pk'),
    ('Ayesha Malik',   'Bachelor of Artificial Intelligence', 'ayesha.malik@nu.edu.pk'),
    ('Bilal Chaudhry', 'Bachelor of Cyber Security',       'bilal.chaudhry@nu.edu.pk');
GO

-- Step 5: Verify inserted records
SELECT * FROM Students;
GO
