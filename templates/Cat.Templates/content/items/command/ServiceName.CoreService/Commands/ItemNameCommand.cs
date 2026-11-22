using Cat.Commands.Abstractions;

namespace ServiceName.CoreService.Commands;

/// <summary>The command ItemNameCommand. Add the values that the handler needs.</summary>
public record ItemNameCommand(Guid Id) : ICatCommand;
