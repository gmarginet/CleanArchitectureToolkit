using Cat.FluentWorkflows.Abstractions;
using ServiceName.CoreService.Messages;

namespace ServiceName.CoreService.Workflows;

/// <summary>The data of one instance of <see cref="ItemNameSaga"/>. It is saved while the saga waits.</summary>
public class ItemNameSagaState : ICatWorkflowState<ItemNameSagaState>
{
    public Guid Id { get; set; }

    public ItemNameAnswered? Answer { get; set; }

    public bool Done { get; set; }
}
