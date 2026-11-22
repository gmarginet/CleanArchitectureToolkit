using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.NotificationService.CoreService.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.NotificationService.CoreService.ServiceRequestHandlers;

/// <summary>
/// Handles the <see cref="LowStockReport"/> message of Inventory, as it handles any service request.
/// It mails the report to the admin. A report without lines counts as handled and sends nothing.
/// The report is not stored. A message that is delivered twice sends two mails, which does no harm for a report.
/// </summary>
public class LowStockReportHandler : ICatServiceRequestHandler<LowStockReport>
{
    private readonly IMailSender _mailSender;
    private readonly NotificationSettings _settings;
    private readonly LowStockReportMailBuilder _mailBuilder;

    public LowStockReportHandler(IMailSender mailSender, NotificationSettings settings, LowStockReportMailBuilder mailBuilder)
    {
        _mailSender = mailSender;
        _settings = settings;
        _mailBuilder = mailBuilder;
    }

    public async Task<ICatResponse> HandleAsync(LowStockReport serviceRequest, CancellationToken cancellationToken = default)
    {
        if (serviceRequest.Lines.Count == 0)
        {
            return CatResponse.Ok();
        }

        // The admin reads the report in the language of the settings, whatever culture the message or the job has.
        using var culture = _settings.UseAdminCulture();
        await _mailSender.SendAsync(_mailBuilder.Build(_settings.AdminEmail, serviceRequest), cancellationToken);
        return CatResponse.Ok();
    }
}
