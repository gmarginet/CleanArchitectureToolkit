using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Sagas.Extensions;
using ServiceName.CoreService.Messages;

namespace ServiceName.CoreService.Workflows;

/// <summary>
/// The saga ItemNameSaga. It sends <see cref="ItemNameRequested"/> and waits for <see cref="ItemNameAnswered"/>.
/// The name of the wait step must never change, because the saved position points at it.
/// </summary>
public class ItemNameSaga : ICatWorkflow<ItemNameSagaState>
{
    public void Build(ICatWorkflowBuilder<ItemNameSagaState> builder)
    {
        builder.SendAndWait<ItemNameSagaState, ItemNameRequested, ItemNameAnswered>("item-name-answer")
            .Input(state => state.Id, step => step.Request.Id)
            .Output(step => step.Answer, state => state.Answer);

        builder.Run(state => state.Done = true);
    }
}
