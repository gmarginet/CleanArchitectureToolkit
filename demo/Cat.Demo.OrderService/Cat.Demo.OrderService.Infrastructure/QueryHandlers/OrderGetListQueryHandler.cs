using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Dapper;
using Cat.Dapper.Abstractions;
using Cat.Demo.OrderService.CoreService.Queries;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Demo.OrderService.Infrastructure.QueryHandlers;

/// <summary>
/// Reads the order overview with plain SQL through Dapper. The SQL sits in <c>OrderGetListQueryHandler.sql</c>
/// and the source generator turns it into the constant <c>Sql</c>.
/// </summary>
public partial class OrderGetListQueryHandler(ICatDbSession session)
    : CatDapperQueryHandlerBase<OrderGetListQuery, IList<OrderSummaryRow>>(session)
{
    public override async Task<ICatResponse<IList<OrderSummaryRow>>> HandleAsync(OrderGetListQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await Session.QueryAsync<OrderSummaryRow>(Sql, new { query.CustomerExternalId }, cancellationToken);
        return CatResponse.Ok<IList<OrderSummaryRow>>(rows.ToList());
    }
}
