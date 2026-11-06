using System;
using System.Collections.Generic;
using System.Linq;

namespace Cat.Api.Gateway.Configuration;

/// <summary>
/// Checks the gateway configuration. A configuration that fails never goes live.
/// </summary>
internal static class CatGatewayOptionsValidator
{
    private static readonly TimeSpan MinimumAssertionLifetime = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan MaximumAssertionLifetime = TimeSpan.FromMinutes(5);

    public static IReadOnlyList<string> Validate(CatGatewayOptions options, bool signingKeyAvailable)
    {
        var errors = new List<string>();

        ValidateServices(options, signingKeyAvailable, errors);
        ValidateAuthentication(options, errors);
        ValidateAssertion(options, errors);

        if (options.RateLimit.Enabled && (options.RateLimit.PermitLimit <= 0 || options.RateLimit.Window <= TimeSpan.Zero))
            errors.Add("RateLimit: PermitLimit and Window must be greater than zero.");

        if (options.Limits.MaxRequestBodySize <= 0)
            errors.Add("Limits: MaxRequestBodySize must be greater than zero.");

        ValidateCors(options.Cors, errors);
        return errors;
    }

    public static string EffectivePath(string name, CatGatewayServiceOptions service)
    {
        var path = string.IsNullOrWhiteSpace(service.Path) ? "/" + name : service.Path.Trim();
        return path.Length > 1 ? path.TrimEnd('/') : path;
    }

    public static IReadOnlyList<string> EffectiveAddresses(CatGatewayServiceOptions service) =>
        service.Addresses.Length > 0 ? service.Addresses : string.IsNullOrWhiteSpace(service.Address) ? [] : [service.Address];

    public static bool EffectiveGatewayOnly(CatGatewayOptions options, CatGatewayServiceOptions service) =>
        service.GatewayOnly ?? options.Defaults.GatewayOnly;

    public static TimeSpan EffectiveTimeout(CatGatewayOptions options, CatGatewayServiceOptions service) =>
        service.Timeout ?? options.Defaults.Timeout;

    private static void ValidateServices(CatGatewayOptions options, bool signingKeyAvailable, List<string> errors)
    {
        var paths = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        if (options.Defaults.Timeout <= TimeSpan.Zero)
            errors.Add("Defaults: Timeout must be greater than zero.");

        foreach (var (name, service) in options.Services)
        {
            var label = $"Services:{name}";

            if (string.IsNullOrWhiteSpace(name) || !IsValidName(name))
                errors.Add($"{label}: the name can only hold letters, digits and - . _ and must start with a letter or digit.");

            if (service is null)
            {
                errors.Add($"{label}: the service has no settings. Give it at least an Address.");
                continue;
            }

            var addresses = EffectiveAddresses(service);
            if (service.Addresses.Length > 0 && !string.IsNullOrWhiteSpace(service.Address))
                errors.Add($"{label}: use Address or Addresses, not both.");
            if (addresses.Count == 0)
                errors.Add($"{label}: Address is required.");
            foreach (var address in addresses)
            {
                if (!Uri.TryCreate(address, UriKind.Absolute, out var uri) || uri.Scheme is not ("http" or "https"))
                    errors.Add($"{label}: '{address}' is not an absolute http or https address.");
            }

            var path = EffectivePath(name, service);
            if (!IsValidPath(path))
                errors.Add($"{label}: the path '{path}' must start with '/' and can only hold letters, digits and - . _ ~ % between the slashes.");
            else if (!paths.TryAdd(path, name))
                errors.Add($"{label}: the path '{path}' is already used by the service '{paths[path]}'.");

            foreach (var text in service.Anonymous)
            {
                if (!AnonymousPattern.TryParse(text, out _, out var error))
                    errors.Add($"{label}: {error}");
            }

            if (!string.IsNullOrEmpty(service.HealthCheckPath) && !service.HealthCheckPath.StartsWith('/'))
                errors.Add($"{label}: HealthCheckPath must start with '/'.");

            if (EffectiveTimeout(options, service) <= TimeSpan.Zero)
                errors.Add($"{label}: Timeout must be greater than zero.");

            if (service.HealthCheckInterval <= TimeSpan.Zero)
                errors.Add($"{label}: HealthCheckInterval must be greater than zero.");

            if (EffectiveGatewayOnly(options, service) && !signingKeyAvailable)
                errors.Add($"{label}: GatewayOnly needs a signing key. Set Assertion:PrivateKeyPem or Assertion:PrivateKeyPemFile. Only the Development environment generates a key.");
        }
    }

