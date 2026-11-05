using System;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Queries;

/// <summary>
/// Gets an order with its status and lines.
/// Pass the external id of a customer to find only the orders of that customer, so the orders of others come back as not found.
/// Pass null to find any order.
/// </summary>
public record OrderGetQuery(Guid OrderId, string? CustomerExternalId) : ICatQuery<Order>;
