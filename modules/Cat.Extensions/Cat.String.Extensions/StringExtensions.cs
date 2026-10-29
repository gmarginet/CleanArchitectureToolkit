using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Cat.String.Extensions;

/// <summary>
/// Extension methods for <see cref="string"/>.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Formats a named message template, for example <c>"User {UserId} logged in"</c>, by converting each named
    /// placeholder to a positional one and passing the result to <see cref="string.Format(string, object?[])"/>.
    /// </summary>
    /// <param name="format">The named format string. Placeholder names are only there for readability; values are matched by position.</param>
    /// <param name="args">The values to substitute into the placeholders, in order.</param>
    /// <returns>The formatted string.</returns>
    public static string NamedFormat([StructuredMessageTemplate] this string format, params object?[] args)
    {
        var resultBuilder = new StringBuilder();
        var valueCounter = 0;
        var scanIndex = 0;
        var endIndex = format.Length;

        while (scanIndex < endIndex)
        {
            var openBraceIndex = FindBraceIndex(format, '{', scanIndex, endIndex);
            if (scanIndex == 0 && openBraceIndex == endIndex)
            {
                resultBuilder.Append(format);
                break;
            }
		
            var closeBraceIndex = FindBraceIndex(format, '}', openBraceIndex, endIndex);
            if (closeBraceIndex == endIndex)
            {
                resultBuilder.Append(format.Substring(scanIndex, endIndex - scanIndex));
                break;
            }
		
            var formatDelimiterIndex = format.Substring(openBraceIndex, closeBraceIndex - openBraceIndex).IndexOfAny([',', ':']);
            formatDelimiterIndex = formatDelimiterIndex < 0 ? closeBraceIndex : formatDelimiterIndex + openBraceIndex;

            resultBuilder.Append(format.Substring(scanIndex, openBraceIndex - scanIndex + 1));
            resultBuilder.Append(valueCounter.ToString(CultureInfo.InvariantCulture));
            valueCounter++;
            resultBuilder.Append(format.Substring(formatDelimiterIndex, closeBraceIndex - formatDelimiterIndex + 1));

            scanIndex = closeBraceIndex + 1;
        }
            
        return string.Format(resultBuilder.ToString(), args);
    }

    /// <summary>
    /// Finds the index of the next unescaped occurrence of <paramref name="brace"/>, treating a doubled brace as an escape.
    /// </summary>
    /// <param name="format">The format string to scan.</param>
    /// <param name="brace">The brace character to find, either <c>'{'</c> or <c>'}'</c>.</param>
    /// <param name="startIndex">The index to start scanning from.</param>
    /// <param name="endIndex">The index to stop scanning at.</param>
    /// <returns>The index of the brace, or <paramref name="endIndex"/> if none was found.</returns>
    private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex)
    {
        var braceIndex = endIndex;
        var scanIndex = startIndex;
        var braceOccurrenceCount = 0;

        while (scanIndex < endIndex)
        {
            if (braceOccurrenceCount > 0 && format[scanIndex] != brace)
            {
                if (braceOccurrenceCount % 2 == 0)
                {
                    braceOccurrenceCount = 0;
                    braceIndex = endIndex;
                }
                else
                {
                    break;
                }
            }
            else if (format[scanIndex] == brace)
            {
                if (brace == '}')
                {
                    if (braceOccurrenceCount == 0)
                    {
                        braceIndex = scanIndex;
                    }
                }
                else
                {
                    braceIndex = scanIndex;
                }

                braceOccurrenceCount++;
            }

            scanIndex++;
        }

        return braceIndex;
    }
    
    /// <summary>
    /// Compiles a regular expression with a two-second matching timeout, so a pathological pattern can't hang the caller.
    /// </summary>
    /// <param name="regexPattern">The regex pattern to compile.</param>
    /// <param name="options">The options to compile the regex with.</param>
    /// <returns>The compiled <see cref="Regex"/>.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="regexPattern"/> isn't a valid regex pattern.</exception>
    public static Regex CreateRegex(this string regexPattern, RegexOptions options = RegexOptions.None)
    {
        try
        {
            return new Regex(regexPattern, options, TimeSpan.FromSeconds(2.0));
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException($"Invalid regex expression: {regexPattern}", e);
        }
    }
}