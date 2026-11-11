using System.Linq;
using Cat.EventProcessor.Abstractions;
using Cat.Responses.Abstractions;

namespace Cat.EventProcessor;

/// <summary>
/// Turns the response of a handler into an action on the message.
/// A succeeded response completes the message. <c>InternalServerError</c> abandons it, so the bus delivers it again.
/// Every other failure dead letters it at once, because trying again gives the same answer.
/// The settings of the message type can override the table per response type.
/// </summary>
internal static class CatFailureTable
{
    /// <summary>
    /// Decides what to do with the message.
    /// </summary>
    /// <param name="response">The response of the handler.</param>
    /// <param name="options">The settings of the message type, with the overrides.</param>
    /// <returns>What to do with the message, and why.</returns>
    public static CatSettlementResult Settle(ICatResponse response, CatReceiveOptions options)
    {
        if (response.IsSucceeded)
        {
            return new CatSettlementResult(CatSettlement.Complete);
        }

        var responseTypeName = response.Type.GetType().Name;
        var settlement = options.FailureOverrides.TryGetValue(responseTypeName, out var overridden)
            ? overridden
            : DefaultFor(response.Type);

        var codes = string.Join(", ", response.ErrorList.Select(error => error.Code));
        var messages = string.Join(" | ", response.ErrorList.Select(error => $"{error.Code}: {error.Message}"));

        return settlement == CatSettlement.Complete
            ? new CatSettlementResult(CatSettlement.Complete)
            : new CatSettlementResult(settlement, string.IsNullOrEmpty(codes) ? responseTypeName : codes, messages);
    }

    private static CatSettlement DefaultFor(CatResponseType type)
    {
        return type is CatResponseType.Failed.InternalServerError ? CatSettlement.Abandon : CatSettlement.DeadLetter;
    }
}
