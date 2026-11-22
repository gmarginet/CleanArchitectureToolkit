-- The table of the inbox (Cat.Inbox.EFCore). It remembers the messages that are handled, so a message that arrives twice runs once.
-- It must match the model of AddCatInbox(). Neither this build nor EF Core compares the two, so follow it by hand.
CREATE TABLE dbo.CatInbox
(
    MessageId   nvarchar(128)    NOT NULL CONSTRAINT PK_CatInbox PRIMARY KEY,
    MessageType nvarchar(260)    NOT NULL,
    HandledAt   datetimeoffset   NOT NULL
);
