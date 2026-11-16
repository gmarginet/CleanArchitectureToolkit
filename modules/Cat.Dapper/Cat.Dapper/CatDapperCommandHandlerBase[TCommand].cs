using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Dapper.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.Dapper;

/// <summary>
/// Base class for command handlers that change data with plain SQL and Dapper and return no result.
/// It only gives the handler its <see cref="ICatDbSession"/>. The handler decides when to start a transaction and when to commit it.
/// </summary>
/// <typeparam name="TCommand">The command this handler can run.</typeparam>
public abstract class CatDapperCommandHandlerBase<TCommand> : ICatCommandHandler<TCommand>
    where TCommand : class, ICatCommand
{
    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="session">The session to change data with.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> is <c>null</c>.</exception>
    protected CatDapperCommandHandlerBase(ICatDbSession session)
    {
        Session = session ?? throw new ArgumentNullException(nameof(session));
    }

    /// <summary>
    /// The session to change data with.
    /// </summary>
    protected ICatDbSession Session { get; }

    /// <inheritdoc />
    public abstract Task<ICatResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
