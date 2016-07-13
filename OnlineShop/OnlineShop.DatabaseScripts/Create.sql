CREATE DATABASE ShopDB
GO

USE ShopDB
GO

CREATE TABLE Categories
(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	Name nvarchar(70) NOT NULL
);

CREATE TABLE Products
(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	CategoryId int NOT NULL,
	Cost decimal NOT NULL,
	Quantity int NOT NULL,
	RegisteredBy int NOT NULL,
	IsAvailable bit NOT NULL,
	Title nvarchar(70) NOT NULL,
	Photo image NULL,
	Likes smallint NOT NULL,
	Dislikes smallint NOT NULL
);

CREATE TABLE Clients
(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FirstName nvarchar(100) NOT NULL,
	LastName nvarchar(100) NOT NULL,
	BirthDate datetime NOT NULL,
	[Address] nvarchar(150) NULL,
	Email nvarchar(70) NOT NULL,
	PasswordHash uniqueidentifier NOT NULL
);

CREATE TABLE Basket
(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	ProductId int NOT NULL,
	ClientID int NOT NULL,
	IsSolded bit NOT NULL
);

CREATE TABLE Comments
(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Text] nvarchar(1000) NOT NULL,
	ProductId int NOT NULL,
	ClientId int NOT NULL
);

CREATE TABLE [Administrators]
(
	Id int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	FirstName nvarchar(100) NOT NULL,
	LastName nvarchar(100) NOT NULL,
	BirthDate datetime NOT NULL,
	[Address] nvarchar(150) NULL,
	Email nvarchar(70) NOT NULL,
	PasswordHash uniqueidentifier NOT NULL
);

ALTER TABLE Products
ADD CONSTRAINT FK_Prod_To_Category 
FOREIGN KEY (CategoryId) REFERENCES Categories(Id);

ALTER TABLE Basket
ADD CONSTRAINT FK_Basket_To_Prod
FOREIGN KEY (ProductId) REFERENCES Products(Id);

ALTER TABLE Basket
ADD CONSTRAINT FK_Basket_To_Client
FOREIGN KEY (ClientId) REFERENCES Clients(Id);

ALTER TABLE Comments
ADD CONSTRAINT FK_Comment_To_Prod
FOREIGN KEY (ProductId) REFERENCES Products(Id);

ALTER TABLE Comments
ADD CONSTRAINT FK_Comment_To_Client
FOREIGN KEY (ClientId) REFERENCES Clients(Id);

ALTER TABLE Products
ADD CONSTRAINT FK_Admin_To_Prod
FOREIGN KEY (RegisteredBy) REFERENCES Administrators(Id);