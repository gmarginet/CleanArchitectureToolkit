using System.Collections.Generic;
using Cat.Demo.CatalogService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Queries;

public record CategoryGetListQuery : ICatQuery<IList<Category>>;
