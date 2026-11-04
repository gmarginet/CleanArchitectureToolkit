using Cat.Commands.Abstractions;
using Cat.Demo.CatalogService.DataModels.Entities;

namespace Cat.Demo.CatalogService.CoreService.Commands;

/// <summary>Saves a book. A null <paramref name="Price"/> leaves the current price as it is.</summary>
public record BookSaveCommand(Book Book, decimal? Price) : ICatCommand;
