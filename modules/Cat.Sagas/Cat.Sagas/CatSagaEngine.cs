using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.Sagas.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// The part that runner and dispatcher share. It turns the outcome of a workflow run into a saved instance,
/// and sends the request messages only after the instance is saved. An answer can then never arrive before its instance exists.
/// </summary>
internal sealed class CatSagaEngine
{
    private readonly ICatSagaStore _store;
    private readonly ICatSagaSerializer _serializer;
    private readonly CatSagaContext _context;
    private readonly ICatMessageSender _sender;

    public CatSagaEngine(ICatSagaStore store, ICatSagaSerializer serializer, CatSagaContext context, ICatMessageSender sender)
    {
        _store = store;
        _serializer = serializer;
        _context = context;
        _sender = sender;
    }

    public async Task<CatSagaResult> FinishAsync(ICatSagaDefinition definition, CatSagaInstance? instance, Guid id, object state,
        ICatWorkflowResponse response, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        if (response.WorkflowResult == CatStepExecutionResult.Suspend)
        {
            var checkpoint = response.Checkpoint
                             ?? throw new InvalidOperationException("The workflow suspended without a checkpoint.");
            var isNew = instance == null;
            instance ??= new CatSagaInstance { Id = id, WorkflowType = definition.Name, CreatedAt = now };

            instance.Status = CatSagaStatus.Waiting;
            instance.State = _serializer.Serialize(state, definition.StateType);
            instance.Checkpoint = _serializer.Serialize(checkpoint, typeof(CatWorkflowCheckpoint));
            instance.WorkflowVersion = checkpoint.Version;
            instance.WaitingFor = _context.WaitingFor;
            instance.UpdatedAt = now;

            if (isNew)
            {
                await _store.AddAsync(instance, cancellationToken);
            }
            else
            {
                await _store.UpdateAsync(instance, cancellationToken);
            }

            await SendPendingAsync(cancellationToken);
            return new CatSagaResult(id, CatSagaStatus.Waiting, response.ErrorList);
        }

        var status = response.ErrorList.Count > 0 ? CatSagaStatus.Failed : CatSagaStatus.Completed;

        if (instance != null)
        {
            instance.Status = status;
            instance.State = _serializer.Serialize(state, definition.StateType);
            instance.Checkpoint = null;
            instance.WaitingFor = null;
            instance.UpdatedAt = now;
            await _store.UpdateAsync(instance, cancellationToken);
        }

        return new CatSagaResult(id, status, response.ErrorList);
    }

    private async Task SendPendingAsync(CancellationToken cancellationToken)
    {
        foreach (var message in _context.Pending)
        {
            switch (message)
            {
                case ICatCommandMessage command:
                    await _sender.SendAsync(command, null, cancellationToken);
                    break;
                case ICatEventMessage @event:
                    await _sender.PublishAsync(@event, null, cancellationToken);
                    break;
                default:
                    throw new InvalidOperationException(
                        $"The message {message.GetType().Name} is neither an event nor a command message, so it cannot be sent.");
            }
        }

        _context.Pending.Clear();
    }
}
