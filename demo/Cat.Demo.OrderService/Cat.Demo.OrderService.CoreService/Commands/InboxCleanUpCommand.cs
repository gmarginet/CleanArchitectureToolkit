using System;
using Cat.Commands.Abstractions;

namespace Cat.Demo.OrderService.CoreService.Commands;

/// <summary>Deletes the inbox rows that were handled before the given time.</summary>
/// <param name="HandledBefore">The time limit. A row handled before this time is deleted.</param>
public record InboxCleanUpCommand(DateTimeOffset HandledBefore) : ICatCommand;
