-- The table of the example entity. One file per table. Replace it with the tables of the service.
-- Run the scripts by hand, see the readme.
CREATE TABLE IF NOT EXISTS "ExampleItem"
(
    "Id"         uuid         NOT NULL CONSTRAINT "PK_ExampleItem" PRIMARY KEY,
    "SequenceId" integer GENERATED ALWAYS AS IDENTITY NOT NULL,
    "Name"       varchar(100) NOT NULL
);
