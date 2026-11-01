using System;
using System.Collections.Generic;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Minimal.Api.Extensions;

/// <summary>
/// Registration helpers for the minimal API module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the exception handler and the problem details services.
    /// <list type="bullet">
    /// <item><description>Request binding failures throw in every environment, so they get a <see cref="CatProblemDetails"/> body everywhere, not only in Development.</description></item>
    /// <item><description>Problem details the framework creates itself, such as for an unknown route, get the <c>catErrors</c> and <c>catTraceId</c> fields. Clients then see one error shape.</description></item>
    /// <item><description>The framework's own <c>traceId</c> field is removed, because <c>catTraceId</c> holds the same value.</description></item>
    /// </list>
    /// Call <see cref="ApplicationBuilderExtensions.UseCatMinimalApiModule"/> as well, so the handler catches the exceptions.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, to chain more calls.</returns>
    public static IServiceCollection AddCatMinimalApiModule(this IServiceCollection services)
    {
        services.AddExceptionHandler<CatExceptionHandler>();

        // Binding failures throw in every environment, not only in Development. CatExceptionHandler then turns them
        // into the same 400 CatProblemDetails everywhere, instead of an empty 400 outside Development.
        services.Configure<RouteHandlerOptions>(options => options.ThrowOnBadRequest = true);

        // Problem details the framework creates itself (unknown route, wrong method and so on) get the same
        // catErrors and catTraceId fields as a CatProblemDetails, so clients only see one error shape.
        // The framework also adds a traceId field to every problem details. catTraceId already holds that value,
        // so traceId is removed to keep one id per response.
        services.AddProblemDetails(options => options.CustomizeProblemDetails = context =>
        {
            context.ProblemDetails.Extensions.Remove("traceId");

            if (context.ProblemDetails is CatProblemDetails) return;

            context.ProblemDetails.Instance ??= context.HttpContext.Request.Path.ToString();
            context.ProblemDetails.Extensions.TryAdd("catErrors", Array.Empty<ICatError>());
            context.ProblemDetails.Extensions.TryAdd("catTraceId", CatProblemDetails.GetTraceId(context.HttpContext));
        });

        return services;
    }
}
