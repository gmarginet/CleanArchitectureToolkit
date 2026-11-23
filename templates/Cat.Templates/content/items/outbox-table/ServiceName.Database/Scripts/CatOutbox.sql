-- The table of the outbox (Cat.Outbox.EFCore). A message is stored here with the data change and sent to the bus after the commit.
-- It must match the model of AddCatOutbox(). Neither EF Core nor a build compares the two, so follow it by hand.
CREATE TABLE IF NOT EXISTS "CatOutbox"
(
    "Id"             uuid                     NOT NULL CONSTRAINT "PK_CatOutbox" PRIMARY KEY,
    "CreatedAt"      timestamp with time zone NOT NULL,
    "SentAt"         timestamp with time zone NULL,
    "EntityName"     varchar(260)             NOT NULL,
    "Kind"           integer                  NOT NULL,
    "Body"           bytea                    NOT NULL,
    "ContentType"    varchar(100)             NOT NULL,
    "MessageId"      uuid                     NOT NULL,
    "CorrelationId"  uuid                     NOT NULL,
    "Subject"        varchar(260)             NOT NULL,
    "SessionId"      varchar(128)             NULL,
    "ScheduledAt"    timestamp with time zone NULL,
    "PropertiesJson" text                     NULL,
    "TraceParent"    varchar(55)              NULL
);

CREATE INDEX IF NOT EXISTS "IX_CatOutbox_SentAt_CreatedAt" ON "CatOutbox" ("SentAt", "CreatedAt");
