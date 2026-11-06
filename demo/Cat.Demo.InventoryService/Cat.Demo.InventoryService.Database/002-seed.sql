-- The seed data of the demo: one warehouse and 50 copies of each book of the Catalog seed data.
-- The ISBNs must match the books of the Catalog service. The script only adds what is missing.

IF NOT EXISTS (SELECT 1 FROM dbo.Warehouse)
BEGIN
    INSERT INTO dbo.Warehouse (Name, Location) VALUES (N'Main warehouse', N'Amsterdam');
END;
GO

INSERT INTO dbo.StockItem (WarehouseId, Isbn, QuantityOnHand)
SELECT w.Id, seed.Isbn, 50
FROM dbo.Warehouse AS w
CROSS JOIN (VALUES
    (N'9780141036144'),
    (N'9780261103573'),
    (N'9780553380163'),
    (N'9780198788607'),
    (N'9780099590088'),
    (N'9780132350884'),
    (N'9780134494166')
) AS seed (Isbn)
WHERE w.Name = N'Main warehouse'
  AND NOT EXISTS (SELECT 1 FROM dbo.StockItem AS s WHERE s.WarehouseId = w.Id AND s.Isbn = seed.Isbn);
GO
