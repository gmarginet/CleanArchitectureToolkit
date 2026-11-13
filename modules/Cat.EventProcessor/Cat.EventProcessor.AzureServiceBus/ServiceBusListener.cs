using Azure.Messaging.ServiceBus;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Hosted service that starts one Azure Service Bus processor per declared message type, and stops them together.
/// A command message is read from its queue, an event from the subscription of this service on its topic.
/// A message type that needs sessions gets a session processor.
/// The SDK continues the trace of the sender from the <c>Diagnostic-Id</c> of the message.
/// </summary>
internal sealed class ServiceBusListener : IHostedService, IAsyncDisposable
{
    private readonly ServiceBusClient _client;
    private readonly ICatReceiveRegistry _registry;
    private readonly ICatMessageNameResolver _nameResolver;
    private readonly ICatMessageReceiver _receiver;
    private readonly IOptions<CatEventProcessorServiceBusOptions> _options;
    private readonly ListenerStatus _status;
    private readonly ILogger<ServiceBusListener> _logger;
    private readonly IServiceProviderIsService _serviceProviderIsService;
    private readonly List<Func<CancellationToken, Task>> _stoppers = new();
    private readonly List<IAsyncDisposable> _disposables = new();

    /// <summary>
    /// Creates the listener.
    /// </summary>
    /// <param name="client">The shared Service Bus client.</param>
    /// <param name="registry">The declared message types.</param>
    /// <param name="nameResolver">Finds the queue or topic name and the kind of a message type.</param>
    /// <param name="receiver">Handles one message.</param>
    /// <param name="options">The settings of the listener.</param>
    /// <param name="status">The state of the listeners, for the health check.</param>
    /// <param name="logger">The logger.</param>
    /// <param name="serviceProviderIsService">Tells whether the service registered an inbox store.</param>
    public ServiceBusListener(ServiceBusClient client, ICatReceiveRegistry registry, ICatMessageNameResolver nameResolver,
        ICatMessageReceiver receiver, IOptions<CatEventProcessorServiceBusOptions> options, ListenerStatus status,
        ILogger<ServiceBusListener> logger, IServiceProviderIsService serviceProviderIsService)
    {
        _serviceProviderIsService = serviceProviderIsService;
        _client = client;
        _registry = registry;
        _nameResolver = nameResolver;
        _receiver = receiver;
        _options = options;
        _status = status;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        CheckInbox();

        foreach (var registration in _registry.Registrations)
        {
            await StartListenerAsync(registration, cancellationToken);
        }
    }

