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
    /// Switches the scheduler on. Every night, shortly after midnight UTC, it sends <see cref="CleanUpOrderCountersRequest"/>
    /// as the system user <c>orders</c>. The runs are claimed in the order database, so two instances of Orders never clean up twice.
    /// The development endpoint <c>POST /development/scheduler/clean-up-order-counters</c> still triggers the request without the scheduler.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderScheduler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatSchedulingEFCore<OrderDbContext>();
        services.AddCatScheduling(configuration, scheduler => scheduler
            .RunAs("orders")
            .Job<CleanUpOrderCountersRequest>(CleanUpOrderCountersJob, "5 0 * * *"));

        return services;
    }
}
