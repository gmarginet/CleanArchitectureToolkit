using System.Collections.Generic;
using Cat.Demo.OrderService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>Gets the order overview, newest first. A customer sees their own orders. An admin sees all of them.</summary>
public record OrderGetListRequest : ICatServiceRequest<IList<OrderSummaryModel>>;
