using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Cat.Decorators.Abstractions;
using Cat.Responses.Abstractions;
using Nito.AsyncEx;

namespace Cat.ServiceRequests;

/// <summary>
/// Default <see cref="ICatServiceRequestProcessor"/>.
/// Opens a new scope per request, gets the decorated handler from it and invokes the handler.
/// </summary>
internal class CatServiceRequestProcessor : ICatServiceRequestProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICatDecoratorFactory _decoratorFactory;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Used to open a scope for each request.</param>
    /// <param name="decoratorFactory">Builds the handler together with its registered decorators.</param>
    public CatServiceRequestProcessor(IServiceProvider serviceProvider, ICatDecoratorFactory decoratorFactory)
    {
        _serviceProvider = serviceProvider;
        _decoratorFactory = decoratorFactory;
    }

    /// <inheritdoc />
    public async Task<ICatResponse> ProcessAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        
        var serviceRequestType = catServiceRequest.GetType();
        var handlerType = typeof(ICatServiceRequestHandler<>).MakeGenericType(serviceRequestType);
        var handler = _decoratorFactory.GetRequiredDecoratedService(scope.ServiceProvider, handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<ICatResponse>)InvokeHandler(method!, handler, catServiceRequest, cancellationToken);
        var result = await task;
        
        return result;
    }

    /// <inheritdoc />
    public async Task<ICatResponse<TResponse>> ProcessAsync<TResponse>(ICatServiceRequest<TResponse> catServiceRequest, CancellationToken cancellationToken = default)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        
        var serviceRequestType = catServiceRequest.GetType();
        var handlerType = typeof(ICatServiceRequestHandler<,>).MakeGenericType(serviceRequestType, typeof(TResponse));
        var handler = _decoratorFactory.GetRequiredDecoratedService(scope.ServiceProvider, handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<ICatResponse<TResponse>>)InvokeHandler(method!, handler, catServiceRequest, cancellationToken);
        var result = await task;

        return result;
    }

    /// <summary>
    /// Calls the handler. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a <see cref="TargetInvocationException"/>.
    /// </summary>
    private static object InvokeHandler(MethodInfo method, object handler, object serviceRequest, CancellationToken cancellationToken)
    {
        try
        {
            return method.Invoke(handler, [serviceRequest, cancellationToken])!;
        }
        catch (TargetInvocationException exception) when (exception.InnerException is not null)
        {
            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            throw;
        }
    }

    /// <inheritdoc />
    public ICatResponse Process(ICatServiceRequest catServiceRequest)
    {
        return AsyncContext.Run(() => ProcessAsync(catServiceRequest));
    }

    /// <inheritdoc />
    public ICatResponse<TResponse> Process<TResponse>(ICatServiceRequest<TResponse> catServiceRequest)
    {
        return AsyncContext.Run(() => ProcessAsync(catServiceRequest));
    }
}