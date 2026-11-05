using Cat.Demo.OrderService.Contracts.Models;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>Places an order for the current user and returns the new order.</summary>
public record PlaceOrderRequest(PlaceOrderModel Order) : ICatServiceRequest<OrderModel>;
