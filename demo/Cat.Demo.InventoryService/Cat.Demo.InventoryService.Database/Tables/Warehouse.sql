-- A book is known by its ISBN and an order by its order number. There is no foreign key to another service.
CREATE TABLE dbo.Warehouse
(
    Id       int IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Warehouse PRIMARY KEY,
    Name     nvarchar(100)      NOT NULL,
    Location nvarchar(100)      NOT NULL
);
