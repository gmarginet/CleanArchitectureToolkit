using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Responses;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeRunSnippetsState : ICatWorkflowState<ReadmeRunSnippetsState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public int Attempts { get; set; }
}

public class ReadmeRunSnippets : ICatWorkflow<ReadmeRunSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeRunSnippetsState> builder)
    {
        builder.Run(s => s.Attempts++);

        builder.Run((logger, s) => logger.LogInformation("Order has {count} lines", s.Lines.Count));

        builder.Run(s =>
        {
            if (s.Lines.Count == 0)
            {
                return CatResponse.BadRequest<CatStepExecutionResult>(
                    CatError.Create("ORD-1001", "An order needs at least one line."));
            }

            return CatResponse.Ok(CatStepExecutionResult.Continue);
        });
    }
}
