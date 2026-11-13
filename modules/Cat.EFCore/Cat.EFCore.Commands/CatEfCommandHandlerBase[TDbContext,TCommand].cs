using Cat.Commands.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.EFCore.Commands;

/// <summary>
/// Base class for command handlers that change data with Entity Framework Core and return no result.
/// It only gives the handler its <see cref="DbContext"/>. The handler decides when to start a transaction
/// and when to call <c>SaveChanges</c>.
/// </summary>
/// <typeparam name="TDbContext">The context type. Any <see cref="Microsoft.EntityFrameworkCore.DbContext"/> works, also a scaffolded one.</typeparam>
/// <typeparam name="TCommand">The command this handler can run.</typeparam>
public abstract class CatEfCommandHandlerBase<TDbContext, TCommand> : ICatCommandHandler<TCommand>
    where TDbContext : DbContext
    where TCommand : class, ICatCommand
{
    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="dbContext">The context to change data with.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="dbContext"/> is <c>null</c>.</exception>
    protected CatEfCommandHandlerBase(TDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// The context to change data with.
    /// </summary>
    protected TDbContext DbContext { get; }

    /// <inheritdoc />
    public abstract Task<ICatResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
