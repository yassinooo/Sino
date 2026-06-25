-- CreateDatabase.sql
-- Run this script on your SQL Server if you prefer manual DB creation.
CREATE DATABASE FishingDb;
GO
USE FishingDb;
GO

CREATE TABLE Buyers (
    BuyerID INT IDENTITY(1,1) PRIMARY KEY,
    BuyerName NVARCHAR(200),
    BuyerAddress NVARCHAR(500),
    BuyerPhone NVARCHAR(50),
    DateRegistered DATETIME NULL,
    IsCreditEnabled BIT DEFAULT 0,
    CreditLimit DECIMAL(18,2) NULL,
    CurrentBalance DECIMAL(18,2) NULL
);

CREATE TABLE Fishermen (
    FishermanID INT IDENTITY(1,1) PRIMARY KEY,
    FishermanName NVARCHAR(200),
    FishermanNote NVARCHAR(1000)
);

CREATE TABLE Auctioneers (
    AuctioneerID INT IDENTITY(1,1) PRIMARY KEY,
    AuctioneerName NVARCHAR(200),
    AuctioneerNote NVARCHAR(1000)
);

CREATE TABLE Writers (
    WriterID INT IDENTITY(1,1) PRIMARY KEY,
    WriterName NVARCHAR(200),
    WriterNote NVARCHAR(1000)
);

CREATE TABLE FishingTypes (
    FishingTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(200)
);

CREATE TABLE Bids (
    BidID INT IDENTITY(1,1) PRIMARY KEY,
    FishermanID INT NOT NULL,
    AuctioneerID INT NOT NULL,
    WriterID INT NOT NULL,
    BidAmount DECIMAL(18,2) NOT NULL,
    BidDate DATETIME NOT NULL,
    BidTax DECIMAL(18,2) NULL,
    BidTaxAmount DECIMAL(18,2) NULL,
    BidNumber NVARCHAR(100) NULL,
    Notes NVARCHAR(2000) NULL
);

CREATE TABLE Catches (
    CatchID INT IDENTITY(1,1) PRIMARY KEY,
    BidID INT NOT NULL,
    BuyerID INT NOT NULL,
    FishingTypeID INT NOT NULL,
    CatchDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18,2),
    UnitPrice DECIMAL(18,2),
    Tax DECIMAL(18,2),
    TotalTaxAmount DECIMAL(18,2),
    WeightKG DECIMAL(18,2),
    Quantity INT
);

ALTER TABLE Bids ADD CONSTRAINT FK_Bids_Fishermen FOREIGN KEY (FishermanID) REFERENCES Fishermen(FishermanID);
ALTER TABLE Bids ADD CONSTRAINT FK_Bids_Auctioneers FOREIGN KEY (AuctioneerID) REFERENCES Auctioneers(AuctioneerID);
ALTER TABLE Bids ADD CONSTRAINT FK_Bids_Writers FOREIGN KEY (WriterID) REFERENCES Writers(WriterID);

ALTER TABLE Catches ADD CONSTRAINT FK_Catches_Bids FOREIGN KEY (BidID) REFERENCES Bids(BidID);
ALTER TABLE Catches ADD CONSTRAINT FK_Catches_Buyers FOREIGN KEY (BuyerID) REFERENCES Buyers(BuyerID);
ALTER TABLE Catches ADD CONSTRAINT FK_Catches_FishingTypes FOREIGN KEY (FishingTypeID) REFERENCES FishingTypes(FishingTypeID);
