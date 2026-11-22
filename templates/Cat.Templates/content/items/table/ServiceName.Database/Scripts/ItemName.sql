-- The table ItemName. One file per table. Keep it in step with the entity and its mapping, because nothing compares the two.
-- Run the scripts by hand, see the readme.
CREATE TABLE IF NOT EXISTS "ItemName"
(
    "Id"         uuid    NOT NULL CONSTRAINT "PK_ItemName" PRIMARY KEY,
    "SequenceId" integer GENERATED ALWAYS AS IDENTITY NOT NULL
);
