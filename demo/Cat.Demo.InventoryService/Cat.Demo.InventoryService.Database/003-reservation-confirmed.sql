-- Orders tells Inventory when an order is confirmed. The reservation then gets the time of the confirmation.
-- The column is empty until the message arrives. Setting it twice changes nothing.
IF COL_LENGTH(N'dbo.StockReservation', N'ConfirmedAt') IS NULL
BEGIN
    ALTER TABLE dbo.StockReservation ADD ConfirmedAt datetime2(0) NULL;
END;
GO
