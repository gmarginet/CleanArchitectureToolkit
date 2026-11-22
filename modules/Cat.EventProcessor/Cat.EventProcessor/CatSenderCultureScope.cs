using System;
using System.Globalization;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;

namespace Cat.EventProcessor;

/// <summary>
/// Sets the culture of the sender for the handling of one message and puts the old culture back when it ends.
/// </summary>
internal sealed class CatSenderCultureScope : IDisposable
{
    private readonly CultureInfo? _previousCulture;
    private readonly CultureInfo? _previousUICulture;

    private CatSenderCultureScope(CultureInfo previousCulture, CultureInfo previousUICulture)
    {
        _previousCulture = previousCulture;
        _previousUICulture = previousUICulture;
    }

    private CatSenderCultureScope()
    {
    }

    /// <summary>
    /// Starts the scope. It does nothing when the service did not turn the option on, or when the message has no usable culture.
    /// </summary>
    /// <param name="enabled">True when the service applies the culture of the sender.</param>
    /// <param name="message">The incoming message.</param>
    /// <returns>A scope to dispose when the handling ends.</returns>
    public static IDisposable Begin(bool enabled, CatIncomingMessage message)
    {
        if (!enabled
            || !message.Properties.TryGetValue(CatMessageProperties.Culture, out var name)
            || string.IsNullOrWhiteSpace(name))
        {
            return new CatSenderCultureScope();
        }

        CultureInfo culture;
        try
        {
            culture = CultureInfo.GetCultureInfo(name);
        }
        catch (CultureNotFoundException)
        {
            return new CatSenderCultureScope();
        }

        var scope = new CatSenderCultureScope(CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        return scope;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (_previousCulture != null && _previousUICulture != null)
        {
            CultureInfo.CurrentCulture = _previousCulture;
            CultureInfo.CurrentUICulture = _previousUICulture;
        }
    }
}
