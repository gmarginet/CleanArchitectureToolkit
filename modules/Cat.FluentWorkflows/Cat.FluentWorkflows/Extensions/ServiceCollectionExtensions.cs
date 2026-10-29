using System;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.FluentWorkflows.Extensions;

/// <summary>
/// Registration helpers for the fluent workflows module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the workflow and step processors and every built-in step.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatFluentWorkflowsModule(this IServiceCollection services)
    {
        services.AddScoped<ICatStepProcessor, CatStepProcessor>();
        services.AddScoped<ICatWorkflowProcessor, CatWorkflowProcessor>();
        services.AddTransient(typeof(CatInlineActionStep<>));
        services.AddTransient(typeof(CatInlineFuncStep<>));
        services.AddTransient(typeof(CatIfStep<>));
        services.AddTransient(typeof(CatForeachStep<,,>));
        services.AddTransient(typeof(CatWhileStep<>));
        services.AddTransient(typeof(CatSwitchStep<,>));
        services.AddTransient(typeof(CatRunSubWorkflowStep<,,>));
        services.AddTransient(typeof(CatSetStatePropertyStep<,>));
        services.AddTransient(typeof(CatLogStep<>));
        services.AddTransient(typeof(CatBreakIfStep<>));
        services.AddTransient<CatBreakStep>();
    }
        
    /// <summary>
    /// Registers every step body found in the given assemblies, with a transient lifetime.
    /// Only public classes that are not generic are registered.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="types">One type from each assembly to scan for step bodies.</param>
    public static void AddCatFluentWorkflowsSteps(this IServiceCollection services,
        params Type[] types)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatStepBodyAsync))
                .Where(t => !t.IsGenericType))
            .AsSelf()
            .WithTransientLifetime()
        );
    }

    /// <summary>
    /// Registers every workflow found in the given assemblies, with a transient lifetime.
    /// Only public classes that are not generic are registered.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="types">One type from each assembly to scan for workflows.</param>
    public static void AddCatFluentWorkflowsFlows(this IServiceCollection services,
        params Type[] types)
    {
        services.Scan(scan => scan
            .FromAssembliesOf(types)
            .AddClasses(c => c.AssignableTo(typeof(ICatWorkflow<>))
                .Where(t => !t.IsGenericType))
            .AsSelf()
            .WithTransientLifetime()
        );
    }
}