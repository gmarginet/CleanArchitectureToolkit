using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>
/// Ships every order that has been Confirmed for at least 5 minutes. A shipped order can no longer be cancelled.
/// The scheduler runs it every minute. You can run it at any time, and more than once.
/// </summary>
public record ShipConfirmedOrdersRequest : ICatServiceRequest;
