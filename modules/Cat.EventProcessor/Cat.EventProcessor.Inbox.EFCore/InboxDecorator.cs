using Cat.EventProcessor.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.EventProcessor.Inbox.EFCore;

/// <summary>
/// Skips a message that was handled before. It runs only for a request that came from a message,
/// and passes every other request, such as an HTTP call, straight on.
/// A repeated message completes without running the handler. A new message gets a row in the context of the handler
/// before the handler runs, so the <c>SaveChanges</c> of the handler saves the row with the work, or neither is saved.
/// If two copies of a message run at the same moment, the key of the table fails the second save,
/// the message is abandoned, and the next delivery finds the row and skips it.
/// </summary>
internal static class InboxDecorator
{
    internal sealed class CatServiceRequestHandler<TRequest> : ICatServiceRequestHandler<TRequest>
        where TRequest : class, ICatServiceRequest
    {
        private readonly ICatServiceRequestHandler<TRequest> _innerHandler;
        private readonly ICatInboxStore _store;

        public CatServiceRequestHandler(ICatServiceRequestHandler<TRequest> innerHandler, ICatInboxStore store)
        {
            _innerHandler = innerHandler;
            _store = store;
        }

        public async Task<ICatResponse> HandleAsync(TRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            var context = CatMessageContext.Current;
            if (context is null || string.IsNullOrEmpty(context.MessageId))
            {
                return await _innerHandler.HandleAsync(serviceRequest, cancellationToken);
            }

            if (await _store.ExistsAsync(context.MessageId, cancellationToken))
            {
                return CatResponse.Ok();
            }

            _store.Add(context.MessageId, typeof(TRequest).Name);

            return await _innerHandler.HandleAsync(serviceRequest, cancellationToken);
        }
    }
}
