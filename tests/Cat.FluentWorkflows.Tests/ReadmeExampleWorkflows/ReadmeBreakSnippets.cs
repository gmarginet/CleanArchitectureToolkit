using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeBreakSnippetsState : ICatWorkflowState<ReadmeBreakSnippetsState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public decimal Total { get; set; }
}

public class ReadmeBreakSnippets : ICatWorkflow<ReadmeBreakSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeBreakSnippetsState> builder)
    {
        builder.If(s => s.Lines.Count == 0, then =>
        {
            then.LogWarning("Empty order", s => []);
            then.BreakFromCurrentFlowOnly();
        });

        builder.BreakFromCurrentFlowOnlyIf(s => s.Lines.Count == 0);

        builder.BreakCascadeIf((logger, s) =>
        {
            logger.LogWarning("Total {total}", s.Total);
            return s.Total < 0;
        });
    }
}
