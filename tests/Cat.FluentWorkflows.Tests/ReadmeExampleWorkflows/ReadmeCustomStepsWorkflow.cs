using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeCustomStepsWorkflowState : ICatWorkflowState<ReadmeCustomStepsWorkflowState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
}

public class CalculateDiscountStep : CatStepBody
{
    public CalculateDiscountStep(ILogger<CalculateDiscountStep> logger)
        : base(logger)
    {
    }

    public decimal Total { get; set; }

    public decimal Discount { get; private set; }

    protected override ICatWorkflowResponse Run()
    {
        Discount = Total >= 100 ? Total * 0.1m : 0m;

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}

public interface IStockService
{
    Task<bool> IsInStockAsync(string productId, int quantity, CancellationToken cancellationToken);
}

public class FakeStockService : IStockService
{
    public Task<bool> IsInStockAsync(string productId, int quantity, CancellationToken cancellationToken)
    {
        return Task.FromResult(productId != "SOLD-OUT");
    }
}

public class CheckStockStep : CatStepBodyAsync<ReadmeCustomStepsWorkflowState>
{
    private readonly IStockService _stockService;

    public CheckStockStep(IStockService stockService, ILogger<CheckStockStep> logger)
        : base(logger)
    {
        _stockService = stockService;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        foreach (var line in WorkflowState.Lines)
        {
            if (await _stockService.IsInStockAsync(line.ProductId, line.Quantity, cancellationToken) is false)
            {
                Logger.LogWarning("Product {productId} is out of stock", line.ProductId);

                return CatWorkflowResponse.Failed(
                    CatStepExecutionResult.BreakCascade,
                    CatError.Create("ORD-1002", "Product '{productId}' is out of stock.", line.ProductId));
            }
        }

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}

public class ReadmeCustomStepsWorkflow : ICatWorkflow<ReadmeCustomStepsWorkflowState>
{
    public void Build(ICatWorkflowBuilder<ReadmeCustomStepsWorkflowState> builder)
    {
        builder.Run<ReadmeCustomStepsWorkflowState, CheckStockStep>();

        builder.Set(s => s.Total, s => s.Lines.Sum(l => l.Quantity * l.Price));

        builder.Run<ReadmeCustomStepsWorkflowState, CalculateDiscountStep>()
            .Input(s => s.Total, step => step.Total)
            .Output(step => step.Discount, s => s.Discount);
    }
}
