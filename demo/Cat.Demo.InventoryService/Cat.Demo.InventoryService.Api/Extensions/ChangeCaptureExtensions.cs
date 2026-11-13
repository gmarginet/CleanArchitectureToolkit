using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.InventoryService.CoreService;
using Cat.Sql.Cdc.Extensions;
using Cat.Sql.Cdc.Messaging.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.InventoryService.Api.Extensions;

public static class ChangeCaptureExtensions
{
    /// <summary>The configuration key that switches the change capture on. It is off when the key is missing.</summary>
    public const string ConfigurationKey = "Inventory:ChangeCapture";

    /// <summary>
    /// Sends every change of the stock table as a <c>StockChanged</c> message, without any Inventory code publishing it.
    /// <c>Cat.Sql.Cdc</c> reads the change table of SQL Server. Change data capture must be on for the table, see <c>005-change-capture.sql</c>,
    /// so the AppHost switches this on only in the container mode, where it runs the scripts.
    /// With an existing database the developer enables change data capture by hand and then sets <see cref="ConfigurationKey"/> to <c>true</c>.
    /// </summary>
    /// <remarks>
    /// The reader uses the inventory connection string. The messages go through <c>ICatMessageSender</c>, which the scheduler extension
    /// registers, with a fake transport when the host gives no bus.
    /// </remarks>
    /// <returns><c>true</c> when the reader is registered.</returns>
    public static bool AddCatDemoInventoryChangeCapture(this IServiceCollection services, IConfiguration configuration, string connectionString)
    {
        if (!configuration.GetValue(ConfigurationKey, false))
        {
            return false;
        }

        // The reader takes its connection string from the section CatSqlCdc. Inventory reads its own database, so it fills the key itself.
        var cdcConfiguration = new ConfigurationBuilder()
            .AddConfiguration(configuration)
            .AddInMemoryCollection([new("CatSqlCdc:ConnectionString", connectionString)])
            .Build();

        var limit = configuration.GetValue(LowStockSettings.ConfigurationKey, LowStockSettings.DefaultLimit);

        services.AddCatSqlCdc(cdcConfiguration, cdc => cdc
            .AddTable<StockChanged>(StockChangeMapper.CaptureInstance, table => table.Map(change => StockChangeMapper.Map(change, limit))));
        services.AddCatSqlCdcMessaging();
        services.AddHealthChecks().AddCatSqlCdcHealthCheck();

        return true;
    }
}
