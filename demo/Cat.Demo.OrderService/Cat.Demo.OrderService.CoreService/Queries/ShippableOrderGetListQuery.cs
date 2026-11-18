using System;
using System.Collections.Generic;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Queries.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Queries;

/// <summary>Gets the orders that are Confirmed and were confirmed before the given moment (UTC), oldest first.</summary>
public record ShippableOrderGetListQuery(DateTime ConfirmedBefore) : ICatQuery<IList<Order>>;
