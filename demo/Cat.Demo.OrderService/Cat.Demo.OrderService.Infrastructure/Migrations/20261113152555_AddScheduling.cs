using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Demo.OrderService.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddScheduling : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CatJobRun",
            columns: table => new
            {
                JobName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                DueTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                ErrorCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Attempts = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CatJobRun", x => new { x.JobName, x.DueTime });
            });

        migrationBuilder.CreateIndex(
            name: "IX_CatJobRun_JobName_Status_StartedAt",
            table: "CatJobRun",
            columns: new[] { "JobName", "Status", "StartedAt" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CatJobRun");
    }
}
