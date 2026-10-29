using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Cat.Decorators.Abstractions;
using Cat.Queries.Abstractions;
using Cat.Responses.Abstractions;
using Nito.AsyncEx;

namespace Cat.Queries;

/// <summary>
/// Default <see cref="ICatQueryProcessor"/>.
/// Opens a new scope per query, gets the decorated handler from it and invokes the handler.
/// </summary>
internal class CatQueryProcessor : ICatQueryProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICatDecoratorFactory _decoratorFactory;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Used to open a scope for each query.</param>
    /// <param name="decoratorFactory">Builds the handler together with its registered decorators.</param>
    public CatQueryProcessor(IServiceProvider serviceProvider, ICatDecoratorFactory decoratorFactory)
    {
        _serviceProvider = serviceProvider;
        _decoratorFactory = decoratorFactory;
    }

    /// <inheritdoc />
    public async Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        
        var queryType = catQuery.GetType();
        var handlerType = typeof(ICatQueryHandler<,>).MakeGenericType(queryType, typeof(TQueryResult));
        var handler = _decoratorFactory.GetRequiredDecoratedService(scope.ServiceProvider, handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<ICatResponse<TQueryResult>>)InvokeHandler(method!, handler, catQuery, cancellationToken);
        var result = await task;

        return result;
    }

    /// <summary>
    /// Calls the handler. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a <see cref="TargetInvocationException"/>.
    /// </summary>
    private static object InvokeHandler(MethodInfo method, object handler, object query, CancellationToken cancellationToken)
    {
        try
        {
            return method.Invoke(handler, [query, cancellationToken])!;
        }
        catch (TargetInvocationException exception) when (exception.InnerException is not null)
        {
            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            throw;
        }
    }

    /// <inheritdoc />
    public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
    {
        return AsyncContext.Run(() => ProcessAsync(catQuery));
    }
}