using System;
using Cat.Demo.OrderService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>Gets one order. A customer only finds their own orders. An admin finds all of them.</summary>
public record OrderGetRequest(Guid OrderId) : ICatServiceRequest<OrderModel>;
