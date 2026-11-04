using System;
using System.Collections.Generic;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.Contracts.ServiceRequests;

public record BookSearchRequest(string? Text, Guid? CategoryId) : ICatServiceRequest<IList<BookModel>>;
