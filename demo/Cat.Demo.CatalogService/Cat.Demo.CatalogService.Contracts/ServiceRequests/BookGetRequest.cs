using System;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.Contracts.ServiceRequests;

public record BookGetRequest(Guid BookId) : ICatServiceRequest<BookModel>;
