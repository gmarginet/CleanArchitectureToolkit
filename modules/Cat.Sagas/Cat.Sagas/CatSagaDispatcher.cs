using System;
using System.Linq;
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

        var waits = _engine.ReadWaits(instance);
        string? problem = null;
        var target = waits.Count == 1 ? waits[0] : FindWaitFor(waits, answer, out problem);
        if (target == null)
        {
            _logger.LogError("The saga instance {InstanceId} cannot take the answer {Answer}: {Problem}", correlationId, answer.GetType().Name, problem);
            return CatResponse.Conflict(CatSagaErrors.ResumeFailed(problem ?? "No open wait."));
        }

        return await ResumeCoreAsync(instance, target.StepName, answer, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ICatResponse> TimeoutAsync(Guid correlationId, Guid waitId, CancellationToken cancellationToken = default)
    {
        var instance = await _store.FindAsync(correlationId, cancellationToken);
        if (instance == null)
        {
            return CatResponse.NotFound(CatSagaErrors.InstanceNotFound(correlationId));
        }

        var wait = instance.Status == CatSagaStatus.Waiting
            ? _engine.ReadWaits(instance).FirstOrDefault(w => w.WaitId == waitId)
            : null;

        if (wait == null)
        {
            _logger.LogInformation("The timeout of wait {WaitId} of saga instance {InstanceId} no longer applies, so it is ignored.", waitId, correlationId);
            return CatResponse.Ok();
        }

        return await ResumeCoreAsync(instance, wait.StepName, CatSagaTimedOut.Instance, cancellationToken);
    }

    private async Task<ICatResponse> ResumeCoreAsync(CatSagaInstance instance, string target, object answer, CancellationToken cancellationToken)
    {
        var definition = _registry.Find(instance.WorkflowType);
        if (definition == null)
        {
            return CatResponse.InternalServerError(CatSagaErrors.WorkflowNotRegistered(instance.WorkflowType));
        }

        var state = _serializer.Deserialize(instance.State, definition.StateType);
        var checkpoint = (CatWorkflowCheckpoint)_serializer.Deserialize(instance.Checkpoint!, typeof(CatWorkflowCheckpoint));

        _context.Begin(instance.Id);

        ICatWorkflowResponse response;
        try
        {
            response = await definition.ResumeAsync(_processor, state, checkpoint, answer, target, cancellationToken);
        }
        catch (CatWorkflowResumeException ex)
        {
            _logger.LogError(ex, "The saga instance {InstanceId} cannot be resumed with {Answer}.", instance.Id, answer.GetType().Name);
            return CatResponse.Conflict(CatSagaErrors.ResumeFailed(ex.Message));
        }

        await _engine.FinishAsync(definition, instance, instance.Id, state, response, target, cancellationToken);
        return CatResponse.Ok();
    }

    /// <summary>
    /// With several open waits, an answer goes to the wait whose answer type it fits. It must fit exactly one.
    /// </summary>
    private static CatSagaWait? FindWaitFor(System.Collections.Generic.List<CatSagaWait> waits, object answer, out string problem)
    {
        var fitting = waits.Where(w =>
        {
            var type = Type.GetType(w.AnswerType, throwOnError: false);
            return type != null && type.IsInstanceOfType(answer);
        }).ToList();

        problem = fitting.Count == 0
            ? $"The answer {answer.GetType().Name} fits none of the {waits.Count} open waits."
            : $"The answer {answer.GetType().Name} fits {fitting.Count} of the {waits.Count} open waits, so it is not clear which one gets it.";

        return fitting.Count == 1 ? fitting[0] : null;
    }
}
