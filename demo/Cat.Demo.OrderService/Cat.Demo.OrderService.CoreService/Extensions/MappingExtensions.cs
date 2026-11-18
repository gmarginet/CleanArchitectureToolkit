using Cat.Demo.OrderService.Contracts.Models;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Demo.OrderService.DataModels.Entities;
using Cat.Users.Abstractions;
using Riok.Mapperly.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Extensions;

[Mapper]
public static partial class MappingExtensions
{
    [MapProperty(nameof(Order.OrderStatus) + "." + nameof(OrderStatus.Code), nameof(OrderModel.Status))]
    [MapProperty(nameof(Order.OrderStatus) + "." + nameof(OrderStatus.Code), nameof(OrderModel.CanCancel), Use = nameof(CanCancel))]
    [MapperIgnoreSource(nameof(Order.SequenceId))]
    [MapperIgnoreSource(nameof(Order.CustomerId))]
    [MapperIgnoreSource(nameof(Order.OrderStatusId))]
    [MapperIgnoreSource(nameof(Order.ConfirmedAt))]
    [MapperIgnoreSource(nameof(Order.Customer))]
    [MapperIgnoreSource(nameof(Order.Payment))]
    public static partial OrderModel ToModel(this Order order);

    /// <summary>The conversion of a status code to the <c>CanCancel</c> flag of the model. The rule lives in <see cref="OrderStatuses.CanCancel"/>.</summary>
    private static bool CanCancel(string statusCode) => OrderStatuses.CanCancel(statusCode);

    public static partial OrderSummaryModel ToSummaryModel(this OrderSummaryRow row);

    [MapperIgnoreSource(nameof(OrderLine.Id))]
    [MapperIgnoreSource(nameof(OrderLine.SequenceId))]
    [MapperIgnoreSource(nameof(OrderLine.OrderId))]
    public static partial OrderLineModel ToModel(this OrderLine orderLine);

    /// <summary>Gets the external id to filter orders on. An admin has no filter and sees every order.</summary>
    public static string? GetOwnerFilter(this ICatUser currentUser)
        => currentUser.IsAdmin() ? null : currentUser.UserId;
}
