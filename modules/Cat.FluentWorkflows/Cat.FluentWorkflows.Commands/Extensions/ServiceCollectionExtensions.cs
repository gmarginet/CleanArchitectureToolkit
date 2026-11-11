using Cat.FluentWorkflows.Commands.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.FluentWorkflows.Commands.Extensions;

/// <summary>
/// Registration helpers for the command workflow step.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the process command step, with and without a result.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatBuildInCommandWorkflowStep(this IServiceCollection services)
    {
        services.AddTransient(typeof(CatProcessCommandStep<>));
        services.AddTransient(typeof(CatProcessCommandStep<,>));
    }
}