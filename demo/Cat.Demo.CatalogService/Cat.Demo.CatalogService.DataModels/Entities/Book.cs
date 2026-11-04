using System;
using Cat.EFCore.Entities;

namespace Cat.Demo.CatalogService.DataModels.Entities;

public class Book : CatEntityBase
{
    public required string Isbn { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public BookPrice? BookPrice { get; set; }
}
