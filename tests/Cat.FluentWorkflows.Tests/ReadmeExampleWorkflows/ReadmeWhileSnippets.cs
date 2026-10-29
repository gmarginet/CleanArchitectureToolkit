using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace Cat.FluentWorkflows.Tests.ReadmeExampleWorkflows;

public record ReadmeWhileSnippetsState : ICatWorkflowState<ReadmeWhileSnippetsState>
{
    public int Attempts { get; set; }
    public string Status { get; set; } = "New";
}

public class ReadmeWhileSnippets : ICatWorkflow<ReadmeWhileSnippetsState>
{
    public void Build(ICatWorkflowBuilder<ReadmeWhileSnippetsState> builder)
    {
        builder.While(s => s.Attempts < 3, loop =>
        {
            loop.Run(s => s.Attempts++);
            loop.LogInformation("Attempt {attempts}", s => [s.Attempts]);
        });

        builder.While(s => s.Attempts < 10, loop =>
        {
            loop.Run(s => s.Attempts++);
            loop.BreakFromLoopIf(s => s.Status == "Done");
        });

        builder.While(s => s.Attempts < 10, loop =>
        {
            loop.Run(s => s.Attempts++);
            loop.BreakCascadeIf(s => s.Status == "Failed");
        });
    }
}
