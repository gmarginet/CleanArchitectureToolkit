-- The table of the sagas (Cat.Sagas.EFCore). One row is one saga instance, with its state as JSON. The version is the concurrency token.
-- It must match the model of AddCatSagas(). Neither EF Core nor a build compares the two, so follow it by hand.
CREATE TABLE IF NOT EXISTS "CatSagas"
(
    "Id"              uuid                     NOT NULL CONSTRAINT "PK_CatSagas" PRIMARY KEY,
    "WorkflowType"    varchar(260)             NOT NULL,
    "WorkflowVersion" integer                  NOT NULL,
    "Status"          integer                  NOT NULL,
    "State"           text                     NOT NULL,
    "Checkpoint"      text                     NULL,
    "Waits"           text                     NULL,
    "CreatedAt"       timestamp with time zone NOT NULL,
    "UpdatedAt"       timestamp with time zone NOT NULL,
    "Version"         bigint                   NOT NULL
);

CREATE INDEX IF NOT EXISTS "IX_CatSagas_Status" ON "CatSagas" ("Status");
