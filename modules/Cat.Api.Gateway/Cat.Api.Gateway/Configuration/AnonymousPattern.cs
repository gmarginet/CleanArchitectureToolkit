using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cat.Api.Gateway.Configuration;

/// <summary>
/// One entry of <see cref="CatGatewayServiceOptions.Anonymous"/>, parsed and checked.
/// </summary>
internal sealed record AnonymousPattern(string[]? Methods, string[] Segments)
{
    private static readonly HashSet<string> KnownMethods = new(StringComparer.OrdinalIgnoreCase)
    {
        "GET", "HEAD", "POST", "PUT", "PATCH", "DELETE", "OPTIONS", "TRACE"
    };

    /// <summary>
    /// Parses a pattern such as <c>GET,HEAD /books/**</c>. A pattern without methods, or with <c>*</c>, matches
    /// every method.
    /// </summary>
    public static bool TryParse(string? text, out AnonymousPattern pattern, out string error)
    {
        pattern = new AnonymousPattern(null, []);
        error = string.Empty;

        if (string.IsNullOrWhiteSpace(text))
        {
            error = "An anonymous pattern is empty.";
            return false;
        }

        var trimmed = text.Trim();
        string[]? methods = null;
        string path;

        if (trimmed.StartsWith('/'))
        {
            path = trimmed;
        }
        else
        {
            var space = trimmed.IndexOf(' ');
            if (space < 0)
            {
                error = $"The anonymous pattern '{text}' has no path. Write it like 'GET /books/**'.";
                return false;
            }

            var methodText = trimmed[..space];
            path = trimmed[(space + 1)..].Trim();

            if (methodText != "*")
            {
                methods = methodText.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(m => m.Trim().ToUpperInvariant()).ToArray();
                var unknown = methods.FirstOrDefault(m => !KnownMethods.Contains(m));
                if (methods.Length == 0 || unknown is not null)
                {
                    error = $"The anonymous pattern '{text}' has an unknown http method '{unknown ?? methodText}'.";
                    return false;
                }
            }
        }

        if (!path.StartsWith('/'))
        {
            error = $"The path of the anonymous pattern '{text}' must start with '/'.";
            return false;
        }

        var segments = path.Split('/', StringSplitOptions.None).Skip(1).ToArray();
        if (segments.Length > 1 && segments[^1].Length == 0) segments = segments[..^1];
        if (path == "/") segments = [];

        for (var i = 0; i < segments.Length; i++)
        {
            var segment = segments[i];
            if (segment.Length == 0)
            {
                error = $"The path of the anonymous pattern '{text}' has an empty segment.";
                return false;
            }

            if (segment == "**")
            {
                if (i != segments.Length - 1)
                {
                    error = $"In the anonymous pattern '{text}', '**' can only be the last segment.";
                    return false;
                }

                continue;
            }

            if (segment == "*") continue;

            if (segment is "." or ".." || !segment.All(IsLiteralCharacter))
            {
                error = $"The segment '{segment}' of the anonymous pattern '{text}' can only hold letters, digits and - . _ ~ %.";
                return false;
            }
        }

        pattern = new AnonymousPattern(methods, segments);
        return true;
    }

    /// <summary>
    /// Writes the pattern as an ASP.NET Core route template, after the prefix of the service.
    /// </summary>
    public string ToRouteTemplate(string prefix)
    {
        var builder = new StringBuilder(prefix == "/" ? string.Empty : prefix);
        var parameter = 0;

        foreach (var segment in Segments)
        {
            builder.Append('/');
            builder.Append(segment switch
            {
                "**" => "{**catchAll}",
                "*" => $"{{segment{parameter++}}}",
                _ => segment
            });
        }

        if (builder.Length == 0) builder.Append('/');
        return builder.ToString();
    }

    private static bool IsLiteralCharacter(char c) =>
        char.IsAsciiLetterOrDigit(c) || c is '-' or '.' or '_' or '~' or '%';
}
