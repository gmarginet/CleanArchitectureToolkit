using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>
/// Cancels every order that has stayed Pending for more than 15 minutes. The stock of those orders goes back.
/// The scheduler runs it every few minutes. You can run it at any time, and more than once.
/// </summary>
public record CancelStuckOrdersRequest : ICatServiceRequest;
