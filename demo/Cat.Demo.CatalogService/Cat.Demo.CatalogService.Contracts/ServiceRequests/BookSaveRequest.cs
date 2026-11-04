using Cat.Demo.CatalogService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.CatalogService.Contracts.ServiceRequests;

public record BookSaveRequest(BookModel Book) : ICatServiceRequest;
