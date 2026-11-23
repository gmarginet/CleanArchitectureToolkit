-- The table of the translations (Cat.Localizations.EFCore). One table serves every translatable entity, so there is no foreign key.
-- It must match the model of AddCatTranslations(). Neither EF Core nor a build compares the two, so follow it by hand.
CREATE TABLE IF NOT EXISTS "Translation"
(
    "Id"         uuid          NOT NULL CONSTRAINT "PK_Translation" PRIMARY KEY,
    "EntityType" varchar(100)  NOT NULL,
    "EntityId"   uuid          NOT NULL,
    "Field"      varchar(100)  NOT NULL,
    "Culture"    varchar(20)   NOT NULL,
    "Text"       varchar(1000) NOT NULL
);

CREATE UNIQUE INDEX IF NOT EXISTS "IX_Translation_EntityType_EntityId_Field_Culture" ON "Translation" ("EntityType", "EntityId", "Field", "Culture");
