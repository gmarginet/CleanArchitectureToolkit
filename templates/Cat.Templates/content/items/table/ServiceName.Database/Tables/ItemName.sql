-- The table ItemName. One file per table. Keep it in step with the entity and its mapping, because nothing compares the two.
CREATE TABLE dbo.ItemName
(
    Id         uniqueidentifier NOT NULL CONSTRAINT PK_ItemName PRIMARY KEY NONCLUSTERED,
    SequenceId int IDENTITY(1, 1) NOT NULL
);
GO

CREATE UNIQUE CLUSTERED INDEX IX_ItemName_SequenceId ON dbo.ItemName (SequenceId);
