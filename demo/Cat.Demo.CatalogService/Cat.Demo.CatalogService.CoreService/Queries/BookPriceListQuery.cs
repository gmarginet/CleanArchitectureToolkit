using System;
using System.Collections.Generic;
using Cat.Queries.Abstractions;

namespace Cat.Demo.CatalogService.CoreService.Queries;

public record BookPriceListQuery(IList<Guid> BookIds) : ICatQuery<IList<BookPriceInfo>>;
