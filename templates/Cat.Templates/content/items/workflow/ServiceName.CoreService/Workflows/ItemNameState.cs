using Cat.FluentWorkflows.Abstractions;

namespace ServiceName.CoreService.Workflows;

/// <summary>The data of one run of <see cref="ItemNameWorkflow"/>. The steps read from it and write to it.</summary>
public class ItemNameState : ICatWorkflowState<ItemNameState>
{
    public bool Done { get; set; }
}
