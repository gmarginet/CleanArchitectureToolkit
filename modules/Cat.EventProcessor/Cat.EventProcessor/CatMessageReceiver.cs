using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Cat.EventProcessor.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor;

/// <summary>
/// Default <see cref="ICatMessageReceiver"/>.
/// The message is the service request itself, so there is no mapping step.
/// </summary>
internal sealed class CatMessageReceiver : ICatMessageReceiver
{
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ICatReceiveRegistry _registry;

    /// <summary>
    /// Creates the receiver.
    /// </summary>
    /// <param name="scopeFactory">Opens a scope per message, because the service request processor is scoped.</param>
    /// <param name="registry">Holds the settings of the declared message types.</param>
    public CatMessageReceiver(IServiceScopeFactory scopeFactory, ICatReceiveRegistry registry)
    {
        _scopeFactory = scopeFactory;
        _registry = registry;
    }

    /// <inheritdoc />
    public async Task<CatSettlementResult> ReceiveAsync(Type messageType, CatIncomingMessage message, CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrEmpty(message.ContentType) && !message.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
        {
            return new CatSettlementResult(CatSettlement.DeadLetter, "UnsupportedContentType",
                $"The content type {message.ContentType} is not supported. Only application/json is.");
        }

        object? request;
        try
        {
            request = JsonSerializer.Deserialize(message.Body, messageType, JsonOptions);
        }
        catch (JsonException exception)
        {
            return new CatSettlementResult(CatSettlement.DeadLetter, "InvalidMessage", exception.Message);
        }

        if (request is not ICatServiceRequest serviceRequest)
        {
            return new CatSettlementResult(CatSettlement.DeadLetter, "InvalidMessage",
                $"The body is not a {messageType.Name}, or the type is not a service request.");
        }

        var options = FindOptions(messageType);

        using var context = CatMessageContext.Begin(message.MessageId, message.DeliveryCount);
        using var scope = _scopeFactory.CreateScope();

        try
        {
            // The policy runs before the inbox, so a message that is not allowed leaves no trace in the inbox.
            var authorizer = scope.ServiceProvider.GetService<ICatMessageAuthorizer>();
            if (authorizer != null)
            {
                var authorization = await authorizer.AuthorizeAsync(message, options, cancellationToken).ConfigureAwait(false);
                if (!authorization.Succeeded)
                {
                    return new CatSettlementResult(CatSettlement.DeadLetter, authorization.Reason, authorization.Description);
                }
            }

            // Resolved after the authorization, so everything in the scope sees the user of the message.
            // The handler runs in this scope, so its DbContext is the one the inbox row is added to and one SaveChanges commits both.
            // A processor of your own, registered only as ICatServiceRequestProcessor, opens a scope of its own and cannot share it.
            var currentScopeProcessor = scope.ServiceProvider.GetService<ICatCurrentScopeServiceRequestProcessor>();
            var processor = currentScopeProcessor == null
                ? scope.ServiceProvider.GetRequiredService<ICatServiceRequestProcessor>()
                : null;

            if (options.UseInbox && !string.IsNullOrEmpty(message.MessageId))
            {
                var store = scope.ServiceProvider.GetRequiredService<ICatInboxStore>();
                if (await store.ExistsAsync(message.MessageId, cancellationToken).ConfigureAwait(false))
                {
                    return new CatSettlementResult(CatSettlement.Complete);
                }

                store.Add(message.MessageId, messageType.Name);
            }

            var response = currentScopeProcessor != null
                ? await currentScopeProcessor.ProcessInCurrentScopeAsync(serviceRequest, cancellationToken).ConfigureAwait(false)
                : await processor!.ProcessAsync(serviceRequest, cancellationToken).ConfigureAwait(false);
            return CatFailureTable.Settle(response, options);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception exception)
        {
            return new CatSettlementResult(CatSettlement.Abandon, exception.GetType().Name, exception.Message);
        }
    }

    private CatReceiveOptions FindOptions(Type messageType)
    {
        foreach (var registration in _registry.Registrations)
        {
            if (registration.MessageType == messageType)
            {
                return registration.Options;
            }
        }

        return new CatReceiveOptions();
    }
}
