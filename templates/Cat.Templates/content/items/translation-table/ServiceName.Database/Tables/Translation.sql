-- The table of the translations (Cat.Localizations.EFCore). One table serves every translatable entity, so there is no foreign key.
-- It must match the model of AddCatTranslations(). Neither this build nor EF Core compares the two, so follow it by hand.
CREATE TABLE dbo.Translation
(
    Id         uniqueidentifier NOT NULL CONSTRAINT PK_Translation PRIMARY KEY,
    EntityType nvarchar(100)    NOT NULL,
    EntityId   uniqueidentifier NOT NULL,
    Field      nvarchar(100)    NOT NULL,
    Culture    nvarchar(20)     NOT NULL,
    Text       nvarchar(1000)   NOT NULL
);
GO

CREATE UNIQUE INDEX IX_Translation_EntityType_EntityId_Field_Culture ON dbo.Translation (EntityType, EntityId, Field, Culture);
