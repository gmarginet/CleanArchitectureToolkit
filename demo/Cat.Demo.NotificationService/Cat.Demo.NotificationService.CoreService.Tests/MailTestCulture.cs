using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Demo.NotificationService.CoreService.Tests;

/// <summary>Gives the tests the real texts of the mails and a way to run a test in a culture.</summary>
internal static class MailTestCulture
{
    public static IStringLocalizer<MailTexts> Localizer()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ILoggerFactory>(NullLoggerFactory.Instance);
        services.AddLocalization();
        return services.BuildServiceProvider().GetRequiredService<IStringLocalizer<MailTexts>>();
    }

    public static IDisposable Use(string name) => new Scope(name);

    private sealed class Scope : IDisposable
    {
        private readonly CultureInfo _culture = CultureInfo.CurrentCulture;
        private readonly CultureInfo _uiCulture = CultureInfo.CurrentUICulture;

        public Scope(string name)
        {
            CultureInfo.CurrentCulture = new CultureInfo(name);
            CultureInfo.CurrentUICulture = new CultureInfo(name);
        }

        public void Dispose()
        {
            CultureInfo.CurrentCulture = _culture;
            CultureInfo.CurrentUICulture = _uiCulture;
        }
    }
}
