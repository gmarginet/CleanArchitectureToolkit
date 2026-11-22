-- The table of the example entity. One file per table. Replace it with the tables of the service.
CREATE TABLE dbo.ExampleItem
(
    Id         uniqueidentifier NOT NULL CONSTRAINT PK_ExampleItem PRIMARY KEY NONCLUSTERED,
    SequenceId int IDENTITY(1, 1) NOT NULL,
    Name       nvarchar(100)    NOT NULL
);
GO

CREATE UNIQUE CLUSTERED INDEX IX_ExampleItem_SequenceId ON dbo.ExampleItem (SequenceId);
