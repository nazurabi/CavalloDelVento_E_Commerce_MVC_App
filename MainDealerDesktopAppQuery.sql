CREATE DATABASE CavalloDelVentoWebAppDb
GO
USE CavalloDelVentoWebAppDb
GO
CREATE TABLE MainDealerSettings(
SettingID int IDENTITY (1,1),
DealerName nvarchar(100) not null,
Mail nvarchar(50) not null,
Adress nvarchar(max),
City nvarchar(50),
PostalCode nvarchar(20),
Country nvarchar(50),
Image nvarchar(max),
InvoiceTaxAmount decimal(18,2) not null,
CONSTRAINT pk_mainDealer PRIMARY KEY (SettingID)
)
GO
INSERT INTO MainDealerSettings(DealerName,Mail,Adress,City,PostalCode,Country,Image,InvoiceTaxAmount)
VALUES ('Cavallo Del Vento','cavallodelvento@gmail.com','Strada Statale 524','Cheiti','66022','Italy','cavallodelventologo.png	',20)
GO
CREATE TABLE MainDealerUsers(
MainUserID int IDENTITY(1,1),
UserName nvarchar(50) not null,
UserPassword nvarchar(50) not null,
UserType nvarchar(10) not null,
IsDeleted bit,
CONSTRAINT pk_mainUser PRIMARY KEY (MainUserID)
)
GO
INSERT INTO MainDealerUsers(UserName,UserPassword,UserType,IsDeleted)VALUES ('nasuh','1863','Admin',0)
INSERT INTO MainDealerUsers(UserName,UserPassword,UserType,IsDeleted)VALUES ('nazurabi','1234','User',0)
GO
CREATE TABLE DiscountRatesSettings(
DiscountID int IDENTITY(1,1),
DiscountType nvarchar(10),
DiscountAmount tinyint,
CONSTRAINT pk_discountRates PRIMARY KEY (DiscountID)
)
GO
INSERT INTO DiscountRatesSettings(DiscountType,DiscountAmount) VALUES ('Gold',10)
INSERT INTO DiscountRatesSettings(DiscountType,DiscountAmount) VALUES ('Silver',5)
INSERT INTO DiscountRatesSettings(DiscountType,DiscountAmount) VALUES ('Bronze',2)
INSERT INTO DiscountRatesSettings(DiscountType,DiscountAmount) VALUES ('Normal',0)
GO
CREATE TABLE SubDealerUsers(
SubDealerUserID int IDENTITY(1,1),
DealerName nvarchar(50),
DealerMail nvarchar(50),
DiscountIDFK int,
DealerAddress nvarchar(max),
DealerCity nvarchar(50),
DealerPostalCode nvarchar(20),
DealerCountry nvarchar(50),
IsDeleted bit,
CONSTRAINT pk_subDealer PRIMARY KEY (SubDealerUserID),
CONSTRAINT fk_discount FOREIGN KEY (DiscountIDFK) REFERENCES DiscountRatesSettings(DiscountID)
)
GO
INSERT INTO SubDealerUsers(DealerName, DealerMail, DiscountIDFK, DealerAddress, DealerCity, DealerPostalCode,DealerCountry,IsDeleted)
 VALUES ('Gold Bike','goldbike@gmail.com',1,'Viale Gran Sasso 520','Cheiti','66022','Italy',0)
GO
CREATE TABLE Brands (
BrandID int IDENTITY (1,1),
BrandName nvarchar(100),
Image nvarchar(max),
IsDeleted bit,
IsActive bit,
CONSTRAINT pk_brand PRIMARY KEY(BrandID)
) 
GO
CREATE TABLE Categories(
CategoryID int IDENTITY(1,1),
BrandIDFK int,
CategoryName nvarchar(50),
Description nvarchar(max),
IsDeleted bit,
IsActive bit,
Image nvarchar(max),
CONSTRAINT pk_category PRIMARY KEY (CategoryID),
CONSTRAINT fk_brandForC FOREIGN KEY (BrandIDFK) REFERENCES Brands(BrandID)
)
GO
CREATE TABLE Products(
ProductID int IDENTITY (1,1),
BrandIDFK int,
CategoryIDFK int,
ProductName nvarchar(50),
Description nvarchar(max),
Image nvarchar(max),
QuantityPerUnit nvarchar(50),
UnitPrice decimal(18,2),
UnitsInStock smallint,
UnitsOnOrder smallint,
ReorderLevel smallint,
Discontinued bit,
IsDeleted bit,
IsActive bit,
CONSTRAINT pk_products PRIMARY KEY (ProductID),
CONSTRAINT fk_brandForP FOREIGN KEY (BrandIDFK) REFERENCES Brands(BrandID),
CONSTRAINT fk_categoryForP FOREIGN KEY (CategoryIDFK) REFERENCES Categories(CategoryID)
)
GO
CREATE TABLE SendToSubDealers(
SendID int IDENTITY (1,1),
BrandIDFK int,
CategoryIDFK int,
ProductIDFK int,
ProductItemNumber nvarchar(50),
MainUserIDFK int,
SubDealerUserIDFK int,
SendDate datetime,
SendQuantity smallint,
UnitPrice decimal (18,2),
SubTotalPrice decimal(18,2),
Tax decimal(18,2),
TotalPrice decimal(18,2),
DiscountedPrice decimal(18,2),
Description nvarchar(max),
IsDeleted bit,
CONSTRAINT pk_send PRIMARY KEY (SendID),
CONSTRAINT fk_brandForSub FOREIGN KEY (BrandIDFK) REFERENCES Brands(BrandID),
CONSTRAINT fk_categoryForSub FOREIGN KEY (CategoryIDFK) REFERENCES Categories(CategoryID),
CONSTRAINT fk_productForSub FOREIGN KEY (ProductIDFK) REFERENCES Products(ProductID),
CONSTRAINT fk_userForSub FOREIGN KEY (SubDealerUserIDFK) REFERENCES SubDealerUsers(SubDealerUserID),
CONSTRAINT fk_mainUserForSub FOREIGN KEY (MainUserIDFK) REFERENCES MainDealerUsers(MainUserID)
)
GO
CREATE TABLE LevelIntegration(
LevelIntegrationID int IDENTITY(1,1),
BrandIDFK int,
CategoryIDFK int,
ProductIDFK int,
UserIDFK int,
UnitsOnOrder smallint,
OrderDate datetime,
CompletionLevel smallint,
OrderCompletionDate datetime,
Description nvarchar(max),
IsDeleted bit,
CONSTRAINT pk_levelIntegration PRIMARY KEY (LevelIntegrationID),
CONSTRAINT fk_brandForLev FOREIGN KEY (BrandIDFK) REFERENCES Brands(BrandID),
CONSTRAINT fk_categoryForLev FOREIGN KEY (CategoryIDFK) REFERENCES Categories(CategoryID),
CONSTRAINT fk_productForLev FOREIGN KEY (ProductIDFK) REFERENCES Products(ProductID),
CONSTRAINT fk_userForLev FOREIGN KEY (UserIDFK) REFERENCES MainDealerUsers(MainUserID)
)