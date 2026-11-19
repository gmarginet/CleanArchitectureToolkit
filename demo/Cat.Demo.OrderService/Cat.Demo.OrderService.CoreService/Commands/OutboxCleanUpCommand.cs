using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>Deletes the outbox rows that were sent before the given time.</summary>
/// <param name="SentBefore">The time limit. A row sent before this time is deleted.</param>
public record OutboxCleanUpCommand(DateTimeOffset SentBefore) : ICatCommand;
