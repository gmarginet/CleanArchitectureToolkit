using System;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>Cancels an order of the current user.</summary>
public record CancelOrderRequest(Guid OrderId) : ICatServiceRequest;
