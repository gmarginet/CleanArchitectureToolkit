using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record BreakCascadeIfWithLoggerFlowState : ICatWorkflowState<BreakCascadeIfWithLoggerFlowState>
{
    public int Number { get; set; }
    public List<string> Trace { get; } = [];
}

public class BreakCascadeIfWithLoggerFlow : ICatWorkflow<BreakCascadeIfWithLoggerFlowState>
{
    public void Build(ICatWorkflowBuilder<BreakCascadeIfWithLoggerFlowState> builder)
    {
        builder.Run(s => s.Trace.Add("1"));
        builder.BreakCascadeIf((logger, s) =>
        {
            logger.LogInformation("checking {n}", s.Number);
            return s.Number == 1;
        });
        builder.Run(s => s.Trace.Add("2"));
    }
}
