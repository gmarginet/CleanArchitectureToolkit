using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Workflows;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.SuspendResume;

public record WaitState : ICatWorkflowState<WaitState>
{
    public List<string> Trace { get; } = [];
    public int Number { get; set; }
    public TestKind Kind { get; set; }
    public int Counter { get; set; }
    public List<int> Items { get; set; } = [1, 2, 3];
    public List<string> Collected { get; } = [];
    public string Answer { get; set; } = "";
    public string PaymentAnswer { get; set; } = "";
    public string StockAnswer { get; set; } = "";
}

public record WaitParentState : ICatWorkflowState<WaitParentState>, ICatHasSubWorkflowState<WaitState>
{
    public List<string> Trace { get; } = [];
    public WaitState WorkflowState { get; set; } = new();
}

public class WaitForeachState : ICatForeachState<int, WaitState>, ICatWorkflowState<WaitForeachState>
{
    public int CurrentItem { get; set; }
    public WaitState ParentWorkflowState { get; set; } = null!;
    public string Answer { get; set; } = "";
    public List<string> Collected { get; set; } = [];
}

/// <summary>
/// Suspends in RunAsync and takes a string answer in ResumeAsync.
/// </summary>
public class WaitStep : CatResumableStepBody<string>
{
    public WaitStep(ILogger<WaitStep> logger) : base(logger)
    {
    }

    public string Answer { get; private set; } = "";

    public override Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(CatWorkflowResponse.Suspended());
    }

    protected override Task<ICatWorkflowResponse> ResumeAsync(string answer, CancellationToken cancellationToken)
    {
        Answer = answer;
        return Task.FromResult(CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue));
    }
}

/// <summary>
/// Suspends, but cannot take an answer.
/// </summary>
public class SuspendOnlyStep : CatStepBodyAsync
{
    public SuspendOnlyStep(ILogger<SuspendOnlyStep> logger) : base(logger)
    {
    }

    public override Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(CatWorkflowResponse.Suspended());
    }
}

public class SimpleWaitFlow : ICatWorkflow<WaitState>, ICatVersionedWorkflow
{
    public int Version => 2;

    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Run(s => s.Trace.Add("before"));
        builder.Run<WaitState, WaitStep>().Named("wait").Output(w => w.Answer, s => s.Answer);
        builder.Run(s => s.Trace.Add("after:" + s.Answer));
    }
}

public class SuspendOnlyFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Run<WaitState, SuspendOnlyStep>().Named("stuck");
    }
}

public class IfWaitFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.If(s => s.Number > 0,
            t =>
            {
                t.Run(s => s.Trace.Add("then-before"));
                t.Run<WaitState, WaitStep>().Named("wait").Output(w => w.Answer, s => s.Answer);
                t.Run(s => s.Trace.Add("then-after:" + s.Answer));
            },
            e => e.Run(s => s.Trace.Add("else")));
        builder.Run(s => s.Trace.Add("end"));
    }
}

public class SwitchWaitFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Switch(s => s.Kind, c =>
        {
            c.Case(TestKind.A, x =>
            {
                x.Run<WaitState, WaitStep>().Named("wait").Output(w => w.Answer, s => s.Answer);
                x.Run(s => s.Trace.Add("A:" + s.Answer));
            });
            c.Default(x => x.Run(s => s.Trace.Add("default")));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}

public class WhileWaitFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.While(s => s.Counter < 3, w =>
        {
            w.Run(s => s.Counter++);
            w.Run<WaitState, WaitStep>().Named("wait").Output(x => x.Answer, s => s.Answer);
            w.Run(s => s.Trace.Add("pass" + s.Counter + ":" + s.Answer));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}

public class ForeachWaitFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Foreach<WaitState, int, WaitForeachState>(s => s.Items, f =>
        {
            f.Run<WaitForeachState, WaitStep>().Named("wait").Output(w => w.Answer, fs => fs.Answer);
            f.Run(fs => fs.Collected.Add(fs.CurrentItem + ":" + fs.Answer));
        });
        builder.Run(s => s.Trace.Add("end"));
    }
}

public class SubWaitFlow : ICatWorkflow<WaitParentState>, ICatVersionedWorkflow
{
    public int Version => 5;

    public void Build(ICatWorkflowBuilder<WaitParentState> builder)
    {
        builder.Run(s => s.Trace.Add("parent-before"));
        builder.Run<SimpleWaitFlow, WaitState, WaitParentState>().Named("sub");
        builder.Run(s => s.Trace.Add("parent-after:" + s.WorkflowState.Answer));
    }
}

public class ParallelFailFastFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Parallel(p => p
            .Branch(b => b.Run<WaitState, WaitStep>().Named("payment").Output(w => w.Answer, s => s.PaymentAnswer))
            .Branch(b => b.Run<WaitState, WaitStep>().Named("stock").Output(w => w.Answer, s => s.StockAnswer)));
        builder.Run(s => s.Trace.Add("end:" + s.PaymentAnswer + ":" + s.StockAnswer));
    }
}

public class ParallelWaitFlow : ICatWorkflow<WaitState>
{
    private readonly CatParallelRule _rule;

    public ParallelWaitFlow() : this(CatParallelRule.SuspendUntilAllDone)
    {
    }

    protected ParallelWaitFlow(CatParallelRule rule)
    {
        _rule = rule;
    }

    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Parallel(p => p
            .Branch(b => b.Run<WaitState, WaitStep>().Named("payment").Output(w => w.Answer, s => s.PaymentAnswer))
            .Branch(b => b.Run<WaitState, WaitStep>().Named("stock").Output(w => w.Answer, s => s.StockAnswer)), _rule);
        builder.Run(s => s.Trace.Add("end:" + s.PaymentAnswer + ":" + s.StockAnswer));
    }
}

public class ParallelWaitForAllFlow : ParallelWaitFlow
{
    public ParallelWaitForAllFlow() : base(CatParallelRule.WaitForAll)
    {
    }
}

public class ParallelFailingBranchFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Parallel(p => p
            .Branch(b =>
            {
                b.Run(s => s.Trace.Add("branch1"));
                b.BreakCascade();
            })
            .Branch(b =>
            {
                b.Run(s => s.Trace.Add("branch2"));
                b.Run<WaitState, WaitStep>().Named("stock").Output(w => w.Answer, s => s.StockAnswer);
            }), CatParallelRule.WaitForAll);
        builder.Run(s => s.Trace.Add("end"));
    }
}

public class ParallelFailFastFailingFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Parallel(p => p
            .Branch(b =>
            {
                b.Run(s => s.Trace.Add("branch1"));
                b.BreakCascade();
            })
            .Branch(b => b.Run(s => s.Trace.Add("branch2"))));
        builder.Run(s => s.Trace.Add("end"));
    }
}

public class ParallelUntilAllDoneFailingFlow : ICatWorkflow<WaitState>
{
    public void Build(ICatWorkflowBuilder<WaitState> builder)
    {
        builder.Parallel(p => p
            .Branch(b => b.Run<WaitState, WaitStep>().Named("payment").Output(w => w.Answer, s => s.PaymentAnswer))
            .Branch(b =>
            {
                b.Run(s => s.Trace.Add("branch2"));
                b.BreakCascade();
            }), CatParallelRule.SuspendUntilAllDone);
        builder.Run(s => s.Trace.Add("end"));
    }
}
