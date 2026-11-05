using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>Sets the status of an order. <paramref name="StatusCode"/> is one of the codes in <c>OrderStatuses</c>.</summary>
public record OrderSetStatusCommand(Guid OrderId, string StatusCode) : ICatCommand;
