using System;
using Cat.Demo.CatalogService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.Contracts.ServiceRequests;

public record CategoryGetRequest(Guid CategoryId) : ICatServiceRequest<CategoryEditModel>;
