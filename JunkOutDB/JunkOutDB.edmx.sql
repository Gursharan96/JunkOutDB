
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/10/2017 10:36:23
-- Generated from EDMX file: D:\sheridan\Semester6\Capstone\Updated\JunkOutDB\JunkOutDB\JunkOutDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBJunkOut];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CompanyName] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JobType] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] time  NOT NULL,
    [SourceOfOrdering] nvarchar(max)  NOT NULL,
    [HearingSource] nvarchar(max)  NOT NULL,
    [OrderNotes] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Invoice_Id] int  NOT NULL,
    [Bin_Id] int  NOT NULL,
    [TransferStation_Id] int  NOT NULL
);
GO

-- Creating table 'Bins'
CREATE TABLE [dbo].[Bins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BinSize] nvarchar(max)  NOT NULL,
    [FlatRate] float  NOT NULL,
    [MinTonnageAwarded] float  NOT NULL,
    [MaxRentalDuration] float  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HST] float  NOT NULL,
    [FuelSurcharge] float  NULL,
    [SubTotal] float  NOT NULL,
    [OverWeight] float  NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DisposalCost] nvarchar(max)  NOT NULL,
    [Distance] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TransferStations'
CREATE TABLE [dbo].[TransferStations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StreetAddress] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [HoursOfOperations] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Rate] nvarchar(max)  NOT NULL,
    [Terms] nvarchar(max)  NOT NULL,
    [Expense_Id] int  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StreetAddress] nvarchar(max)  NOT NULL,
    [AptNum] nvarchar(max)  NULL,
    [City] nvarchar(max)  NOT NULL,
    [Province] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL,
    [AddressType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerOrder'
CREATE TABLE [dbo].[CustomerOrder] (
    [Customers_Id] int  NOT NULL,
    [Orders_Id] int  NOT NULL
);
GO

-- Creating table 'CustomerAddress'
CREATE TABLE [dbo].[CustomerAddress] (
    [Customers_Id] int  NOT NULL,
    [Addresses_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bins'
ALTER TABLE [dbo].[Bins]
ADD CONSTRAINT [PK_Bins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransferStations'
ALTER TABLE [dbo].[TransferStations]
ADD CONSTRAINT [PK_TransferStations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Customers_Id], [Orders_Id] in table 'CustomerOrder'
ALTER TABLE [dbo].[CustomerOrder]
ADD CONSTRAINT [PK_CustomerOrder]
    PRIMARY KEY CLUSTERED ([Customers_Id], [Orders_Id] ASC);
GO

-- Creating primary key on [Customers_Id], [Addresses_Id] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [PK_CustomerAddress]
    PRIMARY KEY CLUSTERED ([Customers_Id], [Addresses_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customers_Id] in table 'CustomerOrder'
ALTER TABLE [dbo].[CustomerOrder]
ADD CONSTRAINT [FK_CustomerOrder_Customer]
    FOREIGN KEY ([Customers_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Orders_Id] in table 'CustomerOrder'
ALTER TABLE [dbo].[CustomerOrder]
ADD CONSTRAINT [FK_CustomerOrder_Order]
    FOREIGN KEY ([Orders_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder_Order'
CREATE INDEX [IX_FK_CustomerOrder_Order]
ON [dbo].[CustomerOrder]
    ([Orders_Id]);
GO

-- Creating foreign key on [Invoice_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderInvoice]
    FOREIGN KEY ([Invoice_Id])
    REFERENCES [dbo].[Invoices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderInvoice'
CREATE INDEX [IX_FK_OrderInvoice]
ON [dbo].[Orders]
    ([Invoice_Id]);
GO

-- Creating foreign key on [Customers_Id] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [FK_CustomerAddress_Customer]
    FOREIGN KEY ([Customers_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Addresses_Id] in table 'CustomerAddress'
ALTER TABLE [dbo].[CustomerAddress]
ADD CONSTRAINT [FK_CustomerAddress_Address]
    FOREIGN KEY ([Addresses_Id])
    REFERENCES [dbo].[Addresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAddress_Address'
CREATE INDEX [IX_FK_CustomerAddress_Address]
ON [dbo].[CustomerAddress]
    ([Addresses_Id]);
GO

-- Creating foreign key on [Bin_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderBin]
    FOREIGN KEY ([Bin_Id])
    REFERENCES [dbo].[Bins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderBin'
CREATE INDEX [IX_FK_OrderBin]
ON [dbo].[Orders]
    ([Bin_Id]);
GO

-- Creating foreign key on [TransferStation_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderTransferStation]
    FOREIGN KEY ([TransferStation_Id])
    REFERENCES [dbo].[TransferStations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderTransferStation'
CREATE INDEX [IX_FK_OrderTransferStation]
ON [dbo].[Orders]
    ([TransferStation_Id]);
GO

-- Creating foreign key on [Expense_Id] in table 'TransferStations'
ALTER TABLE [dbo].[TransferStations]
ADD CONSTRAINT [FK_TransferStationExpense]
    FOREIGN KEY ([Expense_Id])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransferStationExpense'
CREATE INDEX [IX_FK_TransferStationExpense]
ON [dbo].[TransferStations]
    ([Expense_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------