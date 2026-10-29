using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record LogFlowState : ICatWorkflowState<LogFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class LogFlow : ICatWorkflow<LogFlowState>
{
    public void Build(ICatWorkflowBuilder<LogFlowState> builder)
    {
        builder.LogInformation("hello {number}", s => [s.Number]);
        builder.Run(s => s.Trace.Add("logged"));
    }
}
