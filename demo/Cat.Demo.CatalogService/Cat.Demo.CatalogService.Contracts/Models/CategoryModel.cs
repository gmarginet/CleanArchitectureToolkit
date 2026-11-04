using System;

namespace Cat.Demo.CatalogService.Contracts.Models;

public class CategoryModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
