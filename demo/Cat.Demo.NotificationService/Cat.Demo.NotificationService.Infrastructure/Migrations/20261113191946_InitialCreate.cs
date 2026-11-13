using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Demo.NotificationService.Infrastructure.Migrations;

/// <inheritdoc />
public partial class _20261113191946_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "dbo");

        migrationBuilder.CreateTable(
            name: "SentMail",
            schema: "dbo",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Kind = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Recipient = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                SequenceId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SentMail", x => x.Id)
                    .Annotation("SqlServer:Clustered", false);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SentMail_OrderId_Kind",
            schema: "dbo",
            table: "SentMail",
            columns: new[] { "OrderId", "Kind" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_SentMail_SequenceId",
            schema: "dbo",
            table: "SentMail",
            column: "SequenceId",
            unique: true)
            .Annotation("SqlServer:Clustered", true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SentMail",
            schema: "dbo");
    }
}
