using System;
using System.Collections.Generic;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.Contracts.ServiceRequests;

/// <summary>
/// Gets the current price of several books in one call.
/// Fails when a book does not exist or has no price.
/// </summary>
public record BookPriceListRequest(Guid[] BookIds) : ICatServiceRequest<IList<BookPriceModel>>;
