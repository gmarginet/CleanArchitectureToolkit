using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging;

/// <summary>
/// Default <see cref="ICatMessageSender"/>.
/// Builds a <see cref="CatOutgoingMessage"/> from the message and gives it to the <see cref="ICatOutgoingMessageSink"/>.
/// </summary>
internal sealed class CatMessageSender : ICatMessageSender
{
    private readonly ICatMessageNameResolver _nameResolver;
    private readonly ICatMessageSerializer _serializer;
    private readonly ICatOutgoingMessageSink _sink;
    private readonly ICatTokenProvider? _tokenProvider;

    /// <summary>
    /// Creates the sender.
    /// </summary>
    /// <param name="nameResolver">Finds the queue or topic name of the message type.</param>
    /// <param name="serializer">Turns the message into a body.</param>
    /// <param name="sink">Takes the finished message, to send it or to store it in the outbox.</param>
    /// <param name="tokenProvider">Gives the token that travels with the message. Without one, a message carries no token.</param>
    public CatMessageSender(ICatMessageNameResolver nameResolver, ICatMessageSerializer serializer, ICatOutgoingMessageSink sink,
        ICatTokenProvider? tokenProvider = null)
    {
        _nameResolver = nameResolver;
        _serializer = serializer;
        _sink = sink;
        _tokenProvider = tokenProvider;
    }

    /// <inheritdoc />
    public Task PublishAsync(ICatEventMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        return AcceptAsync(message, CatMessageKind.Event, scheduledAt, cancellationToken);
    }

    /// <inheritdoc />
    public Task SendAsync(ICatCommandMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        return AcceptAsync(message, CatMessageKind.Command, scheduledAt, cancellationToken);
    }

    private async Task AcceptAsync(ICatMessage message, CatMessageKind kind, DateTimeOffset? scheduledAt, CancellationToken cancellationToken)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        var messageType = message.GetType();
        var name = _nameResolver.GetName(messageType);

        var outgoing = new CatOutgoingMessage
        {
            EntityName = name,
            Kind = kind,
            Subject = name,
            Body = _serializer.Serialize(message, messageType),
            ContentType = _serializer.ContentType,
            MessageId = message.MessageId,
            CorrelationId = message.CorrelationId,
            SessionId = (message as ICatSessionMessage)?.SessionId,
            ScheduledAt = scheduledAt
        };

        if (_tokenProvider != null)
        {
            // A scheduled message is delivered later, when a token of a user has expired, so it carries the token of the system.
            var subject = scheduledAt.HasValue ? CatTokenSubject.System : CatTokenSubject.CurrentUser;
            var token = await _tokenProvider.GetTokenAsync(subject, cancellationToken).ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(token))
            {
                outgoing.Properties[CatMessageProperties.Authorization] = "Bearer " + token;
            }
        }

        await _sink.AcceptAsync(outgoing, cancellationToken).ConfigureAwait(false);
    }
}
