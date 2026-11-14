using System;
using System.Collections.Generic;
using System.Linq;
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
    private readonly CatSagaOptions _options;

    public CatSagaEngine(ICatSagaStore store, ICatSagaSerializer serializer, CatSagaContext context, ICatMessageSender sender, CatSagaOptions options)
    {
        _store = store;
        _serializer = serializer;
        _context = context;
        _sender = sender;
        _options = options;
    }

    public List<CatSagaWait> ReadWaits(CatSagaInstance instance)
    {
        return string.IsNullOrEmpty(instance.Waits)
            ? new List<CatSagaWait>()
            : (List<CatSagaWait>)_serializer.Deserialize(instance.Waits!, typeof(List<CatSagaWait>));
    }

    /// <summary>Saves the result of a run and sends the messages it collected.</summary>
    /// <param name="definition">The definition of the saga.</param>
    /// <param name="instance">The stored instance, or null for a new saga.</param>
    /// <param name="id">The instance id.</param>
    /// <param name="state">The workflow state after the run.</param>
    /// <param name="response">The workflow response of the run.</param>
    /// <param name="resolvedStep">The wait step that this run answered or timed out, or null for a new saga.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result with the status of the instance.</returns>
    public async Task<CatSagaResult> FinishAsync(ICatSagaDefinition definition, CatSagaInstance? instance, Guid id, object state,
        ICatWorkflowResponse response, string? resolvedStep, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;

        if (response.WorkflowResult == CatStepExecutionResult.Suspend)
        {
            var checkpoint = response.Checkpoint
                             ?? throw new InvalidOperationException("The workflow suspended without a checkpoint.");
            var isNew = instance == null;
            var before = instance == null ? new List<CatSagaWait>() : ReadWaits(instance);
            instance ??= new CatSagaInstance { Id = id, WorkflowType = definition.Name, CreatedAt = now };

            // The waits that stay open, plus the ones this run opened. A step that suspended again replaces its old wait.
            var open = before.Where(w => w.StepName != resolvedStep).Concat(_context.Waits).ToList();

            instance.Status = CatSagaStatus.Waiting;
            instance.State = _serializer.Serialize(state, definition.StateType);
            instance.Checkpoint = _serializer.Serialize(checkpoint, typeof(CatWorkflowCheckpoint));
            instance.WorkflowVersion = checkpoint.Version;
            instance.Waits = _serializer.Serialize(open, typeof(List<CatSagaWait>));
            instance.UpdatedAt = now;

            // With the outbox the sender only adds a row to the context, and the save commits it together with the instance.
            if (_options.SendBeforeSave)
            {
                await SendPendingAsync(cancellationToken);
            }

            if (isNew)
            {
                await _store.AddAsync(instance, cancellationToken);
            }
            else
            {
                await _store.UpdateAsync(instance, cancellationToken);
            }

            if (!_options.SendBeforeSave)
            {
                await SendPendingAsync(cancellationToken);
            }

            return new CatSagaResult(id, CatSagaStatus.Waiting, response.ErrorList);
        }

        var status = response.ErrorList.Count > 0 ? CatSagaStatus.Failed : CatSagaStatus.Completed;

        if (instance != null)
        {
            instance.Status = status;
            instance.State = _serializer.Serialize(state, definition.StateType);
            instance.Checkpoint = null;
            instance.Waits = null;
            instance.UpdatedAt = now;
            await _store.UpdateAsync(instance, cancellationToken);
        }

        return new CatSagaResult(id, status, response.ErrorList);
    }

    private async Task SendPendingAsync(CancellationToken cancellationToken)
    {
        foreach (var pending in _context.Pending)
        {
            switch (pending.Message)
            {
                case ICatCommandMessage command:
                    await _sender.SendAsync(command, pending.ScheduledAt, cancellationToken);
                    break;
                case ICatEventMessage @event:
                    await _sender.PublishAsync(@event, pending.ScheduledAt, cancellationToken);
                    break;
                default:
                    throw new InvalidOperationException(
                        $"The message {pending.Message.GetType().Name} is neither an event nor a command message, so it cannot be sent.");
            }
        }

        _context.Pending.Clear();
    }
}
