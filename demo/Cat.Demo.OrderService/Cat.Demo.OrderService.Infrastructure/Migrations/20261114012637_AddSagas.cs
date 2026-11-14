using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Demo.OrderService.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddSagas : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CatInbox",
            columns: table => new
            {
                MessageId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                MessageType = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                HandledAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CatInbox", x => x.MessageId);
            });

        migrationBuilder.CreateTable(
            name: "CatSagas",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                WorkflowType = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                WorkflowVersion = table.Column<int>(type: "int", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Checkpoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Waits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                Version = table.Column<long>(type: "bigint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CatSagas", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_CatSagas_Status",
            table: "CatSagas",
            column: "Status");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CatInbox");

        migrationBuilder.DropTable(
            name: "CatSagas");
    }
}
