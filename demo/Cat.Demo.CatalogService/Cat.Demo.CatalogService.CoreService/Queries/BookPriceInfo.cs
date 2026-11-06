using System;

namespace Cat.Demo.CatalogService.CoreService.Queries;

/// <summary>The current price of a book, with the ISBN that other services know the book by.</summary>
public record BookPriceInfo(Guid BookId, string Isbn, decimal Amount);