using System.Collections.Generic;
using Cat.Queries.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Queries;

/// <summary>
/// Gets the order overview, newest first.
/// Pass the external id of a customer to get only the orders of that customer. Pass null to get all orders.
/// </summary>
public record OrderGetListQuery(string? CustomerExternalId) : ICatQuery<IList<OrderSummaryRow>>;
