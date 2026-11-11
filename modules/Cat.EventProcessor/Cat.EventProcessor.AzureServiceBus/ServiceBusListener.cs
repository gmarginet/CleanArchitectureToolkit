using Azure.Messaging.ServiceBus;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
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
    public ServiceBusListener(ServiceBusClient client, ICatReceiveRegistry registry, ICatMessageNameResolver nameResolver,
        ICatMessageReceiver receiver, IOptions<CatEventProcessorServiceBusOptions> options, ListenerStatus status,
        ILogger<ServiceBusListener> logger)
    {
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
            var sessionOptions = new ServiceBusSessionProcessorOptions { AutoCompleteMessages = false };
            if (registration.Options.MaxConcurrentCalls is { } sessions)
            {
                sessionOptions.MaxConcurrentSessions = sessions;
            }

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
            var processorOptions = new ServiceBusProcessorOptions { AutoCompleteMessages = false };
            if (registration.Options.MaxConcurrentCalls is { } calls)
            {
                processorOptions.MaxConcurrentCalls = calls;
            }

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
