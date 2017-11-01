
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/01/2017 18:48:38
-- Generated from EDMX file: C:\Users\Deol\source\repos\JunkOutDB\JunkOutDBModel\JunkoutDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JunkoutDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerAddress_Address]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Address];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerAddress_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerAddress] DROP CONSTRAINT [FK_CustomerAddress_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderBin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderBin];
GO
IF OBJECT_ID(N'[dbo].[FK_TransferStationExpense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransferStations] DROP CONSTRAINT [FK_TransferStationExpense];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderInvoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderInvoice];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerOrder_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerOrder] DROP CONSTRAINT [FK_CustomerOrder_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerOrder_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerOrder] DROP CONSTRAINT [FK_CustomerOrder_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderTransferStation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderTransferStation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Bins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bins];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[TransferStations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransferStations];
GO
IF OBJECT_ID(N'[dbo].[CustomerAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerAddress];
GO
IF OBJECT_ID(N'[dbo].[CustomerOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerOrder];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StreetAddress] nvarchar(max)  NOT NULL,
    [AptNum] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL,
    [Province] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [AddressType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bins'
CREATE TABLE [dbo].[Bins] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BinSize] nvarchar(max)  NOT NULL,
    [FlatRate] float  NOT NULL,
    [MinTonnageAwarded] float  NOT NULL,
    [MaxRentalDuration] float  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CompanyName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DisposalCost] nvarchar(max)  NOT NULL,
    [Distance] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [HST] float  NOT NULL,
    [FuelSurcharge] float  NULL,
    [SubTotal] float  NOT NULL,
    [OverWeight] float  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [JobType] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] time  NOT NULL,
    [SourceOfOrdering] nvarchar(max)  NOT NULL,
    [HearingSource] nvarchar(max)  NOT NULL,
    [OrderNotes] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Bin_ID] int  NOT NULL,
    [Invoice_ID] int  NULL,
    [TransferStation_ID] int  NULL
);
GO

-- Creating table 'TransferStations'
CREATE TABLE [dbo].[TransferStations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StreetAddress] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [HoursOfOperation] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [Rate] nvarchar(max)  NOT NULL,
    [Term] nvarchar(max)  NOT NULL,
    [Expen_ID] int  NULL
);
GO

-- Creating table 'CustomerAddress'
CREATE TABLE [dbo].[CustomerAddress] (
    [Addresses_ID] int  NOT NULL,
    [Customers_ID] int  NOT NULL
);
GO

-- Creating table 'CustomerOrder'
CREATE TABLE [dbo].[CustomerOrder] (
    [Customers_ID] int  NOT NULL,
    [Orders_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Bins'
ALTER TABLE [dbo].[Bins]
ADD CONSTRAINT [PK_Bins]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TransferStations'
ALTER TABLE [dbo].[TransferStations]
ADD CONSTRAINT [PK_TransferStations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Addresses_ID], [Customers_ID] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [PK_CustomerAddress]
    PRIMARY KEY CLUSTERED ([Addresses_ID], [Customers_ID] ASC);
GO

-- Creating primary key on [Customers_ID], [Orders_ID] in table 'CustomerOrder'
ALTER TABLE [dbo].[CustomerOrder]
ADD CONSTRAINT [PK_CustomerOrder]
    PRIMARY KEY CLUSTERED ([Customers_ID], [Orders_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Addresses_ID] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [FK_CustomerAddress_Address]
    FOREIGN KEY ([Addresses_ID])
    REFERENCES [dbo].[Addresses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Customers_ID] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [FK_CustomerAddress_Customer]
    FOREIGN KEY ([Customers_ID])
    REFERENCES [dbo].[Customers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAddress_Customer'
CREATE INDEX [IX_FK_CustomerAddress_Customer]
ON [dbo].[CustomerAddress]
    ([Customers_ID]);
GO

-- Creating foreign key on [Customers_ID] in table 'CustomerOrder'
ALTER TABLE [dbo].[CustomerOrder]
ADD CONSTRAINT [FK_CustomerOrder_Customer]
    FOREIGN KEY ([Customers_ID])
    REFERENCES [dbo].[Customers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Orders_ID] in table 'CustomerOrder'
ALTER TABLE [dbo].[CustomerOrder]
ADD CONSTRAINT [FK_CustomerOrder_Order]
    FOREIGN KEY ([Orders_ID])
    REFERENCES [dbo].[Orders]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder_Order'
CREATE INDEX [IX_FK_CustomerOrder_Order]
ON [dbo].[CustomerOrder]
    ([Orders_ID]);
GO

-- Creating foreign key on [Bin_ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderBin]
    FOREIGN KEY ([Bin_ID])
    REFERENCES [dbo].[Bins]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderBin'
CREATE INDEX [IX_FK_OrderBin]
ON [dbo].[Orders]
    ([Bin_ID]);
GO

-- Creating foreign key on [Invoice_ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_InvoiceOrder]
    FOREIGN KEY ([Invoice_ID])
    REFERENCES [dbo].[Invoices]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceOrder'
CREATE INDEX [IX_FK_InvoiceOrder]
ON [dbo].[Orders]
    ([Invoice_ID]);
GO

-- Creating foreign key on [TransferStation_ID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderTransferStation]
    FOREIGN KEY ([TransferStation_ID])
    REFERENCES [dbo].[TransferStations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderTransferStation'
CREATE INDEX [IX_FK_OrderTransferStation]
ON [dbo].[Orders]
    ([TransferStation_ID]);
GO

-- Creating foreign key on [Expen_ID] in table 'TransferStations'
ALTER TABLE [dbo].[TransferStations]
ADD CONSTRAINT [FK_TransferStationExpens]
    FOREIGN KEY ([Expen_ID])
    REFERENCES [dbo].[Expenses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransferStationExpens'
CREATE INDEX [IX_FK_TransferStationExpens]
ON [dbo].[TransferStations]
    ([Expen_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------