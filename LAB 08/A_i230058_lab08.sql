CREATE DATABASE Lab0008;
GO

USE Lab0008;
GO

CREATE TABLE Books (
    BookId INT PRIMARY KEY,
    Title VARCHAR(100),
    Author VARCHAR(100),
    Category VARCHAR(50),
    Price INT,
    Quantity INT
);

CREATE TABLE Members (
    MemberId INT PRIMARY KEY,
    Name VARCHAR(100),
    Email VARCHAR(100),
    City VARCHAR(50),
    Status VARCHAR(20)
);

CREATE TABLE Borrow (
    BorrowId INT PRIMARY KEY,
    Book_id INT,
    Member_id INT,
    BorrowDate DATE,
    ReturnDate DATE,
    Status VARCHAR(20),

    FOREIGN KEY (Book_id) REFERENCES Books(BookId),
    FOREIGN KEY (Member_id) REFERENCES Members(MemberId)
);

INSERT INTO Books VALUES
(1,'Clean Code','Robert Martin','Programming',1200,4),
(2,'Database Concepts','Korth','Education',900,6),
(3,'AI Basics','Andrew Ng','Technology',1500,2),
(4,'Deep Learning','Ian Goodfellow','Technology',1800,3);

INSERT INTO Members VALUES
(101,'Ali Khan','ali@gmail.com','Lahore','Active'),
(102,'Sara Ahmed','sara@yahoo.com','Karachi','Active'),
(103,'John Lee','john@yahoo.com',NULL,'Inactive'),
(104,'Ahmed Raza','ahmed@gmail.com','Lahore','Active');

INSERT INTO Borrow VALUES
(1,1,101,'2025-01-10','2025-01-18','Returned'),
(2,3,102,'2025-02-01',NULL,'Borrowed'),
(3,2,101,'2025-02-10',NULL,'Borrowed'),
(4,1,104,'2025-02-15',NULL,'Borrowed');

-- Query 01
SELECT *
FROM Books
ORDER BY Price DESC, Title ASC;

-- Query 02
SELECT Title, Author, Price
FROM Books
WHERE Price > 1000 AND Quantity >= 2;

-- Query 03
SELECT DISTINCT Category
FROM Books
ORDER BY Category ASC;

-- Query 04
SELECT *
FROM Members
WHERE City IS NULL OR Status = 'Inactive';

-- Query 05
SELECT Title
FROM Books
WHERE Title LIKE 'D%' OR Title LIKE '%e';

-- Query 06
SELECT m.Name, b.Title
FROM Members m
INNER JOIN Borrow br ON m.MemberId = br.Member_id
INNER JOIN Books b ON br.Book_id = b.BookId;

-- Query 07
SELECT Name
FROM Members
WHERE MemberId IN (
    SELECT Member_id
    FROM Borrow
    WHERE Book_id IN (
        SELECT BookId
        FROM Books
        WHERE Author = 'Robert Martin'
    )
);

-- Query 08
SELECT Title
FROM Books b
WHERE NOT EXISTS (
    SELECT *
    FROM Borrow br
    WHERE br.Book_id = b.BookId
);

-- Query 09
SELECT Name
FROM Members
WHERE MemberId IN (
    SELECT Member_id
    FROM Borrow
    WHERE Book_id IN (
        SELECT BookId
        FROM Books
        WHERE Category = 'Programming'
    )
);

-- Query 10
UPDATE Books
SET Price = Price * 1.05
WHERE Category = 'Education' AND Quantity > 2;

-- Query 11
DELETE FROM Borrow
WHERE Status = 'Returned'
AND ReturnDate IS NOT NULL;

-- Data Transfer Task
CREATE TABLE InactiveMembers (
    MemberId INT,
    Name VARCHAR(100),
    Email VARCHAR(100),
    City VARCHAR(50)
);

INSERT INTO InactiveMembers (MemberId, Name, Email, City)
SELECT MemberId, Name, Email, City
FROM Members
WHERE Status = 'Inactive' OR City IS NULL;

DELETE FROM Members
WHERE MemberId IN (
    SELECT MemberId
    FROM InactiveMembers
);

