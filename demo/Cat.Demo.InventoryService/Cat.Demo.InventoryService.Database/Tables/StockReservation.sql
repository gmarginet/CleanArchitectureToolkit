CREATE TABLE dbo.StockReservation
(
    Id          int IDENTITY(1, 1) NOT NULL CONSTRAINT PK_StockReservation PRIMARY KEY,
    StockItemId int                NOT NULL CONSTRAINT FK_StockReservation_StockItem REFERENCES dbo.StockItem (Id),
    OrderNumber nvarchar(20)       NOT NULL,
    Quantity    int                NOT NULL,
    ReservedAt  datetime2(0)       NOT NULL CONSTRAINT DF_StockReservation_ReservedAt DEFAULT (SYSUTCDATETIME()),
    -- Orders tells Inventory when an order is confirmed. The column is empty until the message arrives.
    ConfirmedAt datetime2(0)       NULL,
    CONSTRAINT CK_StockReservation_Quantity CHECK (Quantity > 0),
    -- One reservation per order and stock item. This is what makes a repeated reserve call safe.
    CONSTRAINT UQ_StockReservation_StockItem_OrderNumber UNIQUE (StockItemId, OrderNumber)
);
