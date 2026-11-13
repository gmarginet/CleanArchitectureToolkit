using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService;
using Cat.Demo.InventoryService.Infrastructure.DataAccess;
using Cat.Demo.InventoryService.Infrastructure.Fakes;
using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Cat.Scheduling.EFCore.Extensions;
using Cat.Scheduling.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.InventoryService.Api.Extensions;

public static class SchedulerExtensions
{
    /// <summary>
    /// The name of the job that publishes the low stock report. It is the key in the configuration, so
    /// <c>CatScheduling:Jobs:low-stock-report:Cron</c> changes the time, and <c>Enabled</c> switches the job off.
    /// </summary>
    public const string LowStockReportJob = "low-stock-report";

    /// <summary>
    /// Switches the scheduler on. Every night at 02:00 UTC it sends <see cref="LowStockReportRequest"/> as the system user <c>inventory</c>.
    /// The runs are claimed in the inventory database, table <c>CatJobRun</c> from <c>004-scheduling.sql</c>, so two instances of Inventory never run the job twice.
    /// The limit comes from <c>Inventory:LowStockLimit</c>, with <see cref="LowStockSettings.DefaultLimit"/> as the default.
    /// The development endpoint <c>POST /development/scheduler/low-stock-report</c> still triggers the request without the scheduler.
    /// </summary>
    /// <remarks>
    /// The report goes out as a message. When the host gives no bus (<c>ConnectionStrings:messaging</c>), a fake transport only logs it.
    /// </remarks>
    public static IServiceCollection AddCatDemoInventoryScheduler(this IServiceCollection services, IConfiguration configuration)
    {
        if (string.IsNullOrWhiteSpace(configuration.GetConnectionString("messaging")))
        {
            services.AddCatMessagingModule();
            services.AddSingleton<ICatMessageTransport, FakeMessageTransport>();
        }

        services.AddSingleton(new LowStockSettings(configuration.GetValue(LowStockSettings.ConfigurationKey, LowStockSettings.DefaultLimit)));

        services.AddCatSchedulingEFCore<InventoryDbContext>();
        services.AddCatScheduling(configuration, scheduler => scheduler
            .RunAs("inventory")
            .Job<LowStockReportRequest>(LowStockReportJob, "0 2 * * *"));

        return services;
    }
}
