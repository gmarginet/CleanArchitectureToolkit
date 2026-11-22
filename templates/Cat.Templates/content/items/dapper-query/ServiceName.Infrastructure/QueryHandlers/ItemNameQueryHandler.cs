using Cat.Dapper;
using Cat.Dapper.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using ServiceName.CoreService.Queries;

namespace ServiceName.Infrastructure.QueryHandlers;

/// <summary>
/// Reads the rows of <see cref="ItemNameQuery"/> with plain SQL through Dapper. The SQL sits in <c>ItemNameQueryHandler.sql</c>
/// and the source generator turns it into the constant <c>Sql</c>.
/// </summary>
public partial class ItemNameQueryHandler(ICatDbSession session)
    : CatDapperQueryHandlerBase<ItemNameQuery, IList<ItemNameRow>>(session)
{
    public override async Task<ICatResponse<IList<ItemNameRow>>> HandleAsync(ItemNameQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await Session.QueryAsync<ItemNameRow>(Sql, new { }, cancellationToken);
        return CatResponse.Ok<IList<ItemNameRow>>(rows.ToList());
    }
}
