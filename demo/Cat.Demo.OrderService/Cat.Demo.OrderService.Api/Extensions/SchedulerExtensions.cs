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
    /// Switches the scheduler on. Every night, shortly after midnight UTC, it sends <see cref="CleanUpOrderCountersRequest"/>
    /// as the system user <c>orders</c>, and every 5 minutes it sends <see cref="CancelStuckOrdersRequest"/>.
    /// The runs are claimed in the order database, so two instances of Orders never run a job twice.
    /// The development endpoints under <c>/development/scheduler</c> still trigger the requests without the scheduler.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderScheduler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatSchedulingEFCore<OrderDbContext>();
        services.AddCatScheduling(configuration, scheduler => scheduler
            .RunAs("orders")
            .Job<CleanUpOrderCountersRequest>(CleanUpOrderCountersJob, "5 0 * * *")
            .Job<CancelStuckOrdersRequest>(CancelStuckOrdersJob, "*/5 * * * *"));

        return services;
    }
}
