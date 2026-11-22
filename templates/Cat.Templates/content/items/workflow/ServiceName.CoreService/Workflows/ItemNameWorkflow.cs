using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

namespace ServiceName.CoreService.Workflows;

/// <summary>The workflow ItemNameWorkflow. The steps run in the order you add them. Replace the first step with your own.</summary>
public class ItemNameWorkflow : ICatWorkflow<ItemNameState>
{
    public void Build(ICatWorkflowBuilder<ItemNameState> builder)
    {
        builder.Run(s => s.Done = true);
    }
}
