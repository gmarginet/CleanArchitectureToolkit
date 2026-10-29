using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.Workflows;

public record LogLevelsFlowState : ICatWorkflowState<LogLevelsFlowState>
{
    public int Number { get; set; }
}

public class LogLevelsFlow : ICatWorkflow<LogLevelsFlowState>
{
    public void Build(ICatWorkflowBuilder<LogLevelsFlowState> builder)
    {
        builder.LogTrace("trace {n}", s => [s.Number]);
        builder.LogDebug("debug {n}", s => [s.Number]);
        builder.LogInformation("information {n}", s => [s.Number]);
        builder.LogWarning("warning {n}", s => [s.Number]);
        builder.LogError("error {n}", s => [s.Number]);
        builder.LogCritical("critical {n}", s => [s.Number]);
        builder.Log(LogLevel.Warning, "custom {n} and {m}", s => [s.Number, s.Number * 2]);
    }
}
