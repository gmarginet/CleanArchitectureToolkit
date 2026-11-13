using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Users.Abstractions;
using Riok.Mapperly.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Extensions;

[Mapper]
public static partial class MappingExtensions
{
    [MapProperty(nameof(Order.OrderStatus) + "." + nameof(OrderStatus.Code), nameof(OrderModel.Status))]
    [MapperIgnoreSource(nameof(Order.SequenceId))]
    [MapperIgnoreSource(nameof(Order.CustomerId))]
    [MapperIgnoreSource(nameof(Order.OrderStatusId))]
    [MapperIgnoreSource(nameof(Order.Customer))]
    [MapperIgnoreSource(nameof(Order.Payment))]
    public static partial OrderModel ToModel(this Order order);

    [MapProperty(nameof(Order.OrderStatus) + "." + nameof(OrderStatus.Code), nameof(OrderSummaryModel.Status))]
    [MapperIgnoreSource(nameof(Order.SequenceId))]
    [MapperIgnoreSource(nameof(Order.CustomerId))]
    [MapperIgnoreSource(nameof(Order.OrderStatusId))]
    [MapperIgnoreSource(nameof(Order.Customer))]
    [MapperIgnoreSource(nameof(Order.Payment))]
    [MapperIgnoreSource(nameof(Order.Lines))]
    public static partial OrderSummaryModel ToSummaryModel(this Order order);

    [MapperIgnoreSource(nameof(OrderLine.Id))]
    [MapperIgnoreSource(nameof(OrderLine.SequenceId))]
    [MapperIgnoreSource(nameof(OrderLine.OrderId))]
    public static partial OrderLineModel ToModel(this OrderLine orderLine);

    /// <summary>Gets the external id to filter orders on. An admin has no filter and sees every order.</summary>
    public static string? GetOwnerFilter(this ICatUser currentUser)
        => currentUser.IsAdmin() ? null : currentUser.UserId;
}
