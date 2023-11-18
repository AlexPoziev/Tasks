CREATE TABLE Products (
    ProductID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(50)
);

INSERT INTO Products (ProductName) VALUES
('Eggs Red'),
('Eggs Blue'),
('Eggs Test'),
('Eggs Green');

CREATE TABLE Categories (
    CategoryID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(50)
);

INSERT INTO Categories (CategoryName) VALUES
('Category C0'),
('Category C1'),
('Category C2');

CREATE TABLE ProductCategory (
    ProductID INT,
    CategoryID INT,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

INSERT INTO ProductCategory (ProductID, CategoryID) VALUES
(1, 1),
(1, 2),
(2, 2),
(3, 3);
