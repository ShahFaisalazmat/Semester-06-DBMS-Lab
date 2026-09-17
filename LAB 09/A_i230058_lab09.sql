-- ================================
-- DATABASE CREATION
-- ================================
CREATE DATABASE LAB09;
GO

USE Lab09;
GO

-- ================================
-- TABLES
-- ================================
CREATE TABLE Customers(
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(50),
    City VARCHAR(50),
    Email VARCHAR(50)
);

CREATE TABLE Employees(
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    City VARCHAR(50),
    ManagerID INT
);

CREATE TABLE Products(
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    Price DECIMAL(10,2),
    Category VARCHAR(50)
);

CREATE TABLE Orders(
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    EmployeeID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10,2)
);

CREATE TABLE OrderDetails(
    DetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT
);

-- ================================
-- INSERT SAMPLE DATA
-- ================================

INSERT INTO Customers VALUES
(1,'Ali Khan','Peshawar','ali@gmail.com'),
(2,'Sara Ahmed','Lahore','sara@gmail.com'),
(3,'Usman Tariq','Karachi','usman@gmail.com'),
(4,'Hina Noor','Islamabad','hina@gmail.com'),
(5,'Ahmad Raza','Multan','ahmad@gmail.com'),
(6,'Zara Shah','Quetta','zara@gmail.com'),
(7,'Bilal Khan','Peshawar','bilal@gmail.com'),
(8,'Ayesha Malik','Lahore','ayesha@gmail.com');

INSERT INTO Employees VALUES
(1,'Manager A','Peshawar',NULL),
(2,'Bilal Shah','Lahore',1),
(3,'Danish Ali','Karachi',1),
(4,'Farhan Khan','Islamabad',2),
(5,'Hamza Tariq','Multan',2),
(6,'Irfan Ali','Quetta',3),
(7,'Junaid Khan','Peshawar',3),
(8,'Kamran Malik','Lahore',4);

INSERT INTO Products VALUES
(1,'Laptop',120000,'Electronics'),
(2,'Mouse',1500,'Electronics'),
(3,'Keyboard',3000,'Electronics'),
(4,'Chair',8000,'Furniture'),
(5,'Table',12000,'Furniture'),
(6,'Monitor',25000,'Electronics'),
(7,'Printer',20000,'Electronics'),
(8,'Headphones',5000,'Electronics');

INSERT INTO Orders VALUES
(101,1,2,'2025-01-10',121500),
(102,2,3,'2025-01-11',3000),
(103,3,4,'2025-01-12',8000),
(104,1,2,'2025-01-15',1500),
(105,4,5,'2025-01-17',25000),
(106,5,6,'2025-01-18',20000),
(107,6,7,'2025-01-19',5000),
(108,7,8,'2025-01-20',12000);

INSERT INTO OrderDetails VALUES
(1,101,1,1),
(2,101,2,1),
(3,102,3,1),
(4,103,4,1),
(5,104,2,1),
(6,105,6,1),
(7,106,7,1),
(8,107,8,1);

-- ================================
-- YOUR OWN RECORDS (FAISAL)
-- ================================

INSERT INTO Customers VALUES
(9, ' Shah Faisal', 'Rawalpindi', 'faisal@gmail.com');

INSERT INTO Employees VALUES
(9, 'Shah Faisal', 'Rawalpindi', 2);

INSERT INTO Products VALUES
(9, 'Webcam', 7000, 'Electronics');

INSERT INTO Orders VALUES
(0058, 9, 9, '2025-01-21', 7000);

INSERT INTO OrderDetails VALUES
(9, 109, 9, 1);

-- ================================
-- QUERIES
-- ================================

-- 1
SELECT C.CustomerName, C.City, O.OrderID
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID;

-- 2
SELECT O.OrderID, P.ProductName, OD.Quantity
FROM OrderDetails OD
JOIN Products P ON OD.ProductID = P.ProductID
JOIN Orders O ON OD.OrderID = O.OrderID;

-- 3
SELECT P.ProductName, SUM(OD.Quantity) AS TotalQuantity
FROM OrderDetails OD
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY P.ProductName;

-- 4
SELECT Category, AVG(Price) AS AvgPrice
FROM Products
GROUP BY Category;

-- 5
SELECT C.CustomerName, SUM(O.TotalAmount) AS TotalPurchase
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
GROUP BY C.CustomerName;

-- 6
SELECT E.EmployeeName AS Employee, M.EmployeeName AS Manager
FROM Employees E
LEFT JOIN Employees M ON E.ManagerID = M.EmployeeID;

-- 7
SELECT ProductName
FROM Products
WHERE ProductName LIKE 'L%';

-- 8
SELECT C.CustomerName, O.OrderID
FROM Customers C
LEFT JOIN Orders O ON C.CustomerID = O.CustomerID;

-- 9 (SQL Server)
SELECT TOP 5 P.ProductName, SUM(OD.Quantity) AS TotalSold
FROM OrderDetails OD
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY P.ProductName
ORDER BY TotalSold DESC;

-- For MySQL use:
-- LIMIT 5 instead of TOP 5

-- 10
SELECT C.CustomerName, SUM(O.TotalAmount) AS TotalPurchase
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
GROUP BY C.CustomerName
HAVING SUM(O.TotalAmount) > 20000;

-- 11
SELECT P.ProductName, E.EmployeeName
FROM Products P
CROSS JOIN Employees E;

-- 12
SELECT 
    C.CustomerName,
    P.ProductName,
    OD.Quantity,
    O.OrderDate,
    E.EmployeeName
FROM Orders O
JOIN Customers C ON O.CustomerID = C.CustomerID
JOIN Employees E ON O.EmployeeID = E.EmployeeID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID;