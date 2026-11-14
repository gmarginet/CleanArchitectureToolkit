using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Sagas;

/// <summary>
/// Default <see cref="ICatSagaDispatcher"/>.
/// </summary>
internal sealed class CatSagaDispatcher : ICatSagaDispatcher
{
    private readonly ICatSagaStore _store;
    private readonly ICatSagaSerializer _serializer;
    private readonly ICatWorkflowProcessor _processor;
    private readonly CatSagaRegistry _registry;
    private readonly CatSagaContext _context;
    private readonly CatSagaEngine _engine;
    private readonly ILogger<CatSagaDispatcher> _logger;

    public CatSagaDispatcher(ICatSagaStore store, ICatSagaSerializer serializer, ICatWorkflowProcessor processor, CatSagaRegistry registry,
        CatSagaContext context, CatSagaEngine engine, ILogger<CatSagaDispatcher> logger)
    {
        _store = store;
        _serializer = serializer;
        _processor = processor;
        _registry = registry;
        _context = context;
        _engine = engine;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<ICatResponse> ResumeAsync(Guid correlationId, object answer, CancellationToken cancellationToken = default)
    {
        var instance = await _store.FindAsync(correlationId, cancellationToken);
        if (instance == null)
        {
            return CatResponse.NotFound(CatSagaErrors.InstanceNotFound(correlationId));
        }

        if (instance.Status != CatSagaStatus.Waiting)
        {
            _logger.LogInformation("The saga instance {InstanceId} is {Status}, so the answer {Answer} is ignored.",
                correlationId, instance.Status, answer.GetType().Name);
            return CatResponse.Ok();
        }

        var definition = _registry.Find(instance.WorkflowType);
        if (definition == null)
        {
            return CatResponse.InternalServerError(CatSagaErrors.WorkflowNotRegistered(instance.WorkflowType));
        }

        var state = _serializer.Deserialize(instance.State, definition.StateType);
        var checkpoint = (CatWorkflowCheckpoint)_serializer.Deserialize(instance.Checkpoint!, typeof(CatWorkflowCheckpoint));

        _context.Begin(correlationId);

        ICatWorkflowResponse response;
        try
        {
            response = await definition.ResumeAsync(_processor, state, checkpoint, answer, cancellationToken);
        }
        catch (CatWorkflowResumeException ex)
        {
            _logger.LogError(ex, "The saga instance {InstanceId} cannot be resumed with the answer {Answer}.", correlationId, answer.GetType().Name);
            return CatResponse.Conflict(CatSagaErrors.ResumeFailed(ex.Message));
        }

        await _engine.FinishAsync(definition, instance, correlationId, state, response, cancellationToken);
        return CatResponse.Ok();
    }
}
