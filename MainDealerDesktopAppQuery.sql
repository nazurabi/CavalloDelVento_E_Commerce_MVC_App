CREATE DATABASE CavalloDelVentoWebAppDb
GO
USE CavalloDelVentoWebAppDb
GO
CREATE TABLE Brands (
BrandID int IDENTITY (1,1),
BrandName nvarchar(100) not null,
CONSTRAINT pk_brand PRIMARY KEY(BrandID)
) 
GO
INSERT INTO Brands(BrandName) VALUES ('Bianchi')
INSERT INTO Brands(BrandName) VALUES ('Colnago')
INSERT INTO Brands(BrandName) VALUES ('Wilier Triestina')
INSERT INTO Brands(BrandName) VALUES ('Olympia')
INSERT INTO Brands(BrandName) VALUES ('Sram')
INSERT INTO Brands(BrandName) VALUES ('Shimano')
INSERT INTO Brands(BrandName) VALUES ('Trek')
INSERT INTO Brands(BrandName) VALUES ('Cannondale')
INSERT INTO Brands(BrandName) VALUES ('Specialized')
INSERT INTO Brands(BrandName) VALUES ('S-Works')
GO
CREATE TABLE Categories(
CategoryID int IDENTITY(1,1),
BrandIDFK int,
CategoryName nvarchar(50) not null,
Description nvarchar(max),
CONSTRAINT pk_category PRIMARY KEY (CategoryID),
CONSTRAINT fk_brand FOREIGN KEY (BrandIDFK) REFERENCES Brands(BrandID)
)
GO
CREATE TABLE Products(
ProductID int IDENTITY (1,1),
BrandIDFK int,
CategoryIDFK int,
ProductName nvarchar(50) not null,
QuantityPerUnit nvarchar(50),
UnitPrice money,
UnitsInStock smallint,
UnitsOnOrder smallint,
ReorderLevel smallint,
Discontinued bit,
IsDeleted bit,
CONSTRAINT pk_products PRIMARY KEY (ProductID),
CONSTRAINT fk_brand FOREIGN KEY (BrandIDFK) REFERENCES Brands(BrandID),
CONSTRAINT fk_category FOREIGN KEY (CategoryIDFK) REFERENCES Categories(CategoryID)
)
