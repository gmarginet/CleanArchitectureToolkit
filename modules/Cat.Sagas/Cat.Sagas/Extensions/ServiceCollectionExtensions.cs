using Cat.FluentWorkflows.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.Sagas.Steps;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Sagas.Extensions;

/// <summary>
/// Registration helpers for the sagas module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the runner, the dispatcher, the JSON serializer and the wait step.
    /// Register a store too, such as <see cref="AddCatSagasInMemoryStore"/>. The module needs the fluent workflows module and the messaging module as well.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatSagasModule(this IServiceCollection services)
    {
        services.TryAddSingleton<ICatSagaSerializer, SystemTextJsonSagaSerializer>();
        services.TryAddScoped<CatSagaContext>();
        services.TryAddScoped<ICatSagaContext>(provider => provider.GetRequiredService<CatSagaContext>());
        services.TryAddSingleton<CatSagaRegistry>();
        services.TryAddScoped<CatSagaEngine>();
        services.TryAddScoped<ICatSagaRunner, CatSagaRunner>();
        services.TryAddScoped<ICatSagaDispatcher, CatSagaDispatcher>();
        services.TryAddTransient(typeof(CatSendAndWaitStep<,>));
    }

    /// <summary>
    /// Registers the store that keeps the instances in memory. Use it for tests and for trying a saga, not for a real service.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatSagasInMemoryStore(this IServiceCollection services)
    {
        services.TryAddSingleton<ICatSagaStore, CatInMemorySagaStore>();
    }

    /// <summary>
    /// Registers a workflow as a saga, so the runner can start it and the dispatcher can resume it.
    /// The workflow itself is registered by the fluent workflows module.
    /// </summary>
    /// <typeparam name="TWorkflow">The workflow.</typeparam>
    /// <typeparam name="TWorkflowState">The state of the workflow. It must be serializable.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatSaga<TWorkflow, TWorkflowState>(this IServiceCollection services)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        services.AddSingleton<ICatSagaDefinition, CatSagaDefinition<TWorkflow, TWorkflowState>>();
    }

    /// <summary>
    /// Registers the handler that gives an answer message to the waiting saga. Declare the message type with <c>Receive</c> on the event processor too.
    /// </summary>
    /// <typeparam name="TAnswer">The answer message. It is a message and a service request at the same time.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatSagaAnswer<TAnswer>(this IServiceCollection services)
        where TAnswer : class, ICatMessage, ICatServiceRequest
    {
        services.AddScoped<ICatServiceRequestHandler<TAnswer>, CatSagaAnswerHandler<TAnswer>>();
    }
}
