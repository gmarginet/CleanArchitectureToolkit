using System;
using Cat.EFCore.Entities.SqlServer;

namespace Cat.Demo.CatalogService.DataModels.Entities;

public class BookPrice : CatTemporalEntityBase
{
    public Guid BookId { get; set; }
    public decimal Amount { get; set; }

    /// <summary>The id of the user who set this price. A price set by a job holds the name of the system user.</summary>
    public string LastUpdatedBy { get; set; } = string.Empty;
}
