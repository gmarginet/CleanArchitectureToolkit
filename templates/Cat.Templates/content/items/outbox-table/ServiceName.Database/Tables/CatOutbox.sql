-- The table of the outbox (Cat.Outbox.EFCore). A message is stored here with the data change and sent to the bus after the commit.
-- It must match the model of AddCatOutbox(). Neither this build nor EF Core compares the two, so follow it by hand.
CREATE TABLE dbo.CatOutbox
(
    Id             uniqueidentifier NOT NULL CONSTRAINT PK_CatOutbox PRIMARY KEY,
    CreatedAt      datetimeoffset   NOT NULL,
    SentAt         datetimeoffset   NULL,
    EntityName     nvarchar(260)    NOT NULL,
    Kind           int              NOT NULL,
    Body           varbinary(max)   NOT NULL,
    ContentType    nvarchar(100)    NOT NULL,
    MessageId      uniqueidentifier NOT NULL,
    CorrelationId  uniqueidentifier NOT NULL,
    Subject        nvarchar(260)    NOT NULL,
    SessionId      nvarchar(128)    NULL,
    ScheduledAt    datetimeoffset   NULL,
    PropertiesJson nvarchar(max)    NULL,
    TraceParent    nvarchar(55)     NULL
);
GO

CREATE INDEX IX_CatOutbox_SentAt_CreatedAt ON dbo.CatOutbox (SentAt, CreatedAt);
