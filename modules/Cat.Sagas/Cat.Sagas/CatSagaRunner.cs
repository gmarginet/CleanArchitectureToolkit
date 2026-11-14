using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Sagas.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// Default <see cref="ICatSagaRunner"/>.
/// </summary>
internal sealed class CatSagaRunner : ICatSagaRunner
{
    private readonly ICatWorkflowProcessor _processor;
    private readonly CatSagaRegistry _registry;
    private readonly CatSagaContext _context;
    private readonly CatSagaEngine _engine;

    public CatSagaRunner(ICatWorkflowProcessor processor, CatSagaRegistry registry, CatSagaContext context, CatSagaEngine engine)
    {
        _processor = processor;
        _registry = registry;
        _context = context;
        _engine = engine;
    }

    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">The workflow is not registered with <c>AddCatSaga</c>.</exception>
    public async Task<CatSagaResult> StartAsync<TWorkflow, TWorkflowState>(TWorkflowState state, Guid? correlationId = null,
        CancellationToken cancellationToken = default)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var definition = _registry.Find(typeof(TWorkflow))
                         ?? throw new InvalidOperationException(
                             $"The saga {typeof(TWorkflow).Name} is not registered. Call AddCatSaga<{typeof(TWorkflow).Name}, {typeof(TWorkflowState).Name}>().");

        var id = correlationId ?? Guid.NewGuid();
        _context.Begin(id);

        var response = await _processor.RunAsync<TWorkflow, TWorkflowState>(state, cancellationToken);
        return await _engine.FinishAsync(definition, null, id, state, response, cancellationToken);
    }
}
