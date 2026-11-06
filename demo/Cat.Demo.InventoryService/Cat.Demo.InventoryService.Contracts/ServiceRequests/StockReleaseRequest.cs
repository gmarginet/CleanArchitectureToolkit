using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.Contracts.ServiceRequests;

/// <summary>Gives the stock of an order back. An order without a reservation changes nothing.</summary>
public record StockReleaseRequest(string OrderNumber) : ICatServiceRequest;
