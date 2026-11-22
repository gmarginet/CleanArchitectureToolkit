using Cat.Scheduling.EFCore.Extensions;
using Cat.Scheduling.Extensions;
using ServiceName.Contracts.ServiceRequests;
using ServiceName.Infrastructure.DataAccess;

namespace ServiceName.Api.Extensions;

public static class SchedulerExtensions
{
    /// <summary>
    /// The name of the example job. It is the key in the configuration, so <c>CatScheduling:Jobs:example-job:Cron</c>
    /// changes the time, and <c>Enabled</c> switches the job off.
    /// </summary>
    public const string ExampleJob = "example-job";

    /// <summary>
    /// Switches the scheduler on. Every night at 02:00 UTC it sends <see cref="ExampleJobRequest"/> as the system user <c>servicelower</c>.
    /// The runs are claimed in the table <c>CatJobRun</c> of the database, so two instances of the service never run a job twice.
    /// </summary>
    public static IServiceCollection AddServiceShortScheduler(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatSchedulingEFCore<ServiceShortDbContext>();
        services.AddCatScheduling(configuration, scheduler => scheduler
            .RunAs("servicelower")
            .Job<ExampleJobRequest>(ExampleJob, "0 2 * * *"));

        return services;
    }
}
