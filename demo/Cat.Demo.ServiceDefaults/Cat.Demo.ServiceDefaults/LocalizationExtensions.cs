using System.Globalization;
using Microsoft.AspNetCore.Builder;

namespace Cat.Demo.ServiceDefaults;

/// <summary>
/// The languages of the demo. English is the default language and Dutch is the extra one.
/// Only the demo uses this class. The CAT modules never reference it.
/// </summary>
public static class LocalizationExtensions
{
    /// <summary>The cultures a service answers in.</summary>
    public static readonly string[] SupportedCultures = ["en", "nl"];

    /// <summary>
    /// Sets the culture of a request from its <c>Accept-Language</c> header. The gateway passes the header on as it is.
    /// A request with no header, or with a language the demo does not have, gets English.
    /// Call it before the endpoints, and before the code that reads <c>CurrentUICulture</c>.
    /// </summary>
    /// <param name="app">The application builder of the service.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static IApplicationBuilder UseDemoRequestLocalization(this IApplicationBuilder app)
    {
        return app.UseRequestLocalization(options =>
        {
            options.SetDefaultCulture(SupportedCultures[0]);
            options.AddSupportedCultures(SupportedCultures);
            options.AddSupportedUICultures(SupportedCultures);
        });
    }
}
