using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record SubWorkflowState : ICatWorkflowState<SubWorkflowState>
{
    public string Message { get; set; } = "";
}

public class SubWorkflow : ICatWorkflow<SubWorkflowState>
{
    public void Build(ICatWorkflowBuilder<SubWorkflowState> builder)
    {
        builder.Run(s => s.Message = "sub-ran");
    }
}
