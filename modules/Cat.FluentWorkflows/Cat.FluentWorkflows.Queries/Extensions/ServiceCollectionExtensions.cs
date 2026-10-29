using Cat.FluentWorkflows.Queries.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.FluentWorkflows.Queries.Extensions;

/// <summary>
/// Registration helpers for the query workflow step.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the process query step.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatBuildInQueryWorkflowStep(this IServiceCollection services)
    {
        services.AddTransient(typeof(CatProcessQueryStep<,>));
    }
}