using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.UnitTesting.Commands;

/// <summary>
/// A command processor for unit tests. It records every command and returns what the test says.
/// It fills no ids and sets no timestamps, the test decides the whole answer.
/// </summary>
public class FakeCommandProcessor : ICatCommandProcessor
{
    private readonly Dictionary<Type, Func<object, object>> _responses = new Dictionary<Type, Func<object, object>>();

    /// <summary>
    /// The response of a command without a result when the test set up nothing for its type.
    /// It starts as <see cref="CatResponse.Ok()"/>.
    /// </summary>
    public ICatResponse DefaultResponse { get; set; } = CatResponse.Ok();

    /// <summary>
    /// Every command that was processed, in order. It holds commands with and without a result.
    /// </summary>
    public List<object> Commands { get; } = new List<object>();

    /// <summary>
    /// Sets the response for a command without a result.
    /// </summary>
    /// <typeparam name="TCommand">The command type.</typeparam>
    /// <param name="response">The response every command of this type gets.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeCommandProcessor Respond<TCommand>(ICatResponse response)
        where TCommand : ICatCommand
    {
        return Respond<TCommand>(_ => response);
    }

    /// <summary>
    /// Sets the response for a command without a result, built from the command.
    /// </summary>
    /// <typeparam name="TCommand">The command type.</typeparam>
    /// <param name="respond">Builds the response. It can also change the command, as a real handler would.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeCommandProcessor Respond<TCommand>(Func<TCommand, ICatResponse> respond)
        where TCommand : ICatCommand
    {
        _responses[typeof(TCommand)] = command => respond((TCommand)command);
        return this;
    }

    /// <summary>
    /// Sets the response for a command with a result.
    /// </summary>
    /// <typeparam name="TCommand">The command type.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="response">The response every command of this type gets.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeCommandProcessor Respond<TCommand, TResult>(ICatResponse<TResult> response)
        where TCommand : ICatCommand<TResult>
    {
        return Respond<TCommand, TResult>(_ => response);
    }

    /// <summary>
    /// Sets the response for a command with a result, built from the command.
    /// </summary>
    /// <typeparam name="TCommand">The command type.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="respond">Builds the response from the command.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeCommandProcessor Respond<TCommand, TResult>(Func<TCommand, ICatResponse<TResult>> respond)
        where TCommand : ICatCommand<TResult>
    {
        _responses[typeof(TCommand)] = command => respond((TCommand)command);
        return this;
    }

    /// <summary>
    /// Gives the processed commands of one type, in order.
    /// </summary>
    /// <typeparam name="T">The command type.</typeparam>
    /// <returns>The commands of this type.</returns>
    public IEnumerable<T> Of<T>() => Commands.OfType<T>();

    /// <summary>
    /// Clears the recorded commands, the set up responses and the default response.
    /// </summary>
    public void Reset()
    {
        Commands.Clear();
        _responses.Clear();
        DefaultResponse = CatResponse.Ok();
    }

    /// <inheritdoc />
    public Task<ICatResponse> ProcessAsync(ICatCommand catCommand, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catCommand));

    /// <inheritdoc />
    public ICatResponse Process(ICatCommand catCommand)
    {
        Commands.Add(catCommand);

        return _responses.TryGetValue(catCommand.GetType(), out var respond)
            ? (ICatResponse)respond(catCommand)
            : DefaultResponse;
    }

    /// <inheritdoc />
    public Task<ICatResponse<TResult>> ProcessAsync<TResult>(ICatCommand<TResult> catCommand, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catCommand));

    /// <inheritdoc />
    public ICatResponse<TResult> Process<TResult>(ICatCommand<TResult> catCommand)
    {
        Commands.Add(catCommand);

        return _responses.TryGetValue(catCommand.GetType(), out var respond)
            ? (ICatResponse<TResult>)respond(catCommand)
            : throw new NotSupportedException($"No response is set up for {catCommand.GetType().Name}. Call Respond first.");
    }
}
