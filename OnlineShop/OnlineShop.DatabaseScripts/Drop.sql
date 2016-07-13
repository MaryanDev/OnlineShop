USE ShopDB
GO

ALTER TABLE Products
DROP CONSTRAINT FK_Prod_To_Category; 


ALTER TABLE Basket
DROP CONSTRAINT FK_Basket_To_Prod;

ALTER TABLE Basket
DROP CONSTRAINT FK_Basket_To_Client;

ALTER TABLE Comments
DROP CONSTRAINT FK_Comment_To_Prod;

ALTER TABLE Comments
DROP CONSTRAINT FK_Comment_To_Client;

ALTER TABLE Products
DROP CONSTRAINT FK_Admin_To_Prod;

DROP TABLE Products;

DROP TABLE Clients;

DROP TABLE Categories;

DROP TABLE Comments;

DROP TABLE Basket;

DROP Table Administrators;