using Cat.Commands.Abstractions;

namespace ServiceName.CoreService.Commands;

/// <summary>The command ItemNameCommand. A Dapper handler in the Infrastructure project runs its SQL.</summary>
public record ItemNameCommand(Guid Id) : ICatCommand;
