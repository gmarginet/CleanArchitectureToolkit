using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.FluentWorkflows.Tests;

/// <summary>
/// Runs the examples of the README, so they keep working.
/// </summary>
[TestFixture]
public class ReadmeExampleTests : UnitTestBase
{
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddSingleton<IStockService, FakeStockService>();
        Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsModule(services);
        Cat.FluentWorkflows.Commands.Extensions.ServiceCollectionExtensions.AddCatBuildInCommandWorkflowStep(services);
        Cat.FluentWorkflows.Queries.Extensions.ServiceCollectionExtensions.AddCatBuildInQueryWorkflowStep(services);
        Cat.Commands.Extensions.ServiceCollectionExtensions.AddCatCommandsModule(services, typeof(SaveOrderCommandHandler));
        Cat.Queries.Extensions.ServiceCollectionExtensions.AddCatQueriesModule(services, typeof(GetDiscountQueryHandler));
        Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsSteps(services, typeof(CalculateDiscountStep));
        Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsFlows(services, typeof(ProcessOrderWorkflow));
    }

    private async Task<ICatWorkflowResponse> RunAsync<TWorkflow, TState>(TState state)
        where TWorkflow : ICatWorkflow<TState>
        where TState : class, ICatWorkflowState<TState>
    {
        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        return await processor.RunAsync<TWorkflow, TState>(state, CancellationToken.None);
    }

    [Test]
    public async Task ProcessOrderWorkflow_PricesTheOrderAndAppliesTheDiscount()
    {
        var state = new ProcessOrderWorkflowState { Lines = [new OrderLine("A", 2, 30m), new OrderLine("B", 1, 50m)] };
        await RunAsync<ProcessOrderWorkflow, ProcessOrderWorkflowState>(state);

        Assert.That(state.Total, Is.EqualTo(110m));
        Assert.That(state.Discount, Is.EqualTo(11m));
        Assert.That(state.Status, Is.EqualTo("Processed"));
    }

    [Test]
    public async Task RunSnippet_EmptyOrder_EndsWithTheError()
    {
        var state = new ReadmeRunSnippetsState();
        var result = await RunAsync<ReadmeRunSnippets, ReadmeRunSnippetsState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(result.ErrorList.Single().Code, Is.EqualTo("ORD-1001"));
        Assert.That(state.Attempts, Is.EqualTo(1));
    }

    [Test]
    public async Task SwitchFallThroughSnippet_ExpressAndPickupShareTheSteps()
    {
        var express = new ReadmeSwitchFallThroughSnippetState { Type = OrderType.Express };
        var pickup = new ReadmeSwitchFallThroughSnippetState { Type = OrderType.Pickup };
        var standard = new ReadmeSwitchFallThroughSnippetState { Type = OrderType.Standard };

        await RunAsync<ReadmeSwitchFallThroughSnippet, ReadmeSwitchFallThroughSnippetState>(express);
        await RunAsync<ReadmeSwitchFallThroughSnippet, ReadmeSwitchFallThroughSnippetState>(pickup);
        await RunAsync<ReadmeSwitchFallThroughSnippet, ReadmeSwitchFallThroughSnippetState>(standard);

        Assert.That(express.Status, Is.EqualTo("Fast lane"));
        Assert.That(pickup.Status, Is.EqualTo("Fast lane"));
        Assert.That(standard.Status, Is.EqualTo("New"));
    }

    [Test]
    public async Task SwitchSnippet_RunsTheMatchingCaseOrTheDefault()
    {
        var express = new ReadmeSwitchSnippetsState { Type = OrderType.Express };
        var pickup = new ReadmeSwitchSnippetsState { Type = OrderType.Pickup };

        await RunAsync<ReadmeSwitchSnippets, ReadmeSwitchSnippetsState>(express);
        await RunAsync<ReadmeSwitchSnippets, ReadmeSwitchSnippetsState>(pickup);

        Assert.That(express.Status, Is.EqualTo("Express"));
        Assert.That(pickup.Status, Is.EqualTo("Other"));
    }

    [Test]
    public async Task ForeachSnippets_SumTheLines()
    {
        var state = new ReadmeForeachSnippetsState { Lines = [new OrderLine("A", 2, 10m), new OrderLine("B", 1, 5m)] };
        await RunAsync<ReadmeForeachSnippets, ReadmeForeachSnippetsState>(state);

        // the first loop adds 25, the second loop adds 25 again, the third loop counts the lines
        Assert.That(state.Total, Is.EqualTo(50m));
        Assert.That(state.Attempts, Is.EqualTo(2));
    }

    [Test]
    public async Task CheckoutWorkflow_RunsThePaymentSubWorkflow()
    {
        var state = new CheckoutWorkflowState { Total = 25m };
        await RunAsync<CheckoutWorkflow, CheckoutWorkflowState>(state);

        Assert.That(state.WorkflowState.Paid, Is.True);
        Assert.That(state.Status, Is.EqualTo("Paid"));
    }

    [Test]
    public async Task CommandAndQuerySnippet_PassTheStateAlongAndBack()
    {
        var state = new ReadmeCommandAndQueryWorkflowState { Status = "Ready", Total = 200m };
        var result = await RunAsync<ReadmeCommandAndQueryWorkflow, ReadmeCommandAndQueryWorkflowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(SaveOrderCommandHandler.LastStatus, Is.EqualTo("Ready"));
        Assert.That(state.Discount, Is.EqualTo(20m));
    }

    [Test]
    public async Task CustomStepsSnippet_OutOfStock_EndsWithTheError()
    {
        var state = new ReadmeCustomStepsWorkflowState { Lines = [new OrderLine("SOLD-OUT", 1, 10m)] };
        var result = await RunAsync<ReadmeCustomStepsWorkflow, ReadmeCustomStepsWorkflowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(result.ErrorList.Single().Code, Is.EqualTo("ORD-1002"));
        Assert.That(state.Total, Is.EqualTo(0m));
    }

    [Test]
    public async Task CustomStepsSnippet_InStock_CalculatesTheDiscountThroughInputsAndOutputs()
    {
        var state = new ReadmeCustomStepsWorkflowState { Lines = [new OrderLine("A", 2, 60m)] };
        var result = await RunAsync<ReadmeCustomStepsWorkflow, ReadmeCustomStepsWorkflowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Total, Is.EqualTo(120m));
        Assert.That(state.Discount, Is.EqualTo(12m));
    }
}
