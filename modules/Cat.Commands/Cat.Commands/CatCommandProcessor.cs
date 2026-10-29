using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Decorators.Abstractions;
using Cat.Responses.Abstractions;
using Nito.AsyncEx;

namespace Cat.Commands;

/// <summary>
/// Default <see cref="ICatCommandProcessor"/>.
/// Opens a new scope per command, gets the decorated handler from it and invokes the handler.
/// </summary>
internal class CatCommandProcessor : ICatCommandProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICatDecoratorFactory _decoratorFactory;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Used to open a scope for each command.</param>
    /// <param name="decoratorFactory">Builds the handler together with its registered decorators.</param>
    public CatCommandProcessor(IServiceProvider serviceProvider, ICatDecoratorFactory decoratorFactory)
    {
        _serviceProvider = serviceProvider;
        _decoratorFactory = decoratorFactory;
    }

    /// <inheritdoc />
    public async Task<ICatResponse> ProcessAsync(ICatCommand catCommand, CancellationToken cancellationToken = default)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        
        var commandType = catCommand.GetType();
        var handlerType = typeof(ICatCommandHandler<>).MakeGenericType(commandType);
        var handler = _decoratorFactory.GetRequiredDecoratedService(scope.ServiceProvider, handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<ICatResponse>)InvokeHandler(method!, handler, catCommand, cancellationToken);
        var result = await task;

        return result;
    }

    /// <summary>
    /// Calls the handler. An exception thrown by the handler itself reaches the caller as it is, not wrapped in a <see cref="TargetInvocationException"/>.
    /// </summary>
    private static object InvokeHandler(MethodInfo method, object handler, object command, CancellationToken cancellationToken)
    {
        try
        {
            return method.Invoke(handler, [command, cancellationToken])!;
        }
        catch (TargetInvocationException exception) when (exception.InnerException is not null)
        {
            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            throw;
        }
    }

    /// <inheritdoc />
    ICatResponse ICatCommandProcessor.Process(ICatCommand catCommand)
    {
        return AsyncContext.Run(() => ProcessAsync(catCommand));
    }
}