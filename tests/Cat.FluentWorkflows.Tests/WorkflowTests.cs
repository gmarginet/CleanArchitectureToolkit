using Cat.Commands.Extensions;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Commands.Extensions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Queries.Extensions;
using Cat.FluentWorkflows.Tests.Steps;
using Cat.FluentWorkflows.Tests.Workflows;
using Cat.NUnit;
using Cat.Queries.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

// ReSharper disable InconsistentNaming

namespace Cat.FluentWorkflows.Tests;

[TestFixture]
public class WorkflowTests : UnitTestBase
{
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatBuildInCommandWorkflowStep();
        services.AddCatBuildInQueryWorkflowStep();
        services.AddCatCommandsModule(typeof(TestPingCommandHandler));
        services.AddCatQueriesModule(typeof(TestAskQueryHandler));
        services.AddCatFluentWorkflowsSteps(typeof(DoubleStep));
        services.AddCatFluentWorkflowsFlows(typeof(DoubleStepFlow));
    }

    private async Task<ICatWorkflowResponse> RunAsync<TWorkflow, TState>(TState state)
        where TWorkflow : ICatWorkflow<TState>
        where TState : class, ICatWorkflowState<TState>
    {
        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        return await processor.RunAsync<TWorkflow, TState>(state, CancellationToken.None);
    }

    #region Run

    [Test]
    public async Task RunAction_RunsEveryStepInOrder()
    {
        var state = new RunActionFlowState();
        var result = await RunAsync<RunActionFlow, RunActionFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "a", "b", "c" }));
    }

    [Test]
    public async Task RunFunc_ContinueResult_RunsNextStep()
    {
        var state = new RunFuncContinueFlowState();
        var result = await RunAsync<RunFuncContinueFlow, RunFuncContinueFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "f1", "after" }));
    }

    [Test]
    public async Task RunFunc_BreakCascadeResult_StopsTheWorkflow()
    {
        var state = new RunFuncBreakCascadeFlowState();
        var result = await RunAsync<RunFuncBreakCascadeFlow, RunFuncBreakCascadeFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Trace, Is.EqualTo(new[] { "f1" }));
    }

    [Test]
    public async Task RunFunc_FailedResponse_StopsTheWorkflowAndReturnsTheErrors()
    {
        var state = new RunFuncFailedFlowState();
        var result = await RunAsync<RunFuncFailedFlow, RunFuncFailedFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        Assert.That(result.ErrorList[0].Code, Is.EqualTo("X-1"));
        Assert.That(state.Trace, Is.EqualTo(new[] { "f1" }));
    }

    [Test]
    public async Task RunSubWorkflow_RunsTheSubWorkflowOnItsOwnState()
    {
        var state = new RunSubWorkflowFlowState();
        var result = await RunAsync<RunSubWorkflowFlow, RunSubWorkflowFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "sub-ran" }));
    }

    #endregion Run

    #region Set and Log

    [Test]
    public async Task Set_AssignsTheStateProperty()
    {
        var state = new SetFlowState();
        await RunAsync<SetFlow, SetFlowState>(state);

        Assert.That(state.Number, Is.EqualTo(42));
        Assert.That(state.Name, Is.EqualTo("n=42"));
    }

    [Test]
    public async Task Log_ContinuesWithTheNextStep()
    {
        var state = new LogFlowState();
        var result = await RunAsync<LogFlow, LogFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "logged" }));
    }

    #endregion Set and Log

    #region If

    [Test]
    public async Task If_ConditionTrue_RunsThenBranch()
    {
        var state = new IfFlowState { Number = 5 };
        await RunAsync<IfFlow, IfFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "then", "end" }));
    }

    [Test]
    public async Task If_ConditionFalse_RunsElseBranch()
    {
        var state = new IfFlowState { Number = 0 };
        await RunAsync<IfFlow, IfFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "else", "end" }));
    }

    [Test]
    public async Task If_ConditionFalseWithoutElse_SkipsToTheNextStep()
    {
        var state = new IfWithoutElseFlowState { Number = 0 };
        await RunAsync<IfWithoutElseFlow, IfWithoutElseFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    #endregion If

    #region While

    [Test]
    public async Task While_RunsUntilTheConditionIsFalse()
    {
        var state = new WhileFlowState();
        await RunAsync<WhileFlow, WhileFlowState>(state);

        Assert.That(state.Number, Is.EqualTo(3));
        Assert.That(state.Trace, Is.EqualTo(new[] { "i", "i", "i", "end" }));
    }

    [Test]
    public async Task While_BreakFromLoopIf_LeavesTheLoopAndContinues()
    {
        var state = new WhileBreakFromLoopFlowState();
        var result = await RunAsync<WhileBreakFromLoopFlow, WhileBreakFromLoopFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Number, Is.EqualTo(2));
        Assert.That(state.Trace, Is.EqualTo(new[] { "i", "end" }));
    }

    [Test]
    public async Task While_BreakCascade_LeavesTheLoopAndEndsTheWorkflow()
    {
        var state = new WhileBreakCascadeFlowState();
        var result = await RunAsync<WhileBreakCascadeFlow, WhileBreakCascadeFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Number, Is.EqualTo(2));
        Assert.That(state.Trace, Is.EqualTo(new[] { "i" }));
    }

    [Test]
    public async Task While_FailedStepsThatContinue_KeepTheErrorsOfEveryPass()
    {
        var state = new FailAndContinueInWhileFlowState();
        var result = await RunAsync<FailAndContinueInWhileFlow, FailAndContinueInWhileFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(result.ErrorList, Has.Count.EqualTo(2));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    #endregion While

    #region Errors

    [Test]
    public async Task FailedStepThatContinues_KeepsItsErrorsWhenLaterStepsSucceed()
    {
        var state = new FailAndContinueFlowState();
        var result = await RunAsync<FailAndContinueFlow, FailAndContinueFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        Assert.That(result.ErrorList[0].Code, Is.EqualTo("X-3"));
        Assert.That(state.Trace, Is.EqualTo(new[] { "after" }));
    }

    [Test]
    public async Task FailedStepThatContinues_InsideIf_KeepsItsErrorsOnce()
    {
        var state = new FailAndContinueInIfFlowState();
        var result = await RunAsync<FailAndContinueInIfFlow, FailAndContinueInIfFlowState>(state);

        Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    [Test]
    public async Task FailedStepsThatContinue_InsideForeach_KeepTheErrorsOfEveryItem()
    {
        var state = new FailAndContinueInForeachFlowState();
        var result = await RunAsync<FailAndContinueInForeachFlow, FailAndContinueInForeachFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(result.ErrorList, Has.Count.EqualTo(3));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    #endregion Errors

    #region Foreach

    [Test]
    public async Task Foreach_WithoutOwnState_RunsForEveryItem()
    {
        var state = new SimpleForeachFlowState();
        await RunAsync<SimpleForeachFlow, SimpleForeachFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "item1", "item2", "item3", "end" }));
    }

    [Test]
    public async Task Foreach_WithOwnState_RunsForEveryItem()
    {
        var state = new ForeachWithStateFlowState();
        await RunAsync<ForeachWithStateFlow, ForeachWithStateFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "item1", "item2", "item3", "end" }));
    }

    [Test]
    public async Task Foreach_BreakFromLoopIf_LeavesTheLoopAndContinues()
    {
        var state = new ForeachBreakFromLoopFlowState();
        var result = await RunAsync<ForeachBreakFromLoopFlow, ForeachBreakFromLoopFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "item1", "item2", "end" }));
    }

    [Test]
    public async Task Foreach_BreakFromCurrentFlowOnlyIf_EndsOnlyTheCurrentItem()
    {
        var state = new ForeachBreakFromCurrentFlowOnlyFlowState();
        var result = await RunAsync<ForeachBreakFromCurrentFlowOnlyFlow, ForeachBreakFromCurrentFlowOnlyFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "item1", "after1", "item2", "item3", "after3", "end" }));
    }

    #endregion Foreach

    #region Switch

    [Test]
    public async Task Switch_RunsTheMatchingCase()
    {
        var state = new SwitchFlowState { Kind = TestKind.B };
        await RunAsync<SwitchFlow, SwitchFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "B", "end" }));
    }

    [Test]
    public async Task Switch_NoMatchAndNoDefault_SkipsToTheNextStep()
    {
        var state = new SwitchFlowState { Kind = TestKind.C };
        var result = await RunAsync<SwitchFlow, SwitchFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    [Test]
    public async Task Switch_NoMatchWithDefault_RunsTheDefaultCase()
    {
        var state = new SwitchDefaultFlowState { Kind = TestKind.C };
        await RunAsync<SwitchDefaultFlow, SwitchDefaultFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "default", "end" }));
    }

    [Test]
    public async Task Switch_CaseWithoutSteps_FallsThroughToTheNextCase()
    {
        var state = new SwitchFallThroughFlowState { Kind = TestKind.A };
        await RunAsync<SwitchFallThroughFlow, SwitchFallThroughFlowState>(state);

        Assert.That(state.Trace, Is.EqualTo(new[] { "A or B" }));
    }

    #endregion Switch

    #region Break

    [Test]
    public async Task BreakCascade_StopsTheWorkflow()
    {
        var state = new BreakCascadeFlowState();
        var result = await RunAsync<BreakCascadeFlow, BreakCascadeFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Trace, Is.EqualTo(new[] { "1" }));
    }

    [Test]
    public async Task BreakFromCurrentFlowOnly_StopsTheWorkflowAndReportsContinue()
    {
        var state = new BreakFromCurrentFlowOnlyFlowState();
        var result = await RunAsync<BreakFromCurrentFlowOnlyFlow, BreakFromCurrentFlowOnlyFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "1" }));
    }

    [Test]
    public async Task BreakFromLoop_LeavesTheLoop()
    {
        var state = new BreakFromLoopFlowState();
        await RunAsync<BreakFromLoopFlow, BreakFromLoopFlowState>(state);

        Assert.That(state.Number, Is.EqualTo(2));
        Assert.That(state.Trace, Is.EqualTo(new[] { "i", "end" }));
    }

    [Test]
    public async Task BreakCascadeIf_ConditionTrue_StopsTheWorkflow()
    {
        var state = new BreakCascadeIfFlowState { Number = 1 };
        var result = await RunAsync<BreakCascadeIfFlow, BreakCascadeIfFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Trace, Is.EqualTo(new[] { "1" }));
    }

    [Test]
    public async Task BreakCascadeIf_ConditionFalse_RunsNextStep()
    {
        var state = new BreakCascadeIfFlowState { Number = 0 };
        var result = await RunAsync<BreakCascadeIfFlow, BreakCascadeIfFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "1", "2" }));
    }

    [Test]
    public async Task BreakFromCurrentFlowOnlyIf_ConditionTrue_StopsTheWorkflowAndReportsContinue()
    {
        var state = new BreakFromCurrentFlowOnlyIfFlowState { Number = 1 };
        var result = await RunAsync<BreakFromCurrentFlowOnlyIfFlow, BreakFromCurrentFlowOnlyIfFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "1" }));
    }

    [Test]
    public async Task BreakFromCurrentFlowOnly_InsideIf_EndsTheWholeWorkflow()
    {
        var state = new IfBreakFromCurrentFlowOnlyFlowState();
        var result = await RunAsync<IfBreakFromCurrentFlowOnlyFlow, IfBreakFromCurrentFlowOnlyFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.Empty);
    }

    [Test]
    public async Task BreakFromCurrentFlowOnly_InsideSubWorkflow_EndsOnlyTheSubWorkflow()
    {
        var state = new SubWorkflowBreakFromCurrentFlowOnlyFlowState();
        var result = await RunAsync<SubWorkflowBreakFromCurrentFlowOnlyFlow, SubWorkflowBreakFromCurrentFlowOnlyFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "before" }));
    }

    [Test]
    public async Task BreakCascade_InsideSubWorkflow_EndsTheMainWorkflowToo()
    {
        var state = new SubWorkflowBreakCascadeFlowState();
        var result = await RunAsync<SubWorkflowBreakCascadeFlow, SubWorkflowBreakCascadeFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Trace, Is.Empty);
    }

    #endregion Break

    #region Custom steps

    [Test]
    public async Task CustomStep_InputsGoInAndOutputsComeOut()
    {
        var state = new DoubleStepFlowState { Number = 4 };
        await RunAsync<DoubleStepFlow, DoubleStepFlowState>(state);

        Assert.That(state.Number, Is.EqualTo(8));
        Assert.That(state.Trace, Is.EqualTo(new[] { "n=8" }));
    }

    #endregion Custom steps

    #region Commands and queries

    [Test]
    public async Task ProcessCommand_Succeeded_ContinuesWithTheNextStep()
    {
        var state = new ProcessCommandFlowState { Name = "ok" };
        var result = await RunAsync<ProcessCommandFlow, ProcessCommandFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "after-command" }));
    }

    [Test]
    public async Task ProcessCommand_Failed_StopsTheWorkflowAndReturnsTheErrors()
    {
        var state = new ProcessCommandFlowState { Name = "fail" };
        var result = await RunAsync<ProcessCommandFlow, ProcessCommandFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(result.ErrorList, Has.Count.EqualTo(1));
        Assert.That(result.ErrorList[0].Code, Is.EqualTo("X-2"));
        Assert.That(state.Trace, Is.Empty);
    }

    [Test]
    public async Task ProcessQuery_Succeeded_ContinuesAndTheOutputIsAssigned()
    {
        var state = new ProcessQueryFlowState();
        var result = await RunAsync<ProcessQueryFlow, ProcessQueryFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Number, Is.EqualTo(7));
        Assert.That(state.Trace, Is.EqualTo(new[] { "after-query" }));
    }

    #endregion Commands and queries
}
