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
/// Default <see cref="ICatCommandProcessor"/> and <see cref="ICatCurrentScopeCommandProcessor"/>.
/// Opens a new scope per command, gets the decorated handler from it and invokes the handler.
/// The current scope variant skips the new scope and uses the scope of the caller.
/// </summary>
internal class CatCommandProcessor : ICatCommandProcessor, ICatCurrentScopeCommandProcessor
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

        return await RunHandlerAsync(scope.ServiceProvider, catCommand, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ICatResponse<TResult>> ProcessAsync<TResult>(ICatCommand<TResult> catCommand, CancellationToken cancellationToken = default)
    {
        await using var scope = _serviceProvider.CreateAsyncScope();

        return await RunHandlerAsync(scope.ServiceProvider, catCommand, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ICatResponse> ProcessInCurrentScopeAsync(ICatCommand catCommand, CancellationToken cancellationToken = default)
    {
        // The processor is scoped, so the provider it got is the provider of the scope of the caller.
        return RunHandlerAsync(_serviceProvider, catCommand, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ICatResponse<TResult>> ProcessInCurrentScopeAsync<TResult>(ICatCommand<TResult> catCommand, CancellationToken cancellationToken = default)
    {
        return RunHandlerAsync(_serviceProvider, catCommand, cancellationToken);
    }

    private async Task<ICatResponse> RunHandlerAsync(IServiceProvider provider, ICatCommand catCommand, CancellationToken cancellationToken)
    {
        var commandType = catCommand.GetType();
        var handlerType = typeof(ICatCommandHandler<>).MakeGenericType(commandType);
        var handler = _decoratorFactory.GetRequiredDecoratedService(provider, handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<ICatResponse>)InvokeHandler(method!, handler, catCommand, cancellationToken);
        return await task;
    }

    private async Task<ICatResponse<TResult>> RunHandlerAsync<TResult>(IServiceProvider provider, ICatCommand<TResult> catCommand, CancellationToken cancellationToken)
    {
        var commandType = catCommand.GetType();
        var handlerType = typeof(ICatCommandHandler<,>).MakeGenericType(commandType, typeof(TResult));
        var handler = _decoratorFactory.GetRequiredDecoratedService(provider, handlerType);

        var method = handlerType.GetMethod("HandleAsync");
        var task = (Task<ICatResponse<TResult>>)InvokeHandler(method!, handler, catCommand, cancellationToken);
        return await task;
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

    /// <inheritdoc />
    ICatResponse<TResult> ICatCommandProcessor.Process<TResult>(ICatCommand<TResult> catCommand)
    {
        return AsyncContext.Run(() => ProcessAsync(catCommand));
    }
}