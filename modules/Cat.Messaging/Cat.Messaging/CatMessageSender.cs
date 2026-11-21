using System;
using Cat.Messaging.Abstractions;

namespace Cat.Messaging;

internal sealed class CatMessageSender : CatMessageSenderBase, ICatMessageSender
{
    public CatMessageSender(ICatMessageNameResolver nameResolver, ICatMessageSerializer serializer, ICatOutgoingMessageSink sink,
        ICatTokenProvider? tokenProvider = null)
        : base(nameResolver, serializer, sink, tokenProvider)
    {
    }

    // A scheduled message is delivered later, when a token of a user has expired, so it carries the token of the system.
    protected override CatTokenSubject ChooseSubject(DateTimeOffset? scheduledAt) =>
        scheduledAt.HasValue ? CatTokenSubject.System : CatTokenSubject.CurrentUser;
}