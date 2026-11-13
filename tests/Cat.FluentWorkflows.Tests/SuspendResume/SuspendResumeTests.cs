using System.Text.Json;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Workflows;
using Cat.UnitTesting.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

// ReSharper disable InconsistentNaming

namespace Cat.FluentWorkflows.Tests.SuspendResume;

[TestFixture]
public class SuspendResumeTests : UnitTestBase
{
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsSteps(typeof(WaitStep));
        services.AddCatFluentWorkflowsFlows(typeof(SimpleWaitFlow));
    }

    // Every call uses its own scope, like a service that resumes a workflow in a later request.
    private async Task<ICatWorkflowResponse> RunAsync<TWorkflow, TState>(TState state)
        where TWorkflow : ICatWorkflow<TState>
        where TState : class, ICatWorkflowState<TState>
    {
        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        return await processor.RunAsync<TWorkflow, TState>(state, CancellationToken.None);
    }

    private async Task<ICatWorkflowResponse> ResumeAsync<TWorkflow, TState>(TState state, ICatWorkflowResponse suspended, object? answer, string? target = null)
        where TWorkflow : ICatWorkflow<TState>
        where TState : class, ICatWorkflowState<TState>
    {
        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        return await processor.ResumeAsync<TWorkflow, TState>(state, suspended.Checkpoint!, answer, target, CancellationToken.None);
    }

    #region Simple

    [Test]
    public async Task Run_StepSuspends_ReturnsSuspendWithCheckpoint()
    {
        var state = new WaitState();
        var result = await RunAsync<SimpleWaitFlow, WaitState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(result.ErrorList, Is.Empty);
        Assert.That(state.Trace, Is.EqualTo(new[] { "before" }));
        Assert.That(result.Checkpoint, Is.Not.Null);
        Assert.That(result.Checkpoint!.Version, Is.EqualTo(2));
        Assert.That(result.Checkpoint.Frame.StepIndex, Is.EqualTo(1));
        Assert.That(result.Checkpoint.Frame.StepName, Is.EqualTo("wait"));
        Assert.That(result.Checkpoint.Frame.IsLeaf, Is.True);
    }

    [Test]
    public async Task Run_NoSuspend_HasNoCheckpoint()
    {
        var state = new IfFlowState { Number = 1 };
        var result = await RunAsync<IfFlow, IfFlowState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(result.Checkpoint, Is.Null);
    }

    [Test]
    public async Task Resume_GoesOnAfterTheWaitingStep_AndCopiesTheAnswer()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);

        var result = await ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, "yes");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(result.Checkpoint, Is.Null);
        Assert.That(state.Answer, Is.EqualTo("yes"));
        Assert.That(state.Trace, Is.EqualTo(new[] { "before", "after:yes" }));
    }

    [Test]
    public async Task Resume_CheckpointThatWentThroughJson_Works()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);
        var json = JsonSerializer.Serialize(suspended.Checkpoint);
        var restored = JsonSerializer.Deserialize<CatWorkflowCheckpoint>(json)!;

        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        var result = await processor.ResumeAsync<SimpleWaitFlow, WaitState>(state, restored, "yes", CancellationToken.None);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "before", "after:yes" }));
    }

    [Test]
    public async Task Resume_AnswerOfTheWrongType_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, 42));
    }

    [Test]
    public async Task Resume_StepThatIsNotResumable_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SuspendOnlyFlow, WaitState>(state);

        Assert.That(suspended.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SuspendOnlyFlow, WaitState>(state, suspended, "x"));
    }

    [Test]
    public async Task Resume_ResumedStepSuspendsAgain_GivesANewCheckpoint()
    {
        var state = new WaitState();
        var first = await RunAsync<WhileWaitFlow, WaitState>(state);
        var second = await ResumeAsync<WhileWaitFlow, WaitState>(state, first, "one");

        Assert.That(second.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(second.Checkpoint, Is.Not.SameAs(first.Checkpoint));
    }

    #endregion

    #region Changed workflows

    [Test]
    public async Task Resume_OtherVersion_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);
        suspended.Checkpoint!.Version = 1;

        var exception = await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, "yes"));
        Assert.That(exception!.Message, Does.Contain("version"));
    }

    [Test]
    public async Task Resume_StepNameIsGone_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);
        suspended.Checkpoint!.Frame.StepName = "gone";

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, "yes"));
    }

    [Test]
    public async Task Resume_NameWinsOverTheIndex()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);
        suspended.Checkpoint!.Frame.StepIndex = 0;

        var result = await ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, "yes");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Answer, Is.EqualTo("yes"));
    }

    [Test]
    public async Task Resume_UnnamedStepAtAnIndexOutOfRange_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);
        suspended.Checkpoint!.Frame.StepName = null;
        suspended.Checkpoint.Frame.StepIndex = 9;

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, "yes"));
    }

    [Test]
    public async Task Resume_UnnamedStepOfAnotherType_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<SimpleWaitFlow, WaitState>(state);
        suspended.Checkpoint!.Frame.StepName = null;
        suspended.Checkpoint.Frame.StepIndex = 0;

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SimpleWaitFlow, WaitState>(state, suspended, "yes"));
    }

    #endregion

    #region Containers

    [Test]
    public async Task If_ResumeStaysInTheSavedBranch_EvenWhenTheConditionChanged()
    {
        var state = new WaitState { Number = 1 };
        var suspended = await RunAsync<IfWaitFlow, WaitState>(state);
        state.Number = 0;

        var result = await ResumeAsync<IfWaitFlow, WaitState>(state, suspended, "ok");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "then-before", "then-after:ok", "end" }));
        Assert.That(suspended.Checkpoint!.Frame.Branch, Is.EqualTo(CatCheckpointBranches.Then));
    }

    [Test]
    public async Task Switch_ResumeStaysInTheSavedCase()
    {
        var state = new WaitState { Kind = TestKind.A };
        var suspended = await RunAsync<SwitchWaitFlow, WaitState>(state);
        state.Kind = TestKind.B;

        var result = await ResumeAsync<SwitchWaitFlow, WaitState>(state, suspended, "ok");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "A:ok", "end" }));
        Assert.That(suspended.Checkpoint!.Frame.CaseValue, Is.EqualTo("A"));
    }

    [Test]
    public async Task While_SuspendsInEveryPass_AndResumesTheLoop()
    {
        var state = new WaitState();
        var result = await RunAsync<WhileWaitFlow, WaitState>(state);

        foreach (var answer in new[] { "a", "b", "c" })
        {
            Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
            result = await ResumeAsync<WhileWaitFlow, WaitState>(state, result, answer);
        }

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "pass1:a", "pass2:b", "pass3:c", "end" }));
    }

    [Test]
    public async Task Foreach_ResumesAtTheSavedItem_AndKeepsTheLoopState()
    {
        var state = new WaitState();
        var result = await RunAsync<ForeachWaitFlow, WaitState>(state);

        var frame = result.Checkpoint!.Frame;
        Assert.That(frame.Iteration, Is.EqualTo(0));
        Assert.That(frame.ItemCount, Is.EqualTo(3));
        Assert.That(frame.LoopStateType, Does.Contain(nameof(WaitForeachState)));
        Assert.That(((WaitForeachState)frame.LoopState!).ParentWorkflowState, Is.Null);

        foreach (var answer in new[] { "x", "y", "z" })
        {
            Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
            result = await ResumeAsync<ForeachWaitFlow, WaitState>(state, result, answer);
        }

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end" }));
    }

    [Test]
    public async Task Foreach_LoopStateSurvivesAcrossResumes()
    {
        var state = new WaitState();
        var result = await RunAsync<ForeachWaitFlow, WaitState>(state);
        result = await ResumeAsync<ForeachWaitFlow, WaitState>(state, result, "x");
        result = await ResumeAsync<ForeachWaitFlow, WaitState>(state, result, "y");

        var loopState = (WaitForeachState)result.Checkpoint!.Frame.LoopState!;
        Assert.That(loopState.Collected, Is.EqualTo(new[] { "1:x", "2:y" }));
        Assert.That(result.Checkpoint.Frame.Iteration, Is.EqualTo(2));
    }

    [Test]
    public async Task Foreach_CollectionCountChanged_Throws()
    {
        var state = new WaitState();
        var suspended = await RunAsync<ForeachWaitFlow, WaitState>(state);
        state.Items.Add(4);

        var exception = await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<ForeachWaitFlow, WaitState>(state, suspended, "x"));
        Assert.That(exception!.Message, Does.Contain("collection"));
    }

    [Test]
    public async Task SubWorkflow_SuspendsAndResumesInsideTheSubWorkflow()
    {
        var state = new WaitParentState();
        var suspended = await RunAsync<SubWaitFlow, WaitParentState>(state);

        Assert.That(suspended.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(suspended.Checkpoint!.Version, Is.EqualTo(5));
        Assert.That(suspended.Checkpoint.Frame.StepName, Is.EqualTo("sub"));
        Assert.That(suspended.Checkpoint.Frame.WorkflowVersion, Is.EqualTo(2));
        Assert.That(suspended.Checkpoint.Frame.Child!.StepName, Is.EqualTo("wait"));
        Assert.That(state.Trace, Is.EqualTo(new[] { "parent-before" }));

        var result = await ResumeAsync<SubWaitFlow, WaitParentState>(state, suspended, "sub-answer");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.WorkflowState.Trace, Is.EqualTo(new[] { "before", "after:sub-answer" }));
        Assert.That(state.Trace, Is.EqualTo(new[] { "parent-before", "parent-after:sub-answer" }));
    }

    [Test]
    public async Task SubWorkflow_OtherSubWorkflowVersion_Throws()
    {
        var state = new WaitParentState();
        var suspended = await RunAsync<SubWaitFlow, WaitParentState>(state);
        suspended.Checkpoint!.Frame.WorkflowVersion = 1;

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<SubWaitFlow, WaitParentState>(state, suspended, "x"));
    }

    #endregion

    #region Parallel

    [Test]
    public async Task Parallel_FailFast_SuspendedBranchStopsTheLaterBranches()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelFailFastFlow, WaitState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        var branches = result.Checkpoint!.Frame.Branches;
        Assert.That(branches.Select(b => b.Status), Is.EqualTo(new[] { CatParallelBranchStatus.Suspended, CatParallelBranchStatus.NotStarted }));
    }

    [Test]
    public async Task Parallel_FailFast_ResumeStartsTheNextBranch()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelFailFastFlow, WaitState>(state);

        result = await ResumeAsync<ParallelFailFastFlow, WaitState>(state, result, "paid");
        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(result.Checkpoint!.Frame.Branches.Select(b => b.Status),
            Is.EqualTo(new[] { CatParallelBranchStatus.Done, CatParallelBranchStatus.Suspended }));

        result = await ResumeAsync<ParallelFailFastFlow, WaitState>(state, result, "reserved");
        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end:paid:reserved" }));
    }

    [Test]
    public async Task Parallel_FailFast_FailureStopsTheLaterBranches()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelFailFastFailingFlow, WaitState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Trace, Is.EqualTo(new[] { "branch1" }));
    }

    [Test]
    public async Task Parallel_UntilAllDone_AllBranchesWaitAtOnce()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelWaitFlow, WaitState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(result.Checkpoint!.Frame.Leaves().Select(l => l.StepName), Is.EqualTo(new[] { "payment", "stock" }));
    }

    [Test]
    public async Task Parallel_UntilAllDone_AnswersInAnyOrderFinishTheStep()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelWaitFlow, WaitState>(state);

        result = await ResumeAsync<ParallelWaitFlow, WaitState>(state, result, "reserved", "stock");
        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(result.Checkpoint!.Frame.Leaves().Select(l => l.StepName), Is.EqualTo(new[] { "payment" }));

        result = await ResumeAsync<ParallelWaitFlow, WaitState>(state, result, "paid");
        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end:paid:reserved" }));
    }

    [Test]
    public async Task Parallel_SeveralWaitingSteps_ResumeWithoutTargetThrows()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelWaitFlow, WaitState>(state);

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<ParallelWaitFlow, WaitState>(state, result, "x"));
    }

    [Test]
    public async Task Parallel_UnknownTarget_Throws()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelWaitFlow, WaitState>(state);

        await Assert.ThrowsAsync<CatWorkflowResumeException>(() => ResumeAsync<ParallelWaitFlow, WaitState>(state, result, "x", "shipping"));
    }

    [Test]
    public async Task Parallel_UntilAllDone_FailureEndsTheStepAtOnce()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelUntilAllDoneFailingFlow, WaitState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.Trace, Is.EqualTo(new[] { "branch2" }));
    }

    [Test]
    public async Task Parallel_WaitForAll_FailureWaitsForTheOtherBranch()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelFailingBranchFlow, WaitState>(state);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(result.Checkpoint!.Frame.Branches.Select(b => b.Status),
            Is.EqualTo(new[] { CatParallelBranchStatus.Failed, CatParallelBranchStatus.Suspended }));

        result = await ResumeAsync<ParallelFailingBranchFlow, WaitState>(state, result, "reserved");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.BreakCascade));
        Assert.That(state.StockAnswer, Is.EqualTo("reserved"));
        Assert.That(state.Trace, Is.EqualTo(new[] { "branch1", "branch2" }));
    }

    [Test]
    public async Task Parallel_WaitForAll_WithoutFailureFinishes()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelWaitForAllFlow, WaitState>(state);

        result = await ResumeAsync<ParallelWaitForAllFlow, WaitState>(state, result, "paid", "payment");
        result = await ResumeAsync<ParallelWaitForAllFlow, WaitState>(state, result, "reserved", "stock");

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Continue));
        Assert.That(state.Trace, Is.EqualTo(new[] { "end:paid:reserved" }));
    }

    [Test]
    public async Task Parallel_CheckpointThatWentThroughJson_Works()
    {
        var state = new WaitState();
        var result = await RunAsync<ParallelWaitFlow, WaitState>(state);
        var restored = JsonSerializer.Deserialize<CatWorkflowCheckpoint>(JsonSerializer.Serialize(result.Checkpoint))!;

        using var scope = ServiceProvider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        result = await processor.ResumeAsync<ParallelWaitFlow, WaitState>(state, restored, "reserved", "stock", CancellationToken.None);

        Assert.That(result.WorkflowResult, Is.EqualTo(CatStepExecutionResult.Suspend));
        Assert.That(result.Checkpoint!.Frame.Leaves().Select(l => l.StepName), Is.EqualTo(new[] { "payment" }));
    }

    #endregion
}
