using System;

namespace Cat.Demo.CatalogService.Contracts.Models;

public class BookModel
{
    public Guid Id { get; set; }
    public required string Isbn { get; set; }
    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }

    /// <summary>The current price in euro. Empty when the book has no price yet.</summary>
    public decimal? Price { get; set; }
}
