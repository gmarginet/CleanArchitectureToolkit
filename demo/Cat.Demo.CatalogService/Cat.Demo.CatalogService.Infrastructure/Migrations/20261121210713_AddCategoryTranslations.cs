using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Demo.CatalogService.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddCategoryTranslations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Translation",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                EntityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Field = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Culture = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Translation", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Translation_EntityType_EntityId_Field_Culture",
            table: "Translation",
            columns: new[] { "EntityType", "EntityId", "Field", "Culture" },
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Translation");
    }
}
