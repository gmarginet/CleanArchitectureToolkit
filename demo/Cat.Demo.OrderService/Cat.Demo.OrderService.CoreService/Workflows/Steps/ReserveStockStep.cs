using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.CoreService.Workflows.Steps;

/// <summary>
/// Asks for a stock reservation. It never fails the workflow.
/// It writes the answer to the state, and an <c>If</c> in the workflow decides what to do with it.
/// </summary>
public class ReserveStockStep : CatStepBodyAsync<PlaceOrderState>
{
    private readonly IStockReservation _stockReservation;

    public ReserveStockStep(IStockReservation stockReservation, ILogger<ReserveStockStep> logger)
        : base(logger)
    {
        _stockReservation = stockReservation;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var lines = WorkflowState.Lines
            .Select(x => new StockReservationLine(x.BookId, x.Quantity))
            .ToList();

        var result = await _stockReservation.ReserveAsync(WorkflowState.OrderNumber, lines, cancellationToken);

        WorkflowState.StockReserved = result.Reserved;
        WorkflowState.OutOfStockBookId = result.OutOfStockBookId;

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
