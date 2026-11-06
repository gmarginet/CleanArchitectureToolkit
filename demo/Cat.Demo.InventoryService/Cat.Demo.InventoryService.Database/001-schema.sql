-- The schema of the inventory database. The scripts can run again: they only create what is missing.
-- A book is known by its ISBN and an order by its order number. There is no foreign key to another service.

IF OBJECT_ID(N'dbo.Warehouse', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Warehouse
    (
        Id       int IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Warehouse PRIMARY KEY,
        Name     nvarchar(100)      NOT NULL,
        Location nvarchar(100)      NOT NULL
    );
END;
GO

IF OBJECT_ID(N'dbo.StockItem', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.StockItem
    (
        Id             int IDENTITY(1, 1) NOT NULL CONSTRAINT PK_StockItem PRIMARY KEY,
        WarehouseId    int                NOT NULL CONSTRAINT FK_StockItem_Warehouse REFERENCES dbo.Warehouse (Id),
        Isbn           nvarchar(13)       NOT NULL,
        QuantityOnHand int                NOT NULL,
        -- Stock never goes below zero, whatever the code does.
        CONSTRAINT CK_StockItem_QuantityOnHand CHECK (QuantityOnHand >= 0),
        CONSTRAINT UQ_StockItem_Warehouse_Isbn UNIQUE (WarehouseId, Isbn)
    );
END;
GO

IF OBJECT_ID(N'dbo.StockReservation', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.StockReservation
    (
        Id          int IDENTITY(1, 1) NOT NULL CONSTRAINT PK_StockReservation PRIMARY KEY,
        StockItemId int                NOT NULL CONSTRAINT FK_StockReservation_StockItem REFERENCES dbo.StockItem (Id),
        OrderNumber nvarchar(20)       NOT NULL,
        Quantity    int                NOT NULL,
        ReservedAt  datetime2(0)       NOT NULL CONSTRAINT DF_StockReservation_ReservedAt DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT CK_StockReservation_Quantity CHECK (Quantity > 0),
        -- One reservation per order and stock item. This is what makes a repeated reserve call safe.
        CONSTRAINT UQ_StockReservation_StockItem_OrderNumber UNIQUE (StockItemId, OrderNumber)
    );
END;
GO
