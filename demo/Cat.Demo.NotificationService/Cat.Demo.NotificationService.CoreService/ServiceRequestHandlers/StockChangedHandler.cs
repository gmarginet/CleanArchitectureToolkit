using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles the <see cref="StockChanged"/> message of Inventory, as it handles any service request.
/// Every change of the stock table arrives here. The handler mails the admin only when the quantity dropped from the limit or more
/// to below the limit. Every other change is a normal case: the handler answers success and sends nothing, so the message is completed.
/// The drop is not stored. A message that is delivered twice sends two mails, which does no harm for an alert.
/// </summary>
public class StockChangedHandler : ICatServiceRequestHandler<StockChanged>
{
    private readonly IMailSender _mailSender;
    private readonly NotificationSettings _settings;

    public StockChangedHandler(IMailSender mailSender, NotificationSettings settings)
    {
        _mailSender = mailSender;
        _settings = settings;
    }

    public async Task<ICatResponse> HandleAsync(StockChanged serviceRequest, CancellationToken cancellationToken = default)
    {
        if (!IsDrop(serviceRequest))
        {
            return CatResponse.Ok();
        }

        await _mailSender.SendAsync(StockDropMailBuilder.Build(_settings.AdminEmail, serviceRequest), cancellationToken);
        return CatResponse.Ok();
    }

    /// <summary>A drop is a change from the limit or more to below the limit. An insert or a delete has no old or no new quantity, so it is no drop.</summary>
    public static bool IsDrop(StockChanged change)
    {
        return change.OldQuantity is { } oldQuantity
               && change.NewQuantity is { } newQuantity
               && oldQuantity >= change.Limit
               && newQuantity < change.Limit;
    }
}
