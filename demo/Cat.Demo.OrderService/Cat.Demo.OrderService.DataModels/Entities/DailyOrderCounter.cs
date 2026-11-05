using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.OrderService.DataModels.Entities;

/// <summary>Holds the last order counter handed out on one UTC day.</summary>
public class DailyOrderCounter : CatEntityBase
{
    /// <summary>The UTC day. Unique.</summary>
    public DateOnly Date { get; set; }

    /// <summary>The last counter handed out that day. The counter of the first order is 1.</summary>
    public int LastNumber { get; set; }
}
