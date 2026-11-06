using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Abstractions;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Demo.OrderService.CoreService.Workflows.Steps;

/// <summary>Asks the price provider for the current price of every book and fills the unit price and the ISBN of the lines.</summary>
public class PriceLinesStep : CatStepBodyAsync<PlaceOrderState>
{
    private readonly IPriceProvider _priceProvider;

    public PriceLinesStep(IPriceProvider priceProvider, ILogger<PriceLinesStep> logger)
        : base(logger)
    {
        _priceProvider = priceProvider;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var bookIds = WorkflowState.Lines.Select(x => x.BookId).Distinct().ToList();
        var response = await _priceProvider.GetPricesAsync(bookIds, cancellationToken);

        if (response.IsFailed)
        {
            return CatWorkflowResponse.Failed(CatStepExecutionResult.BreakCascade, response.ErrorList);
        }

        foreach (var line in WorkflowState.Lines)
        {
            if (!response.Value!.TryGetValue(line.BookId, out var price))
            {
                return CatWorkflowResponse.Failed(
                    CatStepExecutionResult.BreakCascade,
                    OrderErrorDefinitions.PriceUnavailable.CreateCatError(line.BookId));
            }

            line.UnitPrice = price.Price;
            line.Isbn = price.Isbn;
        }

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
