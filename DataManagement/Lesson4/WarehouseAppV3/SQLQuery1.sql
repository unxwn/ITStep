﻿CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Suppliers (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    ContactInfo NVARCHAR(255)
);

CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    CategoryId INT NOT NULL,
    SupplierId INT NOT NULL,
    Quantity INT NOT NULL,
    CostPrice DECIMAL(10, 2) NOT NULL,
    SupplyDate DATE NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
);

INSERT INTO Categories (Name) VALUES
(N'Electronics'),
(N'Furniture'),
(N'Clothing'),
(N'Food');

INSERT INTO Categories (Name) VALUES
(N'ASD');

INSERT INTO Suppliers (Name, ContactInfo) VALUES
(N'ABC Electronics', N'abc@example.com'),
(N'Furniture Co.', N'contact@furniture.com'),
(N'Clothing World', N'info@clothingworld.com'),
(N'Fresh Foods', N'sales@freshfoods.com');

INSERT INTO Products (Name, CategoryId, SupplierId, Quantity, CostPrice, SupplyDate) VALUES
(N'Laptop', 1, 1, 10, 800.00, '2024-01-10'),
(N'Smartphone', 1, 1, 15, 500.00, '2024-01-12'),
(N'Sofa', 2, 2, 5, 1200.00, '2024-01-05'),
(N'Table', 2, 2, 8, 300.00, '2024-01-08'),
(N'T-Shirt', 3, 3, 50, 20.00, '2024-01-15'),
(N'Jeans', 3, 3, 30, 40.00, '2024-01-14'),
(N'Apples', 4, 4, 100, 1.50, '2024-01-20'),
(N'Milk', 4, 4, 60, 2.00, '2024-01-18');

SELECT Products.*, Categories.Name
FROM Products 
JOIN Categories ON Products.CategoryId = Categories.Id
WHERE Categories.Name = 'Electronics';

SELECT Categories.Name, AVG(Products.Quantity) AS AverageQuantity
FROM Products
JOIN Categories ON Products.CategoryId = Categories.Id
GROUP BY Categories.Name;


DROP PROCEDURE IF EXISTS sp_InsertProduct;
GO

GO
CREATE PROCEDURE sp_InsertProduct
    @Name NVARCHAR(100), 
    @CategoryId INT, 
    @SupplierId INT, 
    @CostPrice DECIMAL(10,2), 
    @Quantity INT, 
    @SupplyDate DATE 
AS 
BEGIN 
    INSERT INTO Products (Name, CategoryId, SupplierId, CostPrice, Quantity, SupplyDate) 
    VALUES (@Name, @CategoryId, @SupplierId, @CostPrice, @Quantity, @SupplyDate); 
END; 
GO

CREATE PROCEDURE sp_UpdateProduct 
    @Id INT, 
    @Name NVARCHAR(100), 
    @CategoryId INT, 
    @SupplierId INT, 
    @CostPrice DECIMAL(10,2), 
    @Quantity INT, 
    @SupplyDate DATE 
AS 
BEGIN 
    UPDATE Products 
    SET Name = @Name, 
        CategoryId = @CategoryId, 
        SupplierId = @SupplierId, 
        CostPrice = @CostPrice, 
        Quantity = @Quantity, 
        SupplyDate = @SupplyDate 
    WHERE Id = @Id; 
END; 
GO

CREATE PROCEDURE sp_DeleteProduct 
    @Id INT 
AS 
BEGIN 
    DELETE FROM Products 
    WHERE Id = @Id; 
END; 
GO

CREATE PROCEDURE sp_GetAllProducts 
AS
BEGIN 
    SELECT * FROM Products;
END; 
GO

CREATE PROCEDURE sp_GetAllCategories
AS
BEGIN 
    SELECT * FROM Categories;
END; 
GO

CREATE PROCEDURE sp_DeleteCategory 
    @Id INT 
AS 
BEGIN 
    DELETE FROM Categories 
    WHERE Id = @Id; 
END; 
GO

CREATE PROCEDURE sp_GetAllSuppliers
AS
BEGIN 
    SELECT * FROM Suppliers;
END; 
GO

CREATE PROCEDURE sp_DeleteSupplier 
    @Id INT 
AS 
BEGIN 
    DELETE FROM Suppliers
    WHERE Id = @Id; 
END; 
GO