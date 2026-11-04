using System;
using Cat.Queries.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Queries;

/// <summary>Checks whether a book with the ISBN exists. Pass the id of the book being saved to leave that book out.</summary>
public record CheckIsbnExistsQuery(string Isbn, Guid? ExcludeBookId) : ICatQuery<bool>;
