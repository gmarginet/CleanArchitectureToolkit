using System;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.Queries.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Queries;

/// <summary>Reads one category with its default name and its Dutch translation, for the admin.</summary>
public record CategoryGetQuery(Guid CategoryId) : ICatQuery<CategoryEditModel>;
