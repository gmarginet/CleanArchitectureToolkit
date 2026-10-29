namespace Cat.Commands.Abstractions;

/// <summary>
/// Marks a command that changes state and returns a response without a payload.
/// Handle it with <see cref="ICatCommandHandler{TCommand}"/>.
/// </summary>
public interface ICatCommand
{
}