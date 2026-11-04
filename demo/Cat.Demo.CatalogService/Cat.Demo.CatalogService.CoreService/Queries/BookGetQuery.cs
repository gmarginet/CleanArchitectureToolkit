using System;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Queries;

public record BookGetQuery(Guid BookId) : ICatQuery<Book>;
