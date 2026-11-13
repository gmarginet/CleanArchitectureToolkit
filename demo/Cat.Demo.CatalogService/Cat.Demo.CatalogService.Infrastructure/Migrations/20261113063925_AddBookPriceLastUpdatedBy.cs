using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Demo.CatalogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookPriceLastUpdatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedBy",
                schema: "dbo",
                table: "BookPrice",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                schema: "dbo",
                table: "BookPrice");
        }
    }
}
