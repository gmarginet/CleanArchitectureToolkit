using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cat.Demo.OrderService.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddOrderShipping : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateTime>(
            name: "ConfirmedAt",
            schema: "dbo",
            table: "Order",
            type: "datetime2",
            nullable: true);

        // An order that is Confirmed already gets its placed time as the confirmed time, so it ships like every other Confirmed order.
        // The id is the one of OrderStatuses.ConfirmedId.
        migrationBuilder.Sql(
            "UPDATE [dbo].[Order] SET [ConfirmedAt] = [PlacedAt] WHERE [OrderStatusId] = '0f1c2a10-0000-4000-8000-000000000002'");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ConfirmedAt",
            schema: "dbo",
            table: "Order");
    }
}
