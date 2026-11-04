using System;
using System.Collections.Generic;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Queries;

public record BookSearchQuery(string? Text, Guid? CategoryId) : ICatQuery<IList<Book>>;
