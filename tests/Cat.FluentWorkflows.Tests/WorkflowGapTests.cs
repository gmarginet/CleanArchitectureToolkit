using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Helpers;
using Cat.FluentWorkflows.Tests.Steps;
using Cat.FluentWorkflows.Tests.Workflows;
using Cat.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests;

[TestFixture]
public class WorkflowGapTests : UnitTestBase
{
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton<LogCollector>();
        services.AddSingleton(typeof(ILogger<>), typeof(CollectingLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsSteps(typeof(NullableInputStep));
        services.AddCatFluentWorkflowsFlows(typeof(LogLevelsFlow));
    }

    private LogCollector Logs => ServiceProvider.GetRequiredService<LogCollector>();

    private async Task<ICatWorkflowResponse> RunAsync<TWorkflow, TState>(TState state)
        where TWorkflow : ICatWorkflow<TState>
        where TState : class, ICatWorkflowState<TState>
    {
        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        return await processor.RunAsync<TWorkflow, TState>(state, CancellationToken.None);
    }

    [Test]
    public async Task LogSteps_LogEveryLevelWithFormattedMessage()
    {
        Logs.Clear();
        await RunAsync<LogLevelsFlow, LogLevelsFlowState>(new LogLevelsFlowState { Number = 7 });

        var entries = Logs.Entries;
        Assert.That(entries.Any(e => e.Level == LogLevel.Trace && e.Message.Contains("trace 7")));
        Assert.That(entries.Any(e => e.Level == LogLevel.Debug && e.Message.Contains("debug 7")));
        Assert.That(entries.Any(e => e.Level == LogLevel.Information && e.Message.Contains("information 7")));
        Assert.That(entries.Any(e => e.Level == LogLevel.Warning && e.Message.Contains("warning 7")));
        Assert.That(entries.Any(e => e.Level == LogLevel.Error && e.Message.Contains("error 7")));
        Assert.That(entries.Any(e => e.Level == LogLevel.Critical && e.Message.Contains("critical 7")));
        Assert.That(entries.Any(e => e.Level == LogLevel.Warning && e.Message.Contains("custom 7 and 14")));
    }

    [Test]
    public async Task RunFuncWithLogger_RunsBothSteps()
    {
        var state = new RunFuncWithLoggerFlowState();
        await RunAsync<RunFuncWithLoggerFlow, RunFuncWithLoggerFlowState>(state);
        Assert.That(state.Trace, Is.EqualTo(new[] { "func", "after" }));
    }

    [Test]
    public async Task SetWithLogger_SetsValue()
    {
        var state = new SetWithLoggerFlowState();
        await RunAsync<SetWithLoggerFlow, SetWithLoggerFlowState>(state);
        Assert.That(state.Text, Is.EqualTo("number 4"));
    }

    [TestCase(1, new[] { "1" })]
    [TestCase(2, new[] { "1", "2" })]
    public async Task BreakCascadeIfWithLogger_BreaksOnCondition(int number, string[] expected)
    {
        var state = new BreakCascadeIfWithLoggerFlowState { Number = number };
        await RunAsync<BreakCascadeIfWithLoggerFlow, BreakCascadeIfWithLoggerFlowState>(state);
        Assert.That(state.Trace, Is.EqualTo(expected));
    }

    [TestCase(1, new[] { "1" })]
    [TestCase(2, new[] { "1", "2" })]
    public async Task BreakFromCurrentFlowOnlyIfWithLogger_BreaksOnCondition(int number, string[] expected)
    {
        var state = new BreakFromCurrentFlowOnlyIfWithLoggerFlowState { Number = number };
        await RunAsync<BreakFromCurrentFlowOnlyIfWithLoggerFlow, BreakFromCurrentFlowOnlyIfWithLoggerFlowState>(state);
        Assert.That(state.Trace, Is.EqualTo(expected));
    }

    [Test]
    public async Task BreakFromLoopIfWithLogger_LeavesLoop()
    {
        var state = new BreakFromLoopIfWithLoggerFlowState();
        await RunAsync<BreakFromLoopIfWithLoggerFlow, BreakFromLoopIfWithLoggerFlowState>(state);
        Assert.That(state.Trace, Is.EqualTo(new[] { "i", "i", "end" }));
    }

    [Test]
    public async Task While_NeverTrue_SkipsBody()
    {
        var state = new WhileNeverTrueFlowState();
        await RunAsync<WhileNeverTrueFlow, WhileNeverTrueFlowState>(state);
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    [Test]
    public async Task Foreach_EmptyList_SkipsBody()
    {
        var state = new ForeachEmptyFlowState();
        await RunAsync<ForeachEmptyFlow, ForeachEmptyFlowState>(state);
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    [Test]
    public async Task Input_NullValue_OverwritesPresetValue()
    {
        var state = new NullInputFlowState();
        await RunAsync<NullInputFlow, NullInputFlowState>(state);
        Assert.That(state.StepSawNull, Is.True);
    }

    [Test]
    public async Task NoInput_KeepsStepDefaults()
    {
        var state = new UnusedInputFlowState();
        await RunAsync<UnusedInputFlow, UnusedInputFlowState>(state);
        Assert.That(state.StepNumber, Is.EqualTo(99));
        Assert.That(state.StepSawNull, Is.False);
    }

    [Test]
    public void Switch_DuplicateCase_Throws()
    {
        var exception = Assert.CatchAsync<Exception>(async () =>
            await RunAsync<SwitchDuplicateCaseFlow, SwitchDuplicateCaseFlowState>(new SwitchDuplicateCaseFlowState()));
        Assert.That(exception!.ToString(), Does.Contain("already defined"));
    }

    [Test]
    public void UnregisteredWorkflow_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await RunAsync<UnregisteredFlow, UnregisteredFlowState>(new UnregisteredFlowState()));
    }

    [Test]
    public void UnregisteredStep_Throws()
    {
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await RunAsync<UnregisteredStepFlow, UnregisteredStepFlowState>(new UnregisteredStepFlowState()));
    }
}
