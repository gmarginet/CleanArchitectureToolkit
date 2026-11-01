using Microsoft.AspNetCore.Builder;

namespace Cat.Minimal.Api.Extensions;

/// <summary>
/// Pipeline helpers for the minimal API module.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds the middleware of the minimal API module to the pipeline.
    /// <list type="bullet">
    /// <item><description>Sends unexpected exceptions and request binding failures to the CAT exception handler.</description></item>
    /// <item><description>Gives empty error responses, such as a 404 for an unknown route, a problem details body.</description></item>
    /// </list>
    /// Call it early in the pipeline, before the endpoints are mapped, so it catches everything after it.
    /// Requires <see cref="ServiceCollectionExtensions.AddCatMinimalApiModule"/> to be called first.
    /// </summary>
    /// <param name="app">The application builder to add to.</param>
    /// <returns>The same application builder, to chain more calls.</returns>
    public static IApplicationBuilder UseCatMinimalApiModule(this IApplicationBuilder app)
    {
        app.UseExceptionHandler();
        app.UseStatusCodePages();

        return app;
    }
}