    private static void ValidateAuthentication(CatGatewayOptions options, List<string> errors)
    {
        var needsToken = options.Services.Values.Any(service => service is not null && !IsFullyAnonymous(service));
        var authentication = options.Authentication;

        if (!string.IsNullOrWhiteSpace(authentication.Authority) &&
            !Uri.TryCreate(authentication.Authority, UriKind.Absolute, out _))
            errors.Add("Authentication: Authority is not an absolute address.");

        if (!needsToken) return;

        if (string.IsNullOrWhiteSpace(authentication.Authority))
            errors.Add("Authentication: Authority is required, because at least one endpoint needs a token. Mark every endpoint anonymous if you do not want authentication.");
        if (string.IsNullOrWhiteSpace(authentication.Audience))
            errors.Add("Authentication: Audience is required, because at least one endpoint needs a token.");
    }

    private static void ValidateAssertion(CatGatewayOptions options, List<string> errors)
    {
        var assertion = options.Assertion;

        if (string.IsNullOrWhiteSpace(assertion.Issuer))
            errors.Add("Assertion: Issuer is required.");
        if (assertion.Lifetime < MinimumAssertionLifetime || assertion.Lifetime > MaximumAssertionLifetime)
            errors.Add("Assertion: Lifetime must be between 5 seconds and 5 minutes.");
        if (!assertion.JwksPath.StartsWith('/'))
            errors.Add("Assertion: JwksPath must start with '/'.");
        if (!string.IsNullOrWhiteSpace(assertion.PrivateKeyPem) && !string.IsNullOrWhiteSpace(assertion.PrivateKeyPemFile))
            errors.Add("Assertion: use PrivateKeyPem or PrivateKeyPemFile, not both.");
    }

    private static void ValidateCors(CatGatewayCorsOptions cors, List<string> errors)
    {
        foreach (var origin in cors.AllowedOrigins)
        {
            if (origin == "*")
            {
                if (cors.AllowCredentials)
                    errors.Add("Cors: '*' cannot be combined with AllowCredentials.");
                continue;
            }

            if (!Uri.TryCreate(origin, UriKind.Absolute, out var uri) || uri.Scheme is not ("http" or "https") ||
                uri.AbsolutePath != "/" || !string.IsNullOrEmpty(uri.Query))
                errors.Add($"Cors: '{origin}' is not an origin. Write it like 'https://shop.example.com', without a path.");
        }
    }

    private static bool IsFullyAnonymous(CatGatewayServiceOptions service) =>
        service.Anonymous.Any(text =>
            AnonymousPattern.TryParse(text, out var pattern, out _) &&
            pattern.Methods is null && pattern.Segments is ["**"]);

    private static bool IsValidName(string name) =>
        char.IsAsciiLetterOrDigit(name[0]) && name.All(c => char.IsAsciiLetterOrDigit(c) || c is '-' or '.' or '_');

    private static bool IsValidPath(string path)
    {
        if (!path.StartsWith('/')) return false;
        if (path == "/") return true;

        return path[1..].Split('/').All(segment =>
            segment.Length > 0 && segment is not ("." or "..") &&
            segment.All(c => char.IsAsciiLetterOrDigit(c) || c is '-' or '.' or '_' or '~' or '%'));
    }
}