    /// <summary>
    /// Stops taking new messages and waits for the messages that are running.
    /// </summary>
    /// <param name="cancellationToken">Token that stops the waiting.</param>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        foreach (var stop in _stoppers)
        {
            await stop(cancellationToken);
        }
    }

    private void CheckInbox()
    {
        if (!_serviceProviderIsService.IsService(typeof(ICatInboxStore)))
        {
            var names = _registry.Registrations.Where(registration => registration.Options.UseInbox)
                .Select(registration => registration.MessageType.Name).ToList();
            if (names.Count > 0)
            {
                throw new InvalidOperationException(
                    $"The inbox is on for {string.Join(", ", names)}, but no ICatInboxStore is registered. Register a store, such as AddCatEventProcessorInbox.");
            }
        }

        if (!_serviceProviderIsService.IsService(typeof(ICatMessageAuthorizer)))
        {
            var names = _registry.Registrations.Where(registration => registration.Options.HasAuthorizationRule)
                .Select(registration => registration.MessageType.Name).ToList();
            if (names.Count > 0)
            {
                throw new InvalidOperationException(
                    $"A policy is set for {string.Join(", ", names)}, but no ICatMessageAuthorizer is registered. Register one, such as AddCatEventProcessorAuthorization.");
            }
        }
    }

    private async Task StartListenerAsync(CatReceiveRegistration registration, CancellationToken cancellationToken)
    {
        var type = registration.MessageType;
        var name = _nameResolver.GetName(type);
        var kind = _nameResolver.GetKind(type);
        var subscription = _options.Value.SubscriptionName;

        if (kind == CatMessageKind.Event && string.IsNullOrWhiteSpace(subscription))
        {
            throw new InvalidOperationException($"{type.Name} is an event, so the listener needs a SubscriptionName.");
        }

        if (_nameResolver.RequiresSession(type))
        {
            var sessionOptions = BuildSessionProcessorOptions(type, registration.Options.MaxConcurrentCalls, _options.Value.ConfigureSessionProcessor);

            var processor = kind == CatMessageKind.Event
                ? _client.CreateSessionProcessor(name, subscription, sessionOptions)
                : _client.CreateSessionProcessor(name, sessionOptions);

            processor.ProcessMessageAsync += args => HandleAsync(type, args.Message,
                args.CompleteMessageAsync, args.AbandonMessageAsync, args.DeadLetterMessageAsync, args.CancellationToken);
            processor.ProcessErrorAsync += HandleErrorAsync;
            _status.Add(() => processor.IsProcessing);
            _stoppers.Add(processor.StopProcessingAsync);
            _disposables.Add(processor);
            await processor.StartProcessingAsync(cancellationToken);
        }
        else
        {
            var processorOptions = BuildProcessorOptions(type, registration.Options.MaxConcurrentCalls, _options.Value.ConfigureProcessor);

            var processor = kind == CatMessageKind.Event
                ? _client.CreateProcessor(name, subscription, processorOptions)
                : _client.CreateProcessor(name, processorOptions);

            processor.ProcessMessageAsync += args => HandleAsync(type, args.Message,
                args.CompleteMessageAsync, args.AbandonMessageAsync, args.DeadLetterMessageAsync, args.CancellationToken);
            processor.ProcessErrorAsync += HandleErrorAsync;
            _status.Add(() => processor.IsProcessing);
            _stoppers.Add(processor.StopProcessingAsync);
            _disposables.Add(processor);
            await processor.StartProcessingAsync(cancellationToken);
        }

        _logger.LogInformation("Listening for {MessageType} on {Entity}", type.Name, kind == CatMessageKind.Event ? $"{name}/{subscription}" : name);
    }

    /// <summary>
    /// Builds the options of a processor. The concurrency of the message type is set first, then the callback runs,
    /// and <c>AutoCompleteMessages</c> is set to false after it, because the listener settles every message itself.
    /// </summary>
    internal static ServiceBusProcessorOptions BuildProcessorOptions(Type messageType, int? maxConcurrentCalls,
        Action<Type, ServiceBusProcessorOptions>? configure)
    {
        var options = new ServiceBusProcessorOptions();
        if (maxConcurrentCalls is { } calls)
        {
            options.MaxConcurrentCalls = calls;
        }

        configure?.Invoke(messageType, options);
        options.AutoCompleteMessages = false;
        return options;
    }

    /// <summary>
    /// Builds the options of a session processor. The number of sessions of the message type is set first, then the callback runs,
    /// and <c>AutoCompleteMessages</c> is set to false after it, because the listener settles every message itself.
    /// </summary>
    internal static ServiceBusSessionProcessorOptions BuildSessionProcessorOptions(Type messageType, int? maxConcurrentSessions,
        Action<Type, ServiceBusSessionProcessorOptions>? configure)
    {
        var options = new ServiceBusSessionProcessorOptions();
        if (maxConcurrentSessions is { } sessions)
        {
            options.MaxConcurrentSessions = sessions;
        }

        configure?.Invoke(messageType, options);
        options.AutoCompleteMessages = false;
        return options;
    }

    private async Task HandleAsync(Type messageType, ServiceBusReceivedMessage received,
        Func<ServiceBusReceivedMessage, CancellationToken, Task> complete,
        Func<ServiceBusReceivedMessage, IDictionary<string, object>?, CancellationToken, Task> abandon,
        Func<ServiceBusReceivedMessage, string, string, CancellationToken, Task> deadLetter,
        CancellationToken cancellationToken)
    {
        var incoming = ServiceBusIncomingMessageMapper.ToIncomingMessage(received);
        var result = await _receiver.ReceiveAsync(messageType, incoming, cancellationToken);

        switch (result.Settlement)
        {
            case CatSettlement.Complete:
                await complete(received, cancellationToken);
                break;
            case CatSettlement.DeadLetter:
                _logger.LogWarning("Dead lettering {MessageType} {MessageId}: {Reason}", messageType.Name, received.MessageId, result.Reason);
                await deadLetter(received, result.Reason, result.Description, cancellationToken);
                break;
            default:
                _logger.LogWarning("Abandoning {MessageType} {MessageId} on delivery {DeliveryCount}: {Reason}",
                    messageType.Name, received.MessageId, received.DeliveryCount, result.Reason);
                await abandon(received, null, cancellationToken);
                break;
        }
    }

    private Task HandleErrorAsync(ProcessErrorEventArgs args)
    {
        _status.ReportError();
        _logger.LogError(args.Exception, "The Service Bus processor reported an error on {EntityPath} during {Source}",
            args.EntityPath, args.ErrorSource);
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        foreach (var disposable in _disposables)
        {
            await disposable.DisposeAsync();
        }
    }
}
