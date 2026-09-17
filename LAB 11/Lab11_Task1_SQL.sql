-- ============================================================
--  Lab 11 – Task 1: TechHub Electronics Store
--  3NF SQL Implementation – Microsoft SQL Server
-- ============================================================

USE master;
GO

-- Create and switch to the TechHub database
IF DB_ID('TechHub') IS NOT NULL
    DROP DATABASE TechHub;
GO
CREATE DATABASE TechHub;
GO
USE TechHub;
GO

-- ============================================================
--  TABLE CREATION (3NF Schema)
-- ============================================================

-- 1. Supplier
CREATE TABLE Supplier (
    SupplierID   VARCHAR(10)  NOT NULL PRIMARY KEY,
    SupplierName VARCHAR(100) NOT NULL,
    SupplierCity VARCHAR(50)  NOT NULL
);
GO

-- 2. Product  (FK → Supplier)
CREATE TABLE Product (
    ProductID   VARCHAR(10)  NOT NULL PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Category    VARCHAR(50)  NOT NULL,
    Price       DECIMAL(10,2) NOT NULL,
    SupplierID  VARCHAR(10)  NOT NULL,
    Warranty    VARCHAR(30)  NOT NULL,
    CONSTRAINT FK_Product_Supplier FOREIGN KEY (SupplierID)
        REFERENCES Supplier(SupplierID)
);
GO

-- 3. Customer
CREATE TABLE Customer (
    CustomerID   VARCHAR(10)  NOT NULL PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Phone        VARCHAR(20)  NOT NULL,
    AltPhone     VARCHAR(20)  NULL,
    Email        VARCHAR(100) NOT NULL,
    Address      VARCHAR(150) NOT NULL,
    City         VARCHAR(50)  NOT NULL
);
GO

-- 4. Salesman
CREATE TABLE Salesman (
    SalesmanID   VARCHAR(10)  NOT NULL PRIMARY KEY,
    SalesmanName VARCHAR(100) NOT NULL
);
GO

-- 5. Sale  (FK → Customer, Salesman)
CREATE TABLE Sale (
    SaleID         INT          NOT NULL PRIMARY KEY,
    CustomerID     VARCHAR(10)  NOT NULL,
    SalesmanID     VARCHAR(10)  NOT NULL,
    PurchaseDate   DATE         NOT NULL,
    PaymentStatus  VARCHAR(20)  NOT NULL,
    Discount       DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalAmount    DECIMAL(12,2) NOT NULL,
    DeliveryStatus VARCHAR(20)  NOT NULL,
    CONSTRAINT FK_Sale_Customer  FOREIGN KEY (CustomerID)  REFERENCES Customer(CustomerID),
    CONSTRAINT FK_Sale_Salesman  FOREIGN KEY (SalesmanID)  REFERENCES Salesman(SalesmanID)
);
GO

