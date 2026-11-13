using System;
using System.Collections.Generic;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Demo.InventoryService.CoreService;

/// <summary>Turns a change of the <c>StockItem</c> table into the <see cref="StockChanged"/> message.</summary>
public static class StockChangeMapper
{
    /// <summary>The capture instance of the stock table. It is <c>schema_table</c>, as <c>sys.sp_cdc_enable_table</c> names it.</summary>
    public const string CaptureInstance = "dbo_StockItem";

    /// <summary>Maps the change. An insert has no old row, and a delete has no new row, so the quantity on that side is empty.</summary>
    /// <param name="change">The change of the stock table.</param>
    /// <param name="limit">The low stock limit to put in the message.</param>
    public static StockChanged Map(CatChange change, int limit)
    {
        var row = change.New ?? change.Old ?? change.Keys;

        return new StockChanged
        {
            Isbn = Convert.ToString(row["Isbn"]) ?? string.Empty,
            WarehouseId = Convert.ToInt32(row["WarehouseId"]),
            OldQuantity = Quantity(change.Old),
            NewQuantity = Quantity(change.New),
            Limit = limit
        };
    }

    private static int? Quantity(IReadOnlyDictionary<string, object?>? row)
    {
        return row is null ? null : Convert.ToInt32(row["QuantityOnHand"]);
    }
}
