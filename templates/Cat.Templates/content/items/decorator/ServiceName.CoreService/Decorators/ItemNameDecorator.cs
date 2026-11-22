using Cat.Decorators.Abstractions;
#if (ForCommand)
using Cat.Commands.Abstractions;
#endif
#if (ForQuery)
using Cat.Queries.Abstractions;
#endif
#if (ForServiceRequest)
using Cat.ServiceRequests.Abstractions;
#endif
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceName.CoreService.Decorators;

/// <summary>
/// The decorator ItemName for the handlers of the service. Each handler passes through it.
/// Call <see cref="AddItemNameDecorator"/> on the built service provider to switch it on.
/// </summary>
public static class ItemNameDecorator
{
    /// <summary>Adds the decorator to the handlers. A smaller order sits further out.</summary>
    public static void AddItemNameDecorator(this IServiceProvider serviceProvider, int? order = null)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        var decoratorOrder = order ?? CatDecoratorOrder.Default;
#if (ForCommand)
        decoratorFactory.AddDecorator(typeof(ICatCommandHandler<>), typeof(CommandHandler<>), decoratorOrder);
        decoratorFactory.AddDecorator(typeof(ICatCommandHandler<,>), typeof(CommandHandler<,>), decoratorOrder);
#endif
#if (ForQuery)
        decoratorFactory.AddDecorator(typeof(ICatQueryHandler<,>), typeof(QueryHandler<,>), decoratorOrder);
#endif
#if (ForServiceRequest)
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<>), typeof(ServiceRequestHandler<>), decoratorOrder);
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<,>), typeof(ServiceRequestHandler<,>), decoratorOrder);
#endif
    }
#if (ForCommand)

    /// <summary>Wraps the handlers of commands without a result.</summary>
    public sealed class CommandHandler<TCommand>(ICatCommandHandler<TCommand> innerHandler) : ICatCommandHandler<TCommand>
        where TCommand : class, ICatCommand
    {
        public async Task<ICatResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            // Do your work before the handler.
            var response = await innerHandler.HandleAsync(command, cancellationToken);
            // Do your work after the handler.
            return response;
        }
    }

    /// <summary>Wraps the handlers of commands with a result.</summary>
    public sealed class CommandHandler<TCommand, TResult>(ICatCommandHandler<TCommand, TResult> innerHandler) : ICatCommandHandler<TCommand, TResult>
        where TCommand : class, ICatCommand<TResult>
    {
        public async Task<ICatResponse<TResult>> HandleAsync(TCommand command, CancellationToken cancellationToken = default)
        {
            // Do your work before the handler.
            var response = await innerHandler.HandleAsync(command, cancellationToken);
            // Do your work after the handler.
            return response;
        }
    }
#endif
#if (ForQuery)

    /// <summary>Wraps the handlers of queries.</summary>
    public sealed class QueryHandler<TQuery, TQueryResult>(ICatQueryHandler<TQuery, TQueryResult> innerHandler) : ICatQueryHandler<TQuery, TQueryResult>
        where TQuery : class, ICatQuery<TQueryResult>
    {
        public async Task<ICatResponse<TQueryResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default)
        {
            // Do your work before the handler.
            var response = await innerHandler.HandleAsync(query, cancellationToken);
            // Do your work after the handler.
            return response;
        }
    }
#endif
#if (ForServiceRequest)

    /// <summary>Wraps the handlers of service requests without a response.</summary>
    public sealed class ServiceRequestHandler<TRequest>(ICatServiceRequestHandler<TRequest> innerHandler) : ICatServiceRequestHandler<TRequest>
        where TRequest : class, ICatServiceRequest
    {
        public async Task<ICatResponse> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            // Do your work before the handler.
            var response = await innerHandler.HandleAsync(serviceRequest, cancellationToken);
            // Do your work after the handler.
            return response;
        }
    }

    /// <summary>Wraps the handlers of service requests with a response.</summary>
    public sealed class ServiceRequestHandler<TRequest, TResponse>(ICatServiceRequestHandler<TRequest, TResponse> innerHandler) : ICatServiceRequestHandler<TRequest, TResponse>
        where TRequest : class, ICatServiceRequest<TResponse>
    {
        public async Task<ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            // Do your work before the handler.
            var response = await innerHandler.HandleAsync(serviceRequest, cancellationToken);
            // Do your work after the handler.
            return response;
        }
    }
#endif
}
