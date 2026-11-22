using Cat.Dapper;
using Cat.Dapper.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using ServiceName.CoreService.Commands;

namespace ServiceName.Infrastructure.CommandHandlers;

/// <summary>
/// Runs the statement of <see cref="ItemNameCommand"/> with plain SQL through Dapper. The SQL sits in <c>ItemNameCommandHandler.sql</c>
/// and the source generator turns it into the constant <c>Sql</c>. For more than one statement, start a transaction on the session.
/// </summary>
public partial class ItemNameCommandHandler(ICatDbSession session)
    : CatDapperCommandHandlerBase<ItemNameCommand>(session)
{
    public override async Task<ICatResponse> HandleAsync(ItemNameCommand command, CancellationToken cancellationToken = default)
    {
        await Session.ExecuteAsync(Sql, new { command.Id }, cancellationToken);
        return CatResponse.Ok();
    }
}
