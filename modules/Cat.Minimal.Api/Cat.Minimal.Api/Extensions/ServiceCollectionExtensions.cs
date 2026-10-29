using Microsoft.Extensions.DependencyInjection;

namespace Cat.Minimal.Api.Extensions;

/// <summary>
/// Registration helpers for the minimal API module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the exception handler and the problem details services.
    /// Call <c>app.UseExceptionHandler()</c> as well, so the handler catches unexpected exceptions.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatMinimalApiModule(this IServiceCollection services)
    {
        services.AddExceptionHandler<CatExceptionHandler>();
        services.AddProblemDetails();
    }
}