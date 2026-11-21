using System;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging;

internal sealed class CatSystemMessageSender : CatMessageSenderBase, ICatSystemMessageSender
{
    public CatSystemMessageSender(ICatMessageNameResolver nameResolver, ICatMessageSerializer serializer, ICatOutgoingMessageSink sink,
        ICatTokenProvider? tokenProvider = null)
        : base(nameResolver, serializer, sink, tokenProvider)
    {
    }

    protected override CatTokenSubject ChooseSubject(DateTimeOffset? scheduledAt) => CatTokenSubject.System;

    // Without a provider the message would go out as the anonymous user, which is not what this sender is asked for.
    protected override void RequireNoTokenProvider() =>
        throw new InvalidOperationException(
            "ICatSystemMessageSender needs an ICatTokenProvider that gives a token for CatTokenSubject.System. Register one.");
}