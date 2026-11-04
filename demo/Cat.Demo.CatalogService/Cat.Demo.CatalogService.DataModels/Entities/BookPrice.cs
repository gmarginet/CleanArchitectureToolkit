using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.CatalogService.DataModels.Entities;

public class BookPrice : CatTemporalEntityBase
{
    public Guid BookId { get; set; }
    public decimal Amount { get; set; }
}
