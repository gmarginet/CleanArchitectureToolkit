using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cat.Demo.NotificationService.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "public");

        migrationBuilder.CreateTable(
            name: "SentMail",
            schema: "public",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                Kind = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Recipient = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: false),
                Subject = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                SequenceId = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SentMail", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_SentMail_OrderId_Kind",
            schema: "public",
            table: "SentMail",
            columns: new[] { "OrderId", "Kind" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_SentMail_SequenceId",
            schema: "public",
            table: "SentMail",
            column: "SequenceId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "SentMail",
            schema: "public");
    }
}
