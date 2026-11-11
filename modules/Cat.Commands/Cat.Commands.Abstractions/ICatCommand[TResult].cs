namespace Cat.Commands.Abstractions;

/// <summary>
/// Marks a command that changes state and returns what it made in the response.
/// Handle it with <see cref="ICatCommandHandler{TCommand,TResult}"/>.
/// The result holds only what the command made or decided, such as an ID, a number or a time. It is never a read model.
/// </summary>
/// <typeparam name="TResult">The type of the data the handler returns.</typeparam>
public interface ICatCommand<out TResult>
{
}
