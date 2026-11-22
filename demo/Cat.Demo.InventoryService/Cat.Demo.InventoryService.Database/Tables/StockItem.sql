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
