SELECT o.Id,
       o.OrderNumber,
       s.Code AS Status,
       o.PlacedAt,
       o.Total
FROM dbo.[Order] o
    JOIN dbo.OrderStatus s ON s.Id = o.OrderStatusId
    JOIN dbo.Customer c ON c.Id = o.CustomerId
WHERE @CustomerExternalId IS NULL OR c.ExternalId = @CustomerExternalId
ORDER BY o.PlacedAt DESC
