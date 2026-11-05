using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>Deletes the order counters before today (UTC) and creates the counter of today when it is missing.</summary>
public record OrderCountersCleanUpCommand : ICatCommand;
