using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Commands;

/// <summary>Saves a category and its Dutch name. An empty <paramref name="Id"/> creates a new category. An empty <paramref name="NameNl"/> removes the translation.</summary>
public record CategorySaveCommand(Guid Id, string Name, string? NameNl) : ICatCommand;
