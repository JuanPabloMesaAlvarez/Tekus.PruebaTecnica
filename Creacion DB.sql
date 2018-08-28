--DROP DATABASE MyTekusCnn
--GO
CREATE DATABASE MyTekusCnn
GO
USE [MyTekusCnn]

CREATE TABLE Countries(
	CountryId int NOT NULL,
	Name nvarchar(max) NULL,
 CONSTRAINT PK_Countries PRIMARY KEY CLUSTERED 
(
	CountryId ASC
)) 


CREATE TABLE Customers(
	CustomerId int IDENTITY(1,1) NOT NULL,
	Nit int NOT NULL,
	Name nvarchar(max) NULL,
	Email nvarchar(max) NULL,
 CONSTRAINT PK_Customers PRIMARY KEY CLUSTERED 
(
	CustomerId ASC
))


CREATE TABLE Services(
	ServiceId int IDENTITY(1,1) NOT NULL,
	Name nvarchar(max) NULL,
	Cost decimal(18, 2) NOT NULL,
	CustomerId int NOT NULL,
 CONSTRAINT PK_Services PRIMARY KEY CLUSTERED 
(
	ServiceId ASC
))


CREATE TABLE ServicesCountries(
	ServiceId int NOT NULL,
	CountryId int NOT NULL,
 CONSTRAINT PK_ServicesCountries PRIMARY KEY CLUSTERED 
(
	ServiceId ASC,
	CountryId ASC
))



ALTER TABLE Services  WITH CHECK ADD  CONSTRAINT FK_Services_Customers_CustomerId FOREIGN KEY(CustomerId)
REFERENCES Customers (CustomerId)
ON DELETE CASCADE


ALTER TABLE Services CHECK CONSTRAINT FK_Services_Customers_CustomerId



ALTER TABLE ServicesCountries  WITH CHECK ADD  CONSTRAINT FK_ServicesCountries_Countries_CountryId FOREIGN KEY(CountryId)
REFERENCES Countries (CountryId)
ON DELETE CASCADE


ALTER TABLE ServicesCountries CHECK CONSTRAINT FK_ServicesCountries_Countries_CountryId


ALTER TABLE ServicesCountries  WITH CHECK ADD  CONSTRAINT FK_ServicesCountries_Services_ServiceId FOREIGN KEY(ServiceId)
REFERENCES Services (ServiceId)
ON DELETE CASCADE


ALTER TABLE ServicesCountries CHECK CONSTRAINT FK_ServicesCountries_Services_ServiceId