-- 6. SaleItem  (composite PK, FK → Sale, Product)
CREATE TABLE SaleItem (
    SaleID        INT          NOT NULL,
    ProductID     VARCHAR(10)  NOT NULL,
    Qty           INT          NOT NULL,
    PaymentMethod VARCHAR(30)  NOT NULL,
    LineTotal     DECIMAL(12,2) NOT NULL,
    CONSTRAINT PK_SaleItem PRIMARY KEY (SaleID, ProductID),
    CONSTRAINT FK_SaleItem_Sale    FOREIGN KEY (SaleID)    REFERENCES Sale(SaleID),
    CONSTRAINT FK_SaleItem_Product FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
GO


-- ============================================================
--  INSERT SAMPLE DATA
-- ============================================================

-- Supplier
INSERT INTO Supplier (SupplierID, SupplierName, SupplierCity) VALUES
('S001', 'TechDistrib',  'Lahore'),
('S002', 'GadgetWorld',  'Karachi'),
('S003', 'DigiSupplies', 'Islamabad'),
('S004', 'AlphaVision',  'Faisalabad'),
('S005', 'ByteMart',     'Multan');
GO

-- Product
INSERT INTO Product (ProductID, ProductName, Category, Price, SupplierID, Warranty) VALUES
('P101', 'HP Laptop',           'Laptop',    120000.00, 'S001', '2 Years'),
('P102', 'Logitech Mouse',      'Accessory',   1500.00, 'S002', '1 Year'),
('P104', 'Asus Laptop',         'Laptop',    150000.00, 'S001', '3 Years'),
('P105', 'HP Mouse',            'Accessory',   1800.00, 'S002', '6 Months'),
('P106', 'Lenovo Laptop',       'Laptop',    130000.00, 'S001', '2 Years'),
('P109', 'Dell Mouse',          'Accessory',   1300.00, 'S001', '1 Year'),
('P110', 'Dell Laptop',         'Laptop',    125000.00, 'S001', '2 Years'),
('P111', 'HP Keyboard',         'Accessory',   3500.00, 'S002', '1 Year'),
('P112', 'Gaming Mouse',        'Accessory',   2500.00, 'S002', '6 Months'),
('P113', 'Acer Laptop',         'Laptop',    135000.00, 'S001', '2 Years'),
('P114', 'USB Drive',           'Accessory',   1500.00, 'S002', '6 Months'),
('P115', 'Mechanical Keyboard', 'Accessory',   8000.00, 'S002', '1 Year');
GO

-- Customer
INSERT INTO Customer (CustomerID, CustomerName, Phone, AltPhone, Email, Address, City) VALUES
('C001', 'Ali Khan',      '03001234567', '03219999999', 'ali@gmail.com',    'Street 1',  'Peshawar'),
('C002', 'Sara Ahmed',    '03117654321', NULL,          'sara@gmail.com',   'Street 5',  'Karachi'),
('C003', 'Bilal Hussain', '03221112222', '03008888888', 'bilal@gmail.com',  'Street 3',  'Lahore'),
('C004', 'Ayesha Noor',   '03334445555', '03457777777', 'ayesha@gmail.com', 'Street 7',  'Islamabad'),
('C005', 'Hamza Ali',     '03445556666', NULL,          'hamza@gmail.com',  'Street 2',  'Karachi'),
('C006', 'Noor Fatima',   '03556667777', '03331111111', 'noor@gmail.com',   'Street 9',  'Lahore'),
('C007', 'Usman Tariq',   '03005551234', NULL,          'usman@gmail.com',  'Street 10', 'Rawalpindi'),
('C008', 'Zain Malik',    '03119998888', NULL,          'zain@gmail.com',   'Street 11', 'Karachi'),
('C009', 'Hina Aslam',    '03223334444', NULL,          'hina@gmail.com',   'Street 12', 'Islamabad'),
('C010', 'Farhan Raza',   '03336667777', NULL,          'farhan@gmail.com', 'Street 13', 'Lahore');
GO

-- Salesman
INSERT INTO Salesman (SalesmanID, SalesmanName) VALUES
('SM001', 'Ahmed'),
('SM002', 'Bilal'),
('SM003', 'Usman');
GO

-- Sale
INSERT INTO Sale (SaleID, CustomerID, SalesmanID, PurchaseDate, PaymentStatus, Discount, TotalAmount, DeliveryStatus) VALUES
(1,  'C001', 'SM001', '2026-03-20', 'Paid',    5000.00,  115000.00, 'Delivered'),
(2,  'C002', 'SM002', '2026-03-21', 'Pending',    0.00,  240000.00, 'Pending'),
(3,  'C003', 'SM001', '2026-03-22', 'Mixed',    100.00,   14000.00, 'Delivered'),
(4,  'C004', 'SM002', '2026-03-23', 'Paid',   10000.00,  140000.00, 'Delivered'),
(5,  'C005', 'SM001', '2026-03-24', 'Pending',    0.00,    3600.00, 'Pending'),
(6,  'C006', 'SM003', '2026-03-25', 'Paid',    5000.00,  125000.00, 'Delivered'),
(7,  'C007', 'SM001', '2026-03-25', 'Paid',    3000.00,  130500.00, 'Delivered'),
(8,  'C008', 'SM002', '2026-03-26', 'Paid',     200.00,    7300.00, 'Delivered'),
(9,  'C009', 'SM003', '2026-03-26', 'Paid',    7000.00,  141000.00, 'Delivered'),
(10, 'C010', 'SM001', '2026-03-27', 'Pending',  500.00,   15500.00, 'Pending');
GO

-- SaleItem
INSERT INTO SaleItem (SaleID, ProductID, Qty, PaymentMethod, LineTotal) VALUES
(1,  'P101', 1, 'Credit Card', 115000.00),
(2,  'P101', 2, 'JazzCash',    240000.00),
(3,  'P102', 5, 'Cash',          7500.00),
(3,  'P109', 2, 'Credit Card',   2600.00),
(4,  'P104', 1, 'Credit Card', 140000.00),
(5,  'P105', 2, 'JazzCash',      3600.00),
(6,  'P106', 1, 'Credit Card', 125000.00),
(7,  'P110', 1, 'Cash',        122000.00),
(7,  'P111', 2, 'Credit Card',   7000.00),
(8,  'P112', 3, 'Easypaisa',     7300.00),
(9,  'P113', 1, 'Credit Card', 128000.00),
(9,  'P114', 4, 'Credit Card',   6000.00),
(10, 'P115', 2, 'Cash',         15500.00);
GO


-- ============================================================
--  SAMPLE QUERIES
-- ============================================================

-- Query 1: List all products along with their supplier details
-- (Join Product and Supplier to see who supplies each product)
SELECT
    p.ProductID,
    p.ProductName,
    p.Category,
    p.Price,
    p.Warranty,
    s.SupplierName,
    s.SupplierCity
FROM Product p
INNER JOIN Supplier s ON p.SupplierID = s.SupplierID
ORDER BY p.Category, p.ProductName;
GO

-- Query 2: Show all purchases made by each customer with product and payment details
-- (Full customer purchase history with salesman name)
SELECT
    c.CustomerName,
    c.City AS CustomerCity,
    sa.SaleID,
    sa.PurchaseDate,
    p.ProductName,
    p.Category,
    si.Qty,
    si.PaymentMethod,
    si.LineTotal,
    sm.SalesmanName,
    sa.DeliveryStatus
FROM Sale sa
INNER JOIN Customer   c  ON sa.CustomerID  = c.CustomerID
INNER JOIN Salesman   sm ON sa.SalesmanID  = sm.SalesmanID
INNER JOIN SaleItem   si ON sa.SaleID      = si.SaleID
INNER JOIN Product    p  ON si.ProductID   = p.ProductID
ORDER BY sa.PurchaseDate, c.CustomerName;
GO

-- Query 3: Find all pending (unpaid) sales along with customer contact details
-- (Useful for the billing / follow-up team)
SELECT
    sa.SaleID,
    c.CustomerName,
    c.Phone,
    c.Email,
    sa.PurchaseDate,
    sa.TotalAmount,
    sa.Discount,
    sa.DeliveryStatus
FROM Sale sa
INNER JOIN Customer c ON sa.CustomerID = c.CustomerID
WHERE sa.PaymentStatus IN ('Pending', 'Mixed')
ORDER BY sa.TotalAmount DESC;
GO

-- Query 4: Total revenue and units sold per product category
-- (Aggregate report for business insight)
SELECT
    p.Category,
    COUNT(DISTINCT si.SaleID)       AS NumberOfSales,
    SUM(si.Qty)                     AS TotalUnitsSold,
    SUM(si.LineTotal)               AS TotalRevenue,
    AVG(p.Price)                    AS AvgProductPrice
FROM SaleItem si
INNER JOIN Product p ON si.ProductID = p.ProductID
GROUP BY p.Category
ORDER BY TotalRevenue DESC;
GO

-- Query 5: Salesman performance – total sales amount handled by each salesman
-- (Ranks salesmen by revenue generated)
SELECT
    sm.SalesmanName,
    COUNT(sa.SaleID)          AS TotalSales,
    SUM(sa.TotalAmount)       AS TotalRevenue,
    SUM(sa.Discount)          AS TotalDiscountsGiven,
    AVG(sa.TotalAmount)       AS AvgSaleValue
FROM Sale sa
INNER JOIN Salesman sm ON sa.SalesmanID = sm.SalesmanID
GROUP BY sm.SalesmanName
ORDER BY TotalRevenue DESC;
GO
