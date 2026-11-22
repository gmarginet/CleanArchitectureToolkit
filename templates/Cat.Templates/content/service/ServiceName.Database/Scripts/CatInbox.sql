-- The table of the inbox (Cat.Inbox.EFCore). It remembers the messages that are handled, so a message that arrives twice runs once.
-- It must match the model of AddCatInbox(). Neither EF Core nor a build compares the two, so follow it by hand.
CREATE TABLE IF NOT EXISTS "CatInbox"
(
    "MessageId"   varchar(128)             NOT NULL CONSTRAINT "PK_CatInbox" PRIMARY KEY,
    "MessageType" varchar(260)             NOT NULL,
    "HandledAt"   timestamp with time zone NOT NULL
);
