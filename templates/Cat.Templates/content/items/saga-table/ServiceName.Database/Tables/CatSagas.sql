-- The table of the sagas (Cat.Sagas.EFCore). One row is one saga instance, with its state as JSON. The version is the concurrency token.
-- It must match the model of AddCatSagas(). Neither this build nor EF Core compares the two, so follow it by hand.
CREATE TABLE dbo.CatSagas
(
    Id              uniqueidentifier NOT NULL CONSTRAINT PK_CatSagas PRIMARY KEY,
    WorkflowType    nvarchar(260)    NOT NULL,
    WorkflowVersion int              NOT NULL,
    Status          int              NOT NULL,
    State           nvarchar(max)    NOT NULL,
    Checkpoint      nvarchar(max)    NULL,
    Waits           nvarchar(max)    NULL,
    CreatedAt       datetimeoffset   NOT NULL,
    UpdatedAt       datetimeoffset   NOT NULL,
    Version         bigint           NOT NULL
);
GO

CREATE INDEX IX_CatSagas_Status ON dbo.CatSagas (Status);
