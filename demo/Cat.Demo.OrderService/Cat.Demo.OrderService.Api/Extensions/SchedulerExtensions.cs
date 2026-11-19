using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Scheduling.EFCore.Extensions;
using Cat.Scheduling.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.Api.Extensions;

public static class SchedulerExtensions
{
    /// <summary>
    /// The name of the job that cleans up the order counters. It is the key in the configuration, so
    /// <c>CatScheduling:Jobs:clean-up-order-counters:Cron</c> changes the time, and <c>Enabled</c> switches the job off.
    /// </summary>
    public const string CleanUpOrderCountersJob = "clean-up-order-counters";

    /// <summary>
    /// The name of the job that cancels the orders that stay Pending too long. It runs every 5 minutes.
    /// </summary>
    public const string CancelStuckOrdersJob = "cancel-stuck-orders";

    /// <summary>
    /// The name of the job that ships the orders that stay Confirmed for 5 minutes. It runs every minute.
    /// </summary>
    public const string ShipConfirmedOrdersJob = "ship-confirmed-orders";

    /// <summary>
    /// The name of the job that deletes the old inbox rows. It runs every night, ten minutes after midnight UTC.
    /// </summary>
    public const string CleanUpInboxJob = "clean-up-inbox";

    /// <summary>
    /// The name of the job that deletes the old sent outbox rows. It runs every night, fifteen minutes after midnight UTC.
    /// </summary>
    public const string CleanUpOutboxJob = "clean-up-outbox";

    /// <summary>
    /// Switches the scheduler on. Every night, shortly after midnight UTC, it sends <see cref="CleanUpOrderCountersRequest"/>,
    /// <see cref="CleanUpInboxRequest"/> and <see cref="CleanUpOutboxRequest"/> as the system user <c>orders</c>, every 5 minutes it sends <see cref="CancelStuckOrdersRequest"/>, and every minute it sends <see cref="ShipConfirmedOrdersRequest"/>.
    /// The runs are claimed in the order database, so two instances of Orders never run a job twice.
    /// The development endpoints under <c>/development/scheduler</c> still trigger the requests without the scheduler.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderScheduler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatSchedulingEFCore<OrderDbContext>();
        services.AddCatScheduling(configuration, scheduler => scheduler
            .RunAs("orders")
            .Job<CleanUpOrderCountersRequest>(CleanUpOrderCountersJob, "5 0 * * *")
            .Job<CleanUpInboxRequest>(CleanUpInboxJob, "10 0 * * *")
            .Job<CleanUpOutboxRequest>(CleanUpOutboxJob, "15 0 * * *")
            .Job<CancelStuckOrdersRequest>(CancelStuckOrdersJob, "*/5 * * * *")
            .Job<ShipConfirmedOrdersRequest>(ShipConfirmedOrdersJob, "* * * * *"));

        return services;
    }
}
