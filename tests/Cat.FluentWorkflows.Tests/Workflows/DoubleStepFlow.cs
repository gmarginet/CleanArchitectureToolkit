using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.FluentWorkflows.Tests.Steps;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record DoubleStepFlowState : ICatWorkflowState<DoubleStepFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class DoubleStepFlow : ICatWorkflow<DoubleStepFlowState>
{
    public void Build(ICatWorkflowBuilder<DoubleStepFlowState> builder)
    {
        builder.Run<DoubleStepFlowState, DoubleStep>()
            .Input(s => s.Number, step => step.Value)
            .Output(step => step.Result, s => s.Number);
        builder.Run(s => s.Trace.Add("n=" + s.Number));
    }
}